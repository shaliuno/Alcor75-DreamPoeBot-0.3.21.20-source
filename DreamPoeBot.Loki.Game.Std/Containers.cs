using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Elements;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.NativeWrappers;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game.Std;

public static class Containers
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct NativeListInt_LongNode
	{
		public readonly long Next;

		private readonly long Prev;

		public readonly ushort IntValue;

		private readonly ushort UnusedShort_1;

		private readonly ushort UnusedShort_2;

		private readonly ushort UnusedShort_3;

		public readonly long LongValue;
	}

	internal struct NativeListLong_LongNode
	{
		public readonly long Next;

		public readonly long Prev;

		public readonly long LongKey;

		public readonly long LongValue;
	}

	internal struct NativeListStruct243_LongNode
	{
		public readonly long Next;

		public readonly long Prev;

		public readonly Struct243 Struct243;

		public readonly long LongValue;
	}

	internal struct NativeListLong_Struct37Node
	{
		public readonly long Next;

		public readonly long Prev;

		public readonly long LongKey;

		public readonly LokiPoe.InstanceInfo.Struct37 Struct37Value;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct NativeStringWCustom_intNode
	{
		public readonly long Next;

		public readonly long Prev;

		public readonly NativeStringWCustom stringValue;

		public readonly int intValue;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct NativeStruct60Node
	{
		public readonly long Next;

		public readonly long Prev;

		public readonly LokiPoe.InGameState.ChatPanel.Struct60 StructValue;
	}

	[Serializable]
	private sealed class Class264<T, U>
	{
		public static readonly Class264<T, U> func9 = new Class264<T, U>();

		public static Func<KeyValuePair<T, U>, T> func9__5_0;

		public static Func<KeyValuePair<T, U>, U> func9__5_1;

		internal T method_0(KeyValuePair<T, U> keyValuePair_0)
		{
			return keyValuePair_0.Key;
		}

		internal U method_1(KeyValuePair<T, U> keyValuePair_0)
		{
			return keyValuePair_0.Value;
		}
	}

	private static int _stashTabInfoStruct277Size = -1;

	private static int _nativeStruct60NodeSize = -1;

	private static int StashTabInfoStruct277Size
	{
		get
		{
			if (_stashTabInfoStruct277Size == -1)
			{
				_stashTabInfoStruct277Size = DreamPoeBot.Loki.MarshalCache<StashTabInfo.StashTabInfoStruct277>.Size;
			}
			return _stashTabInfoStruct277Size;
		}
	}

	private static int NativeStruct60NodeSize
	{
		get
		{
			if (_nativeStruct60NodeSize == -1)
			{
				_nativeStruct60NodeSize = MarshalCache<NativeStruct60Node>.Size;
			}
			return _nativeStruct60NodeSize;
		}
	}

	internal static Dictionary<long, List<LokiPoe.InstanceInfo.Struct37>> StdMultiHashMapLongListStruct37<TKey, TValue>(NativeHashMap nativeHashMap, Memory m = null)
	{
		Dictionary<long, List<LokiPoe.InstanceInfo.Struct37>> dictionary = new Dictionary<long, List<LokiPoe.InstanceInfo.Struct37>>();
		foreach (KeyValuePair<long, LokiPoe.InstanceInfo.Struct37> item in StdLong_Struct37List<KeyValuePair<long, LokiPoe.InstanceInfo.Struct37>>(nativeHashMap.List, m))
		{
			if (!dictionary.TryGetValue(item.Key, out var value))
			{
				value = new List<LokiPoe.InstanceInfo.Struct37>();
				dictionary.Add(item.Key, value);
			}
			value.Add(item.Value);
			if (value.Count > 20000)
			{
				return dictionary;
			}
		}
		return dictionary;
	}

	public static Dictionary<long, List<long>> StdMultiHashMaplongListlong<TKey, TValue>(NativeHashMap nativeHashMap, Memory m = null)
	{
		Dictionary<long, List<long>> dictionary = new Dictionary<long, List<long>>();
		foreach (KeyValuePair<long, long> item in StdLong_LongList<KeyValuePair<long, long>>(nativeHashMap.List, m))
		{
			if (!dictionary.TryGetValue(item.Value, out var value))
			{
				value = new List<long>();
				dictionary.Add(item.Value, value);
			}
			value.Add(item.Key);
			if (value.Count > 20000)
			{
				return dictionary;
			}
		}
		return dictionary;
	}

	public static List<TValue> StdList<TValue>(NativeList nativeList, Memory m = null) where TValue : unmanaged
	{
		if (m == null)
		{
			m = GameController.Instance.Memory;
		}
		int size = MarshalCache<NativeListNode<TValue>>.Size;
		List<TValue> list = new List<TValue>();
		long head = nativeList.Head;
		long next = GameController.Instance.Memory.FastIntPtrToStruct<NativeListNode<TValue>>(head, size).Next;
		while (next != head)
		{
			NativeListNode<TValue> nativeListNode = GameController.Instance.Memory.FastIntPtrToStruct<NativeListNode<TValue>>(next, size);
			list.Add(nativeListNode.Value);
			next = nativeListNode.Next;
			if (list.Count >= 20000)
			{
				break;
			}
		}
		return list;
	}

	public static List<int> NativeList_ListInt<TValue>(NativeList nativeList, Memory m = null) where TValue : unmanaged
	{
		if (m == null)
		{
			m = GameController.Instance.Memory;
		}
		int num = 0;
		string key = global::_003CModule_003E.smethod_6<string>(2722711198u);
		if (Memory.StructureSizesDictionary.TryGetValue(key, out var value))
		{
			num = value;
		}
		else
		{
			num = MarshalCache<NativeListInt_LongNode>.Size;
			Memory.StructureSizesDictionary.Add(key, num);
		}
		List<int> list = new List<int>();
		long head = nativeList.Head;
		long next = GameController.Instance.Memory.FastIntPtrToStruct<NativeListInt_LongNode>(head, num).Next;
		while (next != head)
		{
			NativeListInt_LongNode nativeListInt_LongNode = GameController.Instance.Memory.FastIntPtrToStruct<NativeListInt_LongNode>(next, num);
			list.Add(nativeListInt_LongNode.IntValue);
			next = nativeListInt_LongNode.Next;
			if (list.Count >= 20000)
			{
				break;
			}
		}
		return list;
	}

	public static List<KeyValuePair<ushort, long>> StdInt_LongList<TValue>(NativeList nativeList, Memory m = null) where TValue : unmanaged
	{
		if (m == null)
		{
			m = GameController.Instance.Memory;
		}
		int num = 0;
		string key = global::_003CModule_003E.smethod_6<string>(2722711198u);
		if (!Memory.StructureSizesDictionary.TryGetValue(key, out var value))
		{
			num = MarshalCache<NativeListInt_LongNode>.Size;
			Memory.StructureSizesDictionary.Add(key, num);
		}
		else
		{
			num = value;
		}
		List<KeyValuePair<ushort, long>> list = new List<KeyValuePair<ushort, long>>();
		long head = nativeList.Head;
		long next = GameController.Instance.Memory.FastIntPtrToStruct<NativeListInt_LongNode>(head, num).Next;
		while (next != head)
		{
			NativeListInt_LongNode nativeListInt_LongNode = GameController.Instance.Memory.FastIntPtrToStruct<NativeListInt_LongNode>(next, num);
			list.Add(new KeyValuePair<ushort, long>(nativeListInt_LongNode.IntValue, nativeListInt_LongNode.LongValue));
			next = nativeListInt_LongNode.Next;
			if (list.Count >= 20000)
			{
				break;
			}
		}
		return list;
	}

	public static List<KeyValuePair<long, long>> StdLong_LongList<TValue>(NativeList nativeList, Memory m = null) where TValue : unmanaged
	{
		if (m == null)
		{
			m = GameController.Instance.Memory;
		}
		int num = 0;
		string key = global::_003CModule_003E.smethod_5<string>(2412187717u);
		if (Memory.StructureSizesDictionary.TryGetValue(key, out var value))
		{
			num = value;
		}
		else
		{
			num = MarshalCache<NativeListInt_LongNode>.Size;
			Memory.StructureSizesDictionary.Add(key, num);
		}
		List<KeyValuePair<long, long>> list = new List<KeyValuePair<long, long>>();
		long head = nativeList.Head;
		long next = GameController.Instance.Memory.FastIntPtrToStruct<NativeListLong_LongNode>(head, num).Next;
		while (next != head)
		{
			NativeListLong_LongNode nativeListLong_LongNode = GameController.Instance.Memory.FastIntPtrToStruct<NativeListLong_LongNode>(next, num);
			list.Add(new KeyValuePair<long, long>(nativeListLong_LongNode.LongKey, nativeListLong_LongNode.LongValue));
			next = nativeListLong_LongNode.Next;
			if (list.Count >= 20000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<KeyValuePair<long, LokiPoe.InstanceInfo.Struct37>> StdLong_Struct37List<TValue>(NativeList nativeList, Memory m = null) where TValue : unmanaged
	{
		if (m == null)
		{
			m = GameController.Instance.Memory;
		}
		int num = 0;
		string key = global::_003CModule_003E.smethod_8<string>(345111196u);
		if (Memory.StructureSizesDictionary.TryGetValue(key, out var value))
		{
			num = value;
		}
		else
		{
			num = MarshalCache<NativeListLong_Struct37Node>.Size;
			Memory.StructureSizesDictionary.Add(key, num);
		}
		List<KeyValuePair<long, LokiPoe.InstanceInfo.Struct37>> list = new List<KeyValuePair<long, LokiPoe.InstanceInfo.Struct37>>();
		long head = nativeList.Head;
		long next = GameController.Instance.Memory.FastIntPtrToStruct<NativeListLong_Struct37Node>(head, num).Next;
		while (next != head)
		{
			NativeListLong_Struct37Node nativeListLong_Struct37Node = GameController.Instance.Memory.FastIntPtrToStruct<NativeListLong_Struct37Node>(next, num);
			list.Add(new KeyValuePair<long, LokiPoe.InstanceInfo.Struct37>(nativeListLong_Struct37Node.LongKey, nativeListLong_Struct37Node.Struct37Value));
			next = nativeListLong_Struct37Node.Next;
			if (list.Count >= 20000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<KeyValuePair<Struct243, long>> StdStruct243_LongList<TValue>(NativeList nativeList, Memory m = null) where TValue : unmanaged
	{
		if (m == null)
		{
			m = GameController.Instance.Memory;
		}
		List<KeyValuePair<Struct243, long>> list = new List<KeyValuePair<Struct243, long>>();
		int size = MarshalCache<NativeListStruct243_LongNode>.Size;
		long head = nativeList.Head;
		long next = GameController.Instance.Memory.FastIntPtrToStruct<NativeListStruct243_LongNode>(head, size).Next;
		while (next != head)
		{
			NativeListStruct243_LongNode nativeListStruct243_LongNode = GameController.Instance.Memory.FastIntPtrToStruct<NativeListStruct243_LongNode>(next, size);
			list.Add(new KeyValuePair<Struct243, long>(nativeListStruct243_LongNode.Struct243, nativeListStruct243_LongNode.LongValue));
			next = nativeListStruct243_LongNode.Next;
			if (list.Count >= 20000)
			{
				break;
			}
		}
		return list;
	}

	public static List<KeyValuePair<NativeStringWCustom, int>> StdNativeStringWCustom_intList<TValue>(NativeList nativeList, Memory m = null) where TValue : unmanaged
	{
		if (m == null)
		{
			m = GameController.Instance.Memory;
		}
		List<KeyValuePair<NativeStringWCustom, int>> list = new List<KeyValuePair<NativeStringWCustom, int>>();
		long head = nativeList.Head;
		long next = GameController.Instance.Memory.FastIntPtrToStruct<NativeStringWCustom_intNode>(head).Next;
		while (next != head)
		{
			NativeStringWCustom_intNode nativeStringWCustom_intNode = GameController.Instance.Memory.FastIntPtrToStruct<NativeStringWCustom_intNode>(next);
			list.Add(new KeyValuePair<NativeStringWCustom, int>(nativeStringWCustom_intNode.stringValue, nativeStringWCustom_intNode.intValue));
			next = nativeStringWCustom_intNode.Next;
			if (list.Count >= 500000)
			{
				break;
			}
		}
		return list;
	}

	public static List<int> StdIntVector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<int> list = new List<int>();
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			long num = (nativeVector.Last - nativeVector.First) / 4L;
			if (num <= 200000L)
			{
				byte[] value = GameController.Instance.Memory.ReadMem(nativeVector.First, (int)num * 4);
				for (int i = 0; i < num; i++)
				{
					list.Add(BitConverter.ToInt32(value, i * 4));
				}
				return list;
			}
			return list;
		}
		return list;
	}

	public static List<byte> StdByteVector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			long num = nativeVector.Last - nativeVector.First;
			if (num > 20000L)
			{
				return new List<byte>();
			}
			byte[] source = GameController.Instance.Memory.ReadMem(nativeVector.First, (int)num);
			return source.ToList();
		}
		return new List<byte>();
	}

	public static List<long> StdLongVector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<long> list = new List<long>();
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			long num = (nativeVector.Last - nativeVector.First) / 8L;
			if (num > 0L && num <= 200000L)
			{
				byte[] value = GameController.Instance.Memory.ReadMem(nativeVector.First, (int)(num * 8L));
				for (int i = 0; i < num; i++)
				{
					list.Add(BitConverter.ToInt64(value, i * 8));
				}
				return list;
			}
			return list;
		}
		return list;
	}

	internal static List<LokiPoe.InstanceInfo.Struct26> StdStruct26Vector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<LokiPoe.InstanceInfo.Struct26> list = new List<LokiPoe.InstanceInfo.Struct26>();
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(GameController.Instance.Memory.FastIntPtrToStruct<LokiPoe.InstanceInfo.Struct26>(num));
			num += DreamPoeBot.Loki.MarshalCache<LokiPoe.InstanceInfo.Struct26>.Size;
			if (list.Count >= 20000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<MinimapIconWrapper.Struct278> StdStruct278Vector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<MinimapIconWrapper.Struct278> list = new List<MinimapIconWrapper.Struct278>();
		int size = DreamPoeBot.Loki.MarshalCache<MinimapIconWrapper.Struct278>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(GameController.Instance.Memory.FastIntPtrToStruct<MinimapIconWrapper.Struct278>(num));
			num += size;
			if (list.Count >= 20000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<LokiPoe.InGameState.AtlasUi.Struct55> StdStruct55Vector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<LokiPoe.InGameState.AtlasUi.Struct55> list = new List<LokiPoe.InGameState.AtlasUi.Struct55>();
		int size = DreamPoeBot.Loki.MarshalCache<LokiPoe.InGameState.AtlasUi.Struct55>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(GameController.Instance.Memory.FastIntPtrToStruct<LokiPoe.InGameState.AtlasUi.Struct55>(num));
			num += size;
			if (list.Count >= 20000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<LokiPoe.InGameState.StashUi.Struct90> StdStruct90Vector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<LokiPoe.InGameState.StashUi.Struct90> list = new List<LokiPoe.InGameState.StashUi.Struct90>();
		int size = DreamPoeBot.Loki.MarshalCache<LokiPoe.InGameState.StashUi.Struct90>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(GameController.Instance.Memory.FastIntPtrToStruct<LokiPoe.InGameState.StashUi.Struct90>(num));
			num += size;
			if (list.Count >= 20000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<Mods.StructModsInfo> StdStruct178Vector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<Mods.StructModsInfo> list = new List<Mods.StructModsInfo>();
		int size = DreamPoeBot.Loki.MarshalCache<Mods.StructModsInfo>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(GameController.Instance.Memory.FastIntPtrToStruct<Mods.StructModsInfo>(num));
			num += size;
			if (list.Count >= 20000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<KeyValuePair<StatTypeGGG, int>> StdStatType_IntVector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<KeyValuePair<StatTypeGGG, int>> list = new List<KeyValuePair<StatTypeGGG, int>>();
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			long num = (nativeVector.Last - nativeVector.First) / 8L;
			if (num <= 20000L)
			{
				byte[] value = GameController.Instance.Memory.ReadMem(nativeVector.First, (int)num * 8);
				for (int i = 0; i < num; i++)
				{
					StatTypeGGG key = (StatTypeGGG)BitConverter.ToInt32(value, i * 8);
					int value2 = BitConverter.ToInt32(value, i * 8 + 4);
					list.Add(new KeyValuePair<StatTypeGGG, int>(key, value2));
				}
				return list;
			}
			return list;
		}
		return list;
	}

	internal static List<KeyValuePair<long, long>> StdIntPtr_IntPtrVector(NativeVector nativeVector, Memory m = null)
	{
		List<KeyValuePair<long, long>> list = new List<KeyValuePair<long, long>>();
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			long num = (nativeVector.Last - nativeVector.First) / 16L;
			if (num > 20000L)
			{
				return list;
			}
			byte[] value = GameController.Instance.Memory.ReadMem(nativeVector.First, (int)num * 16);
			for (int i = 0; i < num; i++)
			{
				long key = BitConverter.ToInt64(value, i * 16);
				long value2 = BitConverter.ToInt64(value, i * 16 + 8);
				list.Add(new KeyValuePair<long, long>(key, value2));
			}
			return list;
		}
		return list;
	}

	public static List<DatPassiveSkillMasteryEffectsWrapper.PassiveSkillMasteryEffectsStructure> StPassiveSkillMasteryEffectsStructureVector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<DatPassiveSkillMasteryEffectsWrapper.PassiveSkillMasteryEffectsStructure> list = new List<DatPassiveSkillMasteryEffectsWrapper.PassiveSkillMasteryEffectsStructure>();
		int size = DreamPoeBot.Loki.MarshalCache<DatPassiveSkillMasteryEffectsWrapper.PassiveSkillMasteryEffectsStructure>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			GameController.Instance.Memory.FastIntPtrToStruct<DatPassiveSkillMasteryEffectsWrapper.PassiveSkillMasteryEffectsStructure>(num);
			list.Add(GameController.Instance.Memory.FastIntPtrToStruct<DatPassiveSkillMasteryEffectsWrapper.PassiveSkillMasteryEffectsStructure>(num));
			num += size;
			if (list.Count >= 20000)
			{
				break;
			}
		}
		return list;
	}

	public static List<DatPassiveSkillWrapper.Struct131> StdStruct131Vector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<DatPassiveSkillWrapper.Struct131> list = new List<DatPassiveSkillWrapper.Struct131>();
		int size = DreamPoeBot.Loki.MarshalCache<DatPassiveSkillWrapper.Struct131>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			DatPassiveSkillWrapper.Struct131 @struct = GameController.Instance.Memory.FastIntPtrToStruct<DatPassiveSkillWrapper.Struct131>(num);
			if (GameController.Instance.Memory.ReadStringU(@struct.intptr_0Id) == global::_003CModule_003E.smethod_9<string>(3752614129u))
			{
			}
			list.Add(GameController.Instance.Memory.FastIntPtrToStruct<DatPassiveSkillWrapper.Struct131>(num));
			num += size;
			if (list.Count >= 20000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<Struct242> StdStruct242Vector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<Struct242> list = new List<Struct242>();
		int size = DreamPoeBot.Loki.MarshalCache<Struct242>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(GameController.Instance.Memory.FastIntPtrToStruct<Struct242>(num));
			num += size;
			if (list.Count >= 20000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<Stats.Struct221> StdStruct221Vector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<Stats.Struct221> list = new List<Stats.Struct221>();
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			int size = DreamPoeBot.Loki.MarshalCache<Stats.Struct221>.Size;
			long num = nativeVector.First;
			while (num != nativeVector.Last)
			{
				list.Add(GameController.Instance.Memory.FastIntPtrToStruct<Stats.Struct221>(num));
				num += size;
				if (list.Count >= 20000)
				{
					break;
				}
			}
			return list;
		}
		return list;
	}

	internal static List<Stats.Struct222> StdStruct222Vector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<Stats.Struct222> list = new List<Stats.Struct222>();
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			int size = DreamPoeBot.Loki.MarshalCache<Stats.Struct222>.Size;
			for (long num = nativeVector.First; num != nativeVector.Last; num += size)
			{
				if (list.Count > 20000)
				{
					break;
				}
				list.Add(GameController.Instance.Memory.FastIntPtrToStruct<Stats.Struct222>(num));
			}
			return list;
		}
		return list;
	}

	internal static List<DatLabyrinthTrialWrapper.Struct313> StdStruct313Vector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<DatLabyrinthTrialWrapper.Struct313> list = new List<DatLabyrinthTrialWrapper.Struct313>();
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			int size = DreamPoeBot.Loki.MarshalCache<DatLabyrinthTrialWrapper.Struct313>.Size;
			for (long num = nativeVector.First; num != nativeVector.Last; num += size)
			{
				if (list.Count > 20000)
				{
					break;
				}
				list.Add(GameController.Instance.Memory.FastIntPtrToStruct<DatLabyrinthTrialWrapper.Struct313>(num));
			}
			return list;
		}
		return list;
	}

	public static List<NativeStringWCustom> StdNativeStringWCustomVector(NativeVector nativeVector, Memory m = null)
	{
		List<NativeStringWCustom> list = new List<NativeStringWCustom>();
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			int size = DreamPoeBot.Loki.MarshalCache<NativeStringWCustom>.Size;
			for (long num = nativeVector.First; num != nativeVector.Last; num += size)
			{
				if (list.Count > 20000)
				{
					break;
				}
				NativeStringWCustom item = GameController.Instance.Memory.IntptrToNativeStringWCustom(num);
				list.Add(item);
			}
			return list;
		}
		return list;
	}

	internal static List<SoclialPannelElement.Struct110> StdStruct110Vector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<SoclialPannelElement.Struct110> list = new List<SoclialPannelElement.Struct110>();
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			int size = DreamPoeBot.Loki.MarshalCache<SoclialPannelElement.Struct110>.Size;
			long num = nativeVector.First;
			while (num != nativeVector.Last)
			{
				list.Add(GameController.Instance.Memory.FastIntPtrToStruct<SoclialPannelElement.Struct110>(num));
				num += size;
				if (list.Count >= 20000)
				{
					break;
				}
			}
			return list;
		}
		return list;
	}

	internal static List<PartyInvite.Struct279> StdStruct279Vector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<PartyInvite.Struct279> list = new List<PartyInvite.Struct279>();
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			int size = MarshalCache<PartyInvite.Struct279>.Size;
			long num = nativeVector.First;
			while (num != nativeVector.Last)
			{
				list.Add(GameController.Instance.Memory.FastIntPtrToStruct<PartyInvite.Struct279>(num));
				num += size;
				if (list.Count >= 20000)
				{
					break;
				}
			}
			return list;
		}
		return list;
	}

	internal static List<KeyValuePair<long, PartyInvite.Struct279>> StdLong_Struct279List<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<KeyValuePair<long, PartyInvite.Struct279>> list = new List<KeyValuePair<long, PartyInvite.Struct279>>();
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			int size = MarshalCache<PartyInvite.Struct279>.Size;
			long num = nativeVector.First;
			while (num != nativeVector.Last)
			{
				list.Add(new KeyValuePair<long, PartyInvite.Struct279>(num, GameController.Instance.Memory.FastIntPtrToStruct<PartyInvite.Struct279>(num)));
				num += size;
				if (list.Count >= 20000)
				{
					break;
				}
			}
			return list;
		}
		return list;
	}

	internal static List<PartyMember.Struct280> StdStruct280Vector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<PartyMember.Struct280> list = new List<PartyMember.Struct280>();
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			int size = MarshalCache<PartyMember.Struct280>.Size;
			long num = nativeVector.First;
			while (num != nativeVector.Last)
			{
				list.Add(GameController.Instance.Memory.FastIntPtrToStruct<PartyMember.Struct280>(num));
				num += size;
				if (list.Count >= 20000)
				{
					break;
				}
			}
			return list;
		}
		return list;
	}

	internal static List<KeyValuePair<long, PartyMember.Struct280>> StdLong_Struct280List<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<KeyValuePair<long, PartyMember.Struct280>> list = new List<KeyValuePair<long, PartyMember.Struct280>>();
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			int size = MarshalCache<PartyMember.Struct280>.Size;
			long num = nativeVector.First;
			while (num != nativeVector.Last)
			{
				list.Add(new KeyValuePair<long, PartyMember.Struct280>(num, GameController.Instance.Memory.FastIntPtrToStruct<PartyMember.Struct280>(num)));
				num += size;
				if (list.Count >= 20000)
				{
					break;
				}
			}
			return list;
		}
		return list;
	}

	internal static List<StashTabInfo.StashTabInfoStruct277> StdStruct277Vector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<StashTabInfo.StashTabInfoStruct277> list = new List<StashTabInfo.StashTabInfoStruct277>();
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			long num = nativeVector.First;
			while (num != nativeVector.Last)
			{
				list.Add(GameController.Instance.Memory.FastIntPtrToStruct<StashTabInfo.StashTabInfoStruct277>(num));
				num += StashTabInfoStruct277Size;
				if (list.Count >= 20000)
				{
					break;
				}
			}
			return list;
		}
		return list;
	}

	internal static List<TabControlWrapper.Struct110> StdStructTab110Vector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<TabControlWrapper.Struct110> list = new List<TabControlWrapper.Struct110>();
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			int size = DreamPoeBot.Loki.MarshalCache<TabControlWrapper.Struct110>.Size;
			long num = nativeVector.First;
			while (num != nativeVector.Last)
			{
				list.Add(GameController.Instance.Memory.FastIntPtrToStruct<TabControlWrapper.Struct110>(num));
				num += size;
				if (list.Count >= 20000)
				{
					break;
				}
			}
			return list;
		}
		return list;
	}

	internal static List<DatIncursionRoomsWrapper.Struct104> StdStruct104Vector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<DatIncursionRoomsWrapper.Struct104> list = new List<DatIncursionRoomsWrapper.Struct104>();
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			int size = DreamPoeBot.Loki.MarshalCache<DatIncursionRoomsWrapper.Struct104>.Size;
			long num = nativeVector.First;
			while (num != nativeVector.Last)
			{
				list.Add(GameController.Instance.Memory.FastIntPtrToStruct<DatIncursionRoomsWrapper.Struct104>(num));
				num += size;
				if (list.Count >= 20000)
				{
					break;
				}
			}
			return list;
		}
		return list;
	}

	internal static List<LokiPoe.InGameState.MetamorphUi.Struct99Metamorph> StdStructStructMetamorphVector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<LokiPoe.InGameState.MetamorphUi.Struct99Metamorph> list = new List<LokiPoe.InGameState.MetamorphUi.Struct99Metamorph>();
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			if (nativeVector.First != 0L)
			{
				int size = DreamPoeBot.Loki.MarshalCache<LokiPoe.InGameState.MetamorphUi.Struct99Metamorph>.Size;
				long num = nativeVector.First;
				while (num != nativeVector.Last)
				{
					list.Add(GameController.Instance.Memory.FastIntPtrToStruct<LokiPoe.InGameState.MetamorphUi.Struct99Metamorph>(num));
					num += size;
					if (list.Count >= 20000)
					{
						break;
					}
				}
				return list;
			}
			return list;
		}
		return list;
	}

	internal static List<Dat.Runtime.DatMonsterVarietyWrapper2.Struct286> StdStruct286Vector<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		List<Dat.Runtime.DatMonsterVarietyWrapper2.Struct286> list = new List<Dat.Runtime.DatMonsterVarietyWrapper2.Struct286>();
		if (nativeVector.First != 0L && nativeVector.Last != 0L && nativeVector.End != 0L)
		{
			int num = 746;
			long num2 = nativeVector.First;
			while (num2 != nativeVector.Last)
			{
				list.Add(GameController.Instance.Memory.FastIntPtrToStruct<Dat.Runtime.DatMonsterVarietyWrapper2.Struct286>(num2));
				num2 += num;
				if (list.Count >= 20000)
				{
					break;
				}
			}
			return list;
		}
		return list;
	}

	public unsafe static string StdStringW(NativeStringW nativeString)
	{
		Memory memory = GameController.Instance.Memory;
		if (nativeString.Size != 0)
		{
			if (8 > nativeString.ReservedSize)
			{
				StringBuilder stringBuilder = new StringBuilder((int)nativeString.Size);
				int num = 0;
				for (int i = 0; i < nativeString.Size; i++)
				{
					num++;
					if (num > 20000)
					{
						break;
					}
					stringBuilder.Append(nativeString.Buf.FixedElementField[(int)(ushort)(i * 2)]);
				}
				return stringBuilder.ToString();
			}
			char* ptr = nativeString.Buf.FixedElementField;
			long* ptr2 = (long*)ptr;
			return memory.ReadStringU((long)ptr2, (int)(2 * nativeString.Size));
		}
		return string.Empty;
	}

	public static string StdStringWCustom(NativeStringWCustom nativeString)
	{
		Memory memory = GameController.Instance.Memory;
		if (nativeString.Size != 0 && nativeString.Size <= 20000)
		{
			if (nativeString.ReservedSize < nativeString.Size)
			{
				return string.Empty;
			}
			if (8 > nativeString.ReservedSize)
			{
				byte[] bytes = BitConverter.GetBytes(nativeString.Buf.Address);
				byte[] bytes2 = BitConverter.GetBytes(nativeString.Buf.Address2);
				byte[] bytes3 = bytes.Concat(bytes2).ToArray();
				return Encoding.Unicode.GetString(bytes3).Substring(0, (int)nativeString.Size);
			}
			return memory.ReadStringU(nativeString.Buf.Address, (int)(2 * nativeString.Size));
		}
		return string.Empty;
	}

	public static string StdStringACustom(NativeStringWCustom nativeString)
	{
		Memory memory = GameController.Instance.Memory;
		if (nativeString.Size != 0 && nativeString.Size <= 20000)
		{
			if (16 <= nativeString.ReservedSize)
			{
				return memory.ReadString(nativeString.Buf.Address, (int)nativeString.Size);
			}
			byte[] bytes = BitConverter.GetBytes(nativeString.Buf.Address);
			byte[] bytes2 = BitConverter.GetBytes(nativeString.Buf.Address2);
			byte[] bytes3 = bytes.Concat(bytes2).ToArray();
			return Encoding.ASCII.GetString(bytes3).Substring(0, (int)nativeString.Size);
		}
		return string.Empty;
	}

	public unsafe static string StdStringA(NativeStringA nativeString)
	{
		Memory memory = GameController.Instance.Memory;
		if (nativeString.Size != 0)
		{
			if (16 <= nativeString.ReservedSize)
			{
				int num = *(int*)(&nativeString.Buf.FixedElementField);
				return memory.ReadString(num, (int)nativeString.Size);
			}
			StringBuilder stringBuilder = new StringBuilder((int)nativeString.Size);
			int num2 = 0;
			while (num2 < nativeString.Size)
			{
				stringBuilder.Append((&nativeString.Buf.FixedElementField)[num2]);
				num2++;
				if (num2 > 20000)
				{
					break;
				}
			}
			return stringBuilder.ToString();
		}
		return string.Empty;
	}

	public static Dictionary<int, long> StdInt_LongHashMap<TKey, TValue>(NativeHashMap nativeHashMap, Memory m = null)
	{
		Dictionary<int, long> dictionary = new Dictionary<int, long>();
		List<KeyValuePair<ushort, long>> list = StdInt_LongList<KeyValuePair<ushort, long>>(nativeHashMap.List, GameController.Instance.Memory);
		int num = 0;
		foreach (KeyValuePair<ushort, long> item in list)
		{
			num++;
			if (num <= 20000)
			{
				dictionary.Add(item.Key, item.Value);
				continue;
			}
			return dictionary;
		}
		return dictionary;
	}

	internal static Dictionary<Struct243, long> StdStruct243_LongHashMap<TKey, TValue>(NativeHashMap nativeHashMap, Memory m = null)
	{
		Dictionary<Struct243, long> dictionary = new Dictionary<Struct243, long>();
		List<KeyValuePair<Struct243, long>> list = StdStruct243_LongList<KeyValuePair<Struct243, long>>(nativeHashMap.List, GameController.Instance.Memory);
		int num = 0;
		foreach (KeyValuePair<Struct243, long> item in list)
		{
			num++;
			if (num <= 20000)
			{
				dictionary.Add(item.Key, item.Value);
				continue;
			}
			return dictionary;
		}
		return dictionary;
	}

	public static Dictionary<NativeStringWCustom, int> StdNativeStringWCustom_intHashMap<TKey, TValue>(NativeHashMap nativeHashMap, Memory m = null)
	{
		Dictionary<NativeStringWCustom, int> dictionary = new Dictionary<NativeStringWCustom, int>();
		List<KeyValuePair<NativeStringWCustom, int>> list = StdNativeStringWCustom_intList<KeyValuePair<NativeStringWCustom, int>>(nativeHashMap.List, GameController.Instance.Memory);
		int num = 0;
		foreach (KeyValuePair<NativeStringWCustom, int> item in list)
		{
			num++;
			if (num <= 200000)
			{
				dictionary.Add(item.Key, item.Value);
				continue;
			}
			return dictionary;
		}
		return dictionary;
	}

	internal static List<Tuple<DatClientStringWrapper.Struct302, long>> StdVectorExStruct302<Struct302>(NativeVector nativeVector, Memory m = null) where Struct302 : unmanaged
	{
		if (m == null)
		{
			m = LokiPoe.Memory;
		}
		List<Tuple<DatClientStringWrapper.Struct302, long>> list = new List<Tuple<DatClientStringWrapper.Struct302, long>>();
		int size = MarshalCache<DatClientStringWrapper.Struct302>.Size;
		long first = nativeVector.First;
		list.Add(new Tuple<DatClientStringWrapper.Struct302, long>(GameController.Instance.Memory.FastIntPtrToStruct<DatClientStringWrapper.Struct302>(first), first));
		first += size;
		while (first != nativeVector.Last)
		{
			list.Add(new Tuple<DatClientStringWrapper.Struct302, long>(GameController.Instance.Memory.FastIntPtrToStruct<DatClientStringWrapper.Struct302>(first), first));
			first += size;
			if (list.Count >= 500000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<Tuple<DatStatWrapper.Struct325, long>> StdVectorExStruct325<Struct325>(NativeVector nativeVector, Memory m = null) where Struct325 : unmanaged
	{
		if (m == null)
		{
			m = LokiPoe.Memory;
		}
		int size = MarshalCache<DatStatWrapper.Struct325>.Size;
		List<Tuple<DatStatWrapper.Struct325, long>> list = new List<Tuple<DatStatWrapper.Struct325, long>>();
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(new Tuple<DatStatWrapper.Struct325, long>(GameController.Instance.Memory.FastIntPtrToStruct<DatStatWrapper.Struct325>(num), num));
			num += size;
			if (list.Count >= 200000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<Tuple<DatWorldAreaWrapper.Struct327, long>> StdVectorExStruct327<Struct327>(NativeVector nativeVector, Memory m = null) where Struct327 : unmanaged
	{
		if (m == null)
		{
			m = LokiPoe.Memory;
		}
		List<Tuple<DatWorldAreaWrapper.Struct327, long>> list = new List<Tuple<DatWorldAreaWrapper.Struct327, long>>();
		int size = MarshalCache<DatWorldAreaWrapper.Struct327>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(new Tuple<DatWorldAreaWrapper.Struct327, long>(GameController.Instance.Memory.FastIntPtrToStruct<DatWorldAreaWrapper.Struct327>(num), num));
			num += size;
			if (list.Count >= 200000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<Tuple<DatPropheciesWrapper.Struct321, long>> StdVectorExStruct321<Struct321>(NativeVector nativeVector, Memory m = null) where Struct321 : unmanaged
	{
		if (m == null)
		{
			m = LokiPoe.Memory;
		}
		List<Tuple<DatPropheciesWrapper.Struct321, long>> list = new List<Tuple<DatPropheciesWrapper.Struct321, long>>();
		int size = MarshalCache<DatPropheciesWrapper.Struct321>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(new Tuple<DatPropheciesWrapper.Struct321, long>(GameController.Instance.Memory.FastIntPtrToStruct<DatPropheciesWrapper.Struct321>(num), num));
			num += size;
			if (list.Count >= 200000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<Tuple<DatMinimapIconWrapper.Struct315, long>> StdVectorExStruct315<Struct315>(NativeVector nativeVector, Memory m = null) where Struct315 : unmanaged
	{
		if (m == null)
		{
			m = LokiPoe.Memory;
		}
		List<Tuple<DatMinimapIconWrapper.Struct315, long>> list = new List<Tuple<DatMinimapIconWrapper.Struct315, long>>();
		int size = MarshalCache<DatMinimapIconWrapper.Struct315>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(new Tuple<DatMinimapIconWrapper.Struct315, long>(GameController.Instance.Memory.FastIntPtrToStruct<DatMinimapIconWrapper.Struct315>(num), num));
			num += size;
			if (list.Count >= 200000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<Tuple<DatBestiaryRecipesWrapper.Struct299, long>> StdVectorExStruct299<Struct299>(NativeVector nativeVector, Memory m = null) where Struct299 : unmanaged
	{
		if (m == null)
		{
			m = LokiPoe.Memory;
		}
		List<Tuple<DatBestiaryRecipesWrapper.Struct299, long>> list = new List<Tuple<DatBestiaryRecipesWrapper.Struct299, long>>();
		int size = MarshalCache<DatBestiaryRecipesWrapper.Struct299>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(new Tuple<DatBestiaryRecipesWrapper.Struct299, long>(GameController.Instance.Memory.FastIntPtrToStruct<DatBestiaryRecipesWrapper.Struct299>(num), num));
			num += size;
			if (list.Count >= 200000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<LokiPoe.InstanceInfo.Blight.StructBlightData> StdVectorExStructBlightData<StructBlightData>(NativeVector nativeVector, Memory m = null) where StructBlightData : unmanaged
	{
		if (m == null)
		{
			m = LokiPoe.Memory;
		}
		List<LokiPoe.InstanceInfo.Blight.StructBlightData> list = new List<LokiPoe.InstanceInfo.Blight.StructBlightData>();
		int size = MarshalCache<LokiPoe.InstanceInfo.Blight.StructBlightData>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(m.FastIntPtrToStruct<LokiPoe.InstanceInfo.Blight.StructBlightData>(num));
			num += size;
			if (list.Count >= 200000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<Tuple<DatSkillGemWrapper.Struct324, long>> StdVectorExStructDatSkillGems<StructDatSkillGem>(NativeVector nativeVector, Memory m = null) where StructDatSkillGem : unmanaged
	{
		if (m == null)
		{
			m = LokiPoe.Memory;
		}
		List<Tuple<DatSkillGemWrapper.Struct324, long>> list = new List<Tuple<DatSkillGemWrapper.Struct324, long>>();
		int size = MarshalCache<DatSkillGemWrapper.Struct324>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(new Tuple<DatSkillGemWrapper.Struct324, long>(GameController.Instance.Memory.FastIntPtrToStruct<DatSkillGemWrapper.Struct324>(num), num));
			num += size;
			if (list.Count >= 200000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<DatModsWrapper.Struct316> StdVectorStruct316<Struct316>(NativeVector nativeVector, Memory m = null) where Struct316 : unmanaged
	{
		if (m == null)
		{
			m = LokiPoe.Memory;
		}
		List<DatModsWrapper.Struct316> list = new List<DatModsWrapper.Struct316>();
		int size = DreamPoeBot.Loki.MarshalCache<DatModsWrapper.Struct316>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(GameController.Instance.Memory.FastIntPtrToStruct<DatModsWrapper.Struct316>(num));
			num += size;
			if (list.Count >= 200000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<DatWordsWrapper.Struct326> StdVectorStruct326<Struct326>(NativeVector nativeVector, Memory m = null) where Struct326 : unmanaged
	{
		if (m == null)
		{
			m = LokiPoe.Memory;
		}
		List<DatWordsWrapper.Struct326> list = new List<DatWordsWrapper.Struct326>();
		int size = DreamPoeBot.Loki.MarshalCache<DatWordsWrapper.Struct326>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(GameController.Instance.Memory.FastIntPtrToStruct<DatWordsWrapper.Struct326>(num));
			num += size;
			if (list.Count >= 200000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<LokiPoe.InstanceInfo.Struct24> StdVectorStruct24<Struct24>(NativeVector nativeVector, Memory m = null) where Struct24 : unmanaged
	{
		if (m == null)
		{
			m = LokiPoe.Memory;
		}
		List<LokiPoe.InstanceInfo.Struct24> list = new List<LokiPoe.InstanceInfo.Struct24>();
		int size = DreamPoeBot.Loki.MarshalCache<LokiPoe.InstanceInfo.Struct24>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(GameController.Instance.Memory.FastIntPtrToStruct<LokiPoe.InstanceInfo.Struct24>(num));
			num += size;
			if (list.Count >= 200000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<PassiveSkillMasteryEffectsStruct> StdVectorPassiveSkillMasteryEffectsStruct<PassiveSkillMasteryEffectsStruct>(NativeVector nativeVector, Memory m = null) where PassiveSkillMasteryEffectsStruct : unmanaged
	{
		if (m == null)
		{
			m = LokiPoe.Memory;
		}
		List<PassiveSkillMasteryEffectsStruct> list = new List<PassiveSkillMasteryEffectsStruct>();
		int size = DreamPoeBot.Loki.MarshalCache<PassiveSkillMasteryEffectsStruct>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(GameController.Instance.Memory.FastIntPtrToStruct<PassiveSkillMasteryEffectsStruct>(num));
			num += size;
			if (list.Count >= 200000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<Tuple<DatActiveSkillWrapper.ActiveSkills, long>> StdVectorExStruct289<Struct289>(NativeVector nativeVector, Memory m = null) where Struct289 : unmanaged
	{
		if (m == null)
		{
			m = LokiPoe.Memory;
		}
		List<Tuple<DatActiveSkillWrapper.ActiveSkills, long>> list = new List<Tuple<DatActiveSkillWrapper.ActiveSkills, long>>();
		int size = MarshalCache<DatActiveSkillWrapper.ActiveSkills>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(new Tuple<DatActiveSkillWrapper.ActiveSkills, long>(m.FastIntPtrToStruct<DatActiveSkillWrapper.ActiveSkills>(num), num));
			num += size;
			if (list.Count >= 200000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<Tuple<LokiPoe.LocalData.Struct45, long>> StdVectorExStruct45<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		if (m == null)
		{
			m = LokiPoe.Memory;
		}
		List<Tuple<LokiPoe.LocalData.Struct45, long>> list = new List<Tuple<LokiPoe.LocalData.Struct45, long>>();
		int size = MarshalCache<LokiPoe.LocalData.Struct45>.Size;
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(new Tuple<LokiPoe.LocalData.Struct45, long>(GameController.Instance.Memory.FastIntPtrToStruct<LokiPoe.LocalData.Struct45>(num), num));
			num += size;
			if (list.Count >= 200000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<Tuple<DatIncursionArchitectWrapper.Struct311, long>> StdListStruct311VectorEx<TValue>(NativeVector nativeVector, Memory m = null) where TValue : unmanaged
	{
		if (m == null)
		{
			m = LokiPoe.Memory;
		}
		List<Tuple<DatIncursionArchitectWrapper.Struct311, long>> list = new List<Tuple<DatIncursionArchitectWrapper.Struct311, long>>();
		long num = nativeVector.First;
		while (num != nativeVector.Last)
		{
			list.Add(new Tuple<DatIncursionArchitectWrapper.Struct311, long>(GameController.Instance.Memory.FastIntPtrToStruct<DatIncursionArchitectWrapper.Struct311>(num), num));
			num += MarshalCache<DatIncursionArchitectWrapper.Struct311>.Size;
			if (list.Count >= 200000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<Tuple<LokiPoe.InGameState.ChatPanel.Struct60, long>> StdListStruct60Ex<TValue>(NativeList nativeList, Memory m = null) where TValue : unmanaged
	{
		if (m == null)
		{
			m = LokiPoe.Memory;
		}
		List<Tuple<LokiPoe.InGameState.ChatPanel.Struct60, long>> list = new List<Tuple<LokiPoe.InGameState.ChatPanel.Struct60, long>>();
		long head = nativeList.Head;
		long next = m.FastIntPtrToStruct<NativeStruct60Node>(head, NativeStruct60NodeSize).Next;
		while (next != head)
		{
			NativeStruct60Node nativeStruct60Node = m.FastIntPtrToStruct<NativeStruct60Node>(next, NativeStruct60NodeSize);
			list.Add(new Tuple<LokiPoe.InGameState.ChatPanel.Struct60, long>(nativeStruct60Node.StructValue, next));
			next = nativeStruct60Node.Next;
			if (list.Count >= 1000000)
			{
				break;
			}
		}
		return list;
	}

	internal static List<LokiPoe.InGameState.ChatPanel.Struct60> StdListStruct60<TValue>(NativeList nativeList, Memory m = null) where TValue : unmanaged
	{
		if (m == null)
		{
			m = LokiPoe.Memory;
		}
		List<LokiPoe.InGameState.ChatPanel.Struct60> list = new List<LokiPoe.InGameState.ChatPanel.Struct60>();
		long head = nativeList.Head;
		long next = m.FastIntPtrToStruct<NativeStruct60Node>(head, NativeStruct60NodeSize).Next;
		while (next != head)
		{
			NativeStruct60Node nativeStruct60Node = m.FastIntPtrToStruct<NativeStruct60Node>(next, NativeStruct60NodeSize);
			list.Add(nativeStruct60Node.StructValue);
			next = nativeStruct60Node.Next;
			if (list.Count >= 1000000)
			{
				break;
			}
		}
		return list;
	}

	public static Dictionary<int, long> StdMapIntLong(NativeMap nativeMap, Memory m = null)
	{
		if (m == null)
		{
			m = GameController.Instance.Memory;
		}
		Dictionary<int, long> dictionary = new Dictionary<int, long>();
		long head = nativeMap.Head;
		long item = m.ReadLong(head + 8L);
		HashSet<long> hashSet = new HashSet<long>();
		Queue<long> queue = new Queue<long>();
		queue.Enqueue(item);
		int num = 0;
		while (queue.Count > 0 && dictionary.Count < nativeMap.Size)
		{
			num++;
			if (num > 50000)
			{
				break;
			}
			long num2 = queue.Dequeue();
			if (hashSet.Contains(num2))
			{
				continue;
			}
			hashSet.Add(num2);
			if (num2 != head && num2 != 0L)
			{
				byte[] value = m.ReadMem(num2, 48);
				long value2 = BitConverter.ToInt64(value, 40);
				int key = BitConverter.ToInt32(value, 32);
				if (!dictionary.ContainsKey(key))
				{
					dictionary.Add(key, value2);
				}
				queue.Enqueue(BitConverter.ToInt64(value, 0));
				queue.Enqueue(BitConverter.ToInt64(value, 16));
			}
		}
		return dictionary;
	}
}
