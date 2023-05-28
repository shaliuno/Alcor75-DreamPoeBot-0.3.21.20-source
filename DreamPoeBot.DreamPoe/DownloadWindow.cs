using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using log4net;
using MahApps.Metro.Controls;

namespace DreamPoeBot.DreamPoe;

public partial class DownloadWindow : UserControl, IComponentConnector
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly string string_0;

	private readonly string filter;

	internal ProgressRing progressRing_0;

	public DownloadWindow(MainWindow mainWindow, string filter)
	{
		try
		{
			this.filter = filter;
			if (string.IsNullOrEmpty(GlobalSettings.Instance.BuddyUpdaterName))
			{
				string_0 = Path.Combine(Path.GetTempPath(), string.Format(global::_003CModule_003E.smethod_9<string>(3129890978u), Environment.TickCount));
			}
			else
			{
				string_0 = GlobalSettings.Instance.BuddyUpdaterName + global::_003CModule_003E.smethod_7<string>(27796420u);
			}
			InitializeComponent();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_8<string>(2887098237u), ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(delegate
			{
				Application.Current.Shutdown();
			});
		}
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		progressRing_0.IsActive = true;
		ThreadPool.QueueUserWorkItem(method_1);
	}

	private static string EscapeCommandLineArguments(string[] args)
	{
		string text = "";
		foreach (string input in args)
		{
			text += Regex.Replace(input, global::_003CModule_003E.smethod_7<string>(2538215336u), global::_003CModule_003E.smethod_5<string>(572052954u));
		}
		return text;
	}

	private void method_1(object object_0)
	{
		try
		{
			using WebClient webClient = new WebClient();
			webClient.DownloadFile(global::_003CModule_003E.smethod_9<string>(1241174894u), string_0);
			if (!File.Exists(string_0))
			{
				LokiPoe.ApplicationExitCodes_0 = ApplicationExitCodes.UpdaterNotFound;
				if (!CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_5<string>(1460136680u)))
				{
					MessageBox.Show(global::_003CModule_003E.smethod_6<string>(1331658367u) + string_0 + global::_003CModule_003E.smethod_8<string>(2920678016u), Util.RandomWindowTitle(global::_003CModule_003E.smethod_5<string>(3247083280u)), MessageBoxButton.OK, MessageBoxImage.Hand);
				}
				base.Dispatcher.Invoke(delegate
				{
					Application.Current.Shutdown((int)LokiPoe.ApplicationExitCodes_0);
				});
				return;
			}
			LokiPoe.ApplicationExitCodes_0 = ApplicationExitCodes.Updating;
			string[] args = CommandLine.Arguments.GetOriginalArguments.ToArray();
			string text = EscapeCommandLineArguments(args);
			string arguments = filter + global::_003CModule_003E.smethod_6<string>(4087646139u) + Assembly.GetEntryAssembly().Location + global::_003CModule_003E.smethod_8<string>(3898675925u) + GlobalSettings.Instance.CustomRDServerName + global::_003CModule_003E.smethod_8<string>(3500910331u) + text + global::_003CModule_003E.smethod_7<string>(1852958604u);
			Process.Start(string_0, arguments);
			base.Dispatcher.Invoke(delegate
			{
				Application.Current.Shutdown((int)LokiPoe.ApplicationExitCodes_0);
			});
		}
		catch (Exception ex)
		{
			ilog_0.ErrorFormat(global::_003CModule_003E.smethod_9<string>(4171645773u), (object)ex);
			if (!CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_6<string>(3080416367u)))
			{
				MessageBox.Show(global::_003CModule_003E.smethod_6<string>(3715455979u) + ex.ToString(), Util.RandomWindowTitle(global::_003CModule_003E.smethod_7<string>(289310395u)), MessageBoxButton.OK, MessageBoxImage.Hand);
			}
			LokiPoe.ApplicationExitCodes_0 = ApplicationExitCodes.UpdateException;
			base.Dispatcher.Invoke(delegate
			{
				Application.Current.Shutdown((int)LokiPoe.ApplicationExitCodes_0);
			});
		}
	}
}
