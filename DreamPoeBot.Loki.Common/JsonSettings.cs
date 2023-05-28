using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using DreamPoeBot.Loki.Common.MVVM;
using log4net;
using Newtonsoft.Json;

namespace DreamPoeBot.Loki.Common;

public class JsonSettings : NotificationObject
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly bool bool_0;

	[JsonIgnore]
	public string FilePath { get; internal set; }

	public static string AssemblyPath => Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);

	public static string SettingsPath => Path.Combine(AssemblyPath, global::_003CModule_003E.smethod_6<string>(1497201836u));

	public bool HasProperty(string name)
	{
		if (name != null)
		{
			return !(GetType().GetProperty(name) == null);
		}
		return false;
	}

	public object GetProperty(string name)
	{
		return GetType().GetProperty(name)?.GetValue(this);
	}

	public void SetProperty(string name, object value)
	{
		GetType().GetProperty(name)?.SetValue(this, value);
	}

	public JsonSettings(string path)
	{
		if (!string.IsNullOrEmpty(path))
		{
			if (path.Contains(global::_003CModule_003E.smethod_7<string>(3372434635u)) && CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_6<string>(529062273u)))
			{
				string text = CommandLine.Arguments.Single(global::_003CModule_003E.smethod_8<string>(2586738393u));
				if (Directory.Exists(text))
				{
					IO.DirectoryCopy(text, Path.Combine(SettingsPath, global::_003CModule_003E.smethod_6<string>(178247031u)), copySubDirs: true, deleteFile: true);
				}
			}
			bool_0 = false;
			FilePath = path;
			LoadFrom(FilePath);
			bool_0 = true;
			return;
		}
		throw new ArgumentNullException(path);
	}

	public void Save()
	{
		SaveAs(FilePath);
	}

	protected T GetDefaultValue<T>(Expression<Func<T>> exp)
	{
		if (exp.NodeType != ExpressionType.Lambda)
		{
			throw new ArgumentException(global::_003CModule_003E.smethod_7<string>(1705637863u), global::_003CModule_003E.smethod_7<string>(340086657u));
		}
		if (exp.Body is MemberExpression)
		{
			if (((MemberExpression)exp.Body).Member.GetCustomAttributes(typeof(DefaultValueAttribute), inherit: true).FirstOrDefault() is DefaultValueAttribute defaultValueAttribute)
			{
				return (T)defaultValueAttribute.Value;
			}
			return default(T);
		}
		throw new ArgumentException(global::_003CModule_003E.smethod_7<string>(925969875u), global::_003CModule_003E.smethod_7<string>(340086657u));
	}

	public virtual bool Validate(out List<string> errors)
	{
		errors = null;
		return true;
	}

	public void SaveAs(string file)
	{
		if (file == null)
		{
			throw new ArgumentNullException(global::_003CModule_003E.smethod_9<string>(1579260758u));
		}
		if (!bool_0)
		{
			return;
		}
		if (!File.Exists(file))
		{
			string directoryName = Path.GetDirectoryName(file);
			if (directoryName != null && !Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
		}
		string contents = JsonConvert.SerializeObject((object)this, (Formatting)1);
		File.WriteAllText(file, contents);
	}

	protected void LoadFrom(string file)
	{
		PropertyInfo[] properties = GetType().GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(DefaultValueAttribute), inherit: true);
			if (customAttributes.Length == 0)
			{
				continue;
			}
			object[] array = customAttributes;
			for (int j = 0; j < array.Length; j++)
			{
				DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)array[j];
				if (propertyInfo.GetSetMethod() != null)
				{
					propertyInfo.SetValue(this, defaultValueAttribute.Value, null);
				}
			}
		}
		if (!File.Exists(file))
		{
			return;
		}
		string text = File.ReadAllText(file);
		try
		{
			JsonConvert.PopulateObject(text, (object)this);
		}
		catch (Exception ex)
		{
			ilog_0.ErrorFormat(global::_003CModule_003E.smethod_6<string>(999464466u), (object)ex.ToString());
			try
			{
				File.Move(file, string.Format(global::_003CModule_003E.smethod_8<string>(1750980086u), file, Environment.TickCount));
			}
			catch
			{
			}
			try
			{
				File.Delete(file);
			}
			catch
			{
			}
		}
	}

	public static string GetSettingsFilePath(params string[] subPathParts)
	{
		List<string> list = new List<string>();
		list.Add(SettingsPath);
		list.AddRange(subPathParts);
		return Path.Combine(list.ToArray());
	}
}
