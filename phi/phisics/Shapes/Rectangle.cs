using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi.phisics.Shapes
{
   public class Rectangle : Shape
   {
      private int height;
      private int width;
      
      public Rectangle(double originX, double originY, int width, int height)
      {
         this.originX = originX;
         this.originY = originY;
         this.width = width;
         this.height = height;
         this.type = ShapeTypes.RECTANGLE;
      }

      public override int GetHeight()
      {
         return height;
      }

      public override int GetWidth()
      {
         return width;
      }
      
      public override bool willCollide(Shape s, double dx, double dy)
      {
         if(s.getShapeType() == ShapeTypes.RECTANGLE)
         {
            
         }
         return false;
      }

      public override bool isColliding(Shape s)
      {
         if(s.getShapeType() == ShapeTypes.RECTANGLE)
         return (this.originX + this.width > s.getX() && this.originX + this.width < s.getX() + s.GetWidth())
               && (this.originY + this.height > s.getY() && this.originY + this.height < s.getY() + s.GetHeight())
               || s.isColliding(this);
         return false;
      }
   }
}
