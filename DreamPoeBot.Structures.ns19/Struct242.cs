using System;
using System.Runtime.InteropServices;

namespace DreamPoeBot.Structures.ns19;

[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct Struct242
{
	public long intptr_1;

	public long intptr_0;

	public bool method_0(Struct242 struct242_0)
	{
		if (intptr_0 == struct242_0.intptr_0)
		{
			return intptr_1 == struct242_0.intptr_1;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(global::_003CModule_003E.smethod_8<string>(2830766403u), intptr_0, intptr_1);
	}
}
