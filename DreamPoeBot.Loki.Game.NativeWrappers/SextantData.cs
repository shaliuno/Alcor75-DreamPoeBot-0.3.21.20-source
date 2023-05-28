using System.Collections.Generic;
using System.Text;
using DreamPoeBot.Loki.Game.GameData;

namespace DreamPoeBot.Loki.Game.NativeWrappers;

public class SextantData
{
	public int UsesLeft { get; internal set; }

	public DatWorldAreaWrapper WorldArea { get; internal set; }

	public DatModsWrapper Mod { get; internal set; }

	public List<int> Data { get; internal set; }

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(4143051602u), WorldArea.Id));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1911540279u), UsesLeft));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1051209912u), Mod.InternalName));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(204248623u), string.Join(global::_003CModule_003E.smethod_6<string>(396436032u), Data)));
		return stringBuilder.ToString();
	}
}
