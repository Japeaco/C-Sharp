using System;
using System.Collections.Generic;
using System.Text;

namespace CarHireApplication
{
    public class Registration
    {

        private static int i = 0;

        private readonly string number;
	    private static readonly SortedDictionary<String, Registration> REG = new SortedDictionary<String, Registration>();

        public Registration(String number)
        {
            this.number = number;
            if (number == null)
                throw new NullReferenceException();
        }

        public String GetNumber()
        {
            return number;
        }

        override public string ToString()
        {
            return number;
        }

        //factory that produces a unique registration number
        public static Registration getInstance()
        {
            i++;
            char letter = (char)('a' + (i / 10000));
            int number = i % 10000;

            //converts the variables to a string
            string k = letter + "" + number;

            //if the number does not already exist in the map, then create the new registration number
            if (!REG.ContainsKey(k))
                REG.Add(k, new Registration(String.Format(letter + " " + number)));

            //return the registration number
            return REG[k];
        }
    }
}
