using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi.phisics
{
   public class Angle
   {
      private const double DEGREES_TO_RADIANS = Math.PI / 180;
      private const double RADIANS_TO_DEGREES = 180 / Math.PI;
      private const double TAU = Math.PI * 2;

      private double radians;

      public static Angle CreateRadians(double radians) { return new Angle(radians); }
      public static Angle CreateDegrees(double degrees) { return new Angle(degrees * DEGREES_TO_RADIANS); }
      public static Angle CreateSlope(double rise, double run) { return new Angle(Math.Atan2(rise, run)); }

      private Angle(double radians)
      {
         this.radians = radians % TAU;
         // C# modulo is truncated definition; we want the floored definition, so this fixes that
         if (radians < 0)
         {
            this.radians += TAU;
         }
      }

      public bool IsDefined()
      {
         return ! (Double.IsNaN(radians) || Double.IsInfinity(radians));
      }

      /**
       * Returns the right angle to the angle
       */
      public Angle getNormal()
      {
         return new Angle(radians + Math.PI / 2);
      }

      /**
       * Returns the right angle to the angle
       */
      public Angle getAntiNormal()
      {
         return new Angle(radians - Math.PI / 2);
      }

      /**
       * Should output a value between 0 and tau
       */
      public double GetRadians() { return radians; }
      public double GetDegrees() { return radians * RADIANS_TO_DEGREES; }
      public double GetSlope() { return Math.Tan(radians); }

   }

   public class AngleNotDefinedException : Exception
   {
      AngleNotDefinedException() : base() { }
      AngleNotDefinedException(string message) : base(message) { }
   }
}
