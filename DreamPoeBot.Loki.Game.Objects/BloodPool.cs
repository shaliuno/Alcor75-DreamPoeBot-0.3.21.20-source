namespace DreamPoeBot.Loki.Game.Objects;

public class BloodPool : NetworkObject
{
	public const string TypeMetadata = "Metadata/Effects/Spells/Masters/Dex/BloodPool";

	public override string Name => global::_003CModule_003E.smethod_6<string>(2837129733u);

	internal BloodPool(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
