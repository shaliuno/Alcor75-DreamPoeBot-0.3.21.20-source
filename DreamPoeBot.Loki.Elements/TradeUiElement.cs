using DreamPoeBot.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Elements;

public class TradeUiElement : Element
{
	public Element MyOffertElement
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.TradeUi == null)
			{
				return null;
			}
			if (GameController.Instance.Game.IngameState.IngameUi.TradeUi.IsVisible)
			{
				return base.Children[3].Children[1].Children[0].Children[0].Children[0];
			}
			return null;
		}
	}

	public DreamPoeBot.Loki.RemoteMemoryObjects.Inventory MyOffert
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.TradeUi == null)
			{
				return null;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.TradeUi.IsVisible)
			{
				return null;
			}
			return GetObject<DreamPoeBot.Loki.RemoteMemoryObjects.Inventory>(MyOffertElement.Address);
		}
	}

	public Element OtherOffertElement
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.TradeUi == null)
			{
				return null;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.TradeUi.IsVisible)
			{
				return null;
			}
			return base.Children[3].Children[1].Children[0].Children[0].Children[1];
		}
	}

	public string OtherOffertCharName
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.TradeUi == null)
			{
				return "";
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.TradeUi.IsVisible)
			{
				return "";
			}
			return base.Children[3].Children[1].Children[0].Children[0].Children[2].Text.TrimEnd(global::_003CModule_003E.smethod_7<string>(1249438891u).ToCharArray());
		}
	}

	public bool OtherAcceptedTheOffert => base.M.ReadByte(OtherOffertElement.Address + 635L) == 1;

	public bool MeAcceptedTheOffert => base.M.ReadByte(MyOffertElement.Address + 635L) == 1;

	public DreamPoeBot.Loki.RemoteMemoryObjects.Inventory OtherOffert
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.TradeUi == null)
			{
				return null;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.TradeUi.IsVisible)
			{
				return null;
			}
			return GetObject<DreamPoeBot.Loki.RemoteMemoryObjects.Inventory>(OtherOffertElement.Address);
		}
	}

	public Element AcceptButton
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.TradeUi == null)
			{
				return null;
			}
			if (GameController.Instance.Game.IngameState.IngameUi.TradeUi.IsVisible)
			{
				return base.Children[3].Children[1].Children[0].Children[0].Children[5].Children[0];
			}
			return null;
		}
	}

	public bool IsAcceptButtonEnabled
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.TradeUi == null)
			{
				return false;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.TradeUi.IsVisible)
			{
				return false;
			}
			return base.Children[3].Children[1].Children[0].Children[0].Children[5].IsEnable;
		}
	}

	public Element CancelButton
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.TradeUi == null)
			{
				return null;
			}
			if (GameController.Instance.Game.IngameState.IngameUi.TradeUi.IsVisible)
			{
				return base.Children[3].Children[1].Children[0].Children[0].Children[6].Children[0];
			}
			return null;
		}
	}

	public Element ConfirmElement
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.TradeUi == null)
			{
				return null;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.TradeUi.IsVisible)
			{
				return null;
			}
			return base.Children[3].Children[1].Children[0].Children[0].Children[4];
		}
	}

	public Vector2i AceptButtonPosition => LokiPoe.ElementClickLocation(AcceptButton);

	public Vector2i CancellButtonPosition => LokiPoe.ElementClickLocation(CancelButton);
}
