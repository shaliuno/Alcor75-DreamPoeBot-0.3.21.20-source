using System;
using System.IO;
using DreamPoeBot.Loki.Common;
using log4net;
using Newtonsoft.Json;

namespace DreamPoeBot.Framework.Helpers;

public static class Misc
{
	private class SelectedProfile
	{
		public string Name { get; set; }
	}

	private static readonly string RandomSelectedProfilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, global::_003CModule_003E.smethod_5<string>(1102498266u));

	private static readonly ILog Ilog = Logger.GetLoggerInstanceForType();

	private static string LoadProfile()
	{
		string text = Path.Combine(RandomSelectedProfilePath, global::_003CModule_003E.smethod_8<string>(1580737173u));
		if (!File.Exists(text))
		{
			return "";
		}
		string text2 = File.ReadAllText(text);
		SelectedProfile selectedProfile = JsonConvert.DeserializeObject<SelectedProfile>(text2);
		if (selectedProfile == null)
		{
			Ilog.ErrorFormat(global::_003CModule_003E.smethod_6<string>(278661181u) + text + global::_003CModule_003E.smethod_5<string>(4284354750u), Array.Empty<object>());
			return "";
		}
		return selectedProfile.Name;
	}

	private static void SaveProfile(string profile)
	{
		SelectedProfile selectedProfile = new SelectedProfile();
		selectedProfile.Name = profile;
		string contents = JsonConvert.SerializeObject((object)selectedProfile);
		if (!Directory.Exists(RandomSelectedProfilePath))
		{
			Ilog.ErrorFormat(global::_003CModule_003E.smethod_8<string>(1792278077u), Array.Empty<object>());
			Directory.CreateDirectory(RandomSelectedProfilePath);
		}
		string path = Path.Combine(RandomSelectedProfilePath, global::_003CModule_003E.smethod_6<string>(2984430069u));
		File.WriteAllText(path, contents);
	}
}
