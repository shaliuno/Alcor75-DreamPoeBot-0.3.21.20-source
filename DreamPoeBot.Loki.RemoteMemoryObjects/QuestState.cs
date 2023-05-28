using DreamPoeBot.Loki.Controllers;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class QuestState : RemoteMemoryObject
{
	public long QuestPtr => base.M.ReadLong(base.Address);

	public Quest Quest => GameController.Instance.Files.Quests.GetByAddress(QuestPtr);

	public int QuestStateId => base.M.ReadInt(base.Address + 16L);

	public int TestOffset => base.M.ReadInt(base.Address + 20L);

	public string QuestStateText => base.M.ReadStringU(base.M.ReadLong(base.Address + 52L));

	public string QuestProgressText => base.M.ReadStringU(base.M.ReadLong(base.Address + 61L));

	public override string ToString()
	{
		return string.Format(global::_003CModule_003E.smethod_6<string>(2366246934u), QuestStateId, Quest.Id, QuestProgressText, Quest.Name);
	}
}
