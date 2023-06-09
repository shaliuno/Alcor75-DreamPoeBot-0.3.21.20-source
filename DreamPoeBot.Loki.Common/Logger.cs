using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;
using log4net;
using log4net.Core;

namespace DreamPoeBot.Loki.Common;

public static class Logger
{
	[Serializable]
	private sealed class Class397
	{
		public static readonly Class397 class9 = new Class397();

		internal int method_0()
		{
			return DropRepeatMessageDelayMs;
		}

		internal int method_1()
		{
			return DropRepeatMessageDelayMs;
		}

		internal int method_2()
		{
			return DropRepeatMessageDelayMs;
		}
	}

	private static readonly CustomLogger customLogger_0;

	private const string string_0 = "DreamPoeBot";

	private static readonly Stopwatch stopwatch_0;

	public static CustomLogger Instance => customLogger_0;

	public static int DropRepeatMessageDelayMs { get; set; }

	public static string FileName => customLogger_0.FileName;

	public static void OpenLogFile()
	{
		if (!stopwatch_0.IsRunning)
		{
			stopwatch_0.Start();
		}
		else
		{
			if (stopwatch_0.ElapsedMilliseconds < 30000L)
			{
				return;
			}
			stopwatch_0.Restart();
		}
		try
		{
			Process.Start(FileName);
		}
		catch
		{
		}
	}

	public static ILog GetLoggerInstanceForType()
	{
		return customLogger_0.GetLoggerInstanceForType();
	}

	public static ILog GetLoggerInstanceForName(string name)
	{
		return customLogger_0.GetLoggerInstanceForName(name);
	}

	static Logger()
	{
		DropRepeatMessageDelayMs = 1000;
		stopwatch_0 = new Stopwatch();
		if (CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_5<string>(456833430u)))
		{
			string path = CommandLine.Arguments.Single(global::_003CModule_003E.smethod_8<string>(3805351389u));
			customLogger_0 = new CustomLogger(Path.Combine(global::_003CModule_003E.smethod_7<string>(3760758034u), path), global::_003CModule_003E.smethod_5<string>(2870162469u), Level.All, Level.Emergency, Class397.class9.method_0);
		}
		else
		{
			customLogger_0 = new CustomLogger(global::_003CModule_003E.smethod_6<string>(652383748u), global::_003CModule_003E.smethod_6<string>(3383262078u), Level.All, Level.Emergency, Class397.class9.method_1);
		}
	}

	public static void Clear()
	{
		customLogger_0.Clear();
	}

	public static void AddWpfListener(ScrollViewer scrollViewer, RichTextBox rtbLog)
	{
		customLogger_0.AddWpfListener(scrollViewer, rtbLog, Class397.class9.method_2);
	}

	public static void ChangeFileLogFilterLevel(Level minLevel = null, Level maxLevel = null)
	{
		customLogger_0.ChangeFileLogFilterLevel(minLevel, maxLevel);
	}

	public static void ChangeWindowLogFilterLevel(Level minLevel = null, Level maxLevel = null)
	{
		customLogger_0.ChangeWindowLogFilterLevel(minLevel, maxLevel);
	}

	public static void ChangeLogFilterLevel(Level minLevel = null, Level maxLevel = null)
	{
		customLogger_0.ChangeLogFilterLevel(minLevel, maxLevel);
	}
}
