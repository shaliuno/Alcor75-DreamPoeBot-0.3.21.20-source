using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Hooks;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Elements;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;

namespace DreamPoeBot.Loki.Game.Objects;

public class UltimatumChallengeInteractable : NetworkObject
{
	public enum BeginTrialResult
	{
		None,
		UiNotVisible,
		OptionNotSelected,
		ProcessHookManagerNotEnabled
	}

	public enum SelectOptionResult
	{
		None,
		UiNotVisible,
		OptionNotPresent,
		OptionElementNotFound,
		ProcessHookManagerNotEnabled
	}

	internal UltimatumChallengeElement Ui
	{
		get
		{
			ItemsOnGroundLabelElement itemsOnGroundLabelElement = GameController.Instance.Game.IngameState.IngameUi.ItemsOnGroundLabels.FirstOrDefault((ItemsOnGroundLabelElement x) => x.ItemOnGround.Address == base.Entity.Address);
			if (itemsOnGroundLabelElement == null)
			{
				return null;
			}
			Element label = itemsOnGroundLabelElement.Label;
			if (label == null)
			{
				return null;
			}
			return label.GetObjectAt<UltimatumChallengeElement>(0);
		}
	}

	public bool IsInterfaceVisible => Ui.IsVisible;

	public string TrialTitle => Ui.Title;

	public Item RewardItem => Ui.RewardItem.FirstOrDefault();

	public List<DatUltimatumModifiersWrapper> Options
	{
		get
		{
			List<DatUltimatumModifiersWrapper> list = new List<DatUltimatumModifiersWrapper>();
			List<KeyValuePair<long, long>> list2 = Containers.StdIntPtr_IntPtrVector(Ui.OptionsVector);
			foreach (KeyValuePair<long, long> item in list2)
			{
				list.Add(new DatUltimatumModifiersWrapper(item.Key));
			}
			return list;
		}
	}

	public DatUltimatumModifiersWrapper SelectedOption
	{
		get
		{
			int selectedOption = Ui.SelectedOption;
			List<DatUltimatumModifiersWrapper> options = Options;
			if (selectedOption == -1)
			{
				return null;
			}
			return options[selectedOption];
		}
	}

	internal List<string> ActiveStage
	{
		get
		{
			List<string> list = new List<string>();
			StateMachine component = base._entity.GetComponent<StateMachine>();
			if (component == null)
			{
				return list;
			}
			foreach (StateMachine.StageState stageState in component.StageStates)
			{
				list.Add(string.Format(global::_003CModule_003E.smethod_6<string>(1132539769u), stageState.Name, stageState.IsActive ? global::_003CModule_003E.smethod_9<string>(1775965749u) : global::_003CModule_003E.smethod_7<string>(2990660526u)));
			}
			return list;
		}
	}

	public bool IsTrialActive
	{
		get
		{
			StateMachine component = base._entity.GetComponent<StateMachine>();
			if (component == null)
			{
				return false;
			}
			return component.Encounter_Started;
		}
	}

	public bool IsTrialCompleted
	{
		get
		{
			StateMachine component = base._entity.GetComponent<StateMachine>();
			if (component == null)
			{
				return false;
			}
			return component.Encounter_Finished;
		}
	}

	internal UltimatumChallengeInteractable(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public BeginTrialResult BeginTrial()
	{
		if (!Hooking.IsInstalled)
		{
			return BeginTrialResult.ProcessHookManagerNotEnabled;
		}
		if (Ui.IsVisible)
		{
			if (Ui.SelectedOption != -1)
			{
				Vector2i pos = LokiPoe.ElementClickLocation(Ui.BeginButton);
				MouseManager.SetMousePosition(pos);
				Thread.Sleep(100);
				MouseManager.ClickLMB(pos.X, pos.Y);
				Thread.Sleep(200);
				return BeginTrialResult.None;
			}
			return BeginTrialResult.OptionNotSelected;
		}
		return BeginTrialResult.UiNotVisible;
	}

	public SelectOptionResult SelectOption(DatUltimatumModifiersWrapper option)
	{
		if (Hooking.IsInstalled)
		{
			if (Ui.IsVisible)
			{
				if (Options.All((DatUltimatumModifiersWrapper x) => x.Id != option.Id))
				{
					return SelectOptionResult.OptionNotPresent;
				}
				if (Ui.OptionElementsDictionary.TryGetValue(option.Address, out var value))
				{
					Vector2i pos = LokiPoe.ElementClickLocation(value);
					MouseManager.SetMousePosition(pos);
					Thread.Sleep(100);
					MouseManager.ClickLMB(pos.X, pos.Y);
					Thread.Sleep(200);
					return SelectOptionResult.None;
				}
				return SelectOptionResult.OptionElementNotFound;
			}
			return SelectOptionResult.UiNotVisible;
		}
		return SelectOptionResult.ProcessHookManagerNotEnabled;
	}

	public new string Dump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3179916388u)));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(392308900u), IsTrialActive));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(4037742579u), IsTrialCompleted));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(2349548017u), Ui.Address.ToString(global::_003CModule_003E.smethod_8<string>(2050146120u)), Ui.IsVisible));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(3147146705u)));
		foreach (string item in ActiveStage)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3444907389u), item));
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(797232627u)));
		foreach (DatUltimatumModifiersWrapper option in Options)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(461262040u), option.Text, option.Id));
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(1895406389u), (SelectedOption == null) ? global::_003CModule_003E.smethod_9<string>(3322279985u) : (SelectedOption.Text + global::_003CModule_003E.smethod_9<string>(61989554u) + SelectedOption.Id + global::_003CModule_003E.smethod_8<string>(2023435789u))));
		return stringBuilder.ToString();
	}
}
