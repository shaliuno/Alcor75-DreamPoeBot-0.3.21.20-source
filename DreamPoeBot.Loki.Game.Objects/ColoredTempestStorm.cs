namespace DreamPoeBot.Loki.Game.Objects;

public class ColoredTempestStorm : NetworkObject
{
	private static readonly string string_2 = smethod_0(global::_003CModule_003E.smethod_6<string>(204463436u));

	private static readonly string string_3 = smethod_0(global::_003CModule_003E.smethod_9<string>(3119558088u));

	private static readonly string string_4 = smethod_0(global::_003CModule_003E.smethod_7<string>(2826444889u));

	private static readonly string string_5 = smethod_0(global::_003CModule_003E.smethod_7<string>(3119386498u));

	private static readonly string string_6 = smethod_0(global::_003CModule_003E.smethod_8<string>(64915480u));

	private static readonly string string_7 = smethod_0(global::_003CModule_003E.smethod_9<string>(2944818199u));

	private static readonly string string_8 = smethod_0(global::_003CModule_003E.smethod_8<string>(3710349159u));

	private static readonly string string_9 = smethod_0(global::_003CModule_003E.smethod_5<string>(2724863722u));

	private static readonly string string_10 = smethod_0(global::_003CModule_003E.smethod_9<string>(3287613438u));

	public TempestColors Color { get; private set; }

	public override string Name => global::_003CModule_003E.smethod_9<string>(1056102115u) + Color.ToString() + global::_003CModule_003E.smethod_8<string>(2461105257u);

	private static string smethod_0(string string_11)
	{
		return string.Format(global::_003CModule_003E.smethod_6<string>(4054137981u), string_11);
	}

	internal ColoredTempestStorm(NetworkObject entry)
		: base(entry._entity)
	{
		Color = TempestColors.Unknown;
		string text = base.Type.ToLowerInvariant();
		if (text.Equals(string_2))
		{
			Color = TempestColors.Blue;
		}
		else if (text.Equals(string_3))
		{
			Color = TempestColors.Green;
		}
		else if (text.Equals(string_4))
		{
			Color = TempestColors.Orange;
		}
		else if (text.Equals(string_5))
		{
			Color = TempestColors.Pink;
		}
		else if (text.Equals(string_6))
		{
			Color = TempestColors.Purple;
		}
		else if (text.Equals(string_7))
		{
			Color = TempestColors.Red;
		}
		else if (text.Equals(string_8))
		{
			Color = TempestColors.Teal;
		}
		else if (text.Equals(string_9))
		{
			Color = TempestColors.White;
		}
		else if (text.Equals(string_10))
		{
			Color = TempestColors.Yellow;
		}
	}
}
