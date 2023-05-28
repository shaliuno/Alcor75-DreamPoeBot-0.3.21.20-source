using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class AtlasRegion : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructAtlasRegionsFile
	{
		public long RegionLocationString;

		public long RegionNameString;

		public int int_0;

		public long DataAwardDisplay;

		public long FavoriteMapSlots;

		public int int_1;

		public int int_2;

		public long DataSkillGraph;

		public long DataSkillGraphRelateds;

		public long Citadel;

		public int int_3;

		public long CitadelVideo;

		public int int_4;

		public long DataNPCTextAudio;

		public long DataNPCTextAudioRelated;
	}

	private string _regionName;

	private string _regionLocation;

	public string RegionName
	{
		get
		{
			if (string.IsNullOrEmpty(_regionName))
			{
				BuildCache();
			}
			return _regionName;
		}
	}

	public string RegionLocation
	{
		get
		{
			if (string.IsNullOrEmpty(_regionLocation))
			{
				BuildCache();
			}
			return _regionLocation;
		}
	}

	public override string ToString()
	{
		return global::_003CModule_003E.smethod_8<string>(2188526616u) + RegionName + global::_003CModule_003E.smethod_6<string>(1087264770u) + RegionLocation;
	}

	private void BuildCache()
	{
		StructAtlasRegionsFile structAtlasRegionsFile = base.M.FastIntPtrToStruct<StructAtlasRegionsFile>(base.Address);
		_regionName = base.M.ReadStringU(structAtlasRegionsFile.RegionNameString);
		_regionLocation = base.M.ReadStringU(structAtlasRegionsFile.RegionLocationString);
	}
}
