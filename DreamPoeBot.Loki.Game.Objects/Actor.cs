using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Game.Objects;

public class Actor : NetworkObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct139
	{
		public readonly byte byte_0;

		private readonly byte byte_1;

		private readonly byte byte_2;

		private readonly byte byte_3;

		public readonly int int_0;

		public readonly int int_1;

		public readonly int int_2;

		public readonly NativeVector nativeVector_0;

		public readonly int int_3;

		public readonly int int_4;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct140
	{
		public readonly ushort ushort_0;

		public readonly ushort ushort_1;

		public readonly int int_0;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct141
	{
		public IntPtr intptr_0;

		public NativeVector nativeVector_0;
	}

	private bool? nullable_20;

	private bool? nullable_21;

	private bool? nullable_22;

	private PerFrameCachedValue<bool> perFrameCachedValue_5;

	private PerFrameCachedValue<ActorFlags> perFrameCachedValue_6;

	public string LeftHandWeaponVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (inventories != null)
			{
				return inventories.LeftHand.Name;
			}
			return "";
		}
	}

	public string RightHandWeaponVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (!(inventories != null))
			{
				return "";
			}
			return inventories.RightHand.Name;
		}
	}

	public string ChestVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (inventories != null)
			{
				return inventories.Chest.Name;
			}
			return "";
		}
	}

	public string HelmVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (!(inventories != null))
			{
				return "";
			}
			return inventories.Helm.Name;
		}
	}

	public string GlovesVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (inventories != null)
			{
				return inventories.Gloves.Name;
			}
			return "";
		}
	}

	public string BootsVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (inventories != null)
			{
				return inventories.Boots.Name;
			}
			return "";
		}
	}

	public string UnknownVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (!(inventories != null))
			{
				return "";
			}
			return inventories.Unknown.Name;
		}
	}

	public string LeftRingVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (!(inventories != null))
			{
				return "";
			}
			return inventories.LeftRing.Name;
		}
	}

	public string RightRingVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (inventories != null)
			{
				return inventories.RightRing.Name;
			}
			return "";
		}
	}

	public string BeltVisual
	{
		get
		{
			Inventories inventories = ((base.Entity == null) ? null : base.Entity.GetComponent<Inventories>());
			if (inventories != null)
			{
				return inventories.Belt.Name;
			}
			return "";
		}
	}

	public bool IsTargetingMe
	{
		get
		{
			if (!HasCurrentAction)
			{
				return false;
			}
			DreamPoeBot.Loki.Components.Actor.ActionWrapper currentAction = CurrentAction;
			if (currentAction != null)
			{
				if (currentAction.Destination.Distance(LokiPoe.LocalData.MyPosition) < 30)
				{
					return true;
				}
				return object.Equals(currentAction.Target, LokiPoe.ObjectManager.Me);
			}
			return false;
		}
	}

	public bool CorpseUsable
	{
		get
		{
			if (perFrameCachedValue_5 == null)
			{
				perFrameCachedValue_5 = new PerFrameCachedValue<bool>(method_8);
			}
			return perFrameCachedValue_5;
		}
	}

	public Dictionary<StatTypeGGG, int> Stats
	{
		get
		{
			Stats stats = ((base.Entity == null) ? null : base.Entity.GetComponent<Stats>());
			if (!(stats == null))
			{
				return stats.StatsD;
			}
			return new Dictionary<StatTypeGGG, int>();
		}
	}

	public Dictionary<StatTypeGGG, int> ModStats
	{
		get
		{
			ObjectMagicProperties objectMagicProperties = ((base.Entity == null) ? null : base.Entity.GetComponent<ObjectMagicProperties>());
			_ = objectMagicProperties == null;
			return new Dictionary<StatTypeGGG, int>();
		}
	}

	public List<string> ModStatsList
	{
		get
		{
			ObjectMagicProperties objectMagicProperties = ((base.Entity == null) ? null : base.Entity.GetComponent<ObjectMagicProperties>());
			if (!(objectMagicProperties == null))
			{
				return objectMagicProperties.Mods;
			}
			return new List<string>();
		}
	}

	public bool IsMoving => ActorFlags.HasFlag(ActorFlags.Moving);

	public bool IsUsingAbility => ActorFlags.HasFlag(ActorFlags.UsingAbility);

	public bool IsAbilityCooldownActive => ActorFlags.HasFlag(ActorFlags.AbilityCooldownActive);

	public bool InWashedUpState => ActorFlags.HasFlag(ActorFlags.WashedUpState);

	public ActorFlags ActorFlags => (ActorFlags)base.Entity.GetComponent<DreamPoeBot.Loki.Components.Actor>().Flags;

	public List<Aura> Auras
	{
		get
		{
			Buffs buffs = ((base.Entity == null) ? null : base.Entity.GetComponent<Buffs>());
			if (!(buffs != null))
			{
				return new List<Aura>();
			}
			return buffs.Auras;
		}
	}

	public int Health
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (life != null)
			{
				return life.Health;
			}
			return 0;
		}
	}

	public int MaxHealth
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0;
			}
			return life.MaxHealth;
		}
	}

	public float HealthPercent
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0f;
			}
			return life.HealthPercent;
		}
	}

	public float HealthPercentTotal
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (life != null)
			{
				return life.HealthPercentTotal;
			}
			return 0f;
		}
	}

	public int HealthReserved
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (life != null)
			{
				return life.HealthReserved;
			}
			return 0;
		}
	}

	public int HealthReservedPercent
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (life != null)
			{
				return life.HealthReservedPercent;
			}
			return 0;
		}
	}

	public int Mana
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0;
			}
			return life.Mana;
		}
	}

	public int MaxMana
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0;
			}
			return life.MaxMana;
		}
	}

	public float ManaPercent
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0f;
			}
			return life.ManaPercent;
		}
	}

	public float ManaPercentTotal
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0f;
			}
			return life.ManaPercentTotal;
		}
	}

	public int ManaReserved
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0;
			}
			return life.ManaReserved;
		}
	}

	public float ManaReservedPercent
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0f;
			}
			return life.ManaReservedPercent;
		}
	}

	public int EnergyShield
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0;
			}
			return life.EnergyShield;
		}
	}

	public int EnergyShieldMax
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0;
			}
			return life.EnergyShieldMax;
		}
	}

	public float EnergyShieldPercent
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0f;
			}
			return life.EnergyShieldPercent;
		}
	}

	public float EnergyShieldPercentTotal
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0f;
			}
			return life.EnergyShieldPercentTotal;
		}
	}

	public int EnergyShieldReserved
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (life != null)
			{
				return life.EnergyShieldReserved;
			}
			return 0;
		}
	}

	public float EnergyShieldReservedPercent
	{
		get
		{
			Life life = ((base.Entity == null) ? null : base.Entity.GetComponent<Life>());
			if (!(life != null))
			{
				return 0f;
			}
			return life.EnergyShieldReservedPercent;
		}
	}

	public IEnumerable<Skill> AvailableSkills => base.Entity.GetComponent<DreamPoeBot.Loki.Components.Actor>().AvailableSkills;

	public IEnumerable<Skill> UserSkills => AvailableSkills.Where((Skill x) => x.IsUserSkill);

	public bool IsDead => Health <= 0;

	public IEnumerable<NetworkObject> DeployedObjects
	{
		get
		{
			DreamPoeBot.Loki.Components.Actor actor = ((base.Entity == null) ? null : base.Entity.GetComponent<DreamPoeBot.Loki.Components.Actor>());
			if (actor != null)
			{
				List<NetworkObject> list = new List<NetworkObject>();
				{
					foreach (NetworkObject deployedObject in actor.DeployedObjects)
					{
						list.Add(new NetworkObject(deployedObject.Entity));
					}
					return list;
				}
			}
			return new List<NetworkObject>();
		}
	}

	public int BladeFlurryCharges
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.charged_attack);
			if (buff != null)
			{
				return buff.Charges;
			}
			return 0;
		}
	}

	public int FlameblastCharges
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.charged_blast_counter);
			if (buff != null)
			{
				return buff.Charges;
			}
			return 0;
		}
	}

	public int ReaveCharges
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.reave_counter);
			if (buff != null)
			{
				return buff.Charges;
			}
			return 0;
		}
	}

	public int IncinerateCharges
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.incinerate_counter);
			if (buff != null)
			{
				return buff.Charges;
			}
			return 0;
		}
	}

	public int BladeVortexCharges
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.blade_vortex_counter);
			if (!(buff != null))
			{
				return 0;
			}
			return buff.Charges;
		}
	}

	public Aura PowerChargeAura => Auras.FirstOrDefault((Aura x) => x.Name == global::_003CModule_003E.smethod_8<string>(1678505836u) && x.TimeLeft.TotalMilliseconds > 0.0);

	public int PowerCharges
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.power_charge);
			if (buff != null)
			{
				return buff.Charges;
			}
			return 0;
		}
	}

	public Aura FrenzyChargeAura => Auras.FirstOrDefault((Aura x) => x.Name == global::_003CModule_003E.smethod_8<string>(3375338664u) && x.TimeLeft.TotalMilliseconds > 0.0);

	public int FrenzyCharges
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.frenzy_charge);
			if (!(buff != null))
			{
				return 0;
			}
			return buff.Charges;
		}
	}

	public Aura EnduranceChargeAura => Auras.FirstOrDefault((Aura x) => x.Name == global::_003CModule_003E.smethod_7<string>(1780529603u) && x.TimeLeft.TotalMilliseconds > 0.0);

	public int EnduranceCharges
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.endurance_charge);
			if (buff != null)
			{
				return buff.Charges;
			}
			return 0;
		}
	}

	public Aura WinterOrbAura => Auras.FirstOrDefault((Aura x) => x.InternalName == global::_003CModule_003E.smethod_9<string>(1205987598u) && x.TimeLeft.TotalMilliseconds > 0.0);

	public int WinterOrbCharges
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.frost_fury_stage);
			if (buff != null)
			{
				return buff.Charges;
			}
			return 0;
		}
	}

	public bool HasCurrentAction
	{
		get
		{
			DreamPoeBot.Loki.Components.Actor actor = ((base.Entity == null) ? null : base.Entity.GetComponent<DreamPoeBot.Loki.Components.Actor>());
			if (actor != null)
			{
				return actor.HasCurrentAction;
			}
			return false;
		}
	}

	public DreamPoeBot.Loki.Components.Actor.ActionWrapper CurrentAction
	{
		get
		{
			DreamPoeBot.Loki.Components.Actor actor = ((base.Entity == null) ? null : base.Entity.GetComponent<DreamPoeBot.Loki.Components.Actor>());
			if (actor != null)
			{
				return actor.CurrentAction;
			}
			return null;
		}
	}

	public bool TormentIsTouched => HasAura(global::_003CModule_003E.smethod_5<string>(2885861043u));

	public bool TormentIsPossessed => HasAura(global::_003CModule_003E.smethod_9<string>(3861450503u));

	public bool HasProximityShield
	{
		get
		{
			if (!HasAura(global::_003CModule_003E.smethod_9<string>(2658324897u)))
			{
				return HasAura(global::_003CModule_003E.smethod_8<string>(2952256856u));
			}
			return true;
		}
	}

	public bool HasContagion => HasAura(global::_003CModule_003E.smethod_6<string>(2001214585u));

	public bool HasWither => HasAura(global::_003CModule_003E.smethod_9<string>(1119088591u));

	public int MaxTotemCount
	{
		get
		{
			int stat = GetStat(StatTypeGGG.NumberOfTotemsAllowed);
			if (stat != 0)
			{
				return stat;
			}
			return 1;
		}
	}

	public bool IsSpectating => GetStat(StatTypeGGG.Spectating) == 1;

	public bool IsUsingHealthFlask => HasAura(global::_003CModule_003E.smethod_9<string>(4210930281u));

	public bool IsUsingManaFlask => HasAura(global::_003CModule_003E.smethod_8<string>(208124817u));

	public bool IsUsingGraniteFlask => HasAura(global::_003CModule_003E.smethod_5<string>(1535913568u));

	public bool IsUsingQuicksilverFlask => HasAura(global::_003CModule_003E.smethod_8<string>(3959328948u));

	public bool IsUsingJadeFlask => HasAura(global::_003CModule_003E.smethod_8<string>(2660261714u));

	public bool IsUsingDiamondFlask => HasAura(global::_003CModule_003E.smethod_9<string>(1986103497u));

	public bool IsUsingSapphireFlask => HasAura(global::_003CModule_003E.smethod_5<string>(4136350022u));

	public bool IsUsingAmethystFlask => HasAura(global::_003CModule_003E.smethod_8<string>(847253125u));

	public bool IsUsingRubyFlask => HasAura(global::_003CModule_003E.smethod_7<string>(1167472937u));

	public bool IsUsingTopazFlask => HasAura(global::_003CModule_003E.smethod_6<string>(1950995701u));

	public bool IsUsingQuartzFlask => HasAura(global::_003CModule_003E.smethod_6<string>(610665978u));

	public bool IsUsingBasaltFlask => HasAura(global::_003CModule_003E.smethod_9<string>(272127302u));

	public bool IsUsingAquamarineFlask => HasAura(global::_003CModule_003E.smethod_9<string>(3881504120u));

	public bool IsUsingBismuthFlask => HasAura(global::_003CModule_003E.smethod_7<string>(396862765u));

	public bool IsUsingStibniteFlask => HasAura(global::_003CModule_003E.smethod_5<string>(667927627u));

	public bool IsUsingSulphurFlask => HasAura(global::_003CModule_003E.smethod_7<string>(3619220464u));

	public bool IsUsingSilverFlask => HasAura(global::_003CModule_003E.smethod_7<string>(1960727649u));

	public bool IsChilled => HasAura(global::_003CModule_003E.smethod_6<string>(3414646899u));

	public bool IsFrozen => HasAura(global::_003CModule_003E.smethod_6<string>(2471616778u));

	public bool IsIgnited => HasAura(global::_003CModule_003E.smethod_6<string>(2272966977u));

	public bool IsBurning => IsIgnited;

	public bool IsShocked => HasAura(global::_003CModule_003E.smethod_6<string>(2074317176u));

	public bool IsBleeding
	{
		get
		{
			if (!HasAura(global::_003CModule_003E.smethod_5<string>(3604659240u)))
			{
				return HasAura(global::_003CModule_003E.smethod_9<string>(466920808u));
			}
			return true;
		}
	}

	public bool HasLaviangasSpirit => HasAura(global::_003CModule_003E.smethod_9<string>(977771397u));

	public bool HasDivinationDistillate => HasAura(global::_003CModule_003E.smethod_7<string>(1762413971u));

	public bool HasBloodOfTheKarui => HasAura(global::_003CModule_003E.smethod_7<string>(3943864429u));

	public bool HasAtzirisPromise => HasAura(global::_003CModule_003E.smethod_7<string>(1699488396u));

	public bool HasBloodRageBuff => HasAura(global::_003CModule_003E.smethod_8<string>(3108659736u));

	public bool HasRighteousFireBuff => HasAura(global::_003CModule_003E.smethod_7<string>(919820408u));

	public bool HasArcticArmourBuff => HasAura(global::_003CModule_003E.smethod_5<string>(306767844u));

	public bool HasMoltenShellBuff => HasAura(global::_003CModule_003E.smethod_8<string>(1265829337u));

	public bool HasTempestShieldBuff => HasAura(global::_003CModule_003E.smethod_6<string>(633549685u));

	public bool HasHeraldOfAshBuff => HasBuff(BuffDefinitionsEnum.herald_of_ash);

	public bool HasHeraldOfIceBuff => HasBuff(BuffDefinitionsEnum.herald_of_ice);

	public bool HasHeraldOfThunderBuff => HasBuff(BuffDefinitionsEnum.herald_of_thunder);

	public bool HasHeraldOfPurityBuff => HasBuff(BuffDefinitionsEnum.herald_of_light);

	public bool HasHeraldOfAgonyBuff => HasBuff(BuffDefinitionsEnum.herald_of_agony);

	public bool HasPetrifiedBloodBuff => HasBuff(BuffDefinitionsEnum.petrified_blood);

	public bool HasSkitterbotsBuff => HasBuff(BuffDefinitionsEnum.skitterbots_buff);

	public bool HasClarityBuff => HasBuff(BuffDefinitionsEnum.player_aura_mana_regen);

	public bool HasVaalDeterminationBuff => HasBuff(BuffDefinitionsEnum.vaal_aura_armour);

	public bool HasVaalVitalityBuff => HasBuff(BuffDefinitionsEnum.vaal_aura_life_regen);

	public bool HasVaalClarityBuff => HasBuff(BuffDefinitionsEnum.vaal_aura_no_mana_cost);

	public bool HasVaalGraceBuff => HasBuff(BuffDefinitionsEnum.vaal_aura_dodge);

	public bool HasVaalDisciplineBuff => HasBuff(BuffDefinitionsEnum.vaal_aura_energy_shield);

	public bool HasVaalHasteBuff => HasBuff(BuffDefinitionsEnum.vaal_aura_speed);

	public bool HasGluttonyOfElementsBuff => HasBuff(BuffDefinitionsEnum.vaal_aura_elemental_damage_healing);

	public bool HasAspectBirdBuff => HasBuff(BuffDefinitionsEnum.bird_aspect);

	public bool HasAspectCatBuff => HasBuff(BuffDefinitionsEnum.cat_aspect);

	public bool HasAspectCrabBuff => HasBuff(BuffDefinitionsEnum.crab_aspect);

	public bool HasAspectSpiderBuff => HasBuff(BuffDefinitionsEnum.spider_aspect);

	public bool HasEnduranceCharge => EnduranceCharges > 0;

	public bool HasPowerCharge => PowerCharges > 0;

	public bool HasFrenzyCharge => FrenzyCharges > 0;

	public bool HasWinterOrbCharge => WinterOrbCharges > 0;

	public bool HasFleshOffering => HasAura(global::_003CModule_003E.smethod_9<string>(312234536u));

	public bool HasBoneOffering => HasAura(global::_003CModule_003E.smethod_9<string>(2369005970u));

	public bool HasKaruiSpirit => HasAura(global::_003CModule_003E.smethod_5<string>(3243499457u));

	public bool Invincible
	{
		get
		{
			if (!HasAura(global::_003CModule_003E.smethod_6<string>(1898551082u)))
			{
				return GetStat(StatTypeGGG.CannotBeDamaged) == 1;
			}
			return true;
		}
	}

	public bool IsMissionAreaSpawn => HasAura(global::_003CModule_003E.smethod_8<string>(1225602218u));

	public bool IsMissionMob => HasAura(global::_003CModule_003E.smethod_7<string>(3267882188u));

	public bool IsCorruptedMissionBeast => HasAura(global::_003CModule_003E.smethod_6<string>(2891800087u));

	public bool IsRelicInactive => HasAura(global::_003CModule_003E.smethod_9<string>(3753556004u));

	public List<NetworkObject> DeployedMines
	{
		get
		{
			List<NetworkObject> list = new List<NetworkObject>();
			foreach (Skill availableSkill in AvailableSkills)
			{
				if (!availableSkill.IsMine)
				{
					continue;
				}
				foreach (NetworkObject deployedObject in availableSkill.DeployedObjects)
				{
					NetworkObject item = new NetworkObject(deployedObject.Entity);
					list.Add(item);
				}
			}
			return list;
		}
	}

	public List<NetworkObject> DeployedTraps
	{
		get
		{
			List<NetworkObject> list = new List<NetworkObject>();
			foreach (Skill availableSkill in AvailableSkills)
			{
				if (!availableSkill.IsTrap)
				{
					continue;
				}
				foreach (NetworkObject deployedObject in availableSkill.DeployedObjects)
				{
					NetworkObject item = new NetworkObject(deployedObject.Entity);
					list.Add(item);
				}
			}
			return list;
		}
	}

	public List<NetworkObject> DeployedTotems
	{
		get
		{
			List<NetworkObject> list = new List<NetworkObject>();
			foreach (Skill availableSkill in AvailableSkills)
			{
				if (!availableSkill.IsTotem)
				{
					continue;
				}
				foreach (NetworkObject deployedObject in availableSkill.DeployedObjects)
				{
					NetworkObject item = new NetworkObject(deployedObject.Entity);
					list.Add(item);
				}
			}
			return list;
		}
	}

	public List<NetworkObject> DeployedMinions
	{
		get
		{
			List<NetworkObject> list = new List<NetworkObject>();
			foreach (Skill availableSkill in AvailableSkills)
			{
				if (!availableSkill.SkillTags.Contains(global::_003CModule_003E.smethod_8<string>(2484442333u)))
				{
					continue;
				}
				foreach (NetworkObject deployedObject in availableSkill.DeployedObjects)
				{
					NetworkObject item = new NetworkObject(deployedObject.Entity);
					list.Add(item);
				}
			}
			return list;
		}
	}

	public float TimeSinceLastAction
	{
		get
		{
			DreamPoeBot.Loki.Components.Actor actor = ((base.Entity == null) ? null : base.Entity.GetComponent<DreamPoeBot.Loki.Components.Actor>());
			if (actor != null)
			{
				return actor.TimeSinceLastAction;
			}
			return 0f;
		}
	}

	public float TimeSinceLastMove
	{
		get
		{
			DreamPoeBot.Loki.Components.Actor actor = ((base.Entity == null) ? null : base.Entity.GetComponent<DreamPoeBot.Loki.Components.Actor>());
			if (actor != null)
			{
				return actor.TimeSinceLastMove;
			}
			return 0f;
		}
	}

	public bool IsCursedWithTemporalChains => HasBuffFromOther(BuffDefinitionsEnum.curse_temporal_chains);

	public bool IsCursedWithNewPunishment => HasBuffFromOther(BuffDefinitionsEnum.curse_newpunishment);

	public bool IsCursedWithPunishment => HasBuffFromOther(BuffDefinitionsEnum.curse_punishment);

	public bool IsCursedWithAssassinsMark => HasBuffFromOther(BuffDefinitionsEnum.curse_assassins_mark);

	public bool IsCursedWithPoachersMark => HasBuffFromOther(BuffDefinitionsEnum.curse_poachers_mark);

	public bool IsCursedWithWarlordsMark => HasBuffFromOther(BuffDefinitionsEnum.curse_warlords_mark);

	public bool IsCursedWithProjectileWeakness => HasBuffFromOther(BuffDefinitionsEnum.curse_projectile_weakness);

	public bool IsCursedWithConductivity => HasBuffFromOther(BuffDefinitionsEnum.curse_lightning_weakness);

	public bool IsCursedWithEnfeeble => HasBuffFromOther(BuffDefinitionsEnum.curse_enfeeble);

	public bool IsCursedWithFrostbite => HasBuffFromOther(BuffDefinitionsEnum.curse_cold_weakness);

	public bool IsCursedWithFlammability => HasBuffFromOther(BuffDefinitionsEnum.curse_fire_weakness);

	public bool IsCursedWithElementalWeakness => HasBuffFromOther(BuffDefinitionsEnum.curse_elemental_weakness);

	public bool IsCursedWithVulnerability => HasBuffFromOther(BuffDefinitionsEnum.curse_vulnerability);

	public bool IsCursedWithDespair => HasBuffFromOther(BuffDefinitionsEnum.curse_chaos_weakness);

	public bool IsCursingWithTemporalChains => HasBuffFromSelf(BuffDefinitionsEnum.curse_temporal_chains);

	public bool IsCursingWithNewPunishment => HasBuffFromSelf(BuffDefinitionsEnum.curse_newpunishment);

	public bool IsCursingWithPunishment => HasBuffFromSelf(BuffDefinitionsEnum.curse_punishment);

	public bool IsCursingWithAssassinsMark => HasBuffFromSelf(BuffDefinitionsEnum.curse_assassins_mark);

	public bool IsCursingWithPoachersMark => HasBuffFromSelf(BuffDefinitionsEnum.curse_poachers_mark);

	public bool IsCursingWithWarlordsMark => HasBuffFromSelf(BuffDefinitionsEnum.curse_warlords_mark);

	public bool IsCursingWithProjectileWeakness => HasBuffFromSelf(BuffDefinitionsEnum.curse_projectile_weakness);

	public bool IsCursingWithConductivity => HasBuffFromSelf(BuffDefinitionsEnum.curse_lightning_weakness);

	public bool IsCursingWithEnfeeble => HasBuffFromSelf(BuffDefinitionsEnum.curse_enfeeble);

	public bool IsCursingWithFrostbite => HasBuffFromSelf(BuffDefinitionsEnum.curse_cold_weakness);

	public bool IsCursingWithFlammability => HasBuffFromSelf(BuffDefinitionsEnum.curse_fire_weakness);

	public bool IsCursingWithElementalWeakness => HasBuffFromSelf(BuffDefinitionsEnum.curse_elemental_weakness);

	public bool IsCursingWithVulnerability => HasBuffFromSelf(BuffDefinitionsEnum.curse_vulnerability);

	public bool IsCursingWithDespair => HasBuffFromSelf(BuffDefinitionsEnum.curse_chaos_weakness);

	public int CurseCount => Auras.Count((Aura x) => x.CasterId != base.Id && x.InternalName.Contains(global::_003CModule_003E.smethod_6<string>(3585961523u)));

	public bool IsBreachMonster
	{
		get
		{
			if (!nullable_20.HasValue)
			{
				nullable_20 = GetStat(StatTypeGGG.IsBreachMonster) == 1;
			}
			return nullable_20.Value;
		}
	}

	public bool IsStrongboxMinion
	{
		get
		{
			if (!nullable_21.HasValue)
			{
				nullable_21 = HasBuff(BuffDefinitionsEnum.summoned_monster_epk_buff);
			}
			return nullable_21.Value;
		}
	}

	public bool IsHarbingerMinion
	{
		get
		{
			if (!nullable_22.HasValue)
			{
				nullable_22 = HasBuff(BuffDefinitionsEnum.harbinger_minion_new);
			}
			return nullable_22.Value;
		}
	}

	internal Actor(EntityWrapper entity)
		: base(entity)
	{
	}

	internal Actor(Entity player)
		: base(player)
	{
		EntityWrapper entity = new EntityWrapper(player.Address);
		base._entity = entity;
	}

	private bool method_8()
	{
		Life component = base.Entity.GetComponent<Life>();
		if (component != null)
		{
			return component.CorpseUsable;
		}
		return false;
	}

	public int GetStat(StatTypeGGG stat)
	{
		Stats stats = ((base.Entity == null) ? null : base.Entity.GetComponent<Stats>());
		if (!(stats != null))
		{
			return 0;
		}
		if (stats.StatsD.ContainsKey(stat))
		{
			return stats.StatsD[stat];
		}
		return 0;
	}

	public bool HasAura(string name)
	{
		return Auras.Any((Aura x) => x.Name == name || x.Name == name + global::_003CModule_003E.smethod_5<string>(1835534526u) || x.Name == name + global::_003CModule_003E.smethod_6<string>(3040231004u) || x.InternalName == name || x.InternalName == name + global::_003CModule_003E.smethod_9<string>(4123089399u) || x.InternalName == name + global::_003CModule_003E.smethod_9<string>(2577168554u));
	}

	public bool HasAura(IEnumerable<string> names)
	{
		foreach (Aura aura in Auras)
		{
			if (aura.TimeLeft.TotalMilliseconds > 0.0 && names.Any((string x) => x == aura.Name || x + global::_003CModule_003E.smethod_5<string>(1835534526u) == aura.Name || x + global::_003CModule_003E.smethod_8<string>(3878874710u) == aura.Name || x == aura.InternalName || x + global::_003CModule_003E.smethod_9<string>(4123089399u) == aura.InternalName || x + global::_003CModule_003E.smethod_9<string>(2577168554u) == aura.InternalName))
			{
				return true;
			}
		}
		return false;
	}

	public bool HasBuff(string aura)
	{
		return Auras.Any((Aura x) => x.Name == aura && x.TimeLeft.TotalMilliseconds > 0.0);
	}

	public IEnumerable<Skill> GetSkillsByName(string name)
	{
		return AvailableSkills.Where((Skill x) => x.Name == name);
	}

	public bool HasSkillByName(string name)
	{
		return GetSkillsByName(name).Any();
	}

	public Skill GetSkillById(ushort id)
	{
		return AvailableSkills.FirstOrDefault((Skill x) => x.Id == id);
	}

	public Skill GetSkillByName(string name)
	{
		List<string> list = name.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
		if (list.Count > 1 && int.TryParse(list[list.Count - 1], out var result))
		{
			string text = name.Replace(global::_003CModule_003E.smethod_8<string>(337008270u) + result, "");
			result--;
			List<Skill> list2 = GetSkillsByName(text).ToList();
			if (result >= 0 && result < list2.Count)
			{
				return list2[result];
			}
			return null;
		}
		return GetSkillsByName(name).FirstOrDefault();
	}

	private uint getUintFromString(string name)
	{
		uint result = 0u;
		if (name != null)
		{
			result = 2166136261u;
			for (int i = 0; i < name.Length; i++)
			{
				result = (name[i] ^ result) * 16777619;
			}
			return result;
		}
		return result;
	}

	public bool HasCurseFrom(string skillName)
	{
		switch (getUintFromString(skillName))
		{
		case 1299977859u:
			if (skillName == global::_003CModule_003E.smethod_6<string>(3115559330u))
			{
				return IsCursedWithDespair;
			}
			break;
		case 1423058859u:
			if (skillName == global::_003CModule_003E.smethod_7<string>(825192477u))
			{
				return IsCursedWithTemporalChains;
			}
			break;
		case 3510303475u:
			if (skillName == global::_003CModule_003E.smethod_7<string>(3069568510u))
			{
				return IsCursedWithAssassinsMark;
			}
			break;
		case 571677158u:
			if (skillName == global::_003CModule_003E.smethod_8<string>(535841482u))
			{
				return IsCursedWithPoachersMark;
			}
			break;
		case 579956711u:
			if (skillName == global::_003CModule_003E.smethod_5<string>(2736673299u))
			{
				return IsCursedWithFrostbite;
			}
			break;
		case 449755603u:
			if (skillName == global::_003CModule_003E.smethod_5<string>(2998374586u))
			{
				return IsCursedWithEnfeeble;
			}
			break;
		case 4009271405u:
			if (skillName == global::_003CModule_003E.smethod_8<string>(525436173u))
			{
				return IsCursedWithWarlordsMark;
			}
			break;
		case 4050852692u:
			if (skillName == global::_003CModule_003E.smethod_7<string>(3150609717u))
			{
				return IsCursedWithNewPunishment;
			}
			break;
		case 4153453774u:
			if (skillName == global::_003CModule_003E.smethod_5<string>(2122100437u))
			{
				return IsCursedWithFlammability;
			}
			break;
		case 4105110801u:
			if (skillName == global::_003CModule_003E.smethod_9<string>(3598869732u))
			{
				return IsCursedWithVulnerability;
			}
			break;
		case 3511870008u:
			if (skillName == global::_003CModule_003E.smethod_5<string>(1843822734u))
			{
				return IsCursedWithConductivity;
			}
			break;
		case 3713468517u:
			if (skillName == global::_003CModule_003E.smethod_8<string>(21900127u))
			{
				return IsCursedWithProjectileWeakness;
			}
			break;
		case 3925853269u:
			if (skillName == global::_003CModule_003E.smethod_9<string>(1871524459u))
			{
				return IsCursedWithElementalWeakness;
			}
			break;
		}
		return false;
	}

	public bool HasConsideredAuraFrom(ActiveSkillsEnum @enum)
	{
		if (@enum <= ActiveSkillsEnum.petrified_blood)
		{
			uint num = default(uint);
			while (true)
			{
				if (@enum != ActiveSkillsEnum.arctic_armour)
				{
					while (true)
					{
						switch (@enum)
						{
						case ActiveSkillsEnum.herald_of_ash:
							goto IL_00c4;
						case ActiveSkillsEnum.herald_of_ice:
							goto IL_00cb;
						case ActiveSkillsEnum.herald_of_thunder:
							goto IL_00d2;
						case ActiveSkillsEnum.herald_of_agony:
							goto IL_00d9;
						case ActiveSkillsEnum.herald_of_light:
							goto IL_00e0;
						case ActiveSkillsEnum.petrified_blood:
							goto IL_00e7;
						}
						int num2 = ((int)num * -68545822) ^ 0x52498C49;
						while (true)
						{
							switch ((num = (uint)num2 ^ 0x46DA10Au) % 20u)
							{
							case 17u:
								num2 = (int)(num * 1197703835) ^ -1147069005;
								continue;
							case 9u:
								break;
							case 10u:
							case 15u:
								goto end_IL_0091;
							case 8u:
								goto IL_00c4;
							case 2u:
								goto IL_00cb;
							case 0u:
								goto IL_00d2;
							case 4u:
								goto IL_00d9;
							case 12u:
								goto IL_00e0;
							case 16u:
								goto IL_00e7;
							case 6u:
								goto IL_00ee;
							case 13u:
								goto end_IL_00ba;
							case 1u:
								goto IL_0111;
							default:
								goto IL_0119;
							case 19u:
								goto IL_011b;
							case 3u:
								goto IL_0122;
							case 18u:
								goto IL_0129;
							case 5u:
								goto IL_0130;
							case 11u:
								goto IL_0137;
							}
							break;
						}
						continue;
						IL_00cb:
						return HasHeraldOfIceBuff;
						IL_00c4:
						return HasHeraldOfAshBuff;
						IL_00e7:
						return HasPetrifiedBloodBuff;
						IL_00e0:
						return HasHeraldOfPurityBuff;
						IL_00d9:
						return HasHeraldOfAgonyBuff;
						IL_00d2:
						return HasHeraldOfThunderBuff;
						continue;
						end_IL_0091:
						break;
					}
					continue;
				}
				goto IL_00ee;
				IL_00ee:
				return HasArcticArmourBuff;
				continue;
				end_IL_00ba:
				break;
			}
		}
		switch (@enum)
		{
		case ActiveSkillsEnum.aspect_cat:
			goto IL_0122;
		case ActiveSkillsEnum.aspect_bird:
			goto IL_0129;
		case ActiveSkillsEnum.aspect_spider:
			goto IL_0130;
		case ActiveSkillsEnum.aspect_crab:
			goto IL_0137;
		}
		goto IL_0111;
		IL_0111:
		if (@enum != ActiveSkillsEnum.skitterbots)
		{
			goto IL_0119;
		}
		goto IL_011b;
		IL_0119:
		return false;
		IL_0129:
		return HasAspectBirdBuff;
		IL_0130:
		return HasAspectSpiderBuff;
		IL_0122:
		return HasAspectCatBuff;
		IL_0137:
		return HasAspectCrabBuff;
		IL_011b:
		return HasSkitterbotsBuff;
	}

	public bool HasCurseFrom(ActiveSkillsEnum @enum)
	{
		if (@enum <= ActiveSkillsEnum.lightning_weakness)
		{
			uint num = default(uint);
			while (true)
			{
				switch (@enum)
				{
				case ActiveSkillsEnum.temporal_chains:
					goto IL_0107;
				case ActiveSkillsEnum.elemental_weakness:
					goto IL_010e;
				case ActiveSkillsEnum.warlords_mark:
					goto IL_0115;
				case ActiveSkillsEnum.punishment:
					goto IL_011c;
				case ActiveSkillsEnum.enfeeble:
					goto IL_0123;
				case ActiveSkillsEnum.assassins_mark:
					goto IL_012a;
				case ActiveSkillsEnum.projectile_weakness:
					goto IL_0131;
				case ActiveSkillsEnum.vulnerability:
					goto IL_0138;
				}
				int num2 = (int)(num * 195422356) ^ -652681282;
				while (true)
				{
					switch ((num = (uint)num2 ^ 0x9968F811u) % 23u)
					{
					case 20u:
						switch (@enum)
						{
						case ActiveSkillsEnum.fire_weakness:
							goto IL_00f2;
						case ActiveSkillsEnum.cold_weakness:
							goto IL_00f9;
						case ActiveSkillsEnum.lightning_weakness:
							goto IL_0100;
						}
						num2 = ((int)num * -1309424133) ^ -711045310;
						continue;
					case 10u:
						num2 = (int)(num * 208472564) ^ -686098681;
						continue;
					case 5u:
					case 8u:
						break;
					case 19u:
						goto IL_00f2;
					case 14u:
						goto IL_00f9;
					case 17u:
						goto IL_0100;
					case 16u:
						goto IL_0107;
					case 3u:
						goto IL_010e;
					case 2u:
						goto IL_0115;
					case 12u:
						goto IL_011c;
					case 11u:
						goto IL_0123;
					case 1u:
						goto IL_012a;
					case 9u:
						goto IL_0131;
					case 18u:
						goto IL_0138;
					case 6u:
						goto end_IL_00c4;
					case 7u:
						goto IL_0147;
					case 4u:
						goto IL_014e;
					case 21u:
						goto IL_0156;
					case 22u:
						goto IL_015d;
					case 15u:
						goto IL_0165;
					default:
						goto IL_016c;
						IL_0100:
						return IsCursedWithConductivity;
						IL_00f9:
						return IsCursedWithFrostbite;
						IL_00f2:
						return IsCursedWithFlammability;
					}
					break;
				}
				continue;
				IL_010e:
				return IsCursedWithElementalWeakness;
				IL_0107:
				return IsCursedWithTemporalChains;
				IL_0138:
				return IsCursedWithVulnerability;
				IL_0131:
				return IsCursedWithProjectileWeakness;
				IL_012a:
				return IsCursedWithAssassinsMark;
				IL_0123:
				return IsCursedWithEnfeeble;
				IL_011c:
				return IsCursedWithNewPunishment;
				IL_0115:
				return IsCursedWithWarlordsMark;
				continue;
				end_IL_00c4:
				break;
			}
		}
		if (@enum == ActiveSkillsEnum.poachers_mark)
		{
			goto IL_0147;
		}
		goto IL_014e;
		IL_0156:
		return IsCursedWithNewPunishment;
		IL_015d:
		if (@enum == ActiveSkillsEnum.despair)
		{
			goto IL_0165;
		}
		goto IL_016c;
		IL_016c:
		return false;
		IL_0165:
		return IsCursedWithDespair;
		IL_0147:
		return IsCursedWithPoachersMark;
		IL_014e:
		if (@enum == ActiveSkillsEnum.new_punishment)
		{
			goto IL_0156;
		}
		goto IL_015d;
	}

	public bool IsCursingWith(ActiveSkillsEnum @enum)
	{
		if (@enum <= ActiveSkillsEnum.lightning_weakness)
		{
			uint num = default(uint);
			while (true)
			{
				switch (@enum)
				{
				case ActiveSkillsEnum.temporal_chains:
					goto IL_0107;
				case ActiveSkillsEnum.elemental_weakness:
					goto IL_010e;
				case ActiveSkillsEnum.warlords_mark:
					goto IL_0115;
				case ActiveSkillsEnum.punishment:
					goto IL_011c;
				case ActiveSkillsEnum.enfeeble:
					goto IL_0123;
				case ActiveSkillsEnum.assassins_mark:
					goto IL_012a;
				case ActiveSkillsEnum.projectile_weakness:
					goto IL_0131;
				case ActiveSkillsEnum.vulnerability:
					goto IL_0138;
				}
				int num2 = (int)(num * 1196686824) ^ -345288808;
				while (true)
				{
					switch ((num = (uint)num2 ^ 0xC10FEBC8u) % 23u)
					{
					case 20u:
						num2 = ((int)num * -600645374) ^ -1557367440;
						continue;
					case 18u:
						switch (@enum)
						{
						case ActiveSkillsEnum.fire_weakness:
							goto IL_00f2;
						case ActiveSkillsEnum.cold_weakness:
							goto IL_00f9;
						case ActiveSkillsEnum.lightning_weakness:
							goto IL_0100;
						}
						num2 = ((int)num * -1899705692) ^ -25070968;
						continue;
					case 15u:
					case 19u:
						break;
					case 8u:
						goto IL_00f2;
					case 5u:
						goto IL_00f9;
					case 6u:
						goto IL_0100;
					case 11u:
						goto IL_0107;
					case 2u:
						goto IL_010e;
					case 22u:
						goto IL_0115;
					case 9u:
						goto IL_011c;
					case 10u:
						goto IL_0123;
					case 12u:
						goto IL_012a;
					case 1u:
						goto IL_0131;
					case 16u:
						goto IL_0138;
					case 7u:
						goto end_IL_00c4;
					case 14u:
						goto IL_0147;
					case 13u:
						goto IL_014f;
					default:
						goto IL_0157;
					case 17u:
						goto IL_0159;
					case 21u:
						goto IL_0160;
					case 4u:
						goto IL_0167;
						IL_0100:
						return IsCursingWithConductivity;
						IL_00f9:
						return IsCursingWithFrostbite;
						IL_00f2:
						return IsCursingWithFlammability;
					}
					break;
				}
				continue;
				IL_010e:
				return IsCursingWithElementalWeakness;
				IL_0107:
				return IsCursingWithTemporalChains;
				IL_0138:
				return IsCursingWithVulnerability;
				IL_0131:
				return IsCursingWithProjectileWeakness;
				IL_012a:
				return IsCursingWithAssassinsMark;
				IL_0123:
				return IsCursingWithEnfeeble;
				IL_011c:
				return IsCursingWithNewPunishment;
				IL_0115:
				return IsCursingWithWarlordsMark;
				continue;
				end_IL_00c4:
				break;
			}
		}
		if (@enum != ActiveSkillsEnum.poachers_mark)
		{
			goto IL_0147;
		}
		goto IL_0167;
		IL_0160:
		return IsCursingWithNewPunishment;
		IL_0157:
		return false;
		IL_0159:
		return IsCursingWithDespair;
		IL_0147:
		if (@enum != ActiveSkillsEnum.new_punishment)
		{
			goto IL_014f;
		}
		goto IL_0160;
		IL_0167:
		return IsCursingWithPoachersMark;
		IL_014f:
		if (@enum != ActiveSkillsEnum.despair)
		{
			goto IL_0157;
		}
		goto IL_0159;
	}

	public bool HasBuffFromSelf(BuffDefinitionsEnum @enum)
	{
		return GetBuffs(@enum).FirstOrDefault((Aura x) => x.OwnerId == base.Id) != null;
	}

	public bool HasBuffFromOther(BuffDefinitionsEnum @enum)
	{
		return GetBuffs(@enum).FirstOrDefault((Aura x) => x.OwnerId != base.Id) != null;
	}

	public IEnumerable<Aura> GetBuffs(BuffDefinitionsEnum @enum)
	{
		return Auras.Where((Aura x) => x.InternalName == @enum.ToString() && x.TimeLeft.TotalMilliseconds > 0.0);
	}

	public Aura GetBuff(BuffDefinitionsEnum @enum)
	{
		return Auras.FirstOrDefault((Aura x) => x.InternalName == @enum.ToString() && x.TimeLeft.TotalMilliseconds > 0.0);
	}

	public bool HasBuff(BuffDefinitionsEnum @enum)
	{
		return GetBuff(@enum) != null;
	}

	public IEnumerable<Skill> GetSkills(ActiveSkillsEnum @enum)
	{
		return AvailableSkills.Where((Skill x) => x.InternalId == @enum.ToString());
	}

	public Skill GetSkill(ActiveSkillsEnum @enum)
	{
		return AvailableSkills.FirstOrDefault((Skill x) => x.InternalId == @enum.ToString());
	}

	public bool HasSkill(ActiveSkillsEnum @enum)
	{
		return GetSkill(@enum) != null;
	}
}
