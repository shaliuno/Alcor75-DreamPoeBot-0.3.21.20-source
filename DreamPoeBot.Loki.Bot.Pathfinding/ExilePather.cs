using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Objects;
using log4net;

namespace DreamPoeBot.Loki.Bot.Pathfinding;

public static class ExilePather
{
	public delegate void ObstacleUpdateEvent();

	public delegate void ExilePatherReloadEvent();

	public delegate bool PlotFunction(int x, int y);

	private sealed class Class480
	{
		public Vector2i vector2i_0;

		public Vector2i vector2i_1;

		internal List<Vector2i> method_0()
		{
			Class481 @class = new Class481();
			@class.list_0 = new List<Vector2i>();
			PlotFunction plotFunction = @class.method_0;
			int gparam_ = vector2i_0.X;
			int gparam_2 = vector2i_0.Y;
			int gparam_3 = vector2i_1.X;
			int gparam_4 = vector2i_1.Y;
			bool flag;
			if (flag = Math.Abs(gparam_4 - gparam_2) > Math.Abs(gparam_3 - gparam_))
			{
				smethod_0(ref gparam_, ref gparam_2);
				smethod_0(ref gparam_3, ref gparam_4);
			}
			if (gparam_ > gparam_3)
			{
				smethod_0(ref gparam_, ref gparam_3);
				smethod_0(ref gparam_2, ref gparam_4);
			}
			int num = gparam_3 - gparam_;
			int num2 = Math.Abs(gparam_4 - gparam_2);
			int num3 = num / 2;
			int num4 = ((gparam_2 < gparam_4) ? 1 : (-1));
			int num5 = gparam_2;
			int num6 = gparam_;
			while (true)
			{
				if (num6 <= gparam_3)
				{
					if (!(flag ? plotFunction(num5, num6) : plotFunction(num6, num5)))
					{
						break;
					}
					num3 -= num2;
					if (num3 < 0)
					{
						num5 += num4;
						num3 += num;
					}
					num6++;
					continue;
				}
				if (@class.list_0[0] == vector2i_1)
				{
					@class.list_0.Reverse();
				}
				return @class.list_0;
			}
			return @class.list_0;
		}
	}

	private sealed class Class481
	{
		public List<Vector2i> list_0;

		internal bool method_0(int int_0, int int_1)
		{
			list_0.Add(new Vector2i(int_0, int_1));
			return true;
		}
	}

	private sealed class Class483
	{
		public Vector2i startPoint;

		public Vector2i endpoint;

		public CachedTerrainData cachedTerrainData_0;

		internal Tuple<bool, Vector2i> method_0(bool shouldUseFlyMap = false)
		{
			Class484 @class = new Class484();
			@class.class483_0 = this;
			@class.hitpoint = Vector2i.Zero;
			if (startPoint == endpoint)
			{
				return new Tuple<bool, Vector2i>(item1: true, @class.hitpoint);
			}
			PlotFunction plotFunction = null;
			plotFunction = (shouldUseFlyMap ? new PlotFunction(@class.CheckWalkability_Fly) : new PlotFunction(@class.CheckWalkability));
			int gparam_ = startPoint.X;
			int gparam_2 = startPoint.Y;
			int gparam_3 = endpoint.X;
			int gparam_4 = endpoint.Y;
			bool flag;
			if (flag = Math.Abs(gparam_4 - gparam_2) > Math.Abs(gparam_3 - gparam_))
			{
				smethod_0(ref gparam_, ref gparam_2);
				smethod_0(ref gparam_3, ref gparam_4);
			}
			if (gparam_ > gparam_3)
			{
				smethod_0(ref gparam_, ref gparam_3);
				smethod_0(ref gparam_2, ref gparam_4);
			}
			int num = gparam_3 - gparam_;
			int num2 = Math.Abs(gparam_4 - gparam_2);
			int num3 = num / 2;
			int num4 = ((gparam_2 < gparam_4) ? 1 : (-1));
			int num5 = gparam_2;
			bool item = true;
			for (int i = gparam_; i <= gparam_3; i++)
			{
				if (!(flag ? plotFunction(num5, i) : plotFunction(i, num5)))
				{
					item = false;
				}
				num3 -= num2;
				if (num3 < 0)
				{
					num5 += num4;
					num3 += num;
				}
			}
			return new Tuple<bool, Vector2i>(item, @class.hitpoint);
		}
	}

	private sealed class Class484
	{
		public Vector2i hitpoint;

		public Class483 class483_0;

		internal bool CheckWalkability(int int_0, int int_1)
		{
			if (WalkabilityGrid.IsWalkable(class483_0.cachedTerrainData_0.Data, class483_0.cachedTerrainData_0.BPR, int_0, int_1, 2))
			{
				return true;
			}
			hitpoint = new Vector2i(int_0, int_1);
			return false;
		}

		internal bool CheckWalkability_Fly(int int_0, int int_1)
		{
			if (WalkabilityGrid.IsWalkable(class483_0.cachedTerrainData_0.FlyData, class483_0.cachedTerrainData_0.BPR, int_0, int_1, 2))
			{
				return true;
			}
			hitpoint = new Vector2i(int_0, int_1);
			return false;
		}
	}

	private sealed class Class486
	{
		public Vector2i pos;

		public CachedTerrainData cachedTerrainData_0;

		public int range;

		public int int_1;

		public Vector2i vector2i_1;

		internal void method_CheckPosX()
		{
			bool flag = true;
			int num = 0;
			Vector2i vector2i = pos;
			Vector2i vector2i2 = vector2i;
			for (int i = 0; i < range; i++)
			{
				vector2i.X++;
				if (smethod_2(cachedTerrainData_0, vector2i) && WalkabilityGrid.IsWalkable(cachedTerrainData_0, vector2i.X, vector2i.Y, 2))
				{
					num++;
					if (flag && (!UseWalkableCheck || IsWalkable(vector2i.X, vector2i.Y)))
					{
						vector2i2 = vector2i;
						flag = false;
					}
				}
			}
			if (num > int_1)
			{
				int_1 = num;
				vector2i_1 = vector2i2;
			}
		}

		internal void method_CheckNegX()
		{
			bool flag = true;
			int num = 0;
			Vector2i vector2i = pos;
			Vector2i vector2i2 = vector2i;
			for (int i = 0; i < range; i++)
			{
				vector2i.X--;
				if (smethod_2(cachedTerrainData_0, vector2i) && WalkabilityGrid.IsWalkable(cachedTerrainData_0, vector2i.X, vector2i.Y, 2))
				{
					num++;
					if (flag && (!UseWalkableCheck || IsWalkable(vector2i.X, vector2i.Y)))
					{
						vector2i2 = vector2i;
						flag = false;
					}
				}
			}
			if (num > int_1)
			{
				int_1 = num;
				vector2i_1 = vector2i2;
			}
		}

		internal void method_CheckNegY()
		{
			bool flag = true;
			int num = 0;
			Vector2i vector2i = pos;
			Vector2i vector2i2 = vector2i;
			for (int i = 0; i < range; i++)
			{
				vector2i.Y--;
				if (smethod_2(cachedTerrainData_0, vector2i) && WalkabilityGrid.IsWalkable(cachedTerrainData_0, vector2i.X, vector2i.Y, 2))
				{
					num++;
					if (flag && (!UseWalkableCheck || IsWalkable(vector2i.X, vector2i.Y)))
					{
						vector2i2 = vector2i;
						flag = false;
					}
				}
			}
			if (num > int_1)
			{
				int_1 = num;
				vector2i_1 = vector2i2;
			}
		}

		internal void method_CheckPosY()
		{
			bool flag = true;
			int num = 0;
			Vector2i vector2i = pos;
			Vector2i vector2i2 = vector2i;
			for (int i = 0; i < range; i++)
			{
				vector2i.Y++;
				if (smethod_2(cachedTerrainData_0, vector2i) && WalkabilityGrid.IsWalkable(cachedTerrainData_0, vector2i.X, vector2i.Y, 2))
				{
					num++;
					if (flag && (!UseWalkableCheck || IsWalkable(vector2i.X, vector2i.Y)))
					{
						vector2i2 = vector2i;
						flag = false;
					}
				}
			}
			if (num > int_1)
			{
				int_1 = num;
				vector2i_1 = vector2i2;
			}
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private static readonly List<int> blockedObjectList = new List<int>();

	private static readonly List<int> blockedTriggerableBlockages = new List<int>();

	private static uint _areaHash;

	private static FeatureEnum blockTrialOfAscendancy = FeatureEnum.Unset;

	private static FeatureEnum blockLockedDoors = FeatureEnum.Unset;

	private static FeatureEnum blockLockedTempleDoors = FeatureEnum.Unset;

	private static bool CheckForTempleDoors;

	private static bool CheckForAscendancyDoor;

	private static bool BlockUndyingBlockage;

	private static bool BlockOssuary_HiddenDoor;

	private static readonly Dictionary<Vector2i, Vector2i> walkablePositionDictionary = new Dictionary<Vector2i, Vector2i>();

	public static List<string> JumpableTgt = new List<string>();

	public static bool IsReady = false;

	public static RDPathfinder PolyPathfinder { get; private set; }

	public static bool ShouldBlockNPC { get; set; } = true;


	public static bool ShouldBlockChest { get; set; } = false;


	public static uint AreaHash => _areaHash;

	public static int AscendancyDoorRadiusOverride { get; set; } = 0;


	public static int LabyrinthLockedDoorRadiusOverride { get; set; } = 0;


	public static int TempleLockedDoorRadiusOverride { get; set; } = 0;


	public static bool AutoSavePathfindingData { get; set; } = false;


	public static FeatureEnum BlockTrialOfAscendancy
	{
		get
		{
			return blockTrialOfAscendancy;
		}
		set
		{
			if (blockTrialOfAscendancy != value)
			{
				blockTrialOfAscendancy = value;
				ilog_0.InfoFormat(string.Format(global::_003CModule_003E.smethod_7<string>(932415331u), value), Array.Empty<object>());
			}
		}
	}

	public static FeatureEnum BlockLockedDoors
	{
		get
		{
			return blockLockedDoors;
		}
		set
		{
			if (blockLockedDoors != value)
			{
				blockLockedDoors = value;
				ilog_0.InfoFormat(string.Format(global::_003CModule_003E.smethod_8<string>(1513799723u), value), Array.Empty<object>());
			}
		}
	}

	public static FeatureEnum BlockLockedTempleDoors
	{
		get
		{
			return blockLockedTempleDoors;
		}
		set
		{
			if (blockLockedTempleDoors != value)
			{
				blockLockedTempleDoors = value;
				ilog_0.InfoFormat(string.Format(global::_003CModule_003E.smethod_7<string>(1220828032u), value), Array.Empty<object>());
			}
		}
	}

	public static bool UseWalkableCheck { get; set; } = true;


	public static event ObstacleUpdateEvent OnObstacleUpdate;

	public static event ExilePatherReloadEvent OnExilePatherReload;

	public static List<Vector2i> GetPointsOnSegment(Vector2i start, Vector2i end, bool dontLeaveFrame)
	{
		Class480 @class = new Class480();
		@class.vector2i_0 = start;
		@class.vector2i_1 = end;
		return @class.method_0();
	}

	public static bool CanObjectSee(Vector2i start, Vector2i end, bool dontLeaveFrame = false, bool shouldUseRangedMap = false)
	{
		Vector2i hitPoint;
		return Raycast(start, end, out hitPoint, dontLeaveFrame, shouldUseRangedMap);
	}

	public static bool CanObjectSee(NetworkObject obj, NetworkObject other, bool dontLeaveFrame = false, bool shouldUseRangedMap = false)
	{
		Vector2i hitPoint;
		return Raycast(obj.Position, other.Position, out hitPoint, dontLeaveFrame, shouldUseRangedMap);
	}

	public static bool CanObjectSee(NetworkObject obj, NetworkObject other, out Vector2i hitPoint, bool dontLeaveFrame = false, bool shouldUseRangedMap = false)
	{
		return Raycast(obj.Position, other.Position, out hitPoint, dontLeaveFrame, shouldUseRangedMap);
	}

	public static bool CanObjectSee(NetworkObject obj, Vector2i position, bool dontLeaveFrame = false, bool shouldUseRangedMap = false)
	{
		Vector2i hitPoint;
		return Raycast(obj.Position, position, out hitPoint, dontLeaveFrame, shouldUseRangedMap);
	}

	public static bool CanObjectSee(NetworkObject obj, Vector2i position, out Vector2i hitPoint, bool dontLeaveFrame = false, bool shouldUseRangedMap = false)
	{
		return Raycast(obj.Position, position, out hitPoint, dontLeaveFrame, shouldUseRangedMap);
	}

	private static void smethod_0<T>(ref T gparam_0, ref T gparam_1)
	{
		T val = gparam_0;
		gparam_0 = gparam_1;
		gparam_1 = val;
	}

	public static bool Raycast(Vector2i start, Vector2i end, out Vector2i hitPoint, bool dontLeaveFrame = false, bool shouldUseRangedMap = false)
	{
		Class483 @class = new Class483();
		@class.startPoint = start;
		@class.endpoint = end;
		@class.cachedTerrainData_0 = LokiPoe.TerrainData.Cache;
		Tuple<bool, Vector2i> tuple = @class.method_0(shouldUseRangedMap);
		hitPoint = tuple.Item2;
		Utility.BroadcastMessage(null, global::_003CModule_003E.smethod_9<string>(607268392u), start, end, tuple.Item1, tuple.Item2);
		return tuple.Item1;
	}

	private static bool ShouldBlock(NetworkObject triggerableBlockage_0)
	{
		return true;
	}

	private static void CheckForUpdates()
	{
		bool flag = false;
		List<NetworkObject> list = new List<NetworkObject>();
		if ((BlockLockedTempleDoors == FeatureEnum.Enabled && CheckForTempleDoors) || BlockLockedDoors == FeatureEnum.Enabled || (BlockTrialOfAscendancy == FeatureEnum.Enabled && CheckForAscendancyDoor) || BlockUndyingBlockage || (ShouldBlockNPC && LokiPoe.CurrentWorldArea.IsTown) || ShouldBlockChest || LokiPoe.LocalData.WorldArea.Id.StartsWith(global::_003CModule_003E.smethod_5<string>(2079413927u)) || BlockOssuary_HiddenDoor)
		{
			list = LokiPoe.ObjectManager.Objects;
		}
		if (LokiPoe.LocalData.WorldArea.Id.StartsWith(global::_003CModule_003E.smethod_7<string>(2605007534u)))
		{
			byte[] data = LokiPoe.TerrainData.Cache.Data;
			BlockTriggerableBlockages(ref data, LokiPoe.TerrainData.Cache.BPR, ShouldBlock, list);
			LokiPoe.TerrainData.Cache.Data = data;
			flag = true;
		}
		if (BlockLockedTempleDoors == FeatureEnum.Enabled && CheckForTempleDoors)
		{
			IEnumerable<DreamPoeBot.Loki.Game.Objects.TriggerableBlockage> enumerable = from x in list.OfType<DreamPoeBot.Loki.Game.Objects.TriggerableBlockage>()
				where x.Name == global::_003CModule_003E.smethod_5<string>(1770321745u)
				select x;
			foreach (DreamPoeBot.Loki.Game.Objects.TriggerableBlockage item in enumerable)
			{
				if (!blockedObjectList.Contains(item.Id))
				{
					if (!item.IsOpened)
					{
						int num = 8;
						if (TempleLockedDoorRadiusOverride != 0)
						{
							num = TempleLockedDoorRadiusOverride;
						}
						PolyPathfinder.AddObstacle(item.Position, num);
						blockedObjectList.Add(item.Id);
						flag = true;
						ilog_0.InfoFormat(string.Format(global::_003CModule_003E.smethod_6<string>(852286263u), item.Id, item.Name, item.Position.X, item.Position.Y, num), Array.Empty<object>());
					}
				}
				else if (item.IsOpened)
				{
					PolyPathfinder.RemoveObstacle(item.Position);
					blockedObjectList.Remove(item.Id);
					flag = true;
					ilog_0.InfoFormat(string.Format(global::_003CModule_003E.smethod_9<string>(3537739271u), item.Id, item.Name, item.Position.X, item.Position.Y), Array.Empty<object>());
				}
			}
		}
		if (BlockLockedDoors == FeatureEnum.Enabled)
		{
			IEnumerable<DreamPoeBot.Loki.Game.Objects.TriggerableBlockage> enumerable2 = from x in list.OfType<DreamPoeBot.Loki.Game.Objects.TriggerableBlockage>()
				where x.IsLockedDoor || x.IsGoldenDoor || x.IsSilverDoor
				select x;
			foreach (DreamPoeBot.Loki.Game.Objects.TriggerableBlockage item2 in enumerable2)
			{
				if (!blockedObjectList.Contains(item2.Id))
				{
					if (item2.IsOpened)
					{
						continue;
					}
					if (item2.IsGoldenDoor)
					{
						if (LokiPoe.InstanceInfo.GetPlayerInventoryItemsBySlot(InventorySlot.Main).FirstOrDefault((Item x) => x.FullName == global::_003CModule_003E.smethod_7<string>(3623453383u)) != null)
						{
							continue;
						}
					}
					else if (item2.IsSilverDoor && LokiPoe.InstanceInfo.GetPlayerInventoryItemsBySlot(InventorySlot.Main).FirstOrDefault((Item x) => x.FullName == global::_003CModule_003E.smethod_6<string>(262454679u)) != null)
					{
						continue;
					}
					int num2 = 8;
					if (LabyrinthLockedDoorRadiusOverride != 0)
					{
						num2 = LabyrinthLockedDoorRadiusOverride;
					}
					PolyPathfinder.AddObstacle(item2.Position, num2);
					blockedObjectList.Add(item2.Id);
					flag = true;
					ilog_0.InfoFormat(string.Format(global::_003CModule_003E.smethod_9<string>(1118118981u), item2.Id, item2.Name, item2.Position.X, item2.Position.Y, num2), Array.Empty<object>());
				}
				else if (item2.IsOpened)
				{
					PolyPathfinder.RemoveObstacle(item2.Position);
					blockedObjectList.Remove(item2.Id);
					flag = true;
					ilog_0.InfoFormat(string.Format(global::_003CModule_003E.smethod_7<string>(1914925905u), item2.Id, item2.Name, item2.Position.X, item2.Position.Y), Array.Empty<object>());
				}
			}
		}
		if (BlockTrialOfAscendancy == FeatureEnum.Enabled && CheckForAscendancyDoor)
		{
			List<DreamPoeBot.Loki.Game.Objects.TriggerableBlockage> source = list.OfType<DreamPoeBot.Loki.Game.Objects.TriggerableBlockage>().ToList();
			if (source.Any())
			{
				DreamPoeBot.Loki.Game.Objects.TriggerableBlockage triggerableBlockage = source.FirstOrDefault((DreamPoeBot.Loki.Game.Objects.TriggerableBlockage x) => x.Metadata == global::_003CModule_003E.smethod_9<string>(4218767258u));
				if (triggerableBlockage != null && !blockedObjectList.Contains(triggerableBlockage.Id) && !triggerableBlockage.IsOpened)
				{
					int num3 = 8;
					if (AscendancyDoorRadiusOverride != 0)
					{
						num3 = AscendancyDoorRadiusOverride;
					}
					PolyPathfinder.AddObstacle(triggerableBlockage.Position, num3);
					blockedObjectList.Add(triggerableBlockage.Id);
					flag = true;
					ilog_0.InfoFormat(string.Format(global::_003CModule_003E.smethod_9<string>(96417803u), triggerableBlockage.Name, triggerableBlockage.Position.X, triggerableBlockage.Position.Y, num3), Array.Empty<object>());
					CheckForAscendancyDoor = false;
				}
			}
		}
		if (BlockUndyingBlockage)
		{
			NetworkObject undyingBlockage = LokiPoe.ObjectManager.UndyingBlockage;
			if (undyingBlockage != null && !blockedObjectList.Contains(undyingBlockage.Id) && undyingBlockage.IsTargetable)
			{
				PolyPathfinder.AddObstacle(undyingBlockage.Position, 12f);
				blockedObjectList.Add(undyingBlockage.Id);
				flag = true;
				ilog_0.InfoFormat(string.Format(global::_003CModule_003E.smethod_9<string>(96417803u), undyingBlockage.Name, undyingBlockage.Position.X, undyingBlockage.Position.Y, 12), Array.Empty<object>());
				BlockUndyingBlockage = false;
			}
		}
		if (BlockOssuary_HiddenDoor)
		{
			List<DreamPoeBot.Loki.Game.Objects.TriggerableBlockage> source2 = list.OfType<DreamPoeBot.Loki.Game.Objects.TriggerableBlockage>().ToList();
			if (source2.Any())
			{
				DreamPoeBot.Loki.Game.Objects.TriggerableBlockage triggerableBlockage2 = source2.FirstOrDefault((DreamPoeBot.Loki.Game.Objects.TriggerableBlockage x) => x.Metadata == global::_003CModule_003E.smethod_8<string>(2746877441u));
				if (triggerableBlockage2 != null && !triggerableBlockage2.IsOpened && !blockedObjectList.Contains(triggerableBlockage2.Id))
				{
					Vector2i triggerableBlockagePosition = new Vector2i(triggerableBlockage2.Position.X, triggerableBlockage2.BoundsMin.Y);
					Vector2i triggerableBlockagePosition2 = new Vector2i(triggerableBlockage2.Position.X, triggerableBlockage2.BoundsMax.Y);
					PolyPathfinder.AddObstacle(triggerableBlockagePosition, 10f);
					PolyPathfinder.AddObstacle(triggerableBlockagePosition2, 10f);
					blockedObjectList.Add(triggerableBlockage2.Id);
					flag = true;
					ilog_0.InfoFormat(string.Format(global::_003CModule_003E.smethod_8<string>(2228876673u), triggerableBlockage2.Name, triggerableBlockagePosition.X, triggerableBlockagePosition.Y, 10), Array.Empty<object>());
					ilog_0.InfoFormat(string.Format(global::_003CModule_003E.smethod_8<string>(2228876673u), triggerableBlockage2.Name, triggerableBlockagePosition2.X, triggerableBlockagePosition2.Y, 10), Array.Empty<object>());
					BlockOssuary_HiddenDoor = false;
				}
			}
		}
		if (ShouldBlockNPC && LokiPoe.CurrentWorldArea.IsTown)
		{
			List<Npc> list2 = list.OfType<Npc>().ToList();
			if (list2.Any())
			{
				foreach (Npc item3 in list2)
				{
					if (!object.Equals(item3, null))
					{
						int id = item3.Id;
						Vector2i position = item3.Position;
						if (!blockedObjectList.Contains(id))
						{
							PolyPathfinder.AddObstacle(position, 7f);
							blockedObjectList.Add(id);
							flag = true;
						}
					}
				}
			}
		}
		if (ShouldBlockChest)
		{
			List<DreamPoeBot.Loki.Game.Objects.Chest> list3 = list.OfType<DreamPoeBot.Loki.Game.Objects.Chest>().ToList();
			if (list3.Any())
			{
				foreach (DreamPoeBot.Loki.Game.Objects.Chest item4 in list3)
				{
					if (object.Equals(item4, null))
					{
						continue;
					}
					int id2 = item4.Id;
					Vector2i position2 = item4.Position;
					if (item4.IsOpened)
					{
						if (blockedObjectList.Contains(id2))
						{
							PolyPathfinder.RemoveObstacle(position2);
							blockedObjectList.Remove(id2);
							flag = true;
						}
					}
					else if (!blockedObjectList.Contains(id2))
					{
						PolyPathfinder.AddObstacle(position2, 3f);
						blockedObjectList.Add(id2);
						flag = true;
					}
				}
			}
		}
		if (flag)
		{
			PolyPathfinder.UpdateObstacles();
		}
	}

	public static void BlockTriggerableBlockages(ref byte[] data, int bytesPerRow, Func<NetworkObject, bool> shouldBlock, List<NetworkObject> obj)
	{
		if (!LokiPoe.CurrentWorldArea.Id.StartsWith(global::_003CModule_003E.smethod_8<string>(903785266u)))
		{
			return;
		}
		Thread.Sleep(5);
		List<NetworkObject> list = obj.Where((NetworkObject x) => x.Components.TriggerableBlockageComponent != null).ToList();
		foreach (NetworkObject item in list)
		{
			DreamPoeBot.Loki.Components.TriggerableBlockage triggerableBlockageComponent = item.Components.TriggerableBlockageComponent;
			StateMachine stateMachineComponent = item.Components.StateMachineComponent;
			if (stateMachineComponent == null)
			{
				continue;
			}
			StateMachine.StageState stageState = stateMachineComponent.StageStates.FirstOrDefault((StateMachine.StageState x) => x.Name == global::_003CModule_003E.smethod_9<string>(4293851225u));
			if (stageState == null)
			{
				continue;
			}
			if (!stageState.IsActive)
			{
				if (blockedTriggerableBlockages.Contains(item.Id))
				{
					continue;
				}
				ilog_0.WarnFormat(string.Format(global::_003CModule_003E.smethod_5<string>(2679748726u), item.Name, stageState.IsActive), Array.Empty<object>());
				byte[] navData = triggerableBlockageComponent.NavData;
				int x2 = triggerableBlockageComponent.BoundsMin.X;
				int num = triggerableBlockageComponent.BoundsMax.X;
				if ((num - x2) % 2 == 1)
				{
					num++;
				}
				int num2 = (triggerableBlockageComponent.BoundsMax.X + 1) / 2 - triggerableBlockageComponent.BoundsMin.X / 2;
				for (int i = triggerableBlockageComponent.BoundsMin.Y; i < triggerableBlockageComponent.BoundsMax.Y; i++)
				{
					for (int j = x2; j < num; j++)
					{
						int num3 = (i - triggerableBlockageComponent.BoundsMin.Y) * num2 + (j - x2) / 2;
						int num4 = i * bytesPerRow + j / 2;
						if ((j & 1) == 0)
						{
							byte b = (byte)(navData[num3] & 0xFu);
							if (b > 5)
							{
								b = 5;
							}
							data[num4] = b;
						}
						else
						{
							byte b2 = (byte)(navData[num3] >> 4);
							if (b2 > 5)
							{
								b2 = 5;
							}
							data[num4] = b2;
						}
					}
				}
				blockedTriggerableBlockages.Add(item.Id);
			}
			else
			{
				if (!blockedTriggerableBlockages.Contains(item.Id))
				{
					continue;
				}
				ilog_0.WarnFormat(string.Format(global::_003CModule_003E.smethod_7<string>(3181320272u), item.Name, stageState.IsActive), Array.Empty<object>());
				byte[] navData2 = triggerableBlockageComponent.NavData;
				int x3 = triggerableBlockageComponent.BoundsMin.X;
				int num5 = triggerableBlockageComponent.BoundsMax.X;
				if ((num5 - x3) % 2 == 1)
				{
					num5++;
				}
				int num6 = (triggerableBlockageComponent.BoundsMax.X + 1) / 2 - triggerableBlockageComponent.BoundsMin.X / 2;
				for (int k = triggerableBlockageComponent.BoundsMin.Y; k < triggerableBlockageComponent.BoundsMax.Y; k++)
				{
					for (int l = x3; l < num5; l++)
					{
						int num7 = (k - triggerableBlockageComponent.BoundsMin.Y) * num6 + (l - x3) / 2;
						int num8 = k * bytesPerRow + l / 2;
						if (((uint)l & (true ? 1u : 0u)) != 0)
						{
							int num9 = (byte)(navData2[num7] >> 4);
							byte b3 = (byte)(data[num8] & 0xFu);
							byte b4 = (byte)(data[num8] >> 4);
							int num10 = num9 + b4;
							if (num10 > 5)
							{
								num10 = 5;
							}
							data[num8] = (byte)(b3 | (num10 << 4));
						}
						else
						{
							byte b5 = (byte)(navData2[num7] & 0xFu);
							byte b6 = (byte)(data[num8] & 0xFu);
							byte b7 = (byte)(data[num8] >> 4);
							int num11 = b5 + b6;
							if (num11 > 5)
							{
								num11 = 5;
							}
							data[num8] = (byte)(num11 | (b7 << 4));
						}
					}
				}
				blockedTriggerableBlockages.Remove(item.Id);
			}
		}
	}

	public static void Save(string filePath)
	{
	}

	public static void Load(string filePath)
	{
	}

	public static void Reload(bool force = false)
	{
		IsReady = false;
		try
		{
			if (GameStateController.IsInGameState)
			{
				uint num2 = default(uint);
				TimeSpan elapsed = default(TimeSpan);
				while (true)
				{
					uint areaHash = LokiPoe.LocalData.AreaHash;
					while (true)
					{
						IL_0555:
						if (_areaHash != areaHash)
						{
							goto IL_053f;
						}
						goto IL_0550;
						IL_0550:
						if (force)
						{
							goto IL_053f;
						}
						goto IL_056f;
						IL_053f:
						while (true)
						{
							ClearWalkablePositionCache();
							blockedObjectList.Clear();
							while (true)
							{
								blockedTriggerableBlockages.Clear();
								while (true)
								{
									IL_052e:
									if (!force)
									{
										goto IL_0515;
									}
									goto IL_0526;
									IL_0526:
									CachedTerrainData cachedTerrainData = LokiPoe.TerrainData.Recache;
									goto IL_051b;
									IL_051b:
									while (true)
									{
										IL_051b_2:
										RDPathfinder polyPathfinder = PolyPathfinder;
										if (polyPathfinder != null)
										{
											goto IL_04fb;
										}
										goto IL_0501;
										IL_0501:
										while (true)
										{
											IL_0501_2:
											Thread thread = new Thread(LokiPoe.ClientFunctions.GenerateHeightCache);
											while (true)
											{
												thread.Start();
												while (true)
												{
													PolyPathfinder = new RDPathfinder();
													while (true)
													{
														ilog_0.InfoFormat(global::_003CModule_003E.smethod_9<string>(1830447615u), Array.Empty<object>());
														while (true)
														{
															PolyPathfinder.ProcessEntireZone(cachedTerrainData, multiThreadProcessing: true);
															while (true)
															{
																Thread.Sleep(5);
																while (true)
																{
																	ilog_0.InfoFormat(global::_003CModule_003E.smethod_8<string>(1025174582u), Array.Empty<object>());
																	Stopwatch stopwatch = Stopwatch.StartNew();
																	while (true)
																	{
																		IL_048a:
																		if (!thread.IsAlive)
																		{
																			while (true)
																			{
																				_areaHash = areaHash;
																				while (true)
																				{
																					ilog_0.InfoFormat(global::_003CModule_003E.smethod_9<string>(2892256027u), Array.Empty<object>());
																					while (true)
																					{
																						FastWalkablePositionFor(LokiPoe.LocalData.MyPosition, 5);
																						while (true)
																						{
																							BlockUndyingBlockage = false;
																							while (true)
																							{
																								BlockOssuary_HiddenDoor = false;
																								while (true)
																								{
																									IL_03e2:
																									if (LokiPoe.IsInGame)
																									{
																										while (true)
																										{
																											DatWorldAreaWrapper currentWorldArea = LokiPoe.CurrentWorldArea;
																											while (true)
																											{
																												string name = currentWorldArea.Name;
																												while (true)
																												{
																													string id = currentWorldArea.Id;
																													while (true)
																													{
																														bool isTempleOfAtzoatl = currentWorldArea.IsTempleOfAtzoatl;
																														while (true)
																														{
																															IL_034b:
																															ilog_0.InfoFormat(global::_003CModule_003E.smethod_9<string>(2701138607u) + name + global::_003CModule_003E.smethod_9<string>(4223659461u) + id + global::_003CModule_003E.smethod_9<string>(2358343368u), Array.Empty<object>());
																															if (id.Equals(global::_003CModule_003E.smethod_8<string>(634702818u)))
																															{
																																goto IL_02bf;
																															}
																															goto IL_0333;
																															IL_0333:
																															if (id.Equals(global::_003CModule_003E.smethod_5<string>(2596866646u)))
																															{
																																goto IL_028d;
																															}
																															goto IL_0321;
																															IL_0321:
																															while (true)
																															{
																																IL_0321_2:
																																CheckForAscendancyDoor = false;
																																string[] labyrinthTrialAreaIds = LokiPoe.LabyrinthTrialAreaIds;
																																while (true)
																																{
																																	int num = 0;
																																	while (true)
																																	{
																																		IL_027b:
																																		if (num >= labyrinthTrialAreaIds.Length)
																																		{
																																			while (true)
																																			{
																																				IL_0275:
																																				if (isTempleOfAtzoatl)
																																				{
																																					goto IL_0222;
																																				}
																																				goto IL_026d;
																																				IL_026d:
																																				CheckForTempleDoors = false;
																																				goto IL_0252;
																																				IL_0252:
																																				while (true)
																																				{
																																					IL_0252_2:
																																					ilog_0.InfoFormat(global::_003CModule_003E.smethod_6<string>(1356141452u), Array.Empty<object>());
																																					while (true)
																																					{
																																						IL_021b:
																																						CheckForUpdates();
																																						while (true)
																																						{
																																							IL_0200:
																																							ilog_0.InfoFormat(global::_003CModule_003E.smethod_9<string>(321625551u), Array.Empty<object>());
																																							while (true)
																																							{
																																								IL_01f7:
																																								if (!AutoSavePathfindingData)
																																								{
																																								}
																																								while (true)
																																								{
																																									IL_01ea:
																																									if (!thread.IsAlive)
																																									{
																																										while (true)
																																										{
																																											IL_01df:
																																											IsReady = true;
																																											while (true)
																																											{
																																												ExilePatherReloadEvent onExilePatherReload = ExilePather.OnExilePatherReload;
																																												if (onExilePatherReload != null)
																																												{
																																													onExilePatherReload();
																																													switch ((num2 = (num2 * 1408780925) ^ 0x7B41C11Fu ^ 0xA7655C56u) % 84u)
																																													{
																																													case 66u:
																																														break;
																																													case 18u:
																																														goto IL_002b;
																																													case 25u:
																																														goto IL_0036;
																																													case 63u:
																																														goto IL_004f;
																																													case 33u:
																																														continue;
																																													default:
																																														return;
																																													case 52u:
																																														goto IL_01df;
																																													case 23u:
																																													case 55u:
																																														goto IL_01ea;
																																													case 20u:
																																														goto IL_01f7;
																																													case 68u:
																																														goto IL_0200;
																																													case 47u:
																																														goto IL_021b;
																																													case 10u:
																																														goto IL_0222;
																																													case 74u:
																																														goto IL_0252_2;
																																													case 83u:
																																														goto IL_026d;
																																													case 44u:
																																														goto IL_0275;
																																													case 56u:
																																														goto IL_027b;
																																													case 76u:
																																														goto end_IL_027b;
																																													case 36u:
																																														goto end_IL_0288;
																																													case 65u:
																																														goto IL_02bf;
																																													case 73u:
																																														goto IL_02f1;
																																													case 15u:
																																													case 42u:
																																														goto IL_0321_2;
																																													case 6u:
																																														goto IL_0333;
																																													case 67u:
																																														goto IL_034b;
																																													case 12u:
																																														goto end_IL_034b;
																																													case 43u:
																																														goto end_IL_03ae;
																																													case 11u:
																																														goto end_IL_03b9;
																																													case 58u:
																																														goto end_IL_03c4;
																																													case 3u:
																																														goto end_IL_03cf;
																																													case 28u:
																																													case 32u:
																																														goto IL_03e2;
																																													case 81u:
																																														goto end_IL_03e2;
																																													case 79u:
																																														goto end_IL_03eb;
																																													case 5u:
																																														goto end_IL_03f3;
																																													case 13u:
																																														goto end_IL_03fb;
																																													case 0u:
																																														goto end_IL_040a;
																																													case 16u:
																																														goto end_IL_0425;
																																													case 57u:
																																														goto IL_0437;
																																													case 78u:
																																														goto IL_044c;
																																													case 37u:
																																														goto IL_0455;
																																													case 31u:
																																														goto IL_0471;
																																													case 48u:
																																														goto IL_048a;
																																													case 71u:
																																														goto end_IL_048a;
																																													case 59u:
																																														goto end_IL_0494;
																																													case 53u:
																																														goto end_IL_04b6;
																																													case 22u:
																																														goto end_IL_04be;
																																													case 60u:
																																														goto end_IL_04cc;
																																													case 14u:
																																														goto end_IL_04e7;
																																													case 9u:
																																														goto end_IL_04f3;
																																													case 7u:
																																														goto IL_0501_2;
																																													case 2u:
																																														goto end_IL_051b;
																																													case 4u:
																																													case 75u:
																																														goto IL_051b_2;
																																													case 1u:
																																														goto IL_0526;
																																													case 38u:
																																														goto IL_052e;
																																													case 51u:
																																														goto end_IL_052e;
																																													case 40u:
																																														goto end_IL_0533;
																																													case 8u:
																																														goto end_IL_053f;
																																													case 46u:
																																														goto IL_0555;
																																													case 62u:
																																														goto end_IL_0555;
																																													case 21u:
																																													case 29u:
																																														goto end_IL_055f;
																																													case 39u:
																																														goto IL_056f;
																																													case 35u:
																																														return;
																																													case 41u:
																																														goto IL_057f;
																																													case 50u:
																																														goto IL_0598;
																																													case 45u:
																																														goto IL_05a6;
																																													case 26u:
																																														goto IL_05bf;
																																													case 61u:
																																														return;
																																													case 69u:
																																														goto IL_05d0;
																																													case 72u:
																																														return;
																																													case 77u:
																																														return;
																																													case 80u:
																																														return;
																																													case 54u:
																																														goto IL_05f7;
																																													case 30u:
																																														goto IL_0627;
																																													case 34u:
																																														goto IL_062b;
																																													case 17u:
																																														goto IL_0633;
																																													case 82u:
																																														goto IL_0639;
																																													case 24u:
																																													case 27u:
																																														goto IL_0663;
																																													case 19u:
																																														goto IL_0681;
																																													case 64u:
																																														goto IL_069a;
																																													case 49u:
																																														goto IL_06a0;
																																													case 70u:
																																														return;
																																													}
																																													break;
																																												}
																																												return;
																																											}
																																											break;
																																										}
																																										break;
																																									}
																																									goto IL_0036;
																																									IL_004f:
																																									Thread.Sleep(10);
																																									continue;
																																									IL_0036:
																																									ilog_0.InfoFormat(global::_003CModule_003E.smethod_5<string>(756669429u), Array.Empty<object>());
																																									goto IL_004f;
																																								}
																																								break;
																																							}
																																							break;
																																						}
																																						break;
																																					}
																																					break;
																																				}
																																				break;
																																				IL_0222:
																																				CheckForTempleDoors = true;
																																				ilog_0.InfoFormat(string.Format(global::_003CModule_003E.smethod_9<string>(3050618385u), CheckForTempleDoors, id), Array.Empty<object>());
																																				goto IL_0252;
																																			}
																																		}
																																		string value = labyrinthTrialAreaIds[num];
																																		if (!id.Equals(value, StringComparison.OrdinalIgnoreCase))
																																		{
																																			goto IL_002b;
																																		}
																																		goto IL_05f7;
																																		IL_06a0:
																																		IsReady = true;
																																		return;
																																		IL_069a:
																																		_ = AutoSavePathfindingData;
																																		goto IL_06a0;
																																		IL_002b:
																																		num++;
																																		continue;
																																		IL_05f7:
																																		CheckForAscendancyDoor = true;
																																		ilog_0.InfoFormat(string.Format(global::_003CModule_003E.smethod_7<string>(698566201u), CheckForAscendancyDoor, id), Array.Empty<object>());
																																		goto IL_0627;
																																		IL_0627:
																																		if (!isTempleOfAtzoatl)
																																		{
																																			goto IL_062b;
																																		}
																																		goto IL_0633;
																																		IL_062b:
																																		CheckForTempleDoors = false;
																																		goto IL_0663;
																																		IL_0633:
																																		CheckForTempleDoors = true;
																																		goto IL_0639;
																																		IL_0639:
																																		ilog_0.InfoFormat(string.Format(global::_003CModule_003E.smethod_8<string>(2397078979u), CheckForTempleDoors, id), Array.Empty<object>());
																																		goto IL_0663;
																																		IL_0663:
																																		ilog_0.InfoFormat(global::_003CModule_003E.smethod_6<string>(1356141452u), Array.Empty<object>());
																																		CheckForUpdates();
																																		goto IL_0681;
																																		IL_0681:
																																		ilog_0.InfoFormat(global::_003CModule_003E.smethod_6<string>(2771799501u), Array.Empty<object>());
																																		goto IL_069a;
																																		continue;
																																		end_IL_027b:
																																		break;
																																	}
																																	continue;
																																	end_IL_0288:
																																	break;
																																}
																																break;
																															}
																															goto IL_028d;
																															IL_02bf:
																															if (LokiPoe.InstanceInfo.GetPlayerInventoryItemsBySlot(InventorySlot.Main).FirstOrDefault((Item x) => x.FullName == global::_003CModule_003E.smethod_5<string>(1508620458u)) == null)
																															{
																																goto IL_02f1;
																															}
																															goto IL_0321;
																															IL_028d:
																															BlockOssuary_HiddenDoor = true;
																															ilog_0.InfoFormat(string.Format(global::_003CModule_003E.smethod_7<string>(599409362u), BlockOssuary_HiddenDoor, id), Array.Empty<object>());
																															goto IL_0321;
																															IL_02f1:
																															BlockUndyingBlockage = true;
																															ilog_0.InfoFormat(string.Format(global::_003CModule_003E.smethod_8<string>(2291308527u), BlockUndyingBlockage, id), Array.Empty<object>());
																															goto IL_0321;
																															continue;
																															end_IL_034b:
																															break;
																														}
																														continue;
																														end_IL_03ae:
																														break;
																													}
																													continue;
																													end_IL_03b9:
																													break;
																												}
																												continue;
																												end_IL_03c4:
																												break;
																											}
																											continue;
																											end_IL_03cf:
																											break;
																										}
																									}
																									if (GameStateController.IsInGameState)
																									{
																										continue;
																									}
																									goto IL_05d0;
																									IL_05d0:
																									IsReady = true;
																									thread.Abort(false);
																									return;
																									continue;
																									end_IL_03e2:
																									break;
																								}
																								continue;
																								end_IL_03eb:
																								break;
																							}
																							continue;
																							end_IL_03f3:
																							break;
																						}
																						continue;
																						end_IL_03fb:
																						break;
																					}
																					continue;
																					end_IL_040a:
																					break;
																				}
																				continue;
																				end_IL_0425:
																				break;
																			}
																		}
																		if (GameStateController.IsInGameState)
																		{
																			goto IL_0437;
																		}
																		goto IL_057f;
																		IL_0598:
																		thread.Abort();
																		IsReady = false;
																		return;
																		IL_057f:
																		ilog_0.InfoFormat(global::_003CModule_003E.smethod_7<string>(4136657398u), Array.Empty<object>());
																		goto IL_0598;
																		IL_0437:
																		if (stopwatch.ElapsedMilliseconds <= 10000L)
																		{
																			goto IL_044c;
																		}
																		goto IL_05a6;
																		IL_044c:
																		elapsed = stopwatch.Elapsed;
																		goto IL_0455;
																		IL_0455:
																		if (elapsed.TotalSeconds % 5.0 != 0.0)
																		{
																			continue;
																		}
																		goto IL_0471;
																		IL_0471:
																		ilog_0.InfoFormat(global::_003CModule_003E.smethod_6<string>(1395791047u), Array.Empty<object>());
																		continue;
																		IL_05a6:
																		ilog_0.InfoFormat(global::_003CModule_003E.smethod_8<string>(2787550743u), Array.Empty<object>());
																		goto IL_05bf;
																		IL_05bf:
																		thread.Abort();
																		LokiPoe.EscapeState.LogoutToTitleScreen();
																		return;
																		continue;
																		end_IL_048a:
																		break;
																	}
																	continue;
																	end_IL_0494:
																	break;
																}
																continue;
																end_IL_04b6:
																break;
															}
															continue;
															end_IL_04be:
															break;
														}
														continue;
														end_IL_04cc:
														break;
													}
													continue;
													end_IL_04e7:
													break;
												}
												continue;
												end_IL_04f3:
												break;
											}
											break;
										}
										goto IL_04fb;
										IL_04fb:
										polyPathfinder.Destroy();
										goto IL_0501;
										continue;
										end_IL_051b:
										break;
									}
									goto IL_0515;
									IL_0515:
									cachedTerrainData = LokiPoe.TerrainData.Cache;
									goto IL_051b;
									continue;
									end_IL_052e:
									break;
								}
								continue;
								end_IL_0533:
								break;
							}
							continue;
							end_IL_053f:
							break;
						}
						goto IL_0550;
						IL_056f:
						CheckForUpdates();
						IsReady = true;
						return;
						continue;
						end_IL_0555:
						break;
					}
					continue;
					end_IL_055f:
					break;
				}
			}
			IsReady = false;
		}
		catch (Exception)
		{
			ilog_0.ErrorFormat(global::_003CModule_003E.smethod_9<string>(1531435696u), Array.Empty<object>());
			_areaHash = 0u;
			IsReady = false;
		}
	}

	public static bool PathExistsBetween(Vector2i start, Vector2i end, bool dontLeaveFrame = false)
	{
		PathfindingCommand command = new PathfindingCommand(start, end, 15f, avoidWallHugging: false);
		return FindPath(ref command, dontLeaveFrame);
	}

	public static bool FindPath(ref PathfindingCommand command, bool dontLeaveFrame = false)
	{
		if (PolyPathfinder == null)
		{
			throw new Exception(global::_003CModule_003E.smethod_7<string>(689508385u));
		}
		return PolyPathfinder.FindPath(ref command);
	}

	public static float PathDistance(Vector2i start, Vector2i end, bool avoidWallHugging = false, bool dontLeaveFrame = false)
	{
		if (PolyPathfinder == null)
		{
			throw new Exception(global::_003CModule_003E.smethod_7<string>(3808180337u));
		}
		_ = LokiPoe.LocalData.MyPosition;
		PathfindingCommand command = new PathfindingCommand(start, end, 5f, avoidWallHugging);
		if (!FindPath(ref command, dontLeaveFrame))
		{
			return float.MaxValue;
		}
		float num = start.DistanceF(command.Path[0]);
		for (int i = 1; i < command.Path.Count; i++)
		{
			num += command.Path[i - 1].DistanceF(command.Path[i]);
		}
		return num;
	}

	public static bool IsWalkable(Vector2i arg)
	{
		if (PolyPathfinder == null || !PolyPathfinder.AreaGenerated)
		{
			throw new Exception(global::_003CModule_003E.smethod_5<string>(1728880705u));
		}
		return PolyPathfinder.LiesOnPoly(arg);
	}

	public static bool IsWalkable(int x, int y)
	{
		if (PolyPathfinder == null || !PolyPathfinder.AreaGenerated)
		{
			throw new Exception(global::_003CModule_003E.smethod_7<string>(3907337176u));
		}
		return PolyPathfinder.LiesOnPoly(new Vector2i(x, y));
	}

	public static void ClearWalkablePositionCache()
	{
		walkablePositionDictionary.Clear();
	}

	public static Vector2i FastWalkablePositionFor(NetworkObject obj, int range = 30, bool cache = true)
	{
		return FastWalkablePositionFor(obj.Position, range, cache);
	}

	private static bool smethod_2(CachedTerrainData cachedTerrainData_0, Vector2i vector2i_0)
	{
		if (vector2i_0.X >= 0 && vector2i_0.Y >= 0)
		{
			if (vector2i_0.X < cachedTerrainData_0.Cols * 23)
			{
				return vector2i_0.Y < cachedTerrainData_0.Rows * 23;
			}
			return false;
		}
		return false;
	}

	private static double getAngleBetweenPoints(Vector2 pt1, Vector2 pt2)
	{
		return Math.Atan2(pt2.Y - pt1.Y, pt2.X - pt1.X);
	}

	private static Vector2i GetPointOnCircle(Vector2i center, double radian, double radius)
	{
		Vector2i result = default(Vector2i);
		result.X = center.X + (int)(radius * Math.Cos(radian));
		result.Y = center.Y + (int)(radius * Math.Sin(radian));
		return result;
	}

	internal static Vector2i FindWalkableForAngle(Vector2i pos, double radiants, int range = 30)
	{
		_ = Vector2i.Zero;
		for (int i = 5; i < range; i++)
		{
			Vector2i pointOnCircle = GetPointOnCircle(pos, radiants, i);
			if (smethod_2(LokiPoe.TerrainData.Cache, pointOnCircle) && WalkabilityGrid.IsWalkable(LokiPoe.TerrainData.Cache, pointOnCircle.X, pointOnCircle.Y, 2) && (!UseWalkableCheck || IsWalkable(pointOnCircle.X, pointOnCircle.Y)))
			{
				return pointOnCircle;
			}
		}
		return Vector2i.Zero;
	}

	public static Vector2i FastWalkablePositionFor(Vector2i pos, int range = 30, bool cache = true)
	{
		if (cache && walkablePositionDictionary.TryGetValue(pos, out var value))
		{
			return value;
		}
		List<Vector2i> list = new List<Vector2i>();
		Vector2i position = LokiPoe.ObjectManager.Me.Position;
		double angleBetweenPoints = getAngleBetweenPoints(pos.ToVector2(), position.ToVector2());
		for (double num = 0.0; num <= 3.14; num += 0.628)
		{
			if (list.Count >= 3)
			{
				break;
			}
			double radiants = ((num + angleBetweenPoints > 6.28) ? (num + angleBetweenPoints - 6.28) : (num + angleBetweenPoints));
			Vector2i vector2i = FindWalkableForAngle(pos, radiants, range);
			if (vector2i != Vector2i.Zero)
			{
				list.Add(vector2i);
			}
			if (num != 0.0)
			{
				double radiants2 = ((num - angleBetweenPoints < 0.0) ? (num - angleBetweenPoints + 6.28) : (num - angleBetweenPoints));
				Vector2i vector2i2 = FindWalkableForAngle(pos, radiants2, range);
				if (vector2i2 != Vector2i.Zero)
				{
					list.Add(vector2i2);
				}
			}
		}
		if (list.Any())
		{
			list.Shuffle();
			Vector2i vector2i3 = list.First();
			if (!walkablePositionDictionary.ContainsKey(pos))
			{
				walkablePositionDictionary.Add(pos, vector2i3);
			}
			return vector2i3;
		}
		return Vector2i.Zero;
	}

	public static void SignalObstacleUpdate()
	{
		ExilePather.OnObstacleUpdate?.Invoke();
	}
}
