using System.Text;
using DreamPoeBot.Common;

namespace DreamPoeBot.Loki.Game.Objects;

public class Arrow : NetworkObject
{
	public const string TypeMetadata = "Metadata/Effects/Spells/Masters/Dex/Arrow";

	public override string Name => global::_003CModule_003E.smethod_5<string>(2416954556u);

	public Vector2i Destination => new Vector2i(0, 0);

	public bool Visible => false;

	internal Arrow(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3254295464u)));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(2591781484u), base._entity.Address));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(527081659u), base.Id));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3375923685u), Name));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3316856698u), base.Type));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3083343522u), base.Position));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(10265105u), base.Distance));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(2542493634u), Visible));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(779754867u), Destination));
		return stringBuilder.ToString();
	}
}
