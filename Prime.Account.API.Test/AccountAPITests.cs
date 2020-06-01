using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Prime.Account.API.Test
{
    [TestClass]
    public class AccountAPITests
    {
        [TestMethod]
        public void AccountAPITest()
        {
            try
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("username", "sa"));
                postData.Add(new KeyValuePair<string, string>("password", "Ch3ck1t{}"));
                postData.Add(new KeyValuePair<string, string>("grant_type", "password")); // static value: password
                postData.Add(new KeyValuePair<string, string>("client_id", "clientId101"));
                postData.Add(new KeyValuePair<string, string>("client_secret", "clientSecret101"));

                var content = new FormUrlEncodedContent(postData);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                HttpResponseMessage tokenResponse;
                using(var client = new HttpClient())
                {
                    tokenResponse = client.PostAsync("https://localhost:44377/oauth2/token", content).Result;
                    //tokenResponse = client.PostAsync("https://localhost/primeapi/oauth2/token", content).Result;
                }

                var tokenResult = tokenResponse.Content.ReadAsStringAsync().Result;
                var dictResult = JsonConvert.DeserializeObject<Dictionary<string, string>>(tokenResult);
                var accessToken = dictResult.Where(x => x.Key == "access_token")
                                            .Select(v => v.Value)
                                            .FirstOrDefault();

                HttpResponseMessage accntResponse;
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    accntResponse = client.GetAsync("https://localhost:44377/api/Account/GetEmployeeDetails").Result;
                    //accntResponse = client.GetAsync("https://localhost/primeapi/api/Account/GetEmployeeDetails").Result;
                }

                var result = string.Empty;
                if (!accntResponse.IsSuccessStatusCode)
                {
                    result = accntResponse.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    result = accntResponse.Content.ReadAsStringAsync().Result;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
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
