namespace DreamPoeBot.Loki.Game.Objects;

public class MissionMarker : NetworkObject
{
	public const string TypeMetadata = "Metadata/MiscellaneousObjects/MissionMarker";

	public override string Name => global::_003CModule_003E.smethod_9<string>(4119139071u);

	internal MissionMarker(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
