using proj;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for MainWindowTest and is intended
    ///to contain all MainWindowTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MainWindowTest
    {


        /// <summary>
        ///A test for TimeLess
        ///</summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TimeLessTest()
        {
            int t = 30; 
            MainWindow.TimeLess(t);
        }
    }
}
