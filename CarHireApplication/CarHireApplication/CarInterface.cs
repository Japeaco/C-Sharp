using System;

namespace CarHireApplication
{

    public interface ICar
    {

        //method to return registration number
        string GetRegistration();

        //method to set if car has been rented
        Boolean SetRented(Boolean rented);

        //returns whether car has been rented
        Boolean GetRented();

        //returns capacity of the tank
        int Capacity();

        //returns amount of fuel currently in the tank
        int GetFuelInTank();

        //returns whether tank is full
        Boolean IsTankFull();

        //method that adds fuel to the tank
        int AddFuel();

        //method that drives the car and returns amount of fuel consumed
        int Drive(int kilometresDriven);

    }
}
