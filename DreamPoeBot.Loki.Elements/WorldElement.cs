using System.Collections.Generic;
using System.Linq;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class WorldElement : Element
{
	public List<PartElement> PartsElements
	{
		get
		{
			List<PartElement> list = new List<PartElement>();
			IEnumerable<Element> enumerable = GameController.Instance.Game.IngameState.IngameUi.WorldPannel.Children[2].Children[0].Children[0].Children.Where((Element x) => x.ChildCount == 1L);
			foreach (Element item in enumerable)
			{
				list.Add(GetObject<PartElement>(item.Address));
			}
			return list;
		}
	}

	public Dictionary<string, Vector2i> Parts
	{
		get
		{
			Dictionary<string, Vector2i> dictionary = new Dictionary<string, Vector2i>();
			IEnumerable<Element> enumerable = GameController.Instance.Game.IngameState.IngameUi.WorldPannel.Children[2].Children[0].Children[0].Children.Where((Element x) => x.ChildCount == 1L);
			foreach (Element item in enumerable)
			{
				dictionary.Add(item.Children[0].Children[1].Text, LokiPoe.ElementClickLocation(item.Children[0]));
			}
			return dictionary;
		}
	}

	public List<PartElement> ActsElements
	{
		get
		{
			List<PartElement> list = new List<PartElement>();
			List<Element> children = GameController.Instance.Game.IngameState.IngameUi.WorldPannel.Children[2].Children[0].Children[1].Children;
			if (!children.All((Element x) => !x.IsVisible))
			{
				int num = 1;
				{
					foreach (Element item in children)
					{
						if (item.IsVisible)
						{
							IEnumerable<Element> enumerable = item.Children[0].Children[1].Children[0].Children.Where((Element x) => x.ChildCount == 1L);
							foreach (Element item2 in enumerable)
							{
								list.Add(GetObject<PartElement>(item2.Address));
							}
						}
						else
						{
							num++;
						}
					}
					return list;
				}
			}
			return list;
		}
	}

	public Dictionary<string, Vector2i> Acts
	{
		get
		{
			Dictionary<string, Vector2i> dictionary = new Dictionary<string, Vector2i>();
			List<Element> children = GameController.Instance.Game.IngameState.IngameUi.WorldPannel.Children[2].Children[0].Children[1].Children;
			if (!children.All((Element x) => !x.IsVisible))
			{
				int num = 1;
				{
					foreach (Element item in children)
					{
						if (item.IsVisible)
						{
							IEnumerable<Element> enumerable = item.Children[0].Children[1].Children[0].Children.Where((Element x) => x.ChildCount == 1L);
							foreach (Element item2 in enumerable)
							{
								dictionary.Add(item2.Children[0].Children[1].Text, LokiPoe.ElementClickLocation(item2.Children[0]));
							}
						}
						else
						{
							num++;
						}
					}
					return dictionary;
				}
			}
			return dictionary;
		}
	}

	public Element HideOutWayPoint
	{
		get
		{
			Element element = FindElementWithTooltipText(this, global::_003CModule_003E.smethod_7<string>(1830793201u));
			if (element == null)
			{
				element = FindElementWithTooltipText(this, global::_003CModule_003E.smethod_9<string>(2625907756u));
			}
			return element;
		}
	}

	public Element MenagerieWayPoint
	{
		get
		{
			Element element = FindElementWithTooltipText(this, global::_003CModule_003E.smethod_9<string>(2800647645u));
			if (element == null)
			{
				element = FindElementWithTooltipText(this, global::_003CModule_003E.smethod_9<string>(1778946467u));
			}
			return element;
		}
	}

	public Element MineWayPoint
	{
		get
		{
			Element element = FindElementWithTooltipText(this, global::_003CModule_003E.smethod_9<string>(3156811962u));
			if (element == null)
			{
				element = FindElementWithTooltipText(this, global::_003CModule_003E.smethod_6<string>(1115482379u));
			}
			return element;
		}
	}

	public Element LabyrintWayPoint
	{
		get
		{
			Element element = FindElementWithTooltipText(this, global::_003CModule_003E.smethod_8<string>(1570978354u));
			if (element == null)
			{
				element = FindElementWithTooltipText(this, global::_003CModule_003E.smethod_7<string>(3985070211u));
			}
			return element;
		}
	}

	public Element LaboratoryWayPoint
	{
		get
		{
			Element element = FindElementWithTooltipText(this, global::_003CModule_003E.smethod_9<string>(2128426245u));
			if (element == null)
			{
				element = FindElementWithTooltipText(this, global::_003CModule_003E.smethod_6<string>(4268769753u));
			}
			return element;
		}
	}

	public Vector2i LabyrintClickLocation => LokiPoe.ElementClickLocation(LabyrintWayPoint);

	public Vector2i HideOutClickLocation => LokiPoe.ElementClickLocation(HideOutWayPoint);

	public Vector2i MineClickLocation => LokiPoe.ElementClickLocation(MineWayPoint);

	public Vector2i MenagerieClickLocation => LokiPoe.ElementClickLocation(MenagerieWayPoint);

	public Vector2i LaboratoryClickLocation => LokiPoe.ElementClickLocation(LaboratoryWayPoint);

	private Element FindElementWithTooltipText(Element element, string text)
	{
		if (!element.IsVisible)
		{
			return null;
		}
		if (element.Tooltip.Address != 0L && element.Tooltip != null && element.Tooltip.Text != null && element.Tooltip.Text == text)
		{
			return element;
		}
		if (element.ChildCount == 0L)
		{
			return null;
		}
		foreach (Element child in element.Children)
		{
			Element element2 = FindElementWithTooltipText(child, text);
			if (element2 != null)
			{
				return element2;
			}
		}
		return null;
	}

	private Element FindElementWithTooltipTextWhileUiNotOpen(Element element, string text)
	{
		if (element.Tooltip.Address != 0L && element.Tooltip != null && element.Tooltip.Text != null && element.Tooltip.Text == text)
		{
			return element;
		}
		if (element.ChildCount == 0L)
		{
			return null;
		}
		foreach (Element child in element.Children)
		{
			Element element2 = FindElementWithTooltipTextWhileUiNotOpen(child, text);
			if (element2 != null)
			{
				return element2;
			}
		}
		return null;
	}
}
