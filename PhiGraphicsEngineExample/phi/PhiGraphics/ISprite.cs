using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi
{
   public interface ISprite
   {
      Image getImage();
      void setImage(Image image);

      void setX(int x);
      void setY(int y);
      void setXY(int x, int y);
      int getX();
      int getY();

      void FlipX();
      void FlipY();
      ISprite RotateLeft();
      ISprite RotateRight();

      void setRenderer(Renderer renderer);
   }
}
