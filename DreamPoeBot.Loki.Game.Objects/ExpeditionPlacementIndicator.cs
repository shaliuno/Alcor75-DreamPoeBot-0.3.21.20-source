namespace DreamPoeBot.Loki.Game.Objects;

public class ExpeditionPlacementIndicator : NetworkObject
{
	public override string Name => global::_003CModule_003E.smethod_7<string>(1749306384u);

	public bool IsMarkerEnabled => base.AnimatedPropertiesMetadata == global::_003CModule_003E.smethod_7<string>(4092839256u);

	internal ExpeditionPlacementIndicator(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
