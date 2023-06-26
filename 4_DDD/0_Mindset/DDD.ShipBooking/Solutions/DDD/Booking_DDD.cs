using DDD.ShipBooking.Models;
using DDD.ShipBooking.Solutions.DDD.Policies;

namespace DDD.ShipBooking.Solutions.DDD;

public class Booking
{
    public int MakeBooking(Cargo cargo, Voyage voyage)
    {
        if (!OverbookingPolicy.isAllowed(cargo, voyage))
        {
            return -1;
        }

        int confirmationNumber = OrderConfirmationService.Confirm();
        voyage.addCargo(cargo, confirmationNumber);
        return confirmationNumber;
    }
}
