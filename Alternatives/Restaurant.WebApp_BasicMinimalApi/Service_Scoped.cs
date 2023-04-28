namespace Restaurant.WebApp_BasicMinimalApi;

public class Service_Scoped : IService
{
    public int Sum(int a, int b)
    {
        return a + b;
    }

    public string IsItDog()
    {
        Random rnd = new Random();

        if (rnd.Next(2) % 2 == 0)
        {
            return @"Yes, it's a dog";
        }

        return @"No, it's a cat";
    }
}
