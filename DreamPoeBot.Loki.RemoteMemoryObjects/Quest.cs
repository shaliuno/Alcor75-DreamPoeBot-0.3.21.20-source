namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class Quest : RemoteMemoryObject
{
	private string id;

	private string name;

	public string Id
	{
		get
		{
			if (id == null)
			{
				return id = base.M.ReadStringU(base.M.ReadLong(base.Address), 255);
			}
			return id;
		}
	}

	public int Act => base.M.ReadInt(base.Address + 8L);

	public string Name
	{
		get
		{
			if (name == null)
			{
				return name = base.M.ReadStringU(base.M.ReadLong(base.Address + 12L));
			}
			return name;
		}
	}

	public string Icon => base.M.ReadStringU(base.M.ReadLong(base.Address + 20L));

	public override string ToString()
	{
		return global::_003CModule_003E.smethod_9<string>(2764637623u) + Id + global::_003CModule_003E.smethod_9<string>(3967763229u) + Name;
	}
}
