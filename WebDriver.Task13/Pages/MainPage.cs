using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebDriver.Task13.Pages
{
    public class MainPage
    {
        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath , Using = "//button")]
        public IWebElement ChangeLanguageButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[text()='English (US)']")]
        public IWebElement SetEnglishLanguageButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class = 'css-1uvfooa']/div/ul/li[2]")]
        public IWebElement OneWayCheckBox { get; set; }


         [FindsBy(How = How.XPath, Using = "//label[@data-testid ='searchbox_origin']")]
         public IWebElement DepartureStationContainer { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@data-testid = 'searchbox_origin_input']")]
        public IWebElement DepartureStationInput { get; set; }

        public MainPage TypeFrom(string value)
        {
            DepartureStationInput.SendKeys(value);
            return this;
        }

        [FindsBy(How = How.ClassName, Using = "css-1eii3rq")]
        public IWebElement CrossIconDepartureStation { get; set; }


        [FindsBy(How = How.XPath, Using = "//li[contains(@class, 'ac-nested')]")]
        public IWebElement ItemfromSearchDepartureStation { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@data-testid='searchbox_destination_input']")]
        public IWebElement ArrivalStationInput { get; set; }


        public MainPage TypeTo(string value)
        {
            ArrivalStationInput.SendKeys(value);
            return this;
        }

        [FindsBy(How = How.XPath, Using = "//div[@class = 'css-tjh6t8']/div/label/input")]
        public IWebElement ItemfromSearchArrivalStation { get; set; }


        [FindsBy(How = How.XPath, Using = "//table/tbody/tr/td[@class = 'Calendar-module__date___3ZZ7p']")]
        public IWebElement DateFromPopUp { get; set; }


        [FindsBy(How = How.XPath, Using = "//button[@data-testid]")]
        public IWebElement SearchButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//button[@id = 'onetrust-accept-btn-handler']")]

        public IWebElement AcceptCookieButton { get; set; }

    }
}

