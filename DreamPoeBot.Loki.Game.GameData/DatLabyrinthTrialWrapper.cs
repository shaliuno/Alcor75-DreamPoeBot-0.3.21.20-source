using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatLabyrinthTrialWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct313
	{
		public Struct243 struct243_0;

		public int int_Id;

		public int int_1;

		public int int_2;

		private Struct243 struct243_1;

		public long intptr_0;

		public long intptr_1;

		private long intptr_3;

		private long intptr_4;
	}

	public int Index { get; private set; }

	internal Memory ExternalProcessMemory_0 => LokiPoe.Memory;

	internal Struct313 Struct313_0 { get; set; }

	public int Id { get; }

	public DatWorldAreaWrapper WorldArea { get; }

	internal DatLabyrinthTrialWrapper(Struct313 native, int index)
	{
		Struct313_0 = native;
		Index = index;
		Id = Struct313_0.int_Id;
		WorldArea = Dat.GetWorldArea(Struct313_0.struct243_0.intptr_1, bool_0: true);
	}

	public override string ToString()
	{
		Struct313 struct313_ = Struct313_0;
		StringBuilder stringBuilder = new StringBuilder();
		DatWorldAreaWrapper worldArea = Dat.GetWorldArea(struct313_.struct243_0.intptr_1, bool_0: true);
		stringBuilder.AppendLine(worldArea.ToString());
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3224440940u), struct313_.int_Id));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3300744471u), struct313_.int_1));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(3048976448u), struct313_.int_2));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1639513023u), ExternalProcessMemory_0.ReadStringU(struct313_.intptr_0)));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(2379966018u), ExternalProcessMemory_0.ReadStringU(struct313_.intptr_1)));
		return stringBuilder.ToString();
	}
}
