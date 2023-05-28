using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using log4net;

namespace DreamPoeBot.Loki.Bot;

public static class RoutineManager
{
	public delegate void RoutineEvent(IRoutine routine);

	private static readonly ILog ilog_1 = Logger.GetLoggerInstanceForName(global::_003CModule_003E.smethod_9<string>(2403342805u));

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private static List<IRoutine> list_0 = new List<IRoutine>();

	private static RoutineEvent routineEvent_0;

	private static RoutineEvent routineEvent_1;

	private static RoutineEvent routineEvent_2;

	private static RoutineEvent routineEvent_3;

	private static RoutineEvent routineEvent_4;

	private static RoutineEvent routineEvent_5;

	private static IRoutine iroutine_0;

	private static EventHandler<RoutineChangedEventArgs> eventHandler_0;

	public static IReadOnlyList<IRoutine> Routines => list_0;

	public static IRoutine Current
	{
		get
		{
			return iroutine_0;
		}
		set
		{
			if (BotManager.IsRunning)
			{
				throw new InvalidOperationException(global::_003CModule_003E.smethod_9<string>(151777865u));
			}
			if (value != null)
			{
				if (iroutine_0 != value)
				{
					IRoutine old = iroutine_0;
					iroutine_0 = value;
					LokiPoe.InvokeEvent(eventHandler_0, null, new RoutineChangedEventArgs(old, iroutine_0));
				}
				return;
			}
			throw new InvalidOperationException(global::_003CModule_003E.smethod_9<string>(2040493949u));
		}
	}

	public static event RoutineEvent PreStart
	{
		add
		{
			RoutineEvent routineEvent = routineEvent_0;
			RoutineEvent routineEvent2;
			do
			{
				routineEvent2 = routineEvent;
				RoutineEvent value2 = (RoutineEvent)Delegate.Combine(routineEvent2, value);
				routineEvent = Interlocked.CompareExchange(ref routineEvent_0, value2, routineEvent2);
			}
			while (routineEvent != routineEvent2);
		}
		remove
		{
			RoutineEvent routineEvent = routineEvent_0;
			RoutineEvent routineEvent2;
			do
			{
				routineEvent2 = routineEvent;
				RoutineEvent value2 = (RoutineEvent)Delegate.Remove(routineEvent2, value);
				routineEvent = Interlocked.CompareExchange(ref routineEvent_0, value2, routineEvent2);
			}
			while (routineEvent != routineEvent2);
		}
	}

	public static event RoutineEvent PostStart
	{
		add
		{
			RoutineEvent routineEvent = routineEvent_1;
			RoutineEvent routineEvent2;
			do
			{
				routineEvent2 = routineEvent;
				RoutineEvent value2 = (RoutineEvent)Delegate.Combine(routineEvent2, value);
				routineEvent = Interlocked.CompareExchange(ref routineEvent_1, value2, routineEvent2);
			}
			while (routineEvent != routineEvent2);
		}
		remove
		{
			RoutineEvent routineEvent = routineEvent_1;
			RoutineEvent routineEvent2;
			do
			{
				routineEvent2 = routineEvent;
				RoutineEvent value2 = (RoutineEvent)Delegate.Remove(routineEvent2, value);
				routineEvent = Interlocked.CompareExchange(ref routineEvent_1, value2, routineEvent2);
			}
			while (routineEvent != routineEvent2);
		}
	}

	public static event RoutineEvent PreTick
	{
		add
		{
			RoutineEvent routineEvent = routineEvent_2;
			RoutineEvent routineEvent2;
			do
			{
				routineEvent2 = routineEvent;
				RoutineEvent value2 = (RoutineEvent)Delegate.Combine(routineEvent2, value);
				routineEvent = Interlocked.CompareExchange(ref routineEvent_2, value2, routineEvent2);
			}
			while (routineEvent != routineEvent2);
		}
		remove
		{
			RoutineEvent routineEvent = routineEvent_2;
			RoutineEvent routineEvent2;
			do
			{
				routineEvent2 = routineEvent;
				RoutineEvent value2 = (RoutineEvent)Delegate.Remove(routineEvent2, value);
				routineEvent = Interlocked.CompareExchange(ref routineEvent_2, value2, routineEvent2);
			}
			while (routineEvent != routineEvent2);
		}
	}

	public static event RoutineEvent PostTick
	{
		add
		{
			RoutineEvent routineEvent = routineEvent_3;
			RoutineEvent routineEvent2;
			do
			{
				routineEvent2 = routineEvent;
				RoutineEvent value2 = (RoutineEvent)Delegate.Combine(routineEvent2, value);
				routineEvent = Interlocked.CompareExchange(ref routineEvent_3, value2, routineEvent2);
			}
			while (routineEvent != routineEvent2);
		}
		remove
		{
			RoutineEvent routineEvent = routineEvent_3;
			RoutineEvent routineEvent2;
			do
			{
				routineEvent2 = routineEvent;
				RoutineEvent value2 = (RoutineEvent)Delegate.Remove(routineEvent2, value);
				routineEvent = Interlocked.CompareExchange(ref routineEvent_3, value2, routineEvent2);
			}
			while (routineEvent != routineEvent2);
		}
	}

	public static event RoutineEvent PreStop
	{
		add
		{
			RoutineEvent routineEvent = routineEvent_4;
			RoutineEvent routineEvent2;
			do
			{
				routineEvent2 = routineEvent;
				RoutineEvent value2 = (RoutineEvent)Delegate.Combine(routineEvent2, value);
				routineEvent = Interlocked.CompareExchange(ref routineEvent_4, value2, routineEvent2);
			}
			while (routineEvent != routineEvent2);
		}
		remove
		{
			RoutineEvent routineEvent = routineEvent_4;
			RoutineEvent routineEvent2;
			do
			{
				routineEvent2 = routineEvent;
				RoutineEvent value2 = (RoutineEvent)Delegate.Remove(routineEvent2, value);
				routineEvent = Interlocked.CompareExchange(ref routineEvent_4, value2, routineEvent2);
			}
			while (routineEvent != routineEvent2);
		}
	}

	public static event RoutineEvent PostStop
	{
		add
		{
			RoutineEvent routineEvent = routineEvent_5;
			RoutineEvent routineEvent2;
			do
			{
				routineEvent2 = routineEvent;
				RoutineEvent value2 = (RoutineEvent)Delegate.Combine(routineEvent2, value);
				routineEvent = Interlocked.CompareExchange(ref routineEvent_5, value2, routineEvent2);
			}
			while (routineEvent != routineEvent2);
		}
		remove
		{
			RoutineEvent routineEvent = routineEvent_5;
			RoutineEvent routineEvent2;
			do
			{
				routineEvent2 = routineEvent;
				RoutineEvent value2 = (RoutineEvent)Delegate.Remove(routineEvent2, value);
				routineEvent = Interlocked.CompareExchange(ref routineEvent_5, value2, routineEvent2);
			}
			while (routineEvent != routineEvent2);
		}
	}

	public static event EventHandler<RoutineChangedEventArgs> OnRoutineChanged
	{
		add
		{
			EventHandler<RoutineChangedEventArgs> eventHandler = eventHandler_0;
			EventHandler<RoutineChangedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<RoutineChangedEventArgs> value2 = (EventHandler<RoutineChangedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<RoutineChangedEventArgs> eventHandler = eventHandler_0;
			EventHandler<RoutineChangedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<RoutineChangedEventArgs> value2 = (EventHandler<RoutineChangedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
	}

	public static void Start()
	{
		Start(Current);
	}

	public static void Start(IRoutine routine)
	{
		ilog_0.InfoFormat(global::_003CModule_003E.smethod_8<string>(3225866701u), (object)routine.GetType());
		smethod_0(routine, routineEvent_0);
		try
		{
			routine.Start();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_7<string>(2644296768u), ex);
		}
		smethod_0(routine, routineEvent_1);
	}

	public static void Tick()
	{
		if (GlobalSettings.Instance.DebugTicks)
		{
			new StringBuilder();
			Stopwatch stopwatch = Stopwatch.StartNew();
			Tick(Current);
			stopwatch.Stop();
			ilog_1.InfoFormat(string.Format(global::_003CModule_003E.smethod_9<string>(1005423693u), Current.Name, stopwatch.ElapsedMilliseconds), Array.Empty<object>());
		}
		else
		{
			Tick(Current);
		}
	}

	public static void Tick(IRoutine routine)
	{
		smethod_0(routine, routineEvent_2);
		try
		{
			routine.Tick();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_8<string>(2725118889u), ex);
		}
		smethod_0(routine, routineEvent_3);
	}

	public static void Stop()
	{
		Stop(Current);
	}

	public static void Stop(IRoutine routine)
	{
		ilog_0.InfoFormat(global::_003CModule_003E.smethod_5<string>(320700733u), (object)routine.GetType());
		smethod_0(routine, routineEvent_4);
		try
		{
			routine.Stop();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_5<string>(3629371277u), ex);
		}
		smethod_0(routine, routineEvent_5);
	}

	private static void smethod_0(IRoutine iroutine_1, RoutineEvent routineEvent_6)
	{
		if (routineEvent_6 == null)
		{
			return;
		}
		try
		{
			routineEvent_6(iroutine_1);
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_7<string>(3842278378u), ex);
		}
	}

	internal static void smethod_1(IReadOnlyList<ThirdPartyInstance> ireadOnlyList_0)
	{
		List<IRoutine> list = new List<IRoutine>();
		list.AddRange(new TypeLoader<IRoutine>());
		list_0 = new List<IRoutine>();
		foreach (IRoutine item in list)
		{
			if (Utility.smethod_3(ilog_0, item))
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
		foreach (IRoutine item in list_0)
		{
			try
			{
				ilog_0.InfoFormat(global::_003CModule_003E.smethod_9<string>(1018792771u), (object)item.GetType());
				item.Deinitialize();
			}
			catch (Exception ex)
			{
				ilog_0.ErrorFormat(global::_003CModule_003E.smethod_8<string>(3012608435u), (object)item.Name, (object)ex);
			}
		}
		list_0.Clear();
	}
}
