using System.Linq;
using DreamPoeBot.Loki.FilesInMemory.Base;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.FilesInMemory;

public class LabyrinthTrials : UniversalFileWrapper<LabyrinthTrial>
{
	public static string[] LabyrinthTrialAreaIds = new string[18]
	{
		global::_003CModule_003E.smethod_9<string>(233172506u),
		global::_003CModule_003E.smethod_5<string>(4033378996u),
		global::_003CModule_003E.smethod_5<string>(556668393u),
		global::_003CModule_003E.smethod_9<string>(2115204051u),
		global::_003CModule_003E.smethod_8<string>(848909018u),
		global::_003CModule_003E.smethod_9<string>(1947148701u),
		global::_003CModule_003E.smethod_8<string>(2943507440u),
		global::_003CModule_003E.smethod_6<string>(1818917037u),
		global::_003CModule_003E.smethod_7<string>(1806174066u),
		global::_003CModule_003E.smethod_6<string>(1421617435u),
		global::_003CModule_003E.smethod_8<string>(4272396484u),
		global::_003CModule_003E.smethod_8<string>(2323795633u),
		global::_003CModule_003E.smethod_7<string>(1026506078u),
		global::_003CModule_003E.smethod_8<string>(2429566085u),
		global::_003CModule_003E.smethod_6<string>(3805415047u),
		global::_003CModule_003E.smethod_8<string>(1634034897u),
		global::_003CModule_003E.smethod_6<string>(3234575086u),
		global::_003CModule_003E.smethod_8<string>(440738115u)
	};

	public LabyrinthTrials(Memory m, long address)
		: base(m, address)
	{
	}

	public LabyrinthTrial GetLabyrinthTrialByAreaId(string id)
	{
		return base.EntriesList.FirstOrDefault((LabyrinthTrial x) => x.Area.Id == id);
	}

	public LabyrinthTrial GetLabyrinthTrialById(int index)
	{
		return base.EntriesList.FirstOrDefault((LabyrinthTrial x) => x.Id == index);
	}

	public LabyrinthTrial GetLabyrinthTrialByArea(WorldArea area)
	{
		return base.EntriesList.FirstOrDefault((LabyrinthTrial x) => x.Area == area);
	}
}
