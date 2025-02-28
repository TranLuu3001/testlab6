using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Lab6._2
{
    [TestClass]
    public class Test1
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            var options = new ChromeOptions();

            options.AddArgument(@"user-data-dir=C:\Users\Admin\AppData\Local\Google\Chrome\User Data");
            options.AddArgument("--profile-directory=Profile 5");
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalOption("useAutomationExtension", false);
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void SearchUdemyOnGoogle()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            IWebElement searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("Udemy");
            searchBox.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(3000);
            IWebElement udemyLink = driver.FindElement(By.PartialLinkText("Udemy: Online Courses"));
            udemyLink.Click();
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Đã truy cập vào: " + driver.Url);
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();

            Console.WriteLine("Đã kết thúc kiểm thử, đóng trình duyệt.");
        }
    }
}
