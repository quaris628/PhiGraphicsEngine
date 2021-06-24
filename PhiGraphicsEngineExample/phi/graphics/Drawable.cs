using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi.graphics
{
   public abstract class Drawable : Movable2D
   {
      private bool displaying;
      protected int height;
      protected int width;

      public Drawable(int x, int y, int width, int height) : base(x, y)
      {
         displaying = true;
         this.height = height;
         this.width = width;
      }

      public void Draw(Graphics g) { DrawAt(g, this.GetX(), this.GetY()); }
      public void DrawOffset(Graphics g, int xOffset, int yOffset) { DrawAt(g, this.GetX() + xOffset, this.GetY() + yOffset); }
      protected abstract void DrawAt(Graphics g, int x, int y);

      public virtual int GetHeight() { return height; }
      public virtual int GetWidth() { return width; }

      protected void SetDisplaying(bool displaying) { this.displaying = displaying; FlagChange(); }
      public bool IsDisplaying() { return displaying; }

      public override int GetHashCode()
      {
         unchecked // allow arithmetic overflow
         {
            int result = 1046527;
            result *= 106033 ^ base.GetHashCode();
            result *= 106033 ^ (displaying ? 1 : 0);
            return result;
         }
      }

      public override bool Equals(object obj)
      {
         if (!base.Equals(obj)) { return false; }
         if (this.GetType() != obj.GetType()) { return false; }
         return this.displaying == ((Drawable)obj).displaying;
      }

      public override string ToString()
      {
         return (displaying ? "Showing" : "Hiding") + " at " + base.ToString();
      }
   }
}
