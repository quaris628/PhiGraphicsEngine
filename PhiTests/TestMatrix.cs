using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using phi.phisics.PhiMath;

namespace PhiTests
{
   [TestClass]
   public class TestMatrix
   {
      [TestMethod]
      public void MatrixEqualTest_01()
      {
         float[,] a = { {1, 2},
                        {3, 4} };

         float[,] b = { { 4, 3 },
                        { 2, 1 } };

         Matrix m1 = new Matrix(a);
         Matrix m2 = new Matrix(b);
         Assert.IsFalse(m1 == m2);
      }
      [TestMethod]
      public void MatrixEqualTest_02()
      {
         float[,] a = { { 1, 2 },
                        { 3, 4 } };

         float[,] b = { { 1, 2 },
                        { 3, 4 } };

         Matrix m1 = new Matrix(a);
         Matrix m2 = new Matrix(b);
         Assert.IsTrue(m1 == m2);
      }

      [TestMethod]
      public void MatrixEqualTest_03()
      {
         float[,] a = { { 1, 2 },
                        { 3, 4 } };

         float[,] b = { { 1, 2 },
                        { 3, 4 },
                        { 5, 6 } };

         Matrix m1 = new Matrix(a);
         Matrix m2 = new Matrix(b);
         Assert.IsTrue(m1 != m2);
      }

      [TestMethod]
      public void MatrixEqualTest_04()
      {
         float[,] a = { { 1, 2 },
                        { 3, 4 },
                        { 5, 6 } };

         float[,] b = { { 1, 2 },
                        { 3, 4 },
                        { 5, 6 } };

         Matrix m1 = new Matrix(a);
         Matrix m2 = new Matrix(b);
         Assert.IsTrue(m1 == m2);
      }
      [TestMethod]
      public void MatrixMultiplicationTest_01()
      {
         float[,] a = { {1, 2}, 
                        {3, 4} };

         float[,] b = { { 4, 3 }, 
                        { 2, 1 } };

         float[,] result = { { 8, 5 },
                             { 20, 13 } };

         Matrix m1 = new Matrix(a);
         Matrix m2 = new Matrix(b);

         Matrix m3 = m1 * m2;
         Matrix m4 = new Matrix(result);
         Assert.IsTrue(m3 == m4);
      }

      [TestMethod]
      [ExpectedException(typeof(MatrixException), "Invalid Matrix Dimensions")]
      public void MatrixMultiplicationTest_02()
      {
         float[,] a = { {1, 2},
                        {3, 4} };

         float[,] b = { { 1, 2 },
                        { 3, 4 },
                        { 5, 6 } };

         float[,] result = { { 8, 5 },
                             { 20, 13 } };

         Matrix m1 = new Matrix(a);
         Matrix m2 = new Matrix(b);

         Matrix m3 = m1 * m2;
         Matrix m4 = new Matrix(result);
         Assert.IsTrue(m3 == m4);
      }

      [TestMethod]
      public void MatrixMultiplicationTest_03()
      {
         float[,] a = { {1, 2},
                        {3, 4} };

         float[,] b = { { 1, 2, 3 },
                        { 4, 5, 6 } };

         float[,] result = { { 9, 12, 15 },
                             { 19, 26, 33 } };

         Matrix m1 = new Matrix(a);
         Matrix m2 = new Matrix(b);

         Matrix m3 = m1 * m2;
         Matrix m4 = new Matrix(result);
         Assert.IsTrue(m3 == m4);
      }
   }
}
