using System.Diagnostics;
using System.Threading;

namespace DreamPoeBot.Loki.Elements;

public class PoeChatElement : Element
{
	internal Element CurrentMessageElement
	{
		get
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			while (true)
			{
				if (base.ChildCount < 4L)
				{
					if (stopwatch.ElapsedMilliseconds > 1000L)
					{
						break;
					}
					Thread.Sleep(30);
					continue;
				}
				return base.Children[3];
			}
			return null;
		}
	}
}
