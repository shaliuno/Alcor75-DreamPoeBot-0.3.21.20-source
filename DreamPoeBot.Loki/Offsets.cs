using System;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki;

public class Offsets
{
	public static Offsets Regular = new Offsets
	{
		IgsOffset = 0,
		IgsDelta = 0,
		ExeName = global::_003CModule_003E.smethod_6<string>(2059855803u)
	};

	public static Offsets Steam = new Offsets
	{
		IgsOffset = 40,
		IgsDelta = 0,
		ExeName = global::_003CModule_003E.smethod_5<string>(1666042795u)
	};

	private static readonly Pattern diagnosticElementPattern = new Pattern(new byte[15]
	{
		72, 137, 92, 0, 0, 87, 72, 131, 236, 32,
		232, 0, 0, 0, 0
	}, global::_003CModule_003E.smethod_9<string>(771794540u));

	private static readonly Pattern fileRootPattern = new Pattern(new byte[14]
	{
		72, 139, 8, 72, 141, 61, 0, 0, 0, 0,
		65, 139, 4, 14
	}, global::_003CModule_003E.smethod_5<string>(3555969260u));

	private static readonly Pattern areaLoadedFiles = new Pattern(new byte[20]
	{
		72, 0, 0, 0, 0, 0, 0, 0, 65, 0,
		0, 0, 57, 0, 0, 0, 0, 0, 15, 142
	}, global::_003CModule_003E.smethod_5<string>(1674331003u));

	private static readonly Pattern areaChangePattern = new Pattern(new byte[13]
	{
		255, 0, 0, 0, 0, 0, 232, 0, 0, 0,
		0, 255, 5
	}, global::_003CModule_003E.smethod_6<string>(1760768234u));

	private static readonly Pattern GameStatePattern = new Pattern(new byte[12]
	{
		72, 139, 241, 51, 237, 72, 57, 45, 0, 0,
		0, 0
	}, global::_003CModule_003E.smethod_9<string>(2947945801u));

	public long AreaChangeCount { get; private set; }

	public long Base { get; private set; }

	public string ExeName { get; private set; }

	public long FileRoot { get; private set; }

	public int IgsDelta { get; private set; }

	public int IgsOffset { get; private set; }

	public int IgsOffsetDelta => IgsOffset + IgsDelta;

	public long isLoadingScreenOffset { get; private set; }

	public long GameStateOffset { get; private set; }

	public long DiagnosticElementOffset { get; private set; }

	public long AreaLoadedFilesOffset { get; private set; }

	public byte[] TerrainRotationHelper { get; set; }

	public byte[] TerrainRotationSelector { get; set; }

	public void DoPatternScans(Memory m)
	{
		long[] array = m.FindPatterns(fileRootPattern, areaChangePattern, GameStatePattern, diagnosticElementPattern, areaLoadedFiles);
		long addr = m.AddressOfProcess + array[0] + 6L;
		int num = m.ReadInt(addr);
		FileRoot = num + array[0] + 10L;
		Console.WriteLine(global::_003CModule_003E.smethod_7<string>(2998451819u) + (FileRoot + m.AddressOfProcess).ToString(global::_003CModule_003E.smethod_5<string>(3032566686u)));
		AreaChangeCount = m.ReadInt(m.AddressOfProcess + array[1] + 12L) + array[1] + 16L;
		Console.WriteLine(global::_003CModule_003E.smethod_6<string>(3598835327u) + m.ReadInt(AreaChangeCount + m.AddressOfProcess));
		int num2 = m.ReadInt(m.AddressOfProcess + array[2] + 8L);
		GameStateOffset = num2 + array[2] + 12L;
		Console.WriteLine(global::_003CModule_003E.smethod_6<string>(2457155405u) + (GameStateOffset + m.AddressOfProcess).ToString(global::_003CModule_003E.smethod_6<string>(867956997u)));
		long addr2 = m.AddressOfProcess + array[3] + 378L;
		int num3 = m.ReadInt(addr2);
		DiagnosticElementOffset = num3 + array[3] + 402L;
		int num4 = m.ReadInt(m.AddressOfProcess + array[4] + 6L);
		AreaLoadedFilesOffset = num4 + array[4] + 16L;
	}
}
