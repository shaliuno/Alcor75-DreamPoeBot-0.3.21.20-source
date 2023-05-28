using System.Collections.Generic;
using System.Text;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Game.Objects;

public class Player : Actor
{
	public PantheonGod PantheonMajor => base.Components.PlayerComponent.PantheonMajor;

	public PantheonGod PantheonMinor => base.Components.PlayerComponent.PantheonMinor;

	public int HideoutLevel => base.Components.PlayerComponent.HideoutLevel;

	public DatHideoutWrapper Hideout => base.Components.PlayerComponent.Hideout;

	public bool HasHideout => base.Components.PlayerComponent.HasHideout;

	public List<Prophecy> Prophecies => base.Components.PlayerComponent.Prophecies;

	public int Level => base.Components.PlayerComponent.Level;

	public CharacterClass Class => base.Components.PlayerClassComponent.Class;

	public AscendancyClass AscendencyClass => base.Components.PlayerClassComponent.AscendencyClass;

	public uint Experience => base.Components.PlayerComponent.Experience;

	public uint ExperienceNextLevel
	{
		get
		{
			if (Level == 100)
			{
				return uint.MaxValue;
			}
			return GameConstants.PlayerExperienceLevels[Level + 1];
		}
	}

	public uint ExperienceLastLevel => GameConstants.PlayerExperienceLevels[Level];

	public uint ExperienceGainedThisLevel
	{
		get
		{
			uint num = GameConstants.PlayerExperienceLevels[Level];
			return Experience - num;
		}
	}

	public uint ExperienceLeftThisLevel => ExperienceNextLevel - Experience;

	public float ExperiencePercent
	{
		get
		{
			uint experienceNextLevel = ExperienceNextLevel;
			uint experience = Experience;
			if (experienceNextLevel == experience)
			{
				return 100f;
			}
			uint experienceLastLevel = ExperienceLastLevel;
			uint num = experienceNextLevel - experienceLastLevel;
			return (float)((experience - experienceLastLevel) / num) * 100f;
		}
	}

	internal Player(EntityWrapper entry)
		: base(entry)
	{
	}

	public Player(Entity player)
		: base(player)
	{
		EntityWrapper entity = new EntityWrapper(player.Address);
		base._entity = entity;
	}

	public bool IsAscendencyTrialCompleted(string areaId)
	{
		return base.Components.PlayerComponent.IsAscendencyTrialCompleted(areaId);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(3790315508u)));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(1683864681u), base.Entity.Address));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(2433809905u), base.Id));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1563395767u), Name));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(1011744405u), base.Type));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(716977822u), base.Position));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(64815070u), Class));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3576273247u), Level));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(2738998590u), Experience));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(990137310u), PantheonMajor));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3673455844u), PantheonMinor));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(2882445871u), HasHideout));
		DatHideoutWrapper hideout = Hideout;
		if (hideout != null)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(2497352577u), hideout.Id));
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1007243764u), HideoutLevel));
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(777529132u)));
		foreach (KeyValuePair<StatTypeGGG, int> stat in base.Stats)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(635936615u), stat.Key, stat.Value));
		}
		foreach (Aura aura in base.Auras)
		{
			stringBuilder.AppendLine(aura.ToString());
		}
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(1653774643u), global::_003CModule_003E.smethod_5<string>(1284991429u), base.LeftHandWeaponVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3093558887u), global::_003CModule_003E.smethod_7<string>(461442426u), base.RightHandWeaponVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(955040355u), global::_003CModule_003E.smethod_9<string>(1181983653u), base.ChestVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3093558887u), global::_003CModule_003E.smethod_8<string>(3705843563u), base.HelmVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1550026689u), global::_003CModule_003E.smethod_9<string>(1699518781u), base.GlovesVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3093558887u), global::_003CModule_003E.smethod_5<string>(3706608676u), base.BootsVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3093558887u), global::_003CModule_003E.smethod_5<string>(466734736u), base.UnknownVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(1653774643u), global::_003CModule_003E.smethod_5<string>(2880063775u), base.LeftRingVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(955040355u), global::_003CModule_003E.smethod_6<string>(2024724649u), base.RightRingVisual));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1550026689u), global::_003CModule_003E.smethod_7<string>(1434895184u), base.BeltVisual));
		string[] labyrinthTrialAreaIds = LokiPoe.LabyrinthTrialAreaIds;
		foreach (string text in labyrinthTrialAreaIds)
		{
			stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(1653774643u), text, IsAscendencyTrialCompleted(text)));
		}
		return stringBuilder.ToString();
	}
}
