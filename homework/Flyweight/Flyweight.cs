// Flyweight interface
interface IGeometry
{
	void GetShape();
	void GetColor(int size);
}

// ConcreteFlyweight
class Rectangle : IGeometry
{
	public void GetShape()
		=> Console.WriteLine("This is a Rectangle Shape Object...");

	public void GetColor(int length)
	{
		if (length < 5)
			Console.WriteLine("Rectangle is Filled with PURPLE color...\n");
		else
			Console.WriteLine("Rectangle is Filled with WHITE color...\n");
	}
}

// ConcreteFlyweight
class Square : IGeometry
{
	public void GetShape()
		=> Console.WriteLine("This is a Square Shape Object...");
	
	public void GetColor(int length)
	{
		if (length < 5)
			Console.WriteLine("Square is Filled with BLACK color...\n");
		else
			Console.WriteLine("Square is Filled with GREEN color...\n");
	}
}

// FlyweightFactory
class GeometryFactory
{
	Dictionary<string, IGeometry> geometries = new Dictionary<string, IGeometry>();

	public int ObjectCount()
		=> geometries.Count;
	
	public IGeometry getGeometryObject(string name)
	{
		IGeometry geometry;

		if (geometries.ContainsKey(name))
			return geometries[name];
		else
		{
			if (name == "Rectangle")
			{
				geometry = new Rectangle();
				geometries.Add("Rectangle", geometry);
			}
			else if (name == "Square")
			{
				geometry = new Square();
				geometries.Add("Square", geometry);
			}
			else
				throw new Exception("This Type of Object Can Not Be Created...");
		}

		return geometry;
	}
}


class Program
{
	static void Main()
	{
		GeometryFactory geometryFactory = new GeometryFactory();

		Console.WriteLine("-------------- Object Details-----------------");
		IGeometry geometry = geometryFactory.getGeometryObject("Rectangle");
		geometry.GetShape();
		geometry.GetColor(9);
		Console.WriteLine("-------------- Object Details-----------------");
		geometry = geometryFactory.getGeometryObject("Rectangle");
		geometry.GetShape();
		geometry.GetColor(3);
		Console.WriteLine("-------------- Object Details-----------------");
		geometry = geometryFactory.getGeometryObject("Square");
		geometry.GetShape();
		geometry.GetColor(9);
		Console.WriteLine("-------------- Object Details-----------------");
		geometry = geometryFactory.getGeometryObject("Square");
		geometry.GetShape();
		geometry.GetColor(3);
		Console.WriteLine("-------------- Object Count-----------------");
		int ObjectCount = geometryFactory.ObjectCount();
		Console.WriteLine("Total objects created: " + ObjectCount);
	}
}