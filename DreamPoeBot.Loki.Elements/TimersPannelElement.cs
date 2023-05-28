using System;
using System.Globalization;
using System.Linq;

namespace DreamPoeBot.Loki.Elements;

public class TimersPannelElement : Element
{
	private Element ActiveTimerElement => base.Children[0].Children.FirstOrDefault((Element x) => x.IsVisible);

	public bool IsTimerActive
	{
		get
		{
			Element element = ((ActiveTimerElement != null) ? ActiveTimerElement.Children[0] : null);
			if (element == null)
			{
				return false;
			}
			return element.Text != global::_003CModule_003E.smethod_5<string>(1414744189u);
		}
	}

	public TimeSpan Timer
	{
		get
		{
			if (!IsTimerActive)
			{
				return TimeSpan.Parse(global::_003CModule_003E.smethod_8<string>(3141230112u));
			}
			return TimeSpan.ParseExact(ActiveTimerElement.Children[0].Text, global::_003CModule_003E.smethod_5<string>(1161331110u), CultureInfo.InvariantCulture);
		}
	}
}
