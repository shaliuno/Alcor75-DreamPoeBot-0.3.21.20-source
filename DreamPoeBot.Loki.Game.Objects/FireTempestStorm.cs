namespace DreamPoeBot.Loki.Game.Objects;

public class FireTempestStorm : NetworkObject
{
	public const string TypeMetadata = "Metadata/Effects/Environment/tempest_league/elements/fire/TempestStorm";

	public override string Name => global::_003CModule_003E.smethod_6<string>(2860013440u);

	internal FireTempestStorm(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
