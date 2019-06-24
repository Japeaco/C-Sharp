using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CarHireApplication
{
    public class CarHireTest
    {
        public static void Main()
        {
            //create small and large car lists
            List<ICar> small = new List<ICar>();
            List<ICar> large = new List<ICar>();

            //add small cars to list
            small.Add(new SmallCar());
            small.Add(new SmallCar());
            small.Add(new SmallCar());
            small.Add(new SmallCar());
            small.Add(new SmallCar());
            small.Add(new SmallCar());
            small.Add(new SmallCar());
            small.Add(new SmallCar());
            small.Add(new SmallCar());
            small.Add(new SmallCar());
            small.Add(new SmallCar());
            small.Add(new SmallCar());
            small.Add(new SmallCar());
            small.Add(new SmallCar());
            small.Add(new SmallCar());
            small.Add(new SmallCar());
            small.Add(new SmallCar());
            small.Add(new SmallCar());
            small.Add(new SmallCar());
            small.Add(new SmallCar());

            //add large cars to list
            large.Add(new LargeCar());
            large.Add(new LargeCar());
            large.Add(new LargeCar());
            large.Add(new LargeCar());
            large.Add(new LargeCar());
            large.Add(new LargeCar());
            large.Add(new LargeCar());
            large.Add(new LargeCar());
            large.Add(new LargeCar());
            large.Add(new LargeCar());
            large.Add(new LargeCar());

            //add both lists to CarHire object
            CarHire list = new CarHire(small, large);

            DateTime myDT1 = new DateTime(1950, 11, 17, new GregorianCalendar());
            DateTime myDT2 = new DateTime(1999, 8, 25, new GregorianCalendar());

            DateTime myDT3 = new DateTime(1940, 5, 12, new GregorianCalendar());
            DateTime myDT4 = new DateTime(1990, 7, 19, new GregorianCalendar());

            //create list for associated car
            List<ICar> driv1car = new List<ICar>();
            //create Name object for driving license
            Name name1 = new Name("James", "Peacock");
            //create DrivingLicense object
            DrivingLicense driv1 = new DrivingLicense(name1, myDT1, myDT2, true, driv1car);

            //create list for associated car
            List<ICar> driv2car = new List<ICar>();
            //create Name object for driving license
            Name name2 = new Name("David", "Peacock");
            //create DrivingLicense object
            DrivingLicense driv2 = new DrivingLicense(name2, myDT3, myDT4, true, driv2car);

            //print available cars and cars that are currently rented out
            Console.WriteLine("Small cars available to rent: " + list.AvailableCars("small"));
            Console.WriteLine("Large cars available to rent: " + list.AvailableCars("large"));
            Console.WriteLine("Cars currently rented: " + list.GetRentedCars().Count);
            //print out driving licenses
            Console.WriteLine(driv1);
            Console.WriteLine(driv2);

            //issue car to driving license
            list.IssueCar(driv1, "small");
            //show car is associated with driving license
            Console.WriteLine("\nCar associated with driving license: ");
            for (int i = 0; i < list.GetCar(driv1).Count; i++)
            {
                Console.Write(list.GetCar(driv1)[i].ToString() + " ");
            }

            //show car has been rented
            Console.WriteLine("\nSmall cars available to rent: " + list.AvailableCars("small"));
            Console.WriteLine("Large cars available to rent: " + list.AvailableCars("large"));
            Console.WriteLine("Cars currently rented: " + list.GetRentedCars().Count);

            //show fuel consumed after being driven and fuel required to fill tank
            driv1car[0].Drive(400);
            Console.WriteLine("\nFuel required to fill the tank after being driven: " + list.TerminateRental(driv1));

            //show car is no long associated with the driving license after terminating rental
            Console.WriteLine("\nCar disassociated with driving license and returned: ");
            for(int i = 0; i < list.GetCar(driv1).Count; i++)
            {
                Console.Write(list.GetCar(driv1)[i].ToString() + " ");
            }

            //show all cars are now available to rent again
            Console.WriteLine("\nSmall cars available to rent: " + list.AvailableCars("small"));
            Console.WriteLine("Large cars available to rent: " + list.AvailableCars("large"));
            Console.WriteLine("Cars currently rented: " + list.GetRentedCars().Count);

            //show next car to be issued is different from first because tank is not full in first car
            list.IssueCar(driv2, "small");
            Console.WriteLine("\nCar associated with driving license: ");
            for (int i = 0; i < list.GetCar(driv2).Count; i++)
            {
                Console.Write(list.GetCar(driv2)[i].ToString() + " ");
            }

            //show adding a second car to the same driving license does nothing
            list.IssueCar(driv2, "small");
            Console.WriteLine("\nCar associated with driving license: ");
            for (int i = 0; i < list.GetCar(driv2).Count; i++)
            {
                Console.Write(list.GetCar(driv2)[i].ToString() + " ");
            }

        }
    }
}
