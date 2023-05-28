using System.Linq;

namespace DreamPoeBot.Loki.Elements;

public class ChallengesPannelElement : Element
{
	public ProphecyUiElement ProphecyElement
	{
		get
		{
			Element element = base.Children[2].Children[0].Children[1].Children[1];
			if (element == null)
			{
				return null;
			}
			Element element2 = element.Children.FirstOrDefault((Element x) => x.ChildCount == 1L && x.Children[0].ChildCount == 3L && x.Children[0].Children[2].IdLabel == global::_003CModule_003E.smethod_7<string>(1812677569u));
			if (element2 == null)
			{
				return null;
			}
			return base.M.GetObject<ProphecyUiElement>(element2.Address);
		}
	}

	public DelveUiElement DelveElement
	{
		get
		{
			Element element = base.Children[2].Children[0].Children[1].Children[1];
			if (element == null)
			{
				return null;
			}
			Element element2 = element.Children.FirstOrDefault((Element x) => x.ChildCount == 1L && x.Children[0].ChildCount == 2L && x.Children[0].Children[0].Children[0].Children[0].Text == global::_003CModule_003E.smethod_9<string>(3950296939u));
			if (element2 == null)
			{
				return null;
			}
			return base.M.GetObject<DelveUiElement>(element2.Address);
		}
	}
}
