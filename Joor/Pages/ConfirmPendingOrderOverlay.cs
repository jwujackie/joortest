using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Joor.Pages;
using System.Threading;

namespace Joor.Pages
{
    public class ConfirmPendingOrderOverlay
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[contains (@class, \"j-order-instructions\")]")]
        IWebElement submitButton;

        public ConfirmPendingOrderOverlay(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public ReviewPage clickSubmit()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains (@class, \"j-order-instructions\")]")));

                submitButton.Click();
            }
            catch(WebDriverException e)
            {
                Assert.Fail();
            }
            
            return new ReviewPage(driver);
        }

        

    }
}
