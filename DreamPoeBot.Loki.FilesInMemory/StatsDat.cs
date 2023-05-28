using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DreamPoeBot.Loki.FilesInMemory;

public class StatsDat : FileInMemory
{
	public enum StatType
	{
		Percents = 1,
		Value2,
		IntValue,
		Boolean,
		Precents5
	}

	public class StatRecord
	{
		public readonly string Key;

		public readonly string StatTypeGGG;

		public readonly long Address;

		public StatType Type;

		public string UserFriendlyName;

		public StatRecord(Memory m, long addr)
		{
			Address = addr;
			Key = m.ReadStringU(m.ReadLong(addr));
			Type = (Key.Contains(global::_003CModule_003E.smethod_7<string>(1621447112u)) ? StatType.Percents : ((StatType)m.ReadInt(addr + 11L)));
			UserFriendlyName = m.ReadStringU(m.ReadLong(addr + 16L));
			StatTypeGGG = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Key).Replace(global::_003CModule_003E.smethod_8<string>(2520425632u), global::_003CModule_003E.smethod_5<string>(1046918135u)).Replace(global::_003CModule_003E.smethod_8<string>(3261465286u), global::_003CModule_003E.smethod_5<string>(523515561u))
				.Replace(global::_003CModule_003E.smethod_9<string>(3479700468u), global::_003CModule_003E.smethod_8<string>(2122660038u))
				.Replace(global::_003CModule_003E.smethod_9<string>(450936668u), "");
		}

		public override string ToString()
		{
			if (!string.IsNullOrWhiteSpace(UserFriendlyName))
			{
				return UserFriendlyName;
			}
			return Key;
		}

		internal string ValueToString(int val)
		{
			StatType type = Type;
			uint num = default(uint);
			while (true)
			{
				switch (type)
				{
				default:
				{
					int num2 = ((int)num * -1998451495) ^ 0x5A801B87;
					while (true)
					{
						switch ((num = (uint)num2 ^ 0x7947817Cu) % 9u)
						{
						case 2u:
							num2 = ((int)num * -282774304) ^ 0x6BAD3D15;
							continue;
						case 4u:
						case 6u:
							break;
						default:
							return "";
						case 0u:
							goto IL_007f;
						case 7u:
							goto IL_0091;
						case 1u:
							goto IL_0094;
						case 3u:
							goto IL_009f;
						case 8u:
							goto end_IL_005e;
						}
						break;
					}
					continue;
				}
				case StatType.Value2:
				case StatType.IntValue:
					goto IL_007f;
				case StatType.Boolean:
					goto IL_0091;
				case StatType.Percents:
				case StatType.Precents5:
					break;
					IL_007f:
					return val.ToString(global::_003CModule_003E.smethod_8<string>(4255466773u));
					IL_0091:
					if (val == 0)
					{
						goto IL_0094;
					}
					goto IL_009f;
					IL_0094:
					return global::_003CModule_003E.smethod_5<string>(3765288933u);
					IL_009f:
					return global::_003CModule_003E.smethod_9<string>(1140147762u);
					end_IL_005e:
					break;
				}
				break;
			}
			return val.ToString(global::_003CModule_003E.smethod_5<string>(3495299438u)) + global::_003CModule_003E.smethod_6<string>(1796033330u);
		}
	}

	public Dictionary<string, StatRecord> records = new Dictionary<string, StatRecord>(StringComparer.OrdinalIgnoreCase);

	public StatsDat(Memory m, long address)
		: base(m, address)
	{
		LoadItems();
	}

	public StatRecord GetStatByAddress(long address)
	{
		return records.Values.ToList().Find((StatRecord x) => x.Address == address);
	}

	private void LoadItems()
	{
		IEnumerable<long> enumerable = RecordAddresses();
		foreach (long item in enumerable)
		{
			StatRecord statRecord = new StatRecord(base.M, item);
			if (!records.ContainsKey(statRecord.Key))
			{
				records.Add(statRecord.Key, statRecord);
			}
		}
	}
}
