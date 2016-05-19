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

namespace Joor.Pages
{
    public class PendingOrderPage
    {
        private IWebDriver driver;

        public PendingOrderPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void verifyOrderExistsInPage()
        {
            try
            {
                CheckoutPage num = new CheckoutPage(driver);
                string poNum = num.uniquePONumber;
                string xpathOfPendingOrderLink = "//*[@class = \"link\"][contains(text(), \"" + poNum + "\")]";
                IWebElement pendingOrder = driver.FindElement(By.XPath(xpathOfPendingOrderLink));
                if (!pendingOrder.Displayed)
                    Assert.Fail();
            }
            catch (WebDriverException e)
            {
                Assert.Fail();
            }
    
        }

        
    }
}
