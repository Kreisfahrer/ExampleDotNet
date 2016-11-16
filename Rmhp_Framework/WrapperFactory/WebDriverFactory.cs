using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;


namespace Rmhp_Framework.WrapperFactory
{
    class WebDriverFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }


        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (driver == null)
                    {
                        driver = new FirefoxDriver();
                        Drivers.Add("Firefox", Driver);
                    }
                    break;

                case "IE":
                    if (driver == null)
                    {
                        driver = new InternetExplorerDriver(@"C:\Libraries\IEDriverServer_x64_2.53.1");
                        Drivers.Add("IE", Driver);
                    }
                    break;

                case "Chrome":
                    if (driver == null)
                    {
                        driver = new ChromeDriver(@"C:\Libraries\ChromeDriver2.25");
                        Drivers.Add("Chrome", Driver);
                    }
                    break;

                case "Edge":
                    if (driver == null)
                    {
                        driver = new EdgeDriver(@"C:\Libraries\EdgeWebDriver");
                        Drivers.Add("Edge", Driver);
                    }
                    break;
            }
        }

        public static void LoadApplication(string url)
        {
            Driver.Url = url;
        }

        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }
    }
}