using System.ComponentModel;
using System.Windows;
using DreamPoeBot.WPFLocalizeExtension.Extensions;

namespace DreamPoeBot.WPFLocalizeExtension.Engine;

internal class LocProxy : FrameworkElement
{
	private LocExtension locExtension_0;

	public static DependencyProperty SourceProperty = DependencyProperty.Register(global::_003CModule_003E.smethod_6<string>(808208816u), typeof(object), typeof(LocProxy), new PropertyMetadata(smethod_0));

	public static DependencyProperty PrependTypeProperty = DependencyProperty.Register(global::_003CModule_003E.smethod_9<string>(4248422453u), typeof(bool), typeof(LocProxy), new PropertyMetadata(false, smethod_0));

	public static DependencyProperty SeparatorProperty = DependencyProperty.Register(global::_003CModule_003E.smethod_9<string>(1842171241u), typeof(string), typeof(LocProxy), new PropertyMetadata(global::_003CModule_003E.smethod_5<string>(2769619929u), smethod_0));

	public static DependencyPropertyKey ResultProperty = DependencyProperty.RegisterReadOnly(global::_003CModule_003E.smethod_6<string>(1061528971u), typeof(string), typeof(LocProxy), new PropertyMetadata(""));

	[Category("Common")]
	public object Source
	{
		get
		{
			return GetValue(SourceProperty);
		}
		set
		{
			SetValue(SourceProperty, value);
		}
	}

	[Category("Common")]
	public bool PrependType
	{
		get
		{
			return (bool)GetValue(PrependTypeProperty);
		}
		set
		{
			SetValue(PrependTypeProperty, value);
		}
	}

	[Category("Common")]
	public string Separator
	{
		get
		{
			return (string)GetValue(SeparatorProperty);
		}
		set
		{
			SetValue(SeparatorProperty, value);
		}
	}

	[Category("Common")]
	public string Result
	{
		get
		{
			return ((string)GetValue(ResultProperty.DependencyProperty)) ?? Source.ToString();
		}
		set
		{
			SetValue(ResultProperty, value);
		}
	}

	private static void smethod_0(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
		if (!(dependencyObject_0 is LocProxy locProxy))
		{
			return;
		}
		object source = locProxy.Source;
		if (source != null)
		{
			string text = source.ToString();
			if (locProxy.PrependType)
			{
				text = source.GetType().Name + locProxy.Separator + text;
			}
			locProxy.locExtension_0.Key = text;
		}
	}

	public LocProxy()
	{
		locExtension_0 = new LocExtension();
		locExtension_0.SetBinding(this, GetType().GetProperty(global::_003CModule_003E.smethod_5<string>(73246348u)));
	}
}
