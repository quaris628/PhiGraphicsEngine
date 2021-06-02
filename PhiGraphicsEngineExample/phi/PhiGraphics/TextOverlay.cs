using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi
{
   public class TextOverlay
   {
      private const string DEFAULT_TEXT_FONT = "Arial";
      private const float DEFAULT_TEXT_SIZE = 14;
      private string message;
      private string textFont;
      private float textSize;
      private int x;
      private int y;

      public TextOverlay(string message)
      {
         this.message = message;
         this.textFont = DEFAULT_TEXT_FONT;
         this.textSize = DEFAULT_TEXT_SIZE;
         this.x = 0;
         this.y = 0;
      }
      public TextOverlay(string message, int x, int y)
      {
         this.message = message;
         this.textFont = DEFAULT_TEXT_FONT;
         this.textSize = DEFAULT_TEXT_SIZE;
         this.x = x;
         this.y = y;
      }
      public TextOverlay(string message, string textFont, float textSize)
      {
         this.message = message;
         this.textFont = textFont;
         this.textSize = textSize;
         this.x = 0;
         this.y = 0;
      }
      public TextOverlay(string message, string textFont, float textSize, int x, int y)
      {
         this.message = message;
         this.textFont = textFont;
         this.textSize = textSize;
         this.x = x;
         this.y = y;
      }

      public void setMessage(string message) { this.message = message; flagChange(); }
      public string getMessage() { return message; }
      public Font getFont() { return new Font(textFont, (float)textSize); }
      public void setX(int x) { this.x = x; flagChange(); }
      public void setY(int y) { this.y = y; flagChange(); }
      public void setXY(int x, int y) { setX(x); setY(y); }
      public int getX() { return x; }
      public int getY() { return y; }

      // each time this text has a visible change made, indicate this Renderer
      //    also has a visible change made
      private void flagChange() { Renderer.obj.HasChanged(); }
   }
}
