using LAB5.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace LAB5.Steps
{
    [Binding]
    public class AscendingOrderSteps
    {
        ProductPage productPage = null;

        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://adoring-pasteur-3ae17d.netlify.app");
            productPage = new ProductPage(webDriver);
        }

        [Given(@"I click on any product category")]
        public void GivenIClickOnAnyProductCategory()
        {
            productPage.ClickProductCategory();
        }
        
        [Given(@"I click on sort by function")]
        public void GivenIEnterClickOnSortByFunction()
        {
            productPage.SelectElement("country1");
        }
        
        [Given(@"I select ascending sort Name\(A-Z\)")]
        public void GivenISelectAscendingSortNameA_Z()
        {
            productPage.SortAsc("Name(A - Z)");
        }
        
        [Then(@"I should see product page sorted in ascending way")]
        public void ThenIShouldeSeeProductPageSortedInAscendingWay()
        {
            var productName = productPage.GetProductNames("div.single-pro");
            Assert.That(productPage.IsListSorted(productName, ".col-md-3"), Is.True);
        }
    }
}
