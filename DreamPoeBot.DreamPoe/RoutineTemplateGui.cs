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

public partial class RoutineTemplateGui : UserControl, IComponentConnector
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private IRoutine iroutine_0;

	public RoutineTemplateGui()
	{
		InitializeComponent();
	}

	internal void method_0(IRoutine iroutine_1)
	{
		iroutine_0 = iroutine_1;
		RoutineBindingWrapper source = new RoutineBindingWrapper(iroutine_0);
		RoutineTemplateGuiRoutineGuideHyperlink.Tag = iroutine_0;
		if (!(iroutine_0 is IUrlProvider urlProvider))
		{
			RoutineTemplateGuiRoutineGuideTextBlock.Visibility = Visibility.Collapsed;
		}
		else if (string.IsNullOrEmpty(urlProvider.Url))
		{
			RoutineTemplateGuiRoutineGuideTextBlock.Visibility = Visibility.Collapsed;
		}
		else
		{
			RoutineTemplateGuiRoutineGuideTextBlock.Visibility = Visibility.Visible;
		}
		Binding binding = new Binding(global::_003CModule_003E.smethod_7<string>(185145511u))
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		RoutineTemplateGuiRoutineActiveCheckBox.SetBinding(ToggleButton.IsCheckedProperty, binding);
		binding = new Binding(global::_003CModule_003E.smethod_8<string>(2255587004u))
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		RoutineTemplateGuiRoutineAuthorLabel.SetBinding(ContentControl.ContentProperty, binding);
		binding = new Binding(global::_003CModule_003E.smethod_6<string>(1141308767u))
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		RoutineTemplateGuiRoutineVersionLabel.SetBinding(ContentControl.ContentProperty, binding);
		binding = new Binding(global::_003CModule_003E.smethod_8<string>(306986153u))
		{
			Mode = BindingMode.OneWay,
			Source = source,
			Converter = null
		};
		RoutineTemplateGuiRoutineDescriptionLabel.SetBinding(ContentControl.ContentProperty, binding);
		try
		{
			RoutineTemplateGuiContentUserControl.Content = iroutine_0.Control;
		}
		catch (Exception ex)
		{
			RoutineTemplateGuiContentUserControl.Content = null;
			ilog_0.Error((object)global::_003CModule_003E.smethod_9<string>(113462967u), ex);
		}
	}

	private void hyperlink_0_Click(object sender, RoutedEventArgs e)
	{
		if (RoutineTemplateGuiRoutineGuideHyperlink.Tag is IUrlProvider urlProvider)
		{
			try
			{
				Process.Start(urlProvider.Url);
			}
			catch (Exception ex)
			{
				ilog_0.Error((object)global::_003CModule_003E.smethod_6<string>(77785645u), ex);
			}
		}
	}
}
