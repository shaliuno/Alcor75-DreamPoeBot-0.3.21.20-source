using System.Collections.Generic;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.FilesInMemory;

public class ItemClasses
{
	public Dictionary<string, ItemClass> contents;

	public const string StackableCurrency = "StackableCurrency";

	public const string Microtransaction = "Microtransaction";

	public const string TwoHandSword = "Two Hand Sword";

	public const string Wand = "Wand";

	public const string Dagger = "Dagger";

	public const string Claw = "Claw";

	public const string OneHandAxe = "One Hand Axe";

	public const string OneHandSword = "One Hand Sword";

	public const string ThrustingOneHandSword = "Thrusting One Hand Sword";

	public const string OneHandMace = "One Hand Mace";

	public const string Sceptre = "Sceptre";

	public const string Bow = "Bow";

	public const string Staff = "Staff";

	public const string TwoHandAxe = "Two Hand Axe";

	public const string TwoHandMace = "Two Hand Mace";

	public const string FishingRod = "FishingRod";

	public const string Ring = "Ring";

	public const string Amulet = "Amulet";

	public const string Belt = "Belt";

	public const string Shield = "Shield";

	public const string Helmet = "Helmet";

	public const string BodyArmour = "Body Armour";

	public const string Boots = "Boots";

	public const string Gloves = "Gloves";

	public const string LifeFlask = "LifeFlask";

	public const string ManaFlask = "ManaFlask";

	public const string HybridFlask = "HybridFlask";

	public const string UtilityFlaskCritical = "UtilityFlaskCritical";

	public const string UtilityFlask = "UtilityFlask";

	public const string Quiver = "Quiver";

	public const string QuestItem = "QuestItem";

	public const string LabyrinthItem = "LabyrinthItem";

	public const string IncursionItem = "IncursionItem";

	public const string ActiveSkillGem = "Active Skill Gem";

	public const string SupportSkillGem = "Support Skill Gem";

	public const string Jewel = "Jewel";

	public const string AbyssJewel = "AbyssJewel";

	public const string Map = "Map";

	public const string MapFragment = "MapFragment";

	public const string MiscMapItem = "MiscMapItem";

	public const string HideoutDoodad = "HideoutDoodad";

	public const string DivinationCard = "DivinationCard";

	public const string LabyrinthTrinket = "LabyrinthTrinket";

	public const string LabyrinthMapItem = "LabyrinthMapItem";

	public const string Leaguestone = "Leaguestone";

	public const string PantheonSoul = "PantheonSoul";

	public const string UniqueFragment = "UniqueFragment";

	public ItemClasses()
	{
		contents = new Dictionary<string, ItemClass>
		{
			{
				global::_003CModule_003E.smethod_8<string>(912756790u),
				new ItemClass(global::_003CModule_003E.smethod_7<string>(3020196132u), global::_003CModule_003E.smethod_8<string>(534084452u))
			},
			{
				global::_003CModule_003E.smethod_6<string>(1612593392u),
				new ItemClass(global::_003CModule_003E.smethod_6<string>(2466940777u), global::_003CModule_003E.smethod_7<string>(4191962568u))
			},
			{
				global::_003CModule_003E.smethod_9<string>(914757186u),
				new ItemClass(global::_003CModule_003E.smethod_9<string>(461241823u), global::_003CModule_003E.smethod_6<string>(2665590578u))
			},
			{
				global::_003CModule_003E.smethod_6<string>(1126611054u),
				new ItemClass(global::_003CModule_003E.smethod_8<string>(639854904u), global::_003CModule_003E.smethod_8<string>(2986221349u))
			},
			{
				global::_003CModule_003E.smethod_5<string>(4249526366u),
				new ItemClass(global::_003CModule_003E.smethod_9<string>(3727823402u), global::_003CModule_003E.smethod_9<string>(4070618641u))
			},
			{
				global::_003CModule_003E.smethod_6<string>(2208542795u),
				new ItemClass(global::_003CModule_003E.smethod_6<string>(3930591975u), global::_003CModule_003E.smethod_7<string>(2339684983u))
			},
			{
				global::_003CModule_003E.smethod_8<string>(127630911u),
				new ItemClass(global::_003CModule_003E.smethod_8<string>(2442458184u), global::_003CModule_003E.smethod_5<string>(3677640014u))
			},
			{
				global::_003CModule_003E.smethod_7<string>(3096229294u),
				new ItemClass(global::_003CModule_003E.smethod_9<string>(2880862113u), global::_003CModule_003E.smethod_7<string>(2542527569u))
			},
			{
				global::_003CModule_003E.smethod_7<string>(4164309983u),
				new ItemClass(global::_003CModule_003E.smethod_9<string>(4077303180u), global::_003CModule_003E.smethod_5<string>(3677640014u))
			},
			{
				global::_003CModule_003E.smethod_8<string>(3656888829u),
				new ItemClass(global::_003CModule_003E.smethod_6<string>(1994312849u), global::_003CModule_003E.smethod_9<string>(4083987719u))
			},
			{
				global::_003CModule_003E.smethod_5<string>(216260357u),
				new ItemClass(global::_003CModule_003E.smethod_6<string>(231574082u), global::_003CModule_003E.smethod_6<string>(3533292373u))
			},
			{
				global::_003CModule_003E.smethod_7<string>(748167514u),
				new ItemClass(global::_003CModule_003E.smethod_5<string>(2859383321u), global::_003CModule_003E.smethod_9<string>(4083987719u))
			},
			{
				global::_003CModule_003E.smethod_9<string>(34373202u),
				new ItemClass(global::_003CModule_003E.smethod_7<string>(1172447455u), global::_003CModule_003E.smethod_8<string>(493857333u))
			},
			{
				global::_003CModule_003E.smethod_8<string>(525396505u),
				new ItemClass(global::_003CModule_003E.smethod_9<string>(313240090u), global::_003CModule_003E.smethod_8<string>(851395808u))
			},
			{
				global::_003CModule_003E.smethod_8<string>(2222229333u),
				new ItemClass(global::_003CModule_003E.smethod_7<string>(99837858u), global::_003CModule_003E.smethod_5<string>(1779425341u))
			},
			{
				global::_003CModule_003E.smethod_8<string>(157452721u),
				new ItemClass(global::_003CModule_003E.smethod_8<string>(1208934283u), global::_003CModule_003E.smethod_9<string>(998830568u))
			},
			{
				global::_003CModule_003E.smethod_6<string>(4046609888u),
				new ItemClass(global::_003CModule_003E.smethod_9<string>(3573137130u), global::_003CModule_003E.smethod_7<string>(2637155500u))
			},
			{
				global::_003CModule_003E.smethod_6<string>(2507630364u),
				new ItemClass(global::_003CModule_003E.smethod_7<string>(4083747913u), global::_003CModule_003E.smethod_8<string>(851395808u))
			},
			{
				global::_003CModule_003E.smethod_5<string>(1819620911u),
				new ItemClass(global::_003CModule_003E.smethod_5<string>(3848171013u), global::_003CModule_003E.smethod_5<string>(2236522251u))
			},
			{
				global::_003CModule_003E.smethod_5<string>(1009652426u),
				new ItemClass(global::_003CModule_003E.smethod_7<string>(3011138316u), global::_003CModule_003E.smethod_7<string>(2425255098u))
			},
			{
				global::_003CModule_003E.smethod_7<string>(3465683202u),
				new ItemClass(global::_003CModule_003E.smethod_8<string>(3690892990u), global::_003CModule_003E.smethod_8<string>(1742292139u))
			},
			{
				global::_003CModule_003E.smethod_7<string>(2879799984u),
				new ItemClass(global::_003CModule_003E.smethod_9<string>(145184740u), global::_003CModule_003E.smethod_7<string>(2339684983u))
			},
			{
				global::_003CModule_003E.smethod_5<string>(593996556u),
				new ItemClass(global::_003CModule_003E.smethod_7<string>(1045638031u), global::_003CModule_003E.smethod_7<string>(3696178373u))
			},
			{
				global::_003CModule_003E.smethod_8<string>(4065059732u),
				new ItemClass(global::_003CModule_003E.smethod_7<string>(1338579640u), global::_003CModule_003E.smethod_5<string>(363172202u))
			},
			{
				global::_003CModule_003E.smethod_7<string>(2704130846u),
				new ItemClass(global::_003CModule_003E.smethod_8<string>(191456882u), global::_003CModule_003E.smethod_8<string>(3836890561u))
			},
			{
				global::_003CModule_003E.smethod_9<string>(2259199986u),
				new ItemClass(global::_003CModule_003E.smethod_6<string>(1745444164u), global::_003CModule_003E.smethod_7<string>(3696178373u))
			},
			{
				global::_003CModule_003E.smethod_9<string>(1916404747u),
				new ItemClass(global::_003CModule_003E.smethod_5<string>(4101584092u), global::_003CModule_003E.smethod_8<string>(1742292139u))
			},
			{
				global::_003CModule_003E.smethod_7<string>(1055174984u),
				new ItemClass(global::_003CModule_003E.smethod_6<string>(2514933926u), "")
			},
			{
				global::_003CModule_003E.smethod_6<string>(2937342970u),
				new ItemClass(global::_003CModule_003E.smethod_9<string>(3586506208u), "")
			},
			{
				global::_003CModule_003E.smethod_7<string>(2326098259u),
				new ItemClass(global::_003CModule_003E.smethod_6<string>(3508182931u), "")
			},
			{
				global::_003CModule_003E.smethod_5<string>(3431269673u),
				new ItemClass(global::_003CModule_003E.smethod_5<string>(3079643568u), "")
			},
			{
				global::_003CModule_003E.smethod_5<string>(1329371169u),
				new ItemClass(global::_003CModule_003E.smethod_8<string>(3252900277u), "")
			},
			{
				global::_003CModule_003E.smethod_7<string>(847324353u),
				new ItemClass(global::_003CModule_003E.smethod_6<string>(3382635721u), global::_003CModule_003E.smethod_7<string>(2542527569u))
			},
			{
				global::_003CModule_003E.smethod_6<string>(3201791800u),
				new ItemClass(global::_003CModule_003E.smethod_8<string>(1304299426u), global::_003CModule_003E.smethod_6<string>(2665590578u))
			},
			{
				global::_003CModule_003E.smethod_8<string>(2715360070u),
				new ItemClass(global::_003CModule_003E.smethod_5<string>(2547952786u), "")
			},
			{
				global::_003CModule_003E.smethod_7<string>(639952859u),
				new ItemClass(global::_003CModule_003E.smethod_6<string>(1645006396u), global::_003CModule_003E.smethod_8<string>(2986221349u))
			},
			{
				global::_003CModule_003E.smethod_7<string>(676663260u),
				new ItemClass("", "")
			},
			{
				global::_003CModule_003E.smethod_7<string>(3956938489u),
				new ItemClass(global::_003CModule_003E.smethod_9<string>(1032253263u), "")
			},
			{
				global::_003CModule_003E.smethod_7<string>(1225836077u),
				new ItemClass(global::_003CModule_003E.smethod_6<string>(304676673u), global::_003CModule_003E.smethod_5<string>(3636198974u))
			},
			{
				global::_003CModule_003E.smethod_8<string>(1839374644u),
				new ItemClass(global::_003CModule_003E.smethod_5<string>(641449905u), "")
			},
			{
				global::_003CModule_003E.smethod_9<string>(3159637587u),
				new ItemClass(global::_003CModule_003E.smethod_6<string>(1074166435u), "")
			},
			{
				global::_003CModule_003E.smethod_6<string>(1165074906u),
				new ItemClass(global::_003CModule_003E.smethod_8<string>(3430437020u), global::_003CModule_003E.smethod_8<string>(2986221349u))
			},
			{
				global::_003CModule_003E.smethod_9<string>(1089497075u),
				new ItemClass(global::_003CModule_003E.smethod_7<string>(2136842397u), global::_003CModule_003E.smethod_5<string>(3636198974u))
			},
			{
				global::_003CModule_003E.smethod_6<string>(2158323911u),
				new ItemClass(global::_003CModule_003E.smethod_7<string>(3015667224u), "")
			},
			{
				global::_003CModule_003E.smethod_8<string>(3933973066u),
				new ItemClass(global::_003CModule_003E.smethod_6<string>(701976275u), "")
			},
			{
				global::_003CModule_003E.smethod_8<string>(1376065717u),
				new ItemClass(global::_003CModule_003E.smethod_6<string>(2537817633u), global::_003CModule_003E.smethod_8<string>(2986221349u))
			},
			{
				global::_003CModule_003E.smethod_7<string>(3276427340u),
				new ItemClass(global::_003CModule_003E.smethod_9<string>(528087213u), "")
			},
			{
				global::_003CModule_003E.smethod_5<string>(1034517050u),
				new ItemClass(global::_003CModule_003E.smethod_5<string>(3241886359u), global::_003CModule_003E.smethod_9<string>(978776951u))
			}
		};
	}
}
