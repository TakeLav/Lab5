// Brige

public interface IDrawingAPI
{
	void DrawCircle(double x, double y, double radius);
}
public abstract class Shape
{
	protected IDrawingAPI _drawingAPI;

	protected Shape(IDrawingAPI drawingAPI)
	{
		_drawingAPI = drawingAPI;
	}

	public abstract void Draw();
	public abstract void Resize(float percentage);
}
public class DrawingAPI1 : IDrawingAPI
{
	public void DrawCircle(double x, double y, double radius)
	{
		Console.WriteLine($"DrawingAPI1. круг ({x}, {y}) с радиусом {radius}");
	}
}

public class DrawingAPI2 : IDrawingAPI
{
	public void DrawCircle(double x, double y, double radius)
	{
		Console.WriteLine($"DrawingAPI2. круг ({x}, {y}) с радиусом {radius}");
	}
}
public class Circle : Shape
{
	private double _x, _y, _radius;

	public Circle(double x, double y, double radius, IDrawingAPI drawingAPI)
		: base(drawingAPI)
	{
		_x = x;
		_y = y;
		_radius = radius;
	}

	public override void Draw()
	{
		_drawingAPI.DrawCircle(_x, _y, _radius);
	}

	public override void Resize(float percentage)
	{
		_radius *= percentage;
	}
}
class Program
{
	static void Main(string[] args)
	{
		Shape[] shapes = new Shape[]
		{
			new Circle(5, 10, 2, new DrawingAPI1()),
			new Circle(20, 30, 5, new DrawingAPI2())
		};

		foreach (Shape shape in shapes)
		{
			shape.Draw();
			shape.Resize(2);
			shape.Draw();
		}
	}
}