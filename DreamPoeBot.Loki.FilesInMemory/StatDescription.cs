using System;
using System.Collections.Generic;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Properties;

namespace DreamPoeBot.Loki.FilesInMemory;

public class StatDescription
{
	private static Dictionary<string, string> _data;

	public Dictionary<string, string> Data
	{
		get
		{
			if (_data == null)
			{
				_data = new Dictionary<string, string>();
				string[] array = Resources.StatDescription.Split(new string[3]
				{
					global::_003CModule_003E.smethod_6<string>(3409970898u),
					global::_003CModule_003E.smethod_5<string>(2302827915u),
					global::_003CModule_003E.smethod_7<string>(310688412u)
				}, StringSplitOptions.None);
				for (int i = 1; i < array.Length; i++)
				{
					string[] array2 = array[i].Split(',');
					_data.Add(LokiPoe.CleanifyStatString(array2[0]), array2[1]);
				}
			}
			return _data;
		}
	}
}
