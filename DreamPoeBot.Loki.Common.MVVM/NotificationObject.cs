using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows;
using JetBrains.Annotations;

namespace DreamPoeBot.Loki.Common.MVVM;

public class NotificationObject : INotifyPropertyChanged
{
	[CompilerGenerated]
	private sealed class UnckowClass<T>
	{
		public string propertyName;

		public NotificationObject UnknowNotificationOject;

		internal void unknowInternalMethod()
		{
			UnknowNotificationOject.PropertyChanged?.Invoke(UnknowNotificationOject, smethod_0(propertyName));
		}

		static PropertyChangedEventArgs smethod_0(string string_0)
		{
			return new PropertyChangedEventArgs(string_0);
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	private static string OnPropertyChanged<T>(Expression<Func<T>> expression1)
	{
		if (expression1.NodeType != ExpressionType.Lambda)
		{
			throw new ArgumentException(global::_003CModule_003E.smethod_6<string>(1314758537u), global::_003CModule_003E.smethod_9<string>(423868800u));
		}
		if (!(expression1.Body is MemberExpression))
		{
			throw new ArgumentException(global::_003CModule_003E.smethod_6<string>(4054539807u), global::_003CModule_003E.smethod_5<string>(2530345941u));
		}
		return ((MemberExpression)expression1.Body).Member.Name;
	}

	[NotifyPropertyChangedInvocator]
	protected void NotifyPropertyChanged<TExp>(Expression<Func<TExp>> expression)
	{
		string propertyName = OnPropertyChanged(expression);
		if (Application.Current != null)
		{
			Application.Current.Dispatcher.BeginInvoke((Action)delegate
			{
				this.PropertyChanged?.Invoke(this, UnckowClass<TExp>.smethod_0(propertyName));
			});
		}
	}
}
