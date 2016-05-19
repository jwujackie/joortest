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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Joor.Pages
{
    public class StylesPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "(//*[text() = \"Buy\"])[1]")]
        IWebElement buyButton;

        public StylesPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public OrderAddStyleOverlay clickBuyButton()
        {
            try
            {
                Thread.Sleep(3000);
                buyButton.Click();
            }
            catch (WebDriverException e)
            {
                Assert.Fail();
            }
            return new OrderAddStyleOverlay(driver);

        }

    }
}
