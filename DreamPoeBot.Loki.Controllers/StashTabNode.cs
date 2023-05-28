using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using Newtonsoft.Json;

namespace DreamPoeBot.Loki.Controllers;

public class StashTabNode
{
	public const string EMPTYNAME = "-NoName-";

	public string Name { get; set; }

	public int VisibleIndex { get; set; }

	[JsonIgnore]
	public bool Exist { get; set; }

	[JsonIgnore]
	internal int Id { get; set; }

	[JsonIgnore]
	public bool IsRemoveOnly { get; set; }

	public StashTabNode()
	{
		Name = global::_003CModule_003E.smethod_6<string>(119125207u);
		VisibleIndex = -1;
		Id = -1;
		base._002Ector();
	}

	public StashTabNode(string name, int visibleIndex)
	{
		Name = global::_003CModule_003E.smethod_7<string>(4229094059u);
		VisibleIndex = -1;
		Id = -1;
		base._002Ector();
		Name = name;
		VisibleIndex = visibleIndex;
	}

	public StashTabNode(ServerStashTab serverTab, int id)
	{
		Name = global::_003CModule_003E.smethod_8<string>(2440294639u);
		VisibleIndex = -1;
		Id = -1;
		base._002Ector();
		Name = serverTab.DisplayName;
		VisibleIndex = serverTab.DisplayIndex;
		IsRemoveOnly = (serverTab.inventoryTabFlags & InventoryTabFlags.RemoveOnly) == InventoryTabFlags.RemoveOnly;
		Id = id;
	}
}
