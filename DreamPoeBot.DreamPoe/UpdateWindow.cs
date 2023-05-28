using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using DreamPoeBot.Loki.Common;
using log4net;

namespace DreamPoeBot.DreamPoe;

public partial class UpdateWindow : UserControl, IComponentConnector
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly MainWindow mainWindow_0;

	private readonly string string_0;

	private bool bool_0;

	public UpdateWindow(MainWindow mainWindow, string filter)
	{
		try
		{
			mainWindow_0 = mainWindow;
			string_0 = filter;
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

	private void YesButton_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			mainWindow_0.method_13(string_0);
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_7<string>(415161545u), ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(delegate
			{
				Application.Current.Shutdown();
			});
		}
	}

	private void NoButton_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			mainWindow_0.method_11();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)global::_003CModule_003E.smethod_5<string>(2082997750u), ex);
			Logger.OpenLogFile();
			base.Dispatcher.Invoke(delegate
			{
				Application.Current.Shutdown();
			});
		}
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		try
		{
			string text = "";
			using (WebClient webClient = new WebClient())
			{
				text = webClient.DownloadString(global::_003CModule_003E.smethod_8<string>(2188326309u));
			}
			text = text.TrimStart('"').TrimEnd('"');
			text = text.Replace(global::_003CModule_003E.smethod_6<string>(151514593u), global::_003CModule_003E.smethod_9<string>(2692753146u)).Replace(global::_003CModule_003E.smethod_5<string>(851576127u), global::_003CModule_003E.smethod_8<string>(1697821200u));
			ChangelogTextBox.Document.Blocks.Add(new Paragraph(new Run(text)));
		}
		catch (Exception ex)
		{
			ilog_0.ErrorFormat(global::_003CModule_003E.smethod_7<string>(2741537059u), (object)ex);
			ChangelogTextBox.Document.Blocks.Add(new Paragraph(new Run(global::_003CModule_003E.smethod_6<string>(2510202763u))));
		}
	}

	private void method_1(object sender, RoutedEventArgs e)
	{
		YesButton.Focus();
	}
}
