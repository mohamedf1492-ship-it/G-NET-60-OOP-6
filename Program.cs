namespace oop6
{

    #region part2
    /*
    enum TicketType
    {
        Standard,
        VIP,
        IMAX
    }

    struct SeatLocation
    {
        public char Row { get; set; }
        public int Number { get; set; }

        public SeatLocation(char row, int number)
        {
            Row = row;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Row}-{Number}";
        }
    }

    class Ticket
    {
        private static int ticketCounter = 0;

        private string movieName = "Unknown";
        private double price = 50;

        public int TicketId { get; }

        public string MovieName
        {
            get { return movieName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    movieName = value;
            }
        }

        public TicketType Type { get; set; }

        public SeatLocation Seat { get; set; }

        public double Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                    price = value;
            }
        }

        public double PriceAfterTax
        {
            get { return Price * 1.14; }
        }

        public Ticket()
        {
            TicketId = ++ticketCounter;
        }

        public static int GetTotalTicketsSold()
        {
            return ticketCounter;
        }
    }

    class Cinema
    {
        private Ticket[] tickets = new Ticket[20];

        public Ticket this[int index]
        {
            get
            {
                if (index >= 0 && index < tickets.Length)
                    return tickets[index];

                return null;
            }
            set
            {
                if (index >= 0 && index < tickets.Length)
                    tickets[index] = value;
            }
        }

        public Ticket GetMovieByName(string movieName)
        {
            foreach (Ticket ticket in tickets)
            {
                if (ticket != null &&
                    ticket.MovieName.Equals(
                        movieName,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return ticket;
                }
            }

            return null;
        }

        public bool AddTicket(Ticket t)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i] == null)
                {
                    tickets[i] = t;
                    return true;
                }
            }

            return false;
        }
    }

    static class BookingHelper
    {
        private static int referenceCounter = 0;

        public static double CalcGroupDiscount(
            int numberOfTickets, double pricePerTicket)
        {
            double total = numberOfTickets * pricePerTicket;

            if (numberOfTickets >= 5)
                total *= 0.90;

            return total;
        }

        public static string GenerateBookingReference()
        {
            referenceCounter++;
            return $"BK-{referenceCounter}";
        }
    }
    */
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            #region part1

            //Q1
            /*
            Abstraction: Hiding unnecessary implementation details and showing only the essential features of an object.

            Encapsulation: Hiding an object's internal data and controlling access to it through methods or properties.

            Difference: Abstraction focuses on what an object does, while encapsulation focuses on protecting
            its internal data and controlling how it is accessed.

            Real-world example: A car provides a steering wheel and pedals to control movement without requiring the driver 
            to understand the engine's internal operation. This is abstraction.
            Keeping the engine's internal components protected and allowing controlled interaction with them represents encapsulation.
            */

            //Q2
            /*
            .Abstract Class 
            ..Can contain fields and state.
            ..Can have constructors.
            ..Can contain abstract, virtual, and concrete methods.
            ..A class can inherit from only one base class.
            ..Can contain access modifiers such as protected.

            .Interface
            ..Mainly defines a contract; it can also provide certain default implementations.
            ..Cannot have instance constructors.
            ..Defines members that implementing types must satisfy, and may provide default implementations.
            ..A class can implement multiple interfaces.
            ..Interface members are generally public contracts, with some language-supported exceptions.

            .........
            Choose an abstract class when related classes share common data, implementation, or behavior.

            Choose an interface when different classes need to follow the same
            contract without sharing a common base-class implementation.
            */

            //Q3
            /*
            a) Can you write Appliance a = new Appliance("LG");? Why or why not?

            No. Appliance is an abstract class, so it cannot be instantiated directly. 
            We must create an object of a concrete derived class, such as WashingMachine or Toaster.

            b) What is the difference between PowerConsumption(), Status(), and Label()? Why was each declared abstract,
            virtual, or concrete?

            PowerConsumption() is abstract because every derived appliance must provide its own power-consumption value.

            Status() is virtual because it provides a default value, "Standby", which a derived class can override.

            Label() is a concrete method because it provides shared behavior that uses the brand and power consumption to produce a label.

            c) If you call Status() on a Toaster object, what will it return? Why?

            It returns "Standby" because Toaster does not override the Status() method,
            so the inherited implementation from Appliance is used.

            */

            //Q4
            /*
            a)
            A partial class allows one class definition to be divided across multiple files using the partial keyword.
            The files are combined into one class during compilation.

            The developer splits Calculator to organize the main calculation logic separately from the logging functionality,
            making the code easier to maintain.

            b)
            A partial method is a method declared in one part of a partial class and optionally implemented in another part.

            In this example, if the implementation is deleted, the code still compiles. 
            Because OnCalculated() is declared as a void partial method without an explicit access modifier, it is optional,
            and calls to it are removed when no implementation exists.

            c)
            An extension method allows us to call a static method as if it were an instance method of an existing type,
            without modifying that type's source code.

           ..The three rules are:

            ..It must be defined inside a static class.

            ..The extension method itself must be static.

            ..Its first parameter must use the this keyword followed by the type being extended.

            d)
            Output:

             Log: result = 20
             $20.00

            */


            #endregion

            #region part2
            /*
             Cinema cinema = new Cinema();

            Console.WriteLine("========== Ticket Booking ==========");

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"\nEnter data for Ticket {i}:");

                Ticket ticket = new Ticket();

                Console.Write("Movie Name: ");
                ticket.MovieName = Console.ReadLine();

                Console.Write("Ticket Type (0=Standard, 1=VIP, 2=IMAX): ");
                int type = int.Parse(Console.ReadLine());

                if (type >= 0 && type <= 2)
                    ticket.Type = (TicketType)type;
                else
                    ticket.Type = TicketType.Standard;

                Console.Write("Seat Row (A-Z): ");
                char row = char.ToUpper(
                    Console.ReadLine()[0]);

                Console.Write("Seat Number: ");
                int number = int.Parse(Console.ReadLine());

                ticket.Seat = new SeatLocation(row, number);

                Console.Write("Price: ");
                ticket.Price = double.Parse(Console.ReadLine());

                if (cinema.AddTicket(ticket))
                    Console.WriteLine("Ticket added successfully.");
                else
                    Console.WriteLine("Cinema is full.");
            }

            Console.WriteLine("\n========== All Tickets ==========");

            for (int i = 0; i < 3; i++)
            {
                Ticket ticket = cinema[i];

                if (ticket != null)
                {
                    Console.WriteLine(
                        $"Ticket #{ticket.TicketId} | " +
                        $"{ticket.MovieName} | {ticket.Type} | " +
                        $"Seat: {ticket.Seat} | " +
                        $"Price: {ticket.Price:F2} EGP | " +
                        $"After Tax: {ticket.PriceAfterTax:F2} EGP");
                }
            }

            Console.Write("\nEnter movie name to search: ");
            string searchName = Console.ReadLine();

            Ticket found = cinema.GetMovieByName(searchName);

            if (found != null)
            {
                Console.WriteLine(
                    $"Found: {found.MovieName} | " +
                    $"{found.Type} | Seat: {found.Seat}");
            }
            else
            {
                Console.WriteLine("Movie not found.");
            }

            Console.WriteLine(
                $"\nTotal Tickets Sold: {Ticket.GetTotalTicketsSold()}");

            Console.WriteLine(
                $"Booking Reference 1: {BookingHelper.GenerateBookingReference()}");

            Console.WriteLine(
                $"Booking Reference 2: {BookingHelper.GenerateBookingReference()}");

            double groupTotal =
                BookingHelper.CalcGroupDiscount(5, 80);

            Console.WriteLine(
                $"Group Discount Total (5 tickets): {groupTotal:F2} EGP");
            */
            #endregion


        }
    }
}
