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
    public class CheckoutPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[text() = \"CUSTOM PO#\"]/following-sibling::input")]
        IWebElement customPO;

        [FindsBy(How = How.XPath, Using = "(//*[text() = \"Select payment method...\"])[2]")]
        IWebElement selectPaymentMethod;

        [FindsBy(How = How.XPath, Using = "//*[@id = \"selUTG_chzn_o_1\"]")]
        IWebElement payment;

        [FindsBy(How = How.XPath, Using = "(//*[@class = \"chzn-drop\"])[11]")]
        IWebElement dropDown;
        

        [FindsBy(How = How.XPath, Using = "//*[@data-action = \"pending\"]")]
        IWebElement pendingButton;

        [FindsBy(How = How.XPath, Using = "//*[@id = \"selUTG_chzn\"]/div/div/input")]
        IWebElement typeField;

        public string uniquePONumber = "unique1";

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public ConfirmPendingOrderOverlay enterCustomPO()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[text() = \"CUSTOM PO#\"]/following-sibling::input")));

                customPO.Click();
                customPO.SendKeys(uniquePONumber);
                selectPaymentMethod.Click();
                dropDown.Click();

                string cssSelector = "#selUTG_chzn_o_1";
                string jsCommandForMenuItemHover = "$('" + cssSelector + "').click();";
                ((IJavaScriptExecutor)driver).ExecuteScript(jsCommandForMenuItemHover);

                pendingButton.Click();
            }
            catch(WebDriverException e)
            {
                Assert.Fail();
            }

            return new ConfirmPendingOrderOverlay(driver);
        }
    }
}
