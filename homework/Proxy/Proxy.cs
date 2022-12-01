interface IImage
{
	void DisplayImage();
}


class RealImage : IImage
{
	private string Filename { get; set; }

	public RealImage(string filename)
	{
		Filename = filename;
		LoadImageFromDisk();
	}

	public void LoadImageFromDisk()
		=> Console.WriteLine("Loading Image : " + Filename);

	public void DisplayImage()
		=> Console.WriteLine("Displaying Image : " + Filename);
}


class ProxyImage : IImage
{
	private RealImage? realImage = null;

	private string Filename { get; set; }
	
	public ProxyImage(string filename)
		=> Filename = filename;
	
	public void DisplayImage()
	{
		if (realImage == null)
			realImage = new RealImage(Filename);
		
		realImage.DisplayImage();
	}
}


/*class Program
{
	static void Main()
	{
		IImage Image1 = new ProxyImage("Wolf Image");
		Console.WriteLine("Image1 calling DisplayImage first time :");
		Image1.DisplayImage(); // loading necessary
		Console.WriteLine("Image1 calling DisplayImage second time :");
		Image1.DisplayImage(); // loading unnecessary
		Console.WriteLine("Image1 calling DisplayImage third time :");
		Image1.DisplayImage(); // loading unnecessary

		Console.WriteLine();

		IImage Image2 = new ProxyImage("Horse Image");
		Console.WriteLine("Image2 calling DisplayImage first time :");
		Image2.DisplayImage(); // loading necessary
		Console.WriteLine("Image2 calling DisplayImage second time :");
		Image2.DisplayImage(); // loading unnecessary
	}
}*/