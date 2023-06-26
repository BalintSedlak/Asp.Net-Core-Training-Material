using DDD.ShipBooking.Models;

namespace DDD.ShipBooking.Solutions.DDD.Policies;

internal class OverbookingPolicy
{
    internal static bool isAllowed(Cargo cargo, Voyage voyage)
    {
        return cargo.Size() + voyage.BookedCargoSize() <= voyage.Capacity() * 1.1;
    }
}