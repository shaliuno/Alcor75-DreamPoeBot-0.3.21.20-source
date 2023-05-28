using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.FilesInMemory;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.NativeWrappers;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Game.Objects;

public class Monster : Actor
{
	private PerFrameCachedValue<bool> perFrameCachedValue_10;

	private bool? nullable_23;

	public bool IsAliveHostile
	{
		get
		{
			if (base.Reaction == Reaction.Enemy)
			{
				return !base.IsDead;
			}
			return false;
		}
	}

	public new bool CorpseUsable
	{
		get
		{
			Life component = base.Entity.GetComponent<Life>();
			if (component == null)
			{
				return false;
			}
			return component.CorpseUsable;
		}
	}

	public bool IsImprisoned
	{
		get
		{
			if (!nullable_23.HasValue)
			{
				if (perFrameCachedValue_10 == null)
				{
					perFrameCachedValue_10 = new PerFrameCachedValue<bool>(method_16);
				}
				return perFrameCachedValue_10;
			}
			return nullable_23.Value;
		}
	}

	public bool IsActive
	{
		get
		{
			if (base.Reaction == Reaction.Enemy && !base.IsDead && base.IsTargetable && !base.Invincible)
			{
				return !IsHidden;
			}
			return false;
		}
	}

	public bool IsActiveDead
	{
		get
		{
			if (base.Reaction == Reaction.Enemy && base.IsDead && base.IsTargetable)
			{
				return !IsHidden;
			}
			return false;
		}
	}

	public bool IsHidden => GetStat(StatTypeGGG.IsHiddenMonster) != 0;

	public Rarity Rarity
	{
		get
		{
			ObjectMagicProperties component = base._entity.GetComponent<ObjectMagicProperties>();
			if (component == null)
			{
				return Rarity.Normal;
			}
			return component.Rarity;
		}
	}

	public IEnumerable<KeyValuePair<StatTypeGGG, int>> AffixStats
	{
		get
		{
			Dictionary<StatTypeGGG, int> dictionary = new Dictionary<StatTypeGGG, int>();
			ObjectMagicProperties component = base._entity.GetComponent<ObjectMagicProperties>();
			if (!(component == null))
			{
				foreach (ModsDat.ModRecord affix in component.Affixes)
				{
					int num = -1;
					StatsDat.StatRecord[] statNames = affix.StatNames;
					foreach (StatsDat.StatRecord statRecord in statNames)
					{
						num++;
						if (statRecord != null && Enum.TryParse<StatTypeGGG>(statRecord.StatTypeGGG, out var result))
						{
							dictionary.Add(result, affix.StatRange[num].Min);
						}
					}
				}
				return dictionary;
			}
			return dictionary;
		}
	}

	public IEnumerable<ModsDat.ModRecord> Affixes
	{
		get
		{
			List<ModsDat.ModRecord> list = new List<ModsDat.ModRecord>();
			ObjectMagicProperties component = base._entity.GetComponent<ObjectMagicProperties>();
			if (!(component == null))
			{
				foreach (ModsDat.ModRecord affix in component.Affixes)
				{
					list.Add(affix);
				}
				return list;
			}
			return list;
		}
	}

	public IEnumerable<ModsDat.ModRecord> ExplicitAffixes
	{
		get
		{
			List<ModsDat.ModRecord> list = new List<ModsDat.ModRecord>();
			ObjectMagicProperties component = base._entity.GetComponent<ObjectMagicProperties>();
			if (component == null)
			{
				return list;
			}
			foreach (ModsDat.ModRecord affix in component.Affixes)
			{
				if (!affix.InternalName.Contains(global::_003CModule_003E.smethod_6<string>(3311983396u)))
				{
					list.Add(affix);
				}
			}
			return list;
		}
	}

	public IEnumerable<ModsDat.ModRecord> ImplicitAffixes
	{
		get
		{
			List<ModsDat.ModRecord> list = new List<ModsDat.ModRecord>();
			ObjectMagicProperties component = base._entity.GetComponent<ObjectMagicProperties>();
			if (!(component == null))
			{
				foreach (ModsDat.ModRecord affix in component.Affixes)
				{
					if (affix.InternalName.Contains(global::_003CModule_003E.smethod_9<string>(869876898u)))
					{
						list.Add(affix);
					}
				}
				return list;
			}
			return list;
		}
	}

	public Dictionary<StatTypeGGG, int> ImplicitStats
	{
		get
		{
			Dictionary<StatTypeGGG, int> dictionary = new Dictionary<StatTypeGGG, int>();
			ObjectMagicProperties component = base._entity.GetComponent<ObjectMagicProperties>();
			if (!(component == null))
			{
				foreach (ModsDat.ModRecord affix in component.Affixes)
				{
					if (affix.InternalName.Contains(global::_003CModule_003E.smethod_6<string>(3311983396u)))
					{
						int num = -1;
						StatsDat.StatRecord[] statNames = affix.StatNames;
						foreach (StatsDat.StatRecord statRecord in statNames)
						{
							num++;
							if (statRecord != null && Enum.TryParse<StatTypeGGG>(statRecord.StatTypeGGG, out var result))
							{
								if (!dictionary.ContainsKey(result))
								{
									dictionary.Add(result, affix.StatRange[num].Min);
								}
								else
								{
									dictionary[result] += affix.StatRange[num].Min;
								}
							}
						}
					}
				}
				return dictionary;
			}
			return dictionary;
		}
	}

	public Dictionary<StatTypeGGG, int> ExplicitStats
	{
		get
		{
			Dictionary<StatTypeGGG, int> dictionary = new Dictionary<StatTypeGGG, int>();
			ObjectMagicProperties component = base._entity.GetComponent<ObjectMagicProperties>();
			if (component == null)
			{
				return dictionary;
			}
			foreach (ModsDat.ModRecord affix in component.Affixes)
			{
				if (affix.InternalName.Contains(global::_003CModule_003E.smethod_9<string>(869876898u)))
				{
					continue;
				}
				int num = -1;
				StatsDat.StatRecord[] statNames = affix.StatNames;
				foreach (StatsDat.StatRecord statRecord in statNames)
				{
					num++;
					if (statRecord != null && Enum.TryParse<StatTypeGGG>(statRecord.StatTypeGGG, out var result))
					{
						if (!dictionary.ContainsKey(result))
						{
							dictionary.Add(result, affix.StatRange[num].Min);
						}
						else
						{
							dictionary[result] += affix.StatRange[num].Min;
						}
					}
				}
			}
			return dictionary;
		}
	}

	public bool IsCursable
	{
		get
		{
			if (LokiPoe.LocalData.MapMods.TryGetValue(StatTypeGGG.MapMonstersAreImmuneToCurses, out var value) && value != 0)
			{
				return false;
			}
			if (Affixes.FirstOrDefault((ModsDat.ModRecord x) => x.InternalName == global::_003CModule_003E.smethod_8<string>(1702104688u)) == null)
			{
				if (Affixes.FirstOrDefault((ModsDat.ModRecord x) => x.InternalName == global::_003CModule_003E.smethod_9<string>(3639827427u)) != null)
				{
					return false;
				}
				if (GetStat(StatTypeGGG.ImmuneToCurses) == 1)
				{
					return false;
				}
				if (GetStat(StatTypeGGG.Hexproof) != 1)
				{
					if (LokiPoe.LocalData.MapMods.TryGetValue(StatTypeGGG.MapMonstersAreHexproof, out value) && value != 0)
					{
						return false;
					}
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public bool HasSpeciesBeenNettedAlready => false;

	public bool IsSpeciesCapturableForBestiary => false;

	public bool HasBestiaryEnragedAura
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.capture_monster_enraged);
			if (buff != null && buff.Charges > 0)
			{
				return buff.TimeLeft.TotalMilliseconds > 0.0;
			}
			return false;
		}
	}

	public bool HasBestiaryTrappedAura
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.capture_monster_trapped);
			if (buff != null && buff.Charges > 0)
			{
				return buff.TimeLeft.TotalMilliseconds > 0.0;
			}
			return false;
		}
	}

	public bool HasBestiaryCapturedAura
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.capture_monster_captured);
			if (buff != null && buff.Charges > 0)
			{
				return buff.TimeLeft.TotalMilliseconds > 0.0;
			}
			return false;
		}
	}

	public bool HasBestiaryDisappearingAura
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.capture_monster_disappearing);
			if (buff != null && buff.Charges > 0)
			{
				return buff.TimeLeft.TotalMilliseconds > 0.0;
			}
			return false;
		}
	}

	public bool CannotDie
	{
		get
		{
			List<Aura> list = base.Auras.Where((Aura x) => x.InternalName == global::_003CModule_003E.smethod_6<string>(1670966726u)).ToList();
			Aura aura = list.FirstOrDefault();
			if (!(aura != null))
			{
				return false;
			}
			if (base.Id == aura.CasterId)
			{
				return list.Count != 1;
			}
			return true;
		}
	}

	public List<string> Tags => base.Components.MonsterComponent.Tags;

	public string MonsterTypeId => base.Components.MonsterComponent.MonsterTypeId;

	public string MonsterTypeMetadata => base.Components.MonsterComponent.MonsterTypeMetadata;

	public int Level => base.Components.MonsterComponent.Level;

	public string BaseResistenceName => base.Components.MonsterComponent.BaseResistenceName;

	public bool IsMapBoss
	{
		get
		{
			if (Rarity == Rarity.Unique)
			{
				return Affixes.Any((ModsDat.ModRecord x) => x.Category == global::_003CModule_003E.smethod_6<string>(1894725969u));
			}
			return false;
		}
	}

	public bool DropMetamorphosisIngredient
	{
		get
		{
			IEnumerable<MinimapIconWrapper> source = LokiPoe.InstanceInfo.MinimapIcons.Where((MinimapIconWrapper x) => x != null && x.MinimapIcon != null && x.MinimapIcon.Name == global::_003CModule_003E.smethod_6<string>(131987202u) && x.NetworkObject != null);
			return source.Any((MinimapIconWrapper x) => x.NetworkObject.Id == base.Id);
		}
	}

	internal Monster(EntityWrapper entity)
		: base(entity)
	{
	}

	public new string Dump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(1453010816u)));
		if (base.CurrentAction == null)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3716248872u)));
		}
		else if (!(base.CurrentAction.Skill == null))
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(4188642136u), base.CurrentAction.Skill.Name, base.CurrentAction.Skill.InternalName, base.CurrentAction.Destination.X, base.CurrentAction.Destination.Y));
		}
		else
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3464480849u), base.CurrentAction.Destination.X, base.CurrentAction.Destination.Y));
		}
		if (base.Components.ActorComponent != null)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(2628722542u)));
			foreach (Skill availableSkill in base.AvailableSkills)
			{
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(332862738u), availableSkill.Name, availableSkill.InternalName));
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(52387976u)));
				foreach (KeyValuePair<StatTypeGGG, int> stat in availableSkill.Stats)
				{
					stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(1922061146u), stat.Key.ToString(), stat.Value));
				}
			}
		}
		if (base.Components.BuffsComponent != null)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(1160668309u)));
			foreach (Aura aura in base.Auras)
			{
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(4172615383u), aura.Name));
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(1962348586u), aura.InternalName));
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3900229435u), aura.Description));
			}
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(865814190u), CorpseUsable));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(2120710947u), IsImprisoned));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(583243805u), IsActive));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(3511259554u), base.IsTargetable));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(2290583838u), base.Invincible));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3549132724u), IsImprisoned));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(2870085256u), base.Health));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(2394580872u), base.IsDead));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3201602654u), IsActiveDead));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(1061209813u), IsHidden));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(2714876275u), Rarity));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(775486834u), IsCursable));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1450307088u), CannotDie));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(4031298189u), IsMapBoss));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(679943456u), DropMetamorphosisIngredient));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(2116303169u), HasBestiaryEnragedAura));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(1742331807u), HasBestiaryTrappedAura));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(191496550u), HasBestiaryCapturedAura));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(405965329u), HasBestiaryDisappearingAura));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3507691684u), MonsterTypeId));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(4044667267u), MonsterTypeMetadata));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3692857941u)));
		foreach (string tag in Tags)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3444907389u), tag));
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3985799550u)));
		foreach (KeyValuePair<StatTypeGGG, int> implicitStat in ImplicitStats)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3252939945u), implicitStat.Key.ToString(), implicitStat.Value));
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(654805477u)));
		foreach (KeyValuePair<StatTypeGGG, int> explicitStat in ExplicitStats)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(3956552305u), explicitStat.Key.ToString(), explicitStat.Value));
		}
		return stringBuilder.ToString();
	}

	private bool method_16()
	{
		if (!nullable_23.HasValue)
		{
			foreach (Monolith item in LokiPoe.ObjectManager.GetObjectsByType<Monolith>().ToList())
			{
				NetworkObject childNetworkObject = item.ChildNetworkObject;
				if (childNetworkObject != null && childNetworkObject.Id == base.Id)
				{
					return true;
				}
			}
			nullable_23 = false;
		}
		return nullable_23.Value;
	}
}
