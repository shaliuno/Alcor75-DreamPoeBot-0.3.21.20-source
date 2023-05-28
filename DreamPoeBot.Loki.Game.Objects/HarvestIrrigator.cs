using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Elements;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class HarvestIrrigator : NetworkObject
{
	public bool IsUiVisible => _menu != null;

	public string Description
	{
		get
		{
			if (!IsUiVisible)
			{
				return "";
			}
			string text = _menu.Children[0].Children[1].Children[1].Tooltip.Text;
			if (text != null)
			{
				return text;
			}
			return "";
		}
	}

	[Obsolete("HarvestIrrigator Object dont have this property anymore, MagicProperties will always return a empty list.")]
	public List<string> MagicProperties => new List<string>();

	[Obsolete("HarvestIrrigator Object dont have this property anymore, CraftingOutCome will always return a empty list.")]
	public List<Tuple<string, string>> CraftingOutCome => new List<Tuple<string, string>>();

	public List<Tuple<int, string>> MonsterList
	{
		get
		{
			List<Tuple<int, string>> list = new List<Tuple<int, string>>();
			if (_menu == null)
			{
				return list;
			}
			if (_menu.Children[1].IsVisible)
			{
				foreach (Element child in _menu.Children[1].Children[0].Children[3].Children)
				{
					string text = child.Children[0].Children[0].Text;
					if (!string.IsNullOrEmpty(text))
					{
						string text2 = text.Replace(global::_003CModule_003E.smethod_5<string>(2920259345u), "").Replace(global::_003CModule_003E.smethod_5<string>(2650269850u), "").Replace(global::_003CModule_003E.smethod_7<string>(2612536365u), "")
							.Replace(global::_003CModule_003E.smethod_6<string>(2225119579u), "")
							.Replace(global::_003CModule_003E.smethod_6<string>(674865629u), global::_003CModule_003E.smethod_7<string>(576102537u));
						string[] array = text2.Split('~');
						if (array.Length >= 2)
						{
							int item = int.Parse(array[0].TrimEnd(' '));
							string item2 = array[1].TrimStart(' ');
							list.Add(new Tuple<int, string>(item, item2));
						}
					}
				}
				return list;
			}
			return list;
		}
	}

	internal Element _menu
	{
		get
		{
			ItemsOnGroundLabelElement itemsOnGroundLabelElement = GameController.Instance.Game.IngameState.IngameUi.ItemsOnGroundLabels.FirstOrDefault((ItemsOnGroundLabelElement x) => x.ItemOnGround.Address == base.Entity.Address);
			if (itemsOnGroundLabelElement == null)
			{
				return null;
			}
			Element label = itemsOnGroundLabelElement.Label;
			if (!(label == null))
			{
				return label.GetObjectAt<Element>(0);
			}
			return null;
		}
	}

	public HarvestIrrigator(EntityWrapper entity)
		: base(entity)
	{
	}

	public void Activate()
	{
		Vector2i pos = _menu.Children[0].Children[1].CenterClickLocation();
		MouseManager.SetMousePosition(pos, useRandomPos: false);
		Thread.Sleep(30);
		MouseManager.ClickLMB(pos.X, pos.Y);
		Thread.Sleep(60);
	}
}
