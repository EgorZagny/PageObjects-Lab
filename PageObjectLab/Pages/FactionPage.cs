using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectLab.Pages
{
    class FactionPage
    {
        private IWebDriver driver;

        public FactionPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "elementor-button-text")]
        public IList<IWebElement> sections;
    }
}
