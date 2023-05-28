namespace DreamPoeBot.Loki.Elements.InventoryElements;

public class MapSubInventoryInfo
{
	public int Tier;

	public int Count;

	public string MapName;

	public override string ToString()
	{
		return global::_003CModule_003E.smethod_5<string>(497029000u) + Tier + global::_003CModule_003E.smethod_7<string>(357027340u) + Count + global::_003CModule_003E.smethod_8<string>(4264477965u) + MapName;
	}
}
