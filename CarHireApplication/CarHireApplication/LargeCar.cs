using System;
using System.Collections.Generic;
using System.Text;

namespace CarHireApplication
{
    public class LargeCar : ICar
    {

        readonly private string reg;
        private Boolean rented;
        private int fuelInTank;
        private double fuelConsumed;

    /**
	 * Creates a large car object with a registration number, and fuel capacity.
	 */
    public LargeCar()
    {
        Registration reg = Registration.getInstance();
        String str = reg.ToString();
        this.reg = str;
        this.rented = GetRented();
        this.fuelInTank = Capacity();
    }

    public String GetRegistration()
    {
        return reg;
    }

    public Boolean SetRented(Boolean rented)
    {
        return this.rented = rented;
    }

    public Boolean GetRented()
    {
        return rented;
    }

    public int Capacity()
    {
        int capacity = 65;

        return capacity;
    }

    public int GetFuelInTank()
    {
        return fuelInTank;
    }

    public Boolean IsTankFull()
    {

        Boolean isTankFull = false;

        //if fuel in tank matches the capacity return true
        if (GetFuelInTank() == Capacity())
            isTankFull = true;

        //return boolean
        return isTankFull;
    }

    public int AddFuel()
    {

        int addFuelToTank = 0;

        //if tank is full add no fuel to the tank
        if (IsTankFull() == true)
            addFuelToTank = 0;
        //if tank is not full then amount of fuel needed was amount consumed
        if (IsTankFull() == false)
            addFuelToTank = (int)fuelConsumed;

        //add fuel to the tank
        fuelInTank += addFuelToTank;

        //return amount of fuel added
        return (int)fuelConsumed;
    }

    public int Drive(int kilometresDriven)
    {

        //if car has been rented and there is fuel in the tank
        if (GetRented() == true && GetFuelInTank() > 0)
        {
            //first 50km consumes one litre per 15km
            if (kilometresDriven <= 50)
                fuelConsumed = (kilometresDriven / 15) + 1;
            //after first 50km consumes one litre per 20km
            if (kilometresDriven > 50)
                fuelConsumed = ((50 / 15) + 1) + (((kilometresDriven - 50) / 20) + 1);
        }
        //if the car is not rented or the tank is empty no fuel will be consumed/car will not be driven
        else if (GetRented() == false || GetFuelInTank() <= 0)
            fuelConsumed = 0;

        //deduct fuel consumed from fuel in the tank
        fuelInTank = GetFuelInTank() - (int)fuelConsumed;

        //return fuel consumed
        return (int)fuelConsumed;
    }

    public String toString()
    {
        return ("\nRegistration: " + GetRegistration() + "\nCar Type: Large" + "\nFuel: " + GetFuelInTank() + "\nRented: " + GetRented());
    }

}
}
