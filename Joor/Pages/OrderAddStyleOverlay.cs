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
    public class OrderAddStyleOverlay
    {
        private IWebDriver driver;
        [FindsBy(How = How.XPath, Using = "(//*[@class = \"j-order-size\"]//input)[1]")]
        IWebElement sizeField;
        
        [FindsBy(How = How.XPath, Using = "//*[@class = \"order\"]//a[text()=\"Add & View Cart\"]")]
        IWebElement addAndViewCartButton;
            
        public OrderAddStyleOverlay(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public CartPage enterQuantityAndContinue()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("order")));
                sizeField.Click();
                sizeField.Clear();
                sizeField.SendKeys("1");
                addAndViewCartButton.Click();
            }
            catch (WebDriverException e)
            {
                Assert.Fail();
            }
            return new CartPage(driver);
        }
    }
}
