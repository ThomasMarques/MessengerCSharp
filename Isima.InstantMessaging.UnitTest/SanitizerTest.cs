using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Isima.InstantMessaging;

namespace Isima.InstantMessaging.UnitTest
{
    [TestClass]
    public class SanitizerTest
    {

        [TestMethod]
        public void NeutralizeUrl_ShouldLeaveUnchanged_WhenNoUrl()
        {
            Sanitizer sanitizer = new Sanitizer();
            String phrase = "Bonjour, comment ça va ?";
            String sortie = "Bonjour, comment ça va ?";
            Assert.AreEqual(sortie,sanitizer.NeutralizeUrl(phrase));
        }

        [TestMethod]
        public void NeutralizeUrl_ShouldLeaveUnchanged_WhenUrlLikeWorld()
        {
            Sanitizer sanitizer = new Sanitizer();
            String phrase = "Hellohttp://google.com ça va ?";
            String sortie = "Hellohttp://google.com ça va ?";
            Assert.AreEqual(sortie, sanitizer.NeutralizeUrl(phrase));
        }

        [TestMethod]
        public void NeutralizeUrl_ShouldPrefixWithUnderscore_WhenHref()
        {
            Sanitizer sanitizer = new Sanitizer();
            String phrase = "<a href=\"http://google.com\" ></a>";
            String sortie = "<a href=\"_http://google.com\" ></a>";
            Assert.AreEqual(sortie, sanitizer.NeutralizeUrl(phrase));
        }

        [TestMethod]
        public void NeutralizeUrl_ShouldPrefixWithUnderscore_WhenRootUrl()
        {
            Sanitizer sanitizer = new Sanitizer();
            String phrase = "file://fichier.ext";
            String sortie = "_file://fichier.ext";
            Assert.AreEqual(sortie,sanitizer.NeutralizeUrl(phrase));
        }

        [TestMethod]
        public void NeutralizeUrl_ShouldPrefixWithUnderscore_WhenUrl()
        {
            Sanitizer sanitizer = new Sanitizer();
            String phrase = "http://google.com";
            String sortie = "_http://google.com";
            Assert.AreEqual(sortie, sanitizer.NeutralizeUrl(phrase));
        }
    }
}
