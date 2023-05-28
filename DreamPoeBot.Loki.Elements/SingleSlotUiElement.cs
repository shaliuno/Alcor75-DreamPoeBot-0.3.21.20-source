using System;
using System.Collections.Generic;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game.Objects;

namespace DreamPoeBot.Loki.Elements;

public class SingleSlotUiElement : Element
{
	public enum SingleSlotType
	{
		inventory,
		Currency,
		Essence,
		Card,
		Fragment,
		Map,
		ExplorationLocker,
		FiveSlotMapDevice,
		BlightTabMap,
		MapDevice
	}

	private SingleSlotType SlotType;

	private static int id_offset = 1072;

	private static int item_offset = 1080;

	private float SlotSize
	{
		get
		{
			switch (SlotType)
			{
			case SingleSlotType.BlightTabMap:
				return 70.5f;
			default:
				throw new ArgumentOutOfRangeException();
			case SingleSlotType.inventory:
			case SingleSlotType.Currency:
			case SingleSlotType.Essence:
			case SingleSlotType.Card:
			case SingleSlotType.Fragment:
			case SingleSlotType.Map:
			case SingleSlotType.ExplorationLocker:
			case SingleSlotType.FiveSlotMapDevice:
				return 78f;
			}
		}
	}

	public Item Item
	{
		get
		{
			Vector2i locationTopLeft = new Vector2i(0, 0);
			if (SlotType == SingleSlotType.Card)
			{
				Element element = base.Children[1];
				if ((object)element != null && element.ChildCount < 2L)
				{
					return null;
				}
				int num = (int)(base.Children[1].Children[1].Width / SlotSize);
				int num2 = (int)(base.Children[1].Children[1].Height / SlotSize);
				Vector2i locationBottomRight = new Vector2i(locationTopLeft.X + num - 1, locationTopLeft.Y + num2 - 1);
				int id = base.M.ReadInt(base.Children[1].Children[1].Address + id_offset);
				return new Item(base.M.ReadLong(base.Children[1].Children[1].Address + item_offset), hasInventoryLocation: true, locationBottomRight, locationTopLeft, id);
			}
			if (base.ChildCount < 2L)
			{
				return null;
			}
			int num3 = (int)(base.Children[1].Width / SlotSize);
			int num4 = (int)(base.Children[1].Height / SlotSize);
			Vector2i locationBottomRight2 = new Vector2i(locationTopLeft.X + num3 - 1, locationTopLeft.Y + num4 - 1);
			int id2 = base.M.ReadInt(base.Children[1].Address + id_offset);
			return new Item(base.M.ReadLong(base.Children[1].Address + item_offset), hasInventoryLocation: true, locationBottomRight2, locationTopLeft, id2);
		}
	}

	public Element ItemElement
	{
		get
		{
			if (base.ChildCount >= 2L)
			{
				return base.Children[1];
			}
			return null;
		}
	}

	public int SocketCount
	{
		get
		{
			if (base.ChildCount < 2L)
			{
				return 0;
			}
			if (base.Children[1].ChildCount < 1L)
			{
				return 0;
			}
			return (int)base.Children[1].Children[0].ChildCount;
		}
	}

	public Dictionary<int, Vector2i> SocketsLocations
	{
		get
		{
			Dictionary<int, Vector2i> dictionary = new Dictionary<int, Vector2i>();
			if (base.ChildCount >= 2L)
			{
				if (base.Children[1].ChildCount < 1L)
				{
					return dictionary;
				}
				int num = 0;
				{
					foreach (Element child in base.Children[1].Children[0].Children)
					{
						float num2 = (float)(29 + (int)child.X + (int)base.Children[1].X + (int)base.Children[1].Children[0].X + (int)base.X + (int)base.Parent.X + (int)base.Parent.Parent.X) * base.Scale;
						float num3 = (float)(29 + (int)child.Y + (int)base.Children[1].Y + (int)base.Children[1].Children[0].Y + (int)base.Y + (int)base.Parent.Y + (int)base.Parent.Parent.Y) * base.Scale;
						if (!dictionary.ContainsKey(num))
						{
							dictionary.Add(num, new Vector2i((int)num2, (int)num3));
						}
						num++;
					}
					return dictionary;
				}
			}
			return dictionary;
		}
	}

	public Vector2i LocationTopLeft
	{
		get
		{
			float num = 0f;
			float num2 = 0f;
			if (SlotType == SingleSlotType.FiveSlotMapDevice)
			{
				num = (base.X + base.DeltaX) * base.Scale;
				num2 = (base.Y + base.DeltaY) * base.Scale;
				Element parent = base.Parent;
				while (parent.Address != 0L && parent.IdLabel != global::_003CModule_003E.smethod_9<string>(2438978962u))
				{
					num += (parent.X + parent.DeltaX) * parent.Scale;
					num2 += (parent.Y + parent.DeltaY) * parent.Scale;
					parent = parent.Parent;
				}
			}
			else
			{
				num = base.X * base.Scale;
				num2 = base.Y * base.Scale;
				Element parent2 = base.Parent;
				while (parent2.Address != 0L && parent2.IdLabel != global::_003CModule_003E.smethod_6<string>(1715000820u))
				{
					num += parent2.X * parent2.Scale;
					num2 += parent2.Y * parent2.Scale;
					parent2 = parent2.Parent;
				}
			}
			return new Vector2i((int)num, (int)num2);
		}
	}

	public Vector2i Size => new Vector2i((int)(base.Width * base.Scale), (int)(base.Height * base.Scale));

	public SingleSlotUiElement()
	{
	}

	public SingleSlotUiElement(Element element, SingleSlotType slotType = SingleSlotType.inventory)
	{
		base.Address = element.Address;
		SlotType = slotType;
	}

	public SingleSlotUiElement(long elementAddress, SingleSlotType slotType = SingleSlotType.inventory)
	{
		base.Address = elementAddress;
		SlotType = slotType;
	}

	public Vector2i SlotClickLocation(Vector2i slot)
	{
		int num = (int)((float)slot.X * SlotSize * base.Scale - 39f * base.Scale);
		int num2 = (int)((float)slot.Y * SlotSize * base.Scale - 39f * base.Scale);
		return new Vector2i(LocationTopLeft.X + num, LocationTopLeft.Y + num2);
	}
}
