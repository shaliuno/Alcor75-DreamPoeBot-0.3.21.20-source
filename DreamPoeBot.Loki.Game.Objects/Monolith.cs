using System.Collections.Generic;
using System.Linq;
using System.Text;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class Monolith : NetworkObject
{
	public const string TypeMetadata = "Metadata/MiscellaneousObjects/Monolith";

	private string string_2;

	private int int_1 = -1;

	public int ChildNetworkObjectId
	{
		get
		{
			if (int_1 == -1)
			{
				Monster monster = LokiPoe.ObjectManager.GetObjectsByPosition<Monster>(base.Position).FirstOrDefault();
				if (monster != null)
				{
					int_1 = monster.Id;
				}
			}
			return int_1;
		}
	}

	public NetworkObject ChildNetworkObject => LokiPoe.ObjectManager.GetObjectById(ChildNetworkObjectId);

	public int OpenPhase => base.Components.MonolithComponent.OpenPhase;

	public bool IsCorrupted => base.Components.MonolithComponent.IsCorrupted;

	public virtual bool IsMini => false;

	public string MonsterTypeId => base.Components.MonolithComponent.MonsterTypeId;

	public string MonsterTypeMetadata => base.Components.MonolithComponent.MonsterTypeMetadata;

	public List<DatBaseItemTypeWrapper> EssenceBaseItemTypes => base.Components.MonolithComponent.EssenceBaseItemTypes;

	public override string Name
	{
		get
		{
			if (string_2 == null)
			{
				NetworkObject childNetworkObject = ChildNetworkObject;
				if (!object.Equals(ChildNetworkObject, null))
				{
					string_2 = childNetworkObject.Name;
				}
				else
				{
					string_2 = global::_003CModule_003E.smethod_8<string>(75320789u);
				}
			}
			return string_2;
		}
	}

	internal Monolith(EntityWrapper entry)
		: base(entry)
	{
	}

	internal Monolith(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(4237788663u), Name));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3885427883u), IsMini));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(508628832u), OpenPhase));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(3628342099u), ChildNetworkObjectId));
		if (ChildNetworkObject != null)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3574756897u), ChildNetworkObject.Name));
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3701915757u), ChildNetworkObject.Metadata));
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3262566813u), MonsterTypeId));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3215189378u), MonsterTypeMetadata));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(1556696563u)));
		foreach (DatBaseItemTypeWrapper essenceBaseItemType in EssenceBaseItemTypes)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(955040355u), essenceBaseItemType.Name, essenceBaseItemType.Metadata));
		}
		return stringBuilder.ToString();
	}
}
