using System.Text.RegularExpressions;
using System.Windows;

using DesignPatterns.Interfaces;

namespace DesignPatterns.Validators
{
    public class BirthdayValidator : IStringValidator
    {
        public bool IsValid(string s) 
        {
            string pattern = @"^([0-2][0-9]|(3)[0-1])(.)(((0)[0-9])|((1)[0-2]))(.)(19[0-9][0-9]|20[01][0-9]|2021)$";
            Regex rg = new Regex(pattern);

            if (rg.IsMatch(s))
                return true;
            else
                MessageBox.Show("Špatně zadané DATUM!\nViz vzor.", "Chyba");

            return false;
        }
    }
}
