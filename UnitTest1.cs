using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;


namespace Two_mails_Tests
{
    
    public class Tests
    {
        private IWebDriver driver;

        private readonly By _inputmail = By.XPath("//input[@type='email']");
        private readonly By _inputpassword = By.XPath("//input[@type='password']");
        private readonly By _enterbutton= By.XPath("//div[@class='button-content flex items-center login plr-button justify-center']");
        private readonly By _newmailrbutton = By.XPath("//button[@title='Новое сообщение']");
        private readonly By _inputwhom = By.XPath("//input[@aria-label='Кому']");
        private readonly By _inputtitle = By.XPath("//input[@aria-label='Тема']");
        private readonly By _inputext= By.XPath("//div[@role='textbox']");
        private readonly By _sendmailbutton = By.XPath("//button[@title='Отправить']");

        private readonly By _inputbox = By.XPath("//input[@type='checkbox']");
        //private readonly By _click = By.XPath("//body");
        private readonly By _listlmail= By.XPath("//ul[@class='list list-alternate-background fill-absolute click mail-list']/li");

        private readonly By _findtitle = By.XPath("//div[@class='subject text-break selectable']");
        private readonly By _findtext = By.XPath("//div[@class='selectable touch-callout break-word-links']/div");

        private string[] mailArray = { "edison_bred_0999@tutanota.com", "tomas_darvin_12345@tutanota.com" };
        private string[] passwordArray = { "123456789qweasdzxc", "1234567890cxzdsaewq" };
       
        
        string _title = Faker.TextFaker.Sentences(1).ToString();

        string _textmail = Faker.TextFaker.Sentences(4).ToString();
        

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
            
            Thread.Sleep(1000);
            var signin1 = driver.FindElement(_inputmail);
            signin1.SendKeys(mailArray[0]);


            var signin2 = driver.FindElement(_inputpassword);
            signin2.SendKeys(passwordArray[0]);

            var signin9 = driver.FindElement(_inputbox);
            signin9.Click();

            var signin3 = driver.FindElement(_enterbutton);
            signin3.Click();

            Thread.Sleep(5000);
            var signin4 = driver.FindElement(_newmailrbutton);
            signin4.Click();

            Thread.Sleep(1000);
            var signin5 = driver.FindElement(_inputwhom);
            signin5.SendKeys(mailArray[1]);

            var signin6 = driver.FindElement(_inputtitle);
            signin6.SendKeys(_title);

            var signin7 = driver.FindElement(_inputext);
            signin7.SendKeys(_textmail);
            
            var signin8 = driver.FindElement(_sendmailbutton);
            signin8.Click();

            Thread.Sleep(5000);
            driver.Quit();
        }

        [Test]
        public void Test2()
        {
            Thread.Sleep(1000);
            var signin1 = driver.FindElement(_inputmail);
            signin1.SendKeys(mailArray[1]);


            var signin2 = driver.FindElement(_inputpassword);
            signin2.SendKeys(passwordArray[1]);

            var signin9 = driver.FindElement(_inputbox);
            signin9.Click();

            var signin3 = driver.FindElement(_enterbutton);
            signin3.Click();


            Thread.Sleep(5000);
            var signin5 = driver.FindElement(_listlmail);
            signin5.Click();

            Thread.Sleep(1000);
            string actualTitle = driver.FindElement(_findtitle).Text;
            actualTitle = actualTitle.Replace(" ", string.Empty);
            _title = _title.Replace(" ", string.Empty);

            Assert.AreEqual(_title, actualTitle, "Test fail, title is wrong");

            Thread.Sleep(1000);
            string actualText = driver.FindElement(_findtext).Text;
            actualText = actualText.Replace(" ", string.Empty);
            _textmail = _textmail.Replace(" ", string.Empty);

            Assert.AreEqual(_textmail, actualText, "Test fail, text is wrong");

        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(2000);
            driver.Quit();
        }
    }
}