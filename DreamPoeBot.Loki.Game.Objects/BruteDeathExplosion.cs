namespace DreamPoeBot.Loki.Game.Objects;

public class BruteDeathExplosion : NetworkObject
{
	public const string TypeMetadata = "Metadata/Effects/Spells/monsters_effects/brute_death/BruteDeathExplosion";

	public override string Name => global::_003CModule_003E.smethod_5<string>(1997777317u);

	internal BruteDeathExplosion(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
