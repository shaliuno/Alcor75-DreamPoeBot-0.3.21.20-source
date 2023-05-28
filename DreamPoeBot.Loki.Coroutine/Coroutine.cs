using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace DreamPoeBot.Loki.Coroutine;

public sealed class Coroutine : IDisposable
{
	private class Class66 : INotifyCompletion
	{
		public bool Boolean_0 { get; set; }

		public bool Boolean_1 => false;

		public Class66 method_0()
		{
			return this;
		}

		public void method_1()
		{
			if (Boolean_0)
			{
				throw smethod_1();
			}
		}

		public void OnCompleted(Action continuation)
		{
			Current.action_0 = continuation;
		}
	}

	private sealed class Class67
	{
		public Func<Task<object>> func_0;

		public Coroutine coroutine_0;

		internal void method_0()
		{
			Task<object> task;
			try
			{
				task = func_0();
			}
			catch (Exception innerException)
			{
				throw coroutine_0.method_1(new CoroutineUnhandledException(global::_003CModule_003E.smethod_5<string>(1992642850u), innerException));
			}
			if (task == null)
			{
				throw coroutine_0.method_1(new CoroutineBehaviorException(global::_003CModule_003E.smethod_5<string>(2540910048u)));
			}
			coroutine_0.task_0 = task;
		}
	}

	private struct Struct15 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		private object object_0;

		void IAsyncStateMachine.MoveNext()
		{
			int num = int_0;
			try
			{
				Class66 awaiter;
				if (num == 0)
				{
					awaiter = (Class66)object_0;
					object_0 = null;
					num = -1;
					int_0 = -1;
				}
				else
				{
					awaiter = Current.class66_0.method_0();
					if (!awaiter.Boolean_1)
					{
						num = 0;
						int_0 = 0;
						object_0 = awaiter;
						asyncTaskMethodBuilder_0.AwaitOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				awaiter.method_1();
				awaiter = null;
			}
			catch (Exception ex)
			{
				Exception exception = ex;
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncTaskMethodBuilder_0.SetResult();
		}

		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}
	}

	private struct Struct16 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		public TimeSpan timeSpan_0;

		private Stopwatch stopwatch_0;

		private object object_0;

		void IAsyncStateMachine.MoveNext()
		{
			int num = int_0;
			Class66 awaiter;
			if (num == 0)
			{
				awaiter = (Class66)object_0;
				object_0 = null;
				int_0 = -1;
				goto IL_005b;
			}
			if (num == 1)
			{
				awaiter = (Class66)object_0;
				object_0 = null;
				int_0 = -1;
				goto IL_00bf;
			}
			if (!(timeSpan_0 != Timeout.InfiniteTimeSpan))
			{
				goto IL_007c;
			}
			stopwatch_0 = Stopwatch.StartNew();
			goto IL_00dd;
			IL_007c:
			awaiter = Current.class66_0.method_0();
			if (!awaiter.Boolean_1)
			{
				int_0 = 0;
				object_0 = awaiter;
				asyncTaskMethodBuilder_0.AwaitOnCompleted(ref awaiter, ref this);
				return;
			}
			goto IL_005b;
			IL_00bf:
			awaiter.method_1();
			if (stopwatch_0.Elapsed >= timeSpan_0)
			{
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetResult();
				return;
			}
			goto IL_00dd;
			IL_005b:
			try
			{
				awaiter.method_1();
			}
			catch (Exception ex)
			{
				Exception exception = ex;
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			goto IL_007c;
			IL_00dd:
			awaiter = Current.class66_0.method_0();
			if (!awaiter.Boolean_1)
			{
				int_0 = 1;
				object_0 = awaiter;
				asyncTaskMethodBuilder_0.AwaitOnCompleted(ref awaiter, ref this);
				return;
			}
			goto IL_00bf;
		}

		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}
	}

	private struct Struct17 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder_0;

		public TimeSpan timeSpan_0;

		public Func<bool> func_0;

		private Stopwatch stopwatch_0;

		private object object_0;

		void IAsyncStateMachine.MoveNext()
		{
			bool flag = false;
			int num = int_0;
			Class66 awaiter;
			if (num != 0)
			{
				if (num != 1)
				{
					if (!(timeSpan_0 != TimeSpan.Zero))
					{
						flag = func_0();
						int_0 = -2;
						asyncTaskMethodBuilder_0.SetResult(flag);
						return;
					}
					if (!(timeSpan_0 == Timeout.InfiniteTimeSpan))
					{
						stopwatch_0 = Stopwatch.StartNew();
						goto IL_0086;
					}
					goto IL_0174;
				}
				awaiter = (Class66)object_0;
				object_0 = null;
				num = -1;
				int_0 = -1;
				goto IL_00ab;
			}
			awaiter = (Class66)object_0;
			object_0 = null;
			num = -1;
			int_0 = -1;
			goto IL_0135;
			IL_0174:
			if (!func_0())
			{
				awaiter = Current.class66_0.method_0();
				if (!awaiter.Boolean_1)
				{
					num = 0;
					int_0 = 0;
					object_0 = awaiter;
					asyncTaskMethodBuilder_0.AwaitOnCompleted(ref awaiter, ref this);
					return;
				}
				goto IL_0135;
			}
			flag = true;
			int_0 = -2;
			asyncTaskMethodBuilder_0.SetResult(result: true);
			return;
			IL_00ab:
			awaiter.method_1();
			awaiter = null;
			if (stopwatch_0.Elapsed >= timeSpan_0)
			{
				flag = false;
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetResult(result: false);
				return;
			}
			goto IL_0086;
			IL_0086:
			if (!func_0())
			{
				awaiter = Current.class66_0.method_0();
				if (!awaiter.Boolean_1)
				{
					num = 1;
					int_0 = 1;
					object_0 = awaiter;
					asyncTaskMethodBuilder_0.AwaitOnCompleted(ref awaiter, ref this);
					return;
				}
				goto IL_00ab;
			}
			flag = true;
			int_0 = -2;
			asyncTaskMethodBuilder_0.SetResult(result: true);
			return;
			IL_0135:
			try
			{
				awaiter.method_1();
				awaiter = null;
			}
			catch (Exception ex)
			{
				Exception exception = ex;
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			goto IL_0174;
		}

		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}
	}

	private readonly Class66 class66_0 = new Class66();

	private Task<object> task_0;

	private Action action_0;

	[ThreadStatic]
	private static Coroutine coroutine_0;

	public static Coroutine Current => coroutine_0;

	public CoroutineException FaultingException { get; private set; }

	public bool IsDisposed { get; private set; }

	public bool IsFinished
	{
		get
		{
			if (Status != CoroutineStatus.RanToCompletion && Status != CoroutineStatus.Faulted)
			{
				return Status == CoroutineStatus.Stopped;
			}
			return true;
		}
	}

	public object Result { get; private set; }

	public CoroutineStatus Status { get; private set; }

	public int Ticks { get; private set; }

	public Coroutine(Func<Task> taskProducer)
		: this(smethod_0(taskProducer))
	{
	}

	public Coroutine(Func<Task<object>> taskProducer)
	{
		Coroutine coroutine = this;
		if (taskProducer == null)
		{
			throw new ArgumentNullException(global::_003CModule_003E.smethod_6<string>(3771032383u));
		}
		action_0 = delegate
		{
			Task<object> task;
			try
			{
				task = taskProducer();
			}
			catch (Exception innerException)
			{
				throw coroutine.method_1(new CoroutineUnhandledException(global::_003CModule_003E.smethod_7<string>(1069240845u), innerException));
			}
			if (task == null)
			{
				throw coroutine.method_1(new CoroutineBehaviorException(global::_003CModule_003E.smethod_8<string>(1673637327u)));
			}
			coroutine.task_0 = task;
		};
		Status = CoroutineStatus.Runnable;
	}

	public void Dispose()
	{
		if (IsDisposed)
		{
			return;
		}
		if (Current != this)
		{
			if (Status == CoroutineStatus.Runnable)
			{
				if (task_0 != null)
				{
					class66_0.Boolean_0 = true;
					method_0(bool_1: true);
				}
				else
				{
					action_0 = null;
				}
			}
			IsDisposed = true;
			return;
		}
		IsDisposed = true;
		throw smethod_1();
	}

	public static Task ExternalTask(Func<Task> taskProducer)
	{
		if (taskProducer == null)
		{
			throw new ArgumentNullException(global::_003CModule_003E.smethod_6<string>(3771032383u));
		}
		Task task = taskProducer();
		if (task == null)
		{
			throw new ArgumentException(global::_003CModule_003E.smethod_5<string>(1576986980u), global::_003CModule_003E.smethod_7<string>(456184179u));
		}
		return ExternalTask(task);
	}

	public static Task ExternalTask(Task externalTask)
	{
		return smethod_6(externalTask, Timeout.InfiniteTimeSpan);
	}

	[Obsolete("Timeouts should be handled in the external task, not by this method. Use the overloads with infinite timeouts instead.")]
	public static Task<bool> ExternalTask(Task externalTask, TimeSpan timeout)
	{
		return smethod_6(externalTask, timeout);
	}

	[Obsolete("Timeouts should be handled in the external task, not by this method. Use the overloads with infinite timeouts instead.")]
	public static Task<bool> ExternalTask(Task externalTask, int millisecondsTimeout)
	{
		if (millisecondsTimeout != -1 && millisecondsTimeout < 0)
		{
			throw new ArgumentOutOfRangeException(global::_003CModule_003E.smethod_7<string>(2110148086u), global::_003CModule_003E.smethod_5<string>(1282132861u));
		}
		return smethod_6(externalTask, new TimeSpan(0, 0, 0, 0, millisecondsTimeout));
	}

	public static Task<T> ExternalTask<T>(Func<Task<T>> taskProducer)
	{
		if (taskProducer == null)
		{
			throw new ArgumentNullException(global::_003CModule_003E.smethod_7<string>(456184179u));
		}
		Task<T> task = taskProducer();
		if (task == null)
		{
			throw new ArgumentException(global::_003CModule_003E.smethod_8<string>(2064109091u), global::_003CModule_003E.smethod_8<string>(367276263u));
		}
		return ExternalTask(task);
	}

	public static Task<T> ExternalTask<T>(Task<T> externalTask)
	{
		return smethod_8(smethod_9(externalTask, Timeout.InfiniteTimeSpan));
	}

	[Obsolete("Timeouts should be handled in the external task, not by this method. Use the overloads with infinite timeouts instead.")]
	public static Task<ExternalTaskWaitResult<T>> ExternalTask<T>(Task<T> externalTask, int millisecondsTimeout)
	{
		if (millisecondsTimeout < 0 && millisecondsTimeout != -1)
		{
			throw new ArgumentOutOfRangeException(global::_003CModule_003E.smethod_9<string>(2148479862u), global::_003CModule_003E.smethod_5<string>(1282132861u));
		}
		return smethod_9(externalTask, new TimeSpan(0, 0, 0, 0, millisecondsTimeout));
	}

	[Obsolete("Timeouts should be handled in the external taks, not by this method. Use the overloads with infinite timeouts instead.")]
	public static Task<ExternalTaskWaitResult<T>> ExternalTask<T>(Task<T> externalTask, TimeSpan timeout)
	{
		return smethod_9(externalTask, timeout);
	}

	public void Resume()
	{
		if (IsDisposed)
		{
			throw new ObjectDisposedException(GetType().FullName);
		}
		if (!IsFinished)
		{
			if (coroutine_0 == this)
			{
				throw new InvalidOperationException(global::_003CModule_003E.smethod_6<string>(3099754654u));
			}
			method_0(bool_1: false);
			return;
		}
		throw new InvalidOperationException(global::_003CModule_003E.smethod_6<string>(494423534u));
	}

	private void method_0(bool bool_1)
	{
		SynchronizationContext current = SynchronizationContext.Current;
		Coroutine coroutine = coroutine_0;
		try
		{
			coroutine_0 = this;
			SynchronizationContext.SetSynchronizationContext(null);
			Action action = action_0;
			action_0 = null;
			action();
			if (!bool_1)
			{
				Ticks++;
			}
			method_2(bool_1);
		}
		finally
		{
			coroutine_0 = coroutine;
			SynchronizationContext.SetSynchronizationContext(current);
		}
	}

	private void method_2(bool bool_1)
	{
		switch (task_0.Status)
		{
		default:
			throw method_1(new CoroutineBehaviorException(global::_003CModule_003E.smethod_8<string>(2428941396u) + task_0.Status));
		case TaskStatus.WaitingForActivation:
			if (bool_1)
			{
				throw method_1(new CoroutineBehaviorException(global::_003CModule_003E.smethod_7<string>(2804245959u)));
			}
			if (action_0 == null)
			{
				throw method_1(new CoroutineBehaviorException(global::_003CModule_003E.smethod_7<string>(2605932281u)));
			}
			break;
		case TaskStatus.WaitingToRun:
		case TaskStatus.Running:
		case TaskStatus.WaitingForChildrenToComplete:
			throw method_1(new CoroutineBehaviorException(global::_003CModule_003E.smethod_6<string>(1088147202u) + task_0.Status));
		case TaskStatus.RanToCompletion:
			if (action_0 != null)
			{
				throw method_1(new CoroutineBehaviorException(global::_003CModule_003E.smethod_8<string>(1487412637u)));
			}
			Status = CoroutineStatus.RanToCompletion;
			Result = task_0.Result;
			break;
		case TaskStatus.Canceled:
			try
			{
				task_0.Wait(0);
				throw method_1(new CoroutineBehaviorException(global::_003CModule_003E.smethod_9<string>(1091472239u)));
			}
			catch (Exception innerException)
			{
				throw method_1(new CoroutineUnhandledException(global::_003CModule_003E.smethod_8<string>(943649472u), innerException));
			}
		case TaskStatus.Faulted:
		{
			Exception ex = task_0.Exception.InnerExceptions.FirstOrDefault();
			if (!(ex is CoroutineStoppedException))
			{
				throw method_1(new CoroutineUnhandledException(global::_003CModule_003E.smethod_5<string>(1265556445u), ex));
			}
			Status = CoroutineStatus.Stopped;
			break;
		}
		}
	}

	private Exception method_1(CoroutineException coroutineException_1)
	{
		Status = CoroutineStatus.Faulted;
		FaultingException = coroutineException_1;
		return coroutineException_1;
	}

	public static Task Sleep(TimeSpan timeout)
	{
		if (timeout < TimeSpan.Zero && timeout != Timeout.InfiniteTimeSpan)
		{
			throw new ArgumentOutOfRangeException(global::_003CModule_003E.smethod_9<string>(399197222u));
		}
		smethod_2();
		return smethod_4(timeout);
	}

	public static Task Sleep(int milliseconds)
	{
		if (milliseconds < 0 && milliseconds != -1)
		{
			throw new ArgumentOutOfRangeException(global::_003CModule_003E.smethod_5<string>(472164376u));
		}
		return Sleep(new TimeSpan(0, 0, 0, 0, milliseconds));
	}

	private static Func<Task<object>> smethod_0(Func<Task> func_0)
	{
		return async delegate
		{
			await func_0();
			return null;
		};
	}

	internal static Exception smethod_1()
	{
		return new CoroutineStoppedException(global::_003CModule_003E.smethod_7<string>(4016772567u));
	}

	private static async Task<ExternalTaskWaitResult<T>> smethod_10<T>(Task<T> task_1, TimeSpan timeSpan_0)
	{
		return (!(await smethod_7(task_1, timeSpan_0))) ? ExternalTaskWaitResult<T>.externalTaskWaitResult_0 : ExternalTaskWaitResult<T>.smethod_0(task_1.Result);
	}

	private static async Task smethod_4(TimeSpan timeSpan_0)
	{
		Struct16 stateMachine = default(Struct16);
		stateMachine.timeSpan_0 = timeSpan_0;
		stateMachine.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder.Create();
		stateMachine.int_0 = -1;
		stateMachine.asyncTaskMethodBuilder_0.Start(ref stateMachine);
		await stateMachine.asyncTaskMethodBuilder_0.Task;
	}

	private static async Task<bool> smethod_5(TimeSpan timeSpan_0, Func<bool> func_0)
	{
		Struct17 stateMachine = default(Struct17);
		stateMachine.timeSpan_0 = timeSpan_0;
		stateMachine.func_0 = func_0;
		stateMachine.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder<bool>.Create();
		stateMachine.int_0 = -1;
		stateMachine.asyncTaskMethodBuilder_0.Start(ref stateMachine);
		return await stateMachine.asyncTaskMethodBuilder_0.Task;
	}

	private static Task<bool> smethod_6(Task task_1, TimeSpan timeSpan_0)
	{
		if (task_1 == null)
		{
			throw new ArgumentNullException(global::_003CModule_003E.smethod_7<string>(3913086820u));
		}
		if (timeSpan_0 < TimeSpan.Zero && timeSpan_0 != Timeout.InfiniteTimeSpan)
		{
			throw new ArgumentOutOfRangeException(global::_003CModule_003E.smethod_6<string>(4140996808u));
		}
		smethod_2();
		return smethod_7(task_1, timeSpan_0);
	}

	private static async Task<bool> smethod_7(Task task, TimeSpan timeSpan)
	{
		bool result;
		if (timeSpan == TimeSpan.Zero)
		{
			result = Awaiter.Await(task, 0);
		}
		else if (!(timeSpan == Timeout.InfiniteTimeSpan))
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			while (Awaiter.Await(task, 0))
			{
				if (!(stopwatch.Elapsed < timeSpan))
				{
					return false;
				}
				await Current.task_0;
			}
			result = true;
		}
		else
		{
			while (Awaiter.Await(task, 0))
			{
				await Current.task_0;
			}
			result = true;
		}
		return result;
	}

	private static async Task<T> smethod_8<T>(Task<ExternalTaskWaitResult<T>> task_1)
	{
		return (await task_1).Result;
	}

	private static Task<ExternalTaskWaitResult<T>> smethod_9<T>(Task<T> task_1, TimeSpan timeSpan_0)
	{
		if (task_1 == null)
		{
			throw new ArgumentNullException(global::_003CModule_003E.smethod_9<string>(2301282384u));
		}
		if (timeSpan_0 < TimeSpan.Zero && timeSpan_0 != Timeout.InfiniteTimeSpan)
		{
			throw new ArgumentOutOfRangeException(global::_003CModule_003E.smethod_7<string>(1380298086u), global::_003CModule_003E.smethod_8<string>(1918111520u));
		}
		smethod_2();
		return smethod_10(task_1, timeSpan_0);
	}

	public override string ToString()
	{
		CoroutineStatus status = Status;
		uint num = default(uint);
		while (true)
		{
			switch (status)
			{
			default:
			{
				int num2 = ((int)num * -1968381766) ^ -1715125386;
				while (true)
				{
					switch ((num = (uint)num2 ^ 0x18176A23u) % 12u)
					{
					case 9u:
						num2 = ((int)num * -523864218) ^ 0x1B4D89D4;
						continue;
					case 4u:
					case 8u:
						break;
					default:
						return global::_003CModule_003E.smethod_6<string>(1706980312u);
					case 11u:
						goto IL_008a;
					case 7u:
						goto IL_0095;
					case 2u:
						goto IL_009d;
					case 6u:
						goto IL_00b3;
					case 0u:
						goto IL_00be;
					case 3u:
						goto IL_00c9;
					case 1u:
						goto IL_00d1;
					case 10u:
						goto end_IL_0068;
					}
					break;
				}
				continue;
			}
			case CoroutineStatus.Runnable:
				goto IL_008a;
			case CoroutineStatus.RanToCompletion:
				goto IL_0095;
			case CoroutineStatus.Stopped:
				goto IL_00be;
			case CoroutineStatus.Faulted:
				goto IL_00c9;
				IL_008a:
				return global::_003CModule_003E.smethod_5<string>(177310257u);
				IL_00c9:
				if (FaultingException != null)
				{
					break;
				}
				goto IL_00d1;
				IL_00d1:
				return global::_003CModule_003E.smethod_5<string>(1257268237u);
				IL_00be:
				return global::_003CModule_003E.smethod_5<string>(455587960u);
				IL_0095:
				if (Result != null)
				{
					goto IL_009d;
				}
				goto IL_00b3;
				IL_009d:
				return global::_003CModule_003E.smethod_6<string>(864387959u) + Result;
				IL_00b3:
				return global::_003CModule_003E.smethod_6<string>(2006067881u);
				end_IL_0068:
				break;
			}
			break;
		}
		return global::_003CModule_003E.smethod_5<string>(904396662u) + FaultingException.InnerException.GetType();
	}

	public static Task<bool> Wait(TimeSpan maxWaitTimeout, Func<bool> condition)
	{
		if (maxWaitTimeout < TimeSpan.Zero && maxWaitTimeout != Timeout.InfiniteTimeSpan)
		{
			throw new ArgumentOutOfRangeException(global::_003CModule_003E.smethod_5<string>(4119405978u), global::_003CModule_003E.smethod_7<string>(3507401648u));
		}
		if (condition == null)
		{
			throw new ArgumentNullException(global::_003CModule_003E.smethod_7<string>(2141850442u));
		}
		smethod_2();
		return smethod_5(maxWaitTimeout, condition);
	}

	public static Task<bool> Wait(int maxWaitMs, Func<bool> condition)
	{
		if (maxWaitMs < 0 && maxWaitMs != -1)
		{
			throw new ArgumentOutOfRangeException(global::_003CModule_003E.smethod_9<string>(762046078u), global::_003CModule_003E.smethod_5<string>(3841128275u));
		}
		return Wait(new TimeSpan(0, 0, 0, 0, maxWaitMs), condition);
	}

	public static Task Yield()
	{
		smethod_2();
		return smethod_3();
	}

	private static void smethod_2()
	{
		if (coroutine_0 == null)
		{
			throw new InvalidOperationException(global::_003CModule_003E.smethod_9<string>(3867256846u));
		}
		if (coroutine_0.action_0 != null)
		{
			throw new InvalidOperationException(global::_003CModule_003E.smethod_9<string>(1286265745u));
		}
	}

	private static async Task smethod_3()
	{
		Struct15 stateMachine = default(Struct15);
		stateMachine.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder.Create();
		stateMachine.int_0 = -1;
		stateMachine.asyncTaskMethodBuilder_0.Start(ref stateMachine);
		await stateMachine.asyncTaskMethodBuilder_0.Task;
	}
}
