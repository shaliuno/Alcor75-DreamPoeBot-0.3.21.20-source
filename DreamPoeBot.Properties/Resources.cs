using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DreamPoeBot.Properties;

[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCode]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				ResourceManager resourceManager = new ResourceManager(global::_003CModule_003E.smethod_8<string>(1858021717u), typeof(Resources).Assembly);
				resourceMan = resourceManager;
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static string BlightStashTabLayout => ResourceManager.GetString(global::_003CModule_003E.smethod_6<string>(3397333434u), resourceCulture);

	internal static string CurrencyStashTabLayout => ResourceManager.GetString(global::_003CModule_003E.smethod_7<string>(2948154694u), resourceCulture);

	internal static string DivinationCardStashTabLayout => ResourceManager.GetString(global::_003CModule_003E.smethod_8<string>(2361557763u), resourceCulture);

	internal static string FragmentStashTabLayout => ResourceManager.GetString(global::_003CModule_003E.smethod_9<string>(2674821577u), resourceCulture);

	internal static string PantheonSouls => ResourceManager.GetString(global::_003CModule_003E.smethod_8<string>(3438678784u), resourceCulture);

	internal static string StatDescription => ResourceManager.GetString(global::_003CModule_003E.smethod_9<string>(4046002533u), resourceCulture);

	internal Resources()
	{
	}
}
