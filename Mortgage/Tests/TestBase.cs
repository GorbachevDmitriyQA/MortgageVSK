using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using System.Runtime.CompilerServices;
using System.Text;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace MortgageTests
{
    public class TestBase 
    {
        protected AppManager app;

        [SetUp]
        public void SetUpAppManager()
        {
            app = new AppManager();
        }

        [TearDown]
        public void StopAppManager()
        {
            app.Driver.Quit();
        }
    }
}
