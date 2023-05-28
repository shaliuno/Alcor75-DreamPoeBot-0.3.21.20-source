using System;
using System.Collections.Generic;
using System.Drawing;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Models;

public sealed class AreaInstance
{
	public DateTime TimeEntered = DateTime.Now;

	private readonly string[] HexStringTable = new string[256]
	{
		global::_003CModule_003E.smethod_6<string>(1742962354u),
		global::_003CModule_003E.smethod_6<string>(178873388u),
		global::_003CModule_003E.smethod_6<string>(2909751718u),
		global::_003CModule_003E.smethod_7<string>(2462865726u),
		global::_003CModule_003E.smethod_9<string>(3328964524u),
		global::_003CModule_003E.smethod_8<string>(3262536158u),
		global::_003CModule_003E.smethod_7<string>(4220515380u),
		global::_003CModule_003E.smethod_7<string>(511431302u),
		global::_003CModule_003E.smethod_5<string>(3528828737u),
		global::_003CModule_003E.smethod_5<string>(845510203u),
		global::_003CModule_003E.smethod_8<string>(2759000112u),
		global::_003CModule_003E.smethod_7<string>(2854964174u),
		global::_003CModule_003E.smethod_5<string>(1426930233u),
		global::_003CModule_003E.smethod_7<string>(1300157106u),
		global::_003CModule_003E.smethod_6<string>(2809313950u),
		global::_003CModule_003E.smethod_7<string>(2471923542u),
		global::_003CModule_003E.smethod_6<string>(3976103314u),
		global::_003CModule_003E.smethod_8<string>(4163837798u),
		global::_003CModule_003E.smethod_5<string>(346972253u),
		global::_003CModule_003E.smethod_6<string>(3578803712u),
		global::_003CModule_003E.smethod_9<string>(1104137740u),
		global::_003CModule_003E.smethod_9<string>(2307263346u),
		global::_003CModule_003E.smethod_8<string>(2970541016u),
		global::_003CModule_003E.smethod_7<string>(2864021990u),
		global::_003CModule_003E.smethod_8<string>(372406548u),
		global::_003CModule_003E.smethod_7<string>(4035788426u),
		global::_003CModule_003E.smethod_7<string>(326704348u),
		global::_003CModule_003E.smethod_6<string>(3206613552u),
		global::_003CModule_003E.smethod_6<string>(898144266u),
		global::_003CModule_003E.smethod_7<string>(515960210u),
		global::_003CModule_003E.smethod_6<string>(2064933630u),
		global::_003CModule_003E.smethod_8<string>(1777244234u),
		global::_003CModule_003E.smethod_7<string>(2273609864u),
		global::_003CModule_003E.smethod_8<string>(3474077062u),
		global::_003CModule_003E.smethod_6<string>(103545062u),
		global::_003CModule_003E.smethod_9<string>(3523758030u),
		global::_003CModule_003E.smethod_5<string>(1418642025u),
		global::_003CModule_003E.smethod_7<string>(908058658u),
		global::_003CModule_003E.smethod_8<string>(2280780280u),
		global::_003CModule_003E.smethod_5<string>(4101960559u),
		global::_003CModule_003E.smethod_8<string>(3977613108u),
		global::_003CModule_003E.smethod_6<string>(1295443868u),
		global::_003CModule_003E.smethod_5<string>(338684045u),
		global::_003CModule_003E.smethod_5<string>(1950332807u),
		global::_003CModule_003E.smethod_5<string>(1327471737u),
		global::_003CModule_003E.smethod_7<string>(552191474u),
		global::_003CModule_003E.smethod_5<string>(2399141509u),
		global::_003CModule_003E.smethod_5<string>(4010790271u),
		global::_003CModule_003E.smethod_6<string>(1169896658u),
		global::_003CModule_003E.smethod_8<string>(2158704806u),
		global::_003CModule_003E.smethod_5<string>(247513757u),
		global::_003CModule_003E.smethod_8<string>(3855537634u),
		global::_003CModule_003E.smethod_7<string>(358406704u),
		global::_003CModule_003E.smethod_9<string>(332590130u),
		global::_003CModule_003E.smethod_6<string>(3925884430u),
		global::_003CModule_003E.smethod_8<string>(2264475258u),
		global::_003CModule_003E.smethod_5<string>(3479099489u),
		global::_003CModule_003E.smethod_8<string>(3961308086u),
		global::_003CModule_003E.smethod_9<string>(1535715736u),
		global::_003CModule_003E.smethod_8<string>(1363173618u),
		global::_003CModule_003E.smethod_5<string>(1310895321u),
		global::_003CModule_003E.smethod_5<string>(2922544083u),
		global::_003CModule_003E.smethod_9<string>(4123391376u),
		global::_003CModule_003E.smethod_7<string>(939761014u),
		global::_003CModule_003E.smethod_9<string>(2752210420u),
		global::_003CModule_003E.smethod_9<string>(3955336026u),
		global::_003CModule_003E.smethod_9<string>(345959208u),
		global::_003CModule_003E.smethod_9<string>(1549084814u),
		global::_003CModule_003E.smethod_5<string>(1319183529u),
		global::_003CModule_003E.smethod_9<string>(2402730642u),
		global::_003CModule_003E.smethod_8<string>(275647288u),
		global::_003CModule_003E.smethod_7<string>(1331859462u),
		global::_003CModule_003E.smethod_6<string>(53326178u),
		global::_003CModule_003E.smethod_5<string>(779204539u),
		global::_003CModule_003E.smethod_8<string>(3669312944u),
		global::_003CModule_003E.smethod_5<string>(1850874311u),
		global::_003CModule_003E.smethod_5<string>(1360624569u),
		global::_003CModule_003E.smethod_8<string>(1680484974u),
		global::_003CModule_003E.smethod_8<string>(2078250568u),
		global::_003CModule_003E.smethod_8<string>(3377317802u),
		global::_003CModule_003E.smethod_5<string>(3503964113u),
		global::_003CModule_003E.smethod_8<string>(779183334u),
		global::_003CModule_003E.smethod_7<string>(755034060u),
		global::_003CModule_003E.smethod_6<string>(2261357696u),
		global::_003CModule_003E.smethod_9<string>(3269745548u),
		global::_003CModule_003E.smethod_7<string>(2512683714u),
		global::_003CModule_003E.smethod_7<string>(3098566932u),
		global::_003CModule_003E.smethod_6<string>(3850556104u),
		global::_003CModule_003E.smethod_8<string>(1282719380u),
		global::_003CModule_003E.smethod_6<string>(722378172u),
		global::_003CModule_003E.smethod_8<string>(2979552208u),
		global::_003CModule_003E.smethod_9<string>(2584155070u),
		global::_003CModule_003E.smethod_5<string>(1344048153u),
		global::_003CModule_003E.smethod_5<string>(2955696915u),
		global::_003CModule_003E.smethod_6<string>(747487614u),
		global::_003CModule_003E.smethod_6<string>(3478365944u),
		global::_003CModule_003E.smethod_9<string>(2597524148u),
		global::_003CModule_003E.smethod_6<string>(350188012u),
		global::_003CModule_003E.smethod_9<string>(191272936u),
		global::_003CModule_003E.smethod_5<string>(1875738935u),
		global::_003CModule_003E.smethod_7<string>(1142603600u),
		global::_003CModule_003E.smethod_8<string>(2793327518u),
		global::_003CModule_003E.smethod_5<string>(2424006133u),
		global::_003CModule_003E.smethod_9<string>(4136760454u),
		global::_003CModule_003E.smethod_5<string>(3495675905u),
		global::_003CModule_003E.smethod_5<string>(812357371u),
		global::_003CModule_003E.smethod_9<string>(3451169976u),
		global::_003CModule_003E.smethod_8<string>(3588858706u),
		global::_003CModule_003E.smethod_8<string>(225014860u),
		global::_003CModule_003E.smethod_6<string>(249750244u),
		global::_003CModule_003E.smethod_9<string>(1743878320u),
		global::_003CModule_003E.smethod_8<string>(3220914922u),
		global::_003CModule_003E.smethod_6<string>(4147417938u),
		global::_003CModule_003E.smethod_7<string>(4053904058u),
		global::_003CModule_003E.smethod_7<string>(344819980u),
		global::_003CModule_003E.smethod_5<string>(1792856855u),
		global::_003CModule_003E.smethod_8<string>(2027618140u),
		global::_003CModule_003E.smethod_5<string>(2881103043u),
		global::_003CModule_003E.smethod_5<string>(2341124053u),
		global::_003CModule_003E.smethod_5<string>(3952772815u),
		global::_003CModule_003E.smethod_8<string>(1126316500u),
		global::_003CModule_003E.smethod_7<string>(151035210u),
		global::_003CModule_003E.smethod_5<string>(189496301u),
		global::_003CModule_003E.smethod_8<string>(4122216562u),
		global::_003CModule_003E.smethod_8<string>(3830221420u),
		global::_003CModule_003E.smethod_9<string>(3128428354u),
		global::_003CModule_003E.smethod_9<string>(3814018832u),
		global::_003CModule_003E.smethod_7<string>(2097940726u),
		global::_003CModule_003E.smethod_8<string>(2928919780u),
		global::_003CModule_003E.smethod_8<string>(4227987014u),
		global::_003CModule_003E.smethod_6<string>(274859686u),
		global::_003CModule_003E.smethod_9<string>(1239712270u),
		global::_003CModule_003E.smethod_8<string>(1337857404u),
		global::_003CModule_003E.smethod_7<string>(1318272738u),
		global::_003CModule_003E.smethod_8<string>(3034690232u),
		global::_003CModule_003E.smethod_6<string>(299969128u),
		global::_003CModule_003E.smethod_7<string>(3075922392u),
		global::_003CModule_003E.smethod_7<string>(3661805610u),
		global::_003CModule_003E.smethod_9<string>(3296483704u),
		global::_003CModule_003E.smethod_8<string>(3432455826u),
		global::_003CModule_003E.smethod_9<string>(3995443260u),
		global::_003CModule_003E.smethod_5<string>(2905967667u),
		global::_003CModule_003E.smethod_6<string>(174421918u),
		global::_003CModule_003E.smethod_6<string>(2905300248u),
		global::_003CModule_003E.smethod_6<string>(1341211282u),
		global::_003CModule_003E.smethod_8<string>(3538226278u),
		global::_003CModule_003E.smethod_8<string>(3935991872u),
		global::_003CModule_003E.smethod_7<string>(2499096990u),
		global::_003CModule_003E.smethod_8<string>(648096668u),
		global::_003CModule_003E.smethod_7<string>(3670863426u),
		global::_003CModule_003E.smethod_6<string>(4097199054u),
		global::_003CModule_003E.smethod_9<string>(1757247398u),
		global::_003CModule_003E.smethod_8<string>(4041762324u),
		global::_003CModule_003E.smethod_6<string>(3699899452u),
		global::_003CModule_003E.smethod_9<string>(1071656920u),
		global::_003CModule_003E.smethod_5<string>(1834297895u),
		global::_003CModule_003E.smethod_7<string>(1908684864u),
		global::_003CModule_003E.smethod_5<string>(2889391251u),
		global::_003CModule_003E.smethod_7<string>(3080451300u),
		global::_003CModule_003E.smethod_9<string>(567490870u),
		global::_003CModule_003E.smethod_8<string>(1549398308u),
		global::_003CModule_003E.smethod_8<string>(2848465542u),
		global::_003CModule_003E.smethod_5<string>(197784509u),
		global::_003CModule_003E.smethod_6<string>(199531360u),
		global::_003CModule_003E.smethod_9<string>(735546220u),
		global::_003CModule_003E.smethod_5<string>(2897679459u),
		global::_003CModule_003E.smethod_9<string>(2624262304u),
		global::_003CModule_003E.smethod_8<string>(2954235994u),
		global::_003CModule_003E.smethod_9<string>(1253081348u),
		global::_003CModule_003E.smethod_9<string>(2456206954u),
		global::_003CModule_003E.smethod_5<string>(206072717u),
		global::_003CModule_003E.smethod_7<string>(2106998542u),
		global::_003CModule_003E.smethod_8<string>(537820620u),
		global::_003CModule_003E.smethod_9<string>(748915298u),
		global::_003CModule_003E.smethod_9<string>(1434505776u),
		global::_003CModule_003E.smethod_7<string>(3702565782u),
		global::_003CModule_003E.smethod_5<string>(3338199953u),
		global::_003CModule_003E.smethod_5<string>(654881419u),
		global::_003CModule_003E.smethod_6<string>(3996761286u),
		global::_003CModule_003E.smethod_9<string>(3155166510u),
		global::_003CModule_003E.smethod_5<string>(1203148617u),
		global::_003CModule_003E.smethod_8<string>(3639491134u),
		global::_003CModule_003E.smethod_8<string>(4037256728u),
		global::_003CModule_003E.smethod_7<string>(4094664230u),
		global::_003CModule_003E.smethod_5<string>(3346488161u),
		global::_003CModule_003E.smethod_7<string>(971463370u),
		global::_003CModule_003E.smethod_9<string>(916970648u),
		global::_003CModule_003E.smethod_9<string>(2120096254u),
		global::_003CModule_003E.smethod_6<string>(4046980170u),
		global::_003CModule_003E.smethod_5<string>(2789932755u),
		global::_003CModule_003E.smethod_5<string>(2249953765u),
		global::_003CModule_003E.smethod_6<string>(3649680568u),
		global::_003CModule_003E.smethod_7<string>(3504252104u),
		global::_003CModule_003E.smethod_6<string>(521502636u),
		global::_003CModule_003E.smethod_7<string>(381051244u),
		global::_003CModule_003E.smethod_8<string>(1942658306u),
		global::_003CModule_003E.smethod_9<string>(580859948u),
		global::_003CModule_003E.smethod_6<string>(2110701044u),
		global::_003CModule_003E.smethod_6<string>(546612078u),
		global::_003CModule_003E.smethod_8<string>(351595930u),
		global::_003CModule_003E.smethod_9<string>(1098395076u),
		global::_003CModule_003E.smethod_7<string>(187266474u),
		global::_003CModule_003E.smethod_7<string>(773149692u),
		global::_003CModule_003E.smethod_8<string>(3745261586u),
		global::_003CModule_003E.smethod_6<string>(1985153834u),
		global::_003CModule_003E.smethod_6<string>(421064868u),
		global::_003CModule_003E.smethod_6<string>(3151943198u),
		global::_003CModule_003E.smethod_5<string>(3911331775u),
		global::_003CModule_003E.smethod_8<string>(2551964804u),
		global::_003CModule_003E.smethod_5<string>(688034251u),
		global::_003CModule_003E.smethod_8<string>(4248797632u),
		global::_003CModule_003E.smethod_8<string>(1252897570u),
		global::_003CModule_003E.smethod_9<string>(2651000460u),
		global::_003CModule_003E.smethod_7<string>(196324290u),
		global::_003CModule_003E.smethod_7<string>(782207508u),
		global::_003CModule_003E.smethod_7<string>(1368090726u),
		global::_003CModule_003E.smethod_8<string>(59600788u),
		global::_003CModule_003E.smethod_7<string>(2539857162u),
		global::_003CModule_003E.smethod_6<string>(818364470u),
		global::_003CModule_003E.smethod_7<string>(3711623598u),
		global::_003CModule_003E.smethod_9<string>(1461243932u),
		global::_003CModule_003E.smethod_9<string>(2664369538u),
		global::_003CModule_003E.smethod_8<string>(165371240u),
		global::_003CModule_003E.smethod_8<string>(1464438474u),
		global::_003CModule_003E.smethod_9<string>(1978779060u),
		global::_003CModule_003E.smethod_6<string>(2010263276u),
		global::_003CModule_003E.smethod_5<string>(131478845u),
		global::_003CModule_003E.smethod_7<string>(2535328254u),
		global::_003CModule_003E.smethod_6<string>(868583354u),
		global::_003CModule_003E.smethod_5<string>(2831373795u),
		global::_003CModule_003E.smethod_5<string>(2291394805u),
		global::_003CModule_003E.smethod_6<string>(471283752u),
		global::_003CModule_003E.smethod_5<string>(3363064577u),
		global::_003CModule_003E.smethod_7<string>(1755660266u),
		global::_003CModule_003E.smethod_5<string>(139767053u),
		global::_003CModule_003E.smethod_8<string>(2365740114u),
		global::_003CModule_003E.smethod_7<string>(3103095840u),
		global::_003CModule_003E.smethod_5<string>(2740203507u),
		global::_003CModule_003E.smethod_7<string>(4274862276u),
		global::_003CModule_003E.smethod_6<string>(3076614872u),
		global::_003CModule_003E.smethod_6<string>(1512525906u),
		global::_003CModule_003E.smethod_8<string>(3694629158u),
		global::_003CModule_003E.smethod_9<string>(1642668360u),
		global::_003CModule_003E.smethod_9<string>(2845793966u),
		global::_003CModule_003E.smethod_7<string>(3495194288u),
		global::_003CModule_003E.smethod_5<string>(2748491715u),
		global::_003CModule_003E.smethod_7<string>(371993428u),
		global::_003CModule_003E.smethod_7<string>(957876646u),
		global::_003CModule_003E.smethod_8<string>(4198165204u),
		global::_003CModule_003E.smethod_5<string>(596863963u),
		global::_003CModule_003E.smethod_9<string>(607598104u),
		global::_003CModule_003E.smethod_8<string>(2899097970u),
		global::_003CModule_003E.smethod_8<string>(2607102828u),
		global::_003CModule_003E.smethod_6<string>(1165445188u),
		global::_003CModule_003E.smethod_7<string>(3490665380u),
		global::_003CModule_003E.smethod_8<string>(1308035594u)
	};

	public int RealLevel { get; }

	public string Name { get; }

	public int Act { get; }

	public bool IsTown { get; }

	public bool IsHideout { get; }

	public bool HasWaypoint { get; }

	public uint Hash { get; }

	public int Rows { get; private set; }

	public int Cols { get; private set; }

	public AreaMap AreaMap { get; }

	public string DisplayName => Name + global::_003CModule_003E.smethod_8<string>(2063339663u) + RealLevel + global::_003CModule_003E.smethod_9<string>(614282643u);

	public AreaInstance(AreaTemplate area, AreaMap areaMap, uint hash, int realLevel)
	{
		Hash = hash;
		RealLevel = realLevel;
		Name = area.Name;
		Act = area.Act;
		IsTown = area.IsTown;
		HasWaypoint = area.HasWaypoint;
		IsHideout = Name.Contains(global::_003CModule_003E.smethod_9<string>(3994501385u)) && !Name.Contains(global::_003CModule_003E.smethod_6<string>(768145586u));
		AreaMap = areaMap;
	}

	public override string ToString()
	{
		return string.Format(global::_003CModule_003E.smethod_9<string>(3712808872u), Name, RealLevel, Hash);
	}

	public static string GetTimeString(TimeSpan timeSpent)
	{
		int num = (int)timeSpent.TotalSeconds;
		int num2 = num % 60;
		int num3 = num / 60;
		int num4 = num3 / 60;
		num3 %= 60;
		return string.Format((num4 > 0) ? global::_003CModule_003E.smethod_5<string>(3533595576u) : global::_003CModule_003E.smethod_5<string>(2461925804u), num4, num3, num2);
	}

	private List<AreaTilesData> GenerateTiles()
	{
		if (!LokiPoe.IsInGame)
		{
			return new List<AreaTilesData>();
		}
		long grountMapStart = AreaMap.GrountMapStart;
		long groundMapEnd = AreaMap.GroundMapEnd;
		int mapWidth = AreaMap.MapWidth;
		Memory memory = AreaMap.Memory;
		int length = (int)(groundMapEnd - grountMapStart);
		byte[] array = memory.ReadBytes(grountMapStart, length);
		Rows = mapWidth;
		Cols = array.Length / mapWidth;
		List<AreaTilesData> list = new List<AreaTilesData>();
		int num = 0;
		int num2 = 0;
		byte[] array2 = array;
		foreach (byte @byte in array2)
		{
			AreaTilesData item = new AreaTilesData
			{
				X = num,
				Y = num2,
				Byte = @byte,
				Point = new Vector2i(num, num2)
			};
			list.Add(item);
			num++;
			if (num >= mapWidth)
			{
				num2++;
				num = 0;
			}
		}
		return list;
	}

	private Color getColorFromTile(AreaTilesData tile)
	{
		if (tile.Byte == 0)
		{
			return Color.White;
		}
		if (tile.Byte > 0 && tile.Byte < 17)
		{
			return Color.Black;
		}
		if (tile.Byte == 17)
		{
			return Color.DarkSlateGray;
		}
		if (tile.Byte > 17 && tile.Byte < 34)
		{
			return Color.Silver;
		}
		if (tile.Byte != 34)
		{
			if (tile.Byte > 34 && tile.Byte < 51)
			{
				return Color.LawnGreen;
			}
			if (tile.Byte != 51)
			{
				if (tile.Byte > 51 && tile.Byte < 68)
				{
					return Color.PaleGoldenrod;
				}
				if (tile.Byte != 68)
				{
					if (tile.Byte > 68 && tile.Byte < 85)
					{
						return Color.Beige;
					}
					if (tile.Byte == 85)
					{
						return Color.White;
					}
					return Color.Pink;
				}
				return Color.AntiqueWhite;
			}
			return Color.GreenYellow;
		}
		return Color.LimeGreen;
	}
}
