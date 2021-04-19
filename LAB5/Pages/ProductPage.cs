using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace LAB5.Pages
{
    public class ProductPage
    {
        private readonly IWebDriver webDriver;

        SelectElement select = null;

        public ProductPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement LinkProductGender => webDriver.FindElement(By.PartialLinkText("Men's wear"));
        public IWebElement LinkProductCategory => webDriver.FindElement(By.LinkText("Clothing"));

        public void ClickProductCategory()
        {
            LinkProductGender.Click();
            Thread.Sleep(3000);
            LinkProductCategory.Click();
            Thread.Sleep(3000);
        }

        public void SelectElement()
        {
            select = new SelectElement(webDriver.FindElement(By.Id("country1")));
            Thread.Sleep(3000);
        }

        public void Sort()
        {
            select.SelectByText("Name(A - Z)");
            Thread.Sleep(3000);
        }

        public bool IsSortedAsc()
        {
            var firstItemFromPage = webDriver.FindElement(By.ClassName("product-men"));
            Console.WriteLine("First product from page: " + firstItemFromPage);
            var item = webDriver.FindElement(By.LinkText("Analog Watch"));
            Console.WriteLine("Product that should be first: " + item);
            if (firstItemFromPage != item)
            {
                webDriver.Close();
                return true;
                
            }

            webDriver.Close();
            return false;
        }
    }
}
