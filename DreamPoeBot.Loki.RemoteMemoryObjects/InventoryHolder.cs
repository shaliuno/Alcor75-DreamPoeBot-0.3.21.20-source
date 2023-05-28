using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class InventoryHolder : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct StructInventoryHolder
	{
		public readonly int Id;

		private readonly uint uint_2;

		public readonly long InventoryAddress;

		private readonly long intptr_2;

		private readonly long intptr_3;
	}

	internal const int StructSize = 32;

	private int _id = -1;

	private PerFrameCachedValue<StructInventoryHolder> perFrameCachedData;

	public int Id
	{
		get
		{
			if (_id == -1)
			{
				_id = InventoryHolderCache.Id;
			}
			return _id;
		}
	}

	public DreamPoeBot.Loki.Game.Inventory Inventory => new DreamPoeBot.Loki.Game.Inventory(InventoryHolderCache.InventoryAddress, Id);

	private StructInventoryHolder InventoryHolderCache => base.M.FastIntPtrToStruct<StructInventoryHolder>(base.Address, 32);

	private DreamPoeBot.Loki.Game.Inventory createcache()
	{
		return new DreamPoeBot.Loki.Game.Inventory(base.M.ReadLong(base.Address + 8L), Id);
	}

	public override string ToString()
	{
		return string.Format(global::_003CModule_003E.smethod_6<string>(1548764023u), Inventory.PageType, Inventory.PageSlot, Inventory.IsRequested, Inventory.Items.Count);
	}
}
