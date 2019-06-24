using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CarHireApplication
{
    public class CarHire
    {

        public static int MAX_NUMBER_OF_SMALL_CARS = 20;
        public static int MAX_NUMBER_OF_LARGE_CARS = 10;
        public static int MAX_NUMBER_OF_RENTED_CARS = 1;
        private readonly List<ICar> smallCars;
        private readonly List<ICar> largeCars;

        /**
         * @param small
         * @param large
         * CarHire object that uses both a list of small cars and large cars
         */
        public CarHire(List<ICar> small, List<ICar> large)
        {
            this.smallCars = small;
            this.largeCars = large;
        }

        /**
         * @param typeOfCar
         * @return
         * This method returns the number of cars of the specified type that are available to rent
         */
        public int AvailableCars(String typeOfCar)
        {
            int available = 0;

            //if the type of car is of type small
            if (typeOfCar == "small" || typeOfCar == "Small")
            {
                //loop through the maximum number of small cars; 20
                for (int i = 0; i < MAX_NUMBER_OF_SMALL_CARS; i++)
                {
                    //if there is a car and it is not currently rented
                    if (smallCars[i] != null && smallCars[i].GetRented() != true)
                        //increment available
                        available++;
                }
            }
            //if the type of car is of type large
            else if (typeOfCar == "large" || typeOfCar == "Large")
            {
                //loop through the maximum number of large cars; 10
                for (int i = 0; i < MAX_NUMBER_OF_LARGE_CARS; i++)
                {
                    //if there is a car and it is not currently rented
                    if (largeCars[i] != null && largeCars[i].GetRented() != true)
                        //Increment available
                        available++;
                }
            }
            //if the type of car is neither small nor large, return 0
            else
            {
                available = 0;
            }

            //return number of available cars
            return available;
        }

        /**
         * @return
         * This method returns a collection of all that cars that are currently rented
         */
        public List<ICar> GetRentedCars()
        {
            List<ICar> Rented = new List<ICar>();

            //loop through maximum number of small cars; 20
            for (int i = 0; i < MAX_NUMBER_OF_SMALL_CARS; i++)
            {
                //if there is a car and it is currently rented, add it to the list
                if (smallCars[i] != null && smallCars[i].GetRented() == true)
                    Rented.Add(smallCars[i]);
            }
            //loop through maximum number of large cars; 10
            for (int i = 0; i < MAX_NUMBER_OF_LARGE_CARS; i++)
            {
                //if there is a car and it is currently rented, add it to the list
                if (largeCars[i] != null && largeCars[i].GetRented() == true)
                    Rented.Add(largeCars[i]);
            }

            //return the list
            return Rented;
        }

        /**
         * @param drivingLicense
         * @param typeOfCar
         * @return
         *  method determines whether the person is eligible to rent a car of the specified type and,
         *  if there is a car available, issues and associates that car with the driving license
         */
        public String IssueCar(DrivingLicense drivingLicense, String typeOfCar)
        {
            Calendar cal = CultureInfo.InvariantCulture.Calendar;
            DateTime myDT = new DateTime();
            int year = 2019;
            int age = int.Parse(drivingLicense.GetDateOfBirth().ToString().Substring(6, 4));
            int issue = int.Parse(drivingLicense.GetDateOfIssue().ToString().Substring(6, 4));
            Boolean valid = drivingLicense.IsLicenseValid();
            List<ICar> car = drivingLicense.CarAssociated();

            //if the type of car is of type small
            if (typeOfCar == "small" || typeOfCar == "Small")
            {
                //if the driving license is valid, is over 21 years old and has held the license for a year
                if (valid == true && year - age >= 21 && year - issue >= 1)
                {
                    //method call to find a free small car
                    int i = FindFreeSmallCar();
                    //if size of list is less than 1
                    if (car.Count < MAX_NUMBER_OF_RENTED_CARS)
                    {
                        //add a small car to the list and set the car as rented
                        car.Add(smallCars[i]);
                        smallCars[i].SetRented(true);
                    }
                }
            }
            //if the type of car is of type large
            else if (typeOfCar == "large" || typeOfCar == "Large")
            {
                //if the driving license is valid, is over 25 years old and has held the license for 5 years
                if (valid == true && year - age >= 25 && year - issue >= 5)
                {
                    //method call to find a free large car
                    int i = FindFreeLargeCar();
                    //if size of list is less than 1
                    if (car.Count < MAX_NUMBER_OF_RENTED_CARS)
                    {
                        //add a small car to the list and set the car as rented
                        car.Add(largeCars[i]);
                        smallCars[i].SetRented(true);
                    }
                }
            }
            else
            {
                //if conditions for rental are not met then print statement
                return "Car cannot be issued.";
            }

            return "Car can be issued.";
        }

        /**
         * @return
         * method locates a free small car that is available to rent
         */
        private int FindFreeSmallCar()
        {

            int i;
            //loops through the maximum number of small cars; 20
            for (i = 0; i < MAX_NUMBER_OF_SMALL_CARS; i++)
            {
                //if there is a car, it is not currently rented, and its tank is full, return that car
                if (smallCars[i] != null && smallCars[i].GetRented() == false && smallCars[i].IsTankFull() == true)
                {
                    break;
                }
            }
            //return car
            return i;

        }

        /**
         * @return
         *method locates a free large car that is available to rent
         */
        private int FindFreeLargeCar()
        {

            int i;
            //loops through the maximum number of large cars; 10
            for (i = 0; i < MAX_NUMBER_OF_LARGE_CARS; i++)
            {
                //if there is a car, it is not currently rented, and its tank is full, return that car
                if (largeCars[i] != null && largeCars[i].GetRented() == false && largeCars[i].IsTankFull() == true)
                {
                    break;
                }
            }
            //return car
            return i;
        }

        /**
         * @param drivingLicense
         * @return
         * 	method to return the car someone is currently renting
         */
        public List<ICar> GetCar(DrivingLicense drivingLicense)
        {
            //returns list of single car currently associated with the driving license
            return drivingLicense.CarAssociated();
        }

        /**
         * @param drivingLicense
         * @return
         * method disassociates the car currently rented with the driving license and returns fuel to fill the tank
         */
        public int TerminateRental(DrivingLicense drivingLicense)
        {
            List<ICar> car = drivingLicense.CarAssociated();
            int i;

            //loops through maximum number of rented cars; 1
            for (i = 0; i < MAX_NUMBER_OF_RENTED_CARS; i++)
            {
                //if a car is there, break
                if (car != null)
                {
                    break;
                }
            }

            //change cars status to not rented and remove it from the driving license
            car[i].SetRented(false);
            int fuelConsumed = car[i].Capacity() - car[i].GetFuelInTank();
            car.Remove(car[i]);

            //return fuel required to fill the tank
            return fuelConsumed;
        }
    }

}
