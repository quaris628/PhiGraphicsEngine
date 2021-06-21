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
         this.magnitude = Math.Sqrt(xComp * xComp + yComp * yComp);
         this.direction = Angle.CreateSlope(yComp, xComp);
      }

      public void setMagnitude(float Magnitude)
      {
         this.magnitude = Magnitude;
         if (angletype == AngleTypes.RADIANS)
         {
            yComp = Math.Sin((double)direction) * Magnitude;
            xComp = Math.Cos((double)direction) * Magnitude;
         }
         else
         {
            yComp = Math.Sin((double)direction * Math.PI / 180) * Magnitude;
            xComp = Math.Cos((double)direction * Math.PI / 180) * Magnitude;
         }
      }

      public void setDirection(float Direction)
      {
         this.direction = Direction;
         if (angletype == AngleTypes.RADIANS)
         {
            yComp = Math.Sin((double)Direction) * magnitude;
            xComp = Math.Cos((double)Direction) * magnitude;
         }
         else
         {
            yComp = Math.Sin((double)Direction * Math.PI / 180) * magnitude;
            xComp = Math.Cos((double)Direction * Math.PI / 180) * magnitude;
         }
      }

      public double getXComp()
      {
         return xComp;
      }

      public double getYComp()
      {
         return yComp;
      }

      public float getDirection()
      {
         return direction;
      }

      public float getNormal()
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

      public float getAntiNormal()
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

      public double getMagnitude()
      {
         return magnitude;
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
