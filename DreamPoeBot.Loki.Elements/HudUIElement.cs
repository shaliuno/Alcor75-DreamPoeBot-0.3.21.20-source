using System.Linq;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class HudUIElement : Element
{
	public Element SkipTutorialButton => base.Children.FirstOrDefault((Element x) => x.IdLabel != null && x.IdLabel == global::_003CModule_003E.smethod_5<string>(1202772150u));

	public Element HUDRight
	{
		get
		{
			Element element = base.Children.FirstOrDefault((Element x) => x.IdLabel != null && x.IdLabel == global::_003CModule_003E.smethod_5<string>(3346111694u));
			if (element == null)
			{
				return null;
			}
			return element;
		}
	}

	public Element SentinelsElement
	{
		get
		{
			Element hUDRight = HUDRight;
			if (hUDRight == null)
			{
				return null;
			}
			return hUDRight.Children[12].Children[4];
		}
	}

	public Element StartBlightEncounter
	{
		get
		{
			Element hUDRight = HUDRight;
			if (!(hUDRight == null))
			{
				return hUDRight.Children[11].Children[1];
			}
			return null;
		}
	}

	public Element DeliriumEndButton
	{
		get
		{
			Element hUDRight = HUDRight;
			if (hUDRight == null)
			{
				return null;
			}
			return hUDRight.Children[11].Children[0];
		}
	}

	public Element HideoutMainControl
	{
		get
		{
			if (HUDRight == null)
			{
				return null;
			}
			if (HUDRight.ChildCount < 1L)
			{
				return null;
			}
			return HUDRight.Children[0];
		}
	}

	public Element ShowMenuButtonElement
	{
		get
		{
			if (HideoutMainControl == null)
			{
				return null;
			}
			if (HideoutMainControl.ChildCount < 2L)
			{
				return null;
			}
			return HideoutMainControl.Children[1].Children[1];
		}
	}

	public Element HideMenuButtonElement
	{
		get
		{
			if (HideoutMainControl == null)
			{
				return null;
			}
			if (HideoutMainControl.ChildCount < 1L)
			{
				return null;
			}
			return HideoutMainControl.Children[0].Children[1];
		}
	}

	public Element EditButtonElement
	{
		get
		{
			if (HideoutMainControl == null)
			{
				return null;
			}
			if (HideoutMainControl.ChildCount < 1L)
			{
				return null;
			}
			return HideoutMainControl.Children[0].Children[0].Children[1];
		}
	}

	public Element DecorationsButtonElement
	{
		get
		{
			if (HideoutMainControl == null)
			{
				return null;
			}
			if (HideoutMainControl.ChildCount < 1L)
			{
				return null;
			}
			return HideoutMainControl.Children[0].Children[0].Children[2].Children[0].Children[0];
		}
	}

	public Element MusicButtonElement
	{
		get
		{
			if (HideoutMainControl == null)
			{
				return null;
			}
			if (HideoutMainControl.ChildCount < 1L)
			{
				return null;
			}
			return HideoutMainControl.Children[0].Children[0].Children[2].Children[0].Children[1];
		}
	}

	public Element PurchaseButtonElement
	{
		get
		{
			if (HideoutMainControl == null)
			{
				return null;
			}
			if (HideoutMainControl.ChildCount < 1L)
			{
				return null;
			}
			return HideoutMainControl.Children[0].Children[0].Children[2].Children[0].Children[1];
		}
	}

	public Element ReclaimButtonElement
	{
		get
		{
			if (HideoutMainControl == null)
			{
				return null;
			}
			if (HideoutMainControl.ChildCount >= 1L)
			{
				return HideoutMainControl.Children[0].Children[0].Children[2].Children[1];
			}
			return null;
		}
	}

	public Element ExportButtonElement
	{
		get
		{
			if (HideoutMainControl == null)
			{
				return null;
			}
			if (HideoutMainControl.ChildCount < 1L)
			{
				return null;
			}
			return HideoutMainControl.Children[0].Children[0].Children[3].Children[0];
		}
	}

	public Element ImportButtonElement
	{
		get
		{
			if (HideoutMainControl == null)
			{
				return null;
			}
			if (HideoutMainControl.ChildCount < 1L)
			{
				return null;
			}
			return HideoutMainControl.Children[0].Children[0].Children[3].Children[1];
		}
	}

	public Vector2i StartBlightEncounterClickLocation
	{
		get
		{
			if (StartBlightEncounter == null)
			{
				return Vector2i.Zero;
			}
			return LokiPoe.ElementClickLocation(StartBlightEncounter);
		}
	}

	public Vector2i DeliriumEndClickLocation
	{
		get
		{
			if (DeliriumEndButton == null)
			{
				return Vector2i.Zero;
			}
			return LokiPoe.ElementClickLocation(DeliriumEndButton);
		}
	}

	public Element BloodCrucibleItemReadyElement
	{
		get
		{
			Element element = base.Children.FirstOrDefault((Element x) => x.IdLabel != null && x.IdLabel == global::_003CModule_003E.smethod_6<string>(1042379788u));
			if (element == null)
			{
				return null;
			}
			return element.Children[2];
		}
	}

	public Element BloodCrucibleSkillAvailableElement
	{
		get
		{
			Element element = base.Children.FirstOrDefault((Element x) => x.IdLabel != null && x.IdLabel == global::_003CModule_003E.smethod_8<string>(2053703782u));
			if (element == null)
			{
				return null;
			}
			return element.Children[3];
		}
	}
}
