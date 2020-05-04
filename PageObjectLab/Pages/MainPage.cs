using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectLab.Pages
{
    public class MainPage
    {
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "menu-item-12045")]
        public IWebElement supportLink;

        [FindsBy(How = How.Id, Using = "menu-item-11969")]
        public IWebElement factionLink;

        [FindsBy(How = How.CssSelector, Using = "#works a")]
        public IList<IWebElement> factions;

        [FindsBy(How = How.Id, Using = "search-button")]
        public IWebElement searchButton;

        [FindsBy(How = How.Id, Using = "s1")]
        public IWebElement searchField;

        [FindsBy(How = How.CssSelector, Using = "#search-results-header a")]
        public IList<IWebElement> searchResults;

        [FindsBy(How = How.CssSelector, Using = "#search-results-header h2")]
        public IWebElement searchNoResult;

        public MainPage Search(string search)
        {
            searchButton.Click();
            searchField.Click();
            searchField.Clear();
            searchField.SendKeys(search);
            return this;
        }
    }
}
