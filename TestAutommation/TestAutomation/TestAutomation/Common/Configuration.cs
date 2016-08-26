using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Common
{
   public class Configuration
    {
        public static IWebDriver driver;

        [TestInitialize()]
        public void TestIntialise()
        {
            //string ieServerFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName +
            //       "\\IEWebDriver";
            string ieServerFilePath =Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName,"packages","Selenium.WebDriver.IEDriver.2.53.1.1","driver");
            //This is needed due to environment configurations
            var options = new InternetExplorerOptions()
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                RequireWindowFocus = true,
                UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Accept
            };
            driver = new InternetExplorerDriver(ieServerFilePath, options);
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
        }

       [TestCleanup()]
        public void TestCleanUp()
        {
            #region Code Injection
            //for (int i = 0; i < customLogCollection.Count; i++)
            //{
            //    if (customLogCollection[i] != null)
            //    {
            //        customReport.EndTest(customLogCollection[i]);
            //        customReport.Flush();
            //        customLogCollection[i] = null;
            //    }
            //}
            //customLogCollection.Clear();
            driver.Dispose(); driver.Quit();
            ClearBrowser();

            //winiumDriverProcess.Kill();
            #endregion


        }

        public void ClearBrowser()
        {
            #region Code Injection
            Console.Write("Parent Class");
            Process p = new Process();
            ProcessStartInfo ps = new ProcessStartInfo();
            ps.FileName = "cmd.exe";
            ps.Arguments = "/C RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 4351";
            p.StartInfo = ps;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            p.WaitForExit(30000);
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in Process.GetProcesses())
            {
                if (theprocess.ProcessName == "iexplore")
                {
                    theprocess.Kill();
                }
            }
            #endregion
        }
        
    }
}
