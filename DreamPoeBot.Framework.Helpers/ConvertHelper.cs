using System;
using System.Globalization;
using SharpDX;

namespace DreamPoeBot.Framework.Helpers;

public static class ConvertHelper
{
	public static string ToShorten(double value, string format = "0")
	{
		double num = Math.Abs(value);
		if (num < 1000000.0)
		{
			if (num >= 1000.0)
			{
				return (value / 1000.0).ToString(global::_003CModule_003E.smethod_8<string>(3694629158u)) + global::_003CModule_003E.smethod_5<string>(275953365u);
			}
			return value.ToString(format);
		}
		return (value / 1000000.0).ToString(global::_003CModule_003E.smethod_6<string>(2679315270u)) + global::_003CModule_003E.smethod_5<string>(815932355u);
	}

	public static Color ToBGRAColor(this string value)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		if (!uint.TryParse(value, NumberStyles.HexNumber, null, out var result))
		{
			return Color.Black;
		}
		return Color.FromBgra(result);
	}

	public static Color? ConfigColorValueExtractor(this string[] line, int index)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		if (!IsNotNull(line, index))
		{
			return null;
		}
		return line[index].ToBGRAColor();
	}

	public static string ConfigValueExtractor(this string[] line, int index)
	{
		if (!IsNotNull(line, index))
		{
			return null;
		}
		return line[index];
	}

	private static bool IsNotNull(string[] line, int index)
	{
		if (line.Length > index)
		{
			return !string.IsNullOrEmpty(line[index]);
		}
		return false;
	}
}
