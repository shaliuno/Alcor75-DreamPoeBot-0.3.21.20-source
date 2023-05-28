using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using DreamPoeBot.Loki.Bot;

namespace DreamPoeBot.Structures.ns27;

internal class Class470
{
	private sealed class Class471
	{
		public string string_0;

		internal bool method_0(Assembly assembly_0)
		{
			return assembly_0.GetName().Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private static readonly string[] string_0 = new string[1] { global::_003CModule_003E.smethod_7<string>(762654465u) };

	private static bool bool_0;

	private static string string_1;

	private readonly List<string> list_1 = new List<string>();

	private readonly List<Stream> list_2 = new List<Stream>();

	private ResourceWriter resourceWriter_0;

	public string String_0 { get; }

	public string ResourceFilesPath { get; }

	public string String_2 { get; }

	public Assembly CompiledAssembly { get; private set; }

	public CompilerParameters CompilerParameters_0 { get; }

	public float Single_0 { get; }

	public List<string> List_0 { get; }

	public string String_3 => CompilerParameters_0.OutputAssembly;

	public Class470(string name, string sourcePath, string outputPath, List<string> references)
	{
		String_0 = name + global::_003CModule_003E.smethod_8<string>(718468842u);
		ResourceFilesPath = sourcePath;
		String_2 = outputPath;
		Single_0 = 4f;
		List_0 = new List<string>();
		CompilerParameters_0 = new CompilerParameters
		{
			GenerateExecutable = false,
			GenerateInMemory = false,
			IncludeDebugInformation = true
		};
		string arg = global::_003CModule_003E.smethod_9<string>(3729003575u) + Assembly.GetEntryAssembly().GetName().Version.Revision;
		CompilerParameters_0.CompilerOptions = string.Format(global::_003CModule_003E.smethod_5<string>(796811384u), arg);
		CompilerParameters_0.CompilerOptions += global::_003CModule_003E.smethod_7<string>(3106187337u);
		CompilerParameters_0.CompilerOptions += global::_003CModule_003E.smethod_5<string>(2317289858u);
		CompilerParameters_0.TempFiles = new TempFileCollection(Path.GetTempPath());
		CompilerParameters_0.OutputAssembly = Path.Combine(String_2, String_0);
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly in assemblies)
		{
			try
			{
				string location = assembly.Location;
				if (bool_0 && assembly == Assembly.GetEntryAssembly())
				{
					location = string_1;
				}
				method_0(location);
			}
			catch (NotSupportedException)
			{
			}
		}
		string[] array = string_0;
		foreach (string text in array)
		{
			bool flag = true;
			StringEnumerator enumerator = CompilerParameters_0.ReferencedAssemblies.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.ToLowerInvariant().Contains(text.ToLowerInvariant()))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				method_0(text);
			}
		}
		foreach (string reference in references)
		{
			method_0(reference);
		}
	}

	public void method_0(string string_5)
	{
		if (!CompilerParameters_0.ReferencedAssemblies.Contains(string_5))
		{
			CompilerParameters_0.ReferencedAssemblies.Add(string_5);
		}
	}

	private void method_1(string string_5, string string_6)
	{
		if (resourceWriter_0 == null)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(String_0);
			string text = Path.Combine(String_2, fileNameWithoutExtension + global::_003CModule_003E.smethod_9<string>(4085167892u));
			resourceWriter_0 = new ResourceWriter(text);
			CompilerParameters_0.EmbeddedResources.Add(text);
			list_1.Add(text);
		}
		FileStream fileStream = new FileStream(string_5, FileMode.Open, FileAccess.Read);
		list_2.Add(fileStream);
		string name = string_5.Replace(string_6, "").Trim('\\', '/').Replace(global::_003CModule_003E.smethod_9<string>(4188261602u), global::_003CModule_003E.smethod_9<string>(1678916680u))
			.ToLowerInvariant();
		resourceWriter_0.AddResource(name, fileStream);
	}

	private void method_2(string string_5)
	{
		string text = Path.ChangeExtension(string_5, global::_003CModule_003E.smethod_6<string>(3493319732u));
		if (File.Exists(text))
		{
			File.Delete(text);
		}
		using (ResXResourceReader resXResourceReader = new ResXResourceReader(string_5))
		{
			resXResourceReader.BasePath = ResourceFilesPath;
			using ResourceWriter resourceWriter = new ResourceWriter(text);
			foreach (object item in resXResourceReader)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)item;
				resourceWriter.AddResource(dictionaryEntry.Key.ToString(), dictionaryEntry.Value);
			}
		}
		CompilerParameters_0.EmbeddedResources.Add(text);
	}

	private void method_3()
	{
		string[] files = Directory.GetFiles(ResourceFilesPath, global::_003CModule_003E.smethod_6<string>(34267584u), SearchOption.AllDirectories);
		foreach (string string_ in files)
		{
			method_2(string_);
		}
		bool flag = false;
		string[] files2 = Directory.GetFiles(ResourceFilesPath, global::_003CModule_003E.smethod_5<string>(2865557056u), SearchOption.AllDirectories);
		foreach (string string_2 in files2)
		{
			flag = true;
			method_1(string_2, ResourceFilesPath);
		}
		string[] files3 = Directory.GetFiles(ResourceFilesPath, global::_003CModule_003E.smethod_9<string>(126311296u), SearchOption.AllDirectories);
		foreach (string text in files3)
		{
			if (text.ToLowerInvariant().Contains(global::_003CModule_003E.smethod_8<string>(3772295162u)))
			{
				if (flag)
				{
					List_0.Add(text);
				}
			}
			else if (!text.ToLowerInvariant().Contains(global::_003CModule_003E.smethod_5<string>(713929304u)))
			{
				List_0.Add(text);
			}
			else if (flag)
			{
				List_0.Add(text);
			}
		}
	}

	private static bool smethod_1(string string_5)
	{
		Class471 @class = new Class471();
		@class.string_0 = Path.GetFileNameWithoutExtension(string_5);
		return AppDomain.CurrentDomain.GetAssemblies().Any(@class.method_0);
	}

	private void method_4()
	{
		foreach (string item in List_0)
		{
			string[] array = File.ReadAllLines(item);
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].Trim();
				if (!text.StartsWith(global::_003CModule_003E.smethod_7<string>(2425676188u)))
				{
					continue;
				}
				string[] array2 = text.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				string text2 = array2[1];
				if (text2 == global::_003CModule_003E.smethod_8<string>(3878065614u))
				{
					if (array2.Length == 3 && !string.IsNullOrEmpty(array2[2]) && array2[2].EndsWith(global::_003CModule_003E.smethod_8<string>(718468842u)) && !smethod_1(array2[2]))
					{
						method_0(array2[2]);
					}
				}
				else if (text2 == global::_003CModule_003E.smethod_6<string>(4180803963u))
				{
					if (array2.Length == 3 && !string.IsNullOrEmpty(array2[2]) && array2[2] == global::_003CModule_003E.smethod_5<string>(1760734452u) && !CompilerParameters_0.CompilerOptions.Contains(global::_003CModule_003E.smethod_9<string>(3056782175u)))
					{
						CompilerParameters_0.IncludeDebugInformation = false;
						CompilerParameters_0.CompilerOptions += global::_003CModule_003E.smethod_6<string>(1077735473u);
					}
				}
				else if (text2 == global::_003CModule_003E.smethod_8<string>(1677696740u) && array2.Length == 3 && !string.IsNullOrEmpty(array2[2]))
				{
					CompilerParameters compilerParameters_ = CompilerParameters_0;
					compilerParameters_.CompilerOptions = compilerParameters_.CompilerOptions + global::_003CModule_003E.smethod_7<string>(1542322453u) + array2[2] + global::_003CModule_003E.smethod_7<string>(3263740843u);
				}
			}
		}
	}

	public CompilerResults DoCompile()
	{
		method_3();
		method_4();
		if (List_0.Count != 0)
		{
			using (CodeDomProvider codeDomProvider = RoslynCodeCompiler.CreateLatestCSharpProvider())
			{
				codeDomProvider.Supports(GeneratorSupport.Resources);
				if (resourceWriter_0 != null)
				{
					resourceWriter_0.Close();
					resourceWriter_0.Dispose();
					resourceWriter_0 = null;
				}
				foreach (Stream item in list_2)
				{
					try
					{
						item.Close();
						item.Dispose();
					}
					catch
					{
					}
				}
				list_2.Clear();
				CompilerResults compilerResults = codeDomProvider.CompileAssemblyFromFile(CompilerParameters_0, List_0.ToArray());
				if (!compilerResults.Errors.HasErrors)
				{
					CompiledAssembly = compilerResults.CompiledAssembly;
				}
				compilerResults.TempFiles.Delete();
				foreach (string item2 in list_1)
				{
					try
					{
						File.Delete(item2);
					}
					catch
					{
					}
				}
				list_1.Clear();
				return compilerResults;
			}
		}
		if (resourceWriter_0 != null)
		{
			resourceWriter_0.Close();
			resourceWriter_0.Dispose();
			resourceWriter_0 = null;
		}
		foreach (Stream item3 in list_2)
		{
			try
			{
				item3.Close();
				item3.Dispose();
			}
			catch
			{
			}
		}
		list_2.Clear();
		foreach (string item4 in list_1)
		{
			try
			{
				File.Delete(item4);
			}
			catch
			{
			}
		}
		list_1.Clear();
		return null;
	}
}
