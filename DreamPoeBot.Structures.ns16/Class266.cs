using System;
using System.Collections.Generic;
using System.IO;

namespace DreamPoeBot.Structures.ns16;

internal class Class266
{
	internal class Class267
	{
		private const uint uint_0 = 1540483477u;

		private const int int_0 = 24;

		public unsafe static uint smethod_0(byte[] byte_0, uint uint_1 = 3314489979u)
		{
			//The blocks IL_011f, IL_0125, IL_012b, IL_0131, IL_0179, IL_0181 are reachable both inside and outside the pinned region starting at IL_011b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			int num = byte_0.Length;
			if (num != 0)
			{
				uint num2 = uint_1 ^ (uint)num;
				int num3 = num & 3;
				int num4 = num >> 2;
				uint num5 = default(uint);
				uint num7 = default(uint);
				while (true)
				{
					fixed (byte* ptr = &byte_0[0])
					{
						while (true)
						{
							IL_0107:
							uint* ptr2 = (uint*)ptr;
							while (true)
							{
								IL_0102:
								if (num4 == 0)
								{
									while (true)
									{
										IL_00af:
										switch (num3)
										{
										case 1:
											goto IL_0133;
										case 2:
											goto IL_0143;
										case 3:
											goto IL_0154;
										}
										int num6 = ((int)num5 * -860431720) ^ 0x5EA2D521;
										while (true)
										{
											switch ((num5 = (uint)num6 ^ 0xA6F023D0u) % 27u)
											{
											case 3u:
												break;
											case 24u:
												num6 = ((int)num5 * -1596310164) ^ -1399645674;
												continue;
											case 4u:
												goto IL_00af;
											case 5u:
												goto IL_00c8;
											case 10u:
												goto IL_00cd;
											case 17u:
												goto IL_00e1;
											case 15u:
												goto IL_00eb;
											case 2u:
												goto IL_00f3;
											case 9u:
												goto IL_00fc;
											case 0u:
											case 8u:
												goto IL_0102;
											case 1u:
											case 12u:
												goto IL_0107;
											case 26u:
												num4 = num >> 2;
												break;
											case 16u:
												num3 = num & 3;
												goto case 26u;
											case 25u:
												num2 = uint_1 ^ (uint)num;
												goto case 16u;
											case 6u:
											case 7u:
												return 0u;
											case 20u:
												goto IL_0133;
											case 23u:
												goto IL_0143;
											case 22u:
												goto IL_0154;
											case 13u:
												goto IL_0166;
											case 11u:
											case 14u:
											case 18u:
												goto end_IL_0114;
											case 19u:
												num2 *= 1540483477;
												goto default;
											default:
												return num2 ^ (num2 >> 15);
											}
											break;
										}
										break;
										IL_0143:
										num2 ^= (ushort)(*ptr2);
										num2 *= 1540483477;
										goto end_IL_0114;
										IL_0133:
										num2 ^= *(byte*)ptr2;
										num2 *= 1540483477;
										goto end_IL_0114;
										IL_0154:
										num2 ^= (ushort)(*ptr2);
										num2 ^= (uint)(((byte*)ptr2)[2] << 16);
										goto IL_0166;
										IL_0166:
										num2 *= 1540483477;
										goto end_IL_0114;
									}
									break;
								}
								goto IL_00c8;
								IL_00fc:
								ptr2++;
								continue;
								IL_00c8:
								num7 = *ptr2;
								goto IL_00cd;
								IL_00cd:
								num7 *= 1540483477;
								num7 ^= num7 >> 24;
								goto IL_00e1;
								IL_00e1:
								num7 *= 1540483477;
								goto IL_00eb;
								IL_00eb:
								num2 *= 1540483477;
								goto IL_00f3;
								IL_00f3:
								num2 ^= num7;
								num4--;
								goto IL_00fc;
							}
							break;
						}
					}
					continue;
					end_IL_0114:
					break;
				}
				num2 ^= num2 >> 13;
				num2 *= 1540483477;
				return num2 ^ (num2 >> 15);
			}
			return 0u;
		}
	}

	internal Struct124 struct124_0;

	internal Struct125 struct125_0;

	private IntPtr[] intptr_0;

	public const string string_0 = "poe-3.3.1.2-r1 B";

	public const uint uint_0 = 1259488902u;

	public const uint uint_1 = 2672439318u;

	public const string string_1 = "poe_cis-2.2.2.6 B";

	public const uint uint_2 = 2127794603u;

	public const string string_2 = "poe_sg-2.2.2.5 B";

	public const uint uint_3 = 2429995333u;

	public const string string_3 = "poe_tw-2.2.2.4 B";

	public const uint uint_4 = 4195082080u;

	private T[] method_2<T>(ArraySegment<T> arraySegment_0) where T : struct
	{
		List<T> list = new List<T>();
		for (int i = arraySegment_0.Offset; i < arraySegment_0.Offset + arraySegment_0.Count; i++)
		{
			list.Add(arraySegment_0.Array[i]);
		}
		return list.ToArray();
	}

	private static uint smethod_0(uint uint_5, byte byte_0)
	{
		uint num = (uint)((byte_0 << 24) | (byte_0 << 16) | (byte_0 << 8) | byte_0);
		return uint_5 ^ num;
	}

	public void method_3()
	{
		intptr_0 = null;
		struct124_0 = default(Struct124);
		struct125_0 = default(Struct125);
	}

	public static uint smethod_1(string string_4)
	{
		return Class267.smethod_0(File.ReadAllBytes(string_4));
	}

	public void method_4(IntPtr[] intptr_1, out ArraySegment<IntPtr> arraySegment_0, out ArraySegment<IntPtr> arraySegment_1)
	{
		arraySegment_0 = new ArraySegment<IntPtr>(intptr_1, 0, 53);
		arraySegment_1 = new ArraySegment<IntPtr>(intptr_1, 53, 134);
		arraySegment_0 = new ArraySegment<IntPtr>(intptr_1, 0, 53);
		arraySegment_1 = new ArraySegment<IntPtr>(intptr_1, 53, 134);
	}

	public void method_5(IntPtr[] intptr_1, out ArraySegment<IntPtr> arraySegment_0, out ArraySegment<IntPtr> arraySegment_1)
	{
		arraySegment_0 = new ArraySegment<IntPtr>(intptr_1, 0, 35);
		arraySegment_1 = new ArraySegment<IntPtr>(intptr_1, 35, 102);
	}

	public void method_6(IntPtr[] intptr_1, out ArraySegment<IntPtr> arraySegment_0, out ArraySegment<IntPtr> arraySegment_1)
	{
		arraySegment_0 = new ArraySegment<IntPtr>(intptr_1, 0, 35);
		arraySegment_1 = new ArraySegment<IntPtr>(intptr_1, 35, 102);
	}

	public void method_7(IntPtr[] intptr_1, out ArraySegment<IntPtr> arraySegment_0, out ArraySegment<IntPtr> arraySegment_1)
	{
		arraySegment_0 = new ArraySegment<IntPtr>(intptr_1, 0, 35);
		arraySegment_1 = new ArraySegment<IntPtr>(intptr_1, 35, 102);
	}
}
