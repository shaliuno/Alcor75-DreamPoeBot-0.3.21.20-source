using System.Text;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Game.Objects;

public class DarkShrine : NetworkObject
{
	public const string TypeMetadata = "Metadata/Shrines/DarkShrine";

	private PerFrameCachedValue<bool> perFrameCachedValue_5;

	public bool IsDeactivated
	{
		get
		{
			if (perFrameCachedValue_5 == null)
			{
				perFrameCachedValue_5 = new PerFrameCachedValue<bool>(method_8);
			}
			return perFrameCachedValue_5;
		}
	}

	internal DarkShrine(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(2440652149u)));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(2591781484u), base._entity.Address));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(527081659u), base.Id));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(2468910437u), Name));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3316856698u), base.Type));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(716977822u), base.Position));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(10265105u), base.Distance));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3407799199u), IsDeactivated));
		return stringBuilder.ToString();
	}

	private bool method_8()
	{
		return base.Components.TransitionableComponent.Flag1 != 1;
	}
}
