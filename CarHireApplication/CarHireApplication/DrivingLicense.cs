using System;
using System.Collections.Generic;
using System.Text;

namespace CarHireApplication
{
    public class DrivingLicense
    {

        private readonly Name name;
	    private readonly DateTime dateOfBirth;
	    private readonly DateTime dateOfIssue;
	    private readonly Boolean valid;
        private readonly List<ICar> carAssociated;
        private readonly String number;
	
	public DrivingLicense(Name name, DateTime dateOfBirth, DateTime dateOfIssue, Boolean valid, List<ICar> carAssociated)
        {
            LicenseNumber lic = LicenseNumber.getInstance(name, dateOfIssue);
            String str = lic.ToString();
            this.number = str;
            this.name = new Name(name.GetFirstName(), name.GetLastName());
            this.dateOfBirth = dateOfBirth;
            this.dateOfIssue = dateOfIssue;
            this.valid = valid;
            this.carAssociated = carAssociated;

            if (str == null || name == null || dateOfBirth == null || dateOfIssue == null)
                throw new NullReferenceException();
        }

        public String GetLicenseNumber()
        {
            return number;
        }

        public Name GetName()
        {
            return new Name(name.GetFirstName(), name.GetLastName());
        }

        public DateTime GetDateOfBirth()
        {
            return dateOfBirth;
        }

        public DateTime GetDateOfIssue()
        {
            return dateOfIssue;
        }

        public Boolean GetValid()
        {
            return valid;
        }

        public List<ICar> CarAssociated()
        {
            return carAssociated;
        }

        public Boolean IsLicenseValid()
        {
            Boolean isLicenseValid = false;

            if (GetValid() == true)
                isLicenseValid = true;

            return isLicenseValid;

        }

        override public String ToString()
        {
            return "Name: " + GetName() + "\nDate Of Birth: " + GetDateOfBirth().ToString().Substring(0, 4)
                    + GetDateOfBirth().ToString().Substring(5, 6) + "\nDate Of Issue: "
                    + GetDateOfIssue().ToString().Substring(0, 4) + GetDateOfIssue().ToString().Substring(5, 6)
                    + "\nValid: " + IsLicenseValid() + "\nLicense Number: " + GetLicenseNumber();
        }

    }
}
