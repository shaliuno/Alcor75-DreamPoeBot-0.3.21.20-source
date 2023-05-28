using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DreamPoeBot.Loki.Game.GameData;

public class BestiaryCapturedMonster
{
	[Serializable]
	private sealed class Class330
	{
		public static readonly Class330 Class9 = new Class330();

		internal string method_0(BestiaryCapturedMonsterMod bestiaryCapturedMonsterMod_0)
		{
			return bestiaryCapturedMonsterMod_0.Mod.InternalName;
		}
	}

	public int Id { get; internal set; }

	public string Metadata { get; internal set; }

	public string Name { get; internal set; }

	public string FullName { get; internal set; }

	public int Level { get; internal set; }

	public Rarity Rarity { get; internal set; }

	public List<BestiaryCapturedMonsterMod> Mods { get; internal set; }

	public DatWordsWrapper Word1 { get; internal set; }

	public DatWordsWrapper Word2 { get; internal set; }

	public DatWordsWrapper Word3 { get; internal set; }

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(global::_003CModule_003E.smethod_8<string>(3135046822u), Id);
		stringBuilder.AppendFormat(global::_003CModule_003E.smethod_7<string>(1530481389u), Metadata);
		stringBuilder.AppendFormat(global::_003CModule_003E.smethod_8<string>(300055236u), FullName);
		stringBuilder.AppendFormat(global::_003CModule_003E.smethod_7<string>(164930183u), Name);
		stringBuilder.AppendFormat(global::_003CModule_003E.smethod_6<string>(61736703u), Level);
		stringBuilder.AppendFormat(global::_003CModule_003E.smethod_6<string>(3511885911u), Rarity);
		stringBuilder.AppendFormat(global::_003CModule_003E.smethod_8<string>(1704892922u), string.Join(global::_003CModule_003E.smethod_9<string>(1265206574u), Mods.Select(Class330.Class9.method_0)));
		if (Word1 != null)
		{
			stringBuilder.AppendFormat(global::_003CModule_003E.smethod_7<string>(3387287882u), Word1.RealName);
		}
		if (Word2 != null)
		{
			stringBuilder.AppendFormat(global::_003CModule_003E.smethod_8<string>(803591282u), Word2.RealName);
		}
		if (Word3 != null)
		{
			stringBuilder.AppendFormat(global::_003CModule_003E.smethod_9<string>(728468290u), Word3.RealName);
		}
		return stringBuilder.ToString();
	}
}
