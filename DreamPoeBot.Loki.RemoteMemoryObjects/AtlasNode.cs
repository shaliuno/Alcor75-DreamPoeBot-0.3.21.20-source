using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.GameData;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class AtlasNode : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructAtlasNodesFile
	{
		public long DataWorldAreasAddress;

		public long DataWorldAreasKey;

		public long DataVisualIdentityAddress;

		public long DataVisualIdentityKey;

		public byte byte_0;

		public long DataMapsAddress;

		public long DataMapsKey;

		public long MapFlavourTextAddress;

		public long DataMapFlavourText;

		public int ConnectedNodeCount;

		private int Filler0;

		public long ConnectedNodePointer;

		public int Tier0;

		public int Tier1;

		public int Tier2;

		public int Tier3;

		public int Tier4;

		private float float0;

		private float float1;

		private float float2;

		private float float3;

		private float float4;

		private long DDSFile;

		public bool IsRoot;

		public bool IsHidden;
	}

	private string _name;

	private DatWorldAreaWrapper _worldArea;

	private long _areaAddress = -1L;

	private long _dataMapataAddress = -1L;

	private int _tier0 = -1;

	private int _tier1 = -1;

	private int _tier2 = -1;

	private int _tier3 = -1;

	private int _tier4 = -1;

	public string Name
	{
		get
		{
			if (string.IsNullOrEmpty(_name))
			{
				return _name = base.M.ReadStringU(base.M.ReadLong(structure.MapFlavourTextAddress), 255);
			}
			return _name;
		}
	}

	public DatWorldAreaWrapper WorldArea => _worldArea ?? (_worldArea = Dat.GetWorldArea(AreaAddress));

	public long AreaAddress
	{
		get
		{
			if (_areaAddress == -1L)
			{
				return _areaAddress = structure.DataWorldAreasAddress;
			}
			return _areaAddress;
		}
	}

	public long DataMapataAddress
	{
		get
		{
			if (_dataMapataAddress == -1L)
			{
				return _dataMapataAddress = structure.DataMapsAddress;
			}
			return _dataMapataAddress;
		}
	}

	public int Tier0
	{
		get
		{
			if (_tier0 == -1)
			{
				return _tier0 = structure.Tier0;
			}
			return _tier0;
		}
	}

	public int Tier1
	{
		get
		{
			if (_tier1 == -1)
			{
				return _tier1 = structure.Tier1;
			}
			return _tier1;
		}
	}

	public int Tier2
	{
		get
		{
			if (_tier2 == -1)
			{
				return _tier2 = structure.Tier2;
			}
			return _tier2;
		}
	}

	public int Tier3
	{
		get
		{
			if (_tier3 == -1)
			{
				return _tier3 = structure.Tier3;
			}
			return _tier3;
		}
	}

	public int Tier4
	{
		get
		{
			if (_tier4 == -1)
			{
				return _tier4 = structure.Tier4;
			}
			return _tier4;
		}
	}

	private StructAtlasNodesFile structure => base.M.FastIntPtrToStruct<StructAtlasNodesFile>(base.Address);

	public override string ToString()
	{
		return string.Format(global::_003CModule_003E.smethod_5<string>(1430451602u), AreaAddress, Name, DataMapataAddress.ToString(global::_003CModule_003E.smethod_6<string>(4007889961u)), WorldArea.Name, Tier0, Tier1, Tier2, Tier3, Tier4);
	}
}
