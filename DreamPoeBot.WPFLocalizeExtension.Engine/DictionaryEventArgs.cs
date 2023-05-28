using System;

namespace DreamPoeBot.WPFLocalizeExtension.Engine;

internal class DictionaryEventArgs : EventArgs
{
	public DictionaryEventType Type { get; private set; }

	public object Tag { get; private set; }

	public DictionaryEventArgs(DictionaryEventType type, object tag)
	{
		Type = type;
		Tag = tag;
	}

	public override string ToString()
	{
		return Type.ToString() + global::_003CModule_003E.smethod_9<string>(955102718u) + Tag;
	}
}
