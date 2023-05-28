namespace DreamPoeBot.Loki.Game.Objects;

public class LightningTempestStorm : NetworkObject
{
	public const string TypeMetadata = "Metadata/Effects/Environment/tempest_league/elements/lightning/TempestStorm";

	public override string Name => global::_003CModule_003E.smethod_5<string>(1791817587u);

	internal LightningTempestStorm(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
