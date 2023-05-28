using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;

namespace DreamPoeBot.Loki.Game.NativeWrappers;

public class PartyInvite : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct279
	{
		public int int_0;

		public int Unusedint_0;

		public NativeStringWCustom nativeStringW_0;

		public NativeStringWCustom nativeStringW_1;

		public NativeStringWCustom nativeStringW_2;

		public NativeStringWCustom nativeStringW_3;

		public int int_1;

		public int Unusedint_1;

		public NativeVector nativeVector_0;

		public byte byte_2;

		public byte byte_3;

		public byte byte_4;

		public byte byte_5;

		public int Unusedint_2;
	}

	private readonly Struct279? nullable_0;

	internal Struct279 Struct279_0
	{
		get
		{
			if (nullable_0.HasValue)
			{
				return nullable_0.Value;
			}
			return base.M.FastIntPtrToStruct<Struct279>(base.Address);
		}
	}

	public int PartyId => Struct279_0.int_0;

	public string Unknown_04 => Containers.StdStringWCustom(Struct279_0.nativeStringW_0);

	public string PartyDescription => Containers.StdStringWCustom(Struct279_0.nativeStringW_1);

	public string CreatorAccountName => Containers.StdStringWCustom(Struct279_0.nativeStringW_2);

	public int Unknown_4C => Struct279_0.int_1;

	public List<PartyMember> PartyMembers
	{
		get
		{
			List<KeyValuePair<long, PartyMember.Struct280>> source = Containers.StdLong_Struct280List<PartyMember.Struct280>(Struct279_0.nativeVector_0);
			return source.Select((KeyValuePair<long, PartyMember.Struct280> x) => new PartyMember(x.Key, x.Value)).ToList();
		}
	}

	public PartyAllocationType PartyAllocation => (PartyAllocationType)Struct279_0.byte_2;

	internal PartyInvite(long address)
		: base(address)
	{
	}

	internal PartyInvite(long ptr, Struct279 native)
		: base(ptr)
	{
		nullable_0 = native;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(global::_003CModule_003E.smethod_6<string>(707904990u), base.Address);
		stringBuilder.AppendFormat(global::_003CModule_003E.smethod_6<string>(310605388u), PartyId);
		stringBuilder.AppendFormat(global::_003CModule_003E.smethod_6<string>(1477394752u), Unknown_04);
		stringBuilder.AppendFormat(global::_003CModule_003E.smethod_7<string>(471458516u), PartyDescription);
		stringBuilder.AppendFormat(global::_003CModule_003E.smethod_7<string>(3107932997u), CreatorAccountName);
		stringBuilder.AppendFormat(global::_003CModule_003E.smethod_6<string>(2893052801u), Unknown_4C);
		foreach (PartyMember partyMember in PartyMembers)
		{
			stringBuilder.AppendFormat(global::_003CModule_003E.smethod_8<string>(3094819703u), partyMember.ToString());
		}
		stringBuilder.AppendFormat(global::_003CModule_003E.smethod_7<string>(3103404089u), PartyAllocation.ToString());
		return stringBuilder.ToString();
	}
}
