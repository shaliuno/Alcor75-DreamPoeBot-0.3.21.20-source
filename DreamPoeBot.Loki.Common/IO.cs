using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using DreamPoeBot.Loki.Game;
using log4net;

namespace DreamPoeBot.Loki.Common;

public static class IO
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private const int BYTES_TO_READ = 8;

	public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, bool deleteFile = false)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirName);
		DirectoryInfo[] directories = directoryInfo.GetDirectories();
		if (!directoryInfo.Exists)
		{
			ilog_0.ErrorFormat(global::_003CModule_003E.smethod_6<string>(3111509686u) + sourceDirName, Array.Empty<object>());
			MessageBox.Show(global::_003CModule_003E.smethod_6<string>(3111509686u) + sourceDirName, global::_003CModule_003E.smethod_6<string>(1796289405u), MessageBoxButton.OK, MessageBoxImage.Hand);
			return;
		}
		if (!Directory.Exists(destDirName))
		{
			Directory.CreateDirectory(destDirName);
		}
		DirectoryInfo directoryInfo2 = new DirectoryInfo(destDirName);
		FileInfo[] files = directoryInfo2.GetFiles();
		FileInfo[] files2 = directoryInfo.GetFiles();
		FileInfo[] array = files2;
		foreach (FileInfo file in array)
		{
			string text = Path.Combine(destDirName, file.Name);
			if (files.Any((FileInfo x) => x.Name == file.Name))
			{
				FileInfo fileInfo = files.FirstOrDefault((FileInfo x) => x.Name == file.Name);
				if (fileInfo != null && !FilesAreEqual(file, fileInfo))
				{
					try
					{
						file.CopyTo(text, overwrite: true);
					}
					catch (Exception ex)
					{
						ilog_0.ErrorFormat(ex.ToString(), Array.Empty<object>());
						ilog_0.ErrorFormat(global::_003CModule_003E.smethod_5<string>(2404777351u) + file.FullName, Array.Empty<object>());
						ilog_0.ErrorFormat(global::_003CModule_003E.smethod_9<string>(2594277397u) + text, Array.Empty<object>());
						ilog_0.ErrorFormat(global::_003CModule_003E.smethod_6<string>(1074792792u), Array.Empty<object>());
						Terminate();
					}
				}
			}
			else
			{
				try
				{
					file.CopyTo(text, overwrite: true);
				}
				catch (Exception ex2)
				{
					ilog_0.ErrorFormat(ex2.ToString(), Array.Empty<object>());
					ilog_0.ErrorFormat(global::_003CModule_003E.smethod_7<string>(1443702798u) + file.FullName, Array.Empty<object>());
					ilog_0.ErrorFormat(global::_003CModule_003E.smethod_5<string>(2051905776u) + text, Array.Empty<object>());
					ilog_0.ErrorFormat(global::_003CModule_003E.smethod_7<string>(4148327574u), Array.Empty<object>());
					Terminate();
				}
			}
		}
		if (copySubDirs)
		{
			DirectoryInfo[] array2 = directories;
			foreach (DirectoryInfo directoryInfo3 in array2)
			{
				string destDirName2 = Path.Combine(destDirName, directoryInfo3.Name);
				DirectoryCopy(directoryInfo3.FullName, destDirName2, copySubDirs);
			}
		}
	}

	private static bool FilesAreEqual(FileInfo first, FileInfo second)
	{
		if (first.Length != second.Length)
		{
			return false;
		}
		if (!(first.CreationTime != second.CreationTime))
		{
			if (!(first.LastWriteTime != second.LastWriteTime))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public static void Terminate()
	{
		try
		{
			Process.GetProcessesByName(global::_003CModule_003E.smethod_9<string>(3105127986u)).FirstOrDefault()?.Kill();
			int num = 60;
			ilog_0.ErrorFormat(string.Format(global::_003CModule_003E.smethod_5<string>(3131863756u), 60), Array.Empty<object>());
			Process.Start(global::_003CModule_003E.smethod_9<string>(3965458353u), global::_003CModule_003E.smethod_6<string>(727712074u) + num);
			LokiPoe.Memory.Process.Kill();
		}
		catch (Exception ex)
		{
			ilog_0.ErrorFormat(ex.Message ?? "", Array.Empty<object>());
		}
	}
}
