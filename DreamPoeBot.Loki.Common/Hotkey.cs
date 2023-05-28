using System;
using System.Windows.Forms;

namespace DreamPoeBot.Loki.Common;

public class Hotkey : IEquatable<Hotkey>
{
	public Action<Hotkey> Callback { get; set; }

	public int Id { get; private set; }

	public Keys Key { get; private set; }

	public ModifierKeys ModifierKeys { get; private set; }

	public string Name { get; private set; }

	internal bool IsRegistered { get; set; }

	internal Hotkey(string name, Keys key, ModifierKeys modifierKeys, int id, Action<Hotkey> callback)
	{
		Name = name;
		Key = key;
		ModifierKeys = modifierKeys;
		Id = id;
		Callback = callback;
	}

	public override string ToString()
	{
		return Name + global::_003CModule_003E.smethod_6<string>(618461955u) + method_0() + global::_003CModule_003E.smethod_5<string>(1784353606u);
	}

	private string method_0()
	{
		string text = "";
		if (ModifierKeys.HasFlag(ModifierKeys.Control))
		{
			text += global::_003CModule_003E.smethod_9<string>(3464300756u);
		}
		if (ModifierKeys.HasFlag(ModifierKeys.Alt))
		{
			text += global::_003CModule_003E.smethod_7<string>(1542859637u);
		}
		if (ModifierKeys.HasFlag(ModifierKeys.Shift))
		{
			text += global::_003CModule_003E.smethod_6<string>(1919610880u);
		}
		return text + Key;
	}

	public bool Equals(Hotkey other)
	{
		if (other != null)
		{
			if (Id == other.Id)
			{
				return string.Equals(Name, other.Name);
			}
			return false;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((Hotkey)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (Id * 397) ^ ((Name != null) ? Name.GetHashCode() : 0);
	}

	public static bool operator ==(Hotkey left, Hotkey right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Hotkey left, Hotkey right)
	{
		return !object.Equals(left, right);
	}
}
