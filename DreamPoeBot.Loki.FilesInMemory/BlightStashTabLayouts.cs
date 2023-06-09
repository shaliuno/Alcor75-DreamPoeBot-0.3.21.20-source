using System;
using System.Collections.Generic;
using DreamPoeBot.Properties;

namespace DreamPoeBot.Loki.FilesInMemory;

public class BlightStashTabLayouts
{
	public class BlightStashTabLayoutHardcoded
	{
		public string Metadata { get; private set; }

		public short PosX { get; private set; }

		public short PosY { get; private set; }

		public short Order { get; private set; }

		public BlightStashTabLayoutHardcoded(string metadata, short posX, short posY, short order)
		{
			Metadata = metadata;
			PosX = posX;
			PosY = posY;
			Order = order;
		}
	}

	private static Dictionary<string, BlightStashTabLayoutHardcoded> _data;

	public Dictionary<string, BlightStashTabLayoutHardcoded> Data
	{
		get
		{
			if (_data == null)
			{
				_data = new Dictionary<string, BlightStashTabLayoutHardcoded>();
				string[] array = Resources.BlightStashTabLayout.Split(new string[3]
				{
					global::_003CModule_003E.smethod_9<string>(1489627540u),
					global::_003CModule_003E.smethod_8<string>(2522912422u),
					global::_003CModule_003E.smethod_9<string>(2795115544u)
				}, StringSplitOptions.None);
				for (int i = 1; i < array.Length; i++)
				{
					string text = array[i];
					if (!string.IsNullOrEmpty(text))
					{
						string text2 = text.Replace(global::_003CModule_003E.smethod_5<string>(1762848925u), "").Replace(global::_003CModule_003E.smethod_8<string>(4219745250u), "").Replace(global::_003CModule_003E.smethod_6<string>(704202010u), "")
							.Replace(global::_003CModule_003E.smethod_5<string>(2125621806u), "")
							.Replace(global::_003CModule_003E.smethod_6<string>(2604959965u), "");
						string[] array2 = text2.Split(',');
						string text3 = array2[0];
						short posX = Convert.ToInt16(array2[3]);
						short posY = Convert.ToInt16(array2[4]);
						short order = Convert.ToInt16(array2[5]);
						_data.Add(text3, new BlightStashTabLayoutHardcoded(text3, posX, posY, order));
					}
				}
			}
			return _data;
		}
	}
}
