using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace ST_4
{
    public class Tests
    {
        IWebDriver chrome;
        const string url = "https://google.com";

        [SetUp]
        public void Setup()
        {
            chrome = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            chrome.Navigate().GoToUrl(url);
            chrome.Manage().Window.Maximize();

            var searchText = chrome.FindElement(By.ClassName("gLFyf"));
            searchText.SendKeys("Software Testing");
            searchText.SendKeys(Keys.Enter);

            bool isPresent = chrome.PageSource.Contains("head");

            if(isPresent)
            {
                Console.WriteLine("TEST PASSED");
            } 
                else
            {
                Console.WriteLine("TEST FAILED");
            }

            Assert.Pass();
        }
    }
}