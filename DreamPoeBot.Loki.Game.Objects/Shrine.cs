using System.Text;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class Shrine : NetworkObject
{
	private PerFrameCachedValue<bool> perFrameCachedValue_5;

	private PerFrameCachedValue<string> perFrameCachedValue_6;

	private PerFrameCachedValue<string> perFrameCachedValue_7;

	private PerFrameCachedValue<string> perFrameCachedValue_8;

	public bool IsDeactivated
	{
		get
		{
			if (perFrameCachedValue_5 == null)
			{
				perFrameCachedValue_5 = new PerFrameCachedValue<bool>(method_8);
			}
			return perFrameCachedValue_5;
		}
	}

	public string ShrineId
	{
		get
		{
			if (perFrameCachedValue_6 == null)
			{
				perFrameCachedValue_6 = new PerFrameCachedValue<string>(method_9);
			}
			return perFrameCachedValue_6;
		}
	}

	public string ShrineName
	{
		get
		{
			if (perFrameCachedValue_7 == null)
			{
				perFrameCachedValue_7 = new PerFrameCachedValue<string>(method_10);
			}
			return perFrameCachedValue_7;
		}
	}

	public string ShrineDescription
	{
		get
		{
			if (perFrameCachedValue_8 == null)
			{
				perFrameCachedValue_8 = new PerFrameCachedValue<string>(method_11);
			}
			return perFrameCachedValue_8;
		}
	}

	internal Shrine(EntityWrapper entity)
		: base(entity)
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(3315202055u)));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(1500770874u), base._entity.Address));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(527081659u), base.Id));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_6<string>(2468910437u), Name));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1238770395u), base.Type));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(3276128110u), base.Position));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_8<string>(842747529u), base.Distance));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(1769281210u), ShrineId));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_7<string>(3477386905u), ShrineName));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(902266304u), ShrineDescription));
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_9<string>(34400937u), IsDeactivated));
		return stringBuilder.ToString();
	}

	private bool method_8()
	{
		return base.Components.ShrineComponent.IsDeactivated;
	}

	private string method_9()
	{
		return base.Components.ShrineComponent.ShrineId;
	}

	private string method_10()
	{
		return base.Components.ShrineComponent.ShrineName;
	}

	private string method_11()
	{
		return base.Components.ShrineComponent.ShrineDescription;
	}
}
