using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using phi.phisics;

namespace PhiTests
{
   [TestClass]
   public class TestVector
   {
      private const double EPSILON = 0.00000001;
      
      // Zero vector

      [TestMethod]
      public void ZeroVector_Magnitude0()
      {
         Assert.Equals(0, Vector.ZERO.getMagnitude());
      }

      [TestMethod]
      public void ZeroVector_DirectionUndefined()
      {
         Assert.IsFalse(Vector.ZERO.getDirection().IsDefined());
      }
      
      [TestMethod]
      public void ZeroVector_XComp0()
      {
         Assert.Equals(0, Vector.ZERO.getXComp());
      }

      [TestMethod]
      public void ZeroVector_YComp0()
      {
         Assert.Equals(0, Vector.ZERO.getYComp());
      }

      [TestMethod]
      public void ZeroVector_AdditionIdentity()
      {
         Vector v1 = new Vector(1, 1);

         Vector result = Vector.ZERO + v1;

         Assert.IsTrue(v1.Equals(result));
      }

      [TestMethod]
      public void ZeroVector_SubtractionIdentity()
      {
         Vector v1 = new Vector(1, 1);

         Vector result = v1 - Vector.ZERO;

         Assert.IsTrue(v1.Equals(result));
      }

   }
}
