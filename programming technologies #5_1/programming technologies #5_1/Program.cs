// Proxy

public interface IService
{
	void Execute();
}
public class RealService : IService
{
	public void Execute()
	{
		Console.WriteLine("RealService: Выполнение операции.");
	}
}
public class ProxyService : IService
{
	private RealService _realService;

	public void Execute()
	{
		if (_realService == null)
		{
			_realService = new RealService();
		}
		Console.WriteLine("ProxyService: Проверка доступа перед выполнением RealService.");
		_realService.Execute();
	}
}
class Program
{
	static void Main(string[] args)
	{
		IService service = new ProxyService();
		service.Execute();
	}
}
