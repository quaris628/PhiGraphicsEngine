using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.phisics.Shapes;

namespace PhiTests
{
   [TestClass]
   public class TestEdge
   {
      #region IntersectionTests
      /*
       * Tests the functionality of the intersection algorithm
       */
      [TestMethod]
      public void IntersectionTest_1()
      {
         Edge e1 = new Edge(new point(0, 0), new point(1, 1));
         Edge e2 = new Edge(new point(0, 1), new point(1, 0));
         Assert.IsTrue(e1.Intersects(e2));
      }

      /*
       * Tests the functionality of the intersection algorithm
       * Parody: e1 is backwards
       */
      [TestMethod]
      public void IntersectionTest_2()
      {
         Edge e1 = new Edge(new point(1, 1), new point(0, 0));
         Edge e2 = new Edge(new point(0, 1), new point(1, 0));
         Assert.IsTrue(e1.Intersects(e2));
      }

      /**
       * Tests whether the intersection algorithm is communitive
       */
      [TestMethod]
      public void IntersectionTest_3()
      {
         Edge e1 = new Edge(new point(1, 1), new point(0, 0));
         Edge e2 = new Edge(new point(0, 1), new point(1, 0));
         Assert.IsTrue(e1.Intersects(e2) && e2.Intersects(e1));
      }

      /*
       * Tests the functionality of the intersection algorithm
       */
      [TestMethod]
      public void IntersectionTest_4()
      {
         Edge e1 = new Edge(new point(0, 0), new point(1, 1));
         Edge e2 = new Edge(new point(0, 1), new point(1, 0));
         Assert.IsFalse(e1.Intersects(e2, 1, 1));
      }

      /*
       * Tests the functionality of the intersection with dx dy overload algorithm 
       * Parody: e1 is backwards
       */
      [TestMethod]
      public void IntersectionTest_5()
      {
         Edge e1 = new Edge(new point(1, 1), new point(0, 0));
         Edge e2 = new Edge(new point(0, 2), new point(2, 0));
         Assert.IsTrue(e1.Intersects(e2, 1, 1));
      }

      /**
       * Tests whether the intersection algorithm is communitive
       */
      [TestMethod]
      public void IntersectionTest_6()
      {
         Edge e1 = new Edge(new point(1, 1), new point(0, 0));
         Edge e2 = new Edge(new point(0, 1), new point(1, 0));
         Assert.IsTrue(e1.Intersects(e2) && e2.Intersects(e1));
      }

      #endregion
      #region LengthTests
      [TestMethod]
      public void calculateLengthTest_1()
      {
         Edge e1 = new Edge(new point(0, 0), new point(0, 1));
         Assert.AreEqual(e1.calculateLength(), 1);
      }

      [TestMethod]
      public void calculateLengthTest_2()
      {
         Edge e1 = new Edge(new point(0, 1), new point(0, 0));
         Assert.AreEqual(e1.calculateLength(), 1);
      }

      [TestMethod]
      public void calculateLengthTest_3()
      {
         Edge e1 = new Edge(new point(0, 0), new point(1, 1));
         Assert.AreEqual(e1.calculateLength(), Math.Sqrt(2));
      }
      #endregion
   }
}
