using System;
using System.Security.Cryptography;
using System.Text;

namespace DreamPoeBot.Loki.Common;

public static class Util
{
	public static string CalculateMD5Hash(string input)
	{
		HashAlgorithm hashAlgorithm = MD5.Create();
		byte[] bytes = Encoding.ASCII.GetBytes(input);
		byte[] array = hashAlgorithm.ComputeHash(bytes);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString(global::_003CModule_003E.smethod_7<string>(4076069461u)));
		}
		return stringBuilder.ToString();
	}

	public static string RandomWindowTitle(string title)
	{
		return string.Format(global::_003CModule_003E.smethod_8<string>(2489979133u), title, CalculateMD5Hash(title + Environment.TickCount + new Random().NextDouble()));
	}
}
