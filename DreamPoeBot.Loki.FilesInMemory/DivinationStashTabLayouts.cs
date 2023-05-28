using System;
using System.Collections.Generic;
using DreamPoeBot.Properties;

namespace DreamPoeBot.Loki.FilesInMemory;

public class DivinationStashTabLayouts
{
	public class DivinationStashTabLayoutHardcoded
	{
		public int BaseItemTypeId { get; private set; }

		public bool IsEnabled { get; private set; }

		public bool Unknown { get; private set; }

		public DivinationStashTabLayoutHardcoded(int baseItemTypeId, bool isEnabled, bool unknown)
		{
			BaseItemTypeId = baseItemTypeId;
			IsEnabled = isEnabled;
			Unknown = unknown;
		}
	}

	private static Dictionary<int, DivinationStashTabLayoutHardcoded> _data;

	public Dictionary<int, DivinationStashTabLayoutHardcoded> Data
	{
		get
		{
			if (_data == null)
			{
				_data = new Dictionary<int, DivinationStashTabLayoutHardcoded>();
				string[] array = Resources.DivinationCardStashTabLayout.Split(new string[3]
				{
					global::_003CModule_003E.smethod_7<string>(681192168u),
					global::_003CModule_003E.smethod_7<string>(1267075386u),
					global::_003CModule_003E.smethod_9<string>(2795115544u)
				}, StringSplitOptions.None);
				for (int i = 1; i < array.Length; i++)
				{
					string text = array[i];
					if (!string.IsNullOrEmpty(text))
					{
						string text2 = text.Replace(global::_003CModule_003E.smethod_7<string>(1852958604u), "").Replace(global::_003CModule_003E.smethod_8<string>(4219745250u), "").Replace(global::_003CModule_003E.smethod_9<string>(4231989452u), "")
							.Replace(global::_003CModule_003E.smethod_7<string>(3100791729u), "")
							.Replace(global::_003CModule_003E.smethod_5<string>(1784353606u), "");
						string[] array2 = text2.Split(',');
						short num = Convert.ToInt16(array2[0]);
						bool isEnabled = array2[2] == global::_003CModule_003E.smethod_5<string>(167776579u);
						bool unknown = array2[3] == global::_003CModule_003E.smethod_8<string>(931850046u);
						_data.Add(num, new DivinationStashTabLayoutHardcoded(num, isEnabled, unknown));
					}
				}
			}
			return _data;
		}
	}
}
