using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class CraftingRecipe : NetworkObject
{
	public bool IsOpened
	{
		get
		{
			Transitionable component = base._entity.GetComponent<Transitionable>();
			if (component != null)
			{
				return component.Flag1 == 2;
			}
			return true;
		}
	}

	internal CraftingRecipe(EntityWrapper entity)
		: base(entity)
	{
	}
}
