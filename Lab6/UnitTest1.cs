using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Lab6
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            var options = new ChromeOptions();

            options.AddArgument(@"user-data-dir=C:\Users\Admin\AppData\Local\Google\Chrome\User Data");
            options.AddArgument("--profile-directory=Profile 5");
            // Khởi tạo trình duyệt Chrome
            driver = new ChromeDriver(options);
            // Mở trang Facebook
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            // Phóng to cửa sổ trình duyệt
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void TestLogin()
        {
            // Tìm và nhập địa chỉ email
            IWebElement emailField = driver.FindElement(By.Id("email"));
            emailField.SendKeys("luumytran3001@gmail.com");

            // Tìm và nhập mật khẩu
            IWebElement passwordField = driver.FindElement(By.Id("pass"));
            passwordField.SendKeys("TranLuu_5665@iamyoung@");

            // Tìm và nhấn nút đăng nhập
            IWebElement loginButton = driver.FindElement(By.Name("login"));
            loginButton.Click();

            // Đợi một chút để kiểm tra xem đăng nhập thành công hay không
            Thread.Sleep(3000);

            // Kiểm tra xem có đăng nhập thành công không bằng cách kiểm tra URL
            Assert.IsTrue(driver.Url.Contains("facebook.com")); 
            Thread.Sleep(10000);
        }

        [TestCleanup]
        public void TearDown()
        {
            // Đóng trình duyệt sau khi test xong
            driver.Quit();
        }
    }
}