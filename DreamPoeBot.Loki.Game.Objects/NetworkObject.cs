using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using DreamPoeBot.Structures.ns19;
using log4net;

namespace DreamPoeBot.Loki.Game.Objects;

public class NetworkObject : IEquatable<NetworkObject>
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct105
	{
		public IntPtr Struct133_intptr_0;

		public NativeVector Struct133_nativeVector_0;

		public NativeVector nativeVector_0;

		public IntPtr intptr_0;

		public int int_0;

		public byte byte_0;

		internal byte byte_1;

		internal byte byte_2;

		internal byte byte_3;

		public uint uint_0;

		public IntPtr intptr_1;

		public IntPtr intptr_2;

		public IntPtr intptr_3;

		internal Struct252 struct252_0;

		internal Struct252 struct252_1;

		internal Struct252 struct252_2;
	}

	private bool? nullable_99_ArchnemesisIsTrapped;

	private static readonly ILog ilog_0;

	private int? nullable_0;

	private bool? nullable_1;

	private string name;

	private Positioned positionedComponent_0;

	private string string_1;

	private bool? nullable_2;

	private bool? nullable_3;

	private bool? nullable_4;

	private bool? nullable_5;

	private bool? nullable_6;

	private bool? nullable_7;

	private bool? nullable_8;

	private bool? nullable_9;

	private bool? nullable_10;

	private bool? nullable_11;

	private bool? nullable_12;

	private bool? nullable_13;

	private bool? nullable_14;

	private bool? nullable_15;

	private bool? nullable_16;

	private bool? nullable_17;

	private bool? nullable_18;

	private bool? nullable_19;

	private bool? nullable_20;

	private bool? nullable_21;

	private bool? nullable_22_IsAflictionInitiator;

	private bool? nullable_IsLegionInitiator;

	private PerFrameCachedValue<bool> perFrameCachedValue_1;

	private PerFrameCachedValue<bool> perFrameCachedValue_2;

	private SlowCacheValue<EntityComponentInformation> PFVEntityComponentInformation;

	private PerFrameCachedValue<Reaction> perFrameCachedValue_4;

	public EntityWrapper _entity { get; set; }

	public EntityWrapper Entity => _entity;

	public string AnimatedPropertiesMetadata
	{
		get
		{
			Animated component = _entity.GetComponent<Animated>();
			if (component == null)
			{
				return string.Empty;
			}
			return component.BaseAnimatedObjectEntity.Metadata;
		}
	}

	public bool BaseHashChanged => false;

	public int CharacterSize
	{
		get
		{
			if (!nullable_0.HasValue)
			{
				Positioned positioned = PositionedComponent_0;
				if (positioned == null)
				{
					nullable_0 = 0;
				}
				else
				{
					nullable_0 = positioned.CharacterSize;
				}
			}
			return nullable_0.Value;
		}
	}

	public Vector2i Position => new Vector2i(_entity.PositionedComp.GridX, _entity.PositionedComp.GridY);

	public Vector2 WorldPosition => new Vector2(_entity.PositionedComp.WorldX, _entity.PositionedComp.WorldY);

	public float Distance => LokiPoe.LocalData.MyPosition.Distance(Position);

	public float DistanceSqr => LokiPoe.LocalData.MyPosition.DistanceSqr(Position);

	public bool HasNpcFloatingIcon
	{
		get
		{
			NPC component = _entity.GetComponent<NPC>();
			if (component == null)
			{
				return false;
			}
			return component.HasIconOverHead;
		}
	}

	public int Id => _entity.Id;

	public Vector3 InteractCenterWorld
	{
		get
		{
			Render component = _entity.GetComponent<Render>();
			if (!(component == null))
			{
				return component.InteractCenterWorld;
			}
			return Vector3.Zero;
		}
	}

	public bool IsAbyssCrackSpawner
	{
		get
		{
			if (!nullable_17.HasValue)
			{
				nullable_17 = Metadata.Contains(global::_003CModule_003E.smethod_8<string>(4216673439u));
			}
			return nullable_17.Value;
		}
	}

	public bool IsAbyssFinalNodeChest
	{
		get
		{
			if (!nullable_16.HasValue)
			{
				string type = Type;
				nullable_16 = type.Equals(global::_003CModule_003E.smethod_6<string>(3605020117u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_6<string>(1867390792u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_6<string>(129761467u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_8<string>(782780664u), StringComparison.OrdinalIgnoreCase);
			}
			return nullable_16.Value;
		}
	}

	public bool IsAbyssFinalNodeSubArea
	{
		get
		{
			if (!nullable_18.HasValue)
			{
				nullable_18 = Metadata.Contains(global::_003CModule_003E.smethod_7<string>(2352826097u));
			}
			return nullable_18.Value;
		}
	}

	public bool IsAbyssNodeLarge
	{
		get
		{
			if (!nullable_15.HasValue)
			{
				nullable_15 = Type.Equals(global::_003CModule_003E.smethod_9<string>(3021082339u), StringComparison.OrdinalIgnoreCase);
			}
			return nullable_15.Value;
		}
	}

	public bool IsAbyssNodeSmall
	{
		get
		{
			if (!nullable_14.HasValue)
			{
				nullable_14 = Type.Equals(global::_003CModule_003E.smethod_7<string>(3170379435u), StringComparison.OrdinalIgnoreCase);
			}
			return nullable_14.Value;
		}
	}

	public bool IsAbyssStartNode
	{
		get
		{
			if (!nullable_12.HasValue)
			{
				nullable_12 = Type.Equals(global::_003CModule_003E.smethod_6<string>(2015821709u), StringComparison.OrdinalIgnoreCase);
			}
			return nullable_12.Value;
		}
	}

	public bool IsAbyssNodeMini
	{
		get
		{
			if (!nullable_13.HasValue)
			{
				nullable_13 = Type.Equals(global::_003CModule_003E.smethod_5<string>(3250757236u), StringComparison.OrdinalIgnoreCase);
			}
			return nullable_13.Value;
		}
	}

	public bool IsLegionInitiator
	{
		get
		{
			if (!nullable_IsLegionInitiator.HasValue)
			{
				nullable_IsLegionInitiator = Metadata.Contains(global::_003CModule_003E.smethod_9<string>(278720427u));
			}
			return nullable_IsLegionInitiator.Value;
		}
	}

	public bool IsBeyondPortal
	{
		get
		{
			if (!nullable_10.HasValue)
			{
				nullable_10 = Type.Contains(global::_003CModule_003E.smethod_5<string>(788729378u));
			}
			return nullable_10.Value;
		}
	}

	public bool IsBlightDefensiveTower
	{
		get
		{
			if (!nullable_20.HasValue)
			{
				nullable_20 = Components.BlightTowerComponent != null;
			}
			return nullable_20.Value;
		}
	}

	public bool IsUltimatumChallengeInteractable
	{
		get
		{
			if (!nullable_21.HasValue)
			{
				nullable_21 = Type.Equals(global::_003CModule_003E.smethod_6<string>(2486223902u), StringComparison.OrdinalIgnoreCase);
			}
			return nullable_21.Value;
		}
	}

	public bool ArchnemesisIsTrapped
	{
		get
		{
			if (!nullable_99_ArchnemesisIsTrapped.HasValue)
			{
				nullable_99_ArchnemesisIsTrapped = Components.StatsComponent != null && Components.StatsComponent.GetStat(StatTypeGGG.ArchnemesisIsTrapped) > 0;
			}
			return nullable_99_ArchnemesisIsTrapped.Value;
		}
	}

	public bool IsAflictionInitiator
	{
		get
		{
			if (!nullable_22_IsAflictionInitiator.HasValue)
			{
				nullable_22_IsAflictionInitiator = Type.Contains(global::_003CModule_003E.smethod_9<string>(2006065700u)) && Type.Contains(global::_003CModule_003E.smethod_9<string>(1501899650u));
			}
			return nullable_22_IsAflictionInitiator.Value;
		}
	}

	public bool IsBreach
	{
		get
		{
			if (!nullable_11.HasValue)
			{
				nullable_11 = Type.Equals(global::_003CModule_003E.smethod_5<string>(2212240296u), StringComparison.OrdinalIgnoreCase);
			}
			return nullable_11.Value;
		}
	}

	public bool IsDoor
	{
		get
		{
			if (!nullable_7.HasValue)
			{
				nullable_7 = Metadata.Contains(global::_003CModule_003E.smethod_6<string>(1171003621u)) || Name.Equals(global::_003CModule_003E.smethod_5<string>(338890247u));
			}
			return nullable_7.Value;
		}
	}

	public bool IsGoldenDoor
	{
		get
		{
			if (!nullable_2.HasValue)
			{
				nullable_2 = Metadata.Equals(global::_003CModule_003E.smethod_8<string>(2424475468u), StringComparison.OrdinalIgnoreCase);
			}
			return nullable_2.Value;
		}
	}

	public bool IsSilverDoor
	{
		get
		{
			if (!nullable_3.HasValue)
			{
				nullable_3 = Metadata.Equals(global::_003CModule_003E.smethod_6<string>(3379035139u), StringComparison.OrdinalIgnoreCase);
			}
			return nullable_3.Value;
		}
	}

	public bool IsHiddenDoor
	{
		get
		{
			if (!nullable_4.HasValue)
			{
				nullable_4 = Metadata.Equals(global::_003CModule_003E.smethod_6<string>(3205494780u), StringComparison.OrdinalIgnoreCase);
			}
			return nullable_4.Value;
		}
	}

	public bool IsHiddenDoorSwitch
	{
		get
		{
			if (!nullable_8.HasValue)
			{
				nullable_8 = Metadata.Equals(global::_003CModule_003E.smethod_5<string>(1842792305u), StringComparison.OrdinalIgnoreCase);
			}
			return nullable_8.Value;
		}
	}

	public bool IsHighlightable
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<bool>(method_3);
			}
			return perFrameCachedValue_1;
		}
	}

	public bool IsIgnoreHidden
	{
		get
		{
			NPC component = _entity.GetComponent<NPC>();
			if (component == null)
			{
				return false;
			}
			return component.IsIgnoreHidden;
		}
	}

	public bool IsLockedDoor
	{
		get
		{
			if (!nullable_5.HasValue)
			{
				nullable_5 = Metadata.Equals(global::_003CModule_003E.smethod_6<string>(1294325096u), StringComparison.OrdinalIgnoreCase) || Metadata.Equals(global::_003CModule_003E.smethod_8<string>(4040854058u), StringComparison.OrdinalIgnoreCase) || Metadata.Equals(global::_003CModule_003E.smethod_5<string>(2440788751u), StringComparison.OrdinalIgnoreCase);
			}
			return nullable_5.Value;
		}
	}

	public bool IsMaster
	{
		get
		{
			if (!nullable_19.HasValue)
			{
				string type = Type;
				nullable_19 = type.Equals(global::_003CModule_003E.smethod_7<string>(225151824u)) || type.Equals(global::_003CModule_003E.smethod_5<string>(1298055315u)) || type.Equals(global::_003CModule_003E.smethod_5<string>(2361436879u)) || type.Equals(global::_003CModule_003E.smethod_7<string>(3330237052u)) || type.Equals(global::_003CModule_003E.smethod_7<string>(4249822051u)) || type.Equals(global::_003CModule_003E.smethod_6<string>(2933888139u)) || type.Equals(global::_003CModule_003E.smethod_5<string>(2873029876u)) || type.Equals(global::_003CModule_003E.smethod_5<string>(2174329464u)) || type.Equals(global::_003CModule_003E.smethod_6<string>(209687014u)) || type.Equals(global::_003CModule_003E.smethod_7<string>(4010748201u)) || type.Equals(global::_003CModule_003E.smethod_5<string>(1044642236u)) || type.Equals(global::_003CModule_003E.smethod_7<string>(2884270845u)) || type.Equals(global::_003CModule_003E.smethod_6<string>(2958997581u)) || type.Equals(global::_003CModule_003E.smethod_5<string>(197999550u)) || type.Equals(global::_003CModule_003E.smethod_9<string>(1701795922u)) || type.Equals(global::_003CModule_003E.smethod_8<string>(2619973126u)) || type.Equals(global::_003CModule_003E.smethod_6<string>(360343666u)) || type.Equals(global::_003CModule_003E.smethod_8<string>(3548308342u)) || type.Equals(global::_003CModule_003E.smethod_8<string>(527092066u)) || type.Equals(global::_003CModule_003E.smethod_7<string>(986704180u)) || type.Equals(global::_003CModule_003E.smethod_6<string>(307899047u)) || type.Equals(global::_003CModule_003E.smethod_6<string>(4274217862u)) || type.Equals(global::_003CModule_003E.smethod_6<string>(1072937339u));
			}
			return nullable_19.Value;
		}
	}

	public bool IsLabyrinthRollerTrap
	{
		get
		{
			if (!nullable_6.HasValue)
			{
				nullable_6 = Metadata.Contains(global::_003CModule_003E.smethod_5<string>(2415924127u));
			}
			return nullable_6.Value;
		}
	}

	public bool IsMinimapLabelVisible
	{
		get
		{
			NPC component = _entity.GetComponent<NPC>();
			if (!(component == null))
			{
				return component.IsMinimapLabelVisible;
			}
			return false;
		}
	}

	public bool IsMysteriousDarkshrine
	{
		get
		{
			if (!nullable_9.HasValue)
			{
				nullable_9 = Metadata.Equals(global::_003CModule_003E.smethod_8<string>(1150724448u), StringComparison.OrdinalIgnoreCase);
			}
			return nullable_9.Value;
		}
	}

	public bool IsTargetable
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<bool>(method_4);
			}
			return perFrameCachedValue_2;
		}
	}

	public bool IsValid
	{
		get
		{
			if (_entity.Address <= 0L)
			{
				return false;
			}
			if (!LokiPoe.Memory.IsValidAddress(_entity.Address))
			{
				return false;
			}
			return true;
		}
	}

	public bool HasHull
	{
		get
		{
			if (!nullable_1.HasValue)
			{
				Animated component = Entity.GetComponent<Animated>();
				if (component == null)
				{
					nullable_1 = false;
					return nullable_1.Value;
				}
				EntityWrapper baseAnimatedObjectEntity = component.BaseAnimatedObjectEntity;
				if (baseAnimatedObjectEntity == null)
				{
					nullable_1 = false;
					return nullable_1.Value;
				}
				nullable_1 = baseAnimatedObjectEntity.HasComponent<Hull>();
			}
			return nullable_1.Value;
		}
	}

	public Hull Hull
	{
		get
		{
			Animated component = Entity.GetComponent<Animated>();
			if (component == null)
			{
				nullable_1 = false;
				return null;
			}
			EntityWrapper baseAnimatedObjectEntity = component.BaseAnimatedObjectEntity;
			if (!(baseAnimatedObjectEntity == null))
			{
				return baseAnimatedObjectEntity.GetComponent<Hull>();
			}
			nullable_1 = false;
			return null;
		}
	}

	public string Metadata
	{
		get
		{
			if (string_1 == null)
			{
				string_1 = Type;
				int num = string_1.IndexOf(global::_003CModule_003E.smethod_5<string>(3319132597u), StringComparison.Ordinal);
				if (num != -1)
				{
					string_1 = string_1.Substring(0, num);
				}
			}
			return string_1;
		}
	}

	public virtual string Name
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(name))
			{
				return name;
			}
			try
			{
				DreamPoeBot.Loki.Components.Player playerComponent = Components.PlayerComponent;
				if (playerComponent != null)
				{
					name = playerComponent.Name;
					if (string.IsNullOrWhiteSpace(name))
					{
						name = Type;
					}
					return name;
				}
				ArchnemesisMod archnemesisModComponent = Components.ArchnemesisModComponent;
				if (archnemesisModComponent != null)
				{
					name = archnemesisModComponent.ModWrapper.DisplayName;
					if (string.IsNullOrWhiteSpace(name))
					{
						name = Type;
					}
					return name;
				}
				DreamPoeBot.Loki.Components.WorldItem worldItemComponent = Components.WorldItemComponent;
				if (worldItemComponent != null)
				{
					name = worldItemComponent.ItemEntity.Name;
					if (string.IsNullOrWhiteSpace(name))
					{
						name = Type;
					}
					return name;
				}
				DreamPoeBot.Loki.Components.Monster monsterComponent = Components.MonsterComponent;
				if (monsterComponent != null)
				{
					name = monsterComponent.MonsterName;
					if (string.IsNullOrWhiteSpace(name))
					{
						name = Type;
					}
					return name;
				}
				Render renderComponent = Components.RenderComponent;
				if (renderComponent != null)
				{
					name = renderComponent.Name;
					if (string.IsNullOrWhiteSpace(name))
					{
						name = Type;
					}
					return name;
				}
				Base baseComponent = Components.BaseComponent;
				if (baseComponent != null)
				{
					name = baseComponent.Name;
					if (string.IsNullOrWhiteSpace(name))
					{
						name = Type;
					}
					return name;
				}
				string type = Type;
				if (string.IsNullOrEmpty(type))
				{
					name = global::_003CModule_003E.smethod_6<string>(2881790184u);
				}
				else
				{
					name = type;
				}
			}
			catch (Exception ex)
			{
				ilog_0.Error((object)global::_003CModule_003E.smethod_5<string>(2955903117u), ex);
				name = global::_003CModule_003E.smethod_9<string>(32727750u);
			}
			return name;
		}
	}

	public Reaction Reaction
	{
		get
		{
			if (perFrameCachedValue_4 == null)
			{
				perFrameCachedValue_4 = new PerFrameCachedValue<Reaction>(method_7);
			}
			return perFrameCachedValue_4;
		}
	}

	public bool IsFriendly => Reaction == Reaction.Friendly;

	public bool IsHostile => Reaction == Reaction.Enemy;

	public string Type => Entity.Metadata;

	public float WorldDistance => LokiPoe.LocalData.MyWorldPosition.Distance(WorldPosition);

	public float WorldDistanceSqr => LokiPoe.LocalData.MyWorldPosition.DistanceSqr(WorldPosition);

	public EntityComponentInformation Components
	{
		get
		{
			if (PFVEntityComponentInformation == null)
			{
				PFVEntityComponentInformation = new SlowCacheValue<EntityComponentInformation>(CacheComponents);
			}
			return PFVEntityComponentInformation;
		}
	}

	internal Positioned PositionedComponent_0
	{
		get
		{
			if (positionedComponent_0 == null)
			{
				if (Entity.PositionedComp.Address == 0L)
				{
					return null;
				}
				positionedComponent_0 = Entity.PositionedComp;
			}
			positionedComponent_0.UpdatePointer(Entity.PositionedComp.Address);
			if (positionedComponent_0.Address == 0L)
			{
				return null;
			}
			return positionedComponent_0;
		}
	}

	public override int GetHashCode()
	{
		if (!(_entity != null))
		{
			return 0;
		}
		return _entity.GetHashCode();
	}

	static NetworkObject()
	{
		ilog_0 = Logger.GetLoggerInstanceForType();
	}

	public NetworkObject(EntityWrapper entity)
	{
		_entity = entity;
	}

	public NetworkObject(Entity player)
	{
		EntityWrapper entity = new EntityWrapper(player.Address);
		_entity = entity;
	}

	public NetworkObject(long address)
	{
		EntityWrapper entity = new EntityWrapper(address);
		_entity = entity;
	}

	public string Dump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1576371454u)));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(1500770874u), Entity.Address));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(2545156825u), Id));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3375923685u), Name));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(894301046u), Metadata));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(3856114537u), Position, Distance));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3316856698u), Type));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(176647456u), GetType()));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(951695848u), Reaction));
		if (Components.ActorComponent != null && Components.ActorComponent.HasCurrentAction)
		{
			Skill skill = ((!(Components.ActorComponent.CurrentAction?.Skill != null)) ? null : Components.ActorComponent.CurrentAction?.Skill);
			if (skill != null)
			{
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(3483924377u), skill.Name, skill.InternalName));
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3973076802u), skill.CastTime));
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3832774952u), skill.IsOnCooldown));
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(1595638400u), Components.ActorComponent.CurrentAction.Destination.ToString()));
				if (Components.ActorComponent.CurrentAction.Target != null)
				{
					stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(1028056981u), Components.ActorComponent.CurrentAction.Target.Name, Components.ActorComponent.CurrentAction.Target.Id));
				}
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(3666565583u)));
				foreach (KeyValuePair<StatTypeGGG, int> stat in skill.Stats)
				{
					stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(1290928402u), stat.Key.ToString(), stat.Value));
				}
			}
			else
			{
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(1815168970u)));
			}
		}
		ObjectMagicProperties objectMagicPropertiesComponent = Components.ObjectMagicPropertiesComponent;
		if (objectMagicPropertiesComponent != null)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(3323770344u), objectMagicPropertiesComponent.Rarity));
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(1097143632u), AnimatedPropertiesMetadata));
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(57188765u)));
		EntityComponentInformation components = Components;
		foreach (KeyValuePair<string, long> component in components.GetComponents())
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(3408596051u), component.Key, component.Value));
			if (component.Key == global::_003CModule_003E.smethod_9<string>(4190785250u))
			{
				foreach (StateMachine.StageState stageState in Components.StateMachineComponent.StageStates)
				{
					stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1784534038u), stageState.Name, stageState.IsActive));
				}
			}
			if (component.Key == global::_003CModule_003E.smethod_5<string>(380331287u))
			{
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(2057009666u), Components.TargetableComponent.CanHighlight, Components.TargetableComponent.CanTarget, Components.TargetableComponent.IsTargeted));
			}
			if (component.Key == global::_003CModule_003E.smethod_6<string>(1769178759u))
			{
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(6439992u), Components.TransitionableComponent.Flag1, Components.TransitionableComponent.Flag2, Components.TransitionableComponent.Flag3));
			}
			if (component.Key == global::_003CModule_003E.smethod_8<string>(2414070159u))
			{
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(2819604294u), Components.AreaTransitionComponent.Destination.Name, Components.AreaTransitionComponent.TransitionType.ToString()));
			}
		}
		stringBuilder.AppendLine();
		if (Components.PlayerComponent != null)
		{
			stringBuilder.AppendLine(Components.PlayerComponent.ToString());
		}
		if (Components.LifeComponent != null)
		{
			stringBuilder.AppendLine(Components.LifeComponent.ToString());
		}
		if (Components.StatsComponent != null)
		{
			stringBuilder.AppendLine(Components.StatsComponent.ToString());
		}
		if (objectMagicPropertiesComponent != null)
		{
			stringBuilder.AppendLine(objectMagicPropertiesComponent.ToString());
		}
		return stringBuilder.ToString();
	}

	private bool method_3()
	{
		Targetable component = Entity.GetComponent<Targetable>();
		if (!(component != null))
		{
			return false;
		}
		return component.CanHighlight;
	}

	private bool method_4()
	{
		Targetable component = Entity.GetComponent<Targetable>();
		if (!(component != null))
		{
			return false;
		}
		return component.CanTarget;
	}

	private Reaction method_7()
	{
		if (IsIgnoreHidden)
		{
			return Reaction.Npc;
		}
		if (!(Components.ActorComponent != null))
		{
			return Reaction.NonActor;
		}
		Positioned positioned = PositionedComponent_0;
		if (positioned == null)
		{
			return Reaction.Unset;
		}
		int num = LokiPoe.LocalData.MyReaction & 0x7F;
		int num2 = positioned.Reaction & 0x7F;
		if (num != num2)
		{
			return Reaction.Enemy;
		}
		return Reaction.Friendly;
	}

	private EntityComponentInformation CacheComponents()
	{
		return new EntityComponentInformation(_entity);
	}

	public bool Equals(NetworkObject other)
	{
		if (object.Equals(other, null))
		{
			return false;
		}
		return Entity.Address == other.Entity.Address;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj.GetType() != GetType()))
			{
				return Equals((NetworkObject)obj);
			}
			return false;
		}
		return false;
	}

	public static bool operator !=(NetworkObject left, NetworkObject right)
	{
		return !object.Equals(left, right);
	}

	internal NetworkObject ConvertNetworkObject()
	{
		if (!(_entity == null) && _entity.Address != 0L)
		{
			if (_entity.Address == LokiPoe.LocalData.MePtr)
			{
				return new LocalPlayer(_entity);
			}
			if (!IsUltimatumChallengeInteractable)
			{
				if (Components.BlightTowerComponent != null)
				{
					return new BlightDefensiveTower(this);
				}
				if (Metadata.StartsWith(global::_003CModule_003E.smethod_6<string>(821697168u)))
				{
					return new HeistInteractableDoor(this);
				}
				if (!Metadata.StartsWith(global::_003CModule_003E.smethod_7<string>(3977220871u)) && !Metadata.StartsWith(global::_003CModule_003E.smethod_8<string>(3586556323u)))
				{
					if (Metadata == global::_003CModule_003E.smethod_9<string>(4023671775u))
					{
						return new HarvestExtraxtor(_entity);
					}
					if (Metadata == global::_003CModule_003E.smethod_9<string>(3680876536u))
					{
						return new HarvestIrrigator(_entity);
					}
					if (!IsAflictionInitiator)
					{
						if (Components.MonsterComponent != null)
						{
							if (!ArchnemesisIsTrapped)
							{
								return new Monster(_entity);
							}
							return new ArchnemesisTrappedMonster(new Monster(_entity));
						}
						if (!(Components.WorldItemComponent != null))
						{
							if (!(Components.ChestComponent != null))
							{
								if (!(Components.NpcComponent != null))
								{
									if (!(Components.PlayerComponent != null))
									{
										if (!(Components.AreaTransitionComponent != null))
										{
											if (Components.TriggerableBlockageComponent != null && !IsAbyssNodeSmall && !IsAbyssFinalNodeChest && !IsAbyssFinalNodeSubArea && !IsAbyssNodeLarge)
											{
												return new TriggerableBlockage(_entity);
											}
											if (Components.PortalComponent != null)
											{
												return new Portal(_entity);
											}
											if (Components.ActorComponent != null)
											{
												return new Actor(_entity);
											}
											if (Components.ShrineComponent != null)
											{
												return new Shrine(_entity);
											}
											if (Components.ProjectileComponent != null)
											{
												return new Projectile(this);
											}
											string type = Type;
											if (type.Contains(global::_003CModule_003E.smethod_7<string>(78880931u)))
											{
												return new ExpeditionPlacementIndicator(this);
											}
											if (type.Contains(global::_003CModule_003E.smethod_8<string>(1159735640u)))
											{
												return new CraftingRecipe(_entity);
											}
											if (type.Equals(global::_003CModule_003E.smethod_7<string>(367293632u), StringComparison.OrdinalIgnoreCase))
											{
												return new ServerEffect(this);
											}
											if (!type.Equals(global::_003CModule_003E.smethod_6<string>(1639180079u), StringComparison.OrdinalIgnoreCase))
											{
												if (type.Equals(global::_003CModule_003E.smethod_5<string>(3969555433u), StringComparison.OrdinalIgnoreCase))
												{
													return new DarkShrine(this);
												}
												if (type.Equals(global::_003CModule_003E.smethod_5<string>(1817927681u), StringComparison.OrdinalIgnoreCase))
												{
													return new Waypoint(_entity);
												}
												if (type.Equals(global::_003CModule_003E.smethod_7<string>(2205984493u), StringComparison.OrdinalIgnoreCase))
												{
													return new Stash(_entity);
												}
												if (!type.Equals(global::_003CModule_003E.smethod_5<string>(3068416660u), StringComparison.OrdinalIgnoreCase))
												{
													if (!type.Equals(global::_003CModule_003E.smethod_5<string>(1735045601u), StringComparison.OrdinalIgnoreCase))
													{
														if (!IsBeyondPortal)
														{
															if (IsBreach)
															{
																return new Breach(this);
															}
															if (IsAbyssNodeMini)
															{
																return new AbyssNodeMini(this);
															}
															if (!IsAbyssStartNode)
															{
																if (IsAbyssNodeSmall)
																{
																	return new AbyssNodeSmall(this);
																}
																if (!IsAbyssNodeLarge)
																{
																	if (!IsAbyssFinalNodeChest)
																	{
																		if (IsAbyssCrackSpawner)
																		{
																			return new AbyssCrackSpawner(this);
																		}
																		if (!IsAbyssFinalNodeSubArea)
																		{
																			if (!IsLegionInitiator)
																			{
																				if (!type.Equals(global::_003CModule_003E.smethod_5<string>(1440191482u), StringComparison.OrdinalIgnoreCase))
																				{
																					if (!type.Equals(global::_003CModule_003E.smethod_9<string>(4231834359u), StringComparison.OrdinalIgnoreCase))
																					{
																						if (!type.Equals(global::_003CModule_003E.smethod_8<string>(1718409710u), StringComparison.OrdinalIgnoreCase))
																						{
																							if (type.Contains(global::_003CModule_003E.smethod_5<string>(148261463u)))
																							{
																								if (type.Equals(global::_003CModule_003E.smethod_6<string>(1091223825u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_8<string>(2075948185u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_8<string>(3878551465u), StringComparison.OrdinalIgnoreCase))
																								{
																									return new GroundBlindSmoke(this);
																								}
																								if (type.Equals(global::_003CModule_003E.smethod_8<string>(163068857u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_8<string>(918372926u), StringComparison.OrdinalIgnoreCase))
																								{
																									return new GroundEvil(this);
																								}
																								if (type.Equals(global::_003CModule_003E.smethod_6<string>(3771883271u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_6<string>(3399693111u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_5<string>(4115221808u), StringComparison.OrdinalIgnoreCase))
																								{
																									return new GroundEvilRed(this);
																								}
																								if (type.Equals(global::_003CModule_003E.smethod_9<string>(2383225509u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_8<string>(42387500u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_9<string>(3250240415u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_5<string>(73667591u), StringComparison.OrdinalIgnoreCase))
																								{
																									return new GroundFire(this);
																								}
																								if (type.Equals(global::_003CModule_003E.smethod_8<string>(3319877395u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_8<string>(177979762u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_6<string>(3646336061u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_6<string>(3322139050u), StringComparison.OrdinalIgnoreCase))
																								{
																									return new GroundFireWhite(this);
																								}
																								if (type.Equals(global::_003CModule_003E.smethod_5<string>(4057204352u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_6<string>(2577758730u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_5<string>(2428979174u), StringComparison.OrdinalIgnoreCase))
																								{
																									return new GroundHoly(this);
																								}
																								if (type.Equals(global::_003CModule_003E.smethod_8<string>(2403664850u), StringComparison.OrdinalIgnoreCase))
																								{
																									return new GroundIce(this);
																								}
																								if (type.Equals(global::_003CModule_003E.smethod_9<string>(3228303048u), StringComparison.OrdinalIgnoreCase))
																								{
																									return new GroundLightning(this);
																								}
																								if (type.Equals(global::_003CModule_003E.smethod_5<string>(2877787876u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_7<string>(1976447596u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_7<string>(2661487653u), StringComparison.OrdinalIgnoreCase))
																								{
																									return new GroundPoison(this);
																								}
																								if (type.Equals(global::_003CModule_003E.smethod_9<string>(2388026298u), StringComparison.OrdinalIgnoreCase))
																								{
																									return new GroundSpike(this);
																								}
																								if (type.Equals(global::_003CModule_003E.smethod_8<string>(4107791508u), StringComparison.OrdinalIgnoreCase))
																								{
																									return new GroundTar(this);
																								}
																								if (type.Equals(global::_003CModule_003E.smethod_7<string>(1787191734u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_7<string>(2179290182u), StringComparison.OrdinalIgnoreCase) || type.Equals(global::_003CModule_003E.smethod_6<string>(3096154072u), StringComparison.OrdinalIgnoreCase))
																								{
																									return new GroundVaalCloud(this);
																								}
																							}
																							if (type.Equals(global::_003CModule_003E.smethod_9<string>(2569450726u), StringComparison.OrdinalIgnoreCase))
																							{
																								return new WaterGeyser(this);
																							}
																							if (type.Equals(global::_003CModule_003E.smethod_7<string>(3427568917u), StringComparison.OrdinalIgnoreCase))
																							{
																								return new Arrow(this);
																							}
																							if (!type.Equals(global::_003CModule_003E.smethod_5<string>(111587262u), StringComparison.OrdinalIgnoreCase))
																							{
																								if (type.Equals(global::_003CModule_003E.smethod_6<string>(1854036382u), StringComparison.OrdinalIgnoreCase))
																								{
																									return new LightningTempestStorm(this);
																								}
																								if (type.Equals(global::_003CModule_003E.smethod_5<string>(1502975777u), StringComparison.OrdinalIgnoreCase))
																								{
																									return new FireTempestStorm(this);
																								}
																								if (!type.Equals(global::_003CModule_003E.smethod_9<string>(3288463899u), StringComparison.OrdinalIgnoreCase))
																								{
																									if (type.Contains(global::_003CModule_003E.smethod_7<string>(1386035470u)))
																									{
																										return new ColoredTempestStorm(this);
																									}
																									if (type.Equals(global::_003CModule_003E.smethod_6<string>(3144147221u), StringComparison.OrdinalIgnoreCase))
																									{
																										return new StoneAltar(this);
																									}
																									if (!type.Equals(global::_003CModule_003E.smethod_8<string>(2567361560u), StringComparison.OrdinalIgnoreCase))
																									{
																										if (type.Equals(global::_003CModule_003E.smethod_7<string>(1904464205u), StringComparison.OrdinalIgnoreCase))
																										{
																											return new LabyrinthReturnPortal(this);
																										}
																										return this;
																									}
																									return new BreachClientObject(this);
																								}
																								return new IceTempestStorm(this);
																							}
																							return new BloodPool(this);
																						}
																						return new MiniMonolith(this);
																					}
																					return new Monolith(this);
																				}
																				return new MissionMarker(this);
																			}
																			return new LegionInitiator(this);
																		}
																		return new AbyssFinalNodeSubArea(this);
																	}
																	return new AbyssFinalNodeChest(this);
																}
																return new AbyssNodeLarge(this);
															}
															return new AbyssStartNode(this);
														}
														return new BeyondPortal(this);
													}
													return new BruteDeathExplosion(this);
												}
												return new GuildStash(this);
											}
											return new Effect(this);
										}
										return new AreaTransition(_entity);
									}
									return new Player(_entity);
								}
								return new Npc(_entity);
							}
							return new Chest(_entity);
						}
						return new WorldItem(_entity);
					}
					return new AflictionInitiator(this);
				}
				return new TangleAltar(_entity);
			}
			return new UltimatumChallengeInteractable(this);
		}
		return null;
	}
}
