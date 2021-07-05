using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebDriver.Task13.Pages
{
    public class SearchingResultsPage
    {
        public SearchingResultsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Fastest')]")]
        public IWebElement FastestTab { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class = 'css-1ctylyz']/div[last()]")]
        public IWebElement Lastpage { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'searchResultsList')]/div[last()]")]
        public IWebElement LastSearchResult { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class = 'Text-module__root--variant-small_1___16UY4']")]
        public IWebElement MaxJourneyTime { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'searchResultsList')]/div[last()]//button[@data-testid = 'searchresults_select_flight']")]
        public IWebElement SelectLastTicketButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Select')]")]
        public IWebElement SelectButtonInPopUp { get; set; }

    }
}
