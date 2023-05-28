namespace DreamPoeBot.Loki.Game.Objects;

public class WaterGeyser : NetworkObject
{
	public const string TypeMetadata = "Metadata/Effects/Spells/monsters_effects/act1/merveil/water_geyser/WaterGeyser";

	public override string Name => global::_003CModule_003E.smethod_6<string>(3018600011u);

	internal WaterGeyser(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
