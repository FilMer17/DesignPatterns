using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatterns.Validators;

namespace DesignPatternsUnitTests
{
    [TestClass]
    public class ValidatorsTests
    {
        [TestMethod]
        public void NameValidator_ReturnsTrue()
        {
            string[] input = new string[] { "Adam", "Tomáš", "Čeněk" };
            NameValidator fnameValidator = new NameValidator();

            foreach (var item in input)
            {
                bool result = fnameValidator.IsValid(item);
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void BirthdayValidator_ReturnsTrue()
        {
            string[] input = new string[] { "19.09.2000", "01.01.1900",  "31.01.2021" };
            BirthdayValidator bdayValidator = new BirthdayValidator();

            foreach (var item in input)
            {
                bool result = bdayValidator.IsValid(item);
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void SSNValidator_ReturnsTrue()
        {
            string[] inputSSN = new string[] { "0213", "025", "9999" };
            int[] inputYear = new int[] { 2000, 1920, 2021 };
            SSNValidator bdayValidator = new SSNValidator();

            for (int i = 0; i < inputSSN.Length; i++)
            {
                bool result = bdayValidator.IsValid(inputSSN[i], inputYear[i]);
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void NameValidator_ReturnsFalse()
        {
            string[] input = new string[] { "A", "", "ř" };
            NameValidator fnameValidator = new NameValidator();

            foreach (var item in input)
            {
                bool result = fnameValidator.IsValid(item);
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void BirthdayValidator_ReturnsFalse()
        {
            string[] input = new string[] { "19/09/2000", "01-01-1900", "31.01.2022" };
            BirthdayValidator bdayValidator = new BirthdayValidator();
            int i = 0;
            foreach (var item in input)
            {
                bool result = bdayValidator.IsValid(item);
                Assert.IsFalse(result);
                i++;
            }
        }

        [TestMethod]
        public void SSNValidator_ReturnsFalse()
        {
            string[] inputSSN = new string[] { "/0213", "025", "00235" };
            int[] inputYear = new int[] { 2000, 2020, 1980 };
            SSNValidator bdayValidator = new SSNValidator();

            for (int i = 0; i < inputSSN.Length; i++)
            {
                bool result = bdayValidator.IsValid(inputSSN[i], inputYear[i]);
                Assert.IsFalse(result);
            }
        }
    }
}
