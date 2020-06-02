using System;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prime.Account.API.Test.Models;

namespace Prime.Account.API.Test
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void GetEmployeeDetailsTests()
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
                    // Call hosted web API
                       tokenResponse = client.PostAsync("https://www.rvluzuriaga.somee.com/oauth2/token", content).Result;

                    // Call deployed web API in local environment
                    // tokenResponse = client.PostAsync("https://localhost/primeapi/oauth2/token", content).Result;

                    // Debug mode
                    // tokenResponse = client.PostAsync("https://localhost:44377/oauth2/token", content).Result;
                }

                var tokenResult = tokenResponse.Content.ReadAsStringAsync().Result;

                // Assertion
                Assert.IsTrue(tokenResponse.IsSuccessStatusCode, tokenResult);
                Assert.IsNotNull(tokenResult, "Token is null.");

                // Get Token
                var dictResult = JsonConvert.DeserializeObject<Dictionary<string, string>>(tokenResult);
                var accessToken = dictResult.Where(x => x.Key == "access_token")
                                            .Select(v => v.Value)
                                            .FirstOrDefault();

                HttpResponseMessage employeeResponse;
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    // Call the hosted web API
                       employeeResponse = client.GetAsync("https://www.rvluzuriaga.somee.com/api/Employee/GetEmployeeDetails").Result;

                    // Call the deployed web API in local environment
                    // employeeResponse = client.GetAsync("https://localhost/primeapi/api/Employee/GetEmployeeDetails").Result;

                    // Debug mode
                    // employeeResponse = client.GetAsync("https://localhost:44377/api/Employee/GetEmployeeDetails").Result;
                }

                var employeeResult = employeeResponse.Content.ReadAsStringAsync().Result;

                Assert.IsTrue(tokenResponse.IsSuccessStatusCode, employeeResult);

                var employees = JsonConvert.DeserializeObject<List<Employee>>(employeeResult);

                Assert.IsNotNull(employees, "Employees object is null.");

                Assert.AreNotEqual(0, employees.Count);
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
