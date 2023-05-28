using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Bot.Pathfinding;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using log4net;

namespace DreamPoeBot.Loki.Bot;

public static class PlayerMoverManager
{
	public delegate void PlayerMoverEvent(IPlayerMover mover);

	private static readonly ILog ilog_1 = Logger.GetLoggerInstanceForName(global::_003CModule_003E.smethod_9<string>(4211844421u));

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private static List<IPlayerMover> list_0 = new List<IPlayerMover>();

	[CompilerGenerated]
	private static PlayerMoverEvent playerMoverEvent_0;

	[CompilerGenerated]
	private static PlayerMoverEvent playerMoverEvent_1;

	[CompilerGenerated]
	private static PlayerMoverEvent playerMoverEvent_2;

	[CompilerGenerated]
	private static PlayerMoverEvent playerMoverEvent_3;

	[CompilerGenerated]
	private static PlayerMoverEvent playerMoverEvent_4;

	[CompilerGenerated]
	private static PlayerMoverEvent playerMoverEvent_5;

	private static IPlayerMover iplayerMover_0;

	[CompilerGenerated]
	private static EventHandler<PlayerMoverChangedEventArgs> eventHandler_0;

	public static IReadOnlyList<IPlayerMover> PlayerMovers => list_0;

	public static IPlayerMover Current
	{
		get
		{
			return iplayerMover_0;
		}
		set
		{
			if (BotManager.IsRunning)
			{
				throw new InvalidOperationException(global::_003CModule_003E.smethod_6<string>(1737793938u));
			}
			if (value != null)
			{
				if (iplayerMover_0 != value)
				{
					IPlayerMover old = iplayerMover_0;
					iplayerMover_0 = value;
					LokiPoe.InvokeEvent(eventHandler_0, null, new PlayerMoverChangedEventArgs(old, iplayerMover_0));
				}
				return;
			}
			throw new InvalidOperationException(global::_003CModule_003E.smethod_5<string>(3491993110u));
		}
	}

	public static PathfindingCommand CurrentCommand
	{
		get
		{
			if (Current == null)
			{
				ilog_0.ErrorFormat(global::_003CModule_003E.smethod_9<string>(1630853320u), Array.Empty<object>());
				return null;
			}
			return Current.CurrentCommand;
		}
	}

	public static event PlayerMoverEvent PreStart
	{
		[CompilerGenerated]
		add
		{
			PlayerMoverEvent playerMoverEvent = playerMoverEvent_0;
			PlayerMoverEvent playerMoverEvent2;
			do
			{
				playerMoverEvent2 = playerMoverEvent;
				PlayerMoverEvent value2 = (PlayerMoverEvent)Delegate.Combine(playerMoverEvent2, value);
				playerMoverEvent = Interlocked.CompareExchange(ref playerMoverEvent_0, value2, playerMoverEvent2);
			}
			while (playerMoverEvent != playerMoverEvent2);
		}
		[CompilerGenerated]
		remove
		{
			PlayerMoverEvent playerMoverEvent = playerMoverEvent_0;
			PlayerMoverEvent playerMoverEvent2;
			do
			{
				playerMoverEvent2 = playerMoverEvent;
				PlayerMoverEvent value2 = (PlayerMoverEvent)Delegate.Remove(playerMoverEvent2, value);
				playerMoverEvent = Interlocked.CompareExchange(ref playerMoverEvent_0, value2, playerMoverEvent2);
			}
			while (playerMoverEvent != playerMoverEvent2);
		}
	}

	public static event PlayerMoverEvent PostStart
	{
		[CompilerGenerated]
		add
		{
			PlayerMoverEvent playerMoverEvent = playerMoverEvent_1;
			PlayerMoverEvent playerMoverEvent2;
			do
			{
				playerMoverEvent2 = playerMoverEvent;
				PlayerMoverEvent value2 = (PlayerMoverEvent)Delegate.Combine(playerMoverEvent2, value);
				playerMoverEvent = Interlocked.CompareExchange(ref playerMoverEvent_1, value2, playerMoverEvent2);
			}
			while (playerMoverEvent != playerMoverEvent2);
		}
		[CompilerGenerated]
		remove
		{
			PlayerMoverEvent playerMoverEvent = playerMoverEvent_1;
			PlayerMoverEvent playerMoverEvent2;
			do
			{
				playerMoverEvent2 = playerMoverEvent;
				PlayerMoverEvent value2 = (PlayerMoverEvent)Delegate.Remove(playerMoverEvent2, value);
				playerMoverEvent = Interlocked.CompareExchange(ref playerMoverEvent_1, value2, playerMoverEvent2);
			}
			while (playerMoverEvent != playerMoverEvent2);
		}
	}

	public static event PlayerMoverEvent PreTick
	{
		[CompilerGenerated]
		add
		{
			PlayerMoverEvent playerMoverEvent = playerMoverEvent_2;
			PlayerMoverEvent playerMoverEvent2;
			do
			{
				playerMoverEvent2 = playerMoverEvent;
				PlayerMoverEvent value2 = (PlayerMoverEvent)Delegate.Combine(playerMoverEvent2, value);
				playerMoverEvent = Interlocked.CompareExchange(ref playerMoverEvent_2, value2, playerMoverEvent2);
			}
			while (playerMoverEvent != playerMoverEvent2);
		}
		[CompilerGenerated]
		remove
		{
			PlayerMoverEvent playerMoverEvent = playerMoverEvent_2;
			PlayerMoverEvent playerMoverEvent2;
			do
			{
				playerMoverEvent2 = playerMoverEvent;
				PlayerMoverEvent value2 = (PlayerMoverEvent)Delegate.Remove(playerMoverEvent2, value);
				playerMoverEvent = Interlocked.CompareExchange(ref playerMoverEvent_2, value2, playerMoverEvent2);
			}
			while (playerMoverEvent != playerMoverEvent2);
		}
	}

	public static event PlayerMoverEvent PostTick
	{
		[CompilerGenerated]
		add
		{
			PlayerMoverEvent playerMoverEvent = playerMoverEvent_3;
			PlayerMoverEvent playerMoverEvent2;
			do
			{
				playerMoverEvent2 = playerMoverEvent;
				PlayerMoverEvent value2 = (PlayerMoverEvent)Delegate.Combine(playerMoverEvent2, value);
				playerMoverEvent = Interlocked.CompareExchange(ref playerMoverEvent_3, value2, playerMoverEvent2);
			}
			while (playerMoverEvent != playerMoverEvent2);
		}
		[CompilerGenerated]
		remove
		{
			PlayerMoverEvent playerMoverEvent = playerMoverEvent_3;
			PlayerMoverEvent playerMoverEvent2;
			do
			{
				playerMoverEvent2 = playerMoverEvent;
				PlayerMoverEvent value2 = (PlayerMoverEvent)Delegate.Remove(playerMoverEvent2, value);
				playerMoverEvent = Interlocked.CompareExchange(ref playerMoverEvent_3, value2, playerMoverEvent2);
			}
			while (playerMoverEvent != playerMoverEvent2);
		}
	}

	public static event PlayerMoverEvent PreStop
	{
		[CompilerGenerated]
		add
		{
			PlayerMoverEvent playerMoverEvent = playerMoverEvent_4;
			PlayerMoverEvent playerMoverEvent2;
			do
			{
				playerMoverEvent2 = playerMoverEvent;
				PlayerMoverEvent value2 = (PlayerMoverEvent)Delegate.Combine(playerMoverEvent2, value);
				playerMoverEvent = Interlocked.CompareExchange(ref playerMoverEvent_4, value2, playerMoverEvent2);
			}
			while (playerMoverEvent != playerMoverEvent2);
		}
		[CompilerGenerated]
		remove
		{
			PlayerMoverEvent playerMoverEvent = playerMoverEvent_4;
			PlayerMoverEvent playerMoverEvent2;
			do
			{
				playerMoverEvent2 = playerMoverEvent;
				PlayerMoverEvent value2 = (PlayerMoverEvent)Delegate.Remove(playerMoverEvent2, value);
				playerMoverEvent = Interlocked.CompareExchange(ref playerMoverEvent_4, value2, playerMoverEvent2);
			}
			while (playerMoverEvent != playerMoverEvent2);
		}
	}

	public static event PlayerMoverEvent PostStop
	{
		[CompilerGenerated]
		add
		{
			PlayerMoverEvent playerMoverEvent = playerMoverEvent_5;
			PlayerMoverEvent playerMoverEvent2;
			do
			{
				playerMoverEvent2 = playerMoverEvent;
				PlayerMoverEvent value2 = (PlayerMoverEvent)Delegate.Combine(playerMoverEvent2, value);
				playerMoverEvent = Interlocked.CompareExchange(ref playerMoverEvent_5, value2, playerMoverEvent2);
			}
			while (playerMoverEvent != playerMoverEvent2);
		}
		[CompilerGenerated]
		remove
		{
			PlayerMoverEvent playerMoverEvent = playerMoverEvent_5;
			PlayerMoverEvent playerMoverEvent2;
			do
			{
				playerMoverEvent2 = playerMoverEvent;
				PlayerMoverEvent value2 = (PlayerMoverEvent)Delegate.Remove(playerMoverEvent2, value);
				playerMoverEvent = Interlocked.CompareExchange(ref playerMoverEvent_5, value2, playerMoverEvent2);
			}
			while (playerMoverEvent != playerMoverEvent2);
		}
	}

	public static event EventHandler<PlayerMoverChangedEventArgs> OnPlayerMoverChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler<PlayerMoverChangedEventArgs> eventHandler = eventHandler_0;
			EventHandler<PlayerMoverChangedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PlayerMoverChangedEventArgs> value2 = (EventHandler<PlayerMoverChangedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<PlayerMoverChangedEventArgs> eventHandler = eventHandler_0;
			EventHandler<PlayerMoverChangedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PlayerMoverChangedEventArgs> value2 = (EventHandler<PlayerMoverChangedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
	}

	public static void Start()
	{
		Start(Current);
	}

	public static void Start(IPlayerMover mover)
	{
		ilog_0.InfoFormat(global::_003CModule_003E.smethod_9<string>(3242677680u), (object)mover.GetType());
		smethod_0(mover, playerMoverEvent_0);
		try
		{
			mover.Start();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_8<string>(4015174931u), ex);
		}
		smethod_0(mover, playerMoverEvent_1);
	}

	public static void Tick()
	{
		if (GlobalSettings.Instance.DebugTicks)
		{
			new StringBuilder();
			Stopwatch stopwatch = Stopwatch.StartNew();
			Tick(Current);
			stopwatch.Stop();
			ilog_1.InfoFormat(string.Format(global::_003CModule_003E.smethod_7<string>(2031240102u), Current.Name, stopwatch.ElapsedMilliseconds), Array.Empty<object>());
		}
		else
		{
			Tick(Current);
		}
	}

	public static void Tick(IPlayerMover mover)
	{
		smethod_0(mover, playerMoverEvent_2);
		try
		{
			mover.Tick();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_7<string>(4271087227u), ex);
		}
		smethod_0(mover, playerMoverEvent_3);
	}

	public static void Stop()
	{
		Stop(Current);
	}

	public static void Stop(IPlayerMover mover)
	{
		ilog_0.InfoFormat(global::_003CModule_003E.smethod_7<string>(2319652803u), (object)mover.GetType());
		smethod_0(mover, playerMoverEvent_4);
		try
		{
			mover.Stop();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_7<string>(75276770u), ex);
		}
		smethod_0(mover, playerMoverEvent_5);
	}

	private static void smethod_0(IPlayerMover iplayerMover_1, PlayerMoverEvent playerMoverEvent_6)
	{
		if (playerMoverEvent_6 == null)
		{
			return;
		}
		try
		{
			playerMoverEvent_6(iplayerMover_1);
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_5<string>(4268808763u), ex);
		}
	}

	internal static void smethod_1(IReadOnlyList<ThirdPartyInstance> ireadOnlyList_0)
	{
		List<IPlayerMover> list = new List<IPlayerMover>();
		list.AddRange(new TypeLoader<IPlayerMover>());
		list_0 = new List<IPlayerMover>();
		foreach (IPlayerMover item in list)
		{
			if (Utility.smethod_0(ilog_0, item))
			{
				list_0.Add(item);
			}
		}
	}

	internal static void smethod_2()
	{
		if (list_0 == null)
		{
			return;
		}
		foreach (IPlayerMover item in list_0)
		{
			try
			{
				ilog_0.InfoFormat(global::_003CModule_003E.smethod_9<string>(1380699752u), (object)item.GetType());
				item.Deinitialize();
			}
			catch (Exception ex)
			{
				ilog_0.ErrorFormat(global::_003CModule_003E.smethod_9<string>(1205959863u), (object)item.Name, (object)ex);
			}
		}
		list_0.Clear();
	}

	public static bool MoveTowards(Vector2i position, object user = null)
	{
		if (Current == null)
		{
			ilog_0.ErrorFormat(global::_003CModule_003E.smethod_6<string>(3078123661u), Array.Empty<object>());
			return false;
		}
		return Current.MoveTowards(position, user);
	}
}
