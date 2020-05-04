using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using PageObjectLab.Pages;

namespace PageObjectLab
{
    [TestFixture]
    public class TestClass
    {
        private IWebDriver driver;
        private string url = "https://bfmereforged.org/";


        [SetUp]
        public void Init()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public void TheEnd()
        {
            driver.Close();
        }

        [Test]
        public void TestNav()
        {
            var mainPage = new MainPage(driver);
            mainPage.supportLink.Click();
            var supPage = new SupportPage(driver);
            var text = supPage.supportHeader.GetAttribute("innerText");
            Assert.AreEqual(text, "SUPPORT US");
        }
        [Test]
        public void TestLinksImages()
        {
            var mainPage = new MainPage(driver);
            mainPage.factionLink.Click();
            var links = mainPage.factions;
            string[] factions = { "isengard", "factions/elves", "factions/mordor" };
            for (int i = 0; i < factions.Length; i++)
            {
                Assert.AreEqual(links[i].GetAttribute("href"), url + factions[i] + '/');
            }
        }
        [Test]
        public void TestFactionsPage()
        {
            var mainPage = new MainPage(driver);
            mainPage.factionLink.Click();
            mainPage.factions[0].Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10000);
            var sections = new FactionPage(driver).sections;
            string[] names = { "About faction", "Units", "Heroes", "Buildings", "Spellbook" };
            Assert.AreEqual(sections.Count, names.Length);
            for (int i = 0; i < names.Length; i++)
            {
                Assert.AreEqual(sections[i].GetAttribute("innerText"), names[i]);
            }
        }
        [Test]
        public void TestSearch1()
        {
            var page = new MainPage(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15000);
            page.Search("isengard");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10000);
            var results = page.searchResults;
            bool b = false;
            foreach (var result in results)
            {
                if (result.GetAttribute("href") == url + "isengard/")
                {
                    Assert.IsTrue(true);
                    b = true;
                    break;
                }
            }
            if (!b) Assert.IsTrue(false);
        }
        [Test]
        public void TestSearch2()
        {
            var page = new MainPage(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10000);
            page.Search("dorwinion");
            var result = page.searchNoResult;
            Assert.AreEqual(result.GetAttribute("innerText"), "No results found.");
        }
    }
}
