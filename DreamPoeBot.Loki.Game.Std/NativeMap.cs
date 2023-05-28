using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.Std;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NativeMap
{
	public long Head;

	public uint Size;

	public override string ToString()
	{
		return string.Format(global::_003CModule_003E.smethod_5<string>(2852708211u), Head.ToString(global::_003CModule_003E.smethod_5<string>(3360573637u)), Size);
	}
}
