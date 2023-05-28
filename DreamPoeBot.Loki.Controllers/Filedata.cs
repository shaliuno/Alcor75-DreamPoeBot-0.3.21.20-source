using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Controllers;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Filedata
{
	public readonly int unusedInt1;

	public readonly int unusedInt2;

	public readonly long fileAddress;

	public readonly long unusedLong;
}
