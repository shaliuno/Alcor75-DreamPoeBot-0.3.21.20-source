using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using DreamPoeBot.XAMLMarkupExtensions.Base;

namespace DreamPoeBot.WPFLocalizeExtension.Providers;

internal class CSVEmbeddedLocalizationProvider : CSVLocalizationProviderBase
{
	[CompilerGenerated]
	private sealed class Class83
	{
		public string string_0;

		public CultureInfo cultureInfo_0;

		public Func<string, bool> func_0;

		internal bool method_0(string string_1)
		{
			return string_1.Contains(string.Format(global::_003CModule_003E.smethod_5<string>(1290582495u), string_0, string.IsNullOrEmpty(cultureInfo_0.Name) ? "" : global::_003CModule_003E.smethod_8<string>(3261465286u), cultureInfo_0.Name));
		}
	}

	public static readonly DependencyProperty DefaultDictionaryProperty = DependencyProperty.RegisterAttached(global::_003CModule_003E.smethod_9<string>(3119768651u), typeof(string), typeof(CSVEmbeddedLocalizationProvider), new PropertyMetadata(null, smethod_0));

	public static readonly DependencyProperty DefaultAssemblyProperty = DependencyProperty.RegisterAttached(global::_003CModule_003E.smethod_7<string>(2087445499u), typeof(string), typeof(CSVEmbeddedLocalizationProvider), new PropertyMetadata(null, smethod_0));

	private Dictionary<DependencyObject, ParentChangedNotifier> dictionary_0 = new Dictionary<DependencyObject, ParentChangedNotifier>();

	private static CSVEmbeddedLocalizationProvider csvembeddedLocalizationProvider_0;

	private static readonly object object_0 = new object();

	private bool bool_0;

	public static CSVEmbeddedLocalizationProvider Instance
	{
		get
		{
			if (csvembeddedLocalizationProvider_0 == null)
			{
				object obj = object_0;
				lock (obj)
				{
					if (csvembeddedLocalizationProvider_0 == null)
					{
						csvembeddedLocalizationProvider_0 = new CSVEmbeddedLocalizationProvider();
					}
				}
			}
			return csvembeddedLocalizationProvider_0;
		}
	}

	public bool HasHeader
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	private static void smethod_0(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
		Instance.OnProviderChanged(dependencyObject_0);
	}

	public static string GetDefaultDictionary(DependencyObject obj)
	{
		if (obj == null)
		{
			return null;
		}
		return (string)obj.GetValue(DefaultDictionaryProperty);
	}

	public static string GetDefaultAssembly(DependencyObject obj)
	{
		if (obj == null)
		{
			return null;
		}
		return (string)obj.GetValue(DefaultAssemblyProperty);
	}

	public static void SetDefaultDictionary(DependencyObject obj, string value)
	{
		obj.SetValue(DefaultDictionaryProperty, value);
	}

	public static void SetDefaultAssembly(DependencyObject obj, string value)
	{
		obj.SetValue(DefaultAssemblyProperty, value);
	}

	private CSVEmbeddedLocalizationProvider()
	{
		ResourceManagerList = new Dictionary<string, ResourceManager>();
		base.AvailableCultures = new ObservableCollection<CultureInfo>();
		base.AvailableCultures.Add(CultureInfo.InvariantCulture);
	}

	private void method_0(DependencyObject dependencyObject_0)
	{
		OnProviderChanged(dependencyObject_0);
	}

	protected override string GetAssembly(DependencyObject target)
	{
		return target?.GetValueOrRegisterParentNotifier<string>(DefaultAssemblyProperty, method_0, dictionary_0);
	}

	protected override string GetDictionary(DependencyObject target)
	{
		return target?.GetValueOrRegisterParentNotifier<string>(DefaultDictionaryProperty, method_0, dictionary_0);
	}

	public override object GetLocalizedObject(string key, DependencyObject target, CultureInfo culture)
	{
		string text = null;
		string text2 = "";
		string outAssembly = "";
		string string_2 = "";
		CSVLocalizationProviderBase.ParseKey(key, out outAssembly, out string_2, out key);
		if (string.IsNullOrEmpty(outAssembly))
		{
			outAssembly = GetAssembly(target);
		}
		if (string.IsNullOrEmpty(string_2))
		{
			string_2 = GetDictionary(target);
		}
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		Func<string, bool> func_0 = default(Func<string, bool>);
		foreach (Assembly assembly in assemblies)
		{
			if (assembly.FullName == null || !(new AssemblyName(assembly.FullName).Name == outAssembly))
			{
				continue;
			}
			IEnumerable<string> manifestResourceNames = assembly.GetManifestResourceNames();
			Func<string, bool> predicate;
			if ((predicate = func_0) == null)
			{
				predicate = (func_0 = (string string_1) => string_1.Contains(string.Format(global::_003CModule_003E.smethod_5<string>(1290582495u), string_2, string.IsNullOrEmpty(culture.Name) ? "" : global::_003CModule_003E.smethod_8<string>(3261465286u), culture.Name)));
			}
			text2 = manifestResourceNames.Where(predicate).FirstOrDefault();
			if (text2 == null)
			{
				continue;
			}
			using StreamReader streamReader = new StreamReader(assembly.GetManifestResourceStream(text2), Encoding.Default);
			if (HasHeader && !streamReader.EndOfStream)
			{
				streamReader.ReadLine();
			}
			while (!streamReader.EndOfStream)
			{
				string[] array = streamReader.ReadLine().Split(global::_003CModule_003E.smethod_7<string>(3263740843u).ToCharArray());
				if (array.Length >= 2 && !(array[0] != key))
				{
					text = array[1];
					break;
				}
			}
		}
		if (text == null)
		{
			OnProviderError(target, key, global::_003CModule_003E.smethod_5<string>(2657106386u) + text2 + global::_003CModule_003E.smethod_6<string>(887988612u));
		}
		return text;
	}
}
