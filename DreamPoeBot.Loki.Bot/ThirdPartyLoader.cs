using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DreamPoeBot.DreamPoe;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Structures.ns13;
using DreamPoeBot.Structures.ns27;
using log4net;
using Newtonsoft.Json;

namespace DreamPoeBot.Loki.Bot;

public static class ThirdPartyLoader
{
	internal enum SourceType
	{
		Zip,
		Folder,
		Stream
	}

	internal class ThirdPartyLoaderConfiguration
	{
		public string Name { get; set; }

		public SourceType SourceType { get; set; }

		public string String_0 { get; set; }

		public string DirectoryName { get; set; }

		public string String_2 { get; set; }

		public bool Boolean_0 { get; set; }

		public List<string> FileList { get; set; }

		public List<string> DependenciesList { get; set; }

		public List<string> ReferencesList { get; set; }
	}

	private sealed class Class473
	{
		public static readonly Class473 Class9 = new Class473();

		public static Func<KeyValuePair<string, ThirdPartyInstance>, ThirdPartyInstance> Method9__26_0;

		public static Func<IBot, string> Method9__33_0;

		public static Func<IPlugin, string> Method9__33_1;

		public static Func<IRoutine, string> Method9__33_2;

		public static Func<IContent, string> Method9__33_3;

		public static Func<IPlayerMover, string> Method9__33_4;

		public static Func<ZipArchiveEntry, bool> Method9__34_0;

		public static Func<string, bool> Method9__35_0;

		public static Func<string, string> Method9__36_6;

		public static Func<string, string> Method9__36_7;

		public static Func<KeyValuePair<string, ThirdPartyLoaderConfiguration>, bool> Method9__36_0;

		public static Func<KeyValuePair<string, ThirdPartyLoaderConfiguration>, string> Method9__36_1;

		public static Func<string, string> Method9__36_2;

		public static Func<KeyValuePair<string, ThirdPartyLoaderConfiguration>, string> Method9__36_4;

		public static Func<KeyValuePair<string, ThirdPartyLoaderConfiguration>, ThirdPartyLoaderConfiguration> Method9__36_5;

		public static Func<KeyValuePair<string, ThirdPartyLoaderConfiguration>, string> Method9__36_9;

		public static Func<KeyValuePair<string, ThirdPartyLoaderConfiguration>, ThirdPartyLoaderConfiguration> Method9__36_10;

		internal ThirdPartyInstance method_0(KeyValuePair<string, ThirdPartyInstance> keyValuePair_0)
		{
			return keyValuePair_0.Value;
		}

		internal string method_1(IBot ibot_0)
		{
			return ibot_0.GetType().Name + global::_003CModule_003E.smethod_8<string>(2063339663u) + ibot_0.Name + global::_003CModule_003E.smethod_8<string>(1932576242u) + ibot_0.Version + global::_003CModule_003E.smethod_6<string>(2158694193u);
		}

		internal string method_2(IPlugin iplugin_0)
		{
			return iplugin_0.GetType().Name + global::_003CModule_003E.smethod_8<string>(2063339663u) + iplugin_0.Name + global::_003CModule_003E.smethod_6<string>(3614415472u) + iplugin_0.Version + global::_003CModule_003E.smethod_9<string>(614282643u);
		}

		internal string method_3(IRoutine iroutine_0)
		{
			return iroutine_0.GetType().Name + global::_003CModule_003E.smethod_9<string>(4223659461u) + iroutine_0.Name + global::_003CModule_003E.smethod_5<string>(3326175335u) + iroutine_0.Version + global::_003CModule_003E.smethod_8<string>(2461105257u);
		}

		internal string method_4(IContent icontent_0)
		{
			return icontent_0.GetType().Name + global::_003CModule_003E.smethod_9<string>(4223659461u) + icontent_0.Name + global::_003CModule_003E.smethod_6<string>(3614415472u) + icontent_0.Version + global::_003CModule_003E.smethod_7<string>(4175705437u);
		}

		internal string method_5(IPlayerMover iplayerMover_0)
		{
			return iplayerMover_0.GetType().Name + global::_003CModule_003E.smethod_7<string>(3589822219u) + iplayerMover_0.Name + global::_003CModule_003E.smethod_9<string>(955102718u) + iplayerMover_0.Version + global::_003CModule_003E.smethod_5<string>(850277042u);
		}

		internal bool method_6(ZipArchiveEntry zipArchiveEntry_0)
		{
			return zipArchiveEntry_0.Name.Equals(global::_003CModule_003E.smethod_9<string>(3510059240u), StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_7(string string_0)
		{
			return Path.GetFileName(string_0).Equals(global::_003CModule_003E.smethod_8<string>(935709152u), StringComparison.OrdinalIgnoreCase);
		}

		internal string method_8(string string_0)
		{
			return string_0;
		}

		internal string method_9(string string_0)
		{
			return string_0;
		}

		internal bool method_10(KeyValuePair<string, ThirdPartyLoaderConfiguration> keyValuePair_0)
		{
			return !keyValuePair_0.Value.DependenciesList.Any();
		}

		internal string method_11(KeyValuePair<string, ThirdPartyLoaderConfiguration> keyValuePair_0)
		{
			return keyValuePair_0.Key;
		}

		internal string method_12(string string_0)
		{
			return string_0;
		}

		internal string method_13(KeyValuePair<string, ThirdPartyLoaderConfiguration> keyValuePair_0)
		{
			return keyValuePair_0.Key.ToLowerInvariant();
		}

		internal ThirdPartyLoaderConfiguration method_14(KeyValuePair<string, ThirdPartyLoaderConfiguration> keyValuePair_0)
		{
			return keyValuePair_0.Value;
		}

		internal string method_15(KeyValuePair<string, ThirdPartyLoaderConfiguration> keyValuePair_0)
		{
			return keyValuePair_0.Key.ToLowerInvariant();
		}

		internal ThirdPartyLoaderConfiguration method_16(KeyValuePair<string, ThirdPartyLoaderConfiguration> keyValuePair_0)
		{
			return keyValuePair_0.Value;
		}
	}

	private sealed class Class474
	{
		public Dictionary<string, ThirdPartyLoaderConfiguration> dictionaryAssemblyNames;

		public Dictionary<string, string> dictionary_1;

		public Action<string> action_0;

		internal void method_0(string string_0)
		{
			Compile(dictionaryAssemblyNames, string_0);
		}

		internal void method_Premium(KeyValuePair<string, byte[]> pair)
		{
			CompileStream(pair);
		}

		internal void method_1(string string_0)
		{
			Compile(dictionaryAssemblyNames, dictionary_1[string_0]);
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForName(global::_003CModule_003E.smethod_5<string>(922433589u));

	private const string string_0 = "_CONFIGS_";

	private static Dictionary<string, ThirdPartyInstance> dictionary_0;

	private static Dictionary<string, ThirdPartyLoaderConfiguration> dictionary_1;

	private static readonly List<CompilerErrorCollection> compileErrorsList = new List<CompilerErrorCollection>();

	private static readonly List<Exception> compileExceptionsList = new List<Exception>();

	private static readonly List<string> errorsList = new List<string>();

	private static readonly List<string> cleanupPaths = new List<string>();

	private const string string_1 = "3rdparty.json";

	private static string String_0 => Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);

	public static string ThirdPartyPath => Path.Combine(String_0, global::_003CModule_003E.smethod_8<string>(4056796167u));

	public static string RootPath => Path.Combine(ThirdPartyPath, global::_003CModule_003E.smethod_7<string>(350581884u));

	public static string ProfileConfigPath => Path.Combine(RootPath, global::_003CModule_003E.smethod_8<string>(517132940u));

	public static IReadOnlyList<string> CleanupPaths => cleanupPaths;

	public static IReadOnlyList<CompilerErrorCollection> CompileErrors
	{
		get
		{
			List<CompilerErrorCollection> list = compileErrorsList;
			lock (list)
			{
				return compileErrorsList.ToList();
			}
		}
	}

	public static IReadOnlyList<Exception> CompileExceptions
	{
		get
		{
			List<Exception> list = compileExceptionsList;
			lock (list)
			{
				return compileExceptionsList.ToList();
			}
		}
	}

	public static IReadOnlyList<string> LoadErrors
	{
		get
		{
			List<string> list = errorsList;
			lock (list)
			{
				return errorsList.ToList();
			}
		}
	}

	public static IReadOnlyList<ThirdPartyInstance> Instances => dictionary_0.Select(Class473.Class9.method_0).ToList();

	public static ThirdPartyInstance GetInstance(string name)
	{
		dictionary_0.TryGetValue(name, out var value);
		return value;
	}

	private static string smethod_0(string string_2)
	{
		using MD5 mD = MD5.Create();
		using FileStream inputStream = File.OpenRead(string_2);
		return BitConverter.ToString(mD.ComputeHash(inputStream)).Replace(global::_003CModule_003E.smethod_6<string>(415360684u), "").ToLower();
	}

	private static void DeleteDirectoryAndVerify(string string_2, string string_3)
	{
		try
		{
			Directory.Delete(string_2, recursive: true);
		}
		catch
		{
		}
		Stopwatch stopwatch = Stopwatch.StartNew();
		while (Directory.Exists(string_2))
		{
			ilog_0.InfoFormat(global::_003CModule_003E.smethod_9<string>(1231756144u), (object)string_3);
			Thread.Sleep(1000);
			try
			{
				Directory.Delete(string_2, recursive: true);
			}
			catch
			{
			}
			if (stopwatch.ElapsedMilliseconds > 5000L)
			{
				throw new Exception(string.Format(global::_003CModule_003E.smethod_6<string>(2050862274u), stopwatch.Elapsed, string_3));
			}
		}
	}

	private static void CreateDirectoryAndVerify(string string_2, string string_3)
	{
		try
		{
			Directory.CreateDirectory(string_2);
		}
		catch
		{
		}
		Stopwatch stopwatch = Stopwatch.StartNew();
		while (!Directory.Exists(string_2))
		{
			ilog_0.InfoFormat(global::_003CModule_003E.smethod_8<string>(1629975484u), (object)string_3);
			Thread.Sleep(1000);
			try
			{
				Directory.CreateDirectory(string_2);
			}
			catch
			{
			}
			if (stopwatch.ElapsedMilliseconds > 5000L)
			{
				throw new Exception(string.Format(global::_003CModule_003E.smethod_7<string>(3514542916u), stopwatch.Elapsed, string_3));
			}
		}
	}

	public static void RedirectAssembly()
	{
		ResolveEventHandler value = (object sender, ResolveEventArgs args) => AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault((Assembly a) => a.GetName().Name == new AssemblyName(args.Name).Name);
		AppDomain.CurrentDomain.AssemblyResolve += value;
	}

	internal static bool CompileStream(KeyValuePair<string, byte[]> data)
	{
		try
		{
			RedirectAssembly();
			Assembly assembly = Assembly.Load(data.Value);
			string fullName = assembly.FullName;
			string name = fullName.Split(',')[0];
			ThirdPartyInstance thirdPartyInstance = new ThirdPartyInstance(fullName, "", "", assembly);
			Dictionary<string, ThirdPartyInstance> dictionary = dictionary_0;
			lock (dictionary)
			{
				dictionary_0.Add(fullName, thirdPartyInstance);
				ilog_0.InfoFormat(global::_003CModule_003E.smethod_8<string>(241643127u), (object)fullName);
				ilog_0.InfoFormat(global::_003CModule_003E.smethod_5<string>(3281266541u), (object)string.Join(global::_003CModule_003E.smethod_7<string>(394158831u), thirdPartyInstance.BotInstances.Select(Class473.Class9.method_1)));
				ilog_0.InfoFormat(global::_003CModule_003E.smethod_9<string>(2804415145u), (object)string.Join(global::_003CModule_003E.smethod_6<string>(1398107371u), thirdPartyInstance.PluginInstances.Select(Class473.Class9.method_2)));
				ilog_0.InfoFormat(global::_003CModule_003E.smethod_7<string>(2243619641u), (object)string.Join(global::_003CModule_003E.smethod_6<string>(1398107371u), thirdPartyInstance.RoutineInstances.Select(Class473.Class9.method_3)));
				ilog_0.InfoFormat(global::_003CModule_003E.smethod_9<string>(398163933u), (object)string.Join(global::_003CModule_003E.smethod_5<string>(2892912620u), thirdPartyInstance.ContentInstances.Select(Class473.Class9.method_4)));
				ilog_0.InfoFormat(global::_003CModule_003E.smethod_8<string>(3176305145u), (object)string.Join(global::_003CModule_003E.smethod_9<string>(1043976889u), thirdPartyInstance.PlayerMoverInstances.Select(Class473.Class9.method_5)));
			}
			if (GlobalSettings.Instance.PremiumContent.All((PremiumContentClass x) => x.Id != data.Key))
			{
				PremiumContentClass item = new PremiumContentClass
				{
					Name = name,
					Id = data.Key,
					Enabled = true
				};
				GlobalSettings.Instance.PremiumContent.Add(item);
			}
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
			return false;
		}
		return true;
	}

	internal static bool Compile(Dictionary<string, ThirdPartyLoaderConfiguration> dictionary_2, string name)
	{
		try
		{
			string text = Path.Combine(ProfileConfigPath, name);
			bool flag = false;
			if (Directory.Exists(text) && CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_6<string>(708306816u)))
			{
				List<string> source = Directory.EnumerateDirectories(text).ToList();
				string text2 = source.OrderByDescending((string x) => x).FirstOrDefault((string x) => x.Contains(global::_003CModule_003E.smethod_8<string>(1983008363u)));
				string text3 = source.OrderByDescending((string x) => x).FirstOrDefault((string x) => x.Contains(global::_003CModule_003E.smethod_6<string>(733416258u)));
				if (!string.IsNullOrEmpty(text2) && !string.IsNullOrEmpty(text3) && File.Exists(Path.Combine(text3, name + global::_003CModule_003E.smethod_9<string>(1782010390u))))
				{
					string assemblyFile = Path.Combine(text3, name + global::_003CModule_003E.smethod_6<string>(2970472920u));
					try
					{
						RedirectAssembly();
						Assembly compiledAssembly = Assembly.LoadFrom(assemblyFile);
						flag = true;
						ThirdPartyInstance thirdPartyInstance = new ThirdPartyInstance(name, text2, text3, compiledAssembly);
						Dictionary<string, ThirdPartyInstance> dictionary = dictionary_0;
						lock (dictionary)
						{
							dictionary_0.Add(name, thirdPartyInstance);
							ilog_0.InfoFormat(global::_003CModule_003E.smethod_7<string>(2452370499u), (object)name);
							ilog_0.InfoFormat(global::_003CModule_003E.smethod_6<string>(411444982u), (object)string.Join(global::_003CModule_003E.smethod_6<string>(1398107371u), thirdPartyInstance.BotInstances.Select(Class473.Class9.method_1)));
							ilog_0.InfoFormat(global::_003CModule_003E.smethod_9<string>(2804415145u), (object)string.Join(global::_003CModule_003E.smethod_5<string>(2892912620u), thirdPartyInstance.PluginInstances.Select(Class473.Class9.method_2)));
							ilog_0.InfoFormat(global::_003CModule_003E.smethod_7<string>(2243619641u), (object)string.Join(global::_003CModule_003E.smethod_9<string>(1043976889u), thirdPartyInstance.RoutineInstances.Select(Class473.Class9.method_3)));
							ilog_0.InfoFormat(global::_003CModule_003E.smethod_7<string>(878068435u), (object)string.Join(global::_003CModule_003E.smethod_9<string>(1043976889u), thirdPartyInstance.ContentInstances.Select(Class473.Class9.method_4)));
							ilog_0.InfoFormat(global::_003CModule_003E.smethod_8<string>(3176305145u), (object)string.Join(global::_003CModule_003E.smethod_8<string>(1157532427u), thirdPartyInstance.PlayerMoverInstances.Select(Class473.Class9.method_5)));
						}
					}
					catch (Exception value)
					{
						flag = false;
						Console.WriteLine(value);
					}
				}
			}
			if (!flag && !CommandLine.Arguments.Exists(global::_003CModule_003E.smethod_9<string>(1950769317u)))
			{
				try
				{
					if (Directory.Exists(text))
					{
						string[] directories = Directory.GetDirectories(text);
						foreach (string path in directories)
						{
							try
							{
								Directory.Delete(path, recursive: true);
							}
							catch
							{
							}
						}
					}
				}
				catch
				{
				}
				int tickCount = Environment.TickCount;
				string text4 = Path.Combine(text, global::_003CModule_003E.smethod_7<string>(2058892687u) + tickCount);
				string text5 = Path.Combine(text, global::_003CModule_003E.smethod_6<string>(733416258u) + tickCount);
				List<string> list = cleanupPaths;
				lock (list)
				{
					cleanupPaths.Add(text4);
					cleanupPaths.Add(text5);
				}
				ThirdPartyLoaderConfiguration thirdPartyLoaderConfiguration = dictionary_2[name];
				string text6 = thirdPartyLoaderConfiguration.DirectoryName;
				if (Directory.Exists(text5))
				{
					DeleteDirectoryAndVerify(text5, global::_003CModule_003E.smethod_6<string>(1900205622u));
				}
				CreateDirectoryAndVerify(text5, global::_003CModule_003E.smethod_7<string>(3523600732u));
				string path2 = Path.Combine(text4, global::_003CModule_003E.smethod_8<string>(789711581u));
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = true;
				if (!Directory.Exists(text4))
				{
					flag2 = true;
					flag3 = true;
				}
				else
				{
					bool flag5 = false;
					if (!File.Exists(path2))
					{
						flag5 = true;
					}
					else if (!(File.ReadAllText(path2).Trim() != thirdPartyLoaderConfiguration.String_2))
					{
						flag4 = false;
					}
					else
					{
						flag5 = true;
					}
					if (flag5)
					{
						DeleteDirectoryAndVerify(text4, global::_003CModule_003E.smethod_9<string>(2649728873u));
						flag2 = true;
						flag3 = true;
					}
				}
				if (flag2)
				{
					CreateDirectoryAndVerify(text4, global::_003CModule_003E.smethod_7<string>(882597343u));
				}
				if (flag3 && thirdPartyLoaderConfiguration.SourceType == SourceType.Zip)
				{
					File.WriteAllText(path2, thirdPartyLoaderConfiguration.String_2);
				}
				if (flag4)
				{
					if (!string.IsNullOrEmpty(text6))
					{
						text6 += global::_003CModule_003E.smethod_9<string>(1678916680u);
					}
					bool flag6 = string.IsNullOrEmpty(text6);
					int length = text6.Length;
					List<string> list2 = new List<string>(thirdPartyLoaderConfiguration.FileList);
					if (thirdPartyLoaderConfiguration.SourceType == SourceType.Zip)
					{
						using ZipArchive zipArchive = ZipFile.Open(thirdPartyLoaderConfiguration.String_0, ZipArchiveMode.Read);
						foreach (ZipArchiveEntry entry in zipArchive.Entries)
						{
							if (!flag6 && entry.FullName.IndexOf(text6, StringComparison.OrdinalIgnoreCase) != 0)
							{
								continue;
							}
							string text7 = (flag6 ? entry.FullName : entry.FullName.Substring(length));
							text7 = text7.Replace('\\', '/');
							if (!string.IsNullOrEmpty(entry.Name))
							{
								if (Path.GetFileName(text7).Equals(global::_003CModule_003E.smethod_5<string>(3289554749u), StringComparison.OrdinalIgnoreCase))
								{
									continue;
								}
								if (thirdPartyLoaderConfiguration.Boolean_0)
								{
									string item = text7.ToLowerInvariant();
									if (!thirdPartyLoaderConfiguration.FileList.Contains(item))
									{
										continue;
									}
									list2.Remove(item);
								}
								string text8 = Path.Combine(text4, text7);
								string directoryName = Path.GetDirectoryName(text8);
								if (!string.IsNullOrEmpty(directoryName))
								{
									Directory.CreateDirectory(directoryName);
								}
								entry.ExtractToFile(text8);
							}
							else if (!string.IsNullOrEmpty(text7))
							{
								CreateDirectoryAndVerify(Path.Combine(text4, text7), global::_003CModule_003E.smethod_6<string>(361226098u));
							}
						}
					}
					else if (thirdPartyLoaderConfiguration.SourceType == SourceType.Folder)
					{
						string[] directories2 = Directory.GetDirectories(thirdPartyLoaderConfiguration.DirectoryName, global::_003CModule_003E.smethod_5<string>(2852502009u), SearchOption.AllDirectories);
						for (int j = 0; j < directories2.Length; j++)
						{
							string path3 = directories2[j].Replace(thirdPartyLoaderConfiguration.DirectoryName, "").Trim('/', '\\');
							CreateDirectoryAndVerify(Path.Combine(text4, path3), global::_003CModule_003E.smethod_7<string>(102929355u));
						}
						string[] files = Directory.GetFiles(thirdPartyLoaderConfiguration.DirectoryName, global::_003CModule_003E.smethod_6<string>(3367772522u), SearchOption.AllDirectories);
						foreach (string text9 in files)
						{
							string text10 = (flag6 ? text9 : text9.Substring(length));
							text10 = text10.Replace('\\', '/');
							if (Path.GetFileName(text10).Equals(global::_003CModule_003E.smethod_5<string>(3289554749u), StringComparison.OrdinalIgnoreCase))
							{
								continue;
							}
							if (thirdPartyLoaderConfiguration.Boolean_0)
							{
								string item2 = text10.ToLowerInvariant();
								if (!thirdPartyLoaderConfiguration.FileList.Contains(item2))
								{
									continue;
								}
								list2.Remove(item2);
							}
							string path4 = text9.Replace(thirdPartyLoaderConfiguration.DirectoryName, "").Trim('/', '\\');
							File.Copy(text9, Path.Combine(text4, path4));
						}
					}
					if (thirdPartyLoaderConfiguration.Boolean_0 && list2.Any())
					{
						list = errorsList;
						lock (list)
						{
							errorsList.Add(thirdPartyLoaderConfiguration.Name);
						}
						ilog_0.ErrorFormat(global::_003CModule_003E.smethod_7<string>(981754182u), (object)name, (object)string.Join(global::_003CModule_003E.smethod_8<string>(1157532427u), list2));
						return false;
					}
				}
				Class470 @class = new Class470(name, text4, text5, thirdPartyLoaderConfiguration.ReferencesList);
				CompilerResults compilerResults = @class.DoCompile();
				if (compilerResults != null)
				{
					if (compilerResults.Errors.HasErrors)
					{
						List<CompilerErrorCollection> list3 = compileErrorsList;
						lock (list3)
						{
							compileErrorsList.Add(compilerResults.Errors);
						}
						StringBuilder stringBuilder = new StringBuilder();
						foreach (object error in compilerResults.Errors)
						{
							stringBuilder.AppendLine(error.ToString());
						}
						throw new Exception(stringBuilder.ToString());
					}
					ThirdPartyInstance thirdPartyInstance2 = new ThirdPartyInstance(name, text4, text5, @class.CompiledAssembly);
					Dictionary<string, ThirdPartyInstance> dictionary2 = dictionary_0;
					lock (dictionary2)
					{
						dictionary_0.Add(name, thirdPartyInstance2);
						ilog_0.InfoFormat(global::_003CModule_003E.smethod_5<string>(1153204328u), (object)name);
						ilog_0.InfoFormat(global::_003CModule_003E.smethod_6<string>(411444982u), (object)string.Join(global::_003CModule_003E.smethod_5<string>(2892912620u), thirdPartyInstance2.BotInstances.Select(Class473.Class9.method_1)));
						ilog_0.InfoFormat(global::_003CModule_003E.smethod_7<string>(3609170847u), (object)string.Join(global::_003CModule_003E.smethod_7<string>(394158831u), thirdPartyInstance2.PluginInstances.Select(Class473.Class9.method_2)));
						ilog_0.InfoFormat(global::_003CModule_003E.smethod_8<string>(3971836333u), (object)string.Join(global::_003CModule_003E.smethod_7<string>(394158831u), thirdPartyInstance2.RoutineInstances.Select(Class473.Class9.method_3)));
						ilog_0.InfoFormat(global::_003CModule_003E.smethod_6<string>(4160681759u), (object)string.Join(global::_003CModule_003E.smethod_8<string>(1157532427u), thirdPartyInstance2.ContentInstances.Select(Class473.Class9.method_4)));
						ilog_0.InfoFormat(global::_003CModule_003E.smethod_7<string>(1080911021u), (object)string.Join(global::_003CModule_003E.smethod_6<string>(1398107371u), thirdPartyInstance2.PlayerMoverInstances.Select(Class473.Class9.method_5)));
					}
					return true;
				}
				ilog_0.ErrorFormat(global::_003CModule_003E.smethod_6<string>(1427577694u), (object)name);
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			ilog_0.ErrorFormat(global::_003CModule_003E.smethod_9<string>(2481673523u), (object)name, (object)ex.Message);
			List<Exception> list4 = compileExceptionsList;
			lock (list4)
			{
				compileExceptionsList.Add(ex);
			}
			if (ex is ReflectionTypeLoadException)
			{
				Exception[] loaderExceptions = (ex as ReflectionTypeLoadException).LoaderExceptions;
				foreach (Exception ex2 in loaderExceptions)
				{
					ilog_0.ErrorFormat(global::_003CModule_003E.smethod_5<string>(1153204328u), (object)ex2);
				}
			}
			else
			{
				ilog_0.ErrorFormat(global::_003CModule_003E.smethod_5<string>(1153204328u), (object)ex);
			}
		}
		return false;
	}

	internal static bool CompileOriginal(Dictionary<string, ThirdPartyLoaderConfiguration> dictionary_2, string name)
	{
		try
		{
			string text = Path.Combine(ProfileConfigPath, name);
			try
			{
				if (Directory.Exists(text))
				{
					string[] directories = Directory.GetDirectories(text);
					foreach (string path in directories)
					{
						try
						{
							Directory.Delete(path, recursive: true);
						}
						catch
						{
						}
					}
				}
			}
			catch
			{
			}
			int tickCount = Environment.TickCount;
			string text2 = Path.Combine(text, global::_003CModule_003E.smethod_8<string>(1983008363u) + tickCount);
			string text3 = Path.Combine(text, global::_003CModule_003E.smethod_9<string>(2811099684u) + tickCount);
			List<string> list = cleanupPaths;
			lock (list)
			{
				cleanupPaths.Add(text2);
				cleanupPaths.Add(text3);
			}
			ThirdPartyLoaderConfiguration thirdPartyLoaderConfiguration = dictionary_2[name];
			string text4 = thirdPartyLoaderConfiguration.DirectoryName;
			if (Directory.Exists(text3))
			{
				DeleteDirectoryAndVerify(text3, global::_003CModule_003E.smethod_7<string>(3523600732u));
			}
			CreateDirectoryAndVerify(text3, global::_003CModule_003E.smethod_9<string>(404848472u));
			string path2 = Path.Combine(text2, global::_003CModule_003E.smethod_6<string>(957175501u));
			bool flag = false;
			bool flag2 = false;
			bool flag3 = true;
			if (!Directory.Exists(text2))
			{
				flag = true;
				flag2 = true;
			}
			else
			{
				bool flag4 = false;
				if (File.Exists(path2))
				{
					if (!(File.ReadAllText(path2).Trim() != thirdPartyLoaderConfiguration.String_2))
					{
						flag3 = false;
					}
					else
					{
						flag4 = true;
					}
				}
				else
				{
					flag4 = true;
				}
				if (flag4)
				{
					DeleteDirectoryAndVerify(text2, global::_003CModule_003E.smethod_6<string>(559875899u));
					flag = true;
					flag2 = true;
				}
			}
			if (flag)
			{
				CreateDirectoryAndVerify(text2, global::_003CModule_003E.smethod_9<string>(2649728873u));
			}
			if (flag2 && thirdPartyLoaderConfiguration.SourceType == SourceType.Zip)
			{
				File.WriteAllText(path2, thirdPartyLoaderConfiguration.String_2);
			}
			if (flag3)
			{
				if (!string.IsNullOrEmpty(text4))
				{
					text4 += global::_003CModule_003E.smethod_7<string>(2033577740u);
				}
				bool flag5 = string.IsNullOrEmpty(text4);
				int length = text4.Length;
				List<string> list2 = new List<string>(thirdPartyLoaderConfiguration.FileList);
				if (thirdPartyLoaderConfiguration.SourceType == SourceType.Zip)
				{
					using ZipArchive zipArchive = ZipFile.Open(thirdPartyLoaderConfiguration.String_0, ZipArchiveMode.Read);
					foreach (ZipArchiveEntry entry in zipArchive.Entries)
					{
						if (!flag5 && entry.FullName.IndexOf(text4, StringComparison.OrdinalIgnoreCase) != 0)
						{
							continue;
						}
						string text5 = (flag5 ? entry.FullName : entry.FullName.Substring(length));
						text5 = text5.Replace('\\', '/');
						if (string.IsNullOrEmpty(entry.Name))
						{
							if (!string.IsNullOrEmpty(text5))
							{
								CreateDirectoryAndVerify(Path.Combine(text2, text5), global::_003CModule_003E.smethod_6<string>(361226098u));
							}
						}
						else
						{
							if (Path.GetFileName(text5).Equals(global::_003CModule_003E.smethod_5<string>(3289554749u), StringComparison.OrdinalIgnoreCase))
							{
								continue;
							}
							if (thirdPartyLoaderConfiguration.Boolean_0)
							{
								string item = text5.ToLowerInvariant();
								if (!thirdPartyLoaderConfiguration.FileList.Contains(item))
								{
									continue;
								}
								list2.Remove(item);
							}
							string text6 = Path.Combine(text2, text5);
							string directoryName = Path.GetDirectoryName(text6);
							if (!string.IsNullOrEmpty(directoryName))
							{
								Directory.CreateDirectory(directoryName);
							}
							entry.ExtractToFile(text6);
						}
					}
				}
				else if (thirdPartyLoaderConfiguration.SourceType == SourceType.Folder)
				{
					string[] directories2 = Directory.GetDirectories(thirdPartyLoaderConfiguration.DirectoryName, global::_003CModule_003E.smethod_8<string>(2017536076u), SearchOption.AllDirectories);
					for (int j = 0; j < directories2.Length; j++)
					{
						string path3 = directories2[j].Replace(thirdPartyLoaderConfiguration.DirectoryName, "").Trim('/', '\\');
						CreateDirectoryAndVerify(Path.Combine(text2, path3), global::_003CModule_003E.smethod_8<string>(3891382095u));
					}
					string[] files = Directory.GetFiles(thirdPartyLoaderConfiguration.DirectoryName, global::_003CModule_003E.smethod_7<string>(3150997280u), SearchOption.AllDirectories);
					foreach (string text7 in files)
					{
						string text8 = (flag5 ? text7 : text7.Substring(length));
						text8 = text8.Replace('\\', '/');
						if (Path.GetFileName(text8).Equals(global::_003CModule_003E.smethod_9<string>(3510059240u), StringComparison.OrdinalIgnoreCase))
						{
							continue;
						}
						if (thirdPartyLoaderConfiguration.Boolean_0)
						{
							string item2 = text8.ToLowerInvariant();
							if (!thirdPartyLoaderConfiguration.FileList.Contains(item2))
							{
								continue;
							}
							list2.Remove(item2);
						}
						string path4 = text7.Replace(thirdPartyLoaderConfiguration.DirectoryName, "").Trim('/', '\\');
						File.Copy(text7, Path.Combine(text2, path4));
					}
				}
				if (thirdPartyLoaderConfiguration.Boolean_0 && list2.Any())
				{
					list = errorsList;
					lock (list)
					{
						errorsList.Add(thirdPartyLoaderConfiguration.Name);
					}
					ilog_0.ErrorFormat(global::_003CModule_003E.smethod_6<string>(1553124904u), (object)name, (object)string.Join(global::_003CModule_003E.smethod_6<string>(1398107371u), list2));
					return false;
				}
			}
			Class470 @class = new Class470(name, text2, text3, thirdPartyLoaderConfiguration.ReferencesList);
			CompilerResults compilerResults = @class.DoCompile();
			if (compilerResults != null)
			{
				if (compilerResults.Errors.HasErrors)
				{
					List<CompilerErrorCollection> list3 = compileErrorsList;
					lock (list3)
					{
						compileErrorsList.Add(compilerResults.Errors);
					}
					StringBuilder stringBuilder = new StringBuilder();
					foreach (object error in compilerResults.Errors)
					{
						stringBuilder.AppendLine(error.ToString());
					}
					throw new Exception(stringBuilder.ToString());
				}
				ThirdPartyInstance thirdPartyInstance = new ThirdPartyInstance(name, text2, text3, @class.CompiledAssembly);
				Dictionary<string, ThirdPartyInstance> dictionary = dictionary_0;
				lock (dictionary)
				{
					dictionary_0.Add(name, thirdPartyInstance);
					ilog_0.InfoFormat(global::_003CModule_003E.smethod_6<string>(1684813551u), (object)name);
					ilog_0.InfoFormat(global::_003CModule_003E.smethod_9<string>(559534744u), (object)string.Join(global::_003CModule_003E.smethod_9<string>(1043976889u), thirdPartyInstance.BotInstances.Select(Class473.Class9.method_1)));
					ilog_0.InfoFormat(global::_003CModule_003E.smethod_7<string>(3609170847u), (object)string.Join(global::_003CModule_003E.smethod_6<string>(1398107371u), thirdPartyInstance.PluginInstances.Select(Class473.Class9.method_2)));
					ilog_0.InfoFormat(global::_003CModule_003E.smethod_9<string>(2972470495u), (object)string.Join(global::_003CModule_003E.smethod_5<string>(2892912620u), thirdPartyInstance.RoutineInstances.Select(Class473.Class9.method_3)));
					ilog_0.InfoFormat(global::_003CModule_003E.smethod_8<string>(74634631u), (object)string.Join(global::_003CModule_003E.smethod_5<string>(2892912620u), thirdPartyInstance.ContentInstances.Select(Class473.Class9.method_4)));
					ilog_0.InfoFormat(global::_003CModule_003E.smethod_9<string>(3671430051u), (object)string.Join(global::_003CModule_003E.smethod_9<string>(1043976889u), thirdPartyInstance.PlayerMoverInstances.Select(Class473.Class9.method_5)));
				}
				return true;
			}
			ilog_0.ErrorFormat(global::_003CModule_003E.smethod_9<string>(767697328u), (object)name);
			return false;
		}
		catch (Exception ex)
		{
			ilog_0.ErrorFormat(global::_003CModule_003E.smethod_5<string>(4024929362u), (object)name, (object)ex.Message);
			List<Exception> list4 = compileExceptionsList;
			lock (list4)
			{
				compileExceptionsList.Add(ex);
			}
			if (ex is ReflectionTypeLoadException)
			{
				Exception[] loaderExceptions = (ex as ReflectionTypeLoadException).LoaderExceptions;
				foreach (Exception ex2 in loaderExceptions)
				{
					ilog_0.ErrorFormat(global::_003CModule_003E.smethod_6<string>(1684813551u), (object)ex2);
				}
			}
			else
			{
				ilog_0.ErrorFormat(global::_003CModule_003E.smethod_5<string>(1153204328u), (object)ex);
			}
		}
		return false;
	}

	private static void PrecompileFromZip(string zipFileName, Dictionary<string, ThirdPartyLoaderConfiguration> dictionary_2, List<string> list_4)
	{
		string text = "";
		try
		{
			text = Path.GetFileNameWithoutExtension(zipFileName);
			ilog_0.DebugFormat(global::_003CModule_003E.smethod_6<string>(2247286340u), (object)text);
			using ZipArchive zipArchive = ZipFile.Open(zipFileName, ZipArchiveMode.Read);
			ThirdPartyConfig thirdPartyConfig = null;
			string text2 = null;
			ZipArchiveEntry zipArchiveEntry = zipArchive.Entries.FirstOrDefault(Class473.Class9.method_6);
			if (zipArchiveEntry != null)
			{
				using (TextReader textReader = new StreamReader(zipArchiveEntry.Open()))
				{
					try
					{
						thirdPartyConfig = JsonConvert.DeserializeObject<ThirdPartyConfig>(textReader.ReadToEnd());
						thirdPartyConfig.Validate();
					}
					catch (Exception ex)
					{
						List<string> list = errorsList;
						lock (list)
						{
							errorsList.Add(text);
						}
						ilog_0.ErrorFormat(global::_003CModule_003E.smethod_5<string>(2118426481u), (object)text, (object)global::_003CModule_003E.smethod_6<string>(1528015462u), (object)ex);
						return;
					}
				}
				text2 = thirdPartyConfig.AssemblyName;
				if (string.IsNullOrEmpty(text2))
				{
					List<string> list2 = errorsList;
					lock (list2)
					{
						errorsList.Add(text);
					}
					ilog_0.ErrorFormat(global::_003CModule_003E.smethod_9<string>(774381867u), (object)text, (object)global::_003CModule_003E.smethod_7<string>(2347305388u));
					return;
				}
				string directoryName = Path.GetDirectoryName(zipArchiveEntry.FullName);
				if (dictionary_2.ContainsKey(text2))
				{
					List<string> list3 = errorsList;
					lock (list3)
					{
						errorsList.Add(text);
					}
					ilog_0.ErrorFormat(global::_003CModule_003E.smethod_6<string>(3685828096u), (object)text, (object)text2);
					return;
				}
				if (list_4.Contains(text2.ToLowerInvariant()))
				{
					ilog_0.WarnFormat(global::_003CModule_003E.smethod_7<string>(4285153088u), (object)text, (object)text2);
					return;
				}
				ilog_0.DebugFormat(global::_003CModule_003E.smethod_7<string>(3018758721u), (object)text, (object)text2, (object)directoryName);
				ThirdPartyLoaderConfiguration thirdPartyLoaderConfiguration = new ThirdPartyLoaderConfiguration
				{
					Name = text2,
					SourceType = SourceType.Zip,
					String_0 = zipFileName,
					DirectoryName = directoryName,
					String_2 = smethod_0(zipFileName),
					Boolean_0 = false,
					FileList = new List<string>(),
					DependenciesList = new List<string>(),
					ReferencesList = new List<string>()
				};
				if (thirdPartyConfig.FileList.Any())
				{
					thirdPartyLoaderConfiguration.Boolean_0 = true;
					foreach (string file in thirdPartyConfig.FileList)
					{
						thirdPartyLoaderConfiguration.FileList.Add(file.Replace('\\', '/').ToLowerInvariant());
					}
				}
				if (thirdPartyConfig.Dependencies.Any())
				{
					thirdPartyLoaderConfiguration.DependenciesList.AddRange(thirdPartyConfig.Dependencies);
				}
				if (thirdPartyConfig.References.Any())
				{
					thirdPartyLoaderConfiguration.ReferencesList.AddRange(thirdPartyConfig.References);
				}
				dictionary_2.Add(text2, thirdPartyLoaderConfiguration);
			}
			else
			{
				List<string> list4 = errorsList;
				lock (list4)
				{
					errorsList.Add(text);
				}
				ilog_0.ErrorFormat(global::_003CModule_003E.smethod_6<string>(2841010008u), (object)text, (object)global::_003CModule_003E.smethod_8<string>(935709152u));
			}
		}
		catch (Exception ex2)
		{
			List<Exception> list5 = compileExceptionsList;
			lock (list5)
			{
				compileExceptionsList.Add(ex2);
			}
			ilog_0.ErrorFormat(global::_003CModule_003E.smethod_8<string>(527538249u), (object)text, (object)ex2.Message);
			ilog_0.ErrorFormat(global::_003CModule_003E.smethod_9<string>(3683153677u), (object)ex2);
		}
	}

	public static T Deserialize<T>(byte[] data, Encoding encoding = null) where T : class
	{
		using MemoryStream stream = new MemoryStream(data);
		if (encoding == null)
		{
			using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
			{
				return JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
			}
		}
		using StreamReader streamReader2 = new StreamReader(stream, encoding);
		return JsonConvert.DeserializeObject<T>(streamReader2.ReadToEnd());
	}

	private static void PrecompileFromDirectory(string directiryName, Dictionary<string, ThirdPartyLoaderConfiguration> dictionaryAssemblyNames, List<string> disabledContent)
	{
		string fileName = Path.GetFileName(directiryName);
		if (string.IsNullOrEmpty(fileName) || fileName.Equals(global::_003CModule_003E.smethod_7<string>(350581884u), StringComparison.OrdinalIgnoreCase))
		{
			return;
		}
		try
		{
			ilog_0.DebugFormat(global::_003CModule_003E.smethod_8<string>(1282842318u), (object)fileName);
			ThirdPartyConfig thirdPartyConfig = null;
			string text = null;
			string text2 = Directory.GetFiles(directiryName, global::_003CModule_003E.smethod_6<string>(4032908814u), SearchOption.AllDirectories).FirstOrDefault(Class473.Class9.method_7);
			if (text2 != null)
			{
				try
				{
					Deserialize<ThirdPartyConfig>(new byte[0], Encoding.UTF8);
					thirdPartyConfig = JsonConvert.DeserializeObject<ThirdPartyConfig>(File.ReadAllText(text2));
					thirdPartyConfig.Validate();
				}
				catch (Exception ex)
				{
					List<string> list = errorsList;
					lock (list)
					{
						errorsList.Add(fileName);
					}
					ilog_0.ErrorFormat(global::_003CModule_003E.smethod_5<string>(2118426481u), (object)fileName, (object)global::_003CModule_003E.smethod_7<string>(2347305388u), (object)ex);
					return;
				}
				text = thirdPartyConfig.AssemblyName;
				if (string.IsNullOrEmpty(text))
				{
					List<string> list2 = errorsList;
					lock (list2)
					{
						errorsList.Add(fileName);
					}
					ilog_0.ErrorFormat(global::_003CModule_003E.smethod_8<string>(3231443169u), (object)fileName, (object)global::_003CModule_003E.smethod_7<string>(2347305388u));
					return;
				}
				string directoryName = Path.GetDirectoryName(text2);
				if (dictionaryAssemblyNames.ContainsKey(text))
				{
					List<string> list3 = errorsList;
					lock (list3)
					{
						errorsList.Add(fileName);
					}
					ilog_0.ErrorFormat(global::_003CModule_003E.smethod_8<string>(1388612770u), (object)fileName, (object)text);
				}
				else if (!disabledContent.Contains(text.ToLowerInvariant()))
				{
					string text3 = directoryName.Replace(directiryName, "").Trim('/', '\\');
					ilog_0.DebugFormat(global::_003CModule_003E.smethod_6<string>(1601118053u), (object)fileName, (object)text, (object)text3);
					ThirdPartyLoaderConfiguration thirdPartyLoaderConfiguration = new ThirdPartyLoaderConfiguration
					{
						Name = text,
						SourceType = SourceType.Folder,
						DirectoryName = directoryName,
						String_2 = "",
						Boolean_0 = false,
						FileList = new List<string>(),
						DependenciesList = new List<string>(),
						ReferencesList = new List<string>()
					};
					if (thirdPartyConfig.FileList.Any())
					{
						thirdPartyLoaderConfiguration.Boolean_0 = true;
						foreach (string file in thirdPartyConfig.FileList)
						{
							thirdPartyLoaderConfiguration.FileList.Add(file.Replace('\\', '/').ToLowerInvariant());
						}
					}
					if (thirdPartyConfig.Dependencies.Any())
					{
						thirdPartyLoaderConfiguration.DependenciesList.AddRange(thirdPartyConfig.Dependencies);
					}
					if (thirdPartyConfig.References.Any())
					{
						thirdPartyLoaderConfiguration.ReferencesList.AddRange(thirdPartyConfig.References);
					}
					dictionaryAssemblyNames.Add(text, thirdPartyLoaderConfiguration);
				}
				else
				{
					ilog_0.WarnFormat(global::_003CModule_003E.smethod_5<string>(735326174u), (object)fileName, (object)text);
				}
			}
			else
			{
				List<string> list4 = errorsList;
				lock (list4)
				{
					errorsList.Add(fileName);
				}
				ilog_0.ErrorFormat(global::_003CModule_003E.smethod_6<string>(2841010008u), (object)fileName, (object)global::_003CModule_003E.smethod_7<string>(2347305388u));
			}
		}
		catch (Exception ex2)
		{
			List<Exception> list5 = compileExceptionsList;
			lock (list5)
			{
				compileExceptionsList.Add(ex2);
			}
			ilog_0.ErrorFormat(global::_003CModule_003E.smethod_9<string>(2481673523u), (object)fileName, (object)ex2.Message);
			ilog_0.ErrorFormat(global::_003CModule_003E.smethod_6<string>(1684813551u), (object)ex2);
		}
	}

	internal static void CompileAllTherdParty(List<string> disabledPlugin, bool compileAsync)
	{
		string thirdPartyPath = ThirdPartyPath;
		dictionary_0 = new Dictionary<string, ThirdPartyInstance>();
		dictionary_1 = new Dictionary<string, ThirdPartyLoaderConfiguration>();
		ilog_0.DebugFormat(global::_003CModule_003E.smethod_6<string>(3064769251u), Array.Empty<object>());
		try
		{
			Class474 @class = new Class474();
			if (!Directory.Exists(thirdPartyPath))
			{
				ilog_0.DebugFormat(global::_003CModule_003E.smethod_5<string>(1528718243u), Array.Empty<object>());
				Directory.CreateDirectory(thirdPartyPath);
				return;
			}
			@class.dictionaryAssemblyNames = new Dictionary<string, ThirdPartyLoaderConfiguration>();
			foreach (string item in Directory.GetDirectories(thirdPartyPath, global::_003CModule_003E.smethod_6<string>(3367772522u), SearchOption.TopDirectoryOnly).OrderBy(Class473.Class9.method_8))
			{
				PrecompileFromDirectory(item, @class.dictionaryAssemblyNames, disabledPlugin);
			}
			foreach (string item2 in Directory.GetFiles(thirdPartyPath, global::_003CModule_003E.smethod_6<string>(3361631085u), SearchOption.TopDirectoryOnly).OrderBy(Class473.Class9.method_9))
			{
				PrecompileFromZip(item2, @class.dictionaryAssemblyNames, disabledPlugin);
			}
			@class.dictionary_1 = new Dictionary<string, string>();
			foreach (KeyValuePair<string, ThirdPartyLoaderConfiguration> dictionaryAssemblyName in @class.dictionaryAssemblyNames)
			{
				@class.dictionary_1.Add(dictionaryAssemblyName.Key.ToLowerInvariant(), dictionaryAssemblyName.Key);
			}
			List<string> list = (from x in @class.dictionaryAssemblyNames
				where !x.Value.DependenciesList.Any()
				select x.Key).OrderBy(Class473.Class9.method_12).ToList();
			Stopwatch stopwatch;
			if (compileAsync)
			{
				ilog_0.InfoFormat(global::_003CModule_003E.smethod_5<string>(1570159283u), Array.Empty<object>());
				stopwatch = Stopwatch.StartNew();
				Parallel.ForEach(list, @class.method_0);
			}
			else
			{
				ilog_0.InfoFormat(global::_003CModule_003E.smethod_8<string>(3955531311u), Array.Empty<object>());
				stopwatch = Stopwatch.StartNew();
				foreach (string item3 in list)
				{
					Compile(@class.dictionaryAssemblyNames, item3);
				}
			}
			ilog_0.InfoFormat(global::_003CModule_003E.smethod_7<string>(810613952u), (object)stopwatch.Elapsed);
			Dictionary<string, ThirdPartyLoaderConfiguration> dictionary = @class.dictionaryAssemblyNames.ToDictionary(Class473.Class9.method_13, Class473.Class9.method_14);
			foreach (string item4 in list)
			{
				dictionary.Remove(item4.ToLowerInvariant());
			}
			if (dictionary.Any())
			{
				for (int i = 0; i < 16; i++)
				{
					if (!dictionary.Any())
					{
						break;
					}
					list = new List<string>();
					foreach (KeyValuePair<string, ThirdPartyLoaderConfiguration> item5 in dictionary)
					{
						bool flag = true;
						foreach (string dependencies in item5.Value.DependenciesList)
						{
							if (dictionary.ContainsKey(dependencies.ToLowerInvariant()))
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							list.Add(item5.Key);
						}
					}
					if (!list.Any())
					{
						break;
					}
					if (compileAsync)
					{
						ilog_0.InfoFormat(global::_003CModule_003E.smethod_7<string>(3447088433u), (object)(i + 1));
						stopwatch = Stopwatch.StartNew();
						IEnumerable<string> source = list;
						Action<string> body;
						if ((body = @class.action_0) == null)
						{
							body = (@class.action_0 = @class.method_1);
						}
						Parallel.ForEach(source, body);
					}
					else
					{
						ilog_0.InfoFormat(global::_003CModule_003E.smethod_8<string>(2364468935u), (object)(i + 1));
						stopwatch = Stopwatch.StartNew();
						foreach (string item6 in list)
						{
							Compile(@class.dictionaryAssemblyNames, @class.dictionary_1[item6]);
						}
					}
					ilog_0.InfoFormat(global::_003CModule_003E.smethod_6<string>(3982689930u), (object)stopwatch.Elapsed);
					Dictionary<string, ThirdPartyLoaderConfiguration> dictionary2 = dictionary.ToDictionary(Class473.Class9.method_15, Class473.Class9.method_16);
					foreach (string item7 in list)
					{
						dictionary2.Remove(item7.ToLowerInvariant());
					}
					dictionary = dictionary2;
				}
			}
			dictionary_1 = @class.dictionaryAssemblyNames;
			List<string> products = Class104.GetProducts();
			for (int num = GlobalSettings.Instance.PremiumContent.Count - 1; num >= 0; num--)
			{
				PremiumContentClass premiumContentClass = GlobalSettings.Instance.PremiumContent[num];
				string text = products.FirstOrDefault((string x) => x == premiumContentClass.Id);
				if (text == null)
				{
					GlobalSettings.Instance.PremiumContent.RemoveAt(num);
				}
				else if (!premiumContentClass.Enabled)
				{
					products.Remove(text);
				}
			}
			List<KeyValuePair<string, byte[]>> premiumContent = GetPremiumContent(products);
			if (!premiumContent.Any())
			{
				return;
			}
			if (!compileAsync)
			{
				ilog_0.InfoFormat(global::_003CModule_003E.smethod_6<string>(3882252162u), Array.Empty<object>());
				stopwatch = Stopwatch.StartNew();
				foreach (KeyValuePair<string, byte[]> item8 in premiumContent)
				{
					CompileStream(item8);
				}
			}
			else
			{
				ilog_0.InfoFormat(global::_003CModule_003E.smethod_5<string>(1732402074u), Array.Empty<object>());
				stopwatch = Stopwatch.StartNew();
				Parallel.ForEach(premiumContent, @class.method_Premium);
			}
			ilog_0.InfoFormat(global::_003CModule_003E.smethod_5<string>(1184134876u), (object)stopwatch.Elapsed);
		}
		finally
		{
			ilog_0.DebugFormat(global::_003CModule_003E.smethod_6<string>(3112762400u), Array.Empty<object>());
		}
	}

	private static List<KeyValuePair<string, byte[]>> GetPremiumContent(List<string> products)
	{
		if (products == null)
		{
			return new List<KeyValuePair<string, byte[]>>();
		}
		return DlPromiumContent(products);
	}

	private static List<KeyValuePair<string, byte[]>> DlPromiumContent(List<string> ids)
	{
		List<KeyValuePair<string, byte[]>> list = new List<KeyValuePair<string, byte[]>>();
		foreach (string id in ids)
		{
			byte[] product = Class104.GetProduct(id);
			if (product.Length != 0)
			{
				list.Add(new KeyValuePair<string, byte[]>(id, product));
			}
		}
		return list;
	}
}
