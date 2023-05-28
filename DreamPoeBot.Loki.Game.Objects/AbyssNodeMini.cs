namespace DreamPoeBot.Loki.Game.Objects;

public class AbyssNodeMini : NetworkObject
{
	public override string Name => global::_003CModule_003E.smethod_8<string>(4291551209u);

	public float TimeLeft => base.Components.Timer.TimeLeft;

	internal AbyssNodeMini(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
