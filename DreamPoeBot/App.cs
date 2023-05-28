using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.PathfindingClient;
using DreamPoeBot.Structures.ns13;
using log4net;

namespace DreamPoeBot;

public partial class App : System.Windows.Application
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private bool method_0()
	{
		return true;
	}

	private void method_1()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_7<string>(3119294924u) + Assembly.GetEntryAssembly().GetName().Version);
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_9<string>(1210057075u) + System.Windows.Forms.Application.ExecutablePath.Replace(Environment.UserName, global::_003CModule_003E.smethod_9<string>(3959103526u)).Replace(AppDomain.CurrentDomain.FriendlyName, global::_003CModule_003E.smethod_5<string>(2685492379u)));
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_6<string>(122950320u) + string.Join(global::_003CModule_003E.smethod_7<string>(3700649234u), CommandLine.Arguments.GetOriginalArguments));
		ManagementObject managementObject = new ManagementObjectSearcher(global::_003CModule_003E.smethod_5<string>(4272276517u)).Get().Cast<ManagementObject>().First();
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_8<string>(1132539458u) + ((string)managementObject[global::_003CModule_003E.smethod_6<string>(173169204u)]).Trim());
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_6<string>(4269486699u) + (string)managementObject[global::_003CModule_003E.smethod_7<string>(2434254867u)]);
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_8<string>(1636075504u) + (string)managementObject[global::_003CModule_003E.smethod_8<string>(870366126u)]);
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_5<string>(3919404942u) + CultureInfo.InstalledUICulture.Name + global::_003CModule_003E.smethod_9<string>(3811101793u) + CultureInfo.InstalledUICulture.EnglishName + global::_003CModule_003E.smethod_9<string>(3461622015u));
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_7<string>(464704811u) + CultureInfo.CurrentUICulture.Name + global::_003CModule_003E.smethod_6<string>(618461955u) + CultureInfo.CurrentUICulture.EnglishName + global::_003CModule_003E.smethod_7<string>(4173788889u));
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_6<string>(643571397u) + CultureInfo.CurrentCulture.Name + global::_003CModule_003E.smethod_9<string>(3811101793u) + CultureInfo.CurrentCulture.EnglishName + global::_003CModule_003E.smethod_7<string>(4173788889u));
		ilog_0.Info((object)stringBuilder);
	}

	private void method_2()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_6<string>(2059229446u) + Assembly.GetEntryAssembly().GetName().Version);
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_6<string>(2282988689u) + System.Windows.Forms.Application.ExecutablePath.Replace(Environment.UserName, global::_003CModule_003E.smethod_5<string>(1613822607u)).Replace(AppDomain.CurrentDomain.FriendlyName, global::_003CModule_003E.smethod_5<string>(2685492379u)));
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_6<string>(122950320u) + string.Join(global::_003CModule_003E.smethod_5<string>(517288211u), CommandLine.Arguments.GetOriginalArguments));
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_9<string>(3118826776u));
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_7<string>(2920981246u) + OSInfo.Name);
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_7<string>(753117512u) + OSInfo.Edition);
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_8<string>(3972036640u) + OSInfo.ServicePack);
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_9<string>(188355897u) + OSInfo.Version);
		stringBuilder.AppendLine(global::_003CModule_003E.smethod_6<string>(1661929844u) + (Environment.Is64BitOperatingSystem ? 64 : 86));
		ilog_0.Info((object)stringBuilder);
	}

	protected override void OnStartup(StartupEventArgs e)
	{
		try
		{
			method_1();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_8<string>(4077807092u), ex);
			try
			{
				method_2();
			}
			catch (Exception ex2)
			{
				ilog_0.Error((object)global::_003CModule_003E.smethod_9<string>(3300251204u), ex2);
				Logger.OpenLogFile();
				System.Windows.Application.Current.Shutdown();
				return;
			}
		}
		try
		{
			ilog_0.Info((object)global::_003CModule_003E.smethod_8<string>(3136278333u));
			string text = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), global::_003CModule_003E.smethod_8<string>(1585443076u));
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			ProfileOptimization.SetProfileRoot(text);
			ProfileOptimization.StartProfile(global::_003CModule_003E.smethod_7<string>(4277474636u));
			ilog_0.Info((object)global::_003CModule_003E.smethod_8<string>(1942981551u));
		}
		catch (Exception ex3)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_7<string>(1145215960u), ex3);
		}
		try
		{
			string name = new DirectoryInfo(Environment.CurrentDirectory).Name;
			if (name.ToLowerInvariant().Contains(global::_003CModule_003E.smethod_5<string>(2619186715u)))
			{
				ilog_0.ErrorFormat(global::_003CModule_003E.smethod_8<string>(2088979122u) + name + global::_003CModule_003E.smethod_9<string>(3837839949u), Array.Empty<object>());
				Logger.OpenLogFile();
				System.Windows.Application.Current.Shutdown();
				return;
			}
			string processName = Process.GetCurrentProcess().ProcessName;
			if (processName.ToLowerInvariant().Contains(global::_003CModule_003E.smethod_7<string>(4083689866u)))
			{
				ilog_0.ErrorFormat(global::_003CModule_003E.smethod_6<string>(95615143u) + processName + global::_003CModule_003E.smethod_7<string>(1771859350u), Array.Empty<object>());
				Logger.OpenLogFile();
				System.Windows.Application.Current.Shutdown();
				return;
			}
		}
		catch (Exception ex4)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_7<string>(1145215960u), ex4);
			Logger.OpenLogFile();
			System.Windows.Application.Current.Shutdown();
			return;
		}
		base.Dispatcher.UnhandledException += method_4;
		AppDomain.CurrentDomain.UnhandledException += method_3;
		try
		{
			ilog_0.Info((object)global::_003CModule_003E.smethod_9<string>(920738148u));
			if (!method_0())
			{
				Shutdown((int)LokiPoe.ApplicationExitCodes_0);
				return;
			}
			ilog_0.Info((object)global::_003CModule_003E.smethod_6<string>(3646202119u));
		}
		catch (Exception ex5)
		{
			ilog_0.ErrorFormat(global::_003CModule_003E.smethod_9<string>(3683153677u), (object)ex5);
			Logger.OpenLogFile();
			Shutdown((int)LokiPoe.ApplicationExitCodes_0);
			return;
		}
		base.OnStartup(e);
	}

	private void method_3(object sender, UnhandledExceptionEventArgs e)
	{
		if (e.ExceptionObject != null)
		{
			ilog_0.DebugFormat(global::_003CModule_003E.smethod_8<string>(639408721u), (object)e.ExceptionObject.ToString());
		}
		Class104.smethod_0();
	}

	private void method_4(object sender, DispatcherUnhandledExceptionEventArgs e)
	{
		e.Handled = true;
		if (e.Exception != null)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_8<string>(2693780024u), e.Exception);
			if (e.Exception.InnerException != null)
			{
				ilog_0.Error((object)global::_003CModule_003E.smethod_7<string>(3633194751u), e.Exception.InnerException);
			}
		}
	}

	protected override void OnExit(ExitEventArgs e)
	{
		RDClient.Disconnect();
		Class104.smethod_0();
		LokiPoe.smethod_0();
		e.ApplicationExitCode = (int)LokiPoe.ApplicationExitCodes_0;
		base.OnExit(e);
	}
}
