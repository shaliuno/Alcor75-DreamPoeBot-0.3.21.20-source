using DreamPoeBot.Common;

namespace DreamPoeBot.Loki.Common;

public struct Sphere
{
	public Vector3 Center;

	public float Radius;

	public Sphere(Vector3 center, float radius)
	{
		Center = center;
		Radius = radius;
	}

	public override string ToString()
	{
		return string.Format(global::_003CModule_003E.smethod_6<string>(3203044514u), Center, Radius);
	}
}
