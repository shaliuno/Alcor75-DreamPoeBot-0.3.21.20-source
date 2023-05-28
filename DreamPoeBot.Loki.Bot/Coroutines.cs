using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Coroutine;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using log4net;

namespace DreamPoeBot.Loki.Bot;

public static class Coroutines
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003CInteractWith_003Ed__23<T> : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public NetworkObject obj;

		public bool holdCtrl;

		private int _003Cid_003E5__2;

		private TaskAwaiter _003C_003Eu__1;

		private TaskAwaiter<int> _003C_003Eu__2;

		private void MoveNext()
		{
			int num = _003C_003E1__state;
			bool result;
			try
			{
				TaskAwaiter awaiter3;
				TaskAwaiter<int> awaiter2;
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (!object.Equals(obj, null))
					{
						_003Cid_003E5__2 = obj.Id;
						awaiter3 = smethod_1(FinishCurrentAction());
						if (!awaiter3.IsCompleted)
						{
							num = 0;
							_003C_003E1__state = 0;
							_003C_003Eu__1 = awaiter3;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter3, ref this);
							return;
						}
						goto IL_00af;
					}
					smethod_0(Log, global::_003CModule_003E.smethod_7<string>(2855718033u), Array.Empty<object>());
					result = false;
					goto end_IL_0007;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = -1;
					_003C_003E1__state = -1;
					goto IL_00af;
				case 1:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<int>);
					num = -1;
					_003C_003E1__state = -1;
					goto IL_01eb;
				case 2:
					{
						awaiter = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter);
						num = -1;
						_003C_003E1__state = -1;
						break;
					}
					IL_00af:
					awaiter3.GetResult();
					Log.InfoFormat(string.Format(global::_003CModule_003E.smethod_9<string>(3688566629u), _003Cid_003E5__2), Array.Empty<object>());
					if (LokiPoe.Input.HighlightObject(obj))
					{
						Log.InfoFormat(string.Format(global::_003CModule_003E.smethod_6<string>(1646259110u), _003Cid_003E5__2), Array.Empty<object>());
						if (holdCtrl)
						{
							LokiPoe.ProcessHookManager.SetKeyState(Keys.ControlKey, short.MinValue);
							Thread.Sleep(LokiPoe.Random.Next(25, 60));
						}
						Thread.Sleep(LokiPoe.Random.Next(25, 60));
						LokiPoe.ProcessHookManager.ReadCursorPos(out var x, out var y, out var _);
						MouseManager.ClickLMB(x, y);
						Thread.Sleep(LokiPoe.Random.Next(25, 60));
						awaiter2 = LatencyWait().GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = 1;
							_003C_003E1__state = 1;
							_003C_003Eu__2 = awaiter2;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
							return;
						}
						goto IL_01eb;
					}
					Log.ErrorFormat(global::_003CModule_003E.smethod_8<string>(3917021554u), Array.Empty<object>());
					result = false;
					goto end_IL_0007;
					IL_01eb:
					awaiter2.GetResult();
					awaiter = FinishCurrentAction(resetInput: false).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 2;
						_003C_003E1__state = 2;
						_003C_003Eu__1 = awaiter;
						_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					break;
				}
				awaiter.GetResult();
				HookManager.ResetKeyState();
				result = true;
				end_IL_0007:;
			}
			catch (Exception exception)
			{
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003C_003Et__builder.SetResult(result);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_003C_003Et__builder.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}

		static void smethod_0(ILog ilog_0, string string_0, object[] object_0)
		{
			ilog_0.ErrorFormat(string_0, object_0);
		}

		static TaskAwaiter smethod_1(Task task_0)
		{
			return task_0.GetAwaiter();
		}
	}

	private static int _reactionMaxSleepDelay = 300;

	private static int _reactionMinSleepDelay = 250;

	private static float _latencyFactor = 1.5f;

	private static int _finishCurrentActionTimeout = 5000;

	private static readonly ILog Log = Logger.GetLoggerInstanceForType();

	public static float LatencyFactor
	{
		get
		{
			return _latencyFactor;
		}
		set
		{
			_latencyFactor = value;
			if (_latencyFactor < 0f)
			{
				_latencyFactor = 0f;
			}
		}
	}

	public static int ReactionMaxSleepDelay
	{
		get
		{
			return _reactionMaxSleepDelay;
		}
		set
		{
			_reactionMaxSleepDelay = value;
			if (_reactionMaxSleepDelay <= _reactionMinSleepDelay)
			{
				_reactionMaxSleepDelay = _reactionMinSleepDelay + 1;
			}
			if (_reactionMaxSleepDelay < 101)
			{
				_reactionMaxSleepDelay = 101;
			}
		}
	}

	public static int ReactionMinSleepDelay
	{
		get
		{
			return _reactionMinSleepDelay;
		}
		set
		{
			_reactionMinSleepDelay = value;
			if (_reactionMinSleepDelay >= _reactionMaxSleepDelay)
			{
				_reactionMinSleepDelay = _reactionMaxSleepDelay - 1;
			}
			if (_reactionMinSleepDelay < 100)
			{
				_reactionMinSleepDelay = 100;
			}
		}
	}

	public static int FinishCurrentActionTimeout
	{
		get
		{
			return _finishCurrentActionTimeout;
		}
		set
		{
			_finishCurrentActionTimeout = value;
			if (_finishCurrentActionTimeout < 0)
			{
				_finishCurrentActionTimeout = 0;
			}
		}
	}

	public static async Task<int> LatencyWait()
	{
		int num = (int)((float)LatencyTracker.Average * LatencyFactor);
		if (num > 0)
		{
			await DreamPoeBot.Loki.Coroutine.Coroutine.Sleep(num);
		}
		return num;
	}

	public static async Task<int> LatencyWait(float factor)
	{
		int num = (int)((float)LatencyTracker.Average * factor);
		if (num > 0)
		{
			await DreamPoeBot.Loki.Coroutine.Coroutine.Sleep(num);
		}
		return num;
	}

	public static async Task<int> ReactionWait()
	{
		int num = LokiPoe.Random.Next(ReactionMinSleepDelay, ReactionMaxSleepDelay);
		if (num > 0)
		{
			await DreamPoeBot.Loki.Coroutine.Coroutine.Sleep(num);
		}
		return num;
	}

	public static async Task FinishCurrentAction(bool resetInput = true)
	{
		if (resetInput)
		{
			HookManager.ResetKeyState();
		}
		bool shouldLog = true;
		Stopwatch stopwatch = Stopwatch.StartNew();
		Stopwatch stopwatch2 = Stopwatch.StartNew();
		if (FinishCurrentActionTimeout > 1000)
		{
			FinishCurrentActionTimeout = LokiPoe.Random.Next(FinishCurrentActionTimeout - 500, FinishCurrentActionTimeout + 100);
		}
		while (true)
		{
			if (!LokiPoe.IsInGame)
			{
				return;
			}
			if (!object.Equals(LokiPoe.ObjectManager.Me, null))
			{
				if (!LokiPoe.ObjectManager.Me.HasCurrentAction)
				{
					return;
				}
				Skill skill = LokiPoe.ObjectManager.Me?.CurrentAction?.Skill;
				string text = ((!string.IsNullOrEmpty(skill?.Name)) ? skill.Name : "");
				if (string.IsNullOrEmpty(text))
				{
					return;
				}
				if (shouldLog || stopwatch.ElapsedMilliseconds >= 100L)
				{
					Log.DebugFormat(global::_003CModule_003E.smethod_5<string>(3848386054u), (object)text, (object)stopwatch2.ElapsedMilliseconds, (object)resetInput);
					stopwatch.Restart();
					shouldLog = false;
				}
				await DreamPoeBot.Loki.Coroutine.Coroutine.Yield();
				if (LokiPoe.ObjectManager.Me.IsDead)
				{
					break;
				}
				if (stopwatch2.ElapsedMilliseconds >= FinishCurrentActionTimeout)
				{
					Log.DebugFormat(global::_003CModule_003E.smethod_6<string>(1746696878u), (object)stopwatch2.ElapsedMilliseconds, (object)resetInput);
					return;
				}
			}
		}
		Log.DebugFormat(global::_003CModule_003E.smethod_9<string>(4199417218u), (object)resetInput);
	}

	public static async Task CloseBlockingWindows()
	{
		while (true)
		{
			bool shouldRepeat = false;
			while (GameStateController.IsEscapeState)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_5<string>(4179914374u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await DreamPoeBot.Loki.Coroutine.Coroutine.Sleep(16);
			}
			if (shouldRepeat)
			{
				continue;
			}
			if (LokiPoe.InGameState.GlobalWarningDialog.IsBetrayalLeaveZoneWarningOverlayOpen)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_6<string>(3244360458u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.InGameState.GlobalWarningDialog.ConfirmDialog();
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.ShopUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_9<string>(2579024569u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await DreamPoeBot.Loki.Coroutine.Coroutine.Sleep(16);
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.InstanceManagerUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_7<string>(1449406655u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await DreamPoeBot.Loki.Coroutine.Coroutine.Sleep(16);
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.GlobalWarningDialog.IsPassiveTreeWarningOverlayOpen)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_9<string>(3620779364u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await DreamPoeBot.Loki.Coroutine.Coroutine.Sleep(16);
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.GlobalWarningDialog.IsPassiveWarningOverlayOpen)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_7<string>(2129917804u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await DreamPoeBot.Loki.Coroutine.Coroutine.Sleep(16);
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.GlobalWarningDialog.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_7<string>(1260150793u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await DreamPoeBot.Loki.Coroutine.Coroutine.Sleep(16);
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InstanceInfo.DialogDepth > 0)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_9<string>(4151683570u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.IsLeftPanelShown || LokiPoe.InGameState.IsRightPanelShown)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_7<string>(1354778724u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await DreamPoeBot.Loki.Coroutine.Coroutine.Sleep(16);
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.SkillsUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_8<string>(2236493748u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.AtlasUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_6<string>(3564105999u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.IsTopMostOverlayActive)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_8<string>(423485159u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await DreamPoeBot.Loki.Coroutine.Coroutine.Sleep(16);
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.TutorialUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_7<string>(2995155907u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.HelpUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_7<string>(3094312746u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.ProphecyPopupUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_9<string>(1099949114u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.InGameState.ProphecyPopupUi.Dismiss();
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.ShopUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_7<string>(1805273839u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.TempleOfAtzoatlUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_5<string>(14037037u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.SyndicateUI.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_7<string>(2026232057u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.AscendancyUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_5<string>(986248313u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.HideoutSelectionUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_6<string>(906330260u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.MetamorphUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_8<string>(1439568443u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.PantheonUI.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_7<string>(2742974470u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.RitualFavorsUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_6<string>(1004542293u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.ProphecyUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_5<string>(3441018392u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.UnveilingUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_9<string>(1040730138u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.BloodCrucibleUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_7<string>(2066992229u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.ArchnemesisInventoryUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_9<string>(3453665889u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.ArchnemesisEncounterUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_8<string>(2501778559u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.ExpeditionLockerUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_5<string>(2253313708u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.AtlasSkillsUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_9<string>(1753058772u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.DelveSubterrainChartUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_5<string>(421404699u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.MirroredTabletUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_9<string>(2620073678u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.SentinelLockerUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_6<string>(1573156519u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.MicrotansactionShopPannelUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_5<string>(1933594965u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (shouldRepeat)
			{
				continue;
			}
			while (LokiPoe.InGameState.KiracMissionsUi.IsOpened)
			{
				Log.InfoFormat(global::_003CModule_003E.smethod_9<string>(3325717773u), Array.Empty<object>());
				shouldRepeat = true;
				LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
				await LatencyWait();
				await ReactionWait();
			}
			if (!shouldRepeat)
			{
				while (LokiPoe.InGameState.CraftingBenchPannelUi.IsOpened)
				{
					Log.InfoFormat(global::_003CModule_003E.smethod_7<string>(2477206309u), Array.Empty<object>());
					shouldRepeat = true;
					LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.close_panels_combo.Key, down: true, @char: false, up: false, LokiPoe.Input.Binding.close_panels_combo.Modifier);
					await LatencyWait();
					await ReactionWait();
				}
				if (!shouldRepeat)
				{
					break;
				}
			}
		}
	}

	public static async Task<bool> InteractWith(NetworkObject obj, bool holdCtrl = false)
	{
		return await InteractWith<NetworkObject>(obj, holdCtrl);
	}

	public static async Task<bool> InteractWith<T>(NetworkObject obj, bool holdCtrl = false)
	{
		if (!object.Equals(obj, null))
		{
			int id = obj.Id;
			TaskAwaiter taskAwaiter = _003CInteractWith_003Ed__23<T>.smethod_1(FinishCurrentAction());
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter taskAwaiter2 = default(TaskAwaiter);
				taskAwaiter = taskAwaiter2;
			}
			taskAwaiter.GetResult();
			Log.InfoFormat(string.Format(global::_003CModule_003E.smethod_9<string>(3688566629u), id), Array.Empty<object>());
			if (!LokiPoe.Input.HighlightObject(obj))
			{
				Log.ErrorFormat(global::_003CModule_003E.smethod_8<string>(3917021554u), Array.Empty<object>());
				return false;
			}
			Log.InfoFormat(string.Format(global::_003CModule_003E.smethod_6<string>(1646259110u), id), Array.Empty<object>());
			if (holdCtrl)
			{
				LokiPoe.ProcessHookManager.SetKeyState(Keys.ControlKey, short.MinValue);
				Thread.Sleep(LokiPoe.Random.Next(25, 60));
			}
			Thread.Sleep(LokiPoe.Random.Next(25, 60));
			LokiPoe.ProcessHookManager.ReadCursorPos(out var x, out var y, out var _);
			MouseManager.ClickLMB(x, y);
			Thread.Sleep(LokiPoe.Random.Next(25, 60));
			await LatencyWait();
			await FinishCurrentAction(resetInput: false);
			HookManager.ResetKeyState();
			return true;
		}
		_003CInteractWith_003Ed__23<T>.smethod_0(Log, global::_003CModule_003E.smethod_7<string>(2855718033u), Array.Empty<object>());
		return false;
	}
}
