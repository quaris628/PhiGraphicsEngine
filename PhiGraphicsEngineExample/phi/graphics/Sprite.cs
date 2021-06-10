﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi.graphics
{
   public class Sprite : Drawable
   {
      private Image image;

      public Sprite(Image img)
      {
         this.image = img ?? throw new ArgumentNullException();
      }

      public Sprite(Image img, int x, int y) : base(x, y)
      {
         this.image = img ?? throw new ArgumentNullException();
      }

      protected override void DrawAt(Graphics g, int x, int y)
      {
         g.DrawImage(image, x, y);
      }

      public override int GetHeight() { return image.Height; }
      public override int GetWidth() { return image.Width; }

      public Sprite FlipX()
      {
         image.RotateFlip(RotateFlipType.Rotate180FlipNone);
         FlagChange();
         return this;
      }

      public Sprite FlipY()
      {
         image.RotateFlip(RotateFlipType.RotateNoneFlipY);
         FlagChange();
         return this;
      }

      public Sprite RotateLeft()
      {
         image.RotateFlip(RotateFlipType.Rotate270FlipNone);
         FlagChange();
         return this;
      }

      public Sprite RotateRight()
      {
         image.RotateFlip(RotateFlipType.Rotate90FlipNone);
         FlagChange();
         return this;
      }

      public Image GetImage() { return image; }
      public void SetImage(Image image) { this.image = image; FlagChange(); }

      public override int GetHashCode()
      {
         unchecked // allow arithmetic overflow
         {
            int result = 1046527;
            result *= 106033 ^ base.GetHashCode();
            result *= 106033 ^ image.GetHashCode();
            return result;
         }
      }

   }
}
