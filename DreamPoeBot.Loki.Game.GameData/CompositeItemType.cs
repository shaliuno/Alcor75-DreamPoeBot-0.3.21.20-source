using System.Collections.Generic;

namespace DreamPoeBot.Loki.Game.GameData;

public class CompositeItemType
{
	internal static readonly CompositeItemType compositeItemType_0 = new CompositeItemType(ItemTypes.Unknown, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask);

	internal static readonly Dictionary<string, CompositeItemType> dictionary_0 = new Dictionary<string, CompositeItemType>
	{
		{
			global::_003CModule_003E.smethod_8<string>(963389218u),
			new CompositeItemType(ItemTypes.Armor, ArmorTypes.BodyArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_5<string>(863986051u),
			new CompositeItemType(ItemTypes.Armor, ArmorTypes.Helmet, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_7<string>(1045638031u),
			new CompositeItemType(ItemTypes.Armor, ArmorTypes.Gloves, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_5<string>(1395676833u),
			new CompositeItemType(ItemTypes.Armor, ArmorTypes.Boots, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_7<string>(2803287685u),
			new CompositeItemType(ItemTypes.Armor, ArmorTypes.Shield, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_5<string>(4078995367u),
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Dagger, WeaponHandTypes.OneHanded, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_8<string>(127630911u),
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Claw, WeaponHandTypes.OneHanded, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_5<string>(3252450466u),
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Bow, WeaponHandTypes.TwoHanded, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_6<string>(347591995u),
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Wand, WeaponHandTypes.OneHanded, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_6<string>(3078470325u),
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Staff, WeaponHandTypes.TwoHanded, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_9<string>(1586978586u),
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Axe1H, WeaponHandTypes.OneHanded, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_7<string>(1919933950u),
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Axe2H, WeaponHandTypes.TwoHanded, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_9<string>(34373202u),
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Mace1H, WeaponHandTypes.OneHanded, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_6<string>(2706280165u),
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Sceptre, WeaponHandTypes.OneHanded, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_5<string>(2990749179u),
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Mace2H, WeaponHandTypes.TwoHanded, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_6<string>(2978032557u),
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Sword1H, WeaponHandTypes.OneHanded, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_8<string>(409220744u),
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.SwordThrusting, WeaponHandTypes.OneHanded, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_7<string>(2000975157u),
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Sword2H, WeaponHandTypes.TwoHanded, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_8<string>(514991196u),
			new CompositeItemType(ItemTypes.Belt, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_7<string>(3465683202u),
			new CompositeItemType(ItemTypes.Quiver, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_6<string>(2208542795u),
			new CompositeItemType(ItemTypes.Ring, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_5<string>(4249526366u),
			new CompositeItemType(ItemTypes.Amulet, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_9<string>(2622048842u),
			new CompositeItemType(ItemTypes.Flask, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.Life)
		},
		{
			global::_003CModule_003E.smethod_8<string>(2609589618u),
			new CompositeItemType(ItemTypes.Flask, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.Mana)
		},
		{
			global::_003CModule_003E.smethod_6<string>(2035002436u),
			new CompositeItemType(ItemTypes.Flask, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.Hybrid)
		},
		{
			global::_003CModule_003E.smethod_8<string>(1018527242u),
			new CompositeItemType(ItemTypes.Flask, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.Utility)
		},
		{
			global::_003CModule_003E.smethod_6<string>(73613868u),
			new CompositeItemType(ItemTypes.Flask, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.Utility)
		},
		{
			global::_003CModule_003E.smethod_6<string>(3226901242u),
			new CompositeItemType(ItemTypes.Currency, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_6<string>(2829601640u),
			new CompositeItemType(ItemTypes.Gem, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_6<string>(1066862873u),
			new CompositeItemType(ItemTypes.Gem, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_5<string>(3742700208u),
			new CompositeItemType(ItemTypes.Map, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_6<string>(1338615265u),
			new CompositeItemType(ItemTypes.MapFragment, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_5<string>(4274390990u),
			new CompositeItemType(ItemTypes.MapFragment, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_7<string>(3276427340u),
			new CompositeItemType(ItemTypes.MapFragment, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_9<string>(746701836u),
			new CompositeItemType(ItemTypes.Jewel, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_9<string>(1089497075u),
			new CompositeItemType(ItemTypes.DivinationCard, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_8<string>(2529135380u),
			new CompositeItemType(ItemTypes.Quest, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_7<string>(3668525788u),
			new CompositeItemType(ItemTypes.IncursionItem, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_5<string>(3726123792u),
			new CompositeItemType(ItemTypes.LabyrinthItem, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_8<string>(3933973066u),
			new CompositeItemType(ItemTypes.LabyrinthItem, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_7<string>(2785172053u),
			new CompositeItemType(ItemTypes.Leaguestone, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_5<string>(2122763238u),
			new CompositeItemType(ItemTypes.FishingRod, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_5<string>(3194433010u),
			new CompositeItemType(ItemTypes.Microtransaction, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_6<string>(2754273314u),
			new CompositeItemType(ItemTypes.HideoutDoodad, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_5<string>(2654454020u),
			new CompositeItemType(ItemTypes.PantheonSoul, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_9<string>(3104277525u),
			new CompositeItemType(ItemTypes.UniqueFragment, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			global::_003CModule_003E.smethod_5<string>(1761603455u),
			new CompositeItemType(ItemTypes.AbyssJewel, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		}
	};

	public ItemTypes ItemType { get; }

	public ArmorTypes ArmorType { get; }

	public WeaponTypes WeaponType { get; }

	public WeaponHandTypes WeaponHandType { get; }

	public FlaskTypes FlaskType { get; }

	internal CompositeItemType(ItemTypes itemType, ArmorTypes armorType, WeaponTypes weaponType, WeaponHandTypes weaponHandType, FlaskTypes flaskType)
	{
		ItemType = itemType;
		ArmorType = armorType;
		WeaponType = weaponType;
		WeaponHandType = weaponHandType;
		FlaskType = flaskType;
	}

	public override string ToString()
	{
		return string.Format(global::_003CModule_003E.smethod_5<string>(1885926575u), ItemType, ArmorType, WeaponType, WeaponHandType, FlaskType);
	}
}
