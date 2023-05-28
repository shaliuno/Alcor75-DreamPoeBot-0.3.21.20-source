using System;
using System.Runtime.InteropServices;
using System.Security;

namespace DreamPoeBot.Loki.Common;

public static class OSInfo
{
	private struct Struct332
	{
		public int int_0;

		public readonly int int_1;

		public readonly int int_2;

		public readonly int int_3;

		public readonly int int_4;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public readonly string string_0;

		public readonly short short_0;

		public readonly short short_1;

		public readonly short short_2;

		public readonly byte byte_0;

		public readonly byte byte_1;
	}

	private static string string_0;

	private static string string_1;

	private const int int_0 = 0;

	private const int int_1 = 1;

	private const int int_2 = 2;

	private const int int_3 = 3;

	private const int int_4 = 4;

	private const int int_5 = 5;

	private const int int_6 = 6;

	private const int int_7 = 7;

	private const int int_8 = 8;

	private const int int_9 = 9;

	private const int int_10 = 10;

	private const int int_11 = 11;

	private const int int_12 = 12;

	private const int int_13 = 13;

	private const int int_14 = 14;

	private const int int_15 = 15;

	private const int int_16 = 16;

	private const int int_17 = 17;

	private const int int_18 = 18;

	private const int int_19 = 19;

	private const int int_20 = 20;

	private const int int_21 = 21;

	private const int int_22 = 22;

	private const int int_23 = 23;

	private const int int_24 = 24;

	private const int int_25 = 25;

	private const int int_26 = 26;

	private const int int_27 = 27;

	private const int int_28 = 28;

	private const int int_29 = 29;

	private const int int_30 = 30;

	private const int int_31 = 31;

	private const int int_32 = 32;

	private const int int_33 = 35;

	private const int int_34 = 36;

	private const int int_35 = 38;

	private const int int_36 = 40;

	private const int int_37 = 41;

	private const int int_38 = 42;

	private const int int_39 = 101;

	private const int int_40 = 98;

	private const int int_41 = 99;

	private const int int_42 = 100;

	private const int int_43 = 48;

	private const int int_44 = 1;

	private const int int_45 = 2;

	private const int int_46 = 3;

	private const int int_47 = 1;

	private const int int_48 = 2;

	private const int int_49 = 16;

	private const int int_50 = 128;

	private const int int_51 = 256;

	private const int int_52 = 512;

	private const int int_53 = 1024;

	public static int Bits
	{
		get
		{
			if (Environment.Is64BitOperatingSystem)
			{
				return 64;
			}
			return 32;
		}
	}

	public static string Edition
	{
		get
		{
			if (string_0 == null)
			{
				uint num = default(uint);
				while (true)
				{
					string result = string.Empty;
					while (true)
					{
						OperatingSystem oSVersion = Environment.OSVersion;
						while (true)
						{
							Struct332 struct332_ = default(Struct332);
							while (true)
							{
								struct332_.int_0 = Marshal.SizeOf(typeof(Struct332));
								while (true)
								{
									IL_0304:
									if (GetVersionEx(ref struct332_))
									{
										while (true)
										{
											IL_02d5:
											int major = oSVersion.Version.Major;
											int minor = oSVersion.Version.Minor;
											byte byte_ = struct332_.byte_0;
											short short_ = struct332_.short_2;
											if (major != 4)
											{
												while (true)
												{
													IL_02cc:
													if (major != 5)
													{
														while (major == 6)
														{
															int int_;
															while (GetProductInfo(major, minor, struct332_.short_0, struct332_.short_1, out int_))
															{
																while (true)
																{
																	switch (int_)
																	{
																	case 0:
																		goto IL_0467;
																	case 1:
																		goto IL_0477;
																	case 2:
																		goto IL_0487;
																	case 3:
																		goto IL_0497;
																	case 4:
																		goto IL_04a7;
																	case 5:
																		goto IL_04b7;
																	case 6:
																		goto IL_04c7;
																	case 7:
																		goto IL_04d7;
																	case 8:
																		goto IL_04e7;
																	case 9:
																		goto IL_04f7;
																	case 10:
																		goto IL_0507;
																	case 11:
																		goto IL_0517;
																	case 12:
																		goto IL_0527;
																	case 13:
																		goto IL_0537;
																	case 14:
																		goto IL_0547;
																	case 15:
																		goto IL_0557;
																	case 16:
																		goto IL_0567;
																	case 17:
																		goto IL_0577;
																	case 18:
																		goto IL_0587;
																	case 20:
																		goto IL_0597;
																	case 21:
																		goto IL_05a7;
																	case 22:
																		goto IL_05b7;
																	case 23:
																		goto IL_05c7;
																	case 24:
																		goto IL_05d7;
																	case 26:
																		goto IL_05e7;
																	case 27:
																		goto IL_05f7;
																	case 28:
																		goto IL_0607;
																	case 29:
																		goto IL_0617;
																	case 30:
																		goto IL_0627;
																	case 31:
																		goto IL_0634;
																	case 32:
																		goto IL_0641;
																	case 35:
																		goto IL_064e;
																	case 36:
																		goto IL_065b;
																	case 38:
																		goto IL_0668;
																	case 40:
																		goto IL_0675;
																	case 41:
																		goto IL_0682;
																	case 42:
																		goto IL_068f;
																	case 48:
																		goto IL_069c;
																	case 19:
																	case 25:
																	case 33:
																	case 34:
																	case 37:
																	case 39:
																	case 43:
																	case 44:
																	case 45:
																	case 46:
																	case 47:
																		goto end_IL_01d3;
																	}
																	int num2 = ((int)num * -1243613694) ^ -149307566;
																	while (true)
																	{
																		switch ((num = (uint)num2 ^ 0x402F603Au) % 100u)
																		{
																		case 92u:
																			num2 = (int)(num * 988267079) ^ -343797219;
																			continue;
																		case 42u:
																			break;
																		case 95u:
																			goto IL_02a3;
																		case 12u:
																			goto IL_02c3;
																		case 76u:
																			goto IL_02cc;
																		case 11u:
																			goto IL_02d5;
																		case 88u:
																			goto IL_0304;
																		case 51u:
																			goto end_IL_0304;
																		case 69u:
																			goto end_IL_0312;
																		case 31u:
																			goto end_IL_032a;
																		case 5u:
																			goto end_IL_0334;
																		case 20u:
																			goto IL_0344;
																		case 9u:
																			goto IL_0349;
																		case 15u:
																		case 72u:
																			goto end_IL_033c;
																		case 78u:
																			goto IL_035f;
																		case 45u:
																			goto IL_0367;
																		case 68u:
																			goto IL_036d;
																		case 29u:
																			goto IL_037d;
																		case 93u:
																			goto IL_038d;
																		case 28u:
																			goto IL_0395;
																		case 74u:
																			goto IL_039f;
																		case 91u:
																			goto IL_03a3;
																		case 52u:
																			goto IL_03ad;
																		case 61u:
																			goto IL_03b3;
																		case 65u:
																			goto IL_03c3;
																		case 58u:
																			goto IL_03cd;
																		case 75u:
																			goto IL_03dd;
																		case 17u:
																			goto IL_03ed;
																		case 2u:
																			goto IL_03fd;
																		case 79u:
																			goto IL_0407;
																		case 49u:
																			goto IL_0417;
																		case 14u:
																			goto IL_041d;
																		case 71u:
																			goto IL_042d;
																		case 1u:
																			goto IL_043d;
																		case 63u:
																			goto IL_0447;
																		case 37u:
																			goto IL_0457;
																		case 62u:
																			goto IL_0467;
																		case 47u:
																			goto IL_0477;
																		case 33u:
																			goto IL_0487;
																		case 86u:
																			goto IL_0497;
																		case 10u:
																			goto IL_04a7;
																		case 3u:
																			goto IL_04b7;
																		case 94u:
																			goto IL_04c7;
																		case 96u:
																			goto IL_04d7;
																		case 26u:
																			goto IL_04e7;
																		case 7u:
																			goto IL_04f7;
																		case 99u:
																			goto IL_0507;
																		case 82u:
																			goto IL_0517;
																		case 53u:
																			goto IL_0527;
																		case 56u:
																			goto IL_0537;
																		case 38u:
																			goto IL_0547;
																		case 85u:
																			goto IL_0557;
																		case 0u:
																			goto IL_0567;
																		case 43u:
																			goto IL_0577;
																		case 16u:
																			goto IL_0587;
																		case 98u:
																			goto IL_0597;
																		case 66u:
																			goto IL_05a7;
																		case 97u:
																			goto IL_05b7;
																		case 90u:
																			goto IL_05c7;
																		case 77u:
																			goto IL_05d7;
																		case 24u:
																			goto IL_05e7;
																		case 18u:
																			goto IL_05f7;
																		case 41u:
																			goto IL_0607;
																		case 46u:
																			goto IL_0617;
																		case 83u:
																			goto IL_0627;
																		case 48u:
																			goto IL_0634;
																		case 35u:
																			goto IL_0641;
																		case 81u:
																			goto IL_064e;
																		case 36u:
																			goto IL_065b;
																		case 23u:
																			goto IL_0668;
																		case 6u:
																			goto IL_0675;
																		case 44u:
																			goto IL_0682;
																		case 54u:
																			goto IL_068f;
																		case 21u:
																			goto IL_069c;
																		case 4u:
																		case 8u:
																		case 13u:
																		case 19u:
																		case 22u:
																		case 27u:
																		case 30u:
																		case 32u:
																		case 34u:
																		case 39u:
																		case 40u:
																		case 50u:
																		case 55u:
																		case 57u:
																		case 59u:
																		case 60u:
																		case 64u:
																		case 67u:
																		case 70u:
																		case 73u:
																		case 80u:
																		case 84u:
																		case 87u:
																		case 89u:
																			goto end_IL_01d3;
																		default:
																			goto IL_06ad;
																		}
																		break;
																	}
																	continue;
																	IL_0477:
																	result = global::_003CModule_003E.smethod_9<string>(1948794153u);
																	break;
																	IL_0467:
																	result = global::_003CModule_003E.smethod_8<string>(2999414892u);
																	break;
																	IL_069c:
																	result = global::_003CModule_003E.smethod_6<string>(3084174509u);
																	break;
																	IL_068f:
																	result = global::_003CModule_003E.smethod_6<string>(2212021244u);
																	break;
																	IL_0682:
																	result = global::_003CModule_003E.smethod_5<string>(3456349338u);
																	break;
																	IL_0675:
																	result = global::_003CModule_003E.smethod_6<string>(4075197779u);
																	break;
																	IL_0668:
																	result = global::_003CModule_003E.smethod_5<string>(1404180082u);
																	break;
																	IL_065b:
																	result = global::_003CModule_003E.smethod_9<string>(1659475226u);
																	break;
																	IL_064e:
																	result = global::_003CModule_003E.smethod_6<string>(3454138934u);
																	break;
																	IL_0641:
																	result = global::_003CModule_003E.smethod_6<string>(4248738138u);
																	break;
																	IL_0634:
																	result = global::_003CModule_003E.smethod_7<string>(2814478724u);
																	break;
																	IL_0627:
																	result = global::_003CModule_003E.smethod_5<string>(3784356289u);
																	break;
																	IL_0617:
																	result = global::_003CModule_003E.smethod_8<string>(1469390253u);
																	break;
																	IL_0607:
																	result = global::_003CModule_003E.smethod_7<string>(3098362517u);
																	break;
																	IL_05f7:
																	result = global::_003CModule_003E.smethod_6<string>(3355926901u);
																	break;
																	IL_05e7:
																	result = global::_003CModule_003E.smethod_6<string>(823698372u);
																	break;
																	IL_05d7:
																	result = global::_003CModule_003E.smethod_5<string>(3800932705u);
																	break;
																	IL_05c7:
																	result = global::_003CModule_003E.smethod_5<string>(1657593161u);
																	break;
																	IL_05b7:
																	result = global::_003CModule_003E.smethod_8<string>(754313303u);
																	break;
																	IL_05a7:
																	result = global::_003CModule_003E.smethod_9<string>(3521453154u);
																	break;
																	IL_0597:
																	result = global::_003CModule_003E.smethod_6<string>(2661765465u);
																	break;
																	IL_0587:
																	result = global::_003CModule_003E.smethod_8<string>(3170728677u);
																	break;
																	IL_0577:
																	result = global::_003CModule_003E.smethod_7<string>(1894893725u);
																	break;
																	IL_0567:
																	result = global::_003CModule_003E.smethod_6<string>(3456364669u);
																	break;
																	IL_0557:
																	result = global::_003CModule_003E.smethod_5<string>(1462197538u);
																	break;
																	IL_0547:
																	result = global::_003CModule_003E.smethod_5<string>(3900391201u);
																	break;
																	IL_0537:
																	result = global::_003CModule_003E.smethod_8<string>(109285282u);
																	break;
																	IL_0527:
																	result = global::_003CModule_003E.smethod_6<string>(1444757217u);
																	break;
																	IL_0517:
																	result = global::_003CModule_003E.smethod_7<string>(822284128u);
																	break;
																	IL_0507:
																	result = global::_003CModule_003E.smethod_8<string>(1962520990u);
																	break;
																	IL_04f7:
																	result = global::_003CModule_003E.smethod_8<string>(255282853u);
																	break;
																	IL_04e7:
																	result = global::_003CModule_003E.smethod_8<string>(1740574777u);
																	break;
																	IL_04d7:
																	result = global::_003CModule_003E.smethod_6<string>(4177861282u);
																	break;
																	IL_04c7:
																	result = global::_003CModule_003E.smethod_8<string>(2203883704u);
																	break;
																	IL_04b7:
																	result = global::_003CModule_003E.smethod_7<string>(3156759184u);
																	break;
																	IL_04a7:
																	result = global::_003CModule_003E.smethod_5<string>(3065558092u);
																	break;
																	IL_0497:
																	result = global::_003CModule_003E.smethod_9<string>(2809124520u);
																	break;
																	IL_0487:
																	result = global::_003CModule_003E.smethod_8<string>(2098113252u);
																	break;
																	continue;
																	end_IL_01d3:
																	break;
																}
																break;
																IL_02a3:;
															}
															break;
															IL_02c3:;
														}
														break;
													}
													goto IL_038d;
													IL_0457:
													result = global::_003CModule_003E.smethod_9<string>(1585945297u);
													break;
													IL_038d:
													if (byte_ != 1)
													{
														goto IL_0395;
													}
													goto IL_043d;
													IL_0395:
													if (byte_ != 3)
													{
														break;
													}
													goto IL_039f;
													IL_039f:
													if (minor != 0)
													{
														goto IL_03a3;
													}
													goto IL_03fd;
													IL_03a3:
													if ((short_ & 0x80) == 0)
													{
														goto IL_03ad;
													}
													goto IL_03ed;
													IL_03ad:
													if (((uint)short_ & 2u) != 0)
													{
														goto IL_03b3;
													}
													goto IL_03c3;
													IL_03b3:
													result = global::_003CModule_003E.smethod_7<string>(1696580047u);
													break;
													IL_03c3:
													if ((short_ & 0x400) == 0)
													{
														goto IL_03cd;
													}
													goto IL_03dd;
													IL_03cd:
													result = global::_003CModule_003E.smethod_8<string>(3940943651u);
													break;
													IL_03dd:
													result = global::_003CModule_003E.smethod_7<string>(2868346483u);
													break;
													IL_03ed:
													result = global::_003CModule_003E.smethod_6<string>(1147895383u);
													break;
													IL_03fd:
													if (((uint)short_ & 0x80u) != 0)
													{
														goto IL_0407;
													}
													goto IL_0417;
													IL_0407:
													result = global::_003CModule_003E.smethod_9<string>(2970495331u);
													break;
													IL_0417:
													if (((uint)short_ & 2u) != 0)
													{
														goto IL_041d;
													}
													goto IL_042d;
													IL_041d:
													result = global::_003CModule_003E.smethod_7<string>(2476248035u);
													break;
													IL_042d:
													result = global::_003CModule_003E.smethod_5<string>(2247301399u);
													break;
													IL_043d:
													if ((short_ & 0x200) == 0)
													{
														goto IL_0447;
													}
													goto IL_0457;
													IL_0447:
													result = global::_003CModule_003E.smethod_9<string>(1081779247u);
													break;
												}
												break;
											}
											goto IL_0344;
											IL_037d:
											result = global::_003CModule_003E.smethod_5<string>(3418429667u);
											break;
											IL_0344:
											if (byte_ == 1)
											{
												goto IL_0349;
											}
											goto IL_035f;
											IL_0349:
											result = global::_003CModule_003E.smethod_9<string>(4166936398u);
											break;
											IL_035f:
											if (byte_ != 3)
											{
												break;
											}
											goto IL_0367;
											IL_0367:
											if ((short_ & 2) == 0)
											{
												goto IL_036d;
											}
											goto IL_037d;
											IL_036d:
											result = global::_003CModule_003E.smethod_9<string>(40024452u);
											break;
										}
									}
									string_0 = result;
									goto IL_06ad;
									IL_06ad:
									return result;
									continue;
									end_IL_0304:
									break;
								}
								continue;
								end_IL_0312:
								break;
							}
							continue;
							end_IL_032a:
							break;
						}
						continue;
						end_IL_0334:
						break;
					}
					continue;
					end_IL_033c:
					break;
				}
			}
			return string_0;
		}
	}

	public static string Name
	{
		get
		{
			if (string_1 == null)
			{
				uint num = default(uint);
				string text = default(string);
				while (true)
				{
					string result = global::_003CModule_003E.smethod_5<string>(1836412368u);
					while (true)
					{
						OperatingSystem oSVersion = Environment.OSVersion;
						while (true)
						{
							Struct332 struct332_ = default(Struct332);
							struct332_.int_0 = Marshal.SizeOf(typeof(Struct332));
							while (true)
							{
								IL_01a4:
								if (GetVersionEx(ref struct332_))
								{
									while (true)
									{
										IL_0196:
										int major = oSVersion.Version.Major;
										while (true)
										{
											IL_017f:
											int minor = oSVersion.Version.Minor;
											PlatformID platform = oSVersion.Platform;
											while (true)
											{
												IL_0178:
												if (platform != PlatformID.Win32Windows)
												{
													while (platform == PlatformID.Win32NT)
													{
														while (true)
														{
															byte byte_ = struct332_.byte_0;
															while (true)
															{
																switch (major)
																{
																case 3:
																	goto IL_029c;
																case 4:
																	goto IL_02ac;
																case 5:
																	goto IL_02d9;
																case 6:
																	goto IL_0336;
																}
																int num2 = ((int)num * -802023819) ^ 0x56BEC6D5;
																while (true)
																{
																	switch ((num = (uint)num2 ^ 0xE7D1DA23u) % 65u)
																	{
																	case 21u:
																		num2 = (int)((num * 60136477) ^ 0xC665BB1);
																		continue;
																	case 15u:
																		break;
																	case 24u:
																		goto end_IL_0147;
																	case 52u:
																		goto end_IL_0164;
																	case 6u:
																		goto IL_0178;
																	case 56u:
																		goto IL_017f;
																	case 19u:
																		goto IL_0196;
																	case 26u:
																		goto IL_01a4;
																	case 35u:
																		goto end_IL_01a4;
																	case 63u:
																		goto end_IL_01b2;
																	case 60u:
																		goto end_IL_01d2;
																	case 30u:
																		goto IL_01e7;
																	case 5u:
																		goto IL_01ee;
																	case 39u:
																	case 46u:
																		goto end_IL_01da;
																	case 62u:
																		goto IL_01fe;
																	case 32u:
																		goto IL_0202;
																	case 14u:
																		goto IL_0215;
																	case 55u:
																		goto IL_0228;
																	case 57u:
																		goto IL_0238;
																	case 1u:
																		goto IL_0248;
																	case 11u:
																		goto IL_024e;
																	case 8u:
																		goto IL_0259;
																	case 10u:
																		goto IL_0269;
																	case 18u:
																		goto IL_027c;
																	case 47u:
																		goto IL_028c;
																	case 54u:
																		goto IL_029c;
																	case 12u:
																		goto IL_02ac;
																	case 42u:
																		goto IL_02b1;
																	case 25u:
																		goto IL_02c1;
																	case 59u:
																		goto IL_02c9;
																	case 29u:
																		goto IL_02d9;
																	case 50u:
																		goto IL_02f1;
																	case 43u:
																		goto IL_0301;
																	case 4u:
																		goto IL_0311;
																	case 40u:
																		goto IL_0316;
																	case 61u:
																		goto IL_0326;
																	case 33u:
																		goto IL_0336;
																	case 34u:
																		goto IL_034b;
																	case 58u:
																		goto IL_0350;
																	case 48u:
																		goto IL_0357;
																	case 53u:
																		goto IL_0364;
																	case 23u:
																		goto IL_0371;
																	case 38u:
																		goto IL_0376;
																	case 64u:
																		goto IL_0383;
																	case 28u:
																		goto IL_038a;
																	case 37u:
																		goto IL_0397;
																	case 41u:
																		goto IL_039c;
																	case 17u:
																		goto IL_03a3;
																	case 36u:
																		goto IL_03b0;
																	case 0u:
																	case 2u:
																	case 3u:
																	case 7u:
																	case 9u:
																	case 13u:
																	case 20u:
																	case 22u:
																	case 27u:
																	case 31u:
																	case 44u:
																	case 45u:
																	case 49u:
																	case 51u:
																		goto end_IL_016e;
																	default:
																		goto IL_03c1;
																	}
																	break;
																}
																continue;
																IL_02c9:
																result = global::_003CModule_003E.smethod_6<string>(474391919u);
																goto end_IL_016e;
																IL_029c:
																result = global::_003CModule_003E.smethod_6<string>(2237130686u);
																goto end_IL_016e;
																IL_0336:
																switch (minor)
																{
																case 0:
																	break;
																case 1:
																	goto IL_0371;
																case 2:
																	goto IL_0397;
																default:
																	goto end_IL_016e;
																}
																goto IL_034b;
																IL_0397:
																if (byte_ != 1)
																{
																	goto IL_039c;
																}
																goto IL_03b0;
																IL_039c:
																if (byte_ != 2)
																{
																	goto end_IL_016e;
																}
																goto IL_03a3;
																IL_03a3:
																result = global::_003CModule_003E.smethod_9<string>(993938365u);
																goto end_IL_016e;
																IL_03b0:
																result = global::_003CModule_003E.smethod_8<string>(396774828u);
																goto end_IL_016e;
																IL_0371:
																if (byte_ == 1)
																{
																	goto IL_0376;
																}
																goto IL_0383;
																IL_0376:
																result = global::_003CModule_003E.smethod_7<string>(948614415u);
																goto end_IL_016e;
																IL_0383:
																if (byte_ != 3)
																{
																	goto end_IL_016e;
																}
																goto IL_038a;
																IL_038a:
																result = global::_003CModule_003E.smethod_6<string>(944794112u);
																goto end_IL_016e;
																IL_034b:
																if (byte_ != 1)
																{
																	goto IL_0350;
																}
																goto IL_0364;
																IL_0350:
																if (byte_ != 3)
																{
																	goto end_IL_016e;
																}
																goto IL_0357;
																IL_0357:
																result = global::_003CModule_003E.smethod_9<string>(2197063971u);
																goto end_IL_016e;
																IL_0364:
																result = global::_003CModule_003E.smethod_8<string>(2133834775u);
																goto end_IL_016e;
																IL_02d9:
																switch (minor)
																{
																case 0:
																	break;
																case 1:
																	goto IL_0301;
																case 2:
																	goto IL_0311;
																default:
																	goto end_IL_016e;
																}
																goto IL_02f1;
																IL_0311:
																if (byte_ != 1)
																{
																	goto IL_0316;
																}
																goto IL_0326;
																IL_0316:
																result = global::_003CModule_003E.smethod_7<string>(939556599u);
																goto end_IL_016e;
																IL_0326:
																result = global::_003CModule_003E.smethod_7<string>(4062757459u);
																goto end_IL_016e;
																IL_0301:
																result = global::_003CModule_003E.smethod_7<string>(4062757459u);
																goto end_IL_016e;
																IL_02f1:
																result = global::_003CModule_003E.smethod_6<string>(3230379691u);
																goto end_IL_016e;
																IL_02ac:
																if (byte_ == 1)
																{
																	goto IL_02b1;
																}
																goto IL_02c1;
																IL_02b1:
																result = global::_003CModule_003E.smethod_9<string>(3044025260u);
																goto end_IL_016e;
																IL_02c1:
																if (byte_ != 3)
																{
																	goto end_IL_016e;
																}
																goto IL_02c9;
																continue;
																end_IL_0147:
																break;
															}
															continue;
															end_IL_0164:
															break;
														}
														continue;
														end_IL_016e:
														break;
													}
													break;
												}
												goto IL_01e7;
												IL_028c:
												result = global::_003CModule_003E.smethod_9<string>(1350102682u);
												break;
												IL_01e7:
												if (major != 4)
												{
													break;
												}
												goto IL_01ee;
												IL_01ee:
												text = struct332_.string_0;
												goto IL_01fe;
												IL_01fe:
												if (minor == 0)
												{
													goto IL_0202;
												}
												goto IL_0248;
												IL_0202:
												if (!(text == global::_003CModule_003E.smethod_6<string>(780156693u)))
												{
													goto IL_0215;
												}
												goto IL_0238;
												IL_0215:
												if (!(text == global::_003CModule_003E.smethod_8<string>(900310874u)))
												{
													goto IL_0228;
												}
												goto IL_0238;
												IL_0228:
												result = global::_003CModule_003E.smethod_8<string>(1298076468u);
												break;
												IL_0238:
												result = global::_003CModule_003E.smethod_9<string>(1000622904u);
												break;
												IL_0248:
												if (minor != 10)
												{
													goto IL_024e;
												}
												goto IL_0269;
												IL_024e:
												if (minor != 90)
												{
													break;
												}
												goto IL_0259;
												IL_0259:
												result = global::_003CModule_003E.smethod_7<string>(3188461540u);
												break;
												IL_0269:
												if (!(text == global::_003CModule_003E.smethod_6<string>(597713394u)))
												{
													goto IL_027c;
												}
												goto IL_028c;
												IL_027c:
												result = global::_003CModule_003E.smethod_8<string>(3498445342u);
												break;
											}
											break;
										}
										break;
									}
								}
								string_1 = result;
								goto IL_03c1;
								IL_03c1:
								return result;
								continue;
								end_IL_01a4:
								break;
							}
							continue;
							end_IL_01b2:
							break;
						}
						continue;
						end_IL_01d2:
						break;
					}
					continue;
					end_IL_01da:
					break;
				}
			}
			return string_1;
		}
	}

	public static string ServicePack
	{
		get
		{
			string empty = string.Empty;
			Struct332 struct332_ = default(Struct332);
			struct332_.int_0 = Marshal.SizeOf(typeof(Struct332));
			if (GetVersionEx(ref struct332_))
			{
				empty = struct332_.string_0;
			}
			return empty;
		}
	}

	public static int BuildVersion => Environment.OSVersion.Version.Build;

	public static string VersionString => Environment.OSVersion.Version.ToString();

	public static Version Version => Environment.OSVersion.Version;

	public static int MajorVersion => Environment.OSVersion.Version.Major;

	public static int MinorVersion => Environment.OSVersion.Version.Minor;

	public static int RevisionVersion => Environment.OSVersion.Version.Revision;

	[DllImport("Kernel32.dll")]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool GetProductInfo(int int_54, int int_55, int int_56, int int_57, out int int_58);

	[DllImport("kernel32.dll")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool GetVersionEx(ref Struct332 struct332_0);
}
