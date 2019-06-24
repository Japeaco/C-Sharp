using System;
using System.Collections.Generic;
using System.Text;

namespace CarHireApplication
{
    public class LicenseNumber
    {

    private static int i = 0;
    public readonly string number;

	private static readonly SortedDictionary<String, LicenseNumber> NUMB = new SortedDictionary<String, LicenseNumber>();

        public LicenseNumber(String number)
        {
            this.number = number;

            if (number == null)
                throw new NullReferenceException();
        }

        public String Getnumber()
        {
            return number;
        }

        override public String ToString()
        {
            return number;
        }

        //method that produces a unique license number
        public static LicenseNumber getInstance(Name name, DateTime doi)
        {
            i++;
            //return the initials and the year of issue
            String initials = name.GetFirstName().Substring(0, 1)
                    + name.GetLastName().Substring(0, 1);
            String year = doi.ToString().Substring(0, 1);

            int val = i % 100;

            //convert variables to a string
            string k = val.ToString();

            //if the license number does not already exist in the map, then create the new license number
            if (!NUMB.ContainsKey(k))
                NUMB.Add(k, new LicenseNumber(initials + "" + year + "" + val));

            //return the license number
            return NUMB[k];
        }

    }
}
