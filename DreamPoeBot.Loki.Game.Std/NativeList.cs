using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.Std;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NativeList
{
	public readonly long Head;

	public readonly uint Size;

	public readonly int unusedInt0;

	public override string ToString()
	{
		return string.Format(global::_003CModule_003E.smethod_9<string>(1952680802u), Head.ToString(global::_003CModule_003E.smethod_8<string>(2050146120u)), Size);
	}
}
