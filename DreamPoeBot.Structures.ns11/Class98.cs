using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using DreamPoeBot.Loki.Common;
using log4net;

namespace DreamPoeBot.Structures.ns11;

internal static class Class98
{
	private sealed class Class99
	{
		public List<Process> list_0;

		internal void method_0(Process process_0)
		{
			if (smethod_2(process_0) && smethod_3(process_0))
			{
				List<Process> list = list_0;
				lock (list)
				{
					list_0.Add(process_0);
				}
			}
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	internal static Dictionary<Process, string> Dictionary_0
	{
		get
		{
			Dictionary<Process, string> dictionary = new Dictionary<Process, string>();
			foreach (Process item in smethod_4().ToList())
			{
				bool bool_;
				Mutex mutex = smethod_0(item.Id, out bool_);
				if (bool_ && mutex != null)
				{
					string directoryName = Path.GetDirectoryName(item.MainModule.FileName);
					string value = (File.Exists(directoryName + global::_003CModule_003E.smethod_9<string>(1933871037u)) ? global::_003CModule_003E.smethod_7<string>(2263593774u) : (File.Exists(directoryName + global::_003CModule_003E.smethod_5<string>(319616689u)) ? global::_003CModule_003E.smethod_7<string>(501415212u) : (File.Exists(directoryName + global::_003CModule_003E.smethod_5<string>(3281212926u)) ? global::_003CModule_003E.smethod_6<string>(3630621974u) : ((!File.Exists(directoryName + global::_003CModule_003E.smethod_9<string>(2365449033u))) ? global::_003CModule_003E.smethod_5<string>(1054991302u) : global::_003CModule_003E.smethod_7<string>(4246730554u)))));
					dictionary.Add(item, value);
					mutex.ReleaseMutex();
					mutex.Dispose();
				}
			}
			return dictionary;
		}
	}

	internal static Mutex smethod_0(int int_0, out bool bool_0)
	{
		return new Mutex(initiallyOwned: true, global::_003CModule_003E.smethod_9<string>(2256612659u) + (Environment.MachineName.GetHashCode() ^ int_0.GetHashCode() ^ TimeZone.CurrentTimeZone.StandardName.GetHashCode() ^ (global::_003CModule_003E.smethod_7<string>(2646634406u).GetHashCode() + 25)), out bool_0);
	}

	internal static bool smethod_1(out Mutex mutex_0, out Process process_0)
	{
		mutex_0 = null;
		process_0 = null;
		Arguments arguments = CommandLine.Arguments;
		if (arguments.Exists(global::_003CModule_003E.smethod_7<string>(402258373u)))
		{
			try
			{
				int num = int.Parse(arguments.Single(global::_003CModule_003E.smethod_8<string>(998341313u)));
				process_0 = Process.GetProcessById(num);
				if (!smethod_3(process_0))
				{
					ilog_0.Error((object)(global::_003CModule_003E.smethod_5<string>(1652987748u) + arguments.Single(global::_003CModule_003E.smethod_9<string>(2774147787u)) + global::_003CModule_003E.smethod_9<string>(1584391259u)));
					return false;
				}
				mutex_0 = smethod_0(num, out var bool_);
				if (bool_)
				{
					return true;
				}
				mutex_0 = null;
				process_0 = null;
				ilog_0.Error((object)(global::_003CModule_003E.smethod_6<string>(4251680819u) + arguments.Single(global::_003CModule_003E.smethod_6<string>(1520802489u)) + global::_003CModule_003E.smethod_8<string>(2257181428u)));
				return false;
			}
			catch
			{
				ilog_0.Error((object)(global::_003CModule_003E.smethod_9<string>(3977273393u) + arguments.Single(global::_003CModule_003E.smethod_6<string>(1520802489u))));
				return false;
			}
		}
		if (arguments.Exists(global::_003CModule_003E.smethod_8<string>(2362951880u)))
		{
			try
			{
				string processName = arguments.Single(global::_003CModule_003E.smethod_6<string>(2413613726u));
				process_0 = Process.GetProcessesByName(processName).FirstOrDefault();
				if (process_0 != null && smethod_3(process_0))
				{
					mutex_0 = smethod_0(process_0.Id, out var bool_2);
					if (!bool_2)
					{
						mutex_0 = null;
						process_0 = null;
						ilog_0.Error((object)(global::_003CModule_003E.smethod_8<string>(414351029u) + arguments.Single(global::_003CModule_003E.smethod_8<string>(2362951880u)) + global::_003CModule_003E.smethod_7<string>(2448320728u)));
						return false;
					}
					return true;
				}
				ilog_0.Error((object)(global::_003CModule_003E.smethod_9<string>(1765815687u) + arguments.Single(global::_003CModule_003E.smethod_7<string>(3237046532u)) + global::_003CModule_003E.smethod_6<string>(1148612329u)));
				return false;
			}
			catch
			{
				ilog_0.Error((object)(global::_003CModule_003E.smethod_8<string>(414351029u) + arguments.Single(global::_003CModule_003E.smethod_8<string>(2362951880u))));
				return false;
			}
		}
		List<Process> list = smethod_4().ToList();
		if (!list.Any())
		{
			return false;
		}
		if (!arguments.Exists(global::_003CModule_003E.smethod_9<string>(3305051993u)) && list.Count == 1)
		{
			mutex_0 = smethod_0(list[0].Id, out var bool_3);
			if (bool_3)
			{
				process_0 = list[0];
				return true;
			}
			mutex_0.Dispose();
		}
		return false;
	}

	internal static bool smethod_2(Process process_0)
	{
		try
		{
			if (process_0 == null)
			{
				return false;
			}
			if (File.Exists(Path.Combine(Path.GetDirectoryName(process_0.MainModule.FileName), global::_003CModule_003E.smethod_7<string>(3467062566u))))
			{
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	internal static bool smethod_3(Process process_0)
	{
		try
		{
			if (X509Certificate.CreateFromSignedFile(process_0.MainModule.FileName).Subject.Contains(global::_003CModule_003E.smethod_9<string>(1505118666u)))
			{
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	internal static List<Process> smethod_4()
	{
		Class99 @class = new Class99();
		@class.list_0 = new List<Process>();
		Parallel.ForEach(Process.GetProcesses(), @class.method_0);
		return @class.list_0;
	}
}
