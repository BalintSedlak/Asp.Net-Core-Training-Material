using DDD.ShipBooking.Models;
using DDD.ShipBooking.Solutions.NonDDD.Policies;

namespace DDD.ShipBooking.Solutions.DDD;

public class Booking_NonDDD
{
    public int MakeBooking(Cargo cargo, Voyage voyage)
    {
        double maxBooking = voyage.Capacity() * 1.1;
        if ((voyage.BookedCargoSize() + cargo.Size()) > maxBooking)
        { 
            return -1;        
        }

        int confirmationNumber = OrderConfirmationService.Confirm();
        voyage.addCargo(cargo, confirmationNumber);
        return confirmationNumber;
    }
}
