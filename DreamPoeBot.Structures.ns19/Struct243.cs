using System.Runtime.InteropServices;

namespace DreamPoeBot.Structures.ns19;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct Struct243
{
	public long intptr_1;

	public long intptr_0;

	public bool method_0(Struct243 struct243_0)
	{
		if (intptr_0 == struct243_0.intptr_0)
		{
			return intptr_1 == struct243_0.intptr_1;
		}
		return false;
	}

	public new string ToString()
	{
		return string.Format(global::_003CModule_003E.smethod_7<string>(2723146705u), intptr_0, intptr_1);
	}
}
