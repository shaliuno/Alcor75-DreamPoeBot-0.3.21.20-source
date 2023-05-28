using System.Collections.Generic;
using DreamPoeBot.Loki.FilesInMemory.Base;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.FilesInMemory;

public class QuestStates : UniversalFileWrapper<QuestState>
{
	private Dictionary<string, Dictionary<int, QuestState>> QuestStatesDictionary;

	public QuestStates(Memory m, long address)
		: base(m, address)
	{
	}

	public QuestState GetQuestState(string questId, int stateId)
	{
		if (QuestStatesDictionary == null)
		{
			CheckCache();
			List<QuestState> entriesList = base.EntriesList;
			QuestStatesDictionary = new Dictionary<string, Dictionary<int, QuestState>>();
			foreach (QuestState item in entriesList)
			{
				QuestState value2;
				if (!QuestStatesDictionary.TryGetValue(item.Quest.Id.ToLowerInvariant(), out var value))
				{
					value = new Dictionary<int, QuestState>();
					value.Add(item.QuestStateId, item);
					QuestStatesDictionary.Add(item.Quest.Id.ToLowerInvariant(), value);
				}
				else if (!value.TryGetValue(item.QuestStateId, out value2))
				{
					value.Add(item.QuestStateId, item);
				}
			}
		}
		if (QuestStatesDictionary.TryGetValue(questId.ToLowerInvariant(), out var value3) && value3.TryGetValue(stateId, out var value4))
		{
			return value4;
		}
		return null;
	}
}
