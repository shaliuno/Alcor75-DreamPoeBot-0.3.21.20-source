using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.Std;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NativeHashMap
{
	public readonly int Proxy;

	public readonly int unusedInt0;

	public readonly NativeList List;

	public readonly NativeVector Vector;

	public readonly int Mask;

	public readonly int unusedInt1;

	public readonly int MaxIdx;

	public readonly int unusedInt2;

	public override string ToString()
	{
		return string.Format(global::_003CModule_003E.smethod_7<string>(369689317u), List, Vector);
	}
}
