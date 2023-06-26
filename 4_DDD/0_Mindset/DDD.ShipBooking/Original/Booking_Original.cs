using DDD.ShipBooking.Models;

namespace DDD.ShipBooking.Original;

public class Booking_Original
{
    public int MakeBooking(Cargo cargo, Voyage voyage)
    {
        int confirmationNumber = OrderConfirmationService.Confirm();
        voyage.addCargo(cargo, confirmationNumber);
        return confirmationNumber;
    }
}
