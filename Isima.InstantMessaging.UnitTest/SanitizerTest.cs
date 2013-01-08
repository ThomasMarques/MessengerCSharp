using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Isima.InstantMessaging.UnitTest
{
    [TestClass]
    public class SanitizerTest
    {
        [TestMethod]
        public void NeutralizeUrl_ShouldLeaveUnchanged_WhenNoUrl()
        {
        }

        [TestMethod]
        public void NeutralizeUrl_ShouldLeaveUnchanged_WhenUrlLikeWorld()
        {
        }

        [TestMethod]
        public void NeutralizeUrl_ShouldPrefixWithUnderscore_WhenHref()
        {
        }

        [TestMethod]
        public void NeutralizeUrl_ShouldPrefixWithUnderscore_WhenRootUrl()
        {
        }

        [TestMethod]
        public void NeutralizeUrl_ShouldPrefixWithUnderscore_WhenUrl()
        {
        }

        [TestMethod]
        public void SanitizeTest()
        {
        }
    }
}
