using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Threading;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Elements;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Structures.ns13;
using DreamPoeBot.WPFLocalizeExtension.Extensions;
using log4net;
using log4net.Core;
using MahApps.Metro.Controls;

namespace DreamPoeBot.DreamPoe;

public partial class BotWindow : System.Windows.Controls.UserControl, IComponentConnector
{
	[Serializable]
	private sealed class Class21
	{
		public static readonly Class21 Class9 = new Class21();

		internal void method_0()
		{
			System.Windows.Application.Current.Shutdown();
		}

		internal void method_1()
		{
			LokiPoe.BotWindow.Show();
			LokiPoe.BotWindow.WindowState = System.Windows.WindowState.Normal;
			Interop.SwitchToThisWindow(LokiPoe.BotWindowHandle, turnOn: true);
		}

		internal void method_2(object sender, EventArgs e)
		{
			ilog_0.Info((object)global::_003CModule_003E.smethod_8<string>(2207742810u));
			Class104.smethod_0();
			Environment.Exit(0);
		}

		internal bool method_3(StringEntry stringEntry_0)
		{
			return !string.IsNullOrEmpty(stringEntry_0.Name);
		}

		internal string method_4(StringEntry stringEntry_0)
		{
			return stringEntry_0.Name.ToLowerInvariant();
		}

		internal void method_5()
		{
			System.Windows.Application.Current.Shutdown((int)LokiPoe.ApplicationExitCodes_0);
		}

		internal void method_6()
		{
			System.Windows.Application.Current.Shutdown((int)LokiPoe.ApplicationExitCodes_0);
		}

		internal bool method_7(StringEntry stringEntry_0)
		{
			return !string.IsNullOrEmpty(stringEntry_0.Name);
		}

		internal string method_8(StringEntry stringEntry_0)
		{
			return stringEntry_0.Name;
		}

		internal bool method_9(IBot ibot_0)
		{
			return !string.IsNullOrEmpty(ibot_0.Name);
		}

		internal bool method_10(IRoutine iroutine_0)
		{
			return !string.IsNullOrEmpty(iroutine_0.Name);
		}

		internal void method_11(Hotkey hotkey_0)
		{
			if (BotManager.IsRunning)
			{
				if (!BotManager.IsStopping)
				{
					BotManager.Stop(new StopReasonData(global::_003CModule_003E.smethod_9<string>(435262714u), global::_003CModule_003E.smethod_5<string>(1826063302u)));
				}
			}
			else
			{
				BotManager.Start();
			}
		}

		internal void method_12(Hotkey hotkey_0)
		{
			if (LokiPoe.Initialized)
			{
				LokiPoe.BotWindow.Dispatcher.BeginInvoke(new Action(Class9.method_13));
			}
		}

		internal void method_13()
		{
			LokiPoe.BotWindow.Show();
			LokiPoe.BotWindow.WindowState = System.Windows.WindowState.Normal;
			Interop.SwitchToThisWindow(LokiPoe.BotWindowHandle, turnOn: true);
		}

		internal void method_14(Hotkey hotkey_0)
		{
			MouseManager.DebugCursor = !MouseManager.DebugCursor;
			ilog_0.WarnFormat(global::_003CModule_003E.smethod_5<string>(2627743579u), (object)(MouseManager.DebugCursor ? global::_003CModule_003E.smethod_9<string>(3406261953u) : global::_003CModule_003E.smethod_8<string>(2045440217u)));
		}

		internal void method_15(Hotkey hotkey_0)
		{
			HookManager.RemoveHook();
		}

		internal void method_16(Hotkey hotkey_0)
		{
			HookManager.InstallHook();
		}

		internal void method_17(Hotkey hotkey_0)
		{
			HookManager.ResetKeyState();
		}

		internal void method_18(Hotkey hotkey_0)
		{
			if (LokiPoe.IsInGame)
			{
				Vector2i myPosition = LokiPoe.LocalData.MyPosition;
				ilog_0.InfoFormat(global::_003CModule_003E.smethod_9<string>(2330663337u), (object)LokiPoe.TerrainData.TgtUnderPlayer.TgtName, (object)(myPosition.X / 23), (object)(myPosition.Y / 23));
			}
		}

		internal void method_DumpPassive(Hotkey hotkey_0)
		{
			if (GameStateController.IsInGameState)
			{
				if (GameStateController.IsEscapeState)
				{
					return;
				}
				LogFrameUnderCursor();
				if (LokiPoe.InGameState.SkillsUi.IsOpened)
				{
					long frameUnderCursor = LokiPoe.InGameState.FrameUnderCursor;
					if (frameUnderCursor != 0L)
					{
						Dat.BuildPassinveLookupTable();
						DatPassiveSkillWrapper datPassiveSkillWrapper = LokiPoe.InGameState.SkillsUi.PassiveDumpEventFunction(frameUnderCursor);
						if (datPassiveSkillWrapper != null)
						{
							LokiPoe.InGameState.SkillsUi.DumpPassive(datPassiveSkillWrapper);
						}
					}
				}
				else
				{
					if (!LokiPoe.InGameState.AtlasSkillsUi.IsOpened)
					{
						return;
					}
					long frameUnderCursor2 = LokiPoe.InGameState.FrameUnderCursor;
					if (frameUnderCursor2 != 0L)
					{
						Dat.BuildPassinveLookupTable();
						DatPassiveSkillWrapper datPassiveSkillWrapper2 = LokiPoe.InGameState.AtlasSkillsUi.smethod_1(frameUnderCursor2);
						if (datPassiveSkillWrapper2 != null)
						{
							LokiPoe.InGameState.AtlasSkillsUi.smethod_0(datPassiveSkillWrapper2);
						}
					}
				}
			}
			else if (!LokiPoe.IsInLoginScreen)
			{
				_ = LokiPoe.IsInCharacterSelectionScreen;
			}
		}

		private void LogFrameUnderCursor()
		{
			long frameUnderCursor = LokiPoe.InGameState.FrameUnderCursor;
			string text = global::_003CModule_003E.smethod_7<string>(1929687578u) + frameUnderCursor.ToString(global::_003CModule_003E.smethod_5<string>(3548926522u));
			Element element = LokiPoe.Memory.GetObject<Element>(frameUnderCursor);
			if (element.IdLabel == global::_003CModule_003E.smethod_6<string>(1715000820u))
			{
				text = global::_003CModule_003E.smethod_6<string>(3646804858u) + text;
			}
			else
			{
				while (element.Parent.IdLabel != global::_003CModule_003E.smethod_7<string>(3489707106u))
				{
					Element parent = element.Parent;
					int num = (int)parent.ChildCount - 1;
					while (num >= 0)
					{
						if (parent.Children[num].Address != element.Address)
						{
							num--;
							continue;
						}
						text = string.Format(global::_003CModule_003E.smethod_9<string>(92467475u), num) + text;
						break;
					}
					element = parent;
				}
				Element parent2 = element.Parent;
				int num2 = (int)parent2.ChildCount - 1;
				while (num2 >= 0)
				{
					if (parent2.Children[num2].Address != element.Address)
					{
						num2--;
						continue;
					}
					text = string.Format(global::_003CModule_003E.smethod_9<string>(267207364u), num2) + text;
					break;
				}
			}
			ilog_0.DebugFormat(text, Array.Empty<object>());
		}

		internal void method_DumpDelve(Hotkey hotkey_0)
		{
			if (GameStateController.IsInGameState)
			{
				if (GameStateController.IsEscapeState)
				{
					return;
				}
				long frameUnderCursor = LokiPoe.InGameState.FrameUnderCursor;
				if (frameUnderCursor != 0L)
				{
					Dat.BuildPassinveLookupTable();
					SubterainChartElement.DelveNode @object = LokiPoe.Memory.GetObject<SubterainChartElement.DelveNode>(frameUnderCursor);
					if (@object != null)
					{
						LokiPoe.InGameState.DelveSubterrainChartUi.DumpNode(@object);
					}
				}
			}
			else if (!LokiPoe.IsInLoginScreen)
			{
				_ = LokiPoe.IsInCharacterSelectionScreen;
			}
		}

		internal void method_ToggleRender(Hotkey hotkey_0)
		{
			if (LokiPoe.ClientFunctions.IsRenderEnabled)
			{
				LokiPoe.ClientFunctions.DisableRender();
			}
			else
			{
				LokiPoe.ClientFunctions.EnableRender();
			}
		}

		internal void method_20()
		{
			System.Windows.Application.Current.Shutdown((int)LokiPoe.ApplicationExitCodes_0);
		}

		internal System.Windows.WindowState method_21()
		{
			System.Windows.Application.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
			return System.Windows.WindowState.Minimized;
		}

		internal void method_22()
		{
			System.Windows.Application.Current.Shutdown();
		}
	}

	private sealed class Class22
	{
		public string string_0;

		internal bool method_0(IBot ibot_0)
		{
			return ibot_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class23
	{
		public string string_0;

		internal bool method_0(IBot ibot_0)
		{
			return ibot_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class24
	{
		public string string_0;

		internal bool method_0(IRoutine iroutine_0)
		{
			return iroutine_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class25
	{
		public string string_0;

		internal bool method_0(IRoutine iroutine_0)
		{
			return iroutine_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class26
	{
		public BotWindow botWindow_0;

		public BotChangedEventArgs botChangedEventArgs_0;

		internal void method_0()
		{
			botWindow_0.BotsComboBox.SelectedItem = botChangedEventArgs_0.New;
		}
	}

	private sealed class Class27
	{
		public BotWindow botWindow_0;

		public RoutineChangedEventArgs routineChangedEventArgs_0;

		internal void method_0()
		{
			botWindow_0.RoutinesComboBox.SelectedItem = routineChangedEventArgs_0.New;
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly MainWindow mainWindow_0;

	private DispatcherTimer dispatcherTimer_0;

	private bool bool_0 = true;

	private DispatcherTimer dispatcherTimer_1;

	private bool bool_1;

	internal ToggleSwitch RenderSwitch;

	internal void method_0(object sender, EventArgs e)
	{
		if (dispatcherTimer_0 != null)
		{
			dispatcherTimer_0.Stop();
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		if (LokiPoe.IsBotFullyLoaded)
		{
			base.Dispatcher.BeginInvoke(new Action(method_8));
		}
	}

	public BotWindow(MainWindow mainWindow)
	{
		try
		{
			mainWindow_0 = mainWindow;
			InitializeComponent();
			Logger.AddWpfListener(ScrollLog, LogRichTextBox);
			GuiSettings.Instance.LoadRowDefinitions(TopRowDefinition, SplitterRowDefinition, BottomRowDefinition);
			TextboxLogFileName.Text = Logger.FileName;
			mainWindow_0.TitleButton.Content = string.Concat(global::_003CModule_003E.smethod_7<string>(51673956u), global::_003CModule_003E.smethod_6<string>(618461955u), Assembly.GetEntryAssembly().GetName().Version, global::_003CModule_003E.smethod_5<string>(1784353606u));
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_7<string>(415161545u), ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class21.Class9.method_0);
		}
	}

	private void menuItem_2_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			Logger.Clear();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_5<string>(1920754959u), ex);
		}
	}

	private void menuItem_0_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			System.Windows.Clipboard.SetText(Logger.FileName);
			ilog_0.DebugFormat(global::_003CModule_003E.smethod_9<string>(2626054640u), (object)LocExtension.GetLocalizedValue<string>(global::_003CModule_003E.smethod_6<string>(2237824014u)), (object)Logger.FileName.Replace(Environment.UserName, global::_003CModule_003E.smethod_7<string>(1753743718u)));
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_7<string>(3019933670u), ex);
		}
	}

	private void menuItem_1_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			string text = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
			Directory.CreateDirectory(text);
			File.Copy(Logger.FileName, Path.Combine(text, Path.GetFileName(Logger.FileName)));
			string text2 = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName().Replace(global::_003CModule_003E.smethod_5<string>(318371219u), "")) + global::_003CModule_003E.smethod_8<string>(2846871118u);
			ZipFile.CreateFromDirectory(text, text2);
			System.Windows.Clipboard.SetText(text2);
			ilog_0.DebugFormat(global::_003CModule_003E.smethod_9<string>(2626054640u), (object)LocExtension.GetLocalizedValue<string>(global::_003CModule_003E.smethod_7<string>(509789476u)), (object)text2);
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)string.Format(global::_003CModule_003E.smethod_8<string>(241643127u), LocExtension.GetLocalizedValue<string>(global::_003CModule_003E.smethod_5<string>(733050275u))), ex);
		}
	}

	private void method_2(object sender, RoutedEventArgs e)
	{
		ThreadPool.QueueUserWorkItem(method_9);
	}

	private void method_3(IBot ibot_0)
	{
		if (bool_0)
		{
			base.Dispatcher.BeginInvoke(new Action(method_15));
		}
	}

	private void method_4(IBot ibot_0)
	{
		if (bool_0)
		{
			base.Dispatcher.BeginInvoke(new Action(method_16));
		}
	}

	private void button_0_Click(object sender, RoutedEventArgs e)
	{
		Configuration.Instance.SaveAll();
		StartStopButton.IsEnabled = false;
		BotsComboBox.IsEnabled = false;
		RoutinesComboBox.IsEnabled = false;
		try
		{
			bool_0 = false;
			if (BotManager.IsRunning)
			{
				BotManager.Stop(new StopReasonData(global::_003CModule_003E.smethod_9<string>(71471983u), global::_003CModule_003E.smethod_8<string>(2554875976u)));
			}
			else
			{
				BotManager.Start();
			}
		}
		finally
		{
			bool_0 = true;
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		StartStopButton.IsEnabled = true;
		bool flag = !BotManager.IsRunning;
		BotsComboBox.IsEnabled = flag;
		RoutinesComboBox.IsEnabled = flag;
		ForceStopButton.IsEnabled = !flag;
		StartStopButton.Content = ((!flag) ? LocExtension.GetLocalizedValue<string>(global::_003CModule_003E.smethod_6<string>(3329285052u)) : LocExtension.GetLocalizedValue<string>(global::_003CModule_003E.smethod_6<string>(1194356125u)));
	}

	private void method_RenderOff()
	{
		RenderSwitch.IsChecked = false;
		LokiPoe.ClientFunctions.DisableRender();
	}

	private void method_RenderOn()
	{
		RenderSwitch.IsChecked = true;
		LokiPoe.ClientFunctions.EnableRender();
	}

	private void comboBox_0_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		try
		{
			IBot bot2 = (BotManager.Current = BotsComboBox.SelectedItem as IBot);
			if (bot2 != null)
			{
				GuiSettings.Instance.LastBot = bot2.Name;
			}
			Configuration.Instance.SaveAll();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_8<string>(1646280506u), ex);
		}
	}

	private void comboBox_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		try
		{
			IRoutine routine2 = (RoutineManager.Current = RoutinesComboBox.SelectedItem as IRoutine);
			if (routine2 != null)
			{
				GuiSettings.Instance.LastRoutine = routine2.Name;
			}
			Configuration.Instance.SaveAll();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_7<string>(3019933670u), ex);
		}
	}

	private void LogLevelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		try
		{
			ComboBoxItem comboBoxItem = (ComboBoxItem)LogLevelComboBox.SelectedItem;
			string logLevel = comboBoxItem.Content.ToString();
			GuiSettings.Instance.LogLevel = logLevel;
			Configuration.Instance.SaveAll();
			if (!BotManager.IsRunning)
			{
				return;
			}
			string logLevel2 = GuiSettings.Instance.LogLevel;
			if (!(logLevel2 == global::_003CModule_003E.smethod_7<string>(3436593206u)))
			{
				if (!(logLevel2 == global::_003CModule_003E.smethod_9<string>(1384467252u)))
				{
					if (logLevel2 == global::_003CModule_003E.smethod_6<string>(352413747u))
					{
						Logger.ChangeLogFilterLevel(Level.Off, Level.Off);
					}
					else
					{
						Logger.ChangeLogFilterLevel(Level.Verbose, Level.Emergency);
					}
				}
				else
				{
					Logger.ChangeLogFilterLevel(Level.Warn, Level.Error);
				}
			}
			else
			{
				Logger.ChangeLogFilterLevel(Level.Verbose, Level.Emergency);
			}
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_6<string>(3479941704u), ex);
		}
	}

	private void method_6(object sender, BotChangedEventArgs e)
	{
		Class26 @class = new Class26();
		@class.botWindow_0 = this;
		@class.botChangedEventArgs_0 = e;
		base.Dispatcher.BeginInvoke(new Action(@class.method_0));
	}

	private void method_7(object sender, RoutineChangedEventArgs e)
	{
		Class27 @class = new Class27();
		@class.botWindow_0 = this;
		@class.routineChangedEventArgs_0 = e;
		base.Dispatcher.BeginInvoke(new Action(@class.method_0));
	}

	private void button_1_Click(object sender, RoutedEventArgs e)
	{
		if (BotManager.IsRunning && System.Windows.MessageBox.Show(LocExtension.GetLocalizedValue<string>(global::_003CModule_003E.smethod_5<string>(217935909u)), Util.RandomWindowTitle(LocExtension.GetLocalizedValue<string>(global::_003CModule_003E.smethod_7<string>(1298515280u))), MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
		{
			ForceStopButton.IsEnabled = false;
			HookManager.ResetKeyState();
			HookManager.RemoveHook();
			BotManager.Stop(force: true);
		}
	}

	private void method_8()
	{
		try
		{
			LokiPoe.smethod_5((Window)(object)mainWindow_0);
		}
		catch (Exception ex)
		{
			ilog_0.Debug((object)global::_003CModule_003E.smethod_8<string>(3415950497u), ex);
		}
	}

	private void method_9(object object_0)
	{
		try
		{
			if (!GlobalSettings.Instance.DontAutoFocusGameWindow)
			{
				Interop.SwitchToThisWindow(Interop.smethod_0(mainWindow_0.process_0, global::_003CModule_003E.smethod_5<string>(1746702591u)), turnOn: true);
			}
			if (!GlobalSettings.Instance.HookCompatibility0 && !CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_7<string>(793673269u)))
			{
				if (GlobalSettings.Instance.HookCompatibility1)
				{
					LokiPoe.int_0 = GlobalSettings.Instance.HookCompatibilityDepth;
					ilog_0.InfoFormat(global::_003CModule_003E.smethod_6<string>(1119027799u), (object)LokiPoe.int_0);
				}
				else if (CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_8<string>(2902009142u)))
				{
					LokiPoe.int_0 = int.Parse(CommandLine.Arguments.Single(global::_003CModule_003E.smethod_9<string>(2148297034u)));
					ilog_0.InfoFormat(global::_003CModule_003E.smethod_5<string>(3636629056u), (object)LokiPoe.int_0);
				}
			}
			else
			{
				LokiPoe.bool_2 = true;
				ilog_0.InfoFormat(global::_003CModule_003E.smethod_7<string>(1375027579u), (object)true);
			}
			if (LokiPoe.smethod_1(mainWindow_0.process_0, Class104.smethod_6, out var string_))
			{
				if (!GlobalSettings.Instance.DontAutoFocusBotWindow)
				{
					base.Dispatcher.BeginInvoke(new Action(Class21.Class9.method_1));
				}
				string[] array = new string[11]
				{
					global::_003CModule_003E.smethod_8<string>(807410720u),
					global::_003CModule_003E.smethod_5<string>(3620052640u),
					global::_003CModule_003E.smethod_9<string>(1469391095u),
					global::_003CModule_003E.smethod_7<string>(3141735049u),
					global::_003CModule_003E.smethod_6<string>(2781328798u),
					global::_003CModule_003E.smethod_5<string>(969886938u),
					global::_003CModule_003E.smethod_7<string>(3826775106u),
					global::_003CModule_003E.smethod_7<string>(1289457464u),
					global::_003CModule_003E.smethod_8<string>(3576858973u),
					global::_003CModule_003E.smethod_9<string>(3895695924u),
					global::_003CModule_003E.smethod_9<string>(797169695u)
				};
				foreach (string path in array)
				{
					string text = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), path);
					try
					{
						AssemblyName[] referencedAssemblies = Assembly.LoadFrom(text).GetReferencedAssemblies();
						foreach (AssemblyName assemblyRef in referencedAssemblies)
						{
							try
							{
								Assembly.Load(assemblyRef);
							}
							catch (Exception ex)
							{
								ilog_0.Warn((object)global::_003CModule_003E.smethod_9<string>(2860625668u), ex);
							}
						}
					}
					catch (FileLoadException)
					{
						ilog_0.Error((object)global::_003CModule_003E.smethod_9<string>(454374456u));
					}
					catch (Exception ex3)
					{
						ilog_0.Warn((object)global::_003CModule_003E.smethod_6<string>(2831547682u), ex3);
						try
						{
							AssemblyName[] referencedAssemblies2 = Assembly.Load(text).GetReferencedAssemblies();
							foreach (AssemblyName assemblyRef2 in referencedAssemblies2)
							{
								try
								{
									Assembly.Load(assemblyRef2);
								}
								catch (Exception ex4)
								{
									ilog_0.Warn((object)global::_003CModule_003E.smethod_5<string>(1231588225u), ex4);
								}
							}
						}
						catch (Exception ex5)
						{
							ilog_0.Warn((object)global::_003CModule_003E.smethod_9<string>(2860625668u), ex5);
						}
					}
				}
				if (GlobalSettings.Instance.MinimizeGameOnHook && !Interop.IsIconic(mainWindow_0.process_0.MainWindowHandle))
				{
					Interop.ShowWindow(mainWindow_0.process_0.MainWindowHandle, Interop.Cmd.Minimize);
				}
				if (GlobalSettings.Instance.EnableMouseDegudOnHook)
				{
					MouseManager.DebugCursor = true;
				}
				HookManager.Initialize(mainWindow_0.process_0);
				if (GlobalSettings.Instance.StopRenderOnHook)
				{
					base.Dispatcher.Invoke(method_RenderOff);
				}
				else
				{
					base.Dispatcher.Invoke(method_RenderOn);
				}
				Configuration.Instance.AddSettings(GuiSettings.Instance);
				Configuration.Instance.SaveAll();
				BotManager.PreStart += method_4;
				BotManager.PostStop += method_3;
				LokiPoe.Input.Binding.Update();
				ThirdPartyLoader.CompileAllTherdParty((from x in GuiSettings.Instance.DisabledContent
					where !string.IsNullOrEmpty(x.Name)
					select x.Name.ToLowerInvariant()).ToList(), GuiSettings.Instance.CompileAsynchronously);
				if ((!GuiSettings.Instance.ExitOnCompileErrors && !CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_7<string>(4250575910u))) || (!ThirdPartyLoader.CompileErrors.Any() && !ThirdPartyLoader.CompileExceptions.Any()))
				{
					if ((!GuiSettings.Instance.ExitOnLoadErrors && !CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_7<string>(1713258268u))) || !ThirdPartyLoader.LoadErrors.Any())
					{
						base.Dispatcher.Invoke(method_17);
						List<string> list = (from x in GuiSettings.Instance.ContentOrder
							where !string.IsNullOrEmpty(x.Name)
							select x.Name).ToList();
						ContentManager.smethod_0(ThirdPartyLoader.Instances, list);
						BotManager.smethod_5LoadBots(ThirdPartyLoader.Instances);
						base.Dispatcher.Invoke(method_11);
						BotManager.OnBotChanged += method_6;
						RoutineManager.smethod_1(ThirdPartyLoader.Instances);
						base.Dispatcher.Invoke(method_12);
						RoutineManager.OnRoutineChanged += method_7;
						PlayerMoverManager.smethod_1(ThirdPartyLoader.Instances);
						PluginManager.smethod_4(ThirdPartyLoader.Instances, GuiSettings.Instance.EnabledPlugins, list);
						base.Dispatcher.Invoke(method_13);
						base.Dispatcher.Invoke(method_14);
						dispatcherTimer_1 = new DispatcherTimer(TimeSpan.FromMilliseconds(1000.0), DispatcherPriority.Normal, method_5, base.Dispatcher);
						dispatcherTimer_1.Start();
						if (GlobalSettings.Instance.StartStopBotEnabled)
						{
							Hotkeys.Register(global::_003CModule_003E.smethod_7<string>(3759320623u), GlobalSettings.Instance.StartStopBotKey, GlobalSettings.Instance.StartStopBotMod, Class21.Class9.method_11);
						}
						if (GlobalSettings.Instance.FocusBotWindowEnabled)
						{
							Hotkeys.Register(global::_003CModule_003E.smethod_7<string>(929061372u), GlobalSettings.Instance.FocusBotWindowKey, GlobalSettings.Instance.FocusBotWindowMod, Class21.Class9.method_12);
						}
						if (GlobalSettings.Instance.DebugMouseCursorPosEnabled)
						{
							Hotkeys.Register(global::_003CModule_003E.smethod_8<string>(1331757384u), GlobalSettings.Instance.DebugMouseCursorPosKey, GlobalSettings.Instance.DebugMouseCursorPosMod, Class21.Class9.method_14);
						}
						if (GlobalSettings.Instance.DisablePHMEnabled)
						{
							Hotkeys.Register(global::_003CModule_003E.smethod_8<string>(1729522978u), GlobalSettings.Instance.DisablePHMKey, GlobalSettings.Instance.DisablePHMMod, Class21.Class9.method_15);
						}
						if (GlobalSettings.Instance.EnablePHMEnabled)
						{
							Hotkeys.Register(global::_003CModule_003E.smethod_8<string>(536226196u), GlobalSettings.Instance.EnablePHMKey, GlobalSettings.Instance.EnablePHMMod, Class21.Class9.method_16);
						}
						if (GlobalSettings.Instance.ResetPHMEnabled)
						{
							Hotkeys.Register(global::_003CModule_003E.smethod_8<string>(244231054u), GlobalSettings.Instance.ResetPHMKey, GlobalSettings.Instance.ResetPHMMod, Class21.Class9.method_17);
						}
						if (GlobalSettings.Instance.DumpTGTEnabled)
						{
							Hotkeys.Register(global::_003CModule_003E.smethod_9<string>(3929118619u), GlobalSettings.Instance.DumpTGTKey, GlobalSettings.Instance.DumpTGTMod, Class21.Class9.method_18);
						}
						if (GlobalSettings.Instance.DumpFrameUnderCursorEnabled)
						{
							Hotkeys.Register(global::_003CModule_003E.smethod_5<string>(363602284u), GlobalSettings.Instance.DumpFrameUnderCursorKey, GlobalSettings.Instance.DumpFrameUnderCursorMod, Class21.Class9.method_DumpPassive);
						}
						Hotkeys.Register(global::_003CModule_003E.smethod_6<string>(1785854058u), Keys.L, ModifierKeys.Alt | ModifierKeys.Shift, Class21.Class9.method_DumpDelve);
						LokiPoe.InGameState.DelveSubterrainChartUi.OnPassiveDump += LokiPoe.OnDelveCellDump;
						Hotkeys.Register(global::_003CModule_003E.smethod_9<string>(3250212680u), Keys.Z, ModifierKeys.Alt | ModifierKeys.Shift, Class21.Class9.method_ToggleRender);
						ilog_0.InfoFormat(global::_003CModule_003E.smethod_8<string>(2977957784u), (object)Environment.NewLine, (object)LocExtension.GetLocalizedValue<string>(global::_003CModule_003E.smethod_9<string>(326426340u)), (object)LocExtension.GetLocalizedValue<string>(global::_003CModule_003E.smethod_6<string>(2208263102u)));
						LokiPoe.IsBotFullyLoaded = true;
						if (CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_9<string>(1879031724u)))
						{
							string text2 = CommandLine.Arguments.Single(global::_003CModule_003E.smethod_5<string>(3217451817u));
							ilog_0.DebugFormat(global::_003CModule_003E.smethod_9<string>(3424952569u), (object)text2);
							LokiPoe.ApplicationExitCodes_0 = (ApplicationExitCodes)int.Parse(text2);
							base.Dispatcher.Invoke(Class21.Class9.method_20);
							return;
						}
						Utility.BroadcastMessage(null, global::_003CModule_003E.smethod_8<string>(2393967500u));
						if (CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_5<string>(1107265105u)))
						{
							BotManager.Start();
						}
						if (CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_8<string>(3189498688u)))
						{
							base.Dispatcher.Invoke((Func<System.Windows.WindowState>)Class21.Class9.method_21);
						}
					}
					else
					{
						ilog_0.InfoFormat(global::_003CModule_003E.smethod_9<string>(2880679285u), Array.Empty<object>());
						LokiPoe.ApplicationExitCodes_0 = ApplicationExitCodes.LoadErrors;
						base.Dispatcher.Invoke(Class21.Class9.method_6);
					}
				}
				else
				{
					ilog_0.InfoFormat(global::_003CModule_003E.smethod_7<string>(924532464u), Array.Empty<object>());
					LokiPoe.ApplicationExitCodes_0 = ApplicationExitCodes.CompileErrors;
					base.Dispatcher.Invoke(Class21.Class9.method_5);
				}
			}
			else
			{
				ilog_0.ErrorFormat(string_, Array.Empty<object>());
				if (!CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_5<string>(1460136680u)))
				{
					System.Windows.MessageBox.Show(string_, Util.RandomWindowTitle(LocExtension.GetLocalizedValue<string>(global::_003CModule_003E.smethod_6<string>(1815414970u))), MessageBoxButton.OK, MessageBoxImage.Hand);
				}
				base.Dispatcher.BeginInvoke(new Action(method_10));
			}
		}
		catch (Exception ex6)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_9<string>(226158255u), ex6);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class21.Class9.method_22);
		}
	}

	private void method_10()
	{
		((Window)(object)mainWindow_0).Close();
		System.Windows.Application.Current.Shutdown((int)LokiPoe.ApplicationExitCodes_0);
	}

	private void method_11()
	{
		List<IBot> list = BotManager.Bots.Where(Class21.Class9.method_9).ToList();
		BotsComboBox.ItemsSource = list;
		if (!CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_7<string>(1361440855u)))
		{
			if (!string.IsNullOrEmpty(GuiSettings.Instance.LastBot))
			{
				Class23 @class = new Class23();
				@class.string_0 = GuiSettings.Instance.LastBot;
				IBot bot = list.FirstOrDefault(@class.method_0);
				if (bot != null)
				{
					BotsComboBox.SelectedItem = bot;
				}
			}
		}
		else
		{
			Class22 class2 = new Class22();
			class2.string_0 = CommandLine.Arguments.Single(global::_003CModule_003E.smethod_5<string>(2722435236u));
			IBot bot2 = list.FirstOrDefault(class2.method_0);
			if (bot2 != null)
			{
				BotsComboBox.SelectedItem = bot2;
			}
		}
		if (BotsComboBox.SelectedItem == null)
		{
			BotsComboBox.SelectedItem = list.FirstOrDefault();
		}
	}

	private void method_12()
	{
		List<IRoutine> list = RoutineManager.Routines.Where(Class21.Class9.method_10).ToList();
		RoutinesComboBox.ItemsSource = list;
		if (CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_6<string>(2132934776u)))
		{
			Class24 @class = new Class24();
			@class.string_0 = CommandLine.Arguments.Single(global::_003CModule_003E.smethod_6<string>(2132934776u));
			IRoutine routine = list.FirstOrDefault(@class.method_0);
			if (routine != null)
			{
				RoutinesComboBox.SelectedItem = routine;
			}
		}
		else if (!string.IsNullOrEmpty(GuiSettings.Instance.LastRoutine))
		{
			Class25 class2 = new Class25();
			class2.string_0 = GuiSettings.Instance.LastRoutine;
			IRoutine routine2 = list.FirstOrDefault(class2.method_0);
			if (routine2 != null)
			{
				RoutinesComboBox.SelectedItem = routine2;
			}
		}
		if (RoutinesComboBox.SelectedItem == null)
		{
			RoutinesComboBox.SelectedItem = list.FirstOrDefault();
		}
	}

	private void method_13()
	{
		BotsComboBox.IsEnabled = true;
		RoutinesComboBox.IsEnabled = true;
		mainWindow_0.NewSettingsWindow_0.method_13();
	}

	private void method_14()
	{
		dispatcherTimer_0 = new DispatcherTimer(TimeSpan.FromMilliseconds(1000.0), DispatcherPriority.Normal, method_1, base.Dispatcher);
		dispatcherTimer_0.Start();
	}

	private void method_15()
	{
		StartStopButton.IsEnabled = false;
		BotsComboBox.IsEnabled = false;
		RoutinesComboBox.IsEnabled = false;
	}

	private void method_16()
	{
		StartStopButton.IsEnabled = false;
		BotsComboBox.IsEnabled = false;
		RoutinesComboBox.IsEnabled = false;
	}

	private void method_17()
	{
		LogLevelComboBox.SelectedValue = GuiSettings.Instance.LogLevel;
	}

	private void ToggleSwitch_OnClick(object sender, RoutedEventArgs e)
	{
		ToggleSwitch val = (ToggleSwitch)((sender is ToggleSwitch) ? sender : null);
		if (val != null)
		{
			if (RenderSwitch.IsChecked.HasValue && RenderSwitch.IsChecked.Value)
			{
				LokiPoe.ClientFunctions.EnableRender();
			}
			else
			{
				LokiPoe.ClientFunctions.DisableRender();
			}
		}
	}
}
