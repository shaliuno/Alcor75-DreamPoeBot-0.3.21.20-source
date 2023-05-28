using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Hooks;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game.NativeWrappers;
using DreamPoeBot.Loki.Game.Std;
using log4net;

namespace DreamPoeBot.Loki.Game;

public class TabControlWrapper : RemoteMemoryObject
{
	internal class ClassTabData
	{
		public long IntPtr_0 { get; }

		public long IntPtr_1 { get; }

		public string Name { get; }

		internal ClassTabData(Struct110 entry)
		{
			IntPtr_0 = entry.intptr_0;
			IntPtr_1 = entry.intptr_1;
			Name = Containers.StdStringWCustom(entry.nativeStringW_0);
		}

		public new virtual bool Equals(object obj)
		{
			if (obj is ClassTabData classTabData && IntPtr_1 == classTabData.IntPtr_1 && IntPtr_0 == classTabData.IntPtr_0)
			{
				return Name.Equals(classTabData.Name);
			}
			return false;
		}

		public bool method_0(ClassTabData class258_0)
		{
			if (class258_0 != null && IntPtr_1 == class258_0.IntPtr_1 && IntPtr_0 == class258_0.IntPtr_0)
			{
				return Name.Equals(class258_0.Name);
			}
			return false;
		}

		public new virtual int GetHashCode()
		{
			return IntPtr_0.GetHashCode() ^ IntPtr_1.GetHashCode() ^ Name.GetHashCode();
		}
	}

	private sealed class Class259
	{
		public static readonly Class259 Class9 = new Class259();

		public static Func<Struct110, ClassTabData> Method9__45_0;

		public static Func<ClassTabData, string> Method9__47_0;

		internal ClassTabData method_0(Struct110 struct110_0)
		{
			return new ClassTabData(struct110_0);
		}

		internal string method_1(ClassTabData class258_0)
		{
			return class258_0.Name;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct110
	{
		public readonly long intptr_0;

		public readonly long intptr_1;

		public readonly NativeStringWCustom nativeStringW_0;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct Struct111
	{
		private readonly long vtable;

		private readonly long intptr_0;

		private readonly long intptr_1;

		private readonly long intptr_2;

		private readonly long intptr_3;

		private readonly long intptr_4;

		private readonly long intptr_5;

		private readonly long intptr_6;

		private readonly long intptr_7;

		private readonly long intptr_8;

		private readonly long intptr_9;

		private readonly long intptr_10;

		public readonly NativeVector List_0;

		public readonly int CurrentTabIndex;

		public readonly byte byte_0;

		private readonly byte byte_1;

		private readonly byte byte_2;

		private readonly byte byte_3;

		public readonly int int_1;

		public readonly byte byte_4;

		private readonly byte byte_5;

		private readonly byte byte_6;

		private readonly byte byte_7;
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private TabControlType _tabControlType { get; set; }

	public int CurrentTabIndex
	{
		get
		{
			if (_tabControlType == TabControlType.Stash)
			{
				return Struct111_0.CurrentTabIndex;
			}
			if (_tabControlType != TabControlType.Parchase)
			{
				if (_tabControlType != TabControlType.Social)
				{
					if (_tabControlType == TabControlType.ExpeditionDealer)
					{
						return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.IndexVisibleStash;
					}
					if (_tabControlType == TabControlType.BloodCrucible)
					{
						return -1;
					}
					return Struct111_0.CurrentTabIndex;
				}
				return GameController.Instance.Game.IngameState.IngameUi.SocialPannel.IndexVisibleStash;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IsVisible)
			{
				return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.IndexVisibleStash;
			}
			return GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IndexVisibleStash;
		}
	}

	public string CurrentTabName
	{
		get
		{
			if (_tabControlType == TabControlType.Stash)
			{
				return Class258_0?.Name;
			}
			if (_tabControlType != TabControlType.Parchase)
			{
				if (_tabControlType == TabControlType.Social)
				{
					return GameController.Instance.Game.IngameState.IngameUi.SocialPannel.VisibleStashName;
				}
				if (_tabControlType == TabControlType.ExpeditionDealer)
				{
					return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.VisibleStashName;
				}
				return Class258_0?.Name;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IsVisible)
			{
				return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.VisibleStashName;
			}
			return GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.VisibleStashName;
		}
	}

	public bool IsOnFirstTab
	{
		get
		{
			if (CurrentTabIndex == 0)
			{
				return true;
			}
			if (_tabControlType != 0)
			{
				return false;
			}
			if (!LokiPoe.InGameState.StashUi.HideRemoveOnlyTabs)
			{
				return false;
			}
			IEnumerable<StashTabInfo> source = LokiPoe.InstanceInfo.StashTabs.Where((StashTabInfo x) => !x.IsHiddenFlagged);
			int i = CurrentTabIndex - 1;
			while (true)
			{
				if (i >= 0)
				{
					StashTabInfo stashTabInfo = source.FirstOrDefault((StashTabInfo x) => x.DisplayIndex == i);
					if (stashTabInfo != null && !stashTabInfo.IsRemoveOnlyFlagged)
					{
						break;
					}
					i--;
					continue;
				}
				return true;
			}
			return false;
		}
	}

	public bool IsOnLastTab
	{
		get
		{
			if (CurrentTabIndex == LastTabIndex)
			{
				return true;
			}
			if (_tabControlType != 0)
			{
				return false;
			}
			if (LokiPoe.InGameState.StashUi.HideRemoveOnlyTabs)
			{
				IEnumerable<StashTabInfo> source = LokiPoe.InstanceInfo.StashTabs.Where((StashTabInfo x) => !x.IsHiddenFlagged);
				int i = CurrentTabIndex + 1;
				while (true)
				{
					if (i <= LastTabIndex)
					{
						StashTabInfo stashTabInfo = source.FirstOrDefault((StashTabInfo x) => x.DisplayIndex == i);
						if (stashTabInfo != null && !stashTabInfo.IsRemoveOnlyFlagged)
						{
							break;
						}
						i++;
						continue;
					}
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public int LastTabIndex
	{
		get
		{
			if (_tabControlType == TabControlType.Stash)
			{
				return List_0.Count - 1;
			}
			if (_tabControlType == TabControlType.Parchase)
			{
				if (GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IsVisible)
				{
					return (int)GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.TotalStashes - 1;
				}
				return (int)GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.TotalStashes - 1;
			}
			if (_tabControlType != TabControlType.Social)
			{
				if (_tabControlType != TabControlType.ExpeditionDealer)
				{
					return List_0.Count - 1;
				}
				return (int)GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.TotalStashes - 1;
			}
			return (int)GameController.Instance.Game.IngameState.IngameUi.SocialPannel.TotalStashes - 1;
		}
	}

	public List<string> TabNames
	{
		get
		{
			if (_tabControlType == TabControlType.Stash)
			{
				return List_1.Select(Class259.Class9.method_1).ToList();
			}
			if (_tabControlType == TabControlType.Parchase)
			{
				if (GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IsVisible)
				{
					return GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.AllStashNames;
				}
				return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.AllStashNames;
			}
			if (_tabControlType != TabControlType.Social)
			{
				if (_tabControlType == TabControlType.ExpeditionDealer)
				{
					return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.AllStashNames;
				}
				return List_1.Select(Class259.Class9.method_1).ToList();
			}
			return GameController.Instance.Game.IngameState.IngameUi.SocialPannel.AllStashNames;
		}
	}

	public bool IsTabsMenuVisible
	{
		get
		{
			if (_tabControlType == TabControlType.Stash)
			{
				return GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerElement.IsVisible;
			}
			return false;
		}
	}

	internal byte Byte_0 => Struct111_0.byte_0;

	internal int Int32_0 => Struct111_0.int_1;

	internal byte Byte_1 => Struct111_0.byte_4;

	internal ClassTabData Class258_0 => GetTabDataByIndex(CurrentTabIndex);

	internal List<Struct110> List_0 => Containers.StdStructTab110Vector<Struct110>(Struct111_0.List_0);

	private List<ClassTabData> List_1 => List_0.Select(Class259.Class9.method_0).ToList();

	public Struct111 Struct111_0 => base.M.FastIntPtrToStruct<Struct111>(base.Address + 2408L);

	public TabControlWrapper(TabControlType type)
	{
		_tabControlType = type;
	}

	internal void SpecialSetMousePosition(Vector2i pos)
	{
		MouseManager.SetMousePosition(pos, useRandomPos: false);
	}

	internal TabControlWrapper(long control, TabControlType type)
		: base(control)
	{
		_tabControlType = type;
	}

	public bool IsTabVisible(string name)
	{
		if (_tabControlType == TabControlType.Stash)
		{
			return CurrentTabName == name;
		}
		if (_tabControlType != TabControlType.Parchase)
		{
			if (_tabControlType != TabControlType.Social)
			{
				if (_tabControlType != TabControlType.ExpeditionDealer)
				{
					return CurrentTabName == name;
				}
				return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.VisibleStashName == name;
			}
			return GameController.Instance.Game.IngameState.IngameUi.SocialPannel.VisibleStashName == name;
		}
		if (GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IsVisible)
		{
			return GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.VisibleStashName == name;
		}
		return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.VisibleStashName == name;
	}

	public bool IsTabVisible(int index)
	{
		if (_tabControlType == TabControlType.Stash)
		{
			return CurrentTabIndex == index;
		}
		if (_tabControlType == TabControlType.Parchase)
		{
			if (GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IsVisible)
			{
				return GameController.Instance.Game.IngameState.IngameUi.PurchasePanell.IndexVisibleStash == index;
			}
			return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.IndexVisibleStash == index;
		}
		if (_tabControlType == TabControlType.Social)
		{
			return GameController.Instance.Game.IngameState.IngameUi.SocialPannel.IndexVisibleStash == index;
		}
		if (_tabControlType != TabControlType.ExpeditionDealer)
		{
			return CurrentTabIndex == index;
		}
		return GameController.Instance.Game.IngameState.IngameUi.ExpeditionDealerPanell.IndexVisibleStash == index;
	}

	public SwitchToTabResult NextTabKeyboard()
	{
		if (_tabControlType == TabControlType.World)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (_tabControlType == TabControlType.Social)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (!Hooking.IsInstalled)
		{
			return SwitchToTabResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		int currentTabIndex = CurrentTabIndex;
		if (currentTabIndex != LastTabIndex)
		{
			LokiPoe.Input.SimulateKeyEvent(Keys.Right);
			Thread.Sleep(25);
			if (CurrentTabIndex == currentTabIndex)
			{
				return SwitchToTabResult.Failed;
			}
			return SwitchToTabResult.None;
		}
		return SwitchToTabResult.NoMoreTabs;
	}

	public SwitchToTabResult PreviousTabKeyboard()
	{
		if (_tabControlType == TabControlType.World)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (_tabControlType == TabControlType.Social)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (!Hooking.IsInstalled)
		{
			return SwitchToTabResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		int currentTabIndex = CurrentTabIndex;
		if (currentTabIndex != 0)
		{
			LokiPoe.Input.SimulateKeyEvent(Keys.Left);
			Thread.Sleep(25);
			if (CurrentTabIndex != currentTabIndex)
			{
				return SwitchToTabResult.None;
			}
			return SwitchToTabResult.Failed;
		}
		return SwitchToTabResult.NoMoreTabs;
	}

	public SwitchToTabResult SwitchToTabKeyboard(int index)
	{
		if (_tabControlType == TabControlType.World)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (_tabControlType == TabControlType.Social)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (index >= 0 && index <= LastTabIndex)
		{
			if (CurrentTabIndex < index)
			{
				while (CurrentTabIndex != index)
				{
					SwitchToTabResult switchToTabResult = NextTabKeyboard();
					Thread.Sleep(15);
					if (CurrentTabIndex != index)
					{
						if (switchToTabResult != 0)
						{
							return switchToTabResult;
						}
						continue;
					}
					return SwitchToTabResult.None;
				}
				return SwitchToTabResult.None;
			}
			SwitchToTabResult switchToTabResult2;
			do
			{
				if (CurrentTabIndex != index)
				{
					switchToTabResult2 = PreviousTabKeyboard();
					Thread.Sleep(15);
					if (CurrentTabIndex == index)
					{
						return SwitchToTabResult.None;
					}
					continue;
				}
				return SwitchToTabResult.None;
			}
			while (switchToTabResult2 == SwitchToTabResult.None);
			return switchToTabResult2;
		}
		return SwitchToTabResult.Failed;
	}

	public SwitchToTabResult SwitchToTabKeyboard(string name)
	{
		if (_tabControlType == TabControlType.World)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (_tabControlType == TabControlType.Social)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (!TabNames.Contains(name))
		{
			return SwitchToTabResult.Failed;
		}
		ClassTabData tabDataByName = GetTabDataByName(name);
		if (tabDataByName == null)
		{
			return SwitchToTabResult.TabNotFound;
		}
		int indexByTabData = GetIndexByTabData(tabDataByName);
		if (indexByTabData != -1)
		{
			if (CurrentTabIndex < indexByTabData)
			{
				while (true)
				{
					if (CurrentTabIndex != indexByTabData)
					{
						SwitchToTabResult switchToTabResult = NextTabKeyboard();
						Thread.Sleep(15);
						if (CurrentTabIndex == indexByTabData)
						{
							break;
						}
						if (switchToTabResult != 0)
						{
							return switchToTabResult;
						}
						continue;
					}
					return SwitchToTabResult.None;
				}
				return SwitchToTabResult.None;
			}
			while (true)
			{
				if (CurrentTabIndex != indexByTabData)
				{
					SwitchToTabResult switchToTabResult2 = PreviousTabKeyboard();
					Thread.Sleep(15);
					if (CurrentTabIndex == indexByTabData)
					{
						break;
					}
					if (switchToTabResult2 != 0)
					{
						return switchToTabResult2;
					}
					continue;
				}
				return SwitchToTabResult.None;
			}
			return SwitchToTabResult.None;
		}
		return SwitchToTabResult.TabNotFound;
	}

	public SwitchToTabResult SwitchToTabMouse(int index)
	{
		if (_tabControlType == TabControlType.World)
		{
			return SwitchToTabResult.NotSupported;
		}
		if (_tabControlType != TabControlType.Social)
		{
			if (Hooking.IsInstalled)
			{
				HookManager.ResetKeyState();
				ClassTabData tabDataByIndex = GetTabDataByIndex(index);
				if (tabDataByIndex == null)
				{
					return SwitchToTabResult.Failed;
				}
				return SwitchToTabMouse(tabDataByIndex.Name);
			}
			return SwitchToTabResult.ProcessHookManagerNotEnabled;
		}
		return SwitchToTabResult.NotSupported;
	}

	public SwitchToTabResult SwitchToTabMouse(string name)
	{
		if (_tabControlType != TabControlType.World)
		{
			if (_tabControlType != TabControlType.Social)
			{
				if (!Hooking.IsInstalled)
				{
					return SwitchToTabResult.ProcessHookManagerNotEnabled;
				}
				HookManager.ResetKeyState();
				if (TabNames.Contains(name))
				{
					int num = 0;
					while (GameController.Instance.Game.IngameState.IngameUi.StashPannel.IsTabListButtonVisible && !IsTabsMenuVisible)
					{
						Vector2i pos = GameController.Instance.Game.IngameState.IngameUi.StashPannel.TabListButton.CenterClickLocation();
						SpecialSetMousePosition(pos);
						Thread.Sleep(50);
						MouseManager.ClickLMB(pos.X, pos.Y);
						Thread.Sleep(50);
						if (IsTabsMenuVisible || num >= 3)
						{
							break;
						}
						num++;
					}
					Vector2i pos2;
					if (IsTabsMenuVisible)
					{
						Element element = GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightButtonContainer.FirstOrDefault((Element x) => !string.IsNullOrEmpty(x.Text) && x.Text == name);
						if (element == null)
						{
							return SwitchToTabResult.UnableToFindTabInScrollView;
						}
						int num2 = 0;
						while (true)
						{
							num2++;
							float num3 = element.Parent.Parent.Y + element.Parent.Parent.Height;
							if (num2 >= 50)
							{
								break;
							}
							if (num3 + GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerYOffset <= 0f)
							{
								MouseManager.SetMousePosition(LokiPoe.ElementClickLocation(GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerScrollUp));
								Thread.Sleep(5);
								MouseManager.ClickLMB();
								Thread.Sleep(5);
								continue;
							}
							if (!(num3 + GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerYOffset > GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerHeight))
							{
								break;
							}
							MouseManager.SetMousePosition(LokiPoe.ElementClickLocation(GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerScrollDown));
							Thread.Sleep(5);
							MouseManager.ClickLMB();
							Thread.Sleep(5);
						}
						pos2 = element.CenterClickLocation() + new Vector2i(0, (int)(GameController.Instance.Game.IngameState.IngameUi.StashPannel.RightTabsContainerYOffset * element.Scale));
					}
					else
					{
						Element element2 = GameController.Instance.Game.IngameState.IngameUi.StashPannel.UpperTabsContainer.FirstOrDefault((Element x) => !string.IsNullOrEmpty(x.Text) && x.Text == name);
						if (element2 == null)
						{
							return SwitchToTabResult.TabNotFound;
						}
						pos2 = element2.CenterClickLocation();
					}
					SpecialSetMousePosition(pos2);
					Thread.Sleep(10);
					MouseManager.ClickLMB(pos2.X, pos2.Y);
					Thread.Sleep(50);
					if (!(CurrentTabName == name))
					{
						return SwitchToTabResult.Failed;
					}
					return SwitchToTabResult.None;
				}
				return SwitchToTabResult.TabNotFound;
			}
			return SwitchToTabResult.NotSupported;
		}
		return SwitchToTabResult.NotSupported;
	}

	public OpenPremiumStashSettingResult OpenPremiumStashSetting(string name)
	{
		if (_tabControlType != TabControlType.World)
		{
			uint num = default(uint);
			int num3 = default(int);
			Element element = default(Element);
			Vector2i vector2i = default(Vector2i);
			while (true)
			{
				if (_tabControlType != TabControlType.Social)
				{
					while (true)
					{
						if (Hooking.IsInstalled)
						{
							while (true)
							{
								HookManager.ResetKeyState();
								if (TabNames.Contains(name))
								{
									while (true)
									{
										IL_0119:
										SwitchToTabResult switchToTabResult = SwitchToTabKeyboard(name);
										if (switchToTabResult != 0)
										{
											while (true)
											{
												switch (switchToTabResult)
												{
												case SwitchToTabResult.None:
													goto end_IL_00e6;
												case SwitchToTabResult.ProcessHookManagerNotEnabled:
													goto IL_024c;
												case SwitchToTabResult.Failed:
													goto IL_024e;
												case SwitchToTabResult.UiNotOpen:
													goto IL_0250;
												case SwitchToTabResult.TabListNotOpen:
													goto IL_0252;
												case SwitchToTabResult.TabNotFound:
													goto IL_0254;
												case SwitchToTabResult.FailedToOpenTabList:
													goto IL_0256;
												case SwitchToTabResult.UnableToFindTabInScrollView:
													goto IL_0258;
												case SwitchToTabResult.NoMoreTabs:
													goto IL_025b;
												case SwitchToTabResult.NotSupported:
													goto IL_025e;
												}
												int num2 = (int)((num * 1881146583) ^ 0x4BB61ABF);
												while (true)
												{
													switch ((num = (uint)num2 ^ 0x7667A961u) % 37u)
													{
													case 31u:
														num2 = ((int)num * -2124325103) ^ -1974029924;
														continue;
													case 28u:
														break;
													case 0u:
														goto IL_0119;
													case 16u:
														goto end_IL_0119;
													case 15u:
														goto end_IL_012b;
													case 13u:
														goto end_IL_0145;
													case 4u:
														goto IL_0159;
													case 23u:
													case 25u:
														goto end_IL_014e;
													case 26u:
														goto IL_015d;
													case 35u:
														goto IL_015f;
													case 7u:
														goto end_IL_00e6;
													case 32u:
														goto IL_0168;
													case 34u:
														goto IL_0174;
													case 12u:
														goto IL_0180;
													case 22u:
														goto IL_0182;
													case 36u:
														goto IL_0189;
													case 11u:
														goto IL_01b9;
													case 20u:
														goto IL_01c5;
													case 5u:
														goto IL_01cd;
													case 1u:
														goto IL_020a;
													case 18u:
														goto IL_0232;
													case 33u:
														goto IL_0236;
													case 29u:
														goto IL_023d;
													case 30u:
														goto IL_0244;
													case 27u:
														goto IL_0246;
													default:
														goto IL_0248;
													case 9u:
														goto IL_024a;
													case 24u:
														goto IL_024c;
													case 3u:
														goto IL_024e;
													case 10u:
														goto IL_0250;
													case 19u:
														goto IL_0252;
													case 8u:
														goto IL_0254;
													case 14u:
														goto IL_0256;
													case 2u:
														goto IL_0258;
													case 6u:
														goto IL_025b;
													case 21u:
														goto IL_025e;
													}
													break;
												}
												continue;
												IL_024e:
												return OpenPremiumStashSettingResult.Failed;
												IL_024c:
												return OpenPremiumStashSettingResult.ProcessHookManagerNotEnabled;
												IL_025e:
												return OpenPremiumStashSettingResult.NotSupported;
												IL_025b:
												return OpenPremiumStashSettingResult.NoMoreTabs;
												IL_0258:
												return OpenPremiumStashSettingResult.UnableToFindTabInScrollView;
												IL_0256:
												return OpenPremiumStashSettingResult.FailedToOpenTabList;
												IL_0254:
												return OpenPremiumStashSettingResult.TabNotFound;
												IL_0252:
												return OpenPremiumStashSettingResult.TabListNotOpen;
												IL_0250:
												return OpenPremiumStashSettingResult.UiNotOpen;
												continue;
												end_IL_00e6:
												break;
											}
										}
										Thread.Sleep(100);
										goto IL_0168;
										IL_024a:
										return OpenPremiumStashSettingResult.TabNotFound;
										IL_0248:
										return OpenPremiumStashSettingResult.None;
										IL_0168:
										if (LokiPoe.InGameState.StashUi.StashTabInfo.IsNormalTab)
										{
											goto IL_0174;
										}
										goto IL_0182;
										IL_0174:
										if (!LokiPoe.InGameState.StashUi.StashTabInfo.IsPremium)
										{
											goto IL_0180;
										}
										goto IL_0182;
										IL_0180:
										return OpenPremiumStashSettingResult.NotPremiumStash;
										IL_0182:
										num3 = 0;
										goto IL_0236;
										IL_0236:
										if (num3 <= 3)
										{
											goto IL_0189;
										}
										goto IL_023d;
										IL_023d:
										if (!LokiPoe.InGameState.PremiumStashSettingsUi.IsOpened)
										{
											goto IL_0244;
										}
										goto IL_0246;
										IL_0244:
										return OpenPremiumStashSettingResult.Failed;
										IL_0246:
										return OpenPremiumStashSettingResult.None;
										IL_0189:
										element = GameController.Instance.Game.IngameState.IngameUi.StashPannel.UpperTabsContainer.FirstOrDefault((Element x) => !string.IsNullOrEmpty(x.Text) && x.Text == name);
										goto IL_01b9;
										IL_01b9:
										if (!(element == null))
										{
											goto IL_01c5;
										}
										goto IL_024a;
										IL_01c5:
										vector2i = element.CenterClickLocation();
										goto IL_01cd;
										IL_01cd:
										Vector2i pos = new Vector2i(vector2i.X + (int)GameController.Instance.Game.IngameState.IngameUi.StashPannel.UpperTabContainerXOffset, vector2i.Y);
										SpecialSetMousePosition(pos);
										goto IL_020a;
										IL_020a:
										Thread.Sleep(100);
										MouseManager.ClickRMB(vector2i.X, vector2i.Y);
										Thread.Sleep(100);
										if (!LokiPoe.InGameState.PremiumStashSettingsUi.IsOpened)
										{
											goto IL_0232;
										}
										goto IL_0248;
										IL_0232:
										num3++;
										goto IL_0236;
										continue;
										end_IL_0119:
										break;
									}
									continue;
								}
								goto IL_0159;
								IL_0159:
								return OpenPremiumStashSettingResult.Failed;
								continue;
								end_IL_012b:
								break;
							}
							continue;
						}
						goto IL_015d;
						IL_015d:
						return OpenPremiumStashSettingResult.ProcessHookManagerNotEnabled;
						continue;
						end_IL_0145:
						break;
					}
					continue;
				}
				goto IL_015f;
				IL_015f:
				return OpenPremiumStashSettingResult.NotSupported;
				continue;
				end_IL_014e:
				break;
			}
		}
		return OpenPremiumStashSettingResult.NotSupported;
	}

	private bool IsRemoveOnly(InventoryTabFlags flag)
	{
		return (flag & InventoryTabFlags.RemoveOnly) == InventoryTabFlags.RemoveOnly;
	}

	private bool IsHidden(InventoryTabFlags flag)
	{
		return (flag & InventoryTabFlags.Hidden) == InventoryTabFlags.Hidden;
	}

	private int GetIndexByTabData(ClassTabData class258_0)
	{
		if (class258_0 == null)
		{
			return -1;
		}
		List<ClassTabData> list_ = List_1;
		for (int i = 0; i < list_.Count; i++)
		{
			if (list_[i].IntPtr_0 == class258_0.IntPtr_0 && list_[i].IntPtr_1 == class258_0.IntPtr_1 && list_[i].Name == class258_0.Name)
			{
				return i;
			}
		}
		return -1;
	}

	private ClassTabData GetTabDataByIndex(int index)
	{
		List<ClassTabData> list_ = List_1;
		if (index >= 0 && index < list_.Count)
		{
			return list_[index];
		}
		return null;
	}

	private ClassTabData GetTabDataByName(string name)
	{
		return List_1.FirstOrDefault((ClassTabData x) => x.Name.Equals(name));
	}
}
