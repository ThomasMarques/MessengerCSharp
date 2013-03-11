using Isima.InstantMessaging.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Isima.InstantMessaging.UnitTest.Text
{
    
    
    /// <summary>
    ///This is a test class for SanitizerTest and is intended
    ///to contain all SanitizerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SanitizerTest
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
        public void NeutralizeUrl_ShouldLeaveUnchanged_WhenNoUrl()
        {
            string input = "Hello World!";
            string expected = "Hello World!"; 
            string actual;
            actual = Sanitizer.NeutralizeUrl(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NeutralizeUrl_ShouldPrefixWithUnderscore_WhenRootUrl()
        {
            string input = "http://www.isima.fr";
            string expected = "_http://www.isima.fr";
            string actual;
            actual = Sanitizer.NeutralizeUrl(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NeutralizeUrl_ShouldPrefixWithUnderscore_WhenHref()
        {
            string input = "<a href=\"http://www.isima.fr\">Home</a>";
            string expected = "<a href=\"_http://www.isima.fr\">Home</a>";
            string actual;
            actual = Sanitizer.NeutralizeUrl(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NeutralizeUrl_ShouldLeaveUnchanged_WhenUrlLikeWord()
        {
            string input = "Testhttp://www.isima.fr/smiley.jpg";
            string expected = "Testhttp://www.isima.fr/smiley.jpg";
            string actual;
            actual = Sanitizer.NeutralizeUrl(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NeutralizeUrl_ShouldPrefixWithUnderscore_WhenUrl()
        {
            string input = "http://www.isima.fr/smiley.jpg";
            string expected = "_http://www.isima.fr/smiley.jpg";
            string actual;
            actual = Sanitizer.NeutralizeUrl(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SanitizeTest()
        {
            string input = "Hello\t Wor\bld!\n";
            string expected = "Hello World!"; 
            string actual;
            actual = Sanitizer.Sanitize(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
