using System.ComponentModel;

namespace DreamPoeBot.DreamPoe;

public class PremiumContentClass : INotifyPropertyChanged
{
	private string id;

	private string name;

	private bool enabled;

	public string Id
	{
		get
		{
			return id;
		}
		set
		{
			id = value;
			RaisePropertyChanged(global::_003CModule_003E.smethod_8<string>(3301168853u));
		}
	}

	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
			RaisePropertyChanged(global::_003CModule_003E.smethod_6<string>(2385786134u));
		}
	}

	public bool Enabled
	{
		get
		{
			return enabled;
		}
		set
		{
			enabled = value;
			RaisePropertyChanged(global::_003CModule_003E.smethod_8<string>(305268791u));
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void RaisePropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
