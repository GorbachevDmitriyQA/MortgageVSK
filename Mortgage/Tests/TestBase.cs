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

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }
    }
}
