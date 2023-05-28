using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;
using log4net;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class Skill : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct134
	{
		private IntPtr intptr_0;

		private IntPtr intptr_1;

		private IntPtr intptr_2;

		private IntPtr intptr_3;

		private int int_0;

		private int int_1;

		public Struct243 struct243_GrantedEffectPerLevel;

		private IntPtr intptr_4;

		private Struct243 struct243_GrantedEffectStatSetPerLevel;

		private IntPtr intptr_7;

		private IntPtr intptr_8;

		private IntPtr intptr_9;

		private IntPtr intptr_10;

		private IntPtr intptr_11;

		private IntPtr intptr_12;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct135_MainSkillStructure
	{
		private long unusedIntPtr0;

		private int int_08;

		private int int_0C;

		public ushort ushort_0Id;

		private ushort unusedushort_1;

		private ushort unusedushort_2;

		private ushort unusedushort_3;

		public Struct243 struct243_GrantedEffectsPerLevel;

		private long intptr_0;

		private long intptr_1;

		private int int_0;

		private int int_1;

		private long intptr_00;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private byte byte_4;

		private byte byte_5;

		private byte byte_6;

		private byte byte_7;

		private long intptr_000;

		private long intptr_01;

		private long intptr_02;

		private long intptr_03;

		private long intptr_04;

		private long intptr_05;

		public readonly byte byte_6CanBeUsedWithWeapon;

		public readonly byte byte_7CannotBeUsed;

		private byte byte_8;

		private byte byte_9;

		public int int_3TotalUse;

		public int int_4MaxUses;

		public int int_5CoolDown;

		private long intptr_GrantedEffectPerLevelDat;

		private long intptr_GrantedEffectPerLevelFile;

		private int int_8;

		private int int_9;

		private long intptr_GrantedEffectsStatSetPerLevelDat;

		private long intptr_GrantedEffectsStatSetPerLevelFile;

		private long intptr_4;

		private long intptr_5;

		private long intptr_6;

		private long intptr_7;

		private long intptr_8;

		private long intptr_9;

		private int int_10;

		public int int_8SoulsPerUse;

		public int int_9TotalVaalUses;

		private int int_11;

		private long intptr_12;

		public long intptr_Stats;

		private long intptr_14;

		private NativeVector NativeVector_3;

		public NativeVector nativeVector_0SupportsStruct134;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct136
	{
		public readonly float float_0;

		public readonly float float_1;

		public readonly float float_2;

		public readonly float float_3;
	}

	public enum SkillCostType
	{
		Life,
		Mana
	}

	private static int _struct217StatsDSize = -1;

	private static ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private int _struct136Size = -1;

	private int _struct134Size = -1;

	private readonly ActiveSkillsEnum activeSkillsEnum_0;

	private readonly DreamPoeBot.Loki.Components.Actor actorComponent_0;

	private readonly DatActiveSkillWrapper datActiveSkillWrapper_0;

	private readonly DatGrantedEffectsPerLevelWrapper datGrantedEffectsPerLevelWrapper_0;

	private List<string> list_0;

	private bool? nullable_0;

	private bool? nullable_1;

	private bool? nullable_2;

	private bool? nullable_3;

	private bool? nullable_4;

	private PerFrameCachedValue<Dictionary<StatTypeGGG, int>> perFrameCachedValue_0;

	private PerFrameCachedValue<Dictionary<StatTypeGGG, int>> perFrameCachedValue_1;

	private PerFrameCachedValue<Struct135_MainSkillStructure> perFrameCachedValue_2;

	private readonly string string_0;

	private readonly string string_1;

	private readonly string string_2;

	private readonly string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private PerFrameCachedValue<float> perFrameCachedValue_LifeCost;

	private PerFrameCachedValue<float> perFrameCachedValue_LifeReservationPermyriad;

	private PerFrameCachedValue<float> perFrameCachedValue_LifeReservation;

	private PerFrameCachedValue<float> perFrameCachedValue_ManaCost;

	private PerFrameCachedValue<float> perFrameCachedValue_ManaReservationPermyriad;

	private PerFrameCachedValue<float> perFrameCachedValue_ManaReservation;

	private static int Struct218StatsDSize
	{
		get
		{
			if (_struct217StatsDSize == -1)
			{
				_struct217StatsDSize = MarshalCache<DreamPoeBot.Loki.Components.Stats.Struct217StatsD>.Size;
			}
			return _struct217StatsDSize;
		}
	}

	public DatActiveSkillWrapper ActiveSkill => datActiveSkillWrapper_0;

	public ActiveSkillsEnum ActiveSkillsEnum => activeSkillsEnum_0;

	public Dictionary<StatTypeGGG, int> AllStats
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Dictionary<StatTypeGGG, int>>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	public bool AmICursingWithThis
	{
		get
		{
			if (SkillBelongsToMe)
			{
				return LokiPoe.ObjectManager.Me.IsCursingWith(ActiveSkillsEnum);
			}
			return false;
		}
	}

	public bool AmIUsingConsideredAuraWithThis
	{
		get
		{
			if (SkillBelongsToMe)
			{
				return LokiPoe.ObjectManager.Me.HasConsideredAuraFrom(ActiveSkillsEnum);
			}
			return false;
		}
	}

	public Keys BoundKey => GetKeyForSlot(Slot);

	public IEnumerable<Keys> BoundKeys
	{
		get
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			while (object.Equals(LokiPoe.ObjectManager.Me, null))
			{
				if (stopwatch.ElapsedMilliseconds <= 200L)
				{
					Thread.Sleep(0);
					continue;
				}
				return new List<Keys>();
			}
			return LokiPoe.ObjectManager.Me.GetKeysForSkill(this);
		}
	}

	public bool CastingSpell => GetStat(StatTypeGGG.CastingSpell) != 0;

	public TimeSpan CastTime
	{
		get
		{
			TimeSpan result = TimeSpan.FromMilliseconds((int)Math.Ceiling(1000f / ((float)Math.Max(Math.Max(GetStat(StatTypeGGG.HundredTimesAttacksPerSecond), GetStat(StatTypeGGG.HundredTimesCastsPerSecond)), GetStat(StatTypeGGG.HundredTimesNonSpellCastsPerSecond)) / 100f)));
			if (result.TotalMilliseconds <= 0.0)
			{
				return new TimeSpan(0, 0, 0, 0, 5);
			}
			return result;
		}
	}

	public TimeSpan Cooldown
	{
		get
		{
			if (datGrantedEffectsPerLevelWrapper_0 != null)
			{
				return TimeSpan.FromMilliseconds(datGrantedEffectsPerLevelWrapper_0.Cooldown);
			}
			return TimeSpan.FromMilliseconds(Struct135_0.int_5CoolDown);
		}
	}

	public int CooldownsActive
	{
		get
		{
			if (ActiveSkill != null)
			{
				DreamPoeBot.Loki.Components.Actor.Struct139 @struct = actorComponent_0.List_0CoolDownSkills.FirstOrDefault((DreamPoeBot.Loki.Components.Actor.Struct139 x) => x.Index + 1 == ActiveSkill.Index);
				if (@struct.Index + 1 == ActiveSkill.Index)
				{
					return (int)((@struct.nativeVector_0.Last - @struct.nativeVector_0.First) / MarshalCache<Struct136>.Size);
				}
			}
			return 0;
		}
	}

	public int Cost
	{
		get
		{
			List<float> source = new List<float> { LifeCost, LifeReservationPermyriad, LifeReservation, ManaCost, ManaReservationPermyriad, ManaReservation };
			return (int)source.Max();
		}
	}

	public SkillCostType CostType
	{
		get
		{
			if (LifeCost == 0f && LifeReservation == 0f && LifeReservationPermyriad == 0f)
			{
				return SkillCostType.Mana;
			}
			return SkillCostType.Life;
		}
	}

	public bool CurrentlyRequiresPercentPower
	{
		get
		{
			if (!RequiresPercentPower)
			{
				return IsAurifiedCurse;
			}
			return true;
		}
	}

	public int CurrentSouls
	{
		get
		{
			if (ActiveSkill == null)
			{
				return 0;
			}
			foreach (DreamPoeBot.Loki.Components.Actor.Struct138 list_1VaalSkill in actorComponent_0.List_1VaalSkills)
			{
				DatActiveSkillWrapper datActiveSkillWrapper = new DatActiveSkillWrapper(list_1VaalSkill.struct243_0.intptr_1);
				if (datActiveSkillWrapper != null && ActiveSkill.InternalId.Equals(datActiveSkillWrapper.InternalId))
				{
					return list_1VaalSkill.currentSoul;
				}
			}
			return 0;
		}
	}

	public List<NetworkObject> DeployedObjects
	{
		get
		{
			List<NetworkObject> list = new List<NetworkObject>();
			foreach (DreamPoeBot.Loki.Components.Actor.Struct140 item in actorComponent_0.List_2DeployedObjects.Where((DreamPoeBot.Loki.Components.Actor.Struct140 x) => x.ushort_1 == Struct135_0.ushort_0Id))
			{
				NetworkObject objectById = LokiPoe.ObjectManager.GetObjectById(item.int_0);
				if (objectById != null && objectById.IsValid)
				{
					list.Add(objectById);
				}
			}
			return list;
		}
	}

	public string Description => string_1;

	public string DisplayString
	{
		get
		{
			string result;
			if ((result = string_4) == null)
			{
				result = (string_4 = string.Format(global::_003CModule_003E.smethod_8<string>(3813916398u), Name, Id, InventorySlot, SocketIndex));
			}
			return result;
		}
	}

	public string DisplayStringNoId
	{
		get
		{
			string result;
			if ((result = string_5) == null)
			{
				result = (string_5 = string.Format(global::_003CModule_003E.smethod_6<string>(655952786u), Name, InventorySlot, SocketIndex));
			}
			return result;
		}
	}

	public float Dps => (float)GetStat((StatTypeGGG)(677 + (CastingSpell ? 4 : 0))) / 100f;

	public DatGrantedEffectsPerLevelWrapper GrantedEffectsPerLevel => datGrantedEffectsPerLevelWrapper_0;

	public int HundredTimesAttacksPerSecond => GetStat(CastingSpell ? StatTypeGGG.HundredTimesCastsPerSecond : StatTypeGGG.HundredTimesAttacksPerSecond);

	public ushort Id => Struct135_0.ushort_0Id;

	private int Int32_0 => (Id >> 8) & 0xFF;

	public string InternalId => string_3;

	public string InternalName => string_2;

	public InventorySlot InventorySlot => (InventorySlot)(Id & 0x7F);

	public InventoryType InventoryType => (InventoryType)(Id & 0x7F);

	public bool IsAurifiedCurse => (nullable_1 ?? (nullable_1 = GetStat(StatTypeGGG.CurseApplyAsAura) == 1)).Value;

	public bool IsCastable
	{
		get
		{
			if (Struct135_0.byte_6CanBeUsedWithWeapon == 1 && Struct135_0.byte_7CannotBeUsed == 0)
			{
				return GetStat(StatTypeGGG.SpellHasTriggerFromCraftedItemMod) == 0;
			}
			return false;
		}
	}

	public bool IsConsideredAura
	{
		get
		{
			ActiveSkillsEnum activeSkillsEnum = ActiveSkillsEnum;
			if (activeSkillsEnum == ActiveSkillsEnum.herald_of_light)
			{
				return true;
			}
			if (activeSkillsEnum == ActiveSkillsEnum.physical_damage_aura)
			{
				return true;
			}
			if (activeSkillsEnum != ActiveSkillsEnum.herald_of_agony)
			{
				if (activeSkillsEnum != ActiveSkillsEnum.herald_of_blood)
				{
					if (activeSkillsEnum != ActiveSkillsEnum.petrified_blood)
					{
						if (activeSkillsEnum != ActiveSkillsEnum.skitterbots)
						{
							if (activeSkillsEnum <= ActiveSkillsEnum.herald_of_thunder)
							{
								if (activeSkillsEnum != ActiveSkillsEnum.arctic_armour && (uint)(activeSkillsEnum - 332) > 2u)
								{
									return false;
								}
							}
							else if (activeSkillsEnum != ActiveSkillsEnum.new_arctic_armour && (uint)(activeSkillsEnum - 1011) > 3u)
							{
								return false;
							}
							return true;
						}
						return true;
					}
					return true;
				}
				return true;
			}
			return true;
		}
	}

	public bool IsManaReserving
	{
		get
		{
			if (!nullable_0.HasValue)
			{
				uint num = default(uint);
				while (true)
				{
					IL_00f3:
					nullable_0 = false;
					if (!IsAurifiedCurse)
					{
						while (!IsTotem)
						{
							while (true)
							{
								IL_00d8:
								ActiveSkillsEnum activeSkillsEnum = ActiveSkillsEnum;
								if (activeSkillsEnum <= ActiveSkillsEnum.lightning_resist_aura)
								{
									while (true)
									{
										switch (activeSkillsEnum)
										{
										case ActiveSkillsEnum.aura_accuracy_and_crits:
											goto IL_0149;
										case ActiveSkillsEnum.haste:
										case ActiveSkillsEnum.purity:
										case ActiveSkillsEnum.vitality:
										case ActiveSkillsEnum.discipline:
										case ActiveSkillsEnum.grace:
										case ActiveSkillsEnum.determination:
										case ActiveSkillsEnum.anger:
										case ActiveSkillsEnum.hatred:
										case ActiveSkillsEnum.wrath:
										case ActiveSkillsEnum.clarity:
											goto end_IL_007b;
										case ActiveSkillsEnum.vaal_haste:
										case ActiveSkillsEnum.vaal_vitality:
										case ActiveSkillsEnum.vaal_discipline:
										case ActiveSkillsEnum.vaal_grace:
										case ActiveSkillsEnum.vaal_determination:
										case ActiveSkillsEnum.monster_hatred:
										case ActiveSkillsEnum.burning_arrow:
										case ActiveSkillsEnum.vaal_burning_arrow:
											goto end_IL_00d8;
										}
										switch ((num = (num * 2317276814u) ^ 0xF2760084u ^ 0x9503F1E6u) % 17u)
										{
										case 16u:
											break;
										case 10u:
											goto IL_00d8;
										case 0u:
											goto IL_00e9;
										case 12u:
										case 13u:
											goto IL_00f3;
										case 1u:
											goto IL_0109;
										case 2u:
											goto IL_0113;
										case 3u:
											goto IL_0121;
										case 11u:
											goto IL_012b;
										case 15u:
											goto IL_0135;
										case 6u:
											goto IL_013d;
										case 14u:
											goto IL_0149;
										case 4u:
											goto IL_0153;
										case 9u:
											goto end_IL_007b;
										default:
											goto end_IL_00d8;
										}
										continue;
										IL_0153:
										if (activeSkillsEnum - 249 > ActiveSkillsEnum.ground_slam)
										{
											goto end_IL_00d8;
										}
										break;
										IL_0149:
										if (activeSkillsEnum == ActiveSkillsEnum.arctic_armour)
										{
											break;
										}
										goto IL_0153;
										continue;
										end_IL_007b:
										break;
									}
									goto IL_015d;
								}
								goto IL_0109;
								IL_015d:
								nullable_0 = true;
								break;
								IL_0109:
								if (activeSkillsEnum <= ActiveSkillsEnum.new_arctic_armour)
								{
									goto IL_0121;
								}
								goto IL_0135;
								IL_0135:
								if (activeSkillsEnum != ActiveSkillsEnum.envy)
								{
									goto IL_013d;
								}
								goto IL_015d;
								IL_013d:
								if (activeSkillsEnum - 1011 > ActiveSkillsEnum.vaal_ground_slam)
								{
									break;
								}
								goto IL_015d;
								IL_0121:
								if (activeSkillsEnum - 332 > ActiveSkillsEnum.ground_slam)
								{
									goto IL_012b;
								}
								goto IL_015d;
								IL_012b:
								if (activeSkillsEnum != ActiveSkillsEnum.new_arctic_armour)
								{
									break;
								}
								goto IL_015d;
								continue;
								end_IL_00d8:
								break;
							}
							break;
							IL_00e9:;
						}
						break;
					}
					goto IL_0113;
					IL_0113:
					nullable_0 = true;
					break;
				}
			}
			return nullable_0.Value;
		}
	}

	public bool IsMine => (nullable_4 ?? (nullable_4 = GetStat(StatTypeGGG.IsRemoteMine) == 1 || GetStat(StatTypeGGG.SkillIsMined) == 1)).Value;

	private int Struct136Size
	{
		get
		{
			if (_struct136Size == -1)
			{
				_struct136Size = MarshalCache<Struct136>.Size;
			}
			return _struct136Size;
		}
	}

	public bool IsOnCooldown
	{
		get
		{
			if (ActiveSkill == null)
			{
				return false;
			}
			DreamPoeBot.Loki.Components.Actor.Struct139 @struct = actorComponent_0.List_0CoolDownSkills.FirstOrDefault((DreamPoeBot.Loki.Components.Actor.Struct139 x) => x.Index + 1 == ActiveSkill.Index);
			if (@struct.Index + 1 == ActiveSkill.Index)
			{
				int count = (int)((@struct.nativeVector_0.Last - @struct.nativeVector_0.First) / MarshalCache<Struct136>.Size);
				List<Struct136> list = base.M.IntptrToStructArray<Struct136>(@struct.nativeVector_0.First, count, Struct136Size).ToList();
				if (list.Any())
				{
					return list.Count >= @struct.int_5CoolDownCount;
				}
			}
			return false;
		}
	}

	public bool IsOnSkillBar => LokiPoe.InstanceInfo.SkillBarIds.Contains(Id);

	public bool IsTotem => (nullable_3 ?? (nullable_3 = GetStat(StatTypeGGG.IsTotem) == 1 || GetStat(StatTypeGGG.SkillIsTotemified) == 1)).Value;

	public bool IsTrap => (nullable_2 ?? (nullable_2 = GetStat(StatTypeGGG.IsTrap) == 1 || GetStat(StatTypeGGG.SkillIsTrapped) == 1)).Value;

	public bool IsUserSkill => (Int32_0 & 0x80) != 0;

	public bool IsVaalSkill
	{
		get
		{
			if (SoulsPerUse >= 1)
			{
				return TotalVaalUses >= 1;
			}
			return false;
		}
	}

	public string LinkedDisplayString
	{
		get
		{
			if (string_6 == null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat(DisplayString);
				List<Item> list = LinkedGems.ToList();
				for (int i = 0; i < list.Count; i++)
				{
					stringBuilder.AppendFormat(global::_003CModule_003E.smethod_9<string>(3620167201u));
					stringBuilder.AppendFormat(list[i].Name);
				}
				string_6 = stringBuilder.ToString();
			}
			return string_6;
		}
	}

	public List<Item> LinkedGems
	{
		get
		{
			List<Item> list = new List<Item>();
			if (!IsUserSkill)
			{
				return list;
			}
			DreamPoeBot.Loki.Game.Inventory playerInventoryBySlot = LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot);
			if (playerInventoryBySlot == null)
			{
				return list;
			}
			Item item = playerInventoryBySlot.Items.FirstOrDefault();
			if (item == null)
			{
				return list;
			}
			if (!(item.Components.SocketsComponent == null))
			{
				int socketIndex = SocketIndex;
				if (socketIndex >= 0 && socketIndex < 6)
				{
					Item[] socketedGems = item.SocketedGems;
					Item item2 = socketedGems[socketIndex];
					if (!(item2 == null))
					{
						List<DatGrantedEffectsPerLevelWrapper> supports = Supports;
						List<Item[]> socketedSkillGemsByLinks = item.SocketedSkillGemsByLinks;
						{
							foreach (Item[] item5 in socketedSkillGemsByLinks)
							{
								Item[] array = item5;
								foreach (Item item3 in array)
								{
									if (!(item3 != null) || item3.Address != item2.Address)
									{
										continue;
									}
									Item[] array2 = item5;
									foreach (Item item4 in array2)
									{
										if (item4 != null && item3.Address != item4.Address)
										{
											long grantedEffectsData = item4.Components.SkillGemComponent.Struct211_0.GrantedEffectsData;
											DatGrantedEffectWrapper dgew = new DatGrantedEffectWrapper(grantedEffectsData);
											if (supports.Any((DatGrantedEffectsPerLevelWrapper x) => x.GrantedEffect.Name == dgew.Name))
											{
												list.Add(item4);
											}
										}
									}
								}
							}
							return list;
						}
					}
					return list;
				}
				return list;
			}
			return list;
		}
	}

	public int MaxUses
	{
		get
		{
			int statFromAll = GetStatFromAll(StatTypeGGG.VirtualTotalCooldownCount);
			if (statFromAll > 0)
			{
				return statFromAll;
			}
			if (GetStatFromAll(StatTypeGGG.VirtualAddedCooldownCount) != 0)
			{
				return Struct135_0.int_4MaxUses + 1;
			}
			return Struct135_0.int_4MaxUses;
		}
	}

	public string Name => string_0;

	public int SkillActiveToken => actorComponent_0.ListOfDeployedEffect.Count((long x) => base.M.ReadUShort(base.M.ReadLong(x + 176L)) == Id);

	public int NumberDeployed => actorComponent_0.List_2DeployedObjects.Count((DreamPoeBot.Loki.Components.Actor.Struct140 x) => x.ushort_1 == Id);

	public bool RequiresPercentPower
	{
		get
		{
			if (ManaReservationPermyriad == 0f)
			{
				return LifeReservationPermyriad != 0f;
			}
			return true;
		}
	}

	public bool RequiresReservedPower
	{
		get
		{
			if (ManaReservation == 0f)
			{
				return LifeReservation != 0f;
			}
			return true;
		}
	}

	public int Seals
	{
		get
		{
			Aura aura = LokiPoe.ObjectManager.Me.Auras.FirstOrDefault((Aura x) => x.InternalName == global::_003CModule_003E.smethod_6<string>(879712029u) && x.SkillOwnerId == Id);
			if (aura == null)
			{
				return 0;
			}
			return aura.Charges;
		}
	}

	public bool SkillBelongsToMe => LokiPoe.ObjectManager.Me.Components.ActorComponent.Address == actorComponent_0.Address;

	public Item SkillGem
	{
		get
		{
			if (!IsUserSkill)
			{
				return null;
			}
			DreamPoeBot.Loki.Game.Inventory playerInventoryBySlot = LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot);
			if (playerInventoryBySlot == null)
			{
				return null;
			}
			Item item = playerInventoryBySlot.Items.FirstOrDefault();
			if (item == null)
			{
				return null;
			}
			if (item.Components.SocketsComponent == null)
			{
				return null;
			}
			if (SocketIndex >= 0 && SocketIndex < 6)
			{
				return item.SocketedGems[SocketIndex];
			}
			return null;
		}
	}

	public List<string> SkillTags
	{
		get
		{
			list_0 = new List<string>();
			if (SkillGem != null)
			{
				list_0.AddRange(SkillGem.GemTypes.Select((string x) => x.ToLowerInvariant()));
			}
			return list_0;
		}
	}

	public List<string> SkillType
	{
		get
		{
			list_0 = new List<string>();
			if (ActiveSkill != null)
			{
				list_0.AddRange(ActiveSkill.SkillTypes.Select(delegate(int x)
				{
					ActiveSkillTypeEnum activeSkillTypeEnum = (ActiveSkillTypeEnum)x;
					return activeSkillTypeEnum.ToString().ToLowerInvariant();
				}));
			}
			return list_0;
		}
	}

	public int Slot
	{
		get
		{
			List<ushort> skillBarIds = LokiPoe.InstanceInfo.SkillBarIds;
			int num = 0;
			while (true)
			{
				if (num < 13)
				{
					if (skillBarIds[num] == Id)
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return num + 1;
		}
	}

	public IEnumerable<int> Slots
	{
		get
		{
			List<int> list = new List<int>();
			List<ushort> skillBarIds = LokiPoe.InstanceInfo.SkillBarIds;
			for (int i = 0; i < 13; i++)
			{
				if (skillBarIds[i] == Id)
				{
					list.Add(i + 1);
				}
			}
			return list;
		}
	}

	public int SocketIndex => (Int32_0 >> 2) & 0xF;

	public int SoulsPerUse => Struct135_0.int_8SoulsPerUse;

	public Dictionary<StatTypeGGG, int> Stats
	{
		get
		{
			if (perFrameCachedValue_0 == null)
			{
				perFrameCachedValue_0 = new PerFrameCachedValue<Dictionary<StatTypeGGG, int>>(method_0);
			}
			return perFrameCachedValue_0;
		}
	}

	private int Struct134Size
	{
		get
		{
			if (_struct134Size == -1)
			{
				_struct134Size = MarshalCache<Struct134>.Size;
			}
			return _struct134Size;
		}
	}

	public List<DatGrantedEffectsPerLevelWrapper> Supports
	{
		get
		{
			List<DatGrantedEffectsPerLevelWrapper> list = new List<DatGrantedEffectsPerLevelWrapper>();
			int count = (int)(Struct135_0.nativeVector_0SupportsStruct134.Last - Struct135_0.nativeVector_0SupportsStruct134.First) / MarshalCache<Struct134>.Size;
			Struct134[] array = base.M.IntptrToStructArray<Struct134>(Struct135_0.nativeVector_0SupportsStruct134.First, count, Struct134Size);
			for (int i = 0; i < array.Length; i++)
			{
				Struct134 @struct = array[i];
				list.Add(new DatGrantedEffectsPerLevelWrapper(@struct.struct243_GrantedEffectPerLevel.intptr_1));
			}
			return list;
		}
	}

	public float TimeSinceLastAction => actorComponent_0.TimeSinceLastAction;

	public float TimeSinceLastMove => actorComponent_0.TimeSinceLastMove;

	public int TotalUses => Struct135_0.int_3TotalUse;

	public int TotalVaalUses => Struct135_0.int_9TotalVaalUses;

	public int UsesAvailable
	{
		get
		{
			if (MaxUses == 0)
			{
				if (!IsTotem)
				{
					return 1;
				}
				return GetStat(StatTypeGGG.SkillDisplayNumberOfTotemsAllowed);
			}
			if (!(Cooldown != TimeSpan.Zero))
			{
				if (!IsMine)
				{
					return MaxUses - NumberDeployed;
				}
				return GetStat(StatTypeGGG.SkillDisplayNumberOfRemoteMinesAllowed) - NumberDeployed;
			}
			return MaxUses - CooldownsActive;
		}
	}

	private float LifeCost
	{
		get
		{
			if (perFrameCachedValue_LifeCost == null)
			{
				perFrameCachedValue_LifeCost = new PerFrameCachedValue<float>(() => GetStatFromAll(StatTypeGGG.LifeCost));
			}
			return perFrameCachedValue_LifeCost.Value;
		}
	}

	private float LifeReservationPermyriad
	{
		get
		{
			if (perFrameCachedValue_LifeReservationPermyriad == null)
			{
				perFrameCachedValue_LifeReservationPermyriad = new PerFrameCachedValue<float>(() => (float)GetStatFromAll(StatTypeGGG.LifeReservationPermyriad) / 100f);
			}
			return perFrameCachedValue_LifeReservationPermyriad.Value;
		}
	}

	private float LifeReservation
	{
		get
		{
			if (perFrameCachedValue_LifeReservation == null)
			{
				perFrameCachedValue_LifeReservation = new PerFrameCachedValue<float>(() => GetStatFromAll(StatTypeGGG.LifeReservation));
			}
			return perFrameCachedValue_LifeReservation.Value;
		}
	}

	private float ManaCost
	{
		get
		{
			if (perFrameCachedValue_ManaCost == null)
			{
				perFrameCachedValue_ManaCost = new PerFrameCachedValue<float>(() => GetStatFromAll(StatTypeGGG.ManaCost));
			}
			return perFrameCachedValue_ManaCost.Value;
		}
	}

	private float ManaReservationPermyriad
	{
		get
		{
			if (perFrameCachedValue_ManaReservationPermyriad == null)
			{
				perFrameCachedValue_ManaReservationPermyriad = new PerFrameCachedValue<float>(() => (float)GetStatFromAll(StatTypeGGG.ManaReservationPermyriad) / 100f);
			}
			return perFrameCachedValue_ManaReservationPermyriad.Value;
		}
	}

	private float ManaReservation
	{
		get
		{
			if (perFrameCachedValue_ManaReservation == null)
			{
				perFrameCachedValue_ManaReservation = new PerFrameCachedValue<float>(() => GetStatFromAll(StatTypeGGG.ManaReservation));
			}
			return perFrameCachedValue_ManaReservation.Value;
		}
	}

	private Struct135_MainSkillStructure Struct135_0
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<Struct135_MainSkillStructure>(method_2);
			}
			return perFrameCachedValue_2;
		}
	}

	public Skill(long address, DreamPoeBot.Loki.Components.Actor actor)
		: base(address)
	{
		actorComponent_0 = actor;
		if (Struct135_0.struct243_GrantedEffectsPerLevel.intptr_1 != 0L)
		{
			datGrantedEffectsPerLevelWrapper_0 = new DatGrantedEffectsPerLevelWrapper(Struct135_0.struct243_GrantedEffectsPerLevel.intptr_1);
			datActiveSkillWrapper_0 = GrantedEffectsPerLevel.ActiveSkill;
			string_0 = ActiveSkill.DisplayName;
			string_2 = ActiveSkill.InternalName;
			string_3 = ActiveSkill.InternalId;
			string_1 = ActiveSkill.Description;
			if (Enum.TryParse<ActiveSkillsEnum>(InternalId, out var result))
			{
				activeSkillsEnum_0 = result;
			}
			else
			{
				activeSkillsEnum_0--;
			}
			if (Name == "")
			{
				string_0 = InternalId;
				if (Name == "")
				{
					string_0 = Struct135_0.ushort_0Id.ToString(CultureInfo.InvariantCulture);
				}
			}
			return;
		}
		activeSkillsEnum_0--;
		switch (Id)
		{
		case 614:
			string_0 = global::_003CModule_003E.smethod_5<string>(2783920446u);
			string_2 = global::_003CModule_003E.smethod_8<string>(3845132325u);
			break;
		default:
			string_2 = Struct135_0.ushort_0Id.ToString(CultureInfo.InvariantCulture);
			string_0 = InternalName;
			break;
		case 14297:
			string_0 = global::_003CModule_003E.smethod_7<string>(3151955554u);
			string_2 = global::_003CModule_003E.smethod_5<string>(3593888931u);
			break;
		case 10505:
			string_0 = global::_003CModule_003E.smethod_7<string>(321696303u);
			string_2 = global::_003CModule_003E.smethod_8<string>(3447366731u);
			break;
		}
		string_3 = InternalName;
		string_1 = "";
	}

	public bool CanUse(bool logError = false, bool ignoreOnSkillBar = false, bool checkCharges = true)
	{
		if (!IsCastable)
		{
			if (logError)
			{
				ilog_0.Debug((object)(global::_003CModule_003E.smethod_6<string>(144234649u) + Name + global::_003CModule_003E.smethod_5<string>(2023681209u)));
			}
			return false;
		}
		string error;
		bool result = CanUseEx(out error, ignoreOnSkillBar, checkCharges);
		if (logError)
		{
			ilog_0.Debug((object)(global::_003CModule_003E.smethod_5<string>(142042952u) + error));
		}
		return result;
	}

	public bool CanUseEx(out string error, bool ignoreOnSkillBar = false, bool checkCharges = true)
	{
		error = "";
		if (!LokiPoe.ObjectManager.Me.IsInTown)
		{
			if (!ignoreOnSkillBar && !IsOnSkillBar)
			{
				error = string.Format(global::_003CModule_003E.smethod_8<string>(2505837972u), Name);
				return false;
			}
			if (Name == global::_003CModule_003E.smethod_8<string>(2611608424u) && UsesAvailable == 0)
			{
				error = string.Format(global::_003CModule_003E.smethod_9<string>(3216269236u), Name);
				return false;
			}
			if (Struct135_0.byte_6CanBeUsedWithWeapon != 1)
			{
				error = string.Format(global::_003CModule_003E.smethod_5<string>(3357052268u), Name);
				return false;
			}
			if (Struct135_0.byte_7CannotBeUsed == 0)
			{
				if (IsVaalSkill && CurrentSouls < SoulsPerUse)
				{
					error = string.Format(global::_003CModule_003E.smethod_9<string>(3391009125u), Name);
					return false;
				}
				LocalPlayer me = LokiPoe.ObjectManager.Me;
				if (IsOnCooldown && UsesAvailable == 0)
				{
					if (Name == global::_003CModule_003E.smethod_5<string>(1907646297u) && checkCharges && !me.HasFrenzyCharge)
					{
						error = string.Format(global::_003CModule_003E.smethod_6<string>(3891245691u), Name);
						return false;
					}
					if (!(Name == global::_003CModule_003E.smethod_7<string>(1186934406u) && checkCharges))
					{
						error = string.Format(global::_003CModule_003E.smethod_8<string>(1513676785u), Name);
						return false;
					}
					if (me.GetStat(StatTypeGGG.ColdSnapUsesAndGainsPowerChargesInsteadOfFrenzy) == 0)
					{
						if (!me.HasFrenzyCharge)
						{
							error = string.Format(global::_003CModule_003E.smethod_8<string>(108839099u), Name);
							return false;
						}
					}
					else if (!me.HasPowerCharge)
					{
						error = string.Format(global::_003CModule_003E.smethod_6<string>(1756316764u), Name);
						return false;
					}
				}
				int statFromAll = GetStatFromAll(StatTypeGGG.RageCost);
				if (statFromAll > 0)
				{
					int stat = me.GetStat(StatTypeGGG.CurrentRage);
					if (stat < statFromAll)
					{
						error = string.Format(global::_003CModule_003E.smethod_6<string>(861279792u), Name, stat, statFromAll);
						return false;
					}
				}
				if (GetStatFromAll(StatTypeGGG.MeleeAttacksUsableWithoutManaCost) != 0 && SkillTags.Contains(global::_003CModule_003E.smethod_8<string>(1830988141u)) && SkillTags.Contains(global::_003CModule_003E.smethod_8<string>(2480521758u)))
				{
					return true;
				}
				if (RequiresReservedPower)
				{
					SkillCostType costType = CostType;
					int num = ((costType == SkillCostType.Life) ? me.Health : me.Mana);
					float num2 = ((costType == SkillCostType.Life) ? LifeReservation : ManaReservation);
					if ((float)num < num2)
					{
						error = string.Format(global::_003CModule_003E.smethod_5<string>(3290746604u), Name, costType, num, num2);
						return false;
					}
					return true;
				}
				if (!RequiresPercentPower)
				{
					SkillCostType costType2 = CostType;
					if (GetStatFromAll(StatTypeGGG.VirtualEnergyShieldProtectsMana) != 0 || me.GetStat(StatTypeGGG.VirtualEnergyShieldProtectsMana) != 0)
					{
						bool flag;
						if (!(flag = (costType2 == SkillCostType.Life && Cost < me.Health) || Cost < me.EnergyShield + me.Mana))
						{
							error = string.Format(global::_003CModule_003E.smethod_9<string>(582743698u), Name, flag, costType2);
						}
						return flag;
					}
					int num3 = ((costType2 == SkillCostType.Life) ? me.Health : me.Mana);
					float num4 = ((costType2 == SkillCostType.Life) ? LifeCost : ManaCost);
					if ((float)num3 >= num4)
					{
						if ((!(InternalId == global::_003CModule_003E.smethod_9<string>(596112776u)) && !(InternalId == global::_003CModule_003E.smethod_5<string>(2169347584u)) && !(InternalId == global::_003CModule_003E.smethod_8<string>(2131994475u)) && !(InternalId == global::_003CModule_003E.smethod_7<string>(1529694003u))) || (!me.HasAspectSpiderBuff && !me.HasAspectCrabBuff && !me.HasAspectCatBuff && !me.HasAspectBirdBuff))
						{
							return true;
						}
						error = string.Format(global::_003CModule_003E.smethod_6<string>(2473361907u), Name);
						return false;
					}
					error = string.Format(global::_003CModule_003E.smethod_9<string>(2900212153u), Name, costType2, num3, num4);
					return false;
				}
				SkillCostType costType3 = CostType;
				if (costType3 == SkillCostType.Life && me.MaxHealth == 1)
				{
					error = string.Format(global::_003CModule_003E.smethod_5<string>(2127906544u), Name);
					return false;
				}
				int num5 = ((costType3 == SkillCostType.Life) ? me.MaxHealth : me.MaxMana);
				float num6 = ((costType3 == SkillCostType.Life) ? ((float)me.MaxHealth / 100f) : ((float)me.MaxMana / 100f));
				float num7 = ((costType3 == SkillCostType.Life) ? ((float)Math.Round(((float)LokiPoe.ObjectManager.Me.HealthReservedPercent + LifeReservationPermyriad) * num6 + (float)LokiPoe.ObjectManager.Me.HealthReserved, 2, MidpointRounding.ToEven)) : ((float)Math.Round((LokiPoe.ObjectManager.Me.ManaReservedPercent + ManaReservationPermyriad) * num6 + (float)LokiPoe.ObjectManager.Me.ManaReserved, 2, MidpointRounding.ToEven)));
				if ((float)num5 - num7 < 1f)
				{
					float num8 = ((costType3 == SkillCostType.Life) ? ((float)Math.Round((float)LokiPoe.ObjectManager.Me.HealthReservedPercent * num6, 2, MidpointRounding.ToEven)) : ((float)Math.Round(LokiPoe.ObjectManager.Me.ManaReservedPercent * num6, 2, MidpointRounding.ToEven)));
					double num9 = ((costType3 == SkillCostType.Life) ? Math.Round(LifeReservationPermyriad * num6, 2, MidpointRounding.ToEven) : Math.Round(ManaReservationPermyriad * num6, 2, MidpointRounding.ToEven));
					int num10 = ((costType3 == SkillCostType.Life) ? LokiPoe.ObjectManager.Me.HealthReserved : LokiPoe.ObjectManager.Me.ManaReserved);
					error = string.Format(string.Format(global::_003CModule_003E.smethod_6<string>(2945989835u), Name, costType3, num5, num8, num9, num10, (float)num5 - num7));
					return false;
				}
				return true;
			}
			error = string.Format(global::_003CModule_003E.smethod_8<string>(3144966280u), Name);
			return false;
		}
		error = string.Format(global::_003CModule_003E.smethod_6<string>(1185476803u), Name);
		return false;
	}

	public static Keys GetKeyForSlot(int slot)
	{
		return slot switch
		{
			1 => LokiPoe.Input.Binding.use_bound_skill1, 
			2 => LokiPoe.Input.Binding.use_bound_skill2, 
			3 => LokiPoe.Input.Binding.use_bound_skill3, 
			4 => LokiPoe.Input.Binding.use_bound_skill4, 
			5 => LokiPoe.Input.Binding.use_bound_skill5, 
			6 => LokiPoe.Input.Binding.use_bound_skill6, 
			7 => LokiPoe.Input.Binding.use_bound_skill7, 
			8 => LokiPoe.Input.Binding.use_bound_skill8, 
			9 => LokiPoe.Input.Binding.use_bound_skill9, 
			10 => LokiPoe.Input.Binding.use_bound_skill10, 
			11 => LokiPoe.Input.Binding.use_bound_skill11, 
			12 => LokiPoe.Input.Binding.use_bound_skill12, 
			13 => LokiPoe.Input.Binding.use_bound_skill13, 
			_ => Keys.None, 
		};
	}

	public static LokiPoe.Input.KeysCombo GetKeyComboForSlot(int slot)
	{
		return slot switch
		{
			1 => LokiPoe.Input.Binding.use_bound_skill1_combo, 
			2 => LokiPoe.Input.Binding.use_bound_skill2_combo, 
			3 => LokiPoe.Input.Binding.use_bound_skill3_combo, 
			4 => LokiPoe.Input.Binding.use_bound_skill4_combo, 
			5 => LokiPoe.Input.Binding.use_bound_skill5_combo, 
			6 => LokiPoe.Input.Binding.use_bound_skill6_combo, 
			7 => LokiPoe.Input.Binding.use_bound_skill7_combo, 
			8 => LokiPoe.Input.Binding.use_bound_skill8_combo, 
			9 => LokiPoe.Input.Binding.use_bound_skill9_combo, 
			10 => LokiPoe.Input.Binding.use_bound_skill10_combo, 
			11 => LokiPoe.Input.Binding.use_bound_skill11_combo, 
			12 => LokiPoe.Input.Binding.use_bound_skill12_combo, 
			13 => LokiPoe.Input.Binding.use_bound_skill13_combo, 
			_ => new LokiPoe.Input.KeysCombo(Keys.None, Keys.None), 
		};
	}

	public int GetStat(StatTypeGGG stat)
	{
		if (!Stats.TryGetValue(stat, out var value))
		{
			return 0;
		}
		return value;
	}

	public int GetStatFromAll(StatTypeGGG stat)
	{
		if (!AllStats.TryGetValue(stat, out var value))
		{
			return 0;
		}
		return value;
	}

	private Dictionary<StatTypeGGG, int> method_0()
	{
		if (Struct135_0.intptr_Stats == 0L)
		{
			return new Dictionary<StatTypeGGG, int>();
		}
		return DreamPoeBot.Loki.Components.Stats.GetDictionaryStatTypeGGGInt(base.M.FastIntPtrToStruct<Stats.Struct217StatsD>(Struct135_0.intptr_Stats, Struct218StatsDSize));
	}

	private Dictionary<StatTypeGGG, int> method_1()
	{
		if (Struct135_0.intptr_Stats == 0L)
		{
			return new Dictionary<StatTypeGGG, int>();
		}
		return DreamPoeBot.Loki.Components.Stats.GetDictionaryStatTypeGGGInt(base.M.FastIntPtrToStruct<Stats.Struct217StatsD>(Struct135_0.intptr_Stats, Struct218StatsDSize), bool_0: true);
	}

	public float SpellCost()
	{
		float num = Cost;
		if (!RequiresPercentPower)
		{
			float num2 = 1f + (float)GetStatFromAll(StatTypeGGG.MonsterLevelScaleMaximumManaAndManaCostPosPctFinal) / 100f;
			num *= num2;
		}
		int statFromAll = GetStatFromAll(RequiresReservedPower ? StatTypeGGG.ManaReservationPosPct : StatTypeGGG.ManaCostPosPct);
		statFromAll = -statFromAll;
		if (statFromAll >= 100)
		{
			return 0f;
		}
		float num3 = num - num * (float)statFromAll / 100f;
		if (!RequiresReservedPower)
		{
			num3 += (float)GetStatFromAll(StatTypeGGG.SkillManaCostPos);
		}
		if (num3 < 0f)
		{
			num3 = 0f;
		}
		if (GetStatFromAll(StatTypeGGG.HeraldManaReservationOverride45Pct) == 1)
		{
			ActiveSkillsEnum activeSkillsEnum = ActiveSkillsEnum;
			if (activeSkillsEnum - 331 <= ActiveSkillsEnum.vaal_ground_slam)
			{
				num3 = 45f;
			}
		}
		return num3;
	}

	public float FinalSpellCost(bool dontTruncate = false)
	{
		if (GetStatFromAll(StatTypeGGG.NoManaReserved) == 1)
		{
			return 0f;
		}
		return SpellCost();
	}

	public override string ToString()
	{
		_ = Struct135_0;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(2101171747u), base.Address, DisplayString));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3224440940u), Id));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(3491720354u), InternalName));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(4186365778u), InternalId));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3168888377u), InventorySlot));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(1869821143u), ActiveSkillsEnum));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(1799899593u), IsUserSkill));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(1628543819u), Seals));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1469812221u), SocketIndex));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(609481854u), Slot));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1308441410u), string.Join(global::_003CModule_003E.smethod_5<string>(163386207u), Slots)));
		if (SkillBelongsToMe)
		{
			string error;
			bool flag = CanUseEx(out error);
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(1057703858u), flag, error));
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(3714692622u), IsCastable));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(4281730921u), IsConsideredAura));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(790906282u), IsAurifiedCurse));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(957266090u), IsTrap));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(1139833288u), IsTotem));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(2692991444u), IsMine));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(2588716876u), IsOnSkillBar));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(3315954260u), BoundKey));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(2101990497u), string.Join(global::_003CModule_003E.smethod_7<string>(2773443830u), BoundKeys)));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(3546637272u), RequiresPercentPower));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(2879857573u), RequiresReservedPower));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3843738208u), CurrentlyRequiresPercentPower));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(438968774u), NumberDeployed));
		List<NetworkObject> deployedObjects = DeployedObjects;
		if (deployedObjects.Any())
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1321810488u)));
			foreach (NetworkObject item in deployedObjects)
			{
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(3811465895u), item.Id, item.Name, item.Metadata));
			}
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(113656959u), SkillActiveToken));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(2133692853u), CooldownsActive));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(3439275735u), IsOnCooldown));
		if (!CurrentlyRequiresPercentPower)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(3041976133u), Cost, CostType));
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(2232849692u), SpellCost(), CostType, FinalSpellCost(dontTruncate: true)));
		}
		else
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(4091000635u), Cost, CostType));
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(2471136172u), SpellCost(), CostType, FinalSpellCost(dontTruncate: true)));
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(1447028018u), SkillBelongsToMe));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(2098946012u), AmICursingWithThis));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(1005259239u), AmIUsingConsideredAuraWithThis));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3702086645u), IsVaalSkill));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(1766746761u), CurrentSouls));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(2043593830u), SoulsPerUse));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1691343883u), TotalVaalUses));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(2011871632u), TimeSinceLastAction));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(158792116u), TimeSinceLastMove));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(1452777725u), TotalUses));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(2565481592u), MaxUses));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(3418689156u), Cooldown));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(940201860u), UsesAvailable));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(948339693u), CastingSpell));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(532631311u), HundredTimesAttacksPerSecond));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(1397298770u), Dps));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(1633379750u), CastTime));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(2891319481u), (SkillGem != null) ? SkillGem.FullName : global::_003CModule_003E.smethod_6<string>(1280836744u)));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(1642423641u)));
		foreach (string item2 in SkillType)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(606475432u), item2));
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(457084406u)));
		foreach (string skillTag in SkillTags)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(4166168484u), skillTag));
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(1153690156u)));
		foreach (KeyValuePair<StatTypeGGG, int> stat in Stats)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(1653774643u), stat.Key, stat.Value));
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(2660846735u)));
		foreach (DatGrantedEffectsPerLevelWrapper support in Supports)
		{
			DatGrantedEffectWrapper grantedEffect = support.GrantedEffect;
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(2544238763u), grantedEffect.Name, grantedEffect.SupportLetter, support.Level));
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3524061898u), LinkedDisplayString));
		return stringBuilder.ToString();
	}

	private Struct135_MainSkillStructure method_2()
	{
		return base.M.FastIntPtrToStruct<Struct135_MainSkillStructure>(base.Address);
	}
}
