namespace RestaurantGoal.Example.ImplicitExplicitKeyword.Models;

class Celsius : Temperature
{
    public Celsius(float temp)
    {
        Degrees = temp;
    }

    public static implicit operator Fahrenheit(Celsius c)
    {
        return new Fahrenheit(9.0f / 5.0f * c.Degrees + 32);
    }
}
