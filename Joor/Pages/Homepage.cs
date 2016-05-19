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
using OpenQA.Selenium.Support.UI;


namespace Joor.PageClasses
{
    public class Homepage
    {
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "login-button")]
        IWebElement loginButton;

        [FindsBy(How = How.Id, Using = "login-name")]
        IWebElement username;

        [FindsBy(How = How.Id, Using = "login-pw")]
        IWebElement password;

        [FindsBy(How = How.CssSelector, Using = "input.gold-button.center.sign-in")]
        IWebElement signInButton;

        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public OrdersPage signIn()
        {
            try
            {
                loginButton.Click();
                username.Click();
                username.SendKeys("qatest1");
                password.Click();
                password.SendKeys("qatest1");
                signInButton.Click();
            }
            catch(WebDriverException e)
            {
                Assert.Fail();
            }
            return new OrdersPage(driver);
        }


    }
}
