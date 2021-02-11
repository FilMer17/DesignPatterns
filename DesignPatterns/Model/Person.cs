using System;
using System.Linq;
using System.Windows;
using DesignPatterns.Interfaces;
using DesignPatterns.Validators;

namespace DesignPatterns.Model
{
    public class Person
    {
        readonly IStringValidator fnameValidator;
        readonly IStringValidator lnameValidator;
        readonly IStringValidator bdayValidator;
        readonly ISSNValidator ssnValidator;

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public string SSN { get; set; }

        public Person(IStringValidator fname, IStringValidator lname, IStringValidator bday, ISSNValidator ssn)
        {
            fnameValidator = fname;
            lnameValidator = lname;
            bdayValidator = bday;
            ssnValidator = ssn;
        }

        public bool CreatePerson(string fname, string lname, string bday, string ssn)
        {
            bool bdayValid = bdayValidator.IsValid(bday);
            bool ssnValid = false;
            string[] bdayData = new string[3];
            string error = "";

            if (bdayValid)
            {
                bdayData = bday.Split('.');
                int year = Convert.ToInt32(bdayData[2]);
                ssnValid = ssnValidator.IsValid(ssn, year);
            }

            bool[] areValid = new bool[] {
                fnameValidator.IsValid(fname),
                lnameValidator.IsValid(lname),
                bdayValid,
                ssnValid
            };

            if (areValid.All(t => t))
            {
                Firstname = fname;
                Lastname = lname;
                Birthday = new DateTime(Convert.ToInt32(bdayData[2]), Convert.ToInt32(bdayData[1]), Convert.ToInt32(bdayData[0]));
                SSN = bdayData[2].Substring(bdayData[2].Length - 2) + bdayData[1] + bdayData[0] + "/" + ssn;

                return true;
            }
            else
            {
                error += "Špatně zadané:\n";
                if (!areValid[0])
                    error += "KŘESTNÍ JMÉNO\n";
                if (!areValid[1])
                    error += "PŘÍJMENÍ\n";
                if (!areValid[2])
                    error += "DATUM NAROZENÍ\n";
                if (!areValid[3])
                    error += "RODNÉ ČÍSLO\n";

                error += "Viz vzor.";
                MessageBox.Show(error, "Chyba");
            }

            return false;
        }

        public override string ToString()
        {
            return $"{Firstname} {Lastname} | {Birthday:dd/MM/yyyy} | {SSN}";
        }
    }
}
