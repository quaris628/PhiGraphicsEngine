using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using phi.phisics.PhiMath;

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
         Assert.AreEqual(0.0, Vector.ZERO.getMagnitude(), EPSILON);
      }

      [TestMethod]
      public void ZeroVector_DirectionUndefined()
      {
         Assert.IsFalse(Vector.ZERO.getDirection().IsDefined());
      }
      
      [TestMethod]
      public void ZeroVector_XComp0()
      {
         Assert.AreEqual(0.0, Vector.ZERO.getXComp(), EPSILON);
      }

      [TestMethod]
      public void ZeroVector_YComp0()
      {
         Assert.AreEqual(0.0, Vector.ZERO.getYComp(), EPSILON);
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

      // Construct Magnitude Direction -> x/y comp correct
      
      [TestMethod]
      public void ConstructMagDir_Mag2Dir0_X2Y0()
      {
         Vector v = new Vector(2, Angle.CreateRadians(0));
         
         Assert.AreEqual(2.0, v.getXComp(), EPSILON);
         Assert.AreEqual(0.0, v.getYComp(), EPSILON);
      }

      [TestMethod]
      public void ConstructMagDir_Mag1Dir60Deg_XhalfYsqrt3over2()
      {
         Vector v = new Vector(1, Angle.CreateDegrees(60));
         
         Assert.AreEqual(0.5, v.getXComp(), EPSILON);
         Assert.AreEqual(Math.Sqrt(3) * 0.5, v.getYComp(), EPSILON);
      }

      [TestMethod]
      public void ConstructMagDir_MagNegSqrt2Dir225Deg_X1Y1()
      {
         Vector v = new Vector(-Math.Sqrt(2), Angle.CreateDegrees(225));
         
         Assert.AreEqual(1.0, v.getXComp(), EPSILON);
         Assert.AreEqual(1.0, v.getYComp(), EPSILON);
      }

      // Construct X Y complements -> Direction, Mag correct

      [TestMethod]
      public void ConstructXY_X2Y3_DirCorrect()
      {
         Vector v = new Vector(2.0, 3.0);

         Assert.AreEqual(1.5, v.getDirection().GetSlope(), EPSILON);
      }

      [TestMethod]
      public void ConstructXY_X3Y4_MagCorrect()
      {
         Vector v = new Vector(3.0, 4.0);

         Assert.AreEqual(5.0, v.getMagnitude(), EPSILON);
      }

      // Set Magnitude -> Direction unaffected, x/y comp correct

      [TestMethod]
      public void SetMag_Mag4Dir30_Set2_DirUnchanged()
      {
         Vector v = new Vector(4, Angle.CreateDegrees(30));

         v.setMagnitude(2);

         Assert.AreEqual(30, v.getDirection().GetDegrees(), EPSILON);
      }

      [TestMethod]
      public void SetMag_Mag4Dir30_Set2_XYCompCorrect()
      {
         Vector v = new Vector(4, Angle.CreateDegrees(30));

         v.setMagnitude(2);

         Assert.AreEqual(Math.Sqrt(3), v.getXComp(), EPSILON);
         Assert.AreEqual(1.0, v.getYComp(), EPSILON);
      }

      // Set Direction -> Magnitude unaffected, x/y comp correct

      [TestMethod]
      public void SetDir_Mag4Dir30_SetNeg30_MagUnchanged()
      {
         Vector v = new Vector(4, Angle.CreateDegrees(30));

         v.setDirection(Angle.CreateDegrees(-30));

         Assert.AreEqual(4.0, v.getMagnitude(), EPSILON);
      }

      [TestMethod]
      public void SetDir_Mag4Dir30_SetNeg30_XYCompCorrect()
      {
         Vector v = new Vector(4, Angle.CreateDegrees(30));

         v.setDirection(Angle.CreateDegrees(-30));

         Assert.AreEqual(2 * Math.Sqrt(3), v.getXComp(), EPSILON);
         Assert.AreEqual(-2.0, v.getYComp(), EPSILON);
      }

      // Set X Y Complements -> Direction, Magnitude correct

      [TestMethod]
      public void SetX_X2Y3_SetX3_DirCorrect()
      {
         Vector v = new Vector(2.0, 3.0);

         v.setXComp(3.0);

         Assert.AreEqual(45, v.getDirection().GetDegrees(), EPSILON);
      }

      [TestMethod]
      public void SetX_X2Y3_SetX3_MagCorrect()
      {
         Vector v = new Vector(2.0, 3.0);

         v.setXComp(3.0);

         Assert.AreEqual(3 * Math.Sqrt(2), v.getMagnitude(), EPSILON);
      }

      [TestMethod]
      public void SetY_X2Y3_SetY4_DirCorrect()
      {
         Vector v = new Vector(2.0, 3.0);

         v.setYComp(4.0);

         Assert.AreEqual(2.0, v.getDirection().GetSlope(), EPSILON);
      }

      [TestMethod]
      public void SetY_X2Y3_SetY4_MagCorrect()
      {
         Vector v = new Vector(2.0, 3.0);

         v.setYComp(4.0);

         Assert.AreEqual(2 * Math.Sqrt(5), v.getMagnitude(), EPSILON);
      }

      [TestMethod]
      public void SetXY_X2Y3_SetXNeg1YNeg1_DirCorrect()
      {
         Vector v = new Vector(2.0, 3.0);

         v.setXYComp(-1.0, -1.0);

         Assert.AreEqual(225.0, v.getDirection().GetDegrees(), EPSILON);
      }

      [TestMethod]
      public void SetXY_X2Y3_SetXNeg1YNeg1_MagCorrect()
      {
         Vector v = new Vector(2.0, 3.0);

         v.setXYComp(-1.0, -1.0);

         Assert.AreEqual(Math.Sqrt(2), v.getMagnitude(), EPSILON);
      }

      // overload u + v

      // overload u - v

      // overload - v

      // Equals

      // GetHashCode
   }
}
