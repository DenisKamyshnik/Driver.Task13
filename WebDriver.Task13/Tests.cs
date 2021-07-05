using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriver.Task13.Pages;

namespace WebDriver.Task13
{
    public class Tests
    {
        private IWebDriver chromeDriver;

        private WebDriverWait wait;

        private string departmentStation = "Kyiv Boryspil";

        private string arrivalStation = "Copenhagen";
   

        [SetUp]
        public void start_Browser()
        {
            chromeDriver = new ChromeDriver();

            chromeDriver.Manage().Window.Maximize();

            wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));

            chromeDriver.Navigate().GoToUrl("https://flights.booking.com/");    
            
        }

        private Boolean existsElementByXpath(String xpath)
        {
            try
            {
               chromeDriver.FindElement(By.XPath(xpath));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        [Test]
        public void Task13()
        {
            MainPage mainPage = new MainPage(chromeDriver);

            SearchingResultsPage searchingResultsPage = new SearchingResultsPage(chromeDriver);

            StepsPage stepsPage = new StepsPage(chromeDriver);

            Actions actions = new Actions(chromeDriver);

            wait.Until(e => e.FindElement(By.XPath("//button")));

            mainPage.ChangeLanguageButton.Click();

            mainPage.SetEnglishLanguageButton.Click();

            mainPage.OneWayCheckBox.Click();

            mainPage.DepartureStationContainer.Click();

            mainPage.CrossIconDepartureStation.Click();

            mainPage.TypeFrom(departmentStation);

            wait.Until(chromeDriver => mainPage.ItemfromSearchDepartureStation.Displayed);

            mainPage.ItemfromSearchDepartureStation.Click();

            wait.Until(chromeDriver => mainPage.ArrivalStationInput.Displayed);

            mainPage.TypeTo(arrivalStation);

            wait.Until(chromeDriver => mainPage.ItemfromSearchArrivalStation.Displayed);

            mainPage.ItemfromSearchArrivalStation.Click();

            mainPage.OneWayCheckBox.Click();
            wait.Until(chromeDriver => mainPage.DateFromPopUp.Displayed);

            mainPage.DateFromPopUp.Click();

            wait.Until(chromeDriver => mainPage.SearchButton.Displayed);

            if (existsElementByXpath("//button[@id = 'onetrust-accept-btn-handler']"))
            {
                mainPage.AcceptCookieButton.Click();
            }

            mainPage.SearchButton.Click();

            wait.Until(chromeDriver => chromeDriver.FindElement(By.XPath("//div[contains(text(), 'results')]")));

            StringAssert.Contains("results", chromeDriver.FindElement(By.XPath("//div[contains(text(), 'results')]")).Text);

            StringAssert.Contains("Best", chromeDriver.FindElement(By.XPath("//div[contains(text(), 'Best')]")).Text);

            StringAssert.Contains("Cheapest", chromeDriver.FindElement(By.XPath("//div[contains(text(), 'Cheapest')]")).Text);

            StringAssert.Contains("Fastest", searchingResultsPage.FastestTab.Text);

            StringAssert.AreEqualIgnoringCase("Departs from Boryspil International Airport", chromeDriver.FindElement(By.XPath("//div[text() = 'Departs from Boryspil International Airport']")).Text);

            StringAssert.AreEqualIgnoringCase("Arrives to Copenhagen Airport", chromeDriver.FindElement(By.XPath("//div[text() = 'Arrives to Copenhagen Airport']")).Text);

            searchingResultsPage .FastestTab.Click();

            wait.Until(e => e.FindElement(By.XPath("//div[@class = 'css-1ctylyz']/div[last()]")));

            searchingResultsPage.Lastpage.Click();

            wait.Until(e => e.FindElement(By.XPath(" //div[contains(@class, 'searchResultsList')]/div[last()]")));

            actions.MoveToElement(searchingResultsPage.SelectLastTicketButton);

            StringAssert.Contains(searchingResultsPage.MaxJourneyTime.Text, searchingResultsPage.LastSearchResult.Text);

            searchingResultsPage.SelectLastTicketButton.Click();

            wait.Until(chromeDriver => searchingResultsPage.SelectButtonInPopUp.Displayed);

            actions.MoveToElement(searchingResultsPage.SelectButtonInPopUp);

            searchingResultsPage.SelectButtonInPopUp.Click();

            wait.Until(chromeDriver => stepsPage.ActiveStep.Displayed);

            if (existsElementByXpath("//div[text() ='Select your ticket type']"))
            {
                stepsPage.NextButton.Click();
            }

            Assert.AreEqual("Who's flying?", stepsPage.ActiveStep.Text);

            stepsPage.ContactEmailField.SendKeys("dkamyshnik66@gmail.ru");

            stepsPage.ContactNumberField.SendKeys("0984144269");

            stepsPage.ContactFirstNameField.SendKeys("Denis");

            stepsPage.ContactLastNameField.SendKeys("Kamyshnik");

            stepsPage.SelectGender();

            stepsPage.MonthField.SendKeys("12");

            stepsPage.DayField.SendKeys("22");

            stepsPage.YearField.SendKeys("1999");

            wait.Until(chromeDriver => stepsPage.NextButton);

            actions.MoveToElement(stepsPage.PassportNumberField);

            stepsPage.PassportNumberField.SendKeys("12345678");

            stepsPage.SelectCountry();

            stepsPage.ExpirationMonth.SendKeys("12");

            stepsPage.ExpirationDay.SendKeys("22");

            stepsPage.ExpirationYear.SendKeys("2030");

            stepsPage.NextButton.Click();

            wait.Until(chromeDriver  => chromeDriver.FindElement(By.XPath("//ol/li[3]/strong[@aria-current = 'step']")));

            if (existsElementByXpath("//button[text() = 'Add']"))
            {
                Assert.AreEqual("Customize your flight", stepsPage.ActiveStep.Text);

                actions.MoveToElement(stepsPage.AddButton);

                stepsPage.AddButton.Click();

                wait.Until(chromeDriver => stepsPage.OneBagRadioButton.Displayed);

                actions.MoveToElement(stepsPage.OneBagRadioButton).Click();

                stepsPage.OneBagRadioButton.Click();

                stepsPage.DoneButton.Click();

                stepsPage.NextButton.Click();
            }

            stepsPage.SkipButton.Click();

            wait.Until(chromeDriver => stepsPage.ContactDetailsSection.Displayed);

            Assert.AreEqual("Check and pay", stepsPage.ActiveStep.Text);

            Assert.AreEqual("Denis Kamyshnik\r\nAdult · Male · Dec 22, 1999\r\n12345678 · AF · 2030-12-22", stepsPage.TravelerDetailsSection.Text);

            Assert.AreEqual("+380984144269\r\ndkamyshnik66@gmail.ru", stepsPage.ContactDetailsSection.Text);
            }

        [TearDown]
        public void close_Browser()
        {
            chromeDriver.Quit();
        }

    }
}