using System.Windows;

using DesignPatterns.Interfaces;

namespace DesignPatterns.Validators
{
    class NameValidator : IStringValidator
    {
        public bool IsValid(string s) 
        {
            if (s.Length > 1)
                return true;
            
            MessageBox.Show("Špatně zadané JMÉNO!\nViz vzor.", "Chyba");
            return s.Length > 1; }
    }
}
