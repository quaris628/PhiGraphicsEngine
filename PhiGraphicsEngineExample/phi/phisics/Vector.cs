using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi.phisics
{
   public class Vector
   {
      // the Zero Vector
      public static readonly Vector ZERO = new Vector(0, 0);

      private double magnitude;
      private Angle direction;

      private double xComp;
      private double yComp;

      public Vector(double magnitude, Angle direction)
      {
         this.magnitude = magnitude;
         this.direction = direction;
         yComp = Math.Sin(direction.GetRadians()) * magnitude;
         xComp = Math.Cos(direction.GetRadians()) * magnitude;
      }

      public Vector(double xComp, double yComp)
      {
         this.xComp = xComp;
         this.yComp = yComp;
         magnitude = Math.Sqrt(xComp * xComp + yComp * yComp);
         direction = Angle.CreateSlope(yComp, xComp);
      }

      public void setMagnitude(float magnitude)
      {
         this.magnitude = magnitude;
         xComp = Math.Cos(direction.GetRadians()) * magnitude;
         yComp = Math.Sin(direction.GetRadians()) * magnitude;
      }

      public void setDirection(Angle direction)
      {
         this.direction = direction;
         xComp = Math.Cos(this.direction.GetRadians()) * magnitude;
         yComp = Math.Sin(this.direction.GetRadians()) * magnitude;
      }

      public void setXComp(double xComp)
      {
         this.xComp = xComp;
         magnitude = Math.Sqrt(xComp * xComp + yComp * yComp);
         direction = Angle.CreateSlope(yComp, xComp);
      }

      public Angle getDirection() { return direction; }
      public double getMagnitude() { return magnitude; }
      public double getXComp() { return xComp; }
      public double getYComp() { return yComp; }

      public Angle getNormal()
      {
         if(angletype == AngleTypes.RADIANS)
         {
            return (direction + (float)Math.PI / 2) % (float)(2 * Math.PI) ;
         }
         else
         {
            return (direction + 180) % 360;
         }
         
      }

      public Angle getAntiNormal()
      {
         if (angletype == AngleTypes.RADIANS)
         {
            return direction - (float)Math.PI / 2;
         }
         else
         {
            return direction + 180;
         }
      }

      public static Vector operator +(Vector a) => a;

      public static Vector operator -(Vector a) => new Vector(a.angletype, -a.magnitude, a.direction);

      public static Vector operator +(Vector a, Vector b)
         => new Vector(a.angletype, a.xComp + b.xComp, a.yComp + b.yComp);

      public static Vector operator -(Vector a, Vector b)
         => a + -(b);

      public override bool Equals(object obj)
      {
         
      }
   }
}
