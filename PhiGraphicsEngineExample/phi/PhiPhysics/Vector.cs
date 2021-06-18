using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhiGraphicsEngineExample.phi.PhiPhysics
{
   class Vector
   {
      AngleTypes angletype;
      private double Magnitude;
      private float Direction;

      private double xComp;
      private double yComp;

      public Vector()
      {
         this.angletype = AngleTypes.RADIANS;
         this.Magnitude = 0;
         this.Direction = 0;
         this.xComp = 0;
         this.yComp = 0;
      }

      public Vector(AngleTypes angletype)
      {
         this.angletype = angletype;
         this.Magnitude = 0;
         this.Direction = 0;
         this.xComp = 0;
         this.yComp = 0;
      }
      public Vector(AngleTypes angletype, double Magnitude, float Direction)
      {
         this.angletype = angletype;
         this.Magnitude = Magnitude;
         this.Direction = Direction;
         if(angletype == AngleTypes.RADIANS)
         {
            yComp = Math.Sin((double)Direction) * Magnitude;
            xComp = Math.Cos((double)Direction) * Magnitude;
         }
         else
         {
            yComp = Math.Sin((double)Direction * Math.PI / 180) * Magnitude;
            xComp = Math.Cos((double)Direction * Math.PI / 180) * Magnitude;
         }
         
      }

      public Vector(AngleTypes a, double xComp, double yComp)
      {
         this.xComp = xComp;
         this.yComp = yComp;
         this.Magnitude = Math.Pow(xComp, 2);
         this.Direction = (float)Math.Atan(yComp / xComp);
         Console.WriteLine("Arc tan calculation: " + this.Direction);
         if(angletype == AngleTypes.DEGREES)
         {
            Direction = Direction * 180 / (float)Math.PI;
         }
      }

      public void setMagnitude(float Magnitude)
      {
         this.Magnitude = Magnitude;
         if (angletype == AngleTypes.RADIANS)
         {
            yComp = Math.Sin((double)Direction) * Magnitude;
            xComp = Math.Cos((double)Direction) * Magnitude;
         }
         else
         {
            yComp = Math.Sin((double)Direction * Math.PI / 180) * Magnitude;
            xComp = Math.Cos((double)Direction * Math.PI / 180) * Magnitude;
         }
      }

      public void setDirection(float Direction)
      {
         this.Direction = Direction;
         if (angletype == AngleTypes.RADIANS)
         {
            yComp = Math.Sin((double)Direction) * Magnitude;
            xComp = Math.Cos((double)Direction) * Magnitude;
         }
         else
         {
            yComp = Math.Sin((double)Direction * Math.PI / 180) * Magnitude;
            xComp = Math.Cos((double)Direction * Math.PI / 180) * Magnitude;
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
         return Direction;
      }

      public float getNormal()
      {
         if(angletype == AngleTypes.RADIANS)
         {
            return (Direction + (float)Math.PI / 2) % (float)(2 * Math.PI) ;
         }
         else
         {
            return (Direction + 180) % 360;
         }
         
      }

      public float getAntiNormal()
      {
         if (angletype == AngleTypes.RADIANS)
         {
            return Direction - (float)Math.PI / 2;
         }
         else
         {
            return Direction + 180;
         }
      }

      public double getMagnitude()
      {
         return Magnitude;
      }

      public static Vector operator +(Vector a) => a;

      public static Vector operator -(Vector a) => new Vector(a.angletype, -a.Magnitude, a.Direction);

      public static Vector operator +(Vector a, Vector b)
         => new Vector(a.angletype, a.xComp + b.xComp, a.yComp + b.yComp);

      public static Vector operator -(Vector a, Vector b)
         => a + -(b);
   }
}
