using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.graphics;

namespace phi.phisics
{
   public class PhisicsPlane : Drawable
   {

      private HashSet<PhisicsObject> objs;

      /**
       * Constructs a rectangularly bounded phisics plane
       */
      public PhisicsPlane(int originX, int originY, int width, int height) : base(originX, originY, width, height)
      {

      }

      protected override void DrawAt(Graphics g, int x, int y)
      {
         foreach (PhisicsObject obj in objs)
         {
            obj.DrawOffset(g, x, y);
         }
      }
   }
}
