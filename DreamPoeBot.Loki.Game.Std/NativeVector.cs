using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.Std;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NativeVector
{
	public long First;

	public long Last;

	public long End;

	public override string ToString()
	{
		return string.Format(global::_003CModule_003E.smethod_9<string>(4009452236u), First.ToString(global::_003CModule_003E.smethod_6<string>(2756242974u)), Last.ToString(global::_003CModule_003E.smethod_8<string>(2050146120u)), End.ToString(global::_003CModule_003E.smethod_6<string>(2756242974u)));
	}
}
