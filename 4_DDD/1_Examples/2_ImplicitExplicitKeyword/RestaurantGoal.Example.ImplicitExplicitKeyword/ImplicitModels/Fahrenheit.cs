namespace RestaurantGoal.Example.ImplicitExplicitKeyword.Models;

class Fahrenheit : Temperature
{
    public Fahrenheit(float temp)
    {
        Degrees = temp;
    }

    public static implicit operator Celsius(Fahrenheit fahr)
    {
        return new Celsius(5.0f / 9.0f * (fahr.Degrees - 32));
    }
}