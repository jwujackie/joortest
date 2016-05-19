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
    public class ReviewPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "(//*[@href = \"/orders\"])[1]")]
        IWebElement ordersLink;


        public ReviewPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public PendingOrderPage navigateToPendingOrdersPage()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("page")));

                ordersLink.Click();

                string cssSelector = "[class*=\"j-dropdown dropdown\"]>li>a[data=\"Pending\"]";
                string jsCommandForMenuItemHover = "$('" + cssSelector + "').click();";
                ((IJavaScriptExecutor)driver).ExecuteScript(jsCommandForMenuItemHover);
                Thread.Sleep(3000);
            }
            catch (WebDriverException e)
            {
                Assert.Fail();
            }
            return new PendingOrderPage(driver);
        }
    }
}
