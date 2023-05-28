using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Sockets : Component
{
	public class SocketedGem
	{
		public int SocketIndex;

		public Entity GemEntity;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct Struct212
	{
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		[UnsafeValueType]
		public struct Struct213
		{
			public int int_0;

			public int int_1;

			public int int_2;

			public int int_3;

			public int int_4;

			public int int_5;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		[UnsafeValueType]
		public struct Struct214
		{
			public long long_0;

			public long long_1;

			public long long_2;

			public long long_3;

			public long long_4;

			public long long_5;
		}

		private Struct253 struct253_0;

		private IntPtr intptr_0;

		public Struct213 struct213_Colors;

		public Struct214 struct214_Gems;

		public NativeVector nativeVector_SocketLinks;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;
	}

	private PerFrameCachedValue<Struct212> perFrameCachedValue_1;

	public int LargestLinkSize
	{
		get
		{
			if (base.Address == 0L)
			{
				return 0;
			}
			long first = Struct212_0.nativeVector_SocketLinks.First;
			long last = Struct212_0.nativeVector_SocketLinks.Last;
			long num = last - first;
			if (num > 0L && num <= 6L)
			{
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					int num3 = base.M.ReadByte(first + i);
					if (num3 > num2)
					{
						num2 = num3;
					}
				}
				return num2;
			}
			return 0;
		}
	}

	public List<int[]> Links
	{
		get
		{
			List<int[]> list = new List<int[]>();
			if (base.Address == 0L)
			{
				return list;
			}
			long first = Struct212_0.nativeVector_SocketLinks.First;
			long last = Struct212_0.nativeVector_SocketLinks.Last;
			long num = last - first;
			if (num > 0L && num <= 6L)
			{
				int num2 = 0;
				List<int> socketList = SocketList;
				for (int i = 0; i < num; i++)
				{
					int num3 = base.M.ReadByte(first + i);
					int[] array = new int[num3];
					for (int j = 0; j < num3; j++)
					{
						array[j] = socketList[j + num2];
					}
					list.Add(array);
					num2 += num3;
				}
				return list;
			}
			return list;
		}
	}

	public List<int> SocketList
	{
		get
		{
			List<int> list = new List<int>();
			if (base.Address != 0L)
			{
				Struct212.Struct213 struct213_Colors = Struct212_0.struct213_Colors;
				if (struct213_Colors.int_0 >= 1 && struct213_Colors.int_0 <= 5)
				{
					list.Add(struct213_Colors.int_0);
				}
				if (struct213_Colors.int_1 >= 1 && struct213_Colors.int_1 <= 5)
				{
					list.Add(struct213_Colors.int_1);
				}
				if (struct213_Colors.int_2 >= 1 && struct213_Colors.int_2 <= 5)
				{
					list.Add(struct213_Colors.int_2);
				}
				if (struct213_Colors.int_3 >= 1 && struct213_Colors.int_3 <= 5)
				{
					list.Add(struct213_Colors.int_3);
				}
				if (struct213_Colors.int_4 >= 1 && struct213_Colors.int_4 <= 5)
				{
					list.Add(struct213_Colors.int_4);
				}
				if (struct213_Colors.int_5 >= 1 && struct213_Colors.int_5 <= 5)
				{
					list.Add(struct213_Colors.int_5);
				}
				return list;
			}
			return list;
		}
	}

	public int NumberOfSockets => SocketList.Count;

	public bool IsRGB
	{
		get
		{
			if (base.Address != 0L)
			{
				return Links.Any((int[] current) => current.Length >= 3 && current.Contains(1) && current.Contains(2) && current.Contains(3));
			}
			return false;
		}
	}

	public List<string> SocketGroup
	{
		get
		{
			List<string> list = new List<string>();
			foreach (int[] link in Links)
			{
				StringBuilder stringBuilder = new StringBuilder();
				int[] array = link;
				for (int i = 0; i < array.Length; i++)
				{
					switch (array[i])
					{
					case 1:
						stringBuilder.Append(global::_003CModule_003E.smethod_9<string>(3753619683u));
						break;
					case 2:
						stringBuilder.Append(global::_003CModule_003E.smethod_6<string>(2344245659u));
						break;
					case 3:
						stringBuilder.Append(global::_003CModule_003E.smethod_7<string>(1939486993u));
						break;
					case 4:
						stringBuilder.Append(global::_003CModule_003E.smethod_9<string>(3585564333u));
						break;
					case 5:
						stringBuilder.Append('A');
						break;
					}
				}
				list.Add(stringBuilder.ToString());
			}
			return list;
		}
	}

	public List<SocketedGem> SocketedGems
	{
		get
		{
			List<SocketedGem> list = new List<SocketedGem>();
			Struct212.Struct214 struct214_Gems = Struct212_0.struct214_Gems;
			if (struct214_Gems.long_0 != 0L)
			{
				list.Add(new SocketedGem
				{
					SocketIndex = 0,
					GemEntity = ReadObject<EntityWrapper>(struct214_Gems.long_0)
				});
			}
			if (struct214_Gems.long_1 != 0L)
			{
				list.Add(new SocketedGem
				{
					SocketIndex = 1,
					GemEntity = ReadObject<EntityWrapper>(struct214_Gems.long_1)
				});
			}
			if (struct214_Gems.long_2 != 0L)
			{
				list.Add(new SocketedGem
				{
					SocketIndex = 2,
					GemEntity = ReadObject<EntityWrapper>(struct214_Gems.long_2)
				});
			}
			if (struct214_Gems.long_3 != 0L)
			{
				list.Add(new SocketedGem
				{
					SocketIndex = 3,
					GemEntity = ReadObject<EntityWrapper>(struct214_Gems.long_3)
				});
			}
			if (struct214_Gems.long_4 != 0L)
			{
				list.Add(new SocketedGem
				{
					SocketIndex = 4,
					GemEntity = ReadObject<EntityWrapper>(struct214_Gems.long_4)
				});
			}
			if (struct214_Gems.long_5 != 0L)
			{
				list.Add(new SocketedGem
				{
					SocketIndex = 5,
					GemEntity = ReadObject<EntityWrapper>(struct214_Gems.long_5)
				});
			}
			return list;
		}
	}

	public string DisplayString
	{
		get
		{
			SocketColor[] socketColors = SocketColors;
			if (socketColors.All((SocketColor x) => x == SocketColor.None))
			{
				return global::_003CModule_003E.smethod_6<string>(1946946057u);
			}
			byte[] socketLinks = SocketLinks;
			int num = 0;
			string text = "";
			byte[] array = socketLinks;
			foreach (byte b in array)
			{
				for (int j = 0; j < b; j++)
				{
					text += socketColors[num++].ToString()[0];
					text = ((b <= 1 || j >= b - 1) ? (text + global::_003CModule_003E.smethod_6<string>(545359364u)) : (text + global::_003CModule_003E.smethod_7<string>(4138036762u)));
				}
			}
			return text;
		}
	}

	public Item[] Gems
	{
		get
		{
			Item[] array = new Item[6];
			uint num3 = default(uint);
			while (true)
			{
				int num = 0;
				while (true)
				{
					if (num < 6)
					{
						while (true)
						{
							long num2 = 0L;
							while (true)
							{
								switch (num)
								{
								default:
								{
									int num4 = (int)((num3 * 1126430460) ^ 0x1DD7BE92);
									while (true)
									{
										switch ((num3 = (uint)num4 ^ 0xB19BAE8Cu) % 18u)
										{
										case 4u:
											num4 = (int)((num3 * 1946820966) ^ 0x771CBBD9);
											continue;
										case 11u:
											break;
										case 3u:
											goto end_IL_0085;
										case 7u:
											goto IL_00b4;
										case 2u:
											goto IL_00c7;
										case 14u:
											goto IL_00da;
										case 10u:
											goto IL_00ed;
										case 16u:
											goto IL_0100;
										case 9u:
											goto IL_0113;
										case 8u:
										case 15u:
										case 17u:
											goto IL_0124;
										case 6u:
											goto IL_0127;
										case 5u:
											goto IL_0134;
										case 0u:
											goto end_IL_00a8;
										case 12u:
										case 13u:
											goto end_IL_0138;
										default:
											goto IL_0145;
										}
										break;
									}
									break;
								}
								case 0:
									goto IL_00b4;
								case 1:
									goto IL_00c7;
								case 2:
									goto IL_00da;
								case 3:
									goto IL_00ed;
								case 4:
									goto IL_0100;
								case 5:
									goto IL_0113;
									IL_0134:
									num++;
									goto end_IL_00a8;
									IL_0113:
									num2 = Struct212_0.struct214_Gems.long_5;
									goto IL_0124;
									IL_0100:
									num2 = Struct212_0.struct214_Gems.long_4;
									goto IL_0124;
									IL_00ed:
									num2 = Struct212_0.struct214_Gems.long_3;
									goto IL_0124;
									IL_00da:
									num2 = Struct212_0.struct214_Gems.long_2;
									goto IL_0124;
									IL_00c7:
									num2 = Struct212_0.struct214_Gems.long_1;
									goto IL_0124;
									IL_00b4:
									num2 = Struct212_0.struct214_Gems.long_0;
									goto IL_0124;
									IL_0124:
									if (num2 != 0L)
									{
										goto IL_0127;
									}
									goto IL_0134;
									IL_0127:
									array[num] = new Item(num2, -(num + 1));
									goto IL_0134;
								}
								continue;
								end_IL_0085:
								break;
							}
							continue;
							end_IL_00a8:
							break;
						}
						continue;
					}
					goto IL_0145;
					IL_0145:
					return array;
					continue;
					end_IL_0138:
					break;
				}
			}
		}
	}

	public SocketColor[] SocketColors
	{
		get
		{
			SocketColor[] array = new SocketColor[6];
			for (int i = 0; i < 6; i++)
			{
				SocketColor socketColor = SocketColor.None;
				switch (i)
				{
				case 0:
					socketColor = (SocketColor)Struct212_0.struct213_Colors.int_0;
					break;
				case 1:
					socketColor = (SocketColor)Struct212_0.struct213_Colors.int_1;
					break;
				case 2:
					socketColor = (SocketColor)Struct212_0.struct213_Colors.int_2;
					break;
				case 3:
					socketColor = (SocketColor)Struct212_0.struct213_Colors.int_3;
					break;
				case 4:
					socketColor = (SocketColor)Struct212_0.struct213_Colors.int_4;
					break;
				case 5:
					socketColor = (SocketColor)Struct212_0.struct213_Colors.int_5;
					break;
				}
				array[i] = socketColor;
			}
			return array;
		}
	}

	public List<Item[]> SocketedSkillGemsByLinks
	{
		get
		{
			List<Item[]> list = new List<Item[]>();
			byte[] socketLinks = SocketLinks;
			int num = 0;
			byte[] array = socketLinks;
			foreach (byte b in array)
			{
				if (b != 0)
				{
					Item[] array2 = new Item[b];
					for (int j = 0; j < b; j++)
					{
						array2[j] = Gems[num++];
					}
					list.Add(array2);
				}
			}
			return list;
		}
	}

	public byte[] SocketLinks
	{
		get
		{
			byte[] array = new byte[6];
			List<byte> list = Containers.StdByteVector<byte>(Struct212_0.nativeVector_SocketLinks);
			for (int i = 0; i < list.Count; i++)
			{
				array[i] = list[i];
			}
			return array;
		}
	}

	internal Struct212 Struct212_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct212>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	private Struct212 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct212>(base.Address);
	}
}
