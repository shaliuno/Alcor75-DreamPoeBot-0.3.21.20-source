using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Markup;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using log4net;

namespace DreamPoeBot.DreamPoe;

public partial class BotTemplateGui : UserControl, IComponentConnector
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private IBot ibot_0;

	public BotTemplateGui()
	{
		InitializeComponent();
	}

	internal void method_0(IBot ibot_1)
	{
		ibot_0 = ibot_1;
		BotBindingWrapper source = new BotBindingWrapper(ibot_0);
		BotTemplateGuiBotGuideHyperlink.Tag = ibot_0;
		if (ibot_0 is IUrlProvider urlProvider)
		{
			if (!string.IsNullOrEmpty(urlProvider.Url))
			{
				BotTemplateGuiBotGuideTextBlock.Visibility = Visibility.Visible;
			}
			else
			{
				BotTemplateGuiBotGuideTextBlock.Visibility = Visibility.Collapsed;
			}
		}
		else
		{
			BotTemplateGuiBotGuideTextBlock.Visibility = Visibility.Collapsed;
		}
		Binding binding = new Binding(global::_003CModule_003E.smethod_5<string>(2697570612u))
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		BotTemplateGuiBotActiveCheckBox.SetBinding(ToggleButton.IsCheckedProperty, binding);
		binding = new Binding(global::_003CModule_003E.smethod_8<string>(2255587004u))
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		BotTemplateGuiBotAuthorLabel.SetBinding(ContentControl.ContentProperty, binding);
		binding = new Binding(global::_003CModule_003E.smethod_5<string>(1327256696u))
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		BotTemplateGuiBotVersionLabel.SetBinding(ContentControl.ContentProperty, binding);
		binding = new Binding(global::_003CModule_003E.smethod_7<string>(1942795165u))
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		BotTemplateGuiBotDescriptionLabel.SetBinding(ContentControl.ContentProperty, binding);
		try
		{
			BotTemplateGuiContentUserControl.Content = ibot_0.Control;
		}
		catch (Exception ex)
		{
			BotTemplateGuiContentUserControl.Content = null;
			ilog_0.Error((object)global::_003CModule_003E.smethod_8<string>(2003818981u), ex);
		}
	}

	private void hyperlink_0_Click(object sender, RoutedEventArgs e)
	{
		if (BotTemplateGuiBotGuideHyperlink.Tag is IUrlProvider urlProvider)
		{
			try
			{
				Process.Start(urlProvider.Url);
			}
			catch (Exception ex)
			{
				ilog_0.Error((object)global::_003CModule_003E.smethod_7<string>(415161545u), ex);
			}
		}
	}
}
