using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using OpenQA.Selenium.Internal;

namespace Joor.Pages
{
    public class StartOrderOverlay
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@class = \"order_type_icons\"]")]
        IWebElement overlay;

        [FindsBy(How = How.XPath, Using = "//*[@href = \"/orders/create_order\"]")]
        IWebElement webOrderIcon;

        

        public StartOrderOverlay(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public StartWebOrderOverlay clickOnWebOrder()
        {
            try
            {
                overlay.Click();
                webOrderIcon.Click();
                Thread.Sleep(3000);

            }
            catch (WebDriverException e)
            {
                Assert.Fail();
            }
            return new StartWebOrderOverlay(driver);
        }

    }
}
