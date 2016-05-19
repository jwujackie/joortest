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

namespace Joor.PageClasses
{
    public class OrdersPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[text() = \"Orders\"]")]
        IWebElement orderMenuItem;

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, \"j-dropdown dropdown\")]//a[@data = \"Pending\"]")]
        IWebElement pendingSubMenuItem;

        [FindsBy(How = How.XPath, Using = "//*[@id = \"j-start-order-link\"]")]
        IWebElement startOrderSubMenuItem;

        public OrdersPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public StartOrderOverlay clickOnStartOrder()
        {
            try
            {
                Thread.Sleep(3000);
                string cssSelector = "#j-start-order-link";
                string jsCommandForMenuItemHover = "$('" + cssSelector + "').click();";
                ((IJavaScriptExecutor)driver).ExecuteScript(jsCommandForMenuItemHover);
                Thread.Sleep(3000);
            }
            catch (WebDriverException e)
            {
                Assert.Fail();
            }
            return new StartOrderOverlay(driver);
        }

        public PendingOrderPage navigateToPendingOrdersPage()
        {
            try
            {
                Actions action = new Actions(driver);
                action.MoveToElement(orderMenuItem).Click().Perform();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//*[contains(@class, \"j - dropdown dropdown\")]//a[@data = \"Pending\"]")));

                pendingSubMenuItem.Click();
            }
            catch (WebDriverException e)
            {
                Assert.Fail();
            }
            return new PendingOrderPage(driver);


        }
    }
}
