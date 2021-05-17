using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
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
            LinkProductCategory.Click();
        }

        public void SelectElement(string elementId)
        {
            select = new SelectElement(webDriver.FindElement(By.Id(elementId)));
        }

        public void SortAsc(string textSelector)
        {
            select.SelectByText(textSelector);
        }

        //public bool IsSortedAsc()
        //{
        //    var firstItemFromPage = webDriver.FindElement(By.ClassName("product-men"));
        //    Console.WriteLine("First product from page: " + firstItemFromPage);
        //    var item = webDriver.FindElement(By.LinkText("Analog Watch"));
        //    Console.WriteLine("Product that should be first: " + item);
        //    if (firstItemFromPage == item)
        //    {
        //        webDriver.Close();
        //        return true;
        //    }

        //    webDriver.Close();
        //    return false;
        //}

        public List<string> GetProductNames(string element)
        {
            List<string> names = new List<string>();
            IReadOnlyList<IWebElement> products = webDriver.FindElements(By.CssSelector(element));

            foreach (IWebElement product in products)
            {
                names.Add(product.Text);
            }

            return names;
        }

        public bool IsListSorted(List<string> list, string contains)
        {
            string last = list.Find(u => u.Contains(contains));
            for (int i = 1; i < list.Count; i++)
            {
                string current = list.Find(u => u.Contains($"{i}"));
                Console.WriteLine(current);
                if (last.CompareTo(current) > 0)
                {
                    webDriver.Close();
                    return true;
                }

                last = current;
            }

            webDriver.Close();
            return false;
        }

    }
}
