using System.Diagnostics;
using System.Text;

namespace DreamPoeBot.Loki.Game;

public class ReleaseFrameProfile
{
	public string Caller { get; set; }

	public uint StartFrame { get; set; }

	public uint FinishtFrame { get; set; }

	public Stopwatch FuncTimer { get; set; }

	public Stopwatch TotalTimer { get; set; }

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(2268395833u)));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(304608122u), Caller));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(1839055895u), StartFrame, FinishtFrame, FinishtFrame - StartFrame));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3587518108u), FuncTimer.Elapsed));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(688220039u), TotalTimer.Elapsed));
		stringBuilder.AppendLine();
		return stringBuilder.ToString();
	}
}
