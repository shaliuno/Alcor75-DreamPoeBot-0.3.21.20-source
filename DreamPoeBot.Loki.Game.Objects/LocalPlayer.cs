using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using log4net;

namespace DreamPoeBot.Loki.Game.Objects;

public class LocalPlayer : Player
{
	[Serializable]
	private sealed class Class291
	{
		public static readonly Class291 Class9 = new Class291();

		internal bool method_0(DatPassiveSkillWrapper datPassiveSkillWrapper_0)
		{
			return datPassiveSkillWrapper_0.Name == global::_003CModule_003E.smethod_6<string>(287095324u);
		}

		internal bool method_1(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[0];
		}

		internal bool method_2(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[1];
		}

		internal bool method_3(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[2];
		}

		internal bool method_4(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[3];
		}

		internal bool method_5(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[4];
		}

		internal bool method_6(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[5];
		}

		internal bool method_7(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[6];
		}

		internal bool method_8(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[7];
		}

		internal bool method_9(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[8];
		}

		internal bool method_10(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[9];
		}

		internal bool method_11(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[10];
		}

		internal bool method_12(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[11];
		}

		internal bool method_13(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[12];
		}
	}

	private sealed class Class293
	{
		public string string_0;

		internal bool method_0(Skill skill_0)
		{
			if (skill_0 != null)
			{
				return skill_0.Name == string_0;
			}
			return false;
		}
	}

	private static readonly ILog ilog_2 = Logger.GetLoggerInstanceForType();

	private PerFrameCachedValue<int> perFrameCachedValue_9;

	public int BestiaryNetVariation
	{
		get
		{
			if (perFrameCachedValue_9 == null)
			{
				perFrameCachedValue_9 = new PerFrameCachedValue<int>(method_15);
			}
			return perFrameCachedValue_9;
		}
	}

	public Portal TownPortal => LokiPoe.ObjectManager.TownPortal(Name);

	public PartyStatus PartyStatus => LokiPoe.InstanceInfo.PartyStatus;

	public string League => LokiPoe.InstanceInfo.League;

	public List<ushort> SkillBarIds => LokiPoe.InstanceInfo.SkillBarIds;

	public List<Skill> SkillBarSkills => LokiPoe.InstanceInfo.SkillBarSkills;

	public bool IsInHideout => LokiPoe.CurrentWorldArea.IsHideoutArea;

	public bool IsInTown => LokiPoe.CurrentWorldArea.IsTown;

	public bool IsInOverworld => LokiPoe.CurrentWorldArea.IsOverworldArea;

	public bool IsInCorruptedArea => LokiPoe.CurrentWorldArea.IsCorruptedArea;

	public bool IsInMapRoom => LokiPoe.CurrentWorldArea.IsMapRoom;

	private static IEnumerable<Inventory> IEnumerable_0 => new Inventory[12]
	{
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.LeftHand),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.RightHand),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.OffLeftHand),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.OffRightHand),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.Head),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.Chest),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.Gloves),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.Boots),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.Belt),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.LeftRing),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.RightRing),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.Neck)
	};

	public IEnumerable<Item> EquippedItems
	{
		get
		{
			new List<Item>();
			foreach (Inventory item2 in IEnumerable_0)
			{
				if (item2 != null)
				{
					Item item = item2.Items.FirstOrDefault();
					if (item != null)
					{
						yield return item;
					}
				}
			}
		}
	}

	public int NumberOfDeployedBrand
	{
		get
		{
			int num = 0;
			DreamPoeBot.Loki.Components.Actor component = base._entity.GetComponent<DreamPoeBot.Loki.Components.Actor>();
			foreach (Skill item in component.AvailableSkills.Where((Skill x) => x.InternalId.Contains(global::_003CModule_003E.smethod_6<string>(757497517u))))
			{
				num += item.SkillActiveToken;
			}
			return num;
		}
	}

	public int TotalCursesAllowed
	{
		get
		{
			int num = 1;
			foreach (Item equippedItem in EquippedItems)
			{
				if (equippedItem.Stats.TryGetValue(StatTypeGGG.NumberOfAdditionalCursesAllowed, out var value))
				{
					num += value;
				}
			}
			if (LokiPoe.ObjectManager.Me.Passives.Any(Class291.Class9.method_0))
			{
				num++;
			}
			return num;
		}
	}

	public IEnumerable<DatPassiveSkillWrapper> Passives
	{
		get
		{
			Dat.BuildPassinveLookupTable();
			foreach (ushort passiveSkillId in LokiPoe.InstanceInfo.PassiveSkillIds)
			{
				if (!Dat.dictionary_IdToPassiveSkillWrapper.TryGetValue(passiveSkillId, out var value))
				{
					ilog_2.ErrorFormat(global::_003CModule_003E.smethod_6<string>(558847716u), (object)passiveSkillId);
				}
				else
				{
					yield return value;
				}
			}
		}
	}

	public List<DatPassiveSkillWrapper> AtlasPassiveSkills => LokiPoe.InstanceInfo.AtlasPassiveSkills;

	public int AtlasPassivePointsAvailable => LokiPoe.InstanceInfo.AtlasPassivePointsAvailable;

	public List<DatPassiveSkillWrapper> PassiveSkills => LokiPoe.InstanceInfo.PassiveSkills;

	public int PassiveSkillPointsAvailable => LokiPoe.InstanceInfo.PassiveSkillPointsAvailable;

	public int AscendencySkillPointsAvailable => LokiPoe.InstanceInfo.AscendencySkillPointsAvailable;

	public List<Item> EquippedSkillGems
	{
		get
		{
			List<Item> list = new List<Item>();
			foreach (Inventory item2 in IEnumerable_0)
			{
				foreach (Item item3 in item2.Items)
				{
					if (item3 == null || item3.Components.SocketsComponent == null)
					{
						continue;
					}
					for (int i = 0; i < item3.SocketedGems.Length; i++)
					{
						Item item = item3.SocketedGems[i];
						if (!(item == null))
						{
							list.Add(item);
						}
					}
				}
			}
			return list;
		}
	}

	internal LocalPlayer(EntityWrapper entry)
		: base(entry)
	{
	}

	public Keys GetKeyForSkill(Skill skill)
	{
		ushort id = skill.Id;
		uint num2 = default(uint);
		while (true)
		{
			List<ushort> skillBarIds = SkillBarIds;
			while (true)
			{
				int num = 0;
				while (true)
				{
					if (num < skillBarIds.Count)
					{
						while (true)
						{
							if (skillBarIds[num] == id)
							{
								while (true)
								{
									switch (num)
									{
									case 0:
										goto IL_00fd;
									case 1:
										goto IL_0103;
									case 2:
										goto IL_0109;
									case 3:
										goto IL_010f;
									case 4:
										goto IL_0115;
									case 5:
										goto IL_011b;
									case 6:
										goto IL_0121;
									case 7:
										goto IL_0127;
									case 8:
										goto IL_012d;
									case 9:
										goto IL_0133;
									case 10:
										goto IL_0139;
									case 11:
										goto IL_013f;
									case 12:
										goto IL_0145;
									}
									int num3 = (int)((num2 * 117445510) ^ 0x469C50C2);
									while (true)
									{
										switch ((num2 = (uint)num3 ^ 0x2378AFCCu) % 23u)
										{
										case 16u:
											num3 = (int)(num2 * 148018065) ^ -1919769355;
											continue;
										case 18u:
											break;
										case 8u:
											goto end_IL_0096;
										case 20u:
											goto IL_00df;
										case 3u:
										case 19u:
											goto end_IL_00d5;
										case 12u:
											goto end_IL_00e3;
										case 5u:
										case 7u:
											goto end_IL_00ee;
										default:
											goto IL_00fb;
										case 22u:
											goto IL_00fd;
										case 17u:
											goto IL_0103;
										case 14u:
											goto IL_0109;
										case 2u:
											goto IL_010f;
										case 21u:
											goto IL_0115;
										case 11u:
											goto IL_011b;
										case 6u:
											goto IL_0121;
										case 4u:
											goto IL_0127;
										case 1u:
											goto IL_012d;
										case 9u:
											goto IL_0133;
										case 0u:
											goto IL_0139;
										case 13u:
											goto IL_013f;
										case 10u:
											goto IL_0145;
										}
										break;
									}
									continue;
									IL_0103:
									return LokiPoe.Input.Binding.use_bound_skill2;
									IL_00fd:
									return LokiPoe.Input.Binding.use_bound_skill1;
									IL_0145:
									return LokiPoe.Input.Binding.use_bound_skill13;
									IL_013f:
									return LokiPoe.Input.Binding.use_bound_skill12;
									IL_0139:
									return LokiPoe.Input.Binding.use_bound_skill11;
									IL_0133:
									return LokiPoe.Input.Binding.use_bound_skill10;
									IL_012d:
									return LokiPoe.Input.Binding.use_bound_skill9;
									IL_0127:
									return LokiPoe.Input.Binding.use_bound_skill8;
									IL_0121:
									return LokiPoe.Input.Binding.use_bound_skill7;
									IL_011b:
									return LokiPoe.Input.Binding.use_bound_skill6;
									IL_0115:
									return LokiPoe.Input.Binding.use_bound_skill5;
									IL_010f:
									return LokiPoe.Input.Binding.use_bound_skill4;
									IL_0109:
									return LokiPoe.Input.Binding.use_bound_skill3;
									continue;
									end_IL_0096:
									break;
								}
								continue;
							}
							goto IL_00df;
							IL_00df:
							num++;
							break;
							continue;
							end_IL_00d5:
							break;
						}
						continue;
					}
					goto IL_00fb;
					IL_00fb:
					return Keys.None;
					continue;
					end_IL_00e3:
					break;
				}
				continue;
				end_IL_00ee:
				break;
			}
		}
	}

	public LokiPoe.Input.KeysCombo GetKeyComboForSkill(Skill skill)
	{
		ushort id = skill.Id;
		List<ushort> skillBarIds = SkillBarIds;
		uint num2 = default(uint);
		while (true)
		{
			int num = 0;
			while (true)
			{
				if (num < skillBarIds.Count)
				{
					while (true)
					{
						if (skillBarIds[num] == id)
						{
							while (true)
							{
								switch (num)
								{
								case 0:
									goto IL_00ff;
								case 1:
									goto IL_0105;
								case 2:
									goto IL_010b;
								case 3:
									goto IL_0111;
								case 4:
									goto IL_0117;
								case 5:
									goto IL_011d;
								case 6:
									goto IL_0123;
								case 7:
									goto IL_0129;
								case 8:
									goto IL_012f;
								case 9:
									goto IL_0135;
								case 10:
									goto IL_013b;
								case 11:
									goto IL_0141;
								case 12:
									goto IL_0147;
								}
								int num3 = (int)((num2 * 1195512723) ^ 0xCFE8280);
								while (true)
								{
									switch ((num2 = (uint)num3 ^ 0x77B59DC6u) % 22u)
									{
									case 14u:
										num3 = (int)((num2 * 1558709719) ^ 0x3BACFADB);
										continue;
									case 10u:
										break;
									case 7u:
										goto end_IL_0099;
									case 9u:
										goto IL_00e4;
									case 18u:
									case 21u:
										goto end_IL_00d8;
									case 1u:
									case 16u:
										goto end_IL_00e8;
									default:
										goto IL_00f7;
									case 13u:
										goto IL_00ff;
									case 15u:
										goto IL_0105;
									case 19u:
										goto IL_010b;
									case 20u:
										goto IL_0111;
									case 17u:
										goto IL_0117;
									case 3u:
										goto IL_011d;
									case 8u:
										goto IL_0123;
									case 2u:
										goto IL_0129;
									case 5u:
										goto IL_012f;
									case 0u:
										goto IL_0135;
									case 6u:
										goto IL_013b;
									case 4u:
										goto IL_0141;
									case 11u:
										goto IL_0147;
									}
									break;
								}
								continue;
								IL_0105:
								return LokiPoe.Input.Binding.use_bound_skill2_combo;
								IL_00ff:
								return LokiPoe.Input.Binding.use_bound_skill1_combo;
								IL_0147:
								return LokiPoe.Input.Binding.use_bound_skill13_combo;
								IL_0141:
								return LokiPoe.Input.Binding.use_bound_skill12_combo;
								IL_013b:
								return LokiPoe.Input.Binding.use_bound_skill11_combo;
								IL_0135:
								return LokiPoe.Input.Binding.use_bound_skill10_combo;
								IL_012f:
								return LokiPoe.Input.Binding.use_bound_skill9_combo;
								IL_0129:
								return LokiPoe.Input.Binding.use_bound_skill8_combo;
								IL_0123:
								return LokiPoe.Input.Binding.use_bound_skill7_combo;
								IL_011d:
								return LokiPoe.Input.Binding.use_bound_skill6_combo;
								IL_0117:
								return LokiPoe.Input.Binding.use_bound_skill5_combo;
								IL_0111:
								return LokiPoe.Input.Binding.use_bound_skill4_combo;
								IL_010b:
								return LokiPoe.Input.Binding.use_bound_skill3_combo;
								continue;
								end_IL_0099:
								break;
							}
							continue;
						}
						goto IL_00e4;
						IL_00e4:
						num++;
						break;
						continue;
						end_IL_00d8:
						break;
					}
					continue;
				}
				goto IL_00f7;
				IL_00f7:
				return new LokiPoe.Input.KeysCombo(Keys.None, Keys.None);
				continue;
				end_IL_00e8:
				break;
			}
		}
	}

	public IEnumerable<Keys> GetKeysForSkill(Skill skill)
	{
		uint num2 = default(uint);
		bool flag = default(bool);
		ushort id = default(ushort);
		List<ushort> skillBarIds = default(List<ushort>);
		int i = default(int);
		int num4 = default(int);
		int num5 = default(int);
		while (true)
		{
			LocalPlayer localPlayer = this;
			while (true)
			{
				IL_0293:
				int num;
				int num3;
				switch (num)
				{
				case 0:
					goto IL_01b6;
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
				case 12:
				case 13:
					goto IL_026e;
				default:
					num3 = (int)(num2 * 2007756566) ^ -2098765040;
					goto IL_002a;
				case 14:
					yield break;
					IL_01b6:
					flag = false;
					goto IL_01bd;
					IL_01bd:
					id = skill.Id;
					skillBarIds = localPlayer.SkillBarIds;
					goto IL_01da;
					IL_01da:
					i = 0;
					goto IL_01e1;
					IL_01e1:
					if (i < skillBarIds.Count)
					{
						goto IL_0191;
					}
					goto IL_02e2;
					IL_0191:
					if (skillBarIds[i] == id)
					{
						goto IL_0188;
					}
					goto IL_026e;
					IL_0188:
					flag = true;
					goto IL_017f;
					IL_017f:
					num4 = i;
					goto IL_0140;
					IL_0140:
					switch (num4)
					{
					case 0:
						goto IL_02fe;
					case 1:
						goto IL_0312;
					case 2:
						goto IL_0326;
					case 3:
						goto IL_033a;
					case 4:
						goto IL_034e;
					case 5:
						goto IL_0362;
					case 6:
						goto IL_0376;
					case 7:
						goto IL_038a;
					case 8:
						goto IL_039e;
					case 9:
						goto IL_03b3;
					case 10:
						goto IL_03c8;
					case 11:
						goto IL_03dd;
					case 12:
						goto IL_03f2;
					}
					num3 = ((int)num2 * -257849100) ^ -189937660;
					goto IL_002a;
					IL_01f9:
					i = num5 + 1;
					goto IL_01e1;
					IL_002a:
					while (true)
					{
						switch ((num2 = (uint)num3 ^ 0xC5E6512Bu) % 64u)
						{
						case 23u:
							num3 = ((int)num2 * -1931735213) ^ 0xE10D873;
							continue;
						default:
							yield break;
						case 38u:
							break;
						case 9u:
							goto IL_017f;
						case 22u:
							goto IL_0188;
						case 31u:
							goto IL_0191;
						case 7u:
						case 53u:
							goto IL_01b6;
						case 15u:
							goto IL_01bd;
						case 0u:
							goto IL_01da;
						case 34u:
						case 47u:
							goto IL_01e1;
						case 26u:
							goto IL_01f9;
						case 2u:
						case 3u:
						case 4u:
						case 6u:
						case 13u:
						case 14u:
						case 16u:
						case 21u:
						case 25u:
						case 29u:
						case 30u:
						case 33u:
						case 35u:
						case 36u:
						case 39u:
						case 40u:
						case 42u:
						case 45u:
						case 54u:
							goto IL_026e;
						case 59u:
							goto IL_0293;
						case 12u:
						case 58u:
							goto end_IL_0294;
						case 41u:
							yield break;
						case 57u:
							goto IL_02e2;
						case 63u:
							goto IL_02ed;
						case 43u:
							try
							{
								/*Error near IL_02fd: Unexpected return in MoveNext()*/;
							}
							finally
							{
								/*Error: Could not find finallyMethod for state=14.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
							}
						case 20u:
							goto IL_02fe;
						case 28u:
							try
							{
								/*Error near IL_0311: Unexpected return in MoveNext()*/;
							}
							finally
							{
								/*Error: Could not find finallyMethod for state=1.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
							}
						case 61u:
							goto IL_0312;
						case 10u:
							try
							{
								/*Error near IL_0325: Unexpected return in MoveNext()*/;
							}
							finally
							{
								/*Error: Could not find finallyMethod for state=2.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
							}
						case 49u:
							goto IL_0326;
						case 8u:
							/*Error near IL_0339: Unexpected return in MoveNext()*/;
						case 52u:
							goto IL_033a;
						case 18u:
							goto IL_034e;
						case 37u:
							try
							{
								/*Error near IL_0361: Unexpected return in MoveNext()*/;
							}
							finally
							{
								/*Error: Could not find finallyMethod for state=5.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
							}
						case 5u:
							goto IL_0362;
						case 32u:
							goto IL_0376;
						case 60u:
							/*Error near IL_0389: Unexpected return in MoveNext()*/;
						case 44u:
							goto IL_038a;
						case 19u:
							try
							{
								/*Error near IL_039d: Unexpected return in MoveNext()*/;
							}
							finally
							{
								/*Error: Could not find finallyMethod for state=8.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
							}
						case 46u:
							goto IL_039e;
						case 51u:
							try
							{
								/*Error near IL_03b2: Unexpected return in MoveNext()*/;
							}
							finally
							{
								/*Error: Could not find finallyMethod for state=9.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
							}
						case 50u:
							goto IL_03b3;
						case 24u:
							try
							{
								goto IL_03c6;
								IL_03c6:
								/*Error near IL_03c7: Unexpected return in MoveNext()*/;
							}
							finally
							{
								/*Error: Could not find finallyMethod for state=10.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
							}
						case 62u:
							goto IL_03c6;
						case 56u:
							goto IL_03c8;
						case 48u:
							/*Error near IL_03dc: Unexpected return in MoveNext()*/;
						case 11u:
							goto IL_03dd;
						case 1u:
							/*Error near IL_03f1: Unexpected return in MoveNext()*/;
						case 55u:
							goto IL_03f2;
						case 17u:
							yield break;
						}
						break;
					}
					goto IL_0140;
					IL_03f2:
					yield return LokiPoe.Input.Binding.use_bound_skill13;
					break;
					IL_03dd:
					yield return LokiPoe.Input.Binding.use_bound_skill12;
					break;
					IL_03c8:
					yield return LokiPoe.Input.Binding.use_bound_skill11;
					break;
					IL_03b3:
					yield return LokiPoe.Input.Binding.use_bound_skill10;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_039e:
					yield return LokiPoe.Input.Binding.use_bound_skill9;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_038a:
					yield return LokiPoe.Input.Binding.use_bound_skill8;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_0376:
					yield return LokiPoe.Input.Binding.use_bound_skill7;
					break;
					IL_0362:
					yield return LokiPoe.Input.Binding.use_bound_skill6;
					break;
					IL_034e:
					yield return LokiPoe.Input.Binding.use_bound_skill5;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_033a:
					yield return LokiPoe.Input.Binding.use_bound_skill4;
					break;
					IL_0326:
					yield return LokiPoe.Input.Binding.use_bound_skill3;
					break;
					IL_0312:
					yield return LokiPoe.Input.Binding.use_bound_skill2;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_02fe:
					yield return LokiPoe.Input.Binding.use_bound_skill1;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_02e2:
					if (flag)
					{
						yield break;
					}
					goto IL_02ed;
					IL_02ed:
					yield return Keys.None;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_026e:
					num5 = i;
					goto IL_01f9;
					end_IL_0294:
					break;
				}
				break;
			}
		}
	}

	public IEnumerable<LokiPoe.Input.KeysCombo> GetKeysComboForSkill(Skill skill)
	{
		uint num2 = default(uint);
		bool flag = default(bool);
		ushort id = default(ushort);
		List<ushort> skillBarIds = default(List<ushort>);
		int i = default(int);
		int num4 = default(int);
		while (true)
		{
			LocalPlayer localPlayer = this;
			int num;
			int num3;
			switch (num)
			{
			case 0:
				goto IL_01d8;
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
				goto IL_0285;
			default:
				num3 = ((int)num2 * -22864310) ^ -1098576870;
				goto IL_002a;
			case 14:
				yield break;
				IL_01d8:
				flag = false;
				goto IL_01df;
				IL_01df:
				id = skill.Id;
				goto IL_01f0;
				IL_01f0:
				skillBarIds = localPlayer.SkillBarIds;
				goto IL_01fc;
				IL_01fc:
				i = 0;
				goto IL_0203;
				IL_0203:
				if (i < skillBarIds.Count)
				{
					goto IL_01b3;
				}
				goto IL_0301;
				IL_01b3:
				if (skillBarIds[i] == id)
				{
					goto IL_01a3;
				}
				goto IL_0285;
				IL_01a3:
				flag = true;
				num4 = i;
				goto IL_0164;
				IL_0164:
				switch (num4)
				{
				case 0:
					goto IL_0325;
				case 1:
					goto IL_0339;
				case 2:
					goto IL_034d;
				case 3:
					goto IL_0361;
				case 4:
					goto IL_0375;
				case 5:
					goto IL_0389;
				case 6:
					goto IL_039d;
				case 7:
					goto IL_03b1;
				case 8:
					goto IL_03c5;
				case 9:
					goto IL_03da;
				case 10:
					goto IL_03ef;
				case 11:
					goto IL_0404;
				case 12:
					goto IL_0419;
				}
				num3 = ((int)num2 * -1237634596) ^ 0x10AA6C5;
				goto IL_002a;
				IL_0285:
				i++;
				goto IL_0203;
				IL_002a:
				while (true)
				{
					switch ((num2 = (uint)num3 ^ 0xDB1076A0u) % 73u)
					{
					case 57u:
						num3 = ((int)num2 * -1299478530) ^ 0x3C757F46;
						continue;
					default:
						yield break;
					case 23u:
						break;
					case 33u:
						goto IL_01a3;
					case 4u:
						goto IL_01b3;
					case 13u:
					case 36u:
						goto IL_01d8;
					case 27u:
						goto IL_01df;
					case 21u:
						goto IL_01f0;
					case 34u:
						goto IL_01fc;
					case 42u:
					case 66u:
						goto IL_0203;
					case 0u:
					case 3u:
					case 5u:
					case 7u:
					case 9u:
					case 15u:
					case 16u:
					case 17u:
					case 18u:
					case 22u:
					case 24u:
					case 26u:
					case 28u:
					case 30u:
					case 37u:
					case 43u:
					case 50u:
					case 52u:
					case 53u:
					case 56u:
					case 59u:
					case 60u:
					case 71u:
						goto IL_0285;
					case 12u:
					case 41u:
						goto end_IL_02be;
					case 63u:
						goto IL_0301;
					case 44u:
						goto IL_030c;
					case 40u:
						/*Error near IL_0322: Unexpected return in MoveNext()*/;
					case 68u:
						yield break;
					case 51u:
						goto IL_0325;
					case 54u:
						try
						{
							goto IL_0337;
							IL_0337:
							/*Error near IL_0338: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=1.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 49u:
						goto IL_0337;
					case 10u:
						goto IL_0339;
					case 67u:
						/*Error near IL_034c: Unexpected return in MoveNext()*/;
					case 8u:
						goto IL_034d;
					case 32u:
						goto IL_0361;
					case 65u:
						try
						{
							goto IL_0373;
							IL_0373:
							/*Error near IL_0374: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=4.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 19u:
						goto IL_0373;
					case 31u:
						goto IL_0375;
					case 14u:
						/*Error near IL_0388: Unexpected return in MoveNext()*/;
					case 39u:
						goto IL_0389;
					case 72u:
						try
						{
							/*Error near IL_039c: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=6.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 20u:
						goto IL_039d;
					case 64u:
						try
						{
							goto IL_03af;
							IL_03af:
							/*Error near IL_03b0: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=7.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 69u:
						goto IL_03af;
					case 46u:
						goto IL_03b1;
					case 6u:
						try
						{
							goto IL_03c3;
							IL_03c3:
							/*Error near IL_03c4: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=8.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 35u:
						goto IL_03c3;
					case 45u:
						goto IL_03c5;
					case 25u:
						try
						{
							goto IL_03d8;
							IL_03d8:
							/*Error near IL_03d9: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=9.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 1u:
						goto IL_03d8;
					case 70u:
						goto IL_03da;
					case 29u:
						try
						{
							/*Error near IL_03ee: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=10.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 58u:
						goto IL_03ef;
					case 62u:
						try
						{
							goto IL_0402;
							IL_0402:
							/*Error near IL_0403: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=11.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 47u:
						goto IL_0402;
					case 38u:
						goto IL_0404;
					case 2u:
						/*Error near IL_0418: Unexpected return in MoveNext()*/;
					case 55u:
						goto IL_0419;
					case 61u:
						/*Error near IL_042d: Unexpected return in MoveNext()*/;
					case 48u:
						yield break;
					}
					break;
				}
				goto IL_0164;
				IL_0419:
				yield return LokiPoe.Input.Binding.use_bound_skill13_combo;
				break;
				IL_0404:
				yield return LokiPoe.Input.Binding.use_bound_skill12_combo;
				break;
				IL_03ef:
				yield return LokiPoe.Input.Binding.use_bound_skill11_combo;
				/*Error: Unable to find new state assignment for yield return*/;
				IL_03da:
				yield return LokiPoe.Input.Binding.use_bound_skill10_combo;
				/*Error: Unable to find new state assignment for yield return*/;
				IL_03c5:
				yield return LokiPoe.Input.Binding.use_bound_skill9_combo;
				/*Error: Unable to find new state assignment for yield return*/;
				IL_03b1:
				yield return LokiPoe.Input.Binding.use_bound_skill8_combo;
				/*Error: Unable to find new state assignment for yield return*/;
				IL_039d:
				yield return LokiPoe.Input.Binding.use_bound_skill7_combo;
				/*Error: Unable to find new state assignment for yield return*/;
				IL_0389:
				yield return LokiPoe.Input.Binding.use_bound_skill6_combo;
				/*Error: Unable to find new state assignment for yield return*/;
				IL_0375:
				yield return LokiPoe.Input.Binding.use_bound_skill5_combo;
				break;
				IL_0361:
				yield return LokiPoe.Input.Binding.use_bound_skill4_combo;
				/*Error: Unable to find new state assignment for yield return*/;
				IL_034d:
				yield return LokiPoe.Input.Binding.use_bound_skill3_combo;
				break;
				IL_0339:
				yield return LokiPoe.Input.Binding.use_bound_skill2_combo;
				break;
				IL_0325:
				yield return LokiPoe.Input.Binding.use_bound_skill1_combo;
				/*Error: Unable to find new state assignment for yield return*/;
				IL_0301:
				if (flag)
				{
					yield break;
				}
				goto IL_030c;
				IL_030c:
				yield return new LokiPoe.Input.KeysCombo(Keys.None, Keys.None);
				break;
				end_IL_02be:
				break;
			}
		}
	}

	public Skill FromActionKey(ActionKeys key)
	{
		return key switch
		{
			ActionKeys.use_bound_skill1 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_1), 
			ActionKeys.use_bound_skill2 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_2), 
			ActionKeys.use_bound_skill3 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_3), 
			ActionKeys.use_bound_skill4 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_4), 
			ActionKeys.use_bound_skill5 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_5), 
			ActionKeys.use_bound_skill6 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_6), 
			ActionKeys.use_bound_skill7 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_7), 
			ActionKeys.use_bound_skill8 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_8), 
			ActionKeys.use_bound_skill9 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_9), 
			ActionKeys.use_bound_skill10 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_10), 
			ActionKeys.use_bound_skill11 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_11), 
			ActionKeys.use_bound_skill12 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_12), 
			ActionKeys.use_bound_skill13 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_13), 
			_ => null, 
		};
	}

	public Skill FromKey(Keys key)
	{
		if (LokiPoe.Input.Binding.use_bound_skill1 == key)
		{
			return FromActionKey(ActionKeys.use_bound_skill1);
		}
		if (LokiPoe.Input.Binding.use_bound_skill2 != key)
		{
			if (LokiPoe.Input.Binding.use_bound_skill3 != key)
			{
				if (LokiPoe.Input.Binding.use_bound_skill4 != key)
				{
					if (LokiPoe.Input.Binding.use_bound_skill5 != key)
					{
						if (LokiPoe.Input.Binding.use_bound_skill6 == key)
						{
							return FromActionKey(ActionKeys.use_bound_skill6);
						}
						if (LokiPoe.Input.Binding.use_bound_skill7 != key)
						{
							if (LokiPoe.Input.Binding.use_bound_skill8 == key)
							{
								return FromActionKey(ActionKeys.use_bound_skill8);
							}
							if (LokiPoe.Input.Binding.use_bound_skill9 == key)
							{
								return FromActionKey(ActionKeys.use_bound_skill9);
							}
							if (LokiPoe.Input.Binding.use_bound_skill10 != key)
							{
								if (LokiPoe.Input.Binding.use_bound_skill11 != key)
								{
									if (LokiPoe.Input.Binding.use_bound_skill12 == key)
									{
										return FromActionKey(ActionKeys.use_bound_skill12);
									}
									if (LokiPoe.Input.Binding.use_bound_skill13 == key)
									{
										return FromActionKey(ActionKeys.use_bound_skill13);
									}
									return null;
								}
								return FromActionKey(ActionKeys.use_bound_skill11);
							}
							return FromActionKey(ActionKeys.use_bound_skill10);
						}
						return FromActionKey(ActionKeys.use_bound_skill7);
					}
					return FromActionKey(ActionKeys.use_bound_skill5);
				}
				return FromActionKey(ActionKeys.use_bound_skill4);
			}
			return FromActionKey(ActionKeys.use_bound_skill3);
		}
		return FromActionKey(ActionKeys.use_bound_skill2);
	}

	public Skill FromKeyCombo(LokiPoe.Input.KeysCombo key)
	{
		if (LokiPoe.Input.Binding.use_bound_skill1_combo == key)
		{
			return FromActionKey(ActionKeys.use_bound_skill1);
		}
		if (LokiPoe.Input.Binding.use_bound_skill2_combo == key)
		{
			return FromActionKey(ActionKeys.use_bound_skill2);
		}
		if (LokiPoe.Input.Binding.use_bound_skill3_combo == key)
		{
			return FromActionKey(ActionKeys.use_bound_skill3);
		}
		if (LokiPoe.Input.Binding.use_bound_skill4_combo == key)
		{
			return FromActionKey(ActionKeys.use_bound_skill4);
		}
		if (LokiPoe.Input.Binding.use_bound_skill5_combo != key)
		{
			if (LokiPoe.Input.Binding.use_bound_skill6_combo == key)
			{
				return FromActionKey(ActionKeys.use_bound_skill6);
			}
			if (LokiPoe.Input.Binding.use_bound_skill7_combo != key)
			{
				if (LokiPoe.Input.Binding.use_bound_skill8_combo != key)
				{
					if (LokiPoe.Input.Binding.use_bound_skill9_combo == key)
					{
						return FromActionKey(ActionKeys.use_bound_skill9);
					}
					if (LokiPoe.Input.Binding.use_bound_skill10_combo == key)
					{
						return FromActionKey(ActionKeys.use_bound_skill10);
					}
					if (LokiPoe.Input.Binding.use_bound_skill11_combo == key)
					{
						return FromActionKey(ActionKeys.use_bound_skill11);
					}
					if (LokiPoe.Input.Binding.use_bound_skill12_combo != key)
					{
						if (LokiPoe.Input.Binding.use_bound_skill13_combo == key)
						{
							return FromActionKey(ActionKeys.use_bound_skill13);
						}
						return null;
					}
					return FromActionKey(ActionKeys.use_bound_skill12);
				}
				return FromActionKey(ActionKeys.use_bound_skill8);
			}
			return FromActionKey(ActionKeys.use_bound_skill7);
		}
		return FromActionKey(ActionKeys.use_bound_skill5);
	}

	public bool HasSkillOnBarByName(string name)
	{
		Class293 @class = new Class293();
		@class.string_0 = name;
		return LokiPoe.InstanceInfo.SkillBarSkills.Any(@class.method_0);
	}

	public bool HasAtlasPassive(string value)
	{
		return LokiPoe.InstanceInfo.HasAtlasPassive(value);
	}

	public bool HasPassive(string value)
	{
		return LokiPoe.InstanceInfo.HasPassive(value);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(2593497864u)));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3627691708u), base.Entity.Address));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(2716033993u), base.Id));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(2485544958u), Name));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3141854801u), base.Type));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(2517384192u), base.Position));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(2028944942u), base.Class));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3576273247u), base.Level));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(1236581506u), base.Experience));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(4036332101u), base.PantheonMajor));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(749855127u), base.PantheonMinor));
		DatHideoutWrapper hideout = base.Hideout;
		if (hideout != null)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(939110989u), hideout.Id));
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(2341232996u), base.HideoutLevel));
		}
		Portal townPortal = TownPortal;
		if (townPortal != null)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(1042165762u), townPortal.Name));
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(4196858418u), PartyStatus));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3088859091u), League));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3494302659u), TotalCursesAllowed));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(518513370u)));
		foreach (KeyValuePair<StatTypeGGG, int> stat in base.Stats)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(2602012211u), stat.Key, stat.Value));
		}
		foreach (Aura aura in base.Auras)
		{
			stringBuilder.AppendLine(aura.ToString());
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3093558887u), global::_003CModule_003E.smethod_9<string>(153597936u), base.LeftHandWeaponVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(955040355u), global::_003CModule_003E.smethod_5<string>(3968309963u), base.RightHandWeaponVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(1653774643u), global::_003CModule_003E.smethod_5<string>(491599360u), base.ChestVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1550026689u), global::_003CModule_003E.smethod_8<string>(3705843563u), base.HelmVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(955040355u), global::_003CModule_003E.smethod_8<string>(1107709095u), base.GlovesVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1550026689u), global::_003CModule_003E.smethod_6<string>(832825843u), base.BootsVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3093558887u), global::_003CModule_003E.smethod_8<string>(3811614015u), base.UnknownVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(955040355u), global::_003CModule_003E.smethod_8<string>(563945930u), base.LeftRingVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1550026689u), global::_003CModule_003E.smethod_5<string>(2070095290u), base.RightRingVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(832455156u), global::_003CModule_003E.smethod_5<string>(205033449u), base.BeltVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(2606661620u)));
		string[] labyrinthTrialAreaIds = LokiPoe.LabyrinthTrialAreaIds;
		foreach (string text in labyrinthTrialAreaIds)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(635936615u), text, IsAscendencyTrialCompleted(text)));
		}
		return stringBuilder.ToString();
	}

	private int method_15()
	{
		return GetStat(StatTypeGGG.BestiaryNetVariation);
	}
}
