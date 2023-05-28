using System;
using System.Globalization;
using System.Linq;

namespace DreamPoeBot.Loki.Models;

public struct Pattern
{
	public byte[] Bytes;

	public string Mask;

	public Pattern(byte[] pattern, string mask)
	{
		Bytes = pattern;
		Mask = mask;
	}

	public Pattern(string pattern, string mask)
	{
		string[] source = pattern.Split(new string[1] { global::_003CModule_003E.smethod_8<string>(3614174920u) }, StringSplitOptions.RemoveEmptyEntries);
		Bytes = source.Select((string y) => byte.Parse(y, NumberStyles.HexNumber)).ToArray();
		Mask = mask;
	}
}
