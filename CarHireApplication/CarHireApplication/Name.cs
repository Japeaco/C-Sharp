using System;
using System.Collections.Generic;
using System.Text;

namespace CarHireApplication
{
    public class Name
    {

        private readonly string firstName;
        private readonly string lastName;

        public Name(String firstName, String lastName)
        {

            this.firstName = firstName;
            this.lastName = lastName;

            if (firstName == null || lastName == null)
                throw new NullReferenceException();
        }

        public String GetFirstName()
        {
            return firstName;
        }

        public String GetLastName()
        {
            return lastName;
        }

        override public String ToString()
        {
            return GetFirstName() + " " + GetLastName();
        }
    }
}
