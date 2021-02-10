using System.Windows;

using DesignPatterns.Interfaces;

namespace DesignPatterns.Validators
{
    class SSNValidator : ISSNValidator
    {
        public bool IsValid(string s, int year)
        {
            if (year >= 1954 && s.Length == 4)
                return true;
            else if (year < 1954)
                if (s.Length == 3 || s.Length == 4)
                    return true;
                MessageBox.Show("Špatně zadané RODNÉ ČÍSLO!\nViz vzor.", "Chyba");

            return false;
        }
    }
}
