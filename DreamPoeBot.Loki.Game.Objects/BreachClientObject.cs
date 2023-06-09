using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game.GameData;

namespace DreamPoeBot.Loki.Game.Objects;

public class BreachClientObject : NetworkObject
{
	public const string TypeMetadata = "Metadata/MiscellaneousObjects/Breach/BreachClientObject";

	public override string Name => global::_003CModule_003E.smethod_7<string>(3087684142u);

	public string AttachedEffect => base.Components.BreachObject.AttachedEffect;

	public Vector2i BreachPosition => base.Components.BreachObject.BreachPosition;

	public float Radius => base.Components.BreachObject.Radius;

	public BreachState State => base.Components.BreachObject.State;

	internal BreachClientObject(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
