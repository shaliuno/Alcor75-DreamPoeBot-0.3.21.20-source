using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.Std;

namespace DreamPoeBot.Loki.Elements;

public class AscendUIElement : Element
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct AscendMetadata
	{
		public readonly NativeStringWCustom metadata;
	}

	private List<Element> AscendElements
	{
		get
		{
			List<Element> list = new List<Element>();
			if (base.ChildCount == 4L)
			{
				list.Add(base.Children[1]);
				list.Add(base.Children[2]);
				list.Add(base.Children[3]);
			}
			if (base.ChildCount == 2L)
			{
				list.Add(base.Children[1]);
			}
			return list;
		}
	}

	public Element Occultist => SelectAcendPannel(global::_003CModule_003E.smethod_5<string>(2153640171u));

	public Element Elementalist => SelectAcendPannel(global::_003CModule_003E.smethod_7<string>(3633252798u));

	public Element Necromancer => SelectAcendPannel(global::_003CModule_003E.smethod_8<string>(3313938014u));

	public Element Juggernaut => SelectAcendPannel(global::_003CModule_003E.smethod_8<string>(715803546u));

	public Element Berserker => SelectAcendPannel(global::_003CModule_003E.smethod_6<string>(2389386716u));

	public Element Chieftain => SelectAcendPannel(global::_003CModule_003E.smethod_6<string>(3556176080u));

	public Element Slayer => SelectAcendPannel(global::_003CModule_003E.smethod_9<string>(1401786658u));

	public Element Gladiator => SelectAcendPannel(global::_003CModule_003E.smethod_7<string>(3935252223u));

	public Element Champion => SelectAcendPannel(global::_003CModule_003E.smethod_5<string>(861710152u));

	public Element Assassin => SelectAcendPannel(global::_003CModule_003E.smethod_9<string>(2604912264u));

	public Element Saboteur => SelectAcendPannel(global::_003CModule_003E.smethod_8<string>(1974643661u));

	public Element Trickster => SelectAcendPannel(global::_003CModule_003E.smethod_5<string>(68318083u));

	public Element Deadeye => SelectAcendPannel(global::_003CModule_003E.smethod_6<string>(3455738312u));

	public Element Raider => SelectAcendPannel(global::_003CModule_003E.smethod_6<string>(3257088511u));

	public Element Pathfinder => SelectAcendPannel(global::_003CModule_003E.smethod_5<string>(1671678637u));

	public Element Inquisitor => SelectAcendPannel(global::_003CModule_003E.smethod_7<string>(1100464064u));

	public Element Hierophant => SelectAcendPannel(global::_003CModule_003E.smethod_8<string>(529578856u));

	public Element Guardian => SelectAcendPannel(global::_003CModule_003E.smethod_6<string>(1519459186u));

	public Element Ascendant => SelectAcendPannel(global::_003CModule_003E.smethod_8<string>(277810833u));

	private Element SelectAcendPannel(string _class)
	{
		foreach (Element ascendElement in AscendElements)
		{
			string text = base.M.ReadStringU(base.M.ReadLong(ascendElement.Children[0].Address + 416L, default(long)));
			if (text.Contains(_class))
			{
				return ascendElement;
			}
		}
		return null;
	}

	public Element Next(Element elem)
	{
		return elem.Children[1].Children[0].Children[0].Children[0];
	}

	public Element Ascend(Element elem)
	{
		return elem.Children[2].Children[0].Children[1].Children[0];
	}

	public int AscendStage(Element elem)
	{
		return base.M.ReadByte(elem.Address + 1032L);
	}
}
