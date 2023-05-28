using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using DreamPoeBot.Framework.Helpers;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.WPFLocalizeExtension.Extensions;
using log4net;

namespace DreamPoeBot.DreamPoe;

public partial class ConfigSelection : UserControl, IComponentConnector
{
	private sealed class Class28
	{
		public static readonly Class28 Method9 = new Class28();

		internal void method_0()
		{
			Application.Current.Shutdown();
		}

		internal void method_1()
		{
			Application.Current.Shutdown();
		}
	}

	private string OldProfileBaseName = "";

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly MainWindow mainWindow_0;

	private bool bool_0;

	private void method_0()
	{
		int num = 0;
		bool flag = true;
		string[] directories = Directory.GetDirectories(JsonSettings.SettingsPath, global::_003CModule_003E.smethod_8<string>(2017536076u), SearchOption.TopDirectoryOnly);
		foreach (string text in directories)
		{
			string fileName = Path.GetFileName(text);
			if (!fileName.Equals(global::_003CModule_003E.smethod_5<string>(2683216480u), StringComparison.OrdinalIgnoreCase))
			{
				if (fileName.Equals(global::_003CModule_003E.smethod_9<string>(3259202095u), StringComparison.OrdinalIgnoreCase))
				{
					flag = false;
				}
				if (File.Exists(Path.Combine(text, global::_003CModule_003E.smethod_5<string>(3682836935u))))
				{
					ConfigComboBox.Items.Add(fileName);
					num++;
				}
			}
		}
		if (num == 0 || flag)
		{
			ConfigComboBox.Items.Add(global::_003CModule_003E.smethod_9<string>(3259202095u));
		}
	}

	public ConfigSelection(MainWindow mainWindow)
	{
		try
		{
			mainWindow_0 = mainWindow;
			InitializeComponent();
			method_0();
			OldProfileBaseName = GlobalSettings.Instance.ProfileBaseName;
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_6<string>(77785645u), ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class28.Method9.method_0);
		}
	}

	private void button_0_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			string text = "";
			if (GlobalSettings.Instance.RandomizeProfileSelection)
			{
				ilog_0.DebugFormat(global::_003CModule_003E.smethod_6<string>(3322607847u), Array.Empty<object>());
				string text2 = (string.IsNullOrEmpty(GlobalSettings.Instance.ProfileBaseName) ? "" : GlobalSettings.Instance.ProfileBaseName);
				string text3 = Misc.LoadProfile();
				if (!string.IsNullOrEmpty(text3) && text3.Contains(text2))
				{
					if (!string.IsNullOrEmpty(GlobalSettings.Instance.ProfilesFolderPath) && Directory.Exists(GlobalSettings.Instance.ProfilesFolderPath))
					{
						ilog_0.DebugFormat(global::_003CModule_003E.smethod_9<string>(1893342677u) + text3 + global::_003CModule_003E.smethod_8<string>(1829393717u), Array.Empty<object>());
						Stopwatch stopwatch = Stopwatch.StartNew();
						IO.DirectoryCopy(Path.Combine(GlobalSettings.Instance.ProfilesFolderPath, text3), Path.Combine(JsonSettings.SettingsPath, text3), copySubDirs: true);
						stopwatch.Stop();
						ilog_0.DebugFormat(string.Format(global::_003CModule_003E.smethod_8<string>(530326483u), stopwatch.Elapsed), Array.Empty<object>());
					}
					else
					{
						ilog_0.DebugFormat(global::_003CModule_003E.smethod_8<string>(4029762591u) + text3 + global::_003CModule_003E.smethod_9<string>(172681943u), Array.Empty<object>());
					}
				}
				else
				{
					ilog_0.DebugFormat(string.IsNullOrEmpty(text3) ? global::_003CModule_003E.smethod_7<string>(1740431716u) : (global::_003CModule_003E.smethod_7<string>(4282278266u) + text3 + global::_003CModule_003E.smethod_8<string>(2760517167u) + text2 + global::_003CModule_003E.smethod_6<string>(2354468284u)), Array.Empty<object>());
					if (string.IsNullOrEmpty(GlobalSettings.Instance.ProfilesFolderPath))
					{
						ilog_0.ErrorFormat(global::_003CModule_003E.smethod_7<string>(3011354991u), Array.Empty<object>());
						MessageBox.Show(global::_003CModule_003E.smethod_9<string>(3560527099u), global::_003CModule_003E.smethod_5<string>(2021458925u), MessageBoxButton.OK, MessageBoxImage.Hand);
						return;
					}
					if (!Directory.Exists(GlobalSettings.Instance.ProfilesFolderPath))
					{
						ilog_0.ErrorFormat(global::_003CModule_003E.smethod_6<string>(3868338366u), Array.Empty<object>());
						MessageBox.Show(global::_003CModule_003E.smethod_9<string>(4078062227u), global::_003CModule_003E.smethod_8<string>(1451044624u), MessageBoxButton.OK, MessageBoxImage.Hand);
						return;
					}
					List<string> list = (from x in Directory.EnumerateDirectories(GlobalSettings.Instance.ProfilesFolderPath).ToList()
						where x.Contains(GlobalSettings.Instance.ProfileBaseName)
						select x).ToList();
					if (list.Count <= 0)
					{
						ilog_0.ErrorFormat(global::_003CModule_003E.smethod_9<string>(1503755665u) + GlobalSettings.Instance.ProfileBaseName + global::_003CModule_003E.smethod_5<string>(2046323549u) + GlobalSettings.Instance.ProfilesFolderPath + global::_003CModule_003E.smethod_7<string>(2542469522u), Array.Empty<object>());
						MessageBox.Show(global::_003CModule_003E.smethod_8<string>(3862954402u) + GlobalSettings.Instance.ProfileBaseName + global::_003CModule_003E.smethod_9<string>(656794376u) + GlobalSettings.Instance.ProfilesFolderPath + global::_003CModule_003E.smethod_5<string>(318371219u), global::_003CModule_003E.smethod_7<string>(555078556u), MessageBoxButton.OK, MessageBoxImage.Hand);
						return;
					}
					List<string> list2 = new List<string>(list);
					if (!string.IsNullOrEmpty(GlobalSettings.Instance.BlacklistedProfileWords))
					{
						List<string> list3 = GlobalSettings.Instance.BlacklistedProfileWords.Split(',').ToList();
						for (int num = list.Count - 1; num >= 0; num--)
						{
							bool flag = false;
							string text4 = list[num];
							foreach (string item in list3)
							{
								if (text4.Contains(item))
								{
									flag = true;
									break;
								}
							}
							if (flag)
							{
								list.RemoveAt(num);
							}
						}
					}
					if (!string.IsNullOrEmpty(text3) && !string.IsNullOrEmpty(text2))
					{
						ilog_0.DebugFormat(global::_003CModule_003E.smethod_5<string>(3936250014u), Array.Empty<object>());
						ilog_0.DebugFormat(global::_003CModule_003E.smethod_9<string>(1866604521u) + text3, Array.Empty<object>());
						ilog_0.DebugFormat(global::_003CModule_003E.smethod_6<string>(2254030516u) + text2, Array.Empty<object>());
						ilog_0.DebugFormat(global::_003CModule_003E.smethod_7<string>(1925158670u) + OldProfileBaseName, Array.Empty<object>());
						string text5 = text3.Remove(text3.IndexOf(OldProfileBaseName, StringComparison.Ordinal), OldProfileBaseName.Length);
						if (!string.IsNullOrEmpty(text5))
						{
							ilog_0.DebugFormat(string.Format(global::_003CModule_003E.smethod_5<string>(3566802023u), text5, list2.Count), Array.Empty<object>());
							for (int num2 = list2.Count - 1; num2 >= 0; num2--)
							{
								string text6 = list2[num2];
								if (!text6.Contains(text5))
								{
									list2.RemoveAt(num2);
								}
							}
							ilog_0.DebugFormat(string.Format(global::_003CModule_003E.smethod_5<string>(4090204597u), list2.Count), Array.Empty<object>());
							list = list2;
						}
						else
						{
							ilog_0.DebugFormat(global::_003CModule_003E.smethod_8<string>(3858448806u), Array.Empty<object>());
						}
					}
					DirectoryInfo directoryInfo = new DirectoryInfo(list.ElementAt(LokiPoe.Random.Next(0, list.Count)));
					string name = directoryInfo.Name;
					ilog_0.DebugFormat(global::_003CModule_003E.smethod_8<string>(4029762591u) + name + global::_003CModule_003E.smethod_6<string>(290416213u), Array.Empty<object>());
					Stopwatch stopwatch2 = Stopwatch.StartNew();
					IO.DirectoryCopy(Path.Combine(GlobalSettings.Instance.ProfilesFolderPath, name), Path.Combine(JsonSettings.SettingsPath, name), copySubDirs: true);
					stopwatch2.Stop();
					ilog_0.DebugFormat(string.Format(global::_003CModule_003E.smethod_5<string>(2250007380u), stopwatch2.Elapsed), Array.Empty<object>());
					text3 = name;
					Misc.SaveProfile(text3);
				}
				text = text3;
			}
			else
			{
				text = ConfigComboBox.Text;
			}
			if (string.IsNullOrEmpty(text))
			{
				MessageBox.Show(LocExtension.GetLocalizedValue<string>(global::_003CModule_003E.smethod_8<string>(490099364u)), Util.RandomWindowTitle(LocExtension.GetLocalizedValue<string>(global::_003CModule_003E.smethod_8<string>(1970885692u))), MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			try
			{
				new FileInfo(text);
			}
			catch (Exception ex)
			{
				ilog_0.ErrorFormat(global::_003CModule_003E.smethod_5<string>(3853367934u), (object)ex);
				MessageBox.Show(LocExtension.GetLocalizedValue<string>(global::_003CModule_003E.smethod_7<string>(383938326u)), Util.RandomWindowTitle(LocExtension.GetLocalizedValue<string>(global::_003CModule_003E.smethod_8<string>(1970885692u))), MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			mainWindow_0.method_20(text);
			mainWindow_0.method_14();
		}
		catch (Exception ex2)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_6<string>(77785645u), ex2);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class28.Method9.method_1);
		}
	}

	private void method_1(object sender, RoutedEventArgs e)
	{
		ChooseConfigButton.Focus();
	}

	private void comboBox_0_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.Return || e.Key == Key.Return)
		{
			(new ButtonAutomationPeer(ChooseConfigButton).GetPattern(PatternInterface.Invoke) as IInvokeProvider).Invoke();
		}
	}
}
