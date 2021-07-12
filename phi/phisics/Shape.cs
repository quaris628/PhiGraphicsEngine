using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi.phisics
{
   public abstract class Shape
   {
      private double originX;
      private double originY;

      public abstract int GetHeight();
      public abstract int GetWidth();
   }
}
