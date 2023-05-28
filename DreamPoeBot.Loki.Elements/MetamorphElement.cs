using System.Collections.Generic;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class MetamorphElement : Element
{
	public Element CreateButtonElement => base.Children[3]?.Children[2];

	private Element IngredientsElement => base.Children[3]?.Children[0]?.Children[0]?.Children[2];

	public List<LokiPoe.InGameState.MetamorphUi.Ingredient> Ingredients
	{
		get
		{
			List<LokiPoe.InGameState.MetamorphUi.Ingredient> list = new List<LokiPoe.InGameState.MetamorphUi.Ingredient>();
			foreach (Element child in IngredientsElement.Children)
			{
				if (child == null || child.ChildCount < 2L)
				{
					continue;
				}
				LokiPoe.InGameState.MetamorphUi.Category category = GetCategory(child);
				foreach (Element child2 in child.Children[0].Children)
				{
					list.Add(new LokiPoe.InGameState.MetamorphUi.Ingredient(child2, category));
				}
			}
			return list;
		}
	}

	private LokiPoe.InGameState.MetamorphUi.Category GetCategory(Element element)
	{
		if (element.Children[1]?.Children[0] == null)
		{
			return LokiPoe.InGameState.MetamorphUi.Category.none;
		}
		string text = element.Children[1].Children[0].Text;
		if (!(text == global::_003CModule_003E.smethod_5<string>(1456185229u)))
		{
			if (text == global::_003CModule_003E.smethod_8<string>(3997799037u))
			{
				return LokiPoe.InGameState.MetamorphUi.Category.Eyes;
			}
			if (text == global::_003CModule_003E.smethod_5<string>(2714962416u))
			{
				return LokiPoe.InGameState.MetamorphUi.Category.Lungs;
			}
			if (!(text == global::_003CModule_003E.smethod_5<string>(3516642693u)))
			{
				if (!(text == global::_003CModule_003E.smethod_5<string>(3246653198u)))
				{
					return LokiPoe.InGameState.MetamorphUi.Category.none;
				}
				return LokiPoe.InGameState.MetamorphUi.Category.Livers;
			}
			return LokiPoe.InGameState.MetamorphUi.Category.Hearts;
		}
		return LokiPoe.InGameState.MetamorphUi.Category.Brains;
	}
}
