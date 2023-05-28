using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using DreamPoeBot.Framework.Helpers;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Structures.ns11;
using DreamPoeBot.Structures.ns13;
using DreamPoeBot.WPFLocalizeExtension.Engine;
using DreamPoeBot.WPFLocalizeExtension.Extensions;
using log4net;
using MahApps.Metro.Controls;

namespace DreamPoeBot.DreamPoe;

public class MainWindow : MetroWindow, IComponentConnector
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly NotifyIcon notifyIcon_0;

	private BotWindow botWindow_0;

	private LanguageSelection languageSelection_0;

	private ConfigSelection configSelection_0;

	private LoginWindow loginWindow_0;

	private UpdateWindow updateWindow_0;

	private DownloadWindow downloadWindow_0;

	private ProcessSelectorWindow processSelectorWindow_0;

	internal Mutex mutex_0;

	internal Process process_0;

	public static RoutedCommand ChangeLanguageToEn = new RoutedCommand();

	public static RoutedCommand ChangeLanguageToRu = new RoutedCommand();

	public static RoutedCommand ChangeLanguageToDe = new RoutedCommand();

	public static RoutedCommand ChangeLanguageToFr = new RoutedCommand();

	public static RoutedCommand ChangeLanguageToEs = new RoutedCommand();

	public static RoutedCommand ChangeLanguageToZhCn = new RoutedCommand();

	public static RoutedCommand ChangeLanguageToInvariant = new RoutedCommand();

	public static RoutedCommand OpenSettingsWindow = new RoutedCommand();

	internal System.Windows.Controls.Label StatusBarLeftLabel;

	internal System.Windows.Controls.Label StatusBarRightLabel;

	internal TransitioningContentControl transitioningContentControl_0;

	internal System.Windows.Controls.Button TitleButton;

	internal System.Windows.Controls.Button ProcessButton;

	internal System.Windows.Controls.Button TimeLeftButton;

	internal System.Windows.Controls.Button SettingsButton;

	private bool _contentLoaded;

	internal NewSettingsWindow NewSettingsWindow_0 { get; private set; }

	protected override void OnSourceInitialized(EventArgs e)
	{
		try
		{
			((Window)this).OnSourceInitialized(e);
			(PresentationSource.FromVisual((Visual)(object)this) as HwndSource).AddHook(method_0);
		}
		catch (Exception ex)
		{
			ilog_0.ErrorFormat(global::_003CModule_003E.smethod_8<string>(3774883089u), (object)ex);
			throw;
		}
	}

	public bool IsAdministrator()
	{
		using WindowsIdentity ntIdentity = WindowsIdentity.GetCurrent();
		WindowsPrincipal windowsPrincipal = new WindowsPrincipal(ntIdentity);
		return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
	}

	private IntPtr method_0(IntPtr intptr_0, int int_0, IntPtr intptr_1, IntPtr intptr_2, ref bool bool_1)
	{
		if (LokiPoe.IsBotFullyLoaded && GlobalSettings.Instance.AllowExternalAccess)
		{
			if (int_0 >= 1024 && int_0 < 32768)
			{
				foreach (IPlugin enabledPlugin in PluginManager.EnabledPlugins)
				{
					DreamPoeBot.Loki.Bot.Message message = new DreamPoeBot.Loki.Bot.Message(global::_003CModule_003E.smethod_8<string>(2183820713u), this, intptr_0, int_0, intptr_1, intptr_2);
					if (enabledPlugin.Message(message) == MessageResult.Processed && message.Outputs.Any())
					{
						bool_1 = true;
						return message.GetOutput<IntPtr>();
					}
				}
			}
			return IntPtr.Zero;
		}
		return IntPtr.Zero;
	}

	private void method_1(object sender, ExecutedRoutedEventArgs e)
	{
		if (NewSettingsWindow_0 != null)
		{
			((UIElement)(object)NewSettingsWindow_0).Visibility = Visibility.Visible;
			((Window)(object)NewSettingsWindow_0).Activate();
		}
	}

	private void method_2(object sender, ExecutedRoutedEventArgs e)
	{
		LocalizeDictionary.Instance.Culture = CultureInfo.InvariantCulture;
		GlobalSettings.Instance.LastUsedLanguage = LocalizeDictionary.Instance.Culture.TwoLetterISOLanguageName.ToLowerInvariant();
	}

	private void method_3(object sender, ExecutedRoutedEventArgs e)
	{
		LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo(global::_003CModule_003E.smethod_5<string>(3654450942u));
		GlobalSettings.Instance.LastUsedLanguage = LocalizeDictionary.Instance.Culture.TwoLetterISOLanguageName.ToLowerInvariant();
	}

	private void method_4(object sender, ExecutedRoutedEventArgs e)
	{
		LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo(global::_003CModule_003E.smethod_5<string>(971132408u));
		GlobalSettings.Instance.LastUsedLanguage = LocalizeDictionary.Instance.Culture.TwoLetterISOLanguageName.ToLowerInvariant();
	}

	private void method_5(object sender, ExecutedRoutedEventArgs e)
	{
		LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo(global::_003CModule_003E.smethod_6<string>(683264345u));
		GlobalSettings.Instance.LastUsedLanguage = LocalizeDictionary.Instance.Culture.TwoLetterISOLanguageName.ToLowerInvariant();
	}

	private void method_6(object sender, ExecutedRoutedEventArgs e)
	{
		LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo(global::_003CModule_003E.smethod_6<string>(3414142675u));
		GlobalSettings.Instance.LastUsedLanguage = LocalizeDictionary.Instance.Culture.TwoLetterISOLanguageName.ToLowerInvariant();
	}

	private void method_7(object sender, ExecutedRoutedEventArgs e)
	{
		LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo(global::_003CModule_003E.smethod_9<string>(1427400111u));
		GlobalSettings.Instance.LastUsedLanguage = LocalizeDictionary.Instance.Culture.TwoLetterISOLanguageName.ToLowerInvariant();
	}

	private void method_8(object sender, ExecutedRoutedEventArgs e)
	{
		LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo(global::_003CModule_003E.smethod_5<string>(3031589872u));
		GlobalSettings.Instance.LastUsedLanguage = LocalizeDictionary.Instance.Culture.TwoLetterISOLanguageName.ToLowerInvariant();
	}

	public MainWindow()
	{
		InitializeComponent();
		ChangeLanguageToInvariant.InputGestures.Add(new KeyGesture(Key.D0, System.Windows.Input.ModifierKeys.Control));
		ChangeLanguageToEn.InputGestures.Add(new KeyGesture(Key.D1, System.Windows.Input.ModifierKeys.Control));
		ChangeLanguageToRu.InputGestures.Add(new KeyGesture(Key.D2, System.Windows.Input.ModifierKeys.Control));
		ChangeLanguageToFr.InputGestures.Add(new KeyGesture(Key.D3, System.Windows.Input.ModifierKeys.Control));
		ChangeLanguageToDe.InputGestures.Add(new KeyGesture(Key.D4, System.Windows.Input.ModifierKeys.Control));
		ChangeLanguageToEs.InputGestures.Add(new KeyGesture(Key.D5, System.Windows.Input.ModifierKeys.Control));
		ChangeLanguageToZhCn.InputGestures.Add(new KeyGesture(Key.D6, System.Windows.Input.ModifierKeys.Control));
		OpenSettingsWindow.InputGestures.Add(new KeyGesture(Key.Tab, System.Windows.Input.ModifierKeys.Control));
		try
		{
			notifyIcon_0 = new NotifyIcon
			{
				Icon = new Icon(System.Windows.Application.GetResourceStream(new Uri(global::_003CModule_003E.smethod_8<string>(2113771784u))).Stream),
				Visible = true
			};
			notifyIcon_0.DoubleClick += notifyIcon_0_DoubleClick;
			notifyIcon_0.Text = global::_003CModule_003E.smethod_5<string>(2870162469u);
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_8<string>(2887098237u), ex);
			Logger.OpenLogFile();
			((DispatcherObject)this).Dispatcher.Invoke(System.Windows.Application.Current.Shutdown);
		}
	}

	protected override void OnStateChanged(EventArgs e)
	{
		if (!GuiSettings.Instance.NoHideOnMinimize && ((Window)this).WindowState == WindowState.Minimized)
		{
			((Window)this).Hide();
		}
		((Window)this).OnStateChanged(e);
	}

	internal void method_9()
	{
		bool flag = true;
		if (!CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_7<string>(2989189588u)) && !GlobalSettings.Instance.AutoChooseLanguage)
		{
			try
			{
				if (GlobalSettings.Instance.LastUsedLanguage == global::_003CModule_003E.smethod_9<string>(909864983u))
				{
					LocalizeDictionary.Instance.Culture = CultureInfo.InvariantCulture;
				}
				else
				{
					LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo(GlobalSettings.Instance.LastUsedLanguage);
				}
			}
			catch (Exception ex)
			{
				ilog_0.Error((object)global::_003CModule_003E.smethod_5<string>(2082997750u), ex);
				GlobalSettings.Instance.LastUsedLanguage = global::_003CModule_003E.smethod_5<string>(3654450942u);
			}
		}
		else
		{
			string text = ((!GlobalSettings.Instance.AutoChooseLanguage) ? CommandLine.Arguments.Single(global::_003CModule_003E.smethod_5<string>(3841558357u)).ToLowerInvariant() : GlobalSettings.Instance.AutoLanguage);
			if (text == global::_003CModule_003E.smethod_5<string>(3654450942u))
			{
				LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo(global::_003CModule_003E.smethod_9<string>(3134691767u));
				flag = false;
			}
			else if (!(text == global::_003CModule_003E.smethod_9<string>(2630525717u)))
			{
				if (!(text == global::_003CModule_003E.smethod_6<string>(3414142675u)))
				{
					if (text == global::_003CModule_003E.smethod_9<string>(728440555u))
					{
						LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo(global::_003CModule_003E.smethod_6<string>(683264345u));
						flag = false;
					}
					else if (text == global::_003CModule_003E.smethod_7<string>(1718266313u))
					{
						LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo(global::_003CModule_003E.smethod_5<string>(1419941110u));
						flag = false;
					}
					else if (text == global::_003CModule_003E.smethod_6<string>(2247353311u))
					{
						LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo(global::_003CModule_003E.smethod_6<string>(2247353311u));
						flag = false;
					}
					else if (text == global::_003CModule_003E.smethod_8<string>(1967774213u))
					{
						LocalizeDictionary.Instance.Culture = CultureInfo.InvariantCulture;
						flag = false;
					}
					else
					{
						LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo(global::_003CModule_003E.smethod_8<string>(3880653541u));
					}
				}
				else
				{
					LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo(global::_003CModule_003E.smethod_9<string>(1931566161u));
					flag = false;
				}
			}
			else
			{
				LocalizeDictionary.Instance.Culture = CultureInfo.GetCultureInfo(global::_003CModule_003E.smethod_6<string>(2519105703u));
				flag = false;
			}
		}
		if (!flag)
		{
			method_10();
			return;
		}
		ContentControl contentControl = (ContentControl)(object)transitioningContentControl_0;
		LanguageSelection content;
		if ((content = languageSelection_0) == null)
		{
			content = (languageSelection_0 = new LanguageSelection(this));
		}
		contentControl.Content = content;
	}

	internal void method_10()
	{
		((ContentControl)(object)transitioningContentControl_0).Content = null;
		bool flag = true;
		bool flag2 = GlobalSettings.Instance.RandomizeProfileSelection;
		string profileBaseName = GlobalSettings.Instance.ProfileBaseName;
		if (CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_6<string>(185526975u)))
		{
			flag2 = true;
		}
		if (CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_7<string>(1623638382u)) || GlobalSettings.Instance.AutoChooseConfig)
		{
			string string_ = "";
			if (GlobalSettings.Instance.AutoChooseConfig)
			{
				string_ = GlobalSettings.Instance.LastUsedConfiguration;
			}
			if (CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_5<string>(3301579367u)))
			{
				string_ = CommandLine.Arguments.Single(global::_003CModule_003E.smethod_6<string>(2717755504u));
			}
			if (flag2)
			{
				ilog_0.DebugFormat(global::_003CModule_003E.smethod_9<string>(2512087765u), Array.Empty<object>());
				string newProfileBaseName = (string.IsNullOrEmpty(GlobalSettings.Instance.ProfileBaseName) ? "" : GlobalSettings.Instance.ProfileBaseName);
				if (CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_9<string>(1252660222u)))
				{
					newProfileBaseName = (string.IsNullOrEmpty(CommandLine.Arguments.Single(global::_003CModule_003E.smethod_7<string>(1623638382u))) ? "" : CommandLine.Arguments.Single(global::_003CModule_003E.smethod_6<string>(2717755504u)));
					if (!string.IsNullOrEmpty(newProfileBaseName))
					{
						ilog_0.DebugFormat(global::_003CModule_003E.smethod_5<string>(3015013456u) + newProfileBaseName + global::_003CModule_003E.smethod_5<string>(318371219u), Array.Empty<object>());
					}
					else
					{
						ilog_0.ErrorFormat(global::_003CModule_003E.smethod_9<string>(2462470367u), Array.Empty<object>());
					}
				}
				string text = Misc.LoadProfile();
				if (!string.IsNullOrEmpty(text) && (newProfileBaseName == null || text.Contains(newProfileBaseName)))
				{
					ilog_0.DebugFormat(global::_003CModule_003E.smethod_7<string>(839441486u) + text + global::_003CModule_003E.smethod_5<string>(3861656142u), Array.Empty<object>());
					Stopwatch stopwatch = Stopwatch.StartNew();
					IO.DirectoryCopy(Path.Combine(GlobalSettings.Instance.ProfilesFolderPath, text), Path.Combine(JsonSettings.SettingsPath, text), copySubDirs: true);
					stopwatch.Stop();
					ilog_0.DebugFormat(string.Format(global::_003CModule_003E.smethod_7<string>(3430626887u), stopwatch.Elapsed), Array.Empty<object>());
				}
				else
				{
					ilog_0.DebugFormat(string.IsNullOrEmpty(text) ? global::_003CModule_003E.smethod_5<string>(4247680549u) : (global::_003CModule_003E.smethod_6<string>(2726658444u) + text + global::_003CModule_003E.smethod_8<string>(2760517167u) + newProfileBaseName + global::_003CModule_003E.smethod_7<string>(379409418u)), Array.Empty<object>());
					if (string.IsNullOrEmpty(GlobalSettings.Instance.ProfilesFolderPath))
					{
						ilog_0.ErrorFormat(global::_003CModule_003E.smethod_7<string>(3011354991u), Array.Empty<object>());
						System.Windows.MessageBox.Show(global::_003CModule_003E.smethod_9<string>(3560527099u), global::_003CModule_003E.smethod_7<string>(555078556u), MessageBoxButton.OK, MessageBoxImage.Hand);
						return;
					}
					if (!Directory.Exists(GlobalSettings.Instance.ProfilesFolderPath))
					{
						ilog_0.ErrorFormat(global::_003CModule_003E.smethod_6<string>(3868338366u), Array.Empty<object>());
						System.Windows.MessageBox.Show(global::_003CModule_003E.smethod_9<string>(4078062227u), global::_003CModule_003E.smethod_5<string>(2021458925u), MessageBoxButton.OK, MessageBoxImage.Hand);
						return;
					}
					List<string> list = (from x in Directory.EnumerateDirectories(GlobalSettings.Instance.ProfilesFolderPath)
						where x.Contains(newProfileBaseName ?? "")
						select x).ToList();
					if (list.Count <= 0)
					{
						ilog_0.ErrorFormat(global::_003CModule_003E.smethod_5<string>(2274872004u) + newProfileBaseName + global::_003CModule_003E.smethod_6<string>(4140090758u) + GlobalSettings.Instance.ProfilesFolderPath + global::_003CModule_003E.smethod_6<string>(887988612u), Array.Empty<object>());
						System.Windows.MessageBox.Show(global::_003CModule_003E.smethod_8<string>(3862954402u) + newProfileBaseName + global::_003CModule_003E.smethod_9<string>(656794376u) + GlobalSettings.Instance.ProfilesFolderPath + global::_003CModule_003E.smethod_6<string>(887988612u), global::_003CModule_003E.smethod_8<string>(1451044624u), MessageBoxButton.OK, MessageBoxImage.Hand);
						return;
					}
					List<string> list2 = new List<string>(list);
					if (!string.IsNullOrEmpty(GlobalSettings.Instance.BlacklistedProfileWords))
					{
						List<string> list3 = GlobalSettings.Instance.BlacklistedProfileWords.Split(',').ToList();
						for (int num = list.Count - 1; num >= 0; num--)
						{
							bool flag3 = false;
							string text2 = list[num];
							foreach (string item in list3)
							{
								if (text2.Contains(item))
								{
									flag3 = true;
									break;
								}
							}
							if (flag3)
							{
								list.RemoveAt(num);
							}
						}
					}
					if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(newProfileBaseName))
					{
						ilog_0.DebugFormat(global::_003CModule_003E.smethod_7<string>(1244647521u), Array.Empty<object>());
						ilog_0.DebugFormat(global::_003CModule_003E.smethod_9<string>(1866604521u) + text, Array.Empty<object>());
						ilog_0.DebugFormat(global::_003CModule_003E.smethod_5<string>(434674787u) + newProfileBaseName, Array.Empty<object>());
						ilog_0.DebugFormat(global::_003CModule_003E.smethod_6<string>(1459431312u) + profileBaseName, Array.Empty<object>());
						string text3 = text.Remove(text.IndexOf(profileBaseName, StringComparison.Ordinal), profileBaseName.Length);
						if (string.IsNullOrEmpty(text3))
						{
							ilog_0.DebugFormat(global::_003CModule_003E.smethod_8<string>(3858448806u), Array.Empty<object>());
						}
						else
						{
							ilog_0.DebugFormat(string.Format(global::_003CModule_003E.smethod_9<string>(670163454u), text3, list2.Count), Array.Empty<object>());
							for (int num2 = list2.Count - 1; num2 >= 0; num2--)
							{
								string text4 = list2[num2];
								if (!text4.Contains(text3))
								{
									list2.RemoveAt(num2);
								}
							}
							ilog_0.DebugFormat(string.Format(global::_003CModule_003E.smethod_9<string>(1019643232u), list2.Count), Array.Empty<object>());
							list = list2;
						}
					}
					DirectoryInfo directoryInfo = new DirectoryInfo(list.ElementAt(LokiPoe.Random.Next(0, list.Count)));
					string name = directoryInfo.Name;
					if (!string.IsNullOrEmpty(GlobalSettings.Instance.ProfilesFolderPath) && Directory.Exists(GlobalSettings.Instance.ProfilesFolderPath))
					{
						ilog_0.DebugFormat(global::_003CModule_003E.smethod_9<string>(1893342677u) + name + global::_003CModule_003E.smethod_9<string>(1207752199u), Array.Empty<object>());
						Stopwatch stopwatch2 = Stopwatch.StartNew();
						IO.DirectoryCopy(Path.Combine(GlobalSettings.Instance.ProfilesFolderPath, name), Path.Combine(JsonSettings.SettingsPath, name), copySubDirs: true);
						stopwatch2.Stop();
						ilog_0.DebugFormat(string.Format(global::_003CModule_003E.smethod_9<string>(4626593u), stopwatch2.Elapsed), Array.Empty<object>());
					}
					else
					{
						ilog_0.DebugFormat(global::_003CModule_003E.smethod_9<string>(1893342677u) + name + global::_003CModule_003E.smethod_5<string>(3869944350u), Array.Empty<object>());
					}
					text = name;
					Misc.SaveProfile(text);
				}
				string_ = text;
			}
			try
			{
				method_20(string_);
				flag = false;
			}
			catch
			{
				System.Windows.MessageBox.Show(LocExtension.GetLocalizedValue<string>(global::_003CModule_003E.smethod_5<string>(1348868607u)), Util.RandomWindowTitle(LocExtension.GetLocalizedValue<string>(global::_003CModule_003E.smethod_9<string>(2652463084u))), MessageBoxButton.OK, MessageBoxImage.Hand);
			}
		}
		if (flag)
		{
			ContentControl contentControl = (ContentControl)(object)transitioningContentControl_0;
			ConfigSelection content;
			if ((content = configSelection_0) == null)
			{
				content = (configSelection_0 = new ConfigSelection(this));
			}
			contentControl.Content = content;
		}
		else
		{
			method_14();
		}
	}

	internal void method_11()
	{
		((ContentControl)(object)transitioningContentControl_0).Content = null;
		ContentControl contentControl = (ContentControl)(object)transitioningContentControl_0;
		LoginWindow content;
		if ((content = loginWindow_0) == null)
		{
			content = (loginWindow_0 = new LoginWindow(this));
		}
		contentControl.Content = content;
	}

	internal void method_12(string string_0)
	{
		((ContentControl)(object)transitioningContentControl_0).Content = null;
		ContentControl contentControl = (ContentControl)(object)transitioningContentControl_0;
		UpdateWindow content;
		if ((content = updateWindow_0) == null)
		{
			content = (updateWindow_0 = new UpdateWindow(this, string_0));
		}
		contentControl.Content = content;
	}

	internal void method_13(string string_0)
	{
		((ContentControl)(object)transitioningContentControl_0).Content = null;
		ContentControl contentControl = (ContentControl)(object)transitioningContentControl_0;
		DownloadWindow content;
		if ((content = downloadWindow_0) == null)
		{
			content = (downloadWindow_0 = new DownloadWindow(this, string_0));
		}
		contentControl.Content = content;
	}

	internal void method_14()
	{
		((ContentControl)(object)transitioningContentControl_0).Content = null;
		notifyIcon_0.Text = Configuration.Instance.Name;
		if (!CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_9<string>(1615509078u)) && !GlobalSettings.Instance.DisableUpdateCheck)
		{
			try
			{
				string text = new WebClient().DownloadString(global::_003CModule_003E.smethod_7<string>(1921108899u));
				Version version = new Version(text.Replace(global::_003CModule_003E.smethod_6<string>(281792966u), "").Replace(global::_003CModule_003E.smethod_5<string>(169183475u), ""));
				bool? flag = null;
				Version version2 = Assembly.GetEntryAssembly().GetName().Version;
				if (version == version2)
				{
					ilog_0.InfoFormat(global::_003CModule_003E.smethod_8<string>(2536853592u), (object)global::_003CModule_003E.smethod_7<string>(51673956u), (object)version2);
					method_11();
					return;
				}
				if (version2.Major >= version.Major && version2.Minor >= version.Minor && version2.Build >= version.Build && version2.Revision >= version.Revision)
				{
					ilog_0.InfoFormat(global::_003CModule_003E.smethod_7<string>(262616084u), (object)global::_003CModule_003E.smethod_7<string>(51673956u), (object)version2);
					method_11();
					return;
				}
				if (version2.Major < version.Major)
				{
					_ = version.Revision;
					_ = version2.Revision;
					string text2 = string.Format(global::_003CModule_003E.smethod_5<string>(1436517526u), global::_003CModule_003E.smethod_7<string>(51673956u), version2);
					ilog_0.ErrorFormat(text2, Array.Empty<object>());
					System.Windows.MessageBox.Show(text2, Util.RandomWindowTitle(global::_003CModule_003E.smethod_6<string>(2096696659u)), MessageBoxButton.OK, MessageBoxImage.Hand);
					Environment.Exit(0);
					return;
				}
				if (version < version2)
				{
					flag = true;
				}
				else if (version > version2)
				{
					flag = false;
				}
				if (flag.HasValue)
				{
					bool flag2;
					if (CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_9<string>(2643894795u)))
					{
						flag2 = true;
					}
					else
					{
						if (!flag.Value)
						{
							string string_ = AppDomain.CurrentDomain.FriendlyName.Replace(global::_003CModule_003E.smethod_6<string>(239594590u), "");
							method_12(string_);
							return;
						}
						flag2 = false;
					}
					if (flag2)
					{
						string string_2 = AppDomain.CurrentDomain.FriendlyName.Replace(global::_003CModule_003E.smethod_9<string>(578884784u), "");
						method_13(string_2);
					}
				}
			}
			catch (Exception ex)
			{
				((ContentControl)(object)transitioningContentControl_0).Content = null;
				ilog_0.Error((object)global::_003CModule_003E.smethod_9<string>(4209869257u), ex);
			}
		}
		else
		{
			ilog_0.Info((object)global::_003CModule_003E.smethod_7<string>(3561486082u));
		}
		if (((ContentControl)(object)transitioningContentControl_0).Content == null)
		{
			method_11();
		}
	}

	internal void method_15(Process process_1)
	{
		try
		{
			if (process_1.HasExited)
			{
				return;
			}
			mutex_0 = Class98.smethod_0(process_1.Id, out var _);
			process_0 = process_1;
		}
		catch (Exception)
		{
			mutex_0 = null;
			process_0 = null;
			return;
		}
		method_18();
	}

	internal bool method_16()
	{
		if (Class98.smethod_1(out mutex_0, out process_0))
		{
			method_18();
			return true;
		}
		return false;
	}

	internal void method_17()
	{
		((ContentControl)(object)transitioningContentControl_0).Content = null;
		ContentControl contentControl = (ContentControl)(object)transitioningContentControl_0;
		ProcessSelectorWindow content;
		if ((content = processSelectorWindow_0) == null)
		{
			content = (processSelectorWindow_0 = new ProcessSelectorWindow(this));
		}
		contentControl.Content = content;
	}

	internal void method_18()
	{
		((ContentControl)(object)transitioningContentControl_0).Content = null;
		ProcessButton.Visibility = Visibility.Visible;
		ProcessButton.Content = string.Format(global::_003CModule_003E.smethod_8<string>(1479149072u), process_0.Id);
		SettingsButton.Visibility = Visibility.Visible;
		ContentControl contentControl = (ContentControl)(object)transitioningContentControl_0;
		BotWindow content;
		if ((content = botWindow_0) == null)
		{
			content = (botWindow_0 = new BotWindow(this));
		}
		contentControl.Content = content;
		NewSettingsWindow newSettingsWindow_;
		if ((newSettingsWindow_ = NewSettingsWindow_0) == null)
		{
			NewSettingsWindow newSettingsWindow2 = (NewSettingsWindow_0 = new NewSettingsWindow(this));
			newSettingsWindow_ = newSettingsWindow2;
		}
		NewSettingsWindow_0 = newSettingsWindow_;
		((UIElement)(object)NewSettingsWindow_0).Visibility = Visibility.Collapsed;
		((System.Windows.Controls.Control)(object)transitioningContentControl_0).VerticalContentAlignment = VerticalAlignment.Stretch;
		DispatcherTimer dispatcherTimer = new DispatcherTimer();
		dispatcherTimer.Interval = TimeSpan.FromSeconds(30.0);
		dispatcherTimer.Tick += timer_Tick;
		dispatcherTimer.Start();
	}

	internal void timer_Tick(object sender, EventArgs e)
	{
		string timeLeft = Class104.GetTimeLeft();
		long num = long.Parse(timeLeft);
		TimeSpan timeSpan = TimeSpan.FromSeconds(num);
		TimeLeftButton.Content = string.Format(string.Format(global::_003CModule_003E.smethod_5<string>(1337059030u), timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds));
	}

	private void method_19(object sender, RoutedEventArgs e)
	{
		try
		{
			Window window = Window.GetWindow((DependencyObject)(object)this);
			LokiPoe.BotWindowHandle = new WindowInteropHelper(window).Handle;
			LokiPoe.BotWindow = window;
			SettingsButton.Visibility = Visibility.Collapsed;
			ProcessButton.Visibility = Visibility.Collapsed;
			if (!IsAdministrator())
			{
				System.Windows.MessageBox.Show(global::_003CModule_003E.smethod_6<string>(1226769129u), global::_003CModule_003E.smethod_7<string>(4151898208u));
				((DispatcherObject)this).Dispatcher.Invoke(System.Windows.Application.Current.Shutdown);
			}
			else
			{
				method_9();
			}
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_8<string>(2887098237u), ex);
			Logger.OpenLogFile();
			((DispatcherObject)this).Dispatcher.Invoke(System.Windows.Application.Current.Shutdown);
		}
	}

	internal void method_20(string string_0)
	{
		if (string_0.ToLower() == global::_003CModule_003E.smethod_9<string>(2835890411u))
		{
			Configuration.Instance.Name = GlobalSettings.Instance.LastUsedConfiguration;
		}
		else
		{
			GlobalSettings.Instance.LastUsedConfiguration = string_0;
			Configuration.Instance.Name = string_0;
		}
		bool flag = false;
		bool flag2 = false;
		Screen[] allScreens = Screen.AllScreens;
		foreach (Screen screen in allScreens)
		{
			if (screen.WorkingArea.Contains(GuiSettings.Instance.WindowX, GuiSettings.Instance.WindowY))
			{
				flag = true;
			}
			if (screen.WorkingArea.Contains(GuiSettings.Instance.SettingsWindowX, GuiSettings.Instance.SettingsWindowY))
			{
				flag2 = true;
			}
		}
		if (!flag)
		{
			GuiSettings.Instance.WindowX = 0;
			GuiSettings.Instance.WindowY = 0;
			GuiSettings.Instance.WindowWidth = 627;
			GuiSettings.Instance.WindowHeight = 755;
		}
		if (!flag2)
		{
			GuiSettings.Instance.SettingsWindowX = 0;
			GuiSettings.Instance.SettingsWindowY = 0;
			GuiSettings.Instance.SettingsWindowWidth = 627;
			GuiSettings.Instance.SettingsWindowHeight = 477;
		}
		if (GuiSettings.Instance.WindowX == 0 && GuiSettings.Instance.WindowY == 0 && GuiSettings.Instance.WindowWidth == 627 && GuiSettings.Instance.WindowHeight == 477)
		{
			GuiSettings.Instance.WindowX = (int)((Window)this).Left;
			GuiSettings.Instance.WindowY = (int)((Window)this).Top;
			GuiSettings.Instance.WindowWidth = (int)((FrameworkElement)this).Width;
			GuiSettings.Instance.WindowHeight = (int)((FrameworkElement)this).Height;
			GuiSettings.Instance.SettingsWindowX = (int)((Window)this).Left;
			GuiSettings.Instance.SettingsWindowY = (int)((Window)this).Top;
			GuiSettings.Instance.SettingsWindowWidth = (int)((FrameworkElement)this).Width;
			GuiSettings.Instance.SettingsWindowHeight = (int)((FrameworkElement)this).Height;
		}
		((DispatcherObject)this).Dispatcher.BeginInvoke(new Action(method_23));
	}

	private void button_3_Click(object sender, RoutedEventArgs e)
	{
		((UIElement)(object)NewSettingsWindow_0).Visibility = Visibility.Visible;
		((Window)(object)NewSettingsWindow_0).Activate();
		Configuration.Instance.SaveAll();
	}

	private void button_2_Click(object sender, RoutedEventArgs e)
	{
	}

	private void button_1_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			Interop.SwitchToThisWindow(LokiPoe.ClientWindowHandle, turnOn: true);
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_9<string>(226158255u), ex);
		}
	}

	private void method_21(object sender, CancelEventArgs e)
	{
		try
		{
			notifyIcon_0.Visible = false;
			notifyIcon_0.Icon = null;
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_5<string>(2082997750u), ex);
		}
	}

	private void method_22(object sender, EventArgs e)
	{
		try
		{
			if (botWindow_0 != null)
			{
				botWindow_0.method_0(sender, e);
			}
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_5<string>(2082997750u), ex);
		}
		Class104.smethod_0();
		if (botWindow_0 != null)
		{
			GuiSettings.Instance.SaveRowDefinitions(botWindow_0.TopRowDefinition, botWindow_0.SplitterRowDefinition, botWindow_0.BottomRowDefinition);
		}
		Configuration.Instance.SaveAll();
		PluginManager.smethod_5();
		PlayerMoverManager.smethod_2();
		RoutineManager.smethod_2();
		BotManager.smethod_6Deinitializer();
		ContentManager.smethod_1();
		foreach (object window2 in System.Windows.Application.Current.Windows)
		{
			Window window = (Window)window2;
			if (window.IsVisible)
			{
				window.Close();
			}
		}
		if (mutex_0 != null)
		{
			mutex_0.Dispose();
			mutex_0 = null;
		}
		if (process_0 != null)
		{
			process_0.Dispose();
			process_0 = null;
		}
		try
		{
			System.Windows.Application.Current.Shutdown();
		}
		catch
		{
		}
	}

	private void notifyIcon_0_DoubleClick(object sender, EventArgs e)
	{
		try
		{
			((Window)this).Show();
			((Window)this).WindowState = WindowState.Normal;
			Interop.SwitchToThisWindow(LokiPoe.BotWindowHandle, turnOn: true);
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_8<string>(2887098237u), ex);
		}
	}

	private void method_23()
	{
		((FrameworkElement)this).SetBinding(Window.LeftProperty, (BindingBase)new System.Windows.Data.Binding(global::_003CModule_003E.smethod_9<string>(620546056u))
		{
			Source = GuiSettings.Instance,
			Mode = BindingMode.TwoWay
		});
		((FrameworkElement)this).SetBinding(Window.TopProperty, (BindingBase)new System.Windows.Data.Binding(global::_003CModule_003E.smethod_6<string>(3882319133u))
		{
			Source = GuiSettings.Instance,
			Mode = BindingMode.TwoWay
		});
		((FrameworkElement)this).SetBinding(FrameworkElement.WidthProperty, (BindingBase)new System.Windows.Data.Binding(global::_003CModule_003E.smethod_8<string>(603163646u))
		{
			Source = GuiSettings.Instance,
			Mode = BindingMode.TwoWay
		});
		((FrameworkElement)this).SetBinding(FrameworkElement.HeightProperty, (BindingBase)new System.Windows.Data.Binding(global::_003CModule_003E.smethod_6<string>(555491400u))
		{
			Source = GuiSettings.Instance,
			Mode = BindingMode.TwoWay
		});
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocator = new Uri(global::_003CModule_003E.smethod_6<string>(1722280764u), UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocator);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		switch (connectionId)
		{
		default:
			_contentLoaded = true;
			break;
		case 1:
			((FrameworkElement)(object)(MainWindow)target).Loaded += method_19;
			((Window)(object)(MainWindow)target).Closing += method_21;
			((Window)(object)(MainWindow)target).Closed += method_22;
			break;
		case 2:
			((CommandBinding)target).Executed += method_2;
			break;
		case 3:
			((CommandBinding)target).Executed += method_3;
			break;
		case 4:
			((CommandBinding)target).Executed += method_7;
			break;
		case 5:
			((CommandBinding)target).Executed += method_5;
			break;
		case 6:
			((CommandBinding)target).Executed += method_6;
			break;
		case 7:
			((CommandBinding)target).Executed += method_4;
			break;
		case 8:
			((CommandBinding)target).Executed += method_8;
			break;
		case 9:
			((CommandBinding)target).Executed += method_1;
			break;
		case 10:
			StatusBarLeftLabel = (System.Windows.Controls.Label)target;
			break;
		case 11:
			StatusBarRightLabel = (System.Windows.Controls.Label)target;
			break;
		case 12:
			transitioningContentControl_0 = (TransitioningContentControl)target;
			break;
		case 13:
			TitleButton = (System.Windows.Controls.Button)target;
			break;
		case 14:
			ProcessButton = (System.Windows.Controls.Button)target;
			ProcessButton.Click += button_1_Click;
			break;
		case 15:
			TimeLeftButton = (System.Windows.Controls.Button)target;
			break;
		case 16:
			SettingsButton = (System.Windows.Controls.Button)target;
			SettingsButton.Click += button_3_Click;
			break;
		}
	}
}
