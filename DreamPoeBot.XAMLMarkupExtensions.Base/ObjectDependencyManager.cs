using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DreamPoeBot.XAMLMarkupExtensions.Base;

internal static class ObjectDependencyManager
{
	private static Dictionary<object, List<WeakReference>> dictionary_0 = new Dictionary<object, List<WeakReference>>();

	[MethodImpl(MethodImplOptions.Synchronized)]
	public static bool AddObjectDependency(WeakReference weakRefDp, object objToHold)
	{
		CleanUp();
		if (objToHold == null)
		{
			throw new ArgumentNullException(global::_003CModule_003E.smethod_9<string>(3703207294u), global::_003CModule_003E.smethod_9<string>(107199554u));
		}
		if (objToHold.GetType() == typeof(WeakReference))
		{
			throw new ArgumentException(global::_003CModule_003E.smethod_5<string>(2428557931u), global::_003CModule_003E.smethod_9<string>(3703207294u));
		}
		if (weakRefDp.Target == objToHold)
		{
			throw new InvalidOperationException(global::_003CModule_003E.smethod_6<string>(193827176u));
		}
		bool result = false;
		if (!dictionary_0.ContainsKey(objToHold))
		{
			List<WeakReference> value = new List<WeakReference> { weakRefDp };
			dictionary_0.Add(objToHold, value);
			result = true;
		}
		else
		{
			List<WeakReference> list = dictionary_0[objToHold];
			if (!list.Contains(weakRefDp))
			{
				list.Add(weakRefDp);
				result = true;
			}
		}
		return result;
	}

	public static void CleanUp()
	{
		CleanUp(null);
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	public static void CleanUp(object objToRemove)
	{
		if (objToRemove == null)
		{
			List<object> list = new List<object>();
			foreach (KeyValuePair<object, List<WeakReference>> item in dictionary_0)
			{
				for (int num = item.Value.Count - 1; num >= 0; num--)
				{
					if (item.Value[num].Target == null)
					{
						item.Value.RemoveAt(num);
					}
				}
				if (item.Value.Count == 0)
				{
					list.Add(item.Key);
				}
			}
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				dictionary_0.Remove(list[num2]);
			}
			list.Clear();
		}
		else if (!dictionary_0.Remove(objToRemove))
		{
			throw new Exception(global::_003CModule_003E.smethod_6<string>(1433719131u));
		}
	}
}
