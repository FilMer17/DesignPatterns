using System.Windows;

using DesignPatterns.Interfaces;

namespace DesignPatterns.Validators
{
    public class NameValidator : IStringValidator
    {
        public bool IsValid(string s) 
        {
            if (s.Length > 1)
                return true;
            
            return s.Length > 1; }
    }
}
