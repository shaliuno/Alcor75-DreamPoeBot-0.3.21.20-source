using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

internal class RegionInventory : Element
{
	internal LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum Region
	{
		get
		{
			if (!string.IsNullOrEmpty(base.Children[3]?.Children[0]?.Children[0]?.Text))
			{
				return GetRegionEnum(base.Children[3].Children[0].Children[0].Text);
			}
			return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Unknown;
		}
	}

	internal bool IsOccupied => base.Children[0].IsVisibleLocal;

	internal LokiPoe.InstanceInfo.Atlas.Conqueror Conqueror => GetConqueror();

	internal int RequiredWatchstone => GetRequiredWatchstone();

	internal int RequiredMaps => GetRequiredMaps();

	internal Element Red => base.Children[4];

	internal Element Green => base.Children[5];

	internal Element Blue => base.Children[6];

	internal Element Yellow => base.Children[7];

	private LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum GetRegionEnum(string region)
	{
		switch (global::_003CPrivateImplementationDetails_003E.ComputeStringHash(region))
		{
		case 1821435848u:
			if (region == global::_003CModule_003E.smethod_9<string>(3478611709u))
			{
				return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Lex_Proxima;
			}
			goto default;
		case 2040570142u:
			if (region == global::_003CModule_003E.smethod_5<string>(3159004279u))
			{
				return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Lira_Arthain;
			}
			goto default;
		case 3131727946u:
			if (region == global::_003CModule_003E.smethod_5<string>(2897302992u))
			{
				return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.New_Vastir;
			}
			goto default;
		case 3247329921u:
			if (region == global::_003CModule_003E.smethod_8<string>(1168707164u))
			{
				return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Haewark_Hamlet;
			}
			goto default;
		case 647985391u:
			if (region == global::_003CModule_003E.smethod_5<string>(2087334507u))
			{
				return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Valdos_Rest;
			}
			goto default;
		case 1558219853u:
			if (region == global::_003CModule_003E.smethod_8<string>(519173547u))
			{
				return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Tirns_End;
			}
			goto default;
		case 471017189u:
			if (region == global::_003CModule_003E.smethod_6<string>(3206869627u))
			{
				return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Glennach_Cairns;
			}
			goto default;
		case 424247012u:
			if (region == global::_003CModule_003E.smethod_9<string>(1072360497u))
			{
				return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Lex_Ejoris;
			}
			goto default;
		default:
			return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Unknown;
		}
	}

	private LokiPoe.InstanceInfo.Atlas.Conqueror GetConqueror()
	{
		if (!IsOccupied)
		{
			return LokiPoe.InstanceInfo.Atlas.Conqueror.None;
		}
		string text = base.Children[0].Children[1].Children[0].Tooltip.Text;
		if (!text.Contains(global::_003CModule_003E.smethod_7<string>(1668231650u)))
		{
			if (!text.Contains(global::_003CModule_003E.smethod_8<string>(4124380107u)))
			{
				if (!text.Contains(global::_003CModule_003E.smethod_8<string>(3872612084u)))
				{
					if (!text.Contains(global::_003CModule_003E.smethod_6<string>(2437379865u)))
					{
						if (text.Contains(global::_003CModule_003E.smethod_8<string>(2573544850u)))
						{
							return LokiPoe.InstanceInfo.Atlas.Conqueror.Awakener;
						}
						return LokiPoe.InstanceInfo.Atlas.Conqueror.None;
					}
					return LokiPoe.InstanceInfo.Atlas.Conqueror.Redeemer;
				}
				return LokiPoe.InstanceInfo.Atlas.Conqueror.Warlord;
			}
			return LokiPoe.InstanceInfo.Atlas.Conqueror.Hunter;
		}
		return LokiPoe.InstanceInfo.Atlas.Conqueror.Crusader;
	}

	private int GetRequiredWatchstone()
	{
		if (!IsOccupied)
		{
			return 0;
		}
		string text = base.Children[0].Children[1].Children[0].Tooltip.Text;
		if (!text.Contains(global::_003CModule_003E.smethod_7<string>(3921665499u)))
		{
			if (!text.Contains(global::_003CModule_003E.smethod_5<string>(255425498u)))
			{
				if (text.Contains(global::_003CModule_003E.smethod_9<string>(400139097u)))
				{
					return 2;
				}
				if (!text.Contains(global::_003CModule_003E.smethod_8<string>(2241322589u)))
				{
					if (text.Contains(global::_003CModule_003E.smethod_9<string>(2134168909u)))
					{
						return 4;
					}
					return 0;
				}
				return 3;
			}
			return 1;
		}
		return 0;
	}

	private int GetRequiredMaps()
	{
		if (!IsOccupied)
		{
			return -1;
		}
		string text = base.Children[0].Children[1].Children[0].Tooltip.Text;
		if (text.Contains(global::_003CModule_003E.smethod_8<string>(1445791401u)))
		{
			return 1;
		}
		if (text.Contains(global::_003CModule_003E.smethod_9<string>(2645019498u)))
		{
			return 2;
		}
		if (text.Contains(global::_003CModule_003E.smethod_5<string>(2847573744u)))
		{
			return 3;
		}
		if (text.Contains(global::_003CModule_003E.smethod_8<string>(3670082372u)))
		{
			return 4;
		}
		if (!text.Contains(global::_003CModule_003E.smethod_5<string>(1244213190u)))
		{
			if (text.Contains(global::_003CModule_003E.smethod_9<string>(4266354022u)))
			{
				return 6;
			}
			if (text.Contains(global::_003CModule_003E.smethod_5<string>(1775903972u)))
			{
				return 7;
			}
			if (!text.Contains(global::_003CModule_003E.smethod_8<string>(1283488808u)))
			{
				if (!text.Contains(global::_003CModule_003E.smethod_5<string>(139390586u)))
				{
					if (!text.Contains(global::_003CModule_003E.smethod_9<string>(152811154u)))
					{
						if (!text.Contains(global::_003CModule_003E.smethod_6<string>(2684022815u)))
						{
							if (!text.Contains(global::_003CModule_003E.smethod_8<string>(3191862540u)))
							{
								return 0;
							}
							return 12;
						}
						return 11;
					}
					return 10;
				}
				return 9;
			}
			return 8;
		}
		return 5;
	}
}
