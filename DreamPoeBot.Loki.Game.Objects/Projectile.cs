using System.Text;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class Projectile : NetworkObject
{
	internal Projectile(EntityWrapper entry)
		: base(entry)
	{
	}

	internal Projectile(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(1828926940u), base._entity.Address));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(606475432u), base.AnimatedPropertiesMetadata));
		return stringBuilder.ToString();
	}
}
