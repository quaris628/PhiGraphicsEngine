using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi
{
   public class Sprite : ISprite
   {
      Image myImage;
      int x;
      int y;
      public Sprite(Image img, int x, int y)
      {
         if (img == null) { throw new ArgumentNullException(); }
         this.myImage = img;
         this.x = x;
         this.y = y;
      }
      public Sprite(Image img)
      {
         if (img == null) { throw new ArgumentNullException(); }
         this.myImage = img;
         x = 0;
         y = 0;
      }

      public Image getImage() { return myImage; }

      public void setImage(Image image) { myImage = image; flagChange(); }

      public void setX(int x) { this.x = x; flagChange(); }
      public void setY(int y) { this.y = y; flagChange(); }
      public void setXY(int x, int y) { setX(x); setY(y); }
      public int getX() { return x; }
      public int getY() { return y; }

      public void FlipX()
      {
         myImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
         flagChange();
      }

      public void FlipY()
      {
         myImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
         flagChange();
      }


      public ISprite RotateLeft()
      {
         myImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
         flagChange();
         return this;
      }

      public ISprite RotateRight()
      {
         myImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
         flagChange();
         return this;
      }

      public override int GetHashCode()
      {
         unchecked // allow arithmetic overflow
         {
            int result = 1046527;
            result *= 106033 ^ x;
            result *= 106033 ^ y;
            result *= 106033 ^ myImage.GetHashCode();
            return result;
         }
      }

      // each time this sprite has a visible change made, indicate this Renderer also has a visible change made
      private void flagChange() { Renderer.obj.HasChanged(); }

   }
}
