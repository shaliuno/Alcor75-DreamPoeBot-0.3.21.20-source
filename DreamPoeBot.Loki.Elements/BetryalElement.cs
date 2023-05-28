using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class BetryalElement : Element
{
	internal string InterrogateString
	{
		get
		{
			if (!IsInterrogateVisible)
			{
				return "";
			}
			return InterrogateElement?.Parent?.Parent?.Children[1].Text;
		}
	}

	internal Element InterrogateElement
	{
		get
		{
			Element element = FindElementWithText(this, global::_003CModule_003E.smethod_9<string>(1026510599u));
			if (element == null)
			{
				return null;
			}
			return element;
		}
	}

	public bool IsInterrogateVisible
	{
		get
		{
			if (InterrogateElement != null)
			{
				return InterrogateElement.IsVisible;
			}
			return false;
		}
	}

	public Vector2i InterrogateClickPosition
	{
		get
		{
			if (!IsInterrogateVisible)
			{
				return Vector2i.Zero;
			}
			return LokiPoe.ElementClickLocation(InterrogateElement);
		}
	}

	internal string ExecuteString
	{
		get
		{
			if (!IsExecuteVisible)
			{
				return "";
			}
			return ExecuteElement?.Parent?.Parent?.Children[1].Text;
		}
	}

	internal Element ExecuteElement
	{
		get
		{
			Element element = FindElementWithText(this, global::_003CModule_003E.smethod_7<string>(1150224005u));
			if (!(element == null))
			{
				return element;
			}
			return null;
		}
	}

	public bool IsExecuteVisible
	{
		get
		{
			if (ExecuteElement != null)
			{
				return ExecuteElement.IsVisible;
			}
			return false;
		}
	}

	public Vector2i ExecuteClickPosition
	{
		get
		{
			if (!IsExecuteVisible)
			{
				return Vector2i.Zero;
			}
			return LokiPoe.ElementClickLocation(ExecuteElement);
		}
	}

	internal string BetrayString
	{
		get
		{
			if (!IsBetrayVisible)
			{
				return "";
			}
			return BetrayElement?.Parent?.Parent?.Children[1].Text;
		}
	}

	internal Element BetrayElement
	{
		get
		{
			Element element = FindElementWithText(this, global::_003CModule_003E.smethod_5<string>(189119834u));
			if (element == null)
			{
				return null;
			}
			return element;
		}
	}

	public bool IsBetrayVisible
	{
		get
		{
			if (BetrayElement != null)
			{
				return BetrayElement.IsVisible;
			}
			return false;
		}
	}

	public Vector2i BetrayClickPosition
	{
		get
		{
			if (!IsBetrayVisible)
			{
				return Vector2i.Zero;
			}
			return LokiPoe.ElementClickLocation(BetrayElement);
		}
	}

	internal string BargainString
	{
		get
		{
			if (!IsBargainVisible)
			{
				return "";
			}
			return BargainElement?.Parent?.Parent?.Children[1].Text;
		}
	}

	internal Element BargainElement
	{
		get
		{
			Element element = FindElementWithText(this, global::_003CModule_003E.smethod_8<string>(991493666u));
			if (element == null)
			{
				return null;
			}
			return element;
		}
	}

	public bool IsBargainVisible
	{
		get
		{
			if (BargainElement != null)
			{
				return BargainElement.IsVisible;
			}
			return false;
		}
	}

	public Vector2i BargainClickPosition
	{
		get
		{
			if (!IsBargainVisible)
			{
				return Vector2i.Zero;
			}
			return LokiPoe.ElementClickLocation(BargainElement);
		}
	}

	internal Element SafeHouseElement
	{
		get
		{
			Element element = FindElementWithText(this, global::_003CModule_003E.smethod_6<string>(2583585047u));
			if (!(element == null))
			{
				return element;
			}
			return null;
		}
	}

	public bool IsSafeHouseReady
	{
		get
		{
			Element element = FindSpecialElementWithText(this, global::_003CModule_003E.smethod_6<string>(2583585047u));
			if (element == null)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsSafeHouseVisible
	{
		get
		{
			if (SafeHouseElement != null && SafeHouseElement.IsVisible)
			{
				return SafeHouseElement.IsEnable;
			}
			return false;
		}
	}

	public Vector2i SafeHouseClickPosition
	{
		get
		{
			if (!IsSafeHouseVisible)
			{
				return Vector2i.Zero;
			}
			return LokiPoe.ElementClickLocation(SafeHouseElement);
		}
	}

	private Element Map => base.Children[0];

	private Element FindSpecialElementWithText(Element element, string text)
	{
		if (element.Text != null && element.Text == text && element.Parent.IsVisibleLocal)
		{
			return element;
		}
		if (element.ChildCount != 0L)
		{
			foreach (Element child in element.Children)
			{
				Element element2 = FindSpecialElementWithText(child, text);
				if (element2 != null)
				{
					return element2;
				}
			}
			return null;
		}
		return null;
	}

	private Element FindElementWithText(Element element, string text)
	{
		if (element.IsVisible && element.Text != null && element.Text == text)
		{
			return element;
		}
		if (element.ChildCount != 0L)
		{
			foreach (Element child in element.Children)
			{
				Element element2 = FindElementWithText(child, text);
				if (element2 != null)
				{
					return element2;
				}
			}
			return null;
		}
		return null;
	}

	internal void CenterElement(Element element)
	{
		Vector2i vector2i = new Vector2i(LokiPoe.ClientWindowInfo.Window.Right - LokiPoe.ClientWindowInfo.Window.Left, LokiPoe.ClientWindowInfo.Window.Bottom - LokiPoe.ClientWindowInfo.Window.Top);
		float scale = element.Scale;
		float num = ((element.X + element.Parent.X + element.Parent.Parent.X + element.Parent.Parent.Parent.X) * scale - (float)(vector2i.X / 2)) / scale;
		float num2 = ((element.Y + element.Parent.Y + element.Parent.Parent.Y + element.Parent.Parent.Parent.Y) * scale - (float)(vector2i.Y / 2)) / scale;
		base.M.WriteFloat(Map.XAddress, num * -1f);
		base.M.WriteFloat(Map.YAddress, num2 * -1f);
	}

	internal void CenterSafehouseElement(Element element)
	{
		Vector2i vector2i = new Vector2i(LokiPoe.ClientWindowInfo.Window.Right - LokiPoe.ClientWindowInfo.Window.Left, LokiPoe.ClientWindowInfo.Window.Bottom - LokiPoe.ClientWindowInfo.Window.Top);
		float scale = element.Scale;
		float num = ((element.X + element.Parent.X + element.Parent.Parent.X + element.Parent.Parent.Parent.X + element.Parent.Parent.Parent.Parent.X) * scale - (float)(vector2i.X / 2)) / scale;
		float num2 = ((element.Y + element.Parent.Y + element.Parent.Parent.Y + element.Parent.Parent.Parent.Y + element.Parent.Parent.Parent.Parent.Y) * scale - (float)(vector2i.Y / 2)) / scale;
		base.M.WriteFloat(Map.XAddress, num * -1f);
		base.M.WriteFloat(Map.YAddress, num2 * -1f);
	}
}
