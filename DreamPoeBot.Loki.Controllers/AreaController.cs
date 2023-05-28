using System;
using DreamPoeBot.Loki.Bot.Pathfinding;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using DreamPoeBot.PathfindingClient;

namespace DreamPoeBot.Loki.Controllers;

public class AreaController
{
	public AreaInstance CurrentArea { get; private set; }

	public event Action<AreaController> OnAreaChange;

	public AreaController()
	{
		RDClient.Initialize();
	}

	public void RefreshState()
	{
		IngameData data = GameController.Instance.Game.IngameState.Data;
		AreaTemplate currentArea = GameController.Instance.Game.IngameState.Data.CurrentArea;
		AreaMap currentAreaMap = GameController.Instance.Game.IngameState.CurrentAreaMap;
		uint currentAreaHash = GameController.Instance.Game.IngameState.Data.CurrentAreaHash;
		if (CurrentArea == null || currentAreaHash != CurrentArea.Hash)
		{
			CurrentArea = new AreaInstance(currentArea, currentAreaMap, currentAreaHash, data.CurrentAreaLevel);
			ExilePather.Reload();
			this.OnAreaChange?.Invoke(this);
		}
	}
}
