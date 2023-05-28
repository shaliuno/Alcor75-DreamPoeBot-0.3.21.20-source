using System.Collections.Generic;
using DreamPoeBot.Loki.Models.Enums;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Models;

public class StatTranslator
{
	private delegate void AddStat(ItemStats stats, ItemMod m);

	private readonly Dictionary<string, AddStat> mods;

	public StatTranslator()
	{
		mods = new Dictionary<string, AddStat>
		{
			{
				global::_003CModule_003E.smethod_7<string>(2134171990u),
				Single(ItemStatEnum.Dexterity)
			},
			{
				global::_003CModule_003E.smethod_5<string>(621728587u),
				Single(ItemStatEnum.Strength)
			},
			{
				global::_003CModule_003E.smethod_7<string>(475679175u),
				Single(ItemStatEnum.Intelligence)
			},
			{
				global::_003CModule_003E.smethod_9<string>(1998832677u),
				Single(ItemStatEnum.AddedMana)
			},
			{
				global::_003CModule_003E.smethod_6<string>(4193185352u),
				Single(ItemStatEnum.AddedHP)
			},
			{
				global::_003CModule_003E.smethod_8<string>(870042881u),
				Single(ItemStatEnum.AddedES)
			},
			{
				global::_003CModule_003E.smethod_5<string>(2756779923u),
				Single(ItemStatEnum.AddedESPercent)
			},
			{
				global::_003CModule_003E.smethod_6<string>(692817260u),
				Single(ItemStatEnum.ColdResistance)
			},
			{
				global::_003CModule_003E.smethod_6<string>(1859606624u),
				Single(ItemStatEnum.FireResistance)
			},
			{
				global::_003CModule_003E.smethod_7<string>(570307106u),
				Single(ItemStatEnum.LightningResistance)
			},
			{
				global::_003CModule_003E.smethod_7<string>(2620898369u),
				Single(ItemStatEnum.ChaosResistance)
			},
			{
				global::_003CModule_003E.smethod_6<string>(1686066265u),
				MultipleSame(ItemStatEnum.ColdResistance, ItemStatEnum.FireResistance, ItemStatEnum.LightningResistance)
			},
			{
				global::_003CModule_003E.smethod_7<string>(737614240u),
				Single(ItemStatEnum.CritChance)
			},
			{
				global::_003CModule_003E.smethod_9<string>(2163879574u),
				Single(ItemStatEnum.CritMultiplier)
			},
			{
				global::_003CModule_003E.smethod_7<string>(836771079u),
				Single(ItemStatEnum.MovementSpeed)
			},
			{
				global::_003CModule_003E.smethod_7<string>(1715595906u),
				Single(ItemStatEnum.Rarity)
			},
			{
				global::_003CModule_003E.smethod_9<string>(2506674813u),
				Single(ItemStatEnum.Quantity)
			},
			{
				global::_003CModule_003E.smethod_6<string>(2777527303u),
				Single(ItemStatEnum.ManaLeech)
			},
			{
				global::_003CModule_003E.smethod_5<string>(2387331932u),
				Single(ItemStatEnum.LifeLeech)
			},
			{
				global::_003CModule_003E.smethod_6<string>(816138735u),
				Average(ItemStatEnum.AddedLightningDamage)
			},
			{
				global::_003CModule_003E.smethod_9<string>(2856154591u),
				Average(ItemStatEnum.AddedColdDamage)
			},
			{
				global::_003CModule_003E.smethod_9<string>(1995824224u),
				Average(ItemStatEnum.AddedFireDamage)
			},
			{
				global::_003CModule_003E.smethod_8<string>(877336711u),
				Average(ItemStatEnum.AddedPhysicalDamage)
			},
			{
				global::_003CModule_003E.smethod_7<string>(2598949641u),
				Single(ItemStatEnum.WeaponElementalDamagePercent)
			},
			{
				global::_003CModule_003E.smethod_8<string>(333573546u),
				Single(ItemStatEnum.FireDamagePercent)
			},
			{
				global::_003CModule_003E.smethod_9<string>(1323602824u),
				Single(ItemStatEnum.ColdDamagePercent)
			},
			{
				global::_003CModule_003E.smethod_8<string>(439343998u),
				Single(ItemStatEnum.LightningDamagePercent)
			},
			{
				global::_003CModule_003E.smethod_6<string>(2677089535u),
				Single(ItemStatEnum.SpellDamage)
			},
			{
				global::_003CModule_003E.smethod_6<string>(3843878899u),
				Dual(ItemStatEnum.SpellDamage, ItemStatEnum.AddedMana)
			},
			{
				global::_003CModule_003E.smethod_7<string>(2986519181u),
				Single(ItemStatEnum.SpellCriticalChance)
			},
			{
				global::_003CModule_003E.smethod_5<string>(2952175546u),
				Single(ItemStatEnum.CastSpeed)
			},
			{
				global::_003CModule_003E.smethod_6<string>(3894097783u),
				Single(ItemStatEnum.ProjectileSpeed)
			},
			{
				global::_003CModule_003E.smethod_5<string>(3770432239u),
				Single(ItemStatEnum.MinionSkillLevel)
			},
			{
				global::_003CModule_003E.smethod_6<string>(839022442u),
				Single(ItemStatEnum.FireSkillLevel)
			},
			{
				global::_003CModule_003E.smethod_7<string>(530242746u),
				Single(ItemStatEnum.ColdSkillLevel)
			},
			{
				global::_003CModule_003E.smethod_9<string>(3911278464u),
				Single(ItemStatEnum.LightningSkillLevel)
			},
			{
				global::_003CModule_003E.smethod_9<string>(3581852303u),
				Average(ItemStatEnum.LocalPhysicalDamage)
			},
			{
				global::_003CModule_003E.smethod_8<string>(3782377226u),
				Single(ItemStatEnum.LocalPhysicalDamagePercent)
			},
			{
				global::_003CModule_003E.smethod_8<string>(2589080444u),
				Average(ItemStatEnum.LocalAddedColdDamage)
			},
			{
				global::_003CModule_003E.smethod_8<string>(1290013210u),
				Average(ItemStatEnum.LocalAddedFireDamage)
			},
			{
				global::_003CModule_003E.smethod_6<string>(3222820054u),
				Average(ItemStatEnum.LocalAddedLightningDamage)
			},
			{
				global::_003CModule_003E.smethod_9<string>(496695152u),
				Single(ItemStatEnum.LocalCritChance)
			},
			{
				global::_003CModule_003E.smethod_9<string>(1014230280u),
				Single(ItemStatEnum.LocalAttackSpeed)
			},
			{
				global::_003CModule_003E.smethod_7<string>(733085332u),
				Single(ItemStatEnum.LocalES)
			},
			{
				global::_003CModule_003E.smethod_9<string>(4274127320u),
				Single(ItemStatEnum.LocalEV)
			},
			{
				global::_003CModule_003E.smethod_6<string>(2750192126u),
				Single(ItemStatEnum.LocalArmor)
			},
			{
				global::_003CModule_003E.smethod_6<string>(1211212602u),
				Single(ItemStatEnum.LocalEVPercent)
			},
			{
				global::_003CModule_003E.smethod_5<string>(480829051u),
				Single(ItemStatEnum.LocalESPercent)
			},
			{
				global::_003CModule_003E.smethod_9<string>(342008880u),
				Single(ItemStatEnum.LocalArmorPercent)
			},
			{
				global::_003CModule_003E.smethod_5<string>(2549574723u),
				MultipleSame(ItemStatEnum.LocalArmorPercent, ItemStatEnum.LocalEVPercent)
			},
			{
				global::_003CModule_003E.smethod_5<string>(2811276010u),
				MultipleSame(ItemStatEnum.LocalArmorPercent, ItemStatEnum.LocalESPercent)
			},
			{
				global::_003CModule_003E.smethod_7<string>(3982616479u),
				MultipleSame(ItemStatEnum.LocalEVPercent, ItemStatEnum.LocalESPercent)
			}
		};
	}

	public void Translate(ItemStats stats, ItemMod m)
	{
		if (mods.ContainsKey(m.Name))
		{
			mods[m.Name](stats, m);
		}
	}

	private AddStat Single(ItemStatEnum stat)
	{
		return delegate(ItemStats x, ItemMod m)
		{
			x.AddToMod(stat, m.Value1);
		};
	}

	private AddStat Average(ItemStatEnum stat)
	{
		return delegate(ItemStats x, ItemMod m)
		{
			x.AddToMod(stat, (float)(m.Value1 + m.Value2) / 2f);
		};
	}

	private AddStat Dual(ItemStatEnum s1, ItemStatEnum s2)
	{
		return delegate(ItemStats x, ItemMod m)
		{
			x.AddToMod(s1, m.Value1);
			x.AddToMod(s2, m.Value2);
		};
	}

	private AddStat MultipleSame(params ItemStatEnum[] stats)
	{
		return delegate(ItemStats x, ItemMod m)
		{
			ItemStatEnum[] array = stats;
			foreach (ItemStatEnum stat in array)
			{
				x.AddToMod(stat, m.Value1);
			}
		};
	}
}
