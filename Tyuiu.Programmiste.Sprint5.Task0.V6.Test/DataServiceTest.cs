
using Tyuiu.Programmiste.Sprint5.Task0.V6.Lib;
namespace Tyuiu.Programmiste.Sprint5.Task0.V6.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {



        [TestMethod]
        public void SaveToFileTextData_WithXEquals1_ReturnsCorrectValue()
        {
            DataService ds = new DataService();
            string result = ds.SaveToFileTextData(1);
            Assert.AreEqual("0,707", result);
        }

        [TestMethod]
        public void SaveToFileTextData_WithXEquals2_ReturnsCorrectValue()
        {
            DataService ds = new DataService();
            string result = ds.SaveToFileTextData(2);
            Assert.AreEqual("0,816", result);
        }

        [TestMethod]
        public void SaveToFileTextData_WithXEquals4_ReturnsCorrectValue()
        {
            DataService ds = new DataService();
            string result = ds.SaveToFileTextData(4);
            Assert.AreEqual("0,894", result);
        }

        [TestMethod]
        public void SaveToFileTextData_WithXEquals5_ReturnsCorrectValue()
        {
            DataService ds = new DataService();
            string result = ds.SaveToFileTextData(5);
            Assert.AreEqual("0,913", result);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void SaveToFileTextData_WithXEqualsZero_ThrowsException()
        {
            DataService ds = new DataService();
            ds.SaveToFileTextData(0);
        }
    }
}