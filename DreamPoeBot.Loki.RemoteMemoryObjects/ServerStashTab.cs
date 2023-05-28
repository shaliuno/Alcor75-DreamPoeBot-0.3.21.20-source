using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class ServerStashTab : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct277
	{
		public readonly int int_0;

		public readonly int int_1;

		public readonly NativeStringWCustom nativeStringW_DisplayName;

		public readonly int int_InventoryId;

		public readonly uint uint_Color;

		public readonly InventoryTabPermissions inventoryTabPermissions_MembersFlag;

		public readonly InventoryTabPermissions inventoryTabPermissions_OfficersFlag;

		public readonly InventoryTabType inventoryTabType_0;

		public readonly ushort ushort_DysplayIndex;

		public readonly ushort ushort_LinkedParentId;

		public readonly InventoryTabMapSeries inventoryTabMapSeries_0;

		public readonly InventoryTabFlags inventoryTabFlags_0;

		private readonly byte byte_0;

		private readonly byte byte_1;

		private readonly short ushort_0;

		private readonly short ushort_1;

		private readonly short ushort_2;

		private readonly short ushort_3;
	}

	internal const int StructSize = 64;

	private PerFrameCachedValue<Struct277> perFrameCachedValue_1;

	public string DisplayName => Containers.StdStringWCustom(struct277_0.nativeStringW_DisplayName);

	public int InventoryId => struct277_0.int_InventoryId;

	public uint Color => struct277_0.uint_Color;

	public InventoryTabPermissions inventoryMemberFlags => struct277_0.inventoryTabPermissions_MembersFlag;

	public InventoryTabPermissions inventoryOfficerFlags => struct277_0.inventoryTabPermissions_OfficersFlag;

	public InventoryTabType inventoryTabType => struct277_0.inventoryTabType_0;

	public ushort DisplayIndex => struct277_0.ushort_DysplayIndex;

	public ushort LinkedParentId => struct277_0.ushort_LinkedParentId;

	public InventoryTabMapSeries inventoryTabMapSeries => struct277_0.inventoryTabMapSeries_0;

	public InventoryTabFlags inventoryTabFlags => struct277_0.inventoryTabFlags_0;

	internal Struct277 struct277_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct277>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	public override string ToString()
	{
		Struct277 @struct = struct277_0;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(3463597179u), @struct.int_0));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(126712006u), @struct.int_1));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(1591019544u), DisplayName));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(3288857290u), DisplayIndex));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(378440028u), LinkedParentId));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(3470281718u), Color));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3316856698u), inventoryTabType));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(110135590u), inventoryMemberFlags));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(2886868011u), inventoryOfficerFlags));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(2489568409u), inventoryTabMapSeries));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(2959970602u), inventoryTabFlags));
		return stringBuilder.ToString();
	}

	private Struct277 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct277>(base.Address);
	}
}
