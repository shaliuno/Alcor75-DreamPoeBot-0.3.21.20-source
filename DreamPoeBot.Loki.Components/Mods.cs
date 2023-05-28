using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Mods : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct926
	{
		public int int_0;

		public int intptr_0;

		public int int_1;

		public int intptr_1;

		public int int_2;

		public int intptr_2;

		public uint uint_0;

		public int unusedInt0;

		public int unusedInt1;

		public int unusedInt2;

		public int unusedInt3;

		public int unusedInt4;

		public long intptr_3;

		public long intptr_4;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct176
	{
		public long intptr_0;

		public uint uint_0;

		public NativeVector nativeVector_0;

		public NativeHashMap nativeHashMap_0;

		public int int_0;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct177
	{
		public long intptr_0;

		public long intptr_1;

		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;

		public int int_4;

		public int int_5;

		public int int_6;

		public int int_7;

		public InventoryType inventoryType_0ItemType;

		public int unusedInt1;

		public long StructExtraData;

		public long intptr_2;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructExtraData
	{
		public long intptr_0;

		public NativeStringWCustom nativeStringW_0;

		public int int_1ModLevel;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructModsInfo
	{
		public NativeVector ModsValues;

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		public Struct243 struct243_0;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct179
	{
		public Struct253 struct253_0;

		public long intptr_0Struct177_1;

		public NativeVector nativeVector_0;

		public long intptr_0Struct177_0;

		public NativeVector nativeVector_1FullName;

		public NativeStringWCustom nativeStringW_0;

		public NativeStringWCustom nativeStringW_1;

		public NativeStringWCustom nativeStringW_2;

		public byte byte_0Identified;

		private byte byte_1;

		public byte byte_nrOfFracturedMods;

		private byte byte_3;

		public Rarity rarity_0Rarity;

		private int unusedInt10;

		private int unusedInt110;

		public NativeVector nativeVector_2ImplicitAffixes;

		public NativeVector nativeVector_3ExplicitAffixes;

		public NativeVector nativeVector_3EnchantmentsAffixes;

		public NativeVector nativeVector_3ScourgeAffixes;

		public NativeVector nativeVector_4CrucibleAffixes;

		private long intptr_7;

		private long intptr_8;

		private long intptr_9;

		private long intptr_10;

		private long intptr_11;

		private long intptr_12;

		private long intptr_13;

		private long intptr_14;

		private long intptr_15;

		public NativeVector nativeVector_4MergedStatsEnumerable;

		public NativeVector nativeVector_5Stats_BC;

		private NativeVector nativeVector_6;

		private NativeVector nativeVector_7;

		private NativeVector nativeVector_8;

		public long AlternateQualityTypeAddress;

		public long AlternateQualityTypeFile;

		public int AlternateQualityTypeActialValue;

		private byte byte_4;

		private byte byte_5;

		private byte byte_6;

		private byte byte_7;

		public long TooltipintPtr;

		private long intptr_24_2;

		private long intptr_24_3;

		public NativeVector nativeVector_24Tags;

		public int int_0ItemLevel;

		public int int_1BaseRequiredLevel;

		public long intPtr_Incubator;

		private long intPtr_110;

		private short short_0;

		private byte byte_22;

		private byte byte_23;

		public byte byte_26IsUsable;

		public byte byte_21IsMirrored;

		private byte byte_27;

		private byte byte_25;

		private byte byte_26;

		public byte byte_24IsRelic;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructTooltipStrings
	{
		private int int_0;

		private int int_1;

		public NativeVector nativeVector_7ImplicitStrings;

		private long intptr_110;

		private long intptr_120;

		private long intptr_130;

		private long intptr_140;

		private long intptr_150;

		public NativeVector nativeVector_8_EnchantmentsString;

		private long intptr_111;

		private long intptr_121;

		private long intptr_131;

		private long intptr_141;

		private long intptr_151;

		public NativeVector nativeVector_9ScourgeStrings;

		private long intptr_112;

		private long intptr_122;

		private long intptr_132;

		private long intptr_142;

		private long intptr_152;

		public NativeVector nativeVector_10ExplicitStrings;

		private long intptr_162;

		private long intptr_163;

		private long intptr_164;

		private long intptr_165;

		private long intptr_166;

		public NativeVector nativeVector_11CraftedStrings;

		private long intptr_113;

		private long intptr_123;

		private long intptr_133;

		private long intptr_143;

		private long intptr_153;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructAlternateQualityType
	{
		public long ModTypeAddress;

		public long ModTypeFile;

		public long Description;

		public long BaseItemTypeAddress;

		public long BaseItemFile;

		public long ModEffectStatsAddress;

		public long ModEffectStatsFile;
	}

	private List<string> list_0;

	private PerFrameCachedValue<Struct179> perFrameCachedValue_1;

	private PerFrameCachedValue<StructTooltipStrings> perFrameCachedValue_10;

	private PerFrameCachedValue<Struct177> perFrameCachedValue_2;

	private PerFrameCachedValue<StructExtraData> perFrameCachedValue_3;

	private PerFrameCachedValue<StructAlternateQualityType> perFrameCachedValue_StructAlternateQualityType;

	public bool HasIncubator => (ulong)Struct179_0.intPtr_Incubator > 0uL;

	public List<ItemMod> ItemMods => ImplicitMods.Concat(ExplicitMods).ToList();

	public List<ItemMod> ImplicitMods => GetMods(144, 152);

	public List<ItemMod> ExplicitMods => GetMods(168, 176);

	public List<string> Tags
	{
		get
		{
			if (list_0 == null)
			{
				list_0 = Containers.StdStruct242Vector<Struct242>(Struct179_0.nativeVector_24Tags).Select(method_3).ToList();
			}
			return list_0;
		}
	}

	public bool IsRelic => Struct179_0.byte_24IsRelic > 0;

	public int RequireLevel => Math.Max(BaseRequiredLevel, ModLevel);

	public int BaseRequiredLevel => Struct179_0.int_1BaseRequiredLevel;

	public int ItemLevel => Struct179_0.int_0ItemLevel;

	public bool Identified => Struct179_0.byte_0Identified > 0;

	public Rarity Rarity => Struct179_0.rarity_0Rarity;

	public bool IsUsable => Struct179_0.byte_26IsUsable == 0;

	public bool IsMirrored => Struct179_0.byte_21IsMirrored == 1;

	public bool IsFractured => Struct179_0.byte_nrOfFracturedMods > 0;

	public IEnumerable<ModAffix> Affixes => ImplicitAffixes.Union(ExplicitAffixes).Union(EnchantmentsAffixes).Union(ScourgeAffixes);

	public IEnumerable<ModAffix> ImplicitAffixes
	{
		get
		{
			foreach (StructModsInfo item in Containers.StdStruct178Vector<StructModsInfo>(Struct179_0.nativeVector_2ImplicitAffixes))
			{
				yield return new ModAffix(item);
			}
		}
	}

	public IEnumerable<ModAffix> ExplicitAffixes
	{
		get
		{
			uint num2 = default(uint);
			List<StructModsInfo>.Enumerator enumerator = default(List<StructModsInfo>.Enumerator);
			while (true)
			{
				Mods mods = this;
				while (true)
				{
					int num;
					switch (num)
					{
					default:
						switch ((num2 = (num2 * 1353291965) ^ 0x43502D0Au ^ 0xF2FF4EADu) % 22u)
						{
						case 16u:
							break;
						case 4u:
						case 17u:
							goto end_IL_0089;
						case 18u:
							goto IL_00af;
						case 7u:
							goto IL_00ed;
						case 3u:
						case 6u:
						case 10u:
						case 12u:
							goto IL_0107;
						case 20u:
							goto IL_0114;
						case 14u:
							goto IL_0133;
						case 15u:
							try
							{
								goto IL_0147;
								IL_0147:
								/*Error near IL_0181: Unexpected return in MoveNext()*/;
							}
							finally
							{
								/*Error: Could not find finallyMethod for state=1.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
							}
						case 1u:
							goto IL_0147;
						case 21u:
							goto IL_014b;
						case 11u:
							try
							{
								goto IL_015f;
								IL_015f:
								/*Error near IL_0181: Unexpected return in MoveNext()*/;
							}
							finally
							{
								((IDisposable)enumerator).Dispose();
							}
						case 9u:
							goto IL_015f;
						default:
							yield break;
						case 0u:
							yield break;
						case 2u:
						case 19u:
							yield break;
						case 5u:
							yield break;
						case 8u:
							yield break;
						case 13u:
							yield break;
						}
						continue;
					case 0:
						goto IL_00af;
					case 2:
						goto IL_00ed;
					case 1:
						goto IL_0107;
						IL_00ed:
						try
						{
							goto IL_0107;
							IL_0107:
							if (enumerator.MoveNext())
							{
								goto IL_0114;
							}
							goto end_IL_00ed;
							IL_0114:
							_ = enumerator.Current;
							int index;
							if (index <= mods.Struct179_0.byte_nrOfFracturedMods)
							{
								goto IL_0133;
							}
							goto IL_014b;
							IL_0133:
							StructModsInfo container;
							yield return new ModAffix(container, isFractured: true);
							/*Error: Unable to find new state assignment for yield return*/;
							IL_014b:
							yield return new ModAffix(container);
							/*Error: Unable to find new state assignment for yield return*/;
							end_IL_00ed:;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=-3.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
						IL_00af:
						Containers.StdStruct178Vector<StructModsInfo>(mods.Struct179_0.nativeVector_3ExplicitAffixes).GetEnumerator();
						goto IL_0107;
						end_IL_0089:
						break;
					}
					break;
				}
			}
		}
	}

	public IEnumerable<ModAffix> EnchantmentsAffixes
	{
		get
		{
			foreach (StructModsInfo item in Containers.StdStruct178Vector<StructModsInfo>(Struct179_0.nativeVector_3EnchantmentsAffixes))
			{
				yield return new ModAffix(item);
			}
		}
	}

	public IEnumerable<ModAffix> ScourgeAffixes
	{
		get
		{
			foreach (StructModsInfo item in Containers.StdStruct178Vector<StructModsInfo>(Struct179_0.nativeVector_3ScourgeAffixes))
			{
				yield return new ModAffix(item);
			}
		}
	}

	public Dictionary<StatTypeGGG, int> MergedStats => MergedStatsEnumerable.ToDictionary((KeyValuePair<StatTypeGGG, int> x) => x.Key, (KeyValuePair<StatTypeGGG, int> x) => x.Value);

	public IEnumerable<KeyValuePair<StatTypeGGG, int>> MergedStatsEnumerable
	{
		get
		{
			foreach (KeyValuePair<StatTypeGGG, int> item in Containers.StdStatType_IntVector<KeyValuePair<StatTypeGGG, int>>(Struct179_0.nativeVector_4MergedStatsEnumerable))
			{
				yield return new KeyValuePair<StatTypeGGG, int>(item.Key, item.Value);
			}
		}
	}

	public Dictionary<StatTypeGGG, int> ImplicitStats
	{
		get
		{
			Dictionary<StatTypeGGG, int> dictionary = new Dictionary<StatTypeGGG, int>();
			foreach (KeyValuePair<StatTypeGGG, int> item in ImplicitStatsEnumerable)
			{
				if (!dictionary.ContainsKey(item.Key))
				{
					dictionary.Add(item.Key, item.Value);
				}
				else
				{
					dictionary[item.Key] += item.Value;
				}
			}
			return dictionary;
		}
	}

	public IEnumerable<KeyValuePair<StatTypeGGG, int>> ImplicitStatsEnumerable
	{
		get
		{
			foreach (ModAffix implicitAffix in ImplicitAffixes)
			{
				for (int i = 0; i < 4; i++)
				{
					if (implicitAffix.Stats[i].Stat > StatTypeGGG.None)
					{
						yield return new KeyValuePair<StatTypeGGG, int>(implicitAffix.Stats[i].Stat, implicitAffix.Values[i]);
					}
				}
			}
		}
	}

	public Dictionary<StatTypeGGG, int> ExplicitStats
	{
		get
		{
			Dictionary<StatTypeGGG, int> dictionary = new Dictionary<StatTypeGGG, int>();
			foreach (KeyValuePair<StatTypeGGG, int> item in ExplicitStatsEnumerable)
			{
				if (!dictionary.ContainsKey(item.Key))
				{
					dictionary.Add(item.Key, item.Value);
				}
				else
				{
					dictionary[item.Key] += item.Value;
				}
			}
			return dictionary;
		}
	}

	public IEnumerable<KeyValuePair<StatTypeGGG, int>> ExplicitStatsEnumerable
	{
		get
		{
			foreach (ModAffix explicitAffix in ExplicitAffixes)
			{
				for (int i = 0; i < 4; i++)
				{
					if (explicitAffix.Stats[i].Stat > StatTypeGGG.None)
					{
						yield return new KeyValuePair<StatTypeGGG, int>(explicitAffix.Stats[i].Stat, explicitAffix.Values[i]);
					}
				}
			}
		}
	}

	public Dictionary<StatTypeGGG, int> EnchantmentsStats
	{
		get
		{
			Dictionary<StatTypeGGG, int> dictionary = new Dictionary<StatTypeGGG, int>();
			foreach (KeyValuePair<StatTypeGGG, int> item in EnchantmentsEnumerable)
			{
				if (dictionary.ContainsKey(item.Key))
				{
					dictionary[item.Key] += item.Value;
				}
				else
				{
					dictionary.Add(item.Key, item.Value);
				}
			}
			return dictionary;
		}
	}

	public IEnumerable<KeyValuePair<StatTypeGGG, int>> EnchantmentsEnumerable
	{
		get
		{
			foreach (ModAffix enchantmentsAffix in EnchantmentsAffixes)
			{
				for (int i = 0; i < 4; i++)
				{
					if (enchantmentsAffix.Stats[i].Stat > StatTypeGGG.None)
					{
						yield return new KeyValuePair<StatTypeGGG, int>(enchantmentsAffix.Stats[i].Stat, enchantmentsAffix.Values[i]);
					}
				}
			}
		}
	}

	public Dictionary<StatTypeGGG, int> ScourgeStats
	{
		get
		{
			Dictionary<StatTypeGGG, int> dictionary = new Dictionary<StatTypeGGG, int>();
			foreach (KeyValuePair<StatTypeGGG, int> item in ScourgeEnumerable)
			{
				if (dictionary.ContainsKey(item.Key))
				{
					dictionary[item.Key] += item.Value;
				}
				else
				{
					dictionary.Add(item.Key, item.Value);
				}
			}
			return dictionary;
		}
	}

	public IEnumerable<KeyValuePair<StatTypeGGG, int>> ScourgeEnumerable
	{
		get
		{
			foreach (ModAffix scourgeAffix in ScourgeAffixes)
			{
				for (int i = 0; i < 4; i++)
				{
					if (scourgeAffix.Stats[i].Stat > StatTypeGGG.None)
					{
						yield return new KeyValuePair<StatTypeGGG, int>(scourgeAffix.Stats[i].Stat, scourgeAffix.Values[i]);
					}
				}
			}
		}
	}

	public IEnumerable<KeyValuePair<StatTypeGGG, int>> Stats_BC
	{
		get
		{
			foreach (KeyValuePair<StatTypeGGG, int> item in Containers.StdStatType_IntVector<KeyValuePair<StatTypeGGG, int>>(Struct179_0.nativeVector_5Stats_BC))
			{
				yield return new KeyValuePair<StatTypeGGG, int>(item.Key, item.Value);
			}
		}
	}

	public int ModLevel => StructExtraData_0.int_1ModLevel;

	public InventoryType ItemType => Struct177_0.inventoryType_0ItemType;

	internal IEnumerable<string> IEnumerable_0FullName
	{
		get
		{
			foreach (KeyValuePair<long, long> item in Containers.StdIntPtr_IntPtrVector(Struct179_0.nativeVector_1FullName))
			{
				Struct926 @struct = GameController.Instance.Memory.FastIntPtrToStruct<Struct926>(item.Key);
				string text = GameController.Instance.Memory.ReadStringU(@struct.intptr_3);
				yield return text.Trim();
			}
		}
	}

	public bool IsTooltipBuilt => (ulong)Struct179_0.TooltipintPtr > 0uL;

	public string AlternateQualityType
	{
		get
		{
			if (Struct179_0.AlternateQualityTypeAddress == 0L)
			{
				return "";
			}
			return base.M.ReadStringU(StructAlternateQualityType_0.Description);
		}
	}

	public int AlternateQualityTypeValue => Struct179_0.AlternateQualityTypeActialValue;

	public List<string> EnchantmentsString => Containers.StdNativeStringWCustomVector(StructTooltipStrings_0.nativeVector_8_EnchantmentsString).Select(Containers.StdStringWCustom).ToList();

	public List<string> ImplicitStrings => Containers.StdNativeStringWCustomVector(StructTooltipStrings_0.nativeVector_7ImplicitStrings).Select(Containers.StdStringWCustom).ToList();

	public List<string> ExplicitStrings => Containers.StdNativeStringWCustomVector(StructTooltipStrings_0.nativeVector_10ExplicitStrings).Select(Containers.StdStringWCustom).ToList();

	public List<string> ScourgeStrings => Containers.StdNativeStringWCustomVector(StructTooltipStrings_0.nativeVector_9ScourgeStrings).Select(Containers.StdStringWCustom).ToList();

	public List<string> CraftedStrings => Containers.StdNativeStringWCustomVector(StructTooltipStrings_0.nativeVector_11CraftedStrings).Select(Containers.StdStringWCustom).ToList();

	public List<string> MergedStrings
	{
		get
		{
			List<string> list = new List<string>();
			list.AddRange(EnchantmentsString);
			list.AddRange(ImplicitStrings);
			list.AddRange(ExplicitStrings);
			list.AddRange(ScourgeStrings);
			list.AddRange(CraftedStrings);
			return list;
		}
	}

	internal StructExtraData StructExtraData_0
	{
		get
		{
			if (perFrameCachedValue_3 == null)
			{
				perFrameCachedValue_3 = new PerFrameCachedValue<StructExtraData>(method_3);
			}
			return perFrameCachedValue_3;
		}
	}

	internal StructAlternateQualityType StructAlternateQualityType_0
	{
		get
		{
			if (perFrameCachedValue_StructAlternateQualityType == null)
			{
				perFrameCachedValue_StructAlternateQualityType = new PerFrameCachedValue<StructAlternateQualityType>(GetStructAlternateQualityType);
			}
			return perFrameCachedValue_StructAlternateQualityType;
		}
	}

	internal Struct177 Struct177_0
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<Struct177>(method_2);
			}
			return perFrameCachedValue_2;
		}
	}

	internal Struct179 Struct179_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct179>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	internal StructTooltipStrings StructTooltipStrings_0
	{
		get
		{
			if (perFrameCachedValue_10 == null)
			{
				perFrameCachedValue_10 = new PerFrameCachedValue<StructTooltipStrings>(() => base.M.FastIntPtrToStruct<StructTooltipStrings>(Struct179_0.TooltipintPtr));
			}
			return perFrameCachedValue_10;
		}
	}

	private List<ItemMod> GetMods(int startOffset, int endOffset)
	{
		List<ItemMod> list = new List<ItemMod>();
		if (base.Address == 0L)
		{
			return list;
		}
		long num = base.M.ReadLong(base.Address + startOffset);
		long num2 = base.M.ReadLong(base.Address + endOffset);
		long num3 = (num2 - num) / 40L;
		if (num3 <= 12L)
		{
			for (long num4 = num; num4 < num2; num4 += 40L)
			{
				list.Add(GetObject<ItemMod>(num4));
			}
			return list;
		}
		return list;
	}

	private string method_3(Struct242 struct242_0)
	{
		return base.M.ReadStringU(base.M.ReadLong(struct242_0.intptr_1));
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(174044944u), global::_003CModule_003E.smethod_6<string>(4134319603u)));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(438102074u), string.Join(global::_003CModule_003E.smethod_5<string>(1109693591u), Tags)));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(2151731900u), IsRelic));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3853195583u), RequireLevel));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(1267169543u), BaseRequiredLevel));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(370168454u), ItemLevel));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(1652826709u), Identified));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(2380280355u), Rarity));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(694195134u), IsUsable));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(1938562246u), IsMirrored));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(1623900844u), ModLevel));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(2641981642u), ItemType));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(3940723096u), AlternateQualityType));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(1765707493u), AlternateQualityTypeValue));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(272190981u), IsTooltipBuilt));
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_8<string>(2263890237u));
		foreach (ModAffix implicitAffix in ImplicitAffixes)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(4166168484u), implicitAffix));
		}
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_7<string>(3813484371u));
		foreach (ModAffix explicitAffix in ExplicitAffixes)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(4166168484u), explicitAffix));
		}
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_7<string>(1137174465u));
		foreach (KeyValuePair<StatTypeGGG, int> mergedStat in MergedStats)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3093558887u), mergedStat.Key, mergedStat.Value));
		}
		return stringBuilder.ToString();
	}

	private StructExtraData method_3()
	{
		return base.M.FastIntPtrToStruct<StructExtraData>(Struct177_0.StructExtraData);
	}

	private StructAlternateQualityType GetStructAlternateQualityType()
	{
		return base.M.FastIntPtrToStruct<StructAlternateQualityType>(Struct179_0.AlternateQualityTypeAddress);
	}

	private Struct179 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct179>(base.Address);
	}

	private Struct177 method_2()
	{
		return base.M.FastIntPtrToStruct<Struct177>(Struct179_0.intptr_0Struct177_0);
	}
}
