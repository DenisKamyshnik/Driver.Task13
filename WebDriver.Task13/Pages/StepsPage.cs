using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebDriver.Task13.Pages
{
    class StepsPage
    {
        public StepsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//strong[@aria-current = 'step']")]
        public IWebElement ActiveStep { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@name = 'email']")]
        public IWebElement ContactEmailField { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@name = 'phone']")]
        public IWebElement ContactNumberField { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@name = 'passengers.0.firstName']")]
        public IWebElement ContactFirstNameField { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@name = 'passengers.0.lastName']")]
        public IWebElement ContactLastNameField { get; set; }


        [FindsBy(How = How.XPath, Using = "//select[@name = 'passengers.0.gender']")]
        public IWebElement GenderDropDown { get; set; }


        [FindsBy(How = How.XPath, Using = "//option[@value = 'M']")]
        public IWebElement SelectMValue { get; set; }


        public StepsPage SelectGender()
        {
            GenderDropDown.Click();
            SelectMValue.Click();
            return this;
        }


        [FindsBy(How = How.XPath, Using = "//input[@name = 'month']")]
        public IWebElement MonthField { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@name = 'day']")]
        public IWebElement DayField { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@name = 'year']")]
        public IWebElement YearField { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@name = 'passengers.0.passportNumber']")]
        public IWebElement PassportNumberField { get; set; }


        [FindsBy(How = How.XPath, Using = "//select[@name = 'passengers.0.nationality']")]
        public IWebElement CountryIssuedDropDown { get; set; }


        [FindsBy(How = How.XPath, Using = "//select[@name = 'passengers.0.nationality']/option[@value = 'AF']")]
        public IWebElement SelectAfValue { get; set; }

        public StepsPage SelectCountry()
        {
            CountryIssuedDropDown.Click();
            SelectAfValue.Click();
            return this;
        }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Next')]")]
        public IWebElement NextButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@id = 'passengers.0.expiryDate']/div/div/div[1]/div/div/input")]
        public IWebElement ExpirationMonth { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@id = 'passengers.0.expiryDate']/div/div/div[2]/div/div/input")]
        public IWebElement ExpirationDay { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@id = 'passengers.0.expiryDate']/div/div/div[3]/div/div/input")]
        public IWebElement ExpirationYear { get; set; }


        [FindsBy(How = How.XPath, Using = "//button[text() = 'Add']")]
        public IWebElement AddButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'mxqkpy-radio-input')]")]
        public IWebElement OneBagRadioButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//button[text() = 'Done']")]
        public IWebElement DoneButton { get; set; }

      //  [FindsBy(How = How.XPath, Using = "//select[@class= 'css-1k0jlfl']")]

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Skip')]")]
        public IWebElement SkipButton { get; set; }

       // public IWebElement ContactNumberPopUp { get; set; }

        [FindsBy(How = How.XPath, Using = "//option[@value = 'UA']")]
        public IWebElement SelectUAValue { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[text() = 'Traveler details']/../../../div[2]")]
        public IWebElement TravelerDetailsSection { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[text() = 'Contact details']/../div[2]")]
        public IWebElement ContactDetailsSection { get; set; }
        
    }
}
