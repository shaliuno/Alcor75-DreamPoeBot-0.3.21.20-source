namespace DreamPoeBot.Loki.Game.Objects;

public class IceTempestStorm : NetworkObject
{
	public const string TypeMetadata = "Metadata/Effects/Environment/tempest_league/elements/ice/TempestStorm";

	public override string Name => global::_003CModule_003E.smethod_6<string>(3405743959u);

	internal IceTempestStorm(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
