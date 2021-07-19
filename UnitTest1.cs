using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Two_mails_Tests
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By _inputmail = By.XPath("//input[@type='email']");
        private readonly By _inputpassword = By.XPath("//input[@type='password']");

        private string[] mailArray = { "test-twomails-1@tutanota.com", "test-twomails-2@tutanota.com" };
        private string[] passwordArray = { "1234567890qweasdzxc", "1234567890cxzdsaewq" };

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-application-cache"); // to disable cache
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://mail.tutanota.com/login");
            driver.Manage().Window.Maximize(); 
        }

        [Test]
        public void Test1()
        {
            
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}