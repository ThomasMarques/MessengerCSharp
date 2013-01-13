using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Isima.InstantMessaging.UnitTest
{
    [TestClass]
    public class Base64EncoderTest
    {

        [TestMethod]
        public void Decode_ShouldRaiseArgumentNullException_WhenNullString()
        {
            Base64Encoder base64Encoder = new Base64Encoder();
            bool success = false;
            try
            {
                base64Encoder.Decode(null);
            }
            catch (ArgumentNullException)
            {
                success = true;
            }
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Decode_ShouldSucceed_WhenEmptyString()
        {
            Base64Encoder base64Encoder = new Base64Encoder();
            Assert.AreEqual(String.Empty,base64Encoder.Decode(String.Empty));
        }

        [TestMethod]
        public void Decode_ShouldSucceed_WhenTestString()
        {
            Base64Encoder base64Encoder = new Base64Encoder();
            String entree = "Qm9uam91ciAh";
            String sortie = "Bonjour !";
            Assert.AreEqual(sortie,base64Encoder.Decode(entree));
        }

        [TestMethod]
        public void Encode_ShouldRaiseArgumentNullException_WhenNullString()
        {
            Base64Encoder base64Encoder = new Base64Encoder();
            bool success = false;
            try
            {
                base64Encoder.Encode(null);
            }
            catch (ArgumentNullException)
            {
                success = true;
            }
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Encode_ShouldSucceed_WhenEmptyString()
        {
            Base64Encoder base64Encoder = new Base64Encoder();
            Assert.AreEqual(String.Empty,base64Encoder.Encode(String.Empty));
        }

        [TestMethod]
        public void Encode_ShouldSucceed_WhenTestString()
        {
            Base64Encoder base64Encoder = new Base64Encoder();
            String entree = "Bonjour !";
            String sortie = "Qm9uam91ciAh";
            Assert.AreEqual(sortie,base64Encoder.Encode(entree));
        }
    }
}
