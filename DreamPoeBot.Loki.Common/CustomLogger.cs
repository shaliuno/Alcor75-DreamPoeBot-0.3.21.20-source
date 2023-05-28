using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Controls;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Filter;
using log4net.Layout;
using log4net.Repository;
using log4net.Repository.Hierarchy;

namespace DreamPoeBot.Loki.Common;

public class CustomLogger
{
	private Level level_0 = Level.All;

	private Level level_1 = Level.Emergency;

	private Level level_2 = Level.All;

	private Level level_3 = Level.Emergency;

	private readonly string string_0;

	private WpfRtfAppender wpfRtfAppender_0;

	private FileAppender fileAppender_0;

	public Level WindowMinLevel => level_0;

	public Level WindowMaxLevel => level_1;

	public Level FileMinLevel => level_2;

	public Level FileMaxLevel => level_3;

	public WpfRtfAppender WindowLogAppender => wpfRtfAppender_0;

	public FileAppender FileLogAppender => fileAppender_0;

	public string FileName { get; }

	public CustomLogger(string path, string prefix, Level minLevel, Level maxLevel, Func<int> getDropRepeatMessageDelayMs)
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_0175: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		if (path == null)
		{
			throw new ArgumentNullException(global::_003CModule_003E.smethod_5<string>(3729860202u));
		}
		if (prefix != null)
		{
			if (getDropRepeatMessageDelayMs == null)
			{
				throw new ArgumentNullException(global::_003CModule_003E.smethod_6<string>(2392238808u));
			}
			string_0 = prefix;
			level_2 = minLevel ?? Level.All;
			level_3 = maxLevel ?? Level.Emergency;
			Directory.CreateDirectory(path);
			PatternLayout val = new PatternLayout(global::_003CModule_003E.smethod_9<string>(876625116u));
			DateTime now = DateTime.Now;
			FileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), string.Format(global::_003CModule_003E.smethod_9<string>(4136522156u), now.Year, now.Month, now.Day, now.Hour, now.Minute, Process.GetCurrentProcess().Id, path, string_0));
			fileAppender_0 = new FileAppender
			{
				File = FileName,
				Layout = (ILayout)(object)val,
				LockingModel = (LockingModelBase)new MinimalLock()
			};
			LevelRangeFilter val2 = new LevelRangeFilter();
			val2.LevelMin = level_2;
			val2.LevelMax = level_3;
			val2.AcceptOnMatch = true;
			((AppenderSkeleton)fileAppender_0).AddFilter((IFilter)(object)val2);
			((LayoutSkeleton)val).ActivateOptions();
			((AppenderSkeleton)fileAppender_0).ActivateOptions();
			AsyncAppender asyncAppender = new AsyncAppender(getDropRepeatMessageDelayMs);
			asyncAppender.AddAppender((IAppender)(object)fileAppender_0);
			asyncAppender.ActivateOptions();
			Hierarchy val3 = (Hierarchy)LogManager.CreateRepository(string_0);
			val3.Root.AddAppender((IAppender)(object)asyncAppender);
			((LoggerRepositorySkeleton)val3).Configured = true;
			return;
		}
		throw new ArgumentNullException(global::_003CModule_003E.smethod_5<string>(1046541668u));
	}

	public void ChangeFileLogFilterLevel(Level minLevel = null, Level maxLevel = null)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		if (minLevel != (Level)null)
		{
			level_2 = minLevel;
		}
		if (maxLevel != (Level)null)
		{
			level_3 = maxLevel;
		}
		if (fileAppender_0 != null)
		{
			((AppenderSkeleton)fileAppender_0).ClearFilters();
			((AppenderSkeleton)fileAppender_0).AddFilter((IFilter)new LevelRangeFilter
			{
				LevelMin = level_2,
				LevelMax = level_3,
				AcceptOnMatch = true
			});
			((AppenderSkeleton)fileAppender_0).AddFilter((IFilter)new DenyAllFilter());
		}
	}

	public void ChangeWindowLogFilterLevel(Level minLevel = null, Level maxLevel = null)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		if (minLevel != (Level)null)
		{
			level_0 = minLevel;
		}
		if (maxLevel != (Level)null)
		{
			level_1 = maxLevel;
		}
		if (wpfRtfAppender_0 != null)
		{
			((AppenderSkeleton)wpfRtfAppender_0).ClearFilters();
			((AppenderSkeleton)wpfRtfAppender_0).AddFilter((IFilter)new LevelRangeFilter
			{
				LevelMin = level_0,
				LevelMax = level_1,
				AcceptOnMatch = true
			});
			((AppenderSkeleton)wpfRtfAppender_0).AddFilter((IFilter)new DenyAllFilter());
		}
	}

	public void ChangeLogFilterLevel(Level minLevel = null, Level maxLevel = null)
	{
		ChangeFileLogFilterLevel(minLevel, maxLevel);
		ChangeWindowLogFilterLevel(minLevel, maxLevel);
	}

	public void Clear()
	{
		wpfRtfAppender_0?.Clear();
	}

	public void AddWpfListener(ScrollViewer scrollViewer, RichTextBox rtbLog, Func<int> getDropRepeatMessageDelayMs)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		if (scrollViewer == null)
		{
			throw new ArgumentNullException(global::_003CModule_003E.smethod_9<string>(3450931678u));
		}
		if (rtbLog == null)
		{
			throw new ArgumentNullException(global::_003CModule_003E.smethod_8<string>(1134379758u));
		}
		if (getDropRepeatMessageDelayMs == null)
		{
			throw new ArgumentNullException(global::_003CModule_003E.smethod_6<string>(2392238808u));
		}
		PatternLayout val = new PatternLayout(global::_003CModule_003E.smethod_9<string>(197719177u));
		WpfRtfAppender wpfRtfAppender = new WpfRtfAppender(scrollViewer, rtbLog);
		((AppenderSkeleton)wpfRtfAppender).Layout = (ILayout)(object)val;
		wpfRtfAppender_0 = wpfRtfAppender;
		LevelRangeFilter val2 = new LevelRangeFilter();
		val2.LevelMin = level_0;
		val2.LevelMax = level_1;
		((AppenderSkeleton)wpfRtfAppender_0).AddFilter((IFilter)(object)val2);
		((LayoutSkeleton)val).ActivateOptions();
		((AppenderSkeleton)wpfRtfAppender_0).ActivateOptions();
		AsyncAppender asyncAppender = new AsyncAppender(getDropRepeatMessageDelayMs);
		asyncAppender.AddAppender((IAppender)(object)wpfRtfAppender_0);
		asyncAppender.ActivateOptions();
		((Hierarchy)LogManager.GetRepository(string_0)).Root.AddAppender((IAppender)(object)asyncAppender);
	}

	public ILog GetLoggerInstanceForType()
	{
		return LogManager.GetLogger(string_0, new StackTrace().GetFrames()[1].GetMethod().DeclaringType);
	}

	public ILog GetLoggerInstanceForName(string name)
	{
		return LogManager.GetLogger(string_0, name);
	}
}
