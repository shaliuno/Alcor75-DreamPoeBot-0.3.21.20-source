using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Structures.ns14;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game;

public class Inventory : RemoteMemoryObject
{
	public class HashNodeStruct242 : RemoteMemoryObject
	{
		private int _struct242Size = -1;

		private int Struct242Size
		{
			get
			{
				if (_struct242Size == -1)
				{
					_struct242Size = MarshalCache<Struct242>.Size;
				}
				return _struct242Size;
			}
		}

		public HashNodeStruct242 Previous => ReadObject<HashNodeStruct242>(base.Address);

		public HashNodeStruct242 Root => ReadObject<HashNodeStruct242>(base.Address + 8L);

		public HashNodeStruct242 Next => ReadObject<HashNodeStruct242>(base.Address + 16L);

		public bool IsNull => GameController.Instance.Memory.ReadByte(base.Address + 25L) != 0;

		public int Key => GameController.Instance.Memory.ReadInt(base.Address + 32L);

		internal Struct242 Value1 => GameController.Instance.Memory.FastIntPtrToStruct<Struct242>(base.Address + 40L, Struct242Size);
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public int col;

		public Inventory _003C_003E4__this;

		internal bool _003CGetItemPlacementGraph_003Eb__0(KeyValuePair<int, Item> x)
		{
			return x.Value.LocationTopLeft == new Vector2i(col, (!_003C_003E4__this._isEldrichTab) ? 1 : 2);
		}
	}

	private LokiPoe.InGameState.SentinelLockerUi.SentinelType _sentinelType;

	private List<int> _storableBaseItemTypeKeys;

	private bool _isEldrichTab;

	private bool _isMavenTab;

	private int _struct244InventorySize = -1;

	public int Id { get; internal set; }

	private int Struct244InventorySize
	{
		get
		{
			if (_struct244InventorySize == -1)
			{
				_struct244InventorySize = MarshalCache<Struct244Inventory>.Size;
			}
			return _struct244InventorySize;
		}
	}

	internal Struct244Inventory Struct244_0 => GameController.Instance.Memory.FastIntPtrToStruct<Struct244Inventory>(base.Address + 320L, Struct244InventorySize);

	public bool IsRequested => Struct244_0.isRequested == 1;

	public InventoryType PageType => Struct244_0.inventoryType_0;

	public InventorySlot PageSlot => Struct244_0.inventorySlot_0;

	public Dictionary<int, Item> ItemMap
	{
		get
		{
			if (!_isEldrichTab)
			{
				uint num = default(uint);
				Dictionary<int, Item> result = default(Dictionary<int, Item>);
				Dictionary<int, Item> source2 = default(Dictionary<int, Item>);
				Dictionary<int, Struct242> source3 = default(Dictionary<int, Struct242>);
				Dictionary<int, Item> source4 = default(Dictionary<int, Item>);
				while (!_isMavenTab)
				{
					while (true)
					{
						if (base.Address != 0L)
						{
							while (true)
							{
								if (PageType != InventoryType.EspeditionLocker)
								{
									while (true)
									{
										if (PageType == InventoryType.SentinelLocker)
										{
											while (true)
											{
												string metadata;
												string metadata2;
												while (true)
												{
													Dictionary<int, Item> source = ReadHashMapStruct242(Struct244_0.nativeMap_ItemMap.Head, Struct244_0.nativeMap_ItemMap.Size).ToDictionary((KeyValuePair<int, Struct242> item) => item.Key, (KeyValuePair<int, Struct242> item) => new Class247(item.Value.intptr_1, item.Key).Item_0);
													metadata = "";
													while (true)
													{
														IL_0134:
														metadata2 = "";
														LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType = _sentinelType;
														while (true)
														{
															IL_0118:
															switch (sentinelType)
															{
															case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
																goto IL_0356;
															case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
																goto IL_037a;
															case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
																goto IL_039e;
															case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
																goto IL_03c0;
															}
															int num2 = ((int)num * -756913456) ^ 0x392AFA09;
															while (true)
															{
																switch ((num = (uint)num2 ^ 0x66847937u) % 27u)
																{
																case 18u:
																	break;
																case 12u:
																	num2 = ((int)num * -872126889) ^ -839673023;
																	continue;
																case 7u:
																	goto IL_0118;
																case 22u:
																	goto IL_0134;
																case 2u:
																	goto end_IL_0010;
																case 11u:
																	goto end_IL_0166;
																case 0u:
																	goto end_IL_0172;
																case 14u:
																	goto end_IL_017e;
																case 6u:
																case 16u:
																	goto end_IL_018d;
																case 15u:
																	goto IL_01a4;
																case 24u:
																	goto IL_01aa;
																case 10u:
																	goto IL_01d1;
																default:
																	goto IL_0216;
																case 26u:
																	goto IL_0281;
																case 13u:
																	goto IL_02ec;
																case 4u:
																	goto IL_0356;
																case 5u:
																	goto IL_0367;
																case 17u:
																	goto IL_037a;
																case 23u:
																	goto IL_038b;
																case 1u:
																	goto IL_039e;
																case 3u:
																	goto IL_03af;
																case 9u:
																case 21u:
																case 25u:
																	goto IL_03c0;
																case 20u:
																	goto end_IL_0197;
																case 8u:
																	return result;
																}
																break;
															}
															break;
															IL_0367:
															metadata2 = global::_003CModule_003E.smethod_8<string>(1059055805u);
															goto IL_03c0;
															IL_03c0:
															return source.Where((KeyValuePair<int, Item> x) => x.Value != null && x.Value.IsValid && (x.Value.Metadata.Contains(metadata) || x.Value.Metadata.Contains(metadata2))).ToDictionary((KeyValuePair<int, Item> x) => x.Key, (KeyValuePair<int, Item> x) => x.Value);
															IL_039e:
															metadata = global::_003CModule_003E.smethod_8<string>(3153654227u);
															goto IL_03af;
															IL_03af:
															metadata2 = global::_003CModule_003E.smethod_9<string>(1215708325u);
															goto IL_03c0;
															IL_037a:
															metadata = global::_003CModule_003E.smethod_9<string>(187322608u);
															goto IL_038b;
															IL_038b:
															metadata2 = global::_003CModule_003E.smethod_7<string>(2333181480u);
															goto IL_03c0;
															IL_0356:
															metadata = global::_003CModule_003E.smethod_9<string>(348693419u);
															goto IL_0367;
														}
														break;
													}
													continue;
													end_IL_0010:
													break;
												}
												continue;
												end_IL_0166:
												break;
											}
											continue;
										}
										goto IL_01aa;
										IL_0216:
										return source2.Where((KeyValuePair<int, Item> x) => x.Value != null && x.Value.IsValid).ToDictionary((KeyValuePair<int, Item> x) => x.Key, (KeyValuePair<int, Item> x) => x.Value);
										IL_01aa:
										source3 = ReadHashMapStruct242(Struct244_0.nativeMap_ItemMap.Head, Struct244_0.nativeMap_ItemMap.Size);
										goto IL_01d1;
										IL_01d1:
										source2 = source3.ToDictionary((KeyValuePair<int, Struct242> item) => item.Key, (KeyValuePair<int, Struct242> item) => new Class247(item.Value.intptr_1, item.Key).Item_0);
										goto IL_0216;
										continue;
										end_IL_0172:
										break;
									}
									continue;
								}
								goto IL_0281;
								IL_02ec:
								return source4.Where((KeyValuePair<int, Item> x) => x.Value != null && x.Value.IsValid && x.Value.Metadata == global::_003CModule_003E.smethod_6<string>(3268587468u)).ToDictionary((KeyValuePair<int, Item> x) => x.Key, (KeyValuePair<int, Item> x) => x.Value);
								IL_0281:
								source4 = ReadHashMapStruct242(Struct244_0.nativeMap_ItemMap.Head, Struct244_0.nativeMap_ItemMap.Size).ToDictionary((KeyValuePair<int, Struct242> item) => item.Key, (KeyValuePair<int, Struct242> item) => new Class247(item.Value.intptr_1, item.Key).Item_0);
								goto IL_02ec;
								continue;
								end_IL_017e:
								break;
							}
							continue;
						}
						goto IL_01a4;
						IL_01a4:
						return new Dictionary<int, Item>();
						continue;
						end_IL_018d:
						break;
					}
					continue;
					end_IL_0197:
					break;
				}
			}
			Dictionary<int, Struct242> source5 = ReadHashMapStruct242(Struct244_0.nativeMap_ItemMap.Head, Struct244_0.nativeMap_ItemMap.Size);
			Dictionary<int, Item> source6 = source5.ToDictionary((KeyValuePair<int, Struct242> item) => item.Key, (KeyValuePair<int, Struct242> item) => new Class247(item.Value.intptr_1, item.Key).Item_0);
			return source6.Where((KeyValuePair<int, Item> x) => x.Value != null && x.Value.IsValid && IsEldrichMavenBaseItemType(x.Value.BaseItemType.Index)).ToDictionary((KeyValuePair<int, Item> x) => x.Key, (KeyValuePair<int, Item> x) => x.Value);
		}
	}

	public List<Item> Items
	{
		get
		{
			if (base.Address == 0L)
			{
				return new List<Item>();
			}
			return ItemMap.Values.ToList();
		}
	}

	public int Rows
	{
		get
		{
			if (!_isEldrichTab && !_isMavenTab)
			{
				return Struct244_0.rows;
			}
			return 6;
		}
	}

	public int Cols
	{
		get
		{
			if (!_isEldrichTab && !_isMavenTab)
			{
				return Columns;
			}
			return 12;
		}
	}

	public int Columns
	{
		get
		{
			if (!_isEldrichTab && !_isMavenTab)
			{
				return Struct244_0.cols;
			}
			return 12;
		}
	}

	public int InventorySpacePercent
	{
		get
		{
			if (PageType == InventoryType.SentinelLocker)
			{
				return (int)(100.0 * (double)AvailableInventorySquares / 120.0);
			}
			return (int)(100.0 * (double)AvailableInventorySquares / (double)((float)Rows * (float)Columns));
		}
	}

	public int AvailableInventorySquares
	{
		get
		{
			int rows = Rows;
			uint num3 = default(uint);
			int num5 = default(int);
			int num6 = default(int);
			int num7 = default(int);
			int num8 = default(int);
			while (true)
			{
				int columns = Columns;
				while (true)
				{
					bool[,] itemPlacementGraph = GetItemPlacementGraph();
					while (true)
					{
						int num = 0;
						if (PageType == InventoryType.SentinelLocker)
						{
							while (true)
							{
								int num2 = 0;
								LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType = _sentinelType;
								while (true)
								{
									switch (sentinelType)
									{
									case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
										goto IL_0140;
									case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
										goto IL_0145;
									case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
										goto IL_014b;
									case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
										goto IL_014f;
									}
									int num4 = ((int)num3 * -1976090183) ^ -362802898;
									while (true)
									{
										switch ((num3 = (uint)num4 ^ 0x87DEB58Au) % 33u)
										{
										case 5u:
											num4 = (int)((num3 * 1201087139) ^ 0x13D5BA30);
											continue;
										case 19u:
											break;
										case 4u:
											goto end_IL_00c1;
										case 30u:
											goto end_IL_00dd;
										case 24u:
											goto end_IL_00ea;
										case 1u:
										case 17u:
											goto end_IL_00f8;
										case 7u:
											goto IL_010a;
										case 31u:
										case 32u:
											goto IL_010f;
										case 20u:
											goto IL_0114;
										case 11u:
											goto IL_0120;
										case 12u:
											goto IL_0124;
										case 9u:
											goto IL_012c;
										case 28u:
											goto IL_0134;
										case 18u:
										case 26u:
											goto IL_0139;
										default:
											goto IL_013e;
										case 0u:
											goto IL_0140;
										case 8u:
											goto IL_0145;
										case 16u:
											goto IL_014b;
										case 14u:
										case 21u:
											goto IL_014f;
										case 23u:
											goto IL_0155;
										case 3u:
											goto IL_015a;
										case 29u:
											goto IL_0166;
										case 27u:
											goto IL_016a;
										case 6u:
										case 22u:
											goto IL_0170;
										case 2u:
											goto IL_0175;
										case 10u:
										case 13u:
											goto IL_017b;
										case 25u:
											goto IL_0184;
										}
										break;
									}
									continue;
									IL_0166:
									num++;
									goto IL_016a;
									IL_016a:
									num5++;
									goto IL_0170;
									IL_014b:
									num2 = 24;
									goto IL_014f;
									IL_0145:
									num2 = 12;
									goto IL_014f;
									IL_0140:
									num2 = 0;
									goto IL_014f;
									IL_014f:
									num6 = num2;
									goto IL_017b;
									IL_017b:
									if (num6 < num2 + 12)
									{
										goto IL_0155;
									}
									goto IL_0184;
									IL_0184:
									return num;
									IL_0155:
									num5 = 0;
									goto IL_0170;
									IL_0170:
									if (num5 < rows)
									{
										goto IL_015a;
									}
									goto IL_0175;
									IL_0175:
									num6++;
									goto IL_017b;
									IL_015a:
									if (!itemPlacementGraph[num5, num6])
									{
										goto IL_0166;
									}
									goto IL_016a;
									continue;
									end_IL_00c1:
									break;
								}
								continue;
								end_IL_00dd:
								break;
							}
							continue;
						}
						goto IL_010a;
						IL_012c:
						num7++;
						goto IL_0139;
						IL_010a:
						num7 = 0;
						goto IL_0139;
						IL_0139:
						if (num7 < columns)
						{
							goto IL_0134;
						}
						goto IL_013e;
						IL_013e:
						return num;
						IL_0134:
						num8 = 0;
						goto IL_010f;
						IL_010f:
						if (num8 < rows)
						{
							goto IL_0114;
						}
						goto IL_012c;
						IL_0114:
						if (!itemPlacementGraph[num8, num7])
						{
							goto IL_0120;
						}
						goto IL_0124;
						IL_0120:
						num++;
						goto IL_0124;
						IL_0124:
						num8++;
						goto IL_010f;
						continue;
						end_IL_00ea:
						break;
					}
					continue;
					end_IL_00f8:
					break;
				}
			}
		}
	}

	internal Inventory(long inventoryPageContents, int id)
		: base(inventoryPageContents)
	{
		Id = id;
	}

	internal Inventory(long inventoryPageContents)
		: base(inventoryPageContents)
	{
		Id = 0;
	}

	internal Inventory(long inventoryPageContents, LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType)
		: base(inventoryPageContents)
	{
		Id = 0;
		_sentinelType = sentinelType;
	}

	internal Inventory(long inventoryPageContents, bool isEldrichTab = false, bool isMavenTab = false, List<int> storableBaseItemTypeKeys = null)
		: base(inventoryPageContents)
	{
		Id = 0;
		_isEldrichTab = isEldrichTab;
		_isMavenTab = isMavenTab;
		_storableBaseItemTypeKeys = storableBaseItemTypeKeys;
	}

	private Dictionary<int, Struct242> ReadHashMapStruct242(long pointer, uint size)
	{
		Dictionary<int, Struct242> dictionary = new Dictionary<int, Struct242>();
		if (size == 0)
		{
			return dictionary;
		}
		Stack<HashNodeStruct242> stack = new Stack<HashNodeStruct242>();
		HashNodeStruct242 @object = GetObject<HashNodeStruct242>(pointer);
		HashNodeStruct242 root = @object.Root;
		stack.Push(root);
		while (stack.Count != 0)
		{
			HashNodeStruct242 hashNodeStruct = stack.Pop();
			if (hashNodeStruct.Address != 0L)
			{
				if (!hashNodeStruct.IsNull && !dictionary.ContainsKey(hashNodeStruct.Key))
				{
					dictionary.Add(hashNodeStruct.Key, hashNodeStruct.Value1);
				}
				HashNodeStruct242 previous = hashNodeStruct.Previous;
				if (!previous.IsNull)
				{
					stack.Push(previous);
				}
				HashNodeStruct242 next = hashNodeStruct.Next;
				if (!next.IsNull)
				{
					stack.Push(next);
				}
			}
		}
		stack.Clear();
		return dictionary;
	}

	private bool IsEldrichMavenBaseItemType(int index)
	{
		return _storableBaseItemTypeKeys.Any((int x) => x == index - 1);
	}

	public Item FindItemByPos(Vector2i pos)
	{
		return GetItemAtLocation(pos);
	}

	public Item GetItemById(int id)
	{
		if (ItemMap.TryGetValue(id, out var value))
		{
			return value;
		}
		return null;
	}

	public bool NextAvailableInventoryPosition(int w, int h, out Vector2i pos)
	{
		pos = Vector2i.Zero;
		int rows = Rows;
		int columns = Columns;
		for (int i = 0; i < columns; i++)
		{
			for (int j = 0; j < rows; j++)
			{
				if (CanFitItemAt(i, j, w, h, allowOverlap: false, out var _))
				{
					pos = new Vector2i(i, j);
					return true;
				}
			}
		}
		return false;
	}

	public bool[,] GetItemPlacementGraph()
	{
		int rows = Rows;
		uint num2 = default(uint);
		int num4 = default(int);
		int num5 = default(int);
		int num6 = default(int);
		int num7 = default(int);
		int num8 = default(int);
		int num9 = default(int);
		_003C_003Ec__DisplayClass42_0 _003C_003Ec__DisplayClass42_ = default(_003C_003Ec__DisplayClass42_0);
		while (true)
		{
			int columns = Columns;
			while (true)
			{
				bool[,] array = new bool[rows, columns];
				while (true)
				{
					IL_013c:
					if (!_isEldrichTab)
					{
						while (!_isMavenTab)
						{
							while (true)
							{
								List<long> list = Containers.StdLongVector<long>(Struct244_0.nativeVector_ItemPlacementGraph);
								if (PageType == InventoryType.SentinelLocker)
								{
									while (true)
									{
										int num = 0;
										LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType = _sentinelType;
										while (true)
										{
											switch (sentinelType)
											{
											case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
												goto IL_01a0;
											case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
												goto IL_01a5;
											case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
												goto IL_01ab;
											case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
												goto IL_01af;
											}
											int num3 = ((int)num2 * -701413805) ^ -1375969963;
											while (true)
											{
												switch ((num2 = (uint)num3 ^ 0xEEF1345Cu) % 42u)
												{
												case 36u:
													num3 = ((int)num2 * -212395084) ^ 0x3B657707;
													continue;
												case 3u:
													break;
												case 7u:
													goto end_IL_00e8;
												case 24u:
													goto end_IL_0104;
												case 1u:
													goto end_IL_0111;
												case 39u:
													goto IL_013c;
												case 10u:
													goto end_IL_013c;
												case 23u:
												case 40u:
													goto end_IL_0149;
												case 27u:
													goto IL_015c;
												case 35u:
													goto IL_0161;
												case 2u:
													goto IL_0166;
												case 26u:
													goto IL_018e;
												case 17u:
													goto IL_0193;
												case 16u:
												case 29u:
													goto IL_0199;
												default:
													goto IL_019e;
												case 20u:
													goto IL_01a0;
												case 11u:
													goto IL_01a5;
												case 4u:
													goto IL_01ab;
												case 19u:
												case 28u:
												case 37u:
													goto IL_01af;
												case 22u:
													goto IL_01b5;
												case 21u:
													goto IL_01ba;
												case 5u:
												case 9u:
													goto IL_01e2;
												case 6u:
													goto IL_01e7;
												case 8u:
												case 33u:
													goto IL_01ed;
												case 18u:
													goto IL_01f6;
												case 34u:
													goto end_IL_012f;
												case 12u:
													goto IL_01fd;
												case 13u:
													goto IL_0202;
												case 30u:
													goto IL_0209;
												case 25u:
													goto IL_0242;
												case 14u:
												case 31u:
													goto IL_0248;
												case 41u:
													goto IL_024d;
												case 32u:
												case 38u:
													goto IL_0253;
												case 15u:
													goto IL_0258;
												}
												break;
											}
											continue;
											IL_01e7:
											num4++;
											goto IL_01ed;
											IL_01ba:
											array[num5, num4] = (ulong)list[num4 + num5 * columns] > 0uL;
											num5++;
											goto IL_01e2;
											IL_01ab:
											num = 24;
											goto IL_01af;
											IL_01a5:
											num = 12;
											goto IL_01af;
											IL_01a0:
											num = 0;
											goto IL_01af;
											IL_01af:
											num4 = num;
											goto IL_01ed;
											IL_01ed:
											if (num4 < num + 12)
											{
												goto IL_01b5;
											}
											goto IL_01f6;
											IL_01f6:
											return array;
											IL_01b5:
											num5 = 0;
											goto IL_01e2;
											IL_01e2:
											if (num5 < rows)
											{
												goto IL_01ba;
											}
											goto IL_01e7;
											continue;
											end_IL_00e8:
											break;
										}
										continue;
										end_IL_0104:
										break;
									}
									continue;
								}
								goto IL_015c;
								IL_0166:
								array[num6, num7] = (ulong)list[num7 + num6 * columns] > 0uL;
								num6++;
								goto IL_018e;
								IL_015c:
								num7 = 0;
								goto IL_0199;
								IL_0199:
								if (num7 < columns)
								{
									goto IL_0161;
								}
								goto IL_019e;
								IL_019e:
								return array;
								IL_0161:
								num6 = 0;
								goto IL_018e;
								IL_018e:
								if (num6 < rows)
								{
									goto IL_0166;
								}
								goto IL_0193;
								IL_0193:
								num7++;
								goto IL_0199;
								continue;
								end_IL_0111:
								break;
							}
							continue;
							end_IL_012f:
							break;
						}
					}
					num8 = 0;
					goto IL_0253;
					IL_0242:
					num9++;
					goto IL_0248;
					IL_0209:
					_003C_003Ec__DisplayClass42_._003C_003E4__this = this;
					_003C_003Ec__DisplayClass42_.col = num8 + 12 * num9;
					array[num9, num8] = ItemMap.Any(_003C_003Ec__DisplayClass42_._003CGetItemPlacementGraph_003Eb__0);
					goto IL_0242;
					IL_0253:
					if (num8 < columns)
					{
						goto IL_01fd;
					}
					goto IL_0258;
					IL_0258:
					return array;
					IL_01fd:
					num9 = 0;
					goto IL_0248;
					IL_0248:
					if (num9 < rows)
					{
						goto IL_0202;
					}
					goto IL_024d;
					IL_024d:
					num8++;
					goto IL_0253;
					IL_0202:
					_003C_003Ec__DisplayClass42_ = new _003C_003Ec__DisplayClass42_0();
					goto IL_0209;
					continue;
					end_IL_013c:
					break;
				}
				continue;
				end_IL_0149:
				break;
			}
		}
	}

	public bool CanFitItemAt(int col, int row, int width, int height, bool allowOverlap, out bool overlapped)
	{
		overlapped = false;
		if (col >= 0)
		{
			if (row < 0)
			{
				return false;
			}
			if (col + width > Columns)
			{
				return false;
			}
			if (row + height > Rows)
			{
				return false;
			}
			List<long> list = new List<long>();
			for (int i = col; i < col + width; i++)
			{
				for (int j = row; j < row + height; j++)
				{
					Item itemAtLocation = GetItemAtLocation(i, j);
					if (itemAtLocation != null)
					{
						if (!allowOverlap)
						{
							overlapped = true;
							return false;
						}
						if (!list.Contains(itemAtLocation.Address))
						{
							list.Add(itemAtLocation.Address);
						}
					}
				}
			}
			overlapped = list.Count > 1;
			return list.Count <= 1;
		}
		return false;
	}

	public Item GetItemAtLocation(Vector2i pos)
	{
		return GetItemAtLocation(pos.X, pos.Y);
	}

	public Item GetItemAtLocation(int col, int row)
	{
		if (PageType == InventoryType.SentinelLocker)
		{
			uint num = default(uint);
			while (true)
			{
				IL_0083:
				LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType = _sentinelType;
				while (true)
				{
					switch (sentinelType)
					{
					case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
						goto IL_008c;
					case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
						goto IL_0094;
					case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
					case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
						goto end_IL_006b;
					}
					int num2 = (int)(num * 1228686916) ^ -439499860;
					while (true)
					{
						switch ((num = (uint)num2 ^ 0x4D6F5B2Du) % 10u)
						{
						case 5u:
							num2 = (int)(num * 1300056051) ^ -1329752640;
							continue;
						case 7u:
							break;
						case 1u:
						case 3u:
							goto IL_0083;
						case 9u:
							goto IL_008c;
						case 6u:
							goto IL_0094;
						case 2u:
						case 8u:
							goto end_IL_006b;
						case 4u:
							goto IL_00a5;
						default:
							goto IL_017e;
						}
						break;
					}
					continue;
					IL_0094:
					col += 24;
					break;
					IL_008c:
					col += 12;
					break;
					continue;
					end_IL_006b:
					break;
				}
				break;
			}
		}
		if (!_isEldrichTab)
		{
			goto IL_00a5;
		}
		goto IL_017e;
		IL_00a5:
		if (!_isMavenTab)
		{
			foreach (Item item in Items)
			{
				Vector2i locationTopLeft = item.LocationTopLeft;
				Vector2i size = item.Size;
				if ((size.X > 1 || size.Y > 1) && size.X >= 1 && size.Y >= 1)
				{
					if (new Rect(locationTopLeft.X, locationTopLeft.Y, size.X - 1, size.Y - 1).Contains(col, row))
					{
						return item;
					}
				}
				else if (locationTopLeft.X == col && locationTopLeft.Y == row)
				{
					return item;
				}
			}
			return null;
		}
		goto IL_017e;
		IL_017e:
		foreach (Item item2 in Items)
		{
			Vector2i locationTopLeft2 = item2.LocationTopLeft;
			if (locationTopLeft2.X == col + 12 * row && locationTopLeft2.Y == ((!_isEldrichTab) ? 1 : 2))
			{
				return item2;
			}
		}
		return null;
	}

	public bool CanFitItem(Item item)
	{
		int col;
		int row;
		return CanFitItem(item, out col, out row);
	}

	internal void SetId(int int_1)
	{
		Id = int_1;
	}

	public bool CanFitItem(Item item, out int col, out int row)
	{
		if (item == null)
		{
			throw new ArgumentNullException(global::_003CModule_003E.smethod_9<string>(355377958u));
		}
		return CanFitItem(item.Size, out col, out row);
	}

	public bool CanFitItem(Vector2i itemSize, out int col, out int row)
	{
		return CanFitItem(itemSize.X, itemSize.Y, out col, out row);
	}

	public bool CanFitItem(Vector2i itemSize)
	{
		int fcol;
		int frow;
		return CanFitItem(itemSize.X, itemSize.Y, out fcol, out frow);
	}

	public bool CanFitItem(int itemWidth, int itemHeight, out int fcol, out int frow)
	{
		fcol = -1;
		frow = -1;
		if (PageType != InventoryType.Cursor)
		{
			uint num2 = default(uint);
			int num4 = default(int);
			int num5 = default(int);
			Vector2i vector2i = default(Vector2i);
			Vector2i vector2i2 = default(Vector2i);
			bool flag = default(bool);
			int num6 = default(int);
			int num7 = default(int);
			int num8 = default(int);
			int num9 = default(int);
			Vector2i vector2i3 = default(Vector2i);
			Vector2i vector2i4 = default(Vector2i);
			bool flag2 = default(bool);
			int num10 = default(int);
			int num11 = default(int);
			while (true)
			{
				bool[,] itemPlacementGraph = GetItemPlacementGraph();
				while (true)
				{
					int columns = Columns;
					int rows = Rows;
					while (true)
					{
						if (PageType == InventoryType.SentinelLocker)
						{
							while (true)
							{
								int num = 0;
								while (true)
								{
									LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType = _sentinelType;
									while (true)
									{
										IL_025a:
										switch (sentinelType)
										{
										case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
											break;
										case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
											goto IL_0238;
										case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
											goto IL_023b;
										case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
											goto IL_0241;
										default:
											goto IL_0247;
										}
										goto IL_0232;
										IL_0247:
										int num3 = ((int)num2 * -1514828629) ^ -1729045485;
										goto IL_0047;
										IL_0232:
										num = 12;
										goto IL_023b;
										IL_023b:
										num4 = num;
										goto IL_0223;
										IL_0223:
										if (num4 < num + 12 - (itemWidth - 1))
										{
											goto IL_0218;
										}
										goto IL_02a7;
										IL_0218:
										num5 = 0;
										goto IL_020d;
										IL_020d:
										if (num5 < rows - (itemHeight - 1))
										{
											goto IL_01df;
										}
										goto IL_021d;
										IL_01df:
										vector2i = new Vector2i(num4, num5);
										vector2i2 = new Vector2i(num4 + itemWidth, num5 + itemHeight);
										flag = true;
										num6 = vector2i.X;
										goto IL_01d2;
										IL_01d2:
										if (num6 < vector2i2.X)
										{
											goto IL_0199;
										}
										goto IL_01c6;
										IL_01c6:
										if (flag)
										{
											goto IL_0175;
										}
										goto IL_0207;
										IL_0175:
										switch (_sentinelType)
										{
										case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
											goto IL_036c;
										case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
											goto IL_0372;
										case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
											goto IL_037b;
										case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
											goto IL_0382;
										}
										num3 = ((int)num2 * -1254558330) ^ -19301250;
										goto IL_0047;
										IL_0207:
										num5++;
										goto IL_020d;
										IL_0047:
										while (true)
										{
											switch ((num2 = (uint)num3 ^ 0x84A81A2Fu) % 70u)
											{
											case 60u:
												num3 = ((int)num2 * -1090350781) ^ 0x2D43E9AE;
												continue;
											case 49u:
												num3 = (int)((num2 * 1513045624) ^ 0x40BA5B3);
												continue;
											case 34u:
												break;
											case 67u:
												goto IL_0199;
											case 1u:
												goto IL_01a4;
											case 44u:
												goto IL_01b0;
											case 52u:
											case 62u:
												goto IL_01b6;
											case 53u:
												goto IL_01c3;
											case 39u:
											case 59u:
												goto IL_01c6;
											case 48u:
												goto IL_01cc;
											case 17u:
											case 26u:
												goto IL_01d2;
											case 54u:
												goto IL_01df;
											case 51u:
												goto IL_0207;
											case 14u:
											case 28u:
												goto IL_020d;
											case 7u:
												goto IL_0218;
											case 5u:
												goto IL_021d;
											case 31u:
											case 66u:
												goto IL_0223;
											case 4u:
												goto IL_0232;
											case 33u:
												goto IL_0238;
											case 25u:
											case 47u:
											case 63u:
												goto IL_023b;
											case 65u:
												goto IL_0241;
											case 24u:
												goto IL_025a;
											case 15u:
												goto end_IL_025a;
											case 9u:
												goto end_IL_0273;
											case 37u:
												goto end_IL_027d;
											case 61u:
												goto end_IL_0282;
											case 43u:
												goto end_IL_028e;
											case 21u:
												goto IL_02a7;
											case 35u:
												goto IL_02a9;
											case 64u:
												goto IL_02ae;
											case 45u:
												goto IL_02b9;
											case 8u:
												goto IL_02c5;
											case 46u:
												goto IL_02cd;
											case 38u:
												goto IL_02d5;
											case 30u:
												goto IL_02da;
											case 29u:
												goto IL_02e2;
											case 13u:
												goto IL_02e8;
											case 22u:
												goto IL_02f1;
											case 23u:
											case 41u:
												goto IL_02f4;
											case 40u:
												goto IL_02fd;
											case 57u:
												goto IL_031a;
											case 0u:
												goto IL_0323;
											case 3u:
												goto IL_032e;
											case 19u:
											case 27u:
											case 56u:
												goto IL_0334;
											case 2u:
												goto IL_0344;
											case 6u:
												goto IL_0348;
											case 16u:
												goto IL_034d;
											default:
												goto IL_034f;
											case 20u:
											case 69u:
												goto end_IL_029e;
											case 68u:
												goto IL_0360;
											case 36u:
												goto IL_0363;
											case 11u:
												goto IL_036a;
											case 12u:
												goto IL_036c;
											case 18u:
												goto IL_0372;
											case 42u:
												goto IL_037b;
											case 10u:
											case 32u:
											case 55u:
												goto IL_0382;
											case 58u:
												goto IL_0387;
											}
											break;
										}
										goto IL_0175;
										IL_037b:
										fcol = num4 - 24;
										goto IL_0382;
										IL_0372:
										fcol = num4 - 12;
										goto IL_0382;
										IL_036c:
										fcol = num4;
										goto IL_0382;
										IL_0382:
										frow = num5;
										goto IL_0387;
										IL_0387:
										return true;
										IL_02a7:
										return false;
										IL_0241:
										num = 24;
										goto IL_023b;
										IL_0238:
										num = 0;
										goto IL_023b;
										IL_021d:
										num4++;
										goto IL_0223;
										IL_0199:
										num7 = vector2i.Y;
										goto IL_01b6;
										IL_01b6:
										if (num7 < vector2i2.Y)
										{
											goto IL_01a4;
										}
										goto IL_01cc;
										IL_01a4:
										if (!itemPlacementGraph[num7, num6])
										{
											goto IL_01b0;
										}
										goto IL_01c3;
										IL_01b0:
										num7++;
										goto IL_01b6;
										IL_01c3:
										flag = false;
										goto IL_01c6;
										IL_01cc:
										num6++;
										goto IL_01d2;
										continue;
										end_IL_025a:
										break;
									}
									continue;
									end_IL_0273:
									break;
								}
								continue;
								end_IL_027d:
								break;
							}
							continue;
						}
						goto IL_02a9;
						IL_034f:
						return false;
						IL_02a9:
						num8 = 0;
						goto IL_02e8;
						IL_02e8:
						if (num8 < columns - (itemWidth - 1))
						{
							goto IL_02f1;
						}
						goto IL_034f;
						IL_02f1:
						num9 = 0;
						goto IL_02f4;
						IL_02f4:
						if (num9 >= rows - (itemHeight - 1))
						{
							goto IL_02e2;
						}
						goto IL_02fd;
						IL_02fd:
						vector2i3 = new Vector2i(num8, num9);
						vector2i4 = new Vector2i(num8 + itemWidth, num9 + itemHeight);
						flag2 = true;
						goto IL_031a;
						IL_031a:
						num10 = vector2i3.X;
						goto IL_0323;
						IL_0323:
						if (num10 < vector2i4.X)
						{
							goto IL_02ae;
						}
						goto IL_032e;
						IL_02ae:
						num11 = vector2i3.Y;
						goto IL_0334;
						IL_0334:
						if (num11 < vector2i4.Y)
						{
							goto IL_02b9;
						}
						goto IL_02cd;
						IL_02cd:
						num10++;
						goto IL_0323;
						IL_02b9:
						if (!itemPlacementGraph[num11, num10])
						{
							goto IL_02c5;
						}
						goto IL_02d5;
						IL_02c5:
						num11++;
						goto IL_0334;
						IL_02d5:
						flag2 = false;
						goto IL_032e;
						IL_032e:
						if (!flag2)
						{
							goto IL_02da;
						}
						goto IL_0344;
						IL_0344:
						fcol = num8;
						goto IL_0348;
						IL_0348:
						frow = num9;
						goto IL_034d;
						IL_034d:
						return true;
						IL_02da:
						num9++;
						goto IL_02f4;
						IL_02e2:
						num8++;
						goto IL_02e8;
						continue;
						end_IL_0282:
						break;
					}
					continue;
					end_IL_028e:
					break;
				}
				continue;
				end_IL_029e:
				break;
			}
		}
		bool flag3 = !Items.Any();
		goto IL_0360;
		IL_0360:
		if (flag3)
		{
			goto IL_0363;
		}
		goto IL_036a;
		IL_036a:
		return flag3;
		IL_0363:
		fcol = 0;
		frow = 0;
		goto IL_036a;
	}

	public bool CanSlideItemUpOrLeft(Item item)
	{
		if (item == null)
		{
			throw new ArgumentNullException(global::_003CModule_003E.smethod_7<string>(2139396710u));
		}
		if (item.HasInventoryLocation)
		{
			bool[,] itemPlacementGraph = GetItemPlacementGraph();
			bool flag = true;
			if (item.LocationTopLeft.Y > 0)
			{
				for (int i = 0; i < item.Size.X; i++)
				{
					if (itemPlacementGraph[item.LocationTopLeft.Y - 1, item.LocationTopLeft.X + i])
					{
						flag = false;
						break;
					}
				}
			}
			else
			{
				flag = false;
			}
			bool flag2 = true;
			if (item.LocationTopLeft.X <= 0)
			{
				flag2 = false;
			}
			else
			{
				for (int j = 0; j < item.Size.Y; j++)
				{
					if (itemPlacementGraph[item.LocationTopLeft.Y + j, item.LocationTopLeft.X - 1])
					{
						flag2 = false;
						break;
					}
				}
			}
			return flag2 || flag;
		}
		throw new Exception(string.Format(global::_003CModule_003E.smethod_6<string>(2971725634u), item.FullName));
	}

	public bool CanFitItemSizeAt(int itemWidth, int itemHeight, int col, int row)
	{
		Vector2i vector2i = new Vector2i(col, row);
		Vector2i vector2i2 = new Vector2i(col + itemWidth, row + itemHeight);
		if (vector2i2.X <= Columns && vector2i2.Y <= Rows)
		{
			bool[,] itemPlacementGraph = GetItemPlacementGraph();
			for (int i = vector2i.X; i < vector2i2.X; i++)
			{
				for (int j = vector2i.Y; j < vector2i2.Y; j++)
				{
					if (itemPlacementGraph[j, i])
					{
						return false;
					}
				}
			}
			return true;
		}
		return false;
	}

	public Item FindItemByFullName(string fullName)
	{
		return Items.FirstOrDefault((Item x) => x.FullName == fullName);
	}

	public Item FindItemByName(string name)
	{
		return Items.FirstOrDefault((Item x) => x.Name == name);
	}

	private int GetTotalItemQuantity(IEnumerable<Item> ienumerable_0)
	{
		int num = 0;
		foreach (Item item in ienumerable_0)
		{
			num += item.StackCount;
		}
		return num;
	}

	public int GetTotalItemQuantityByName(string name)
	{
		IEnumerable<Item> ienumerable_ = Items.Where((Item x) => x.Name == name);
		return GetTotalItemQuantity(ienumerable_);
	}

	public int GetTotalItemQuantityByFullName(string fullName)
	{
		IEnumerable<Item> ienumerable_ = Items.Where((Item x) => x.FullName == fullName);
		return GetTotalItemQuantity(ienumerable_);
	}

	public int GetTotalItemQuantityByMetadata(string metadata)
	{
		IEnumerable<Item> ienumerable_ = Items.Where((Item x) => x.Metadata == metadata);
		return GetTotalItemQuantity(ienumerable_);
	}

	public int GetTotalItemQuantityByMetadataFlags(MetadataFlags flag)
	{
		IEnumerable<Item> ienumerable_ = Items.Where((Item x) => x.HasMetadataFlags(flag));
		return GetTotalItemQuantity(ienumerable_);
	}

	public int GetTotalItemStacksByFullName(string fullName)
	{
		return Items.Count((Item x) => x.FullName == fullName);
	}

	public bool NeedsToMerge()
	{
		List<Item> list = (from x in Items
			where x.Rarity == Rarity.Currency && x.Rarity != Rarity.Quest && x.MaxStackCount > 1 && x.StackCount != x.MaxStackCount
			orderby x.FullName
			select x).ToList();
		int num = 0;
		while (true)
		{
			if (num < list.Count - 1)
			{
				Item item = list[num];
				Item item2 = list[num + 1];
				if (item.FullName == item2.FullName)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3629532703u), Id));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(2819564218u), IsRequested));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(1259205751u), PageType));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3637820911u), PageSlot));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(2827852426u), Rows));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(1133658541u), Cols));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(2781682787u)));
		foreach (Item item in Items)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1235761942u), item.StackCount, item.FullName));
		}
		return stringBuilder.ToString();
	}
}
