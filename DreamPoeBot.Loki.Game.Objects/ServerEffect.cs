using System.Text;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class ServerEffect : NetworkObject
{
	public const string TypeMetadata = "Metadata/Effects/ServerEffect";

	internal ServerEffect(EntityWrapper entry)
		: base(entry)
	{
	}

	internal ServerEffect(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3580009657u), base._entity.Address));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(1550989758u), base.AnimatedPropertiesMetadata));
		return stringBuilder.ToString();
	}
}
