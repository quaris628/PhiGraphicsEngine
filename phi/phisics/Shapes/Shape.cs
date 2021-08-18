using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi.phisics.Shapes
{
   public enum ShapeTypes
   {
      RECTANGLE,
      CIRCLE,
      TRIANGLE
   }
   public abstract class Shape
   {
      protected double originX;
      protected double originY;
      protected ShapeTypes type;
      public abstract int GetHeight();
      public abstract int GetWidth();
      public void updatePosition(double originX, double originY)
      {
         this.originX = originX;
         this.originY = originY;
      }
      public ShapeTypes getShapeType()
      {
         return type;
      }
      public double getX()
      {
         return originX;
      }
      public double getY()
      {
         return originY;
      }
      public abstract bool willCollide(Shape s, double dx, double dy);
      public abstract bool isColliding(Shape s);
   }
}
