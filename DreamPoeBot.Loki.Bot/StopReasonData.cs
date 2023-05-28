using System;

namespace DreamPoeBot.Loki.Bot;

public class StopReasonData
{
	public object Context { get; private set; }

	public string Id { get; private set; }

	public string Reason { get; private set; }

	public StopReasonData(string id, string reason = "", object context = null)
	{
		if (string.IsNullOrEmpty(id))
		{
			throw new ArgumentException(global::_003CModule_003E.smethod_5<string>(2237982762u), global::_003CModule_003E.smethod_5<string>(1951416851u));
		}
		if (reason == null)
		{
			reason = "";
		}
		Id = id;
		Reason = reason;
		Context = context;
	}
}
