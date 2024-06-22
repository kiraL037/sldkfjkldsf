using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qaaaa;
namespace TestQaaaa
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void RootsNull()
        {
            double a =1.2;
            double b =2.5;
            double c =3;
            double[] actual = Program.Qaaa(a, b, c);
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.GetLength(0) == 0);
        }
    }
}
