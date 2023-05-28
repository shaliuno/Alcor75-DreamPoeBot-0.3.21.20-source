using System.Runtime.InteropServices;

namespace DreamPoeBot.Structures.ns19;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct Struct253WorldItemComp
{
	internal readonly long intptr_0;

	internal readonly long intptr_1;

	public new string ToString()
	{
		return string.Format(global::_003CModule_003E.smethod_8<string>(46407245u), intptr_0, intptr_1);
	}
}
