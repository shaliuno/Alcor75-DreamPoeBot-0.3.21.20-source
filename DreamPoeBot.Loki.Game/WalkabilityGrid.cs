using System;
using System.Collections;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Common;
using log4net;

namespace DreamPoeBot.Loki.Game;

public static class WalkabilityGrid
{
	internal static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	public static bool IsWalkable(CachedTerrainData cache, Vector2i pos, byte value)
	{
		return IsWalkable(cache, pos.X, pos.Y, value);
	}

	public static bool IsWalkable(CachedTerrainData cache, int c, int r, byte value)
	{
		return IsWalkable(cache.Data, cache.BPR, c, r, value);
	}

	public static bool IsWalkable(byte[] data, int bytesPerRow, Vector2i pos, byte value)
	{
		return IsWalkable(data, bytesPerRow, pos.X, pos.Y, value);
	}

	public static bool IsWalkable(byte[] data, int bytesPerRow, int c, int r, byte value)
	{
		int num = r * bytesPerRow + c / 2;
		if (num >= 0 && num < data.Length)
		{
			byte b = ((((uint)c & (true ? 1u : 0u)) != 0) ? ((byte)(data[num] >> 4)) : ((byte)(data[num] & 0xFu)));
			if (b < value)
			{
				return false;
			}
			return b < 15;
		}
		return false;
	}

	public static bool IsJumpable(byte[] data, int bytesPerRow, int c, int r, byte jumpableValue)
	{
		int num = r * bytesPerRow + c / 2;
		if (num >= 0 && num < data.Length)
		{
			byte b = (((c & 1) == 0) ? ((byte)(data[num] & 0xFu)) : ((byte)(data[num] >> 4)));
			return b >= jumpableValue;
		}
		ilog_0.WarnFormat(string.Format(global::_003CModule_003E.smethod_5<string>(3974107231u), c, r, bytesPerRow, num, data.Length), Array.Empty<object>());
		return false;
	}

	public static byte WalkableValue(CachedTerrainData cache, Vector2i pos)
	{
		return WalkableValue(cache, pos.X, pos.Y);
	}

	public static byte WalkableValue(CachedTerrainData cache, int c, int r)
	{
		return WalkableValue(cache.Data, cache.BPR, c, r);
	}

	public static byte WalkableValue(byte[] data, int bytesPerRow, Vector2i pos)
	{
		return WalkableValue(data, bytesPerRow, pos.X, pos.Y);
	}

	public static byte WalkableValue(byte[] data, int bytesPerRow, int c, int r)
	{
		int num = r * bytesPerRow + c / 2;
		if (num >= 0 && num < data.Length)
		{
			if ((c & 1) == 0)
			{
				return (byte)(data[num] & 0xFu);
			}
			return (byte)(data[num] >> 4);
		}
		ilog_0.WarnFormat(string.Format(global::_003CModule_003E.smethod_8<string>(3381238377u), c, r, bytesPerRow, num, data.Length), Array.Empty<object>());
		return 0;
	}

	public static BitArray GetWalkableBitArray(CachedTerrainData cache, byte value)
	{
		int num = cache.Cols * 23;
		int num2 = cache.Rows * 23;
		BitArray bitArray = new BitArray(num * num2);
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				bitArray[j * num + i] = IsWalkable(cache.Data, cache.BPR, i, j, value);
			}
		}
		return bitArray;
	}
}
