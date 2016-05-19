using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Joor.PageClasses;
using OpenQA.Selenium.Support.PageObjects;

namespace Joor.Tests
{
    [TestClass]
    public class PendingOrder
    {
        IWebDriver driver = new ChromeDriver(@"C:\Users\Jacqueline\Documents\Visual Studio 2015\Projects\Joor\Joor\ExternalLibraries");
        string url = "http://staging.joordev.com";

        [TestInitialize]
        public void setup()
        {
            driver.Navigate().GoToUrl(url);
        }

        [TestCleanup]
        public void cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void submitPendingOrder()
        {
            Homepage homepage = new Homepage(driver);
            homepage.signIn()
                .clickOnStartOrder()
                .clickOnWebOrder()
                .initiateStartOrder()
                .clickBuyButton()
                .enterQuantityAndContinue()
                .clickCheckoutButton()
                .enterCustomPO()
                .clickSubmit()
                .navigateToPendingOrdersPage()
                .verifyOrderExistsInPage();

        }
    }
}
