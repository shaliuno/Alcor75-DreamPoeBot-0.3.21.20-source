using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Elements;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Game.Objects;

public class BlightDefensiveTower : Monster
{
	public int Tier
	{
		get
		{
			string text = Name;
			switch (global::_003CPrivateImplementationDetails_003E.ComputeStringHash(text))
			{
			case 1332895049u:
				if (text == global::_003CModule_003E.smethod_8<string>(704043788u))
				{
					goto IL_04aa;
				}
				goto default;
			case 1193329796u:
				if (text == global::_003CModule_003E.smethod_6<string>(380229530u))
				{
					break;
				}
				goto default;
			case 1050662772u:
				if (text == global::_003CModule_003E.smethod_5<string>(4190846109u))
				{
					goto IL_0403;
				}
				goto default;
			case 1111717987u:
				if (text == global::_003CModule_003E.smethod_7<string>(2763040177u))
				{
					return 0;
				}
				goto default;
			case 1772432530u:
				if (text == global::_003CModule_003E.smethod_5<string>(1540680407u))
				{
					goto IL_04aa;
				}
				goto default;
			case 1771659546u:
				if (text == global::_003CModule_003E.smethod_9<string>(1533530009u))
				{
					break;
				}
				goto default;
			case 1598580381u:
				if (text == global::_003CModule_003E.smethod_6<string>(530886182u))
				{
					goto IL_0486;
				}
				goto default;
			case 1454458349u:
				if (text == global::_003CModule_003E.smethod_5<string>(4273728189u))
				{
					goto IL_0403;
				}
				goto default;
			case 780644348u:
				if (text == global::_003CModule_003E.smethod_8<string>(1313350286u))
				{
					break;
				}
				goto default;
			case 640553471u:
				if (text == global::_003CModule_003E.smethod_5<string>(3380877624u))
				{
					goto IL_04aa;
				}
				goto default;
			case 985320287u:
				if (text == global::_003CModule_003E.smethod_8<string>(2043338141u))
				{
					goto IL_0486;
				}
				goto default;
			case 969983023u:
				if (text == global::_003CModule_003E.smethod_9<string>(2199066870u))
				{
					goto IL_0486;
				}
				goto default;
			case 109360204u:
				if (text == global::_003CModule_003E.smethod_8<string>(1343172096u))
				{
					break;
				}
				goto default;
			case 240563863u:
				if (text == global::_003CModule_003E.smethod_5<string>(2678655843u))
				{
					goto IL_0403;
				}
				goto default;
			case 487629100u:
				if (text == global::_003CModule_003E.smethod_8<string>(890268478u))
				{
					goto IL_0486;
				}
				goto default;
			case 3533690119u:
				if (text == global::_003CModule_003E.smethod_7<string>(1235406557u))
				{
					goto IL_0486;
				}
				goto default;
			case 3322044108u:
				if (text == global::_003CModule_003E.smethod_8<string>(3148886855u))
				{
					goto IL_0403;
				}
				goto default;
			case 3539591100u:
				if (text == global::_003CModule_003E.smethod_8<string>(4203479896u))
				{
					goto IL_04aa;
				}
				goto default;
			case 3751594442u:
				if (text == global::_003CModule_003E.smethod_6<string>(1026397817u))
				{
					goto IL_04aa;
				}
				goto default;
			case 4075116302u:
				if (text == global::_003CModule_003E.smethod_6<string>(3483298020u))
				{
					break;
				}
				goto default;
			case 4106474822u:
				if (text == global::_003CModule_003E.smethod_7<string>(1920446614u))
				{
					goto IL_0403;
				}
				goto default;
			case 3992409694u:
				if (text == global::_003CModule_003E.smethod_7<string>(1438249143u))
				{
					break;
				}
				goto default;
			case 3940403046u:
				if (text == global::_003CModule_003E.smethod_8<string>(3513719160u))
				{
					break;
				}
				goto default;
			case 3317919815u:
				if (text == global::_003CModule_003E.smethod_9<string>(2729971076u))
				{
					break;
				}
				goto default;
			case 3173467196u:
				if (text == global::_003CModule_003E.smethod_5<string>(975836793u))
				{
					goto IL_0403;
				}
				goto default;
			case 2867504342u:
				if (text == global::_003CModule_003E.smethod_8<string>(295872885u))
				{
					break;
				}
				goto default;
			case 2919697869u:
				if (text == global::_003CModule_003E.smethod_5<string>(182444724u))
				{
					break;
				}
				goto default;
			case 2089840649u:
				if (text == global::_003CModule_003E.smethod_7<string>(3583468337u))
				{
					break;
				}
				goto default;
			case 1887559546u:
				if (text == global::_003CModule_003E.smethod_8<string>(2984866900u))
				{
					goto IL_0486;
				}
				goto default;
			case 2316153762u:
				if (text == global::_003CModule_003E.smethod_7<string>(72697937u))
				{
					goto IL_04aa;
				}
				goto default;
			case 2292842704u:
				if (text == global::_003CModule_003E.smethod_5<string>(2791169386u))
				{
					break;
				}
				goto default;
			default:
				{
					return 0;
				}
				IL_0486:
				return 2;
				IL_04aa:
				return 3;
				IL_0403:
				return 1;
			}
			return 4;
		}
	}

	public BlightTowerElement Ui
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
				return label.GetObjectAt<BlightTowerElement>(0);
			}
			return null;
		}
	}

	internal BlightDefensiveTower(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public bool Upgrade(string selectedId = "")
	{
		List<BlightTowerOption> menu = Ui.Menu;
		BlightTowerOption blightTowerOption = (string.IsNullOrEmpty(selectedId) ? menu.FirstOrDefault() : ((menu.Count > 1) ? Ui.Menu.FirstOrDefault((BlightTowerOption x) => x.Id == selectedId) : menu.FirstOrDefault()));
		if (blightTowerOption == null)
		{
			return false;
		}
		Vector2i elementClickLocation = blightTowerOption.ElementClickLocation;
		MouseManager.SetMousePosition(elementClickLocation, useRandomPos: false);
		Thread.Sleep(30);
		MouseManager.ClickLMB(elementClickLocation.X, elementClickLocation.Y);
		Thread.Sleep(30);
		return true;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3846262742u)));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(1683864681u), base.Entity.Address));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(424036213u), base.Id));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(2485544958u), Name));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(2861758569u), base.Type));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3083343522u), base.Position));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(1122662994u), Tier));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1889694326u), base.Level));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(518513370u)));
		foreach (KeyValuePair<StatTypeGGG, int> stat in base.Stats)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(2602012211u), stat.Key, stat.Value));
		}
		foreach (Aura aura in base.Auras)
		{
			stringBuilder.AppendLine(aura.ToString());
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1714954437u)));
		if (Ui != null)
		{
			foreach (BlightTowerOption item in Ui.Menu)
			{
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(1010949835u), item.Id));
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3314571960u), item.Name));
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(1028035063u), item.Description));
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(59111213u), item.Icon));
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(3209319893u), item.Cost));
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(2816034010u), item.IsVisible));
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(970722716u), item.IsVisibleLocal));
			}
		}
		return stringBuilder.ToString();
	}

	public new string Dump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(829721385u)));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(2591781484u), base.Entity.Address));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(2948645338u), base.Id));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(2468910437u), Name));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3141854801u), base.Type));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3083343522u), base.Position));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(2504603475u), Tier));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1889694326u), base.Level));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(518513370u)));
		foreach (KeyValuePair<StatTypeGGG, int> stat in base.Stats)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(82986228u), stat.Key, stat.Value));
		}
		foreach (Aura aura in base.Auras)
		{
			stringBuilder.AppendLine(aura.ToString());
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3609084303u)));
		if (Ui != null)
		{
			foreach (BlightTowerOption item in Ui.Menu)
			{
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(1010949835u), item.Id));
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(2232489565u), item.Name));
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(206689171u), item.Description));
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(59111213u), item.Icon));
				stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3211318709u), item.Cost));
			}
		}
		return stringBuilder.ToString();
	}
}
