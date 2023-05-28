using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Structures.ns13;
using DreamPoeBot.WPFLocalizeExtension.Extensions;
using log4net;
using MahApps.Metro.Controls;

namespace DreamPoeBot.DreamPoe;

public partial class LoginWindow : UserControl, IComponentConnector
{
	[Serializable]
	private sealed class Class31
	{
		public static readonly Class31 Class9 = new Class31();

		internal void method_0()
		{
			Application.Current.Shutdown();
		}

		internal void method_1()
		{
			Application.Current.Shutdown();
		}
	}

	private sealed class Class32
	{
		public LoginWindow loginWindow_0;

		public LoginWindow loginWindow_1;

		internal void method_0()
		{
			((ProgressBar)(object)loginWindow_0.metroProgressBar_0).IsIndeterminate = false;
			((UIElement)(object)loginWindow_1.metroProgressBar_0).Visibility = Visibility.Hidden;
			loginWindow_0.AuthLoginButton.IsEnabled = true;
			loginWindow_0.KeyTextBox.IsEnabled = true;
			loginWindow_1.AuthRegionComboBox.IsEnabled = true;
		}

		internal void method_1()
		{
			((ProgressBar)(object)loginWindow_0.metroProgressBar_0).IsIndeterminate = false;
			((UIElement)(object)loginWindow_1.metroProgressBar_0).Visibility = Visibility.Hidden;
			loginWindow_0.mainWindow_0.method_17();
		}

		internal void method_2()
		{
			((ProgressBar)(object)loginWindow_0.metroProgressBar_0).IsIndeterminate = false;
			((UIElement)(object)loginWindow_1.metroProgressBar_0).Visibility = Visibility.Hidden;
			loginWindow_0.AuthLoginButton.IsEnabled = true;
			loginWindow_0.KeyTextBox.IsEnabled = true;
			loginWindow_1.AuthRegionComboBox.IsEnabled = true;
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly MainWindow mainWindow_0;

	private bool bool_0;

	internal MetroProgressBar metroProgressBar_0;

	public LoginWindow(MainWindow mainWindow)
	{
		try
		{
			mainWindow_0 = mainWindow;
			InitializeComponent();
			((ProgressBar)(object)metroProgressBar_0).IsIndeterminate = false;
			((UIElement)(object)metroProgressBar_0).Visibility = Visibility.Hidden;
			AuthLoginButton.IsEnabled = true;
			KeyTextBox.IsEnabled = true;
			AuthRegionComboBox.IsEnabled = true;
			if (CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_9<string>(1192499371u)))
			{
				GlobalSettings.Instance.AuthKeys = CommandLine.Arguments.Single(global::_003CModule_003E.smethod_7<string>(2862859301u));
			}
			KeyTextBox.Text = GlobalSettings.Instance.AuthKeys;
			if (string.IsNullOrEmpty(KeyTextBox.Text))
			{
				Keyboard.Focus(KeyTextBox);
				return;
			}
			Keyboard.Focus(AuthLoginButton);
			if (GlobalSettings.Instance.AutoAuthLogin || CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_7<string>(3155800910u)))
			{
				method_1();
			}
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_5<string>(2082997750u), ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class31.Class9.method_0);
		}
	}

	private void button_0_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			GlobalSettings.Instance.AuthKeys = KeyTextBox.Text;
			GlobalSettings.Instance.Save();
			if (string.IsNullOrEmpty(GlobalSettings.Instance.AuthKeys))
			{
				MessageBox.Show(LocExtension.GetLocalizedValue<string>(global::_003CModule_003E.smethod_9<string>(3780175011u)), Util.RandomWindowTitle(LocExtension.GetLocalizedValue<string>(global::_003CModule_003E.smethod_7<string>(1298515280u))), MessageBoxButton.OK, MessageBoxImage.Hand);
			}
			else
			{
				method_1();
			}
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_6<string>(77785645u), ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(Class31.Class9.method_1);
		}
	}

	private void method_0(object object_0)
	{
		Class32 @class = new Class32();
		@class.loginWindow_1 = this;
		@class.loginWindow_0 = (LoginWindow)object_0;
		try
		{
			GlobalSettings.Instance.AuthKey = "";
			string[] array = GlobalSettings.Instance.AuthKeys.Split(new char[7] { ' ', '\t', '\n', '\r', '-', ',', '|' }, StringSplitOptions.RemoveEmptyEntries);
			int num = 0;
			string text;
			while (true)
			{
				if (num < array.Length)
				{
					text = array[num];
					if (Class104.smethod_4(GlobalSettings.Instance.AuthRegion, text))
					{
						break;
					}
					ilog_0.Info((object)global::_003CModule_003E.smethod_9<string>(2059514277u));
					Thread.Sleep(1000);
					num++;
					continue;
				}
				ilog_0.ErrorFormat(global::_003CModule_003E.smethod_5<string>(4252447388u), (object)Environment.NewLine, (object)Class104.string_0);
				@class.loginWindow_0.Dispatcher.BeginInvoke(new Action(@class.method_0));
				MessageBox.Show(string.Format(global::_003CModule_003E.smethod_6<string>(907023588u), global::_003CModule_003E.smethod_8<string>(1151432407u), Environment.NewLine, global::_003CModule_003E.smethod_6<string>(1502972991u), global::_003CModule_003E.smethod_6<string>(1354542074u)), global::_003CModule_003E.smethod_6<string>(2594434029u), MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			GlobalSettings.Instance.AuthKey = text;
			Class104.smethod_5();
			@class.loginWindow_0.Dispatcher.BeginInvoke(new Action(@class.method_1));
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_7<string>(415161545u), ex);
			@class.loginWindow_0.Dispatcher.BeginInvoke(new Action(@class.method_2));
			MessageBox.Show(string.Format(global::_003CModule_003E.smethod_8<string>(1720511786u), global::_003CModule_003E.smethod_9<string>(553700666u), Environment.NewLine, Class104.string_0), global::_003CModule_003E.smethod_9<string>(1064551255u), MessageBoxButton.OK, MessageBoxImage.Hand);
		}
	}

	private void method_1()
	{
		((ProgressBar)(object)metroProgressBar_0).IsIndeterminate = true;
		((UIElement)(object)metroProgressBar_0).Visibility = Visibility.Visible;
		AuthLoginButton.IsEnabled = false;
		KeyTextBox.IsEnabled = false;
		AuthRegionComboBox.IsEnabled = false;
		new Thread(method_0).Start(this);
	}

	private void method_2(object sender, KeyEventArgs e)
	{
	}

	private void method_3(object sender, RoutedEventArgs e)
	{
		KeyTextBox.Focus();
	}
}
