using ZTableGenerator;

namespace ZTableArithmeticUnitTests
{
    [TestClass]
    public class ArithmeticTests
    {
        [TestMethod]
        public void TestNormalCDF()
        {
            Assert.AreEqual(0.5,
                Math.Round(Arithmetic.NormalCDF(0, Program.p, Program.a1, Program.a2
                , Program.a3, Program.a4, Program.a5), 4));
            Assert.AreEqual(0.5398,
                Math.Round(Arithmetic.NormalCDF(0.1, Program.p, Program.a1, Program.a2
                , Program.a3, Program.a4, Program.a5), 4));
            Assert.AreEqual(0.5040,
                Math.Round(Arithmetic.NormalCDF(0.01, Program.p, Program.a1, Program.a2
                , Program.a3, Program.a4, Program.a5), 4));
            Assert.AreEqual(0.5438,
                Math.Round(Arithmetic.NormalCDF(0.11, Program.p, Program.a1, Program.a2
                , Program.a3, Program.a4, Program.a5), 4));
        }

        [TestMethod]
        public void TestRangeAroundZero()
        {
            CollectionAssert.AreEqual(new[] { -0.2, -0.1, 0, 0.1, 0.2 },
                Arithmetic.RangeAroundZero(0.2, 0.1));
        }

        [TestMethod]
        public void TestRangeAboveZero()
        {
            CollectionAssert.AreEqual(new[] { 0, 0.1, 0.2, 0.3, 0.4, 0.5 },
                Arithmetic.RangeAboveZero(0.5, 0.1));
        }

        [TestMethod]
        public void TestCreateRange()
        {
            CollectionAssert.AreEqual(new double[,]
                {
                    { 0, 0.01, 0.02 },
                    { 0.1, 0.11, 0.12 },
                    { 0.2, 0.21, 0.22 }
                }, 
            Arithmetic.CreateRange(new[] { 0, 0.1, 0.2 }, new[] { 0, 0.01, 0.02 }));
        }
    }
}