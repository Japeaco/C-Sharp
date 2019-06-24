using System;
using System.Collections.Generic;
using System.Text;

namespace CarHireApplication
{
    public class SmallCar : ICar
    {

        readonly private string reg;
        private Boolean rented;
        private int fuelInTank;
        private double fuelConsumed;

    /**
	 * Creates a small car object with a registration number, and a fuel capacity;
	 */
    public SmallCar()
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
        int capacity = 45;

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
            //consumes one litre per 25km driven
            fuelConsumed = (kilometresDriven / 25) + 1;

        //if the car is not rented or the tank is empty no fuel will be consumed/car will not be driven
        else if (GetRented() == false || GetFuelInTank() <= 0)
            fuelConsumed = 0;

        //deduct fuel consumed from fuel in the tank
        fuelInTank = GetFuelInTank() - (int)fuelConsumed;

        //return fuel consumed
        return (int)fuelConsumed;
    }

    override public String ToString()
    {
        return ("\nRegistration: " + GetRegistration() + "\nCar Type: small" + "\nFuel: " + GetFuelInTank() + "\nRented: " + GetRented());
    }

}
}
