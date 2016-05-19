using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Joor.Pages;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Joor.Pages
{
    public class CartPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "(//*[contains(text(), \"CHECKOUT\")])[1]")]
        IWebElement checkoutButton;
        

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public CheckoutPage clickCheckoutButton()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//*[contains(text(), \"CHECKOUT\")])[1]")));
                checkoutButton.Click();
            }
            catch (WebDriverException e)
            {
                Assert.Fail();
            }

            return new CheckoutPage(driver);
        }

    }
}
