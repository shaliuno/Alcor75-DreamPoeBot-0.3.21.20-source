using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;

namespace DreamPoeBot.WPFLocalizeExtension.TypeConverters;

internal class ThicknessConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		return sourceType == typeof(string);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		Thickness thickness = default(Thickness);
		uint num2 = default(uint);
		while (true)
		{
			double result = 0.0;
			double result2 = 0.0;
			double result3 = 0.0;
			double result4 = 0.0;
			if (!(value is string))
			{
				break;
			}
			while (true)
			{
				string[] array = ((string)value).Split(global::_003CModule_003E.smethod_9<string>(713517439u).ToCharArray());
				int num = array.Length;
				while (true)
				{
					switch (num)
					{
					case 1:
						goto IL_00f5;
					case 2:
						goto IL_0114;
					case 4:
						goto IL_0145;
					case 3:
						goto end_IL_00bf;
					}
					int num3 = (int)(num2 * 1812592935) ^ -587122632;
					while (true)
					{
						switch ((num2 = (uint)num3 ^ 0xC232C4A1u) % 15u)
						{
						case 14u:
							num3 = (int)(num2 * 1096049361) ^ -1264487815;
							continue;
						case 5u:
							break;
						case 12u:
							goto end_IL_007d;
						case 7u:
						case 11u:
							goto end_IL_009b;
						case 2u:
							goto IL_00f5;
						case 8u:
							goto IL_0114;
						case 4u:
							goto IL_0126;
						case 0u:
							goto IL_0138;
						case 9u:
							goto IL_0145;
						case 13u:
							goto IL_0157;
						case 10u:
							goto IL_0169;
						case 3u:
							goto IL_018d;
						default:
							goto end_IL_00bf;
						}
						break;
					}
					continue;
					IL_0138:
					thickness = new Thickness(result, result2, result, result2);
					goto end_IL_00bf;
					IL_00f5:
					double.TryParse(array[0], NumberStyles.Any, culture, out result);
					thickness = new Thickness(result);
					goto end_IL_00bf;
					IL_0145:
					double.TryParse(array[0], NumberStyles.Any, culture, out result);
					goto IL_0157;
					IL_0157:
					double.TryParse(array[1], NumberStyles.Any, culture, out result2);
					goto IL_0169;
					IL_0169:
					double.TryParse(array[2], NumberStyles.Any, culture, out result3);
					double.TryParse(array[3], NumberStyles.Any, culture, out result4);
					goto IL_018d;
					IL_018d:
					thickness = new Thickness(result, result2, result3, result4);
					goto end_IL_00bf;
					IL_0114:
					double.TryParse(array[0], NumberStyles.Any, culture, out result);
					goto IL_0126;
					IL_0126:
					double.TryParse(array[1], NumberStyles.Any, culture, out result2);
					goto IL_0138;
					continue;
					end_IL_007d:
					break;
				}
				continue;
				end_IL_009b:
				break;
			}
			continue;
			end_IL_00bf:
			break;
		}
		return thickness;
	}
}
