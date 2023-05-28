using DreamPoeBot.Loki.Components;

namespace DreamPoeBot.Loki.Models;

public class EntityWrapper : Entity
{
	private readonly bool _isInList = true;

	public bool IsAlive => GetComponent<Life>().Health > 0;

	public EntityWrapper()
	{
	}

	public EntityWrapper(long address)
		: base(address)
	{
	}

	public override bool Equals(object obj)
	{
		EntityWrapper entityWrapper = obj as EntityWrapper;
		if (entityWrapper != null)
		{
			return entityWrapper.Id == base.Id;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.Id.GetHashCode();
	}

	public override string ToString()
	{
		return global::_003CModule_003E.smethod_7<string>(669463945u) + base.Metadata;
	}
}
