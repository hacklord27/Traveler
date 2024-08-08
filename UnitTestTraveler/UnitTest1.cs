using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace YourNamespace.Tests
{
    public class RegistrationTests
    {
        private IWebDriver driver;
        private string baseUrl = "URL_of_your_website"; // Thay URL_of_your_website bằng URL thực tế của trang web của bạn

        [SetUp]
        public void Setup()
        {
            // Khởi tạo Chrome WebDriver
            driver = new ChromeDriver();
        }

        [TearDown]
        public void Cleanup()
        {
            // Đóng trình duyệt sau khi mỗi test case kết thúc
            driver.Quit();
        }
    }
}
