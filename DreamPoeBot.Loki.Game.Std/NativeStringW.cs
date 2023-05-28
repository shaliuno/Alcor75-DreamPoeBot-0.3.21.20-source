using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace DreamPoeBot.Loki.Game.Std;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NativeStringW : IEquatable<NativeStringW>
{
	[StructLayout(LayoutKind.Sequential, Size = 16)]
	[CompilerGenerated]
	[UnsafeValueType]
	public struct Bufe__FixedBuffer
	{
		public unsafe fixed char FixedElementField[8];
	}

	public Bufe__FixedBuffer Buf;

	public readonly uint Size;

	public readonly uint Sizeunused;

	public readonly uint ReservedSize;

	public readonly uint ReservedSizeunused;

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(global::_003CModule_003E.smethod_5<string>(3654388488u), DreamPoeBot.Loki.MarshalCache<NativeStringW>.Size));
		return stringBuilder.ToString();
	}

	public unsafe bool Equals(NativeStringW other)
	{
		if (ReservedSize != other.ReservedSize)
		{
			return false;
		}
		if (Size == other.Size)
		{
			if (8 > ReservedSize)
			{
				fixed (char* ptr = Buf.FixedElementField)
				{
					char** ptr2 = (char**)ptr;
					char* ptr3 = (char*)ptr2;
					for (int i = 0; i < Size; i++)
					{
						if (!ptr3[i].Equals(other.Buf.FixedElementField[i]))
						{
							return false;
						}
					}
				}
				return true;
			}
			fixed (char* ptr4 = Buf.FixedElementField)
			{
				char** ptr5 = (char**)ptr4;
				int num = *(int*)ptr5;
				char* ptr6 = other.Buf.FixedElementField;
				int obj = *(int*)(&ptr6);
				return num.Equals(obj);
			}
		}
		return false;
	}
}
