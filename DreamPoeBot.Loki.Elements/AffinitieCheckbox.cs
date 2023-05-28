using System;
using System.Threading;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class AffinitieCheckbox : Element
{
	public LokiPoe.StashTabAffinitiesEnum AffinitieEnum
	{
		get
		{
			string text = base.Children[0].Text;
			if (string.IsNullOrEmpty(text))
			{
				throw new ArgumentNullException(global::_003CModule_003E.smethod_5<string>(1431320605u));
			}
			switch (global::_003CPrivateImplementationDetails_003E.ComputeStringHash(text))
			{
			case 3128792989u:
				if (text == global::_003CModule_003E.smethod_9<string>(2585800522u))
				{
					return LokiPoe.StashTabAffinitiesEnum.Essence;
				}
				goto default;
			case 3180808700u:
				if (text == global::_003CModule_003E.smethod_7<string>(1303306650u))
				{
					return LokiPoe.StashTabAffinitiesEnum.Gem;
				}
				goto default;
			case 3644247934u:
				if (text == global::_003CModule_003E.smethod_7<string>(721952340u))
				{
					return LokiPoe.StashTabAffinitiesEnum.Delirium;
				}
				goto default;
			case 2975789710u:
				if (text == global::_003CModule_003E.smethod_9<string>(3970350556u))
				{
					return LokiPoe.StashTabAffinitiesEnum.Metamorph;
				}
				goto default;
			case 2211661894u:
				if (text == global::_003CModule_003E.smethod_8<string>(4042531752u))
				{
					return LokiPoe.StashTabAffinitiesEnum.Unique;
				}
				goto default;
			case 2022303741u:
				if (text == global::_003CModule_003E.smethod_9<string>(2928595761u))
				{
					return LokiPoe.StashTabAffinitiesEnum.Fragment;
				}
				goto default;
			case 754411619u:
				if (text == global::_003CModule_003E.smethod_6<string>(3675046085u))
				{
					return LokiPoe.StashTabAffinitiesEnum.Delve;
				}
				goto default;
			case 516870170u:
				if (text == global::_003CModule_003E.smethod_5<string>(2531376370u))
				{
					return LokiPoe.StashTabAffinitiesEnum.DivinationCards;
				}
				goto default;
			case 342827606u:
				if (text == global::_003CModule_003E.smethod_8<string>(639854904u))
				{
					return LokiPoe.StashTabAffinitiesEnum.Corrency;
				}
				goto default;
			case 1151856721u:
				if (text == global::_003CModule_003E.smethod_8<string>(3576434591u))
				{
					return LokiPoe.StashTabAffinitiesEnum.Map;
				}
				goto default;
			case 1699492079u:
				if (text == global::_003CModule_003E.smethod_5<string>(2789556288u))
				{
					return LokiPoe.StashTabAffinitiesEnum.Blight;
				}
				goto default;
			case 1379998224u:
				if (text == global::_003CModule_003E.smethod_7<string>(1010365041u))
				{
					return LokiPoe.StashTabAffinitiesEnum.Flask;
				}
				goto default;
			default:
				throw new ArgumentNullException(global::_003CModule_003E.smethod_6<string>(2284497478u));
			}
		}
	}

	public bool IsSelected => base.M.ReadByte(base.Children[1].Address + PremiumStashSettingElement._checkBoxOffset) == 1;

	public void ClickCheckBox()
	{
		Vector2i pos = base.Children[1].CenterClickLocation();
		MouseManager.SetMousePosition(pos, useRandomPos: false);
		Thread.Sleep(10);
		MouseManager.ClickLMB(pos.X, pos.Y);
		Thread.Sleep(10);
	}
}
