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
    public class StartWebOrderOverlay
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "OrderOrderForLabel")]
        IWebElement orderForField;


        [FindsBy(How = How.XPath, Using = "(//*[@class = \"ui-corner-all\"])[1]")]
        IWebElement joorSuggestedInput;

        [FindsBy(How = How.XPath, Using = "(//*[text() = \"Start Order\"])[2]")]
        IWebElement startOrderButton;

        public StartWebOrderOverlay(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public StylesPage initiateStartOrder()
        {
            try
            {
                orderForField.Click();
                orderForField.SendKeys("j");
                Thread.Sleep(2000);
                joorSuggestedInput.Click();
                startOrderButton.Click();
            }
            catch (WebDriverException e)
            {
                Assert.Fail();
            }

            return new StylesPage(driver);

        }

    }
}
