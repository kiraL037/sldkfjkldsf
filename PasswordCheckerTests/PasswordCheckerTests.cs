using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChecker.Tests
{
    [TestClass()]
    public class PasswordCheckerTests
    {
        [TestMethod()]
        public void ValidatePasswordTest()
        {
            string password = "ASqw12$$";
            bool expected = true;

            bool actual = PasswordChecker.ValidatePassword(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_8Symbols_ReturnsTrue()
        {
            string password = "ASqw12$$";
            bool expected = true;

            bool actual = PasswordChecker.ValidatePassword(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_4Symbols_ReturnsTrue()
        {
            string password = "Aq1$";

            bool actual = PasswordChecker.ValidatePassword(password);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void Check_30Symbols_ReturnsTrue()
        {
            string password = "ASDqwe123$ASDqwe123$ASDqwe123$";
            bool expected = false;

            bool actual = PasswordChecker.ValidatePassword(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_PasswordWithDigits_ReturnsTrue()
        {
            string password = "ASDqwe1$";
            bool expected = true;

            bool actual = PasswordChecker.ValidatePassword(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_PasswordWithoutDigits_ReturnsFalse()
        {
            string password = "ASDqweASD$";
            bool expected = false;

            bool actual = PasswordChecker.ValidatePassword(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_PasswordWithSpecSymbols_ReturnsTrue()
        {
            string password = "Aqwe123$";
            bool expected = true;

            bool actual = PasswordChecker.ValidatePassword(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_PasswordWithoutSpecSymbols_ReturnsFalse()
        {
            string password = "ASDqwe123";
            bool expected = false;

            bool actual = PasswordChecker.ValidatePassword(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_PasswordWithCapsSymbols_ReturnsTrue()
        {
            string password = "Aqwe123$";
            bool expected = true;

            bool actual = PasswordChecker.ValidatePassword(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_PasswordWithoutCapsSymbols_ReturnsFalse()
        {
            string password = "asdqwe123$";
            bool expected = false;

            bool actual = PasswordChecker.ValidatePassword(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_PasswordWithLowerSymbols_ReturnsTrue()
        {
            string password = "ASDq123$";
            bool expected = true;

            bool actual = PasswordChecker.ValidatePassword(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Check_PasswordWithoutLowerSymbols_ReturnsFalse()
        {
            string password = "ASDQWE123$";
            bool expected = false;

            bool actual = PasswordChecker.ValidatePassword(password);

            Assert.AreEqual(expected, actual);
        }

    }
}
