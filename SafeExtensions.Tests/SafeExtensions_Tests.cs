using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SafeExtensions.Tests
{
    [TestClass]
    public class SafeExtensions_Tests
    {
        [TestMethod]
        public void SafeTrim_Tests()
        {
            //what do I need to test?

            //an null object
            string someString = null;

            Assert.AreEqual("", someString.SafeTrim());

            //an empty string
            someString = "";

            Assert.AreEqual("", someString.SafeTrim());

            //a whitespace string
            someString = "   ";

            Assert.AreEqual("", someString.SafeTrim());

            //a string with no spaces
            someString = nameof(someString);

            Assert.AreEqual(nameof(someString), someString.SafeTrim());

            //string with leading spaces
            someString = "    asdf";

            Assert.AreEqual("asdf", someString.SafeTrim());

            //string with trailing spaces
            someString = "asdf     ";

            Assert.AreEqual("asdf", someString.SafeTrim());

            //string with both leading and trailing spaces as well as spaces between words which should stay intact.
            someString = "    asd    f      ";

            Assert.AreEqual("asd    f", someString.SafeTrim());

        }

        [TestMethod]
        public void SafeTrim_DefaultValue_Tests()
        {
            SafeTrim_DefaultValue_Core(" ");
            SafeTrim_DefaultValue_Core(null);
        }

        private void SafeTrim_DefaultValue_Core(string pValueToPassIn)
        {
            var retVal = pValueToPassIn;
            if(pValueToPassIn == null)
            {
                retVal = "";
            }
            //what do I need to test

            //null object
            string someString = null;

            Assert.AreEqual(retVal, someString.SafeTrim(pValueToPassIn));

            //empty string
            someString = "";

            Assert.AreEqual(retVal, someString.SafeTrim(pValueToPassIn));

            //whitespace string
            someString = "   ";

            Assert.AreEqual(retVal, someString.SafeTrim(pValueToPassIn));

            //string with words, but no whitespace
            someString = nameof(someString);

            Assert.AreEqual(nameof(someString), someString.SafeTrim(pValueToPassIn));

            //string with leading spaces
            someString = "    asdf";

            Assert.AreEqual("asdf", someString.SafeTrim(pValueToPassIn));

            //string with trailing spaces
            someString = "asdf     ";

            Assert.AreEqual("asdf", someString.SafeTrim(pValueToPassIn));

            //string with both leading and trailing spaces as well as spaces between words which should stay intact.
            someString = "    asd    f      ";

            Assert.AreEqual("asd    f", someString.SafeTrim(pValueToPassIn));

        }

        [TestMethod]
        public void SafeAny_Tests()
        {

            //what do I need to test

            //null object
            List<int> lstThings = null;
            Assert.IsFalse(lstThings.SafeAny());

            //collection with no elements
            lstThings = new List<int>();
            Assert.IsFalse(lstThings.SafeAny());

            //collection with a single element
            lstThings.Add(5);
            Assert.IsTrue(lstThings.SafeAny());

            //collection with multiple elements
            lstThings.Add(17);
            Assert.IsTrue(lstThings.SafeAny());

        }

        [TestMethod]
        public void SafeAny_Predicate_Tests()
        {
            //null object
            List<int> lstThings = null;
            Assert.IsFalse(lstThings.SafeAny(x => x > 1));

            //collection with no elements
            lstThings = new List<int>();
            Assert.IsFalse(lstThings.SafeAny(x => x > 1));

            //collection with a single element
            lstThings.Add(5);
            Assert.IsTrue(lstThings.SafeAny(x => x > 1));
            Assert.IsFalse(lstThings.SafeAny(x => x > 5));
            Assert.IsTrue(lstThings.SafeAny(x => x < 10));

            //collection with multiple elements
            lstThings.Add(17);
            Assert.IsTrue(lstThings.SafeAny(x => x > 1));
            Assert.IsTrue(lstThings.SafeAny(x => x > 5));
            Assert.IsTrue(lstThings.SafeAny(x => x < 10));
            Assert.IsTrue(lstThings.SafeAny(x => x > 10));

        }

    }
}
