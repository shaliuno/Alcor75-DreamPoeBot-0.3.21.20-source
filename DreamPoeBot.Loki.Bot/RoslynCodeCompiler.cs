using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using Microsoft.CodeDom.Providers.DotNetCompilerPlatform;

namespace DreamPoeBot.Loki.Bot;

public class RoslynCodeCompiler
{
	public static CodeDomProvider CreateLatestCSharpProvider()
	{
		return smethod_0(10);
	}

	internal static CodeDomProvider smethod_0(int int_0)
	{
		string text = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), global::_003CModule_003E.smethod_5<string>(3334517158u));
		string text2 = Path.Combine(text, global::_003CModule_003E.smethod_6<string>(1189837684u));
		if (!Directory.Exists(text) || !File.Exists(text2))
		{
			throw new FileNotFoundException(global::_003CModule_003E.smethod_7<string>(3518592687u));
		}
		return (CodeDomProvider)(object)smethod_2(smethod_1(text2, int_0));
	}

	private static object smethod_1(string string_0, int int_0)
	{
		return typeof(CSharpCodeProvider).Assembly.GetType(global::_003CModule_003E.smethod_7<string>(3234708894u)).GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new Type[2]
		{
			typeof(string),
			typeof(int)
		}, null).Invoke(new object[2] { string_0, int_0 });
	}

	private static CSharpCodeProvider smethod_2(object object_0)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		Type type = object_0.GetType();
		Type typeFromHandle = typeof(CSharpCodeProvider);
		typeFromHandle.GetConstructors();
		ConstructorInfo constructor = typeFromHandle.GetConstructor(new Type[1] { type });
		if (constructor != null)
		{
			return (CSharpCodeProvider)constructor.Invoke(new object[1] { object_0 });
		}
		((RoslynCodeCompiler)(object)typeof(CSharpCodeProvider)).method_0(BindingFlags.Instance | BindingFlags.NonPublic, (Binder)null, new Type[0], (ParameterModifier[])null);
		ConstructorInfo constructorInfo = ((RoslynCodeCompiler)(object)typeof(CSharpCodeProvider)).method_0(BindingFlags.Instance | BindingFlags.NonPublic, (Binder)null, new Type[1] { type }, (ParameterModifier[])null);
		if (constructorInfo != null)
		{
			return (CSharpCodeProvider)constructorInfo.Invoke(new object[1] { object_0 });
		}
		return null;
	}

	ConstructorInfo method_0(BindingFlags bindingFlags_0, Binder binder_0, Type[] type_0, ParameterModifier[] parameterModifier_0)
	{
		return ((Type)this).GetConstructor(bindingFlags_0, binder_0, type_0, parameterModifier_0);
	}
}
