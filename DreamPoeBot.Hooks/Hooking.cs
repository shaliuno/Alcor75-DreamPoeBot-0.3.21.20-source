using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using DreamPoeBot.Framework;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using log4net;

namespace DreamPoeBot.Hooks;

internal static class Hooking
{
	public static IntPtr HookingdataIntPtr;

	private static readonly ILog Log = Logger.GetLoggerInstanceForType();

	private static long _dPBTimer = 0L;

	internal static bool IsInstalled { get; private set; } = false;


	internal static bool InitializeHook(Process process)
	{
		try
		{
			HookingdataIntPtr = Interop.VirtualAllocEx(LokiPoe.Memory.procHandle, IntPtr.Zero, 4096u, Interop.AllocationType.Commit, Interop.MemoryProtection.ReadWrite);
			byte[] data = new byte[4096];
			LokiPoe.Memory.WriteMem(HookingdataIntPtr.ToInt64(), data);
			LokiPoe.Memory.WriteByte(HookingdataIntPtr.ToInt64() + 992L, 0);
			LokiPoe.Memory.Writelong(HookingdataIntPtr.ToInt64() + 768L, 1L);
			LokiPoe.Memory.WriteByte(HookingdataIntPtr.ToInt64() + 776L, 50);
			HookManager.SetKey(GlobalSettings.Instance.AuthKey);
			if (WinApi.initialize(GlobalSettings.Instance.AuthKey))
			{
				string directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
				if (string.IsNullOrEmpty(directoryName))
				{
					Log.ErrorFormat(global::_003CModule_003E.smethod_9<string>(1431167611u), Array.Empty<object>());
					return false;
				}
				Thread thread = new Thread(DPBTimer)
				{
					IsBackground = true
				};
				thread.Start();
				if (WinApi.start_injection("", "", process.MainWindowHandle.ToInt64(), HookingdataIntPtr.ToInt64(), process.Id, GlobalSettings.Instance.AuthKey))
				{
					return true;
				}
				Log.ErrorFormat(global::_003CModule_003E.smethod_7<string>(1172184993u), Array.Empty<object>());
				return false;
			}
			Log.ErrorFormat(global::_003CModule_003E.smethod_5<string>(3827257840u), Array.Empty<object>());
			return false;
		}
		catch (Exception arg)
		{
			Log.ErrorFormat(string.Format(global::_003CModule_003E.smethod_6<string>(1769647556u), arg), Array.Empty<object>());
			return false;
		}
	}

	private static void DPBTimer()
	{
		LokiPoe.ProcessHookManager.ResetCursor();

        while (true)
		{
			_dPBTimer++;
			LokiPoe.Memory.Writelong(HookingdataIntPtr.ToInt64() + 768L, _dPBTimer);
			byte b = LokiPoe.Memory.ReadByte(HookingdataIntPtr.ToInt64() + 994L);
			if (b == 1 && LokiPoe.ProcessHookManager.OnInjectionDisabledByIngecion != null)
			{
				LokiPoe.ProcessHookManager.OnInjectionDisabledByIngecion(null, new LokiPoe.ProcessHookManager.HookDisabledByIngecionEventArgs(global::_003CModule_003E.smethod_5<string>(4072382711u)));
			}
			Thread.Sleep(1000);
		}
	}

	internal static void Deinitialize()
	{
		LokiPoe.Memory.WriteByte(HookingdataIntPtr.ToInt64() + 992L, 1);
	}

	internal static bool InstallHook()
	{
		try
		{
			LokiPoe.Memory.WriteByte(HookingdataIntPtr.ToInt64() + 993L, 1);
			IsInstalled = true;
			return true;
		}
		catch (Exception arg)
		{
			IsInstalled = false;
			Log.ErrorFormat(string.Format(global::_003CModule_003E.smethod_6<string>(105120822u), arg), Array.Empty<object>());
			return false;
		}
	}

	internal static void RemoveHook()
	{
		try
		{
			LokiPoe.Memory.WriteByte(HookingdataIntPtr.ToInt64() + 993L, 0);
			Thread.Sleep(1000);
			IsInstalled = false;
		}
		catch (Exception arg)
		{
			Log.ErrorFormat(string.Format(global::_003CModule_003E.smethod_8<string>(2386673670u), arg), Array.Empty<object>());
		}
	}
}
