using System.Text;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class Effect : NetworkObject
{
	public const string TypeMetadata = "Metadata/Effects/Effect";

	internal Effect(EntityWrapper entry)
		: base(entry)
	{
	}

	internal Effect(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(825522281u), base._entity));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(2714093413u), base.AnimatedPropertiesMetadata));
		return stringBuilder.ToString();
	}
}
