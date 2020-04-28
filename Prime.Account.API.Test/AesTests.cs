﻿using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AesCrypto;

namespace Prime.Account.API.Test
{
    /// <summary>
    /// Summary description for AesTests
    /// </summary>
    [TestClass]
    public class AesTests
    {
        [TestMethod]
        public void EncryptTest()
        {
            try
            {
                var plainText = "clientID101";

                var cipherText = EncryptorDecryptor.Encrypt(plainText);

                var result = EncryptorDecryptor.Decrypt(cipherText);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public AesTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
    }
}
