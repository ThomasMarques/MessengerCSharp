using Isima.InstantMessaging.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Isima.InstantMessaging.UnitTest.Text
{
    
    
    /// <summary>
    ///This is a test class for Base64EncoderTest and is intended
    ///to contain all Base64EncoderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Base64EncoderTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod()]
        public void Encode_ShouldSucceed_WhenEmptyString()
        {
            string input = string.Empty; 
            string expected = string.Empty; 
            string actual = Base64Encoder.Encode(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Encode_ShouldSucceed_WhenTestString()
        {
            string input = "Hello World!";
            string expected = "SGVsbG8gV29ybGQh";
            string actual = Base64Encoder.Encode(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Encode_ShouldRaiseArgumentNullException_WhenNullString()
        {
            string input = null; 
            string actual = Base64Encoder.Encode(input);
        }

        [TestMethod()]
        public void Decode_ShouldSucceed_WhenEmptyString()
        {
            string input = string.Empty;
            string expected = string.Empty;
            string actual = Base64Encoder.Decode(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Decode_ShouldSucceed_WhenTestString()
        {
            string input = "SGVsbG8gV29ybGQh";
            string expected = "Hello World!";
            string actual = Base64Encoder.Decode(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Decode_ShouldRaiseArgumentNullException_WhenNullString()
        {
            string input = null;
            string actual = Base64Encoder.Decode(input);
        }
    }
}
