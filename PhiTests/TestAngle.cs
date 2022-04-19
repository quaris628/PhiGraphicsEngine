using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using phi.phisics;
using phi.phisics.PhiMath;

namespace PhiTests
{
   [TestClass]
   public class TestAngle
   {
      private const double EPSILON = 0.00000001;

      // CreateRadians
      [TestMethod]
      public void CreateRadians_0_GetRadians0()
      {
         Angle a = Angle.CreateRadians(0);

         Assert.AreEqual(0, a.GetRadians(), EPSILON);
      }

      [TestMethod]
      public void CreateRadians_3_GetRadians3()
      {
         Angle a = Angle.CreateRadians(3);

         Assert.AreEqual(3, a.GetRadians(), EPSILON);
      }

      // CreateDegrees

      [TestMethod]
      public void CreateDegrees_0_GetDegrees0()
      {
         Angle a = Angle.CreateDegrees(0);

         Assert.AreEqual(0, a.GetDegrees(), EPSILON);
      }

      [TestMethod]
      public void CreateDegrees_120_GetDegrees120()
      {
         Angle a = Angle.CreateDegrees(120);

         Assert.AreEqual(120, a.GetDegrees(), EPSILON);
      }

      // CreateSlope

      [TestMethod]
      public void CreateSlope_0_1_GetSlope0()
      {
         Angle a = Angle.CreateSlope(0, 1);

         Assert.AreEqual(0, a.GetSlope(), EPSILON);
      }

      [TestMethod]
      public void CreateSlope_4_2_GetSlope2()
      {
         Angle a = Angle.CreateSlope(4, 2);

         Assert.AreEqual(2, a.GetSlope(), EPSILON);
      }

      // Conversions

      // Radians to Degrees

      [TestMethod]
      public void Convert_RadiansToDegrees_0_0()
      {
         Angle a = Angle.CreateRadians(0);

         Assert.AreEqual(0, a.GetDegrees(), EPSILON);
      }

      [TestMethod]
      public void Convert_RadiansToDegrees_Pi_180()
      {
         Angle a = Angle.CreateRadians(Math.PI);

         Assert.AreEqual(180, a.GetDegrees(), EPSILON);
      }

      // Radians to Slope

      [TestMethod]
      public void Convert_RadiansToSlope_0_0()
      {
         Angle a = Angle.CreateRadians(0);

         Assert.AreEqual(0, a.GetSlope(), EPSILON);
      }

      [TestMethod]
      public void Convert_RadiansToSlope_PiOver4_1()
      {
         Angle a = Angle.CreateRadians(Math.PI / 4);

         Assert.AreEqual(1, a.GetSlope(), EPSILON);
      }

      // Degrees to Radians

      [TestMethod]
      public void Convert_DegreesToRadians_0_0()
      {
         Angle a = Angle.CreateDegrees(0);

         Assert.AreEqual(0, a.GetRadians(), EPSILON);
      }

      [TestMethod]
      public void Convert_DegreesToRadians_180_Pi()
      {
         Angle a = Angle.CreateDegrees(180);

         Assert.AreEqual(Math.PI, a.GetRadians(), EPSILON);
      }

      // Degrees to Slope

      [TestMethod]
      public void Convert_DegreesToSlope_0_0()
      {
         Angle a = Angle.CreateDegrees(0);

         Assert.AreEqual(0, a.GetSlope(), EPSILON);
      }

      [TestMethod]
      public void Convert_DegreesToSlope_135_Neg1()
      {
         Angle a = Angle.CreateDegrees(135);

         Assert.AreEqual(-1, a.GetSlope(), EPSILON);
      }

      // Slope to Radians

      [TestMethod]
      public void Convert_SlopeToRadians_0Over1_0()
      {
         Angle a = Angle.CreateSlope(0, 1);

         Assert.AreEqual(0, a.GetRadians(), EPSILON);
      }

      [TestMethod]
      public void Convert_SlopeToRadians_1Over1_PiOver4()
      {
         Angle a = Angle.CreateSlope(1, 1);

         Assert.AreEqual(Math.PI / 4, a.GetRadians(), EPSILON);
      }

      // Slope to Degrees


      [TestMethod]
      public void Convert_SlopeToDegrees_0Over1_0()
      {
         Angle a = Angle.CreateSlope(0, 1);

         Assert.AreEqual(0, a.GetDegrees(), EPSILON);
      }

      [TestMethod]
      public void Convert_SlopeToDegrees_1OverNeg1_315()
      {
         Angle a = Angle.CreateSlope(-1, 1);

         Assert.AreEqual(315, a.GetDegrees(), EPSILON);
      }

      // 0 to tau output boundary

      [TestMethod]
      public void OutputBoundary_3Pi_GetRadians1Pi()
      {
         Angle a = Angle.CreateRadians(3 * Math.PI);

         Assert.AreEqual(Math.PI, a.GetRadians(), EPSILON);
      }

      [TestMethod]
      public void OutputBoundary_Neg1Pi_GetRadians1Pi()
      {
         Angle a = Angle.CreateRadians(-Math.PI);

         Assert.AreEqual(Math.PI, a.GetRadians(), EPSILON);
      }

      [TestMethod]
      public void OutputBoundary_Neg3Pi_GetRadians1Pi()
      {
         Angle a = Angle.CreateRadians(-3 * Math.PI);

         Assert.AreEqual(Math.PI, a.GetRadians(), EPSILON);
      }

      // Slope equivalence classes

      [TestMethod]
      public void Slope_1Over1_1()
      {
         Angle a = Angle.CreateSlope(1, 1);

         Assert.AreEqual(1, a.GetSlope(), EPSILON);
      }

      [TestMethod]
      public void Slope_1OverNeg1_Neg1()
      {
         Angle a = Angle.CreateSlope(1, -1);

         Assert.AreEqual(-1, a.GetSlope(), EPSILON);
      }

      [TestMethod]
      public void Slope_Neg1OverNeg1_1()
      {
         Angle a = Angle.CreateSlope(-1, -1);

         Assert.AreEqual(1, a.GetSlope(), EPSILON);
      }

      [TestMethod]
      public void Slope_Neg1Over1_Neg1()
      {
         Angle a = Angle.CreateSlope(-1, 1);

         Assert.AreEqual(-1, a.GetSlope(), EPSILON);
      }

      // isDefined

      [TestMethod]
      public void IsDefined_0_True()
      {
         Angle a = Angle.CreateRadians(0);
         Assert.IsTrue(a.IsDefined());
      }

      [TestMethod]
      public void IsDefined_NaN_False()
      {
         Angle a = Angle.CreateRadians(Double.NaN);
         Assert.IsFalse(a.IsDefined());
      }

      [TestMethod]
      public void IsDefined_Slope1Over0_True()
      {
         Angle a = Angle.CreateSlope(1, 0);
         Assert.IsFalse(a.IsDefined());
      }
   }
}
