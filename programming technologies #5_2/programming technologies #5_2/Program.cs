// Adapter

public interface ITarget
{
	void Request();
}
public class Target : ITarget
{
	public void Request()
	{
		Console.WriteLine("Target: Обработка запроса.");
	}
}
public class Adaptee
{
	public void SpecificRequest()
	{
		Console.WriteLine("Adaptee: Обработка конкретного запроса.");
	}
}
public class Adapter : ITarget
{
	private readonly Adaptee _adaptee;

	public Adapter(Adaptee adaptee)
	{
		_adaptee = adaptee;
	}

	public void Request()
	{
		Console.WriteLine("Adapter: Адаптация запроса к конкретному запросу.");
		_adaptee.SpecificRequest();
	}
}
class Program
{
	static void Main(string[] args)
	{
		ITarget target = new Target();
		target.Request();

		Adaptee adaptee = new Adaptee();
		ITarget adapter = new Adapter(adaptee);
		adapter.Request();
	}
}