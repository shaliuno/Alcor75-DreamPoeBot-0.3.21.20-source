using System;

namespace DreamPoeBot.Loki.Elements;

public class WatchStoneTooltipElement : Element
{
	public class WatchStoneInfo : Element
	{
		public bool IsObatained
		{
			get
			{
				if (!string.IsNullOrEmpty(base.Children[1].Text))
				{
					return base.Children[1].Text == global::_003CModule_003E.smethod_5<string>(1393400934u);
				}
				return false;
			}
		}

		public bool CanObatain
		{
			get
			{
				if (!string.IsNullOrEmpty(base.Children[2].Text))
				{
					return base.Children[2].Text != global::_003CModule_003E.smethod_9<string>(2436856914u);
				}
				return false;
			}
		}

		public bool ConquerorInCitadel
		{
			get
			{
				if (!string.IsNullOrEmpty(base.Children[2].Text))
				{
					return base.Children[2].Text != global::_003CModule_003E.smethod_5<string>(853421944u);
				}
				return false;
			}
		}

		public int RequiredWatchstone
		{
			get
			{
				string text = base.Children[2].Text;
				if (string.IsNullOrEmpty(text))
				{
					return 0;
				}
				if (text == global::_003CModule_003E.smethod_6<string>(1544568628u))
				{
					return 0;
				}
				if (!(text == global::_003CModule_003E.smethod_5<string>(853421944u)))
				{
					string oldValue = global::_003CModule_003E.smethod_8<string>(15637501u);
					string oldValue2 = global::_003CModule_003E.smethod_8<string>(2759769540u);
					string text2 = text.Replace(oldValue, "");
					string value = text2.Replace(oldValue2, "");
					return Convert.ToInt32(value);
				}
				return 0;
			}
		}
	}

	public WatchStoneInfo Red => base.M.GetObject<WatchStoneInfo>(base.Children[0].Address);

	public WatchStoneInfo Green => base.M.GetObject<WatchStoneInfo>(base.Children[1].Address);

	public WatchStoneInfo Blue => base.M.GetObject<WatchStoneInfo>(base.Children[2].Address);

	public WatchStoneInfo Yellow => base.M.GetObject<WatchStoneInfo>(base.Children[3].Address);
}
