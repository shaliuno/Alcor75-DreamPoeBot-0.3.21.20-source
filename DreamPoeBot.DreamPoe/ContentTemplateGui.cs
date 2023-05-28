using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using log4net;

namespace DreamPoeBot.DreamPoe;

public partial class ContentTemplateGui : UserControl, IComponentConnector
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private IContent icontent_0;

	private bool bool_0;

	public ContentTemplateGui()
	{
		InitializeComponent();
	}

	internal void method_0(IContent icontent_1)
	{
		icontent_0 = icontent_1;
		ContentBindingWrapper source = new ContentBindingWrapper(icontent_0);
		ContentTemplateGuiContentGuideHyperlink.Tag = icontent_0;
		if (!(icontent_0 is IUrlProvider urlProvider))
		{
			ContentTemplateGuiContentGuideTextBlock.Visibility = Visibility.Collapsed;
		}
		else if (!string.IsNullOrEmpty(urlProvider.Url))
		{
			ContentTemplateGuiContentGuideTextBlock.Visibility = Visibility.Visible;
		}
		else
		{
			ContentTemplateGuiContentGuideTextBlock.Visibility = Visibility.Collapsed;
		}
		Binding binding = new Binding(global::_003CModule_003E.smethod_7<string>(478087120u))
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		ContentTemplateGuiContentAuthorLabel.SetBinding(ContentControl.ContentProperty, binding);
		binding = new Binding(global::_003CModule_003E.smethod_7<string>(2434254867u))
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		ContentTemplateGuiContentVersionLabel.SetBinding(ContentControl.ContentProperty, binding);
		binding = new Binding(global::_003CModule_003E.smethod_6<string>(2934211185u))
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		ContentTemplateGuiContentDescriptionLabel.SetBinding(ContentControl.ContentProperty, binding);
		try
		{
			ContentTemplateGuiContentUserControl.Content = icontent_0.Control;
		}
		catch (Exception ex)
		{
			ContentTemplateGuiContentUserControl.Content = null;
			ilog_0.Error((object)global::_003CModule_003E.smethod_9<string>(113462967u), ex);
		}
	}

	private void hyperlink_0_Click(object sender, RoutedEventArgs e)
	{
		if (ContentTemplateGuiContentGuideHyperlink.Tag is IUrlProvider urlProvider)
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
