using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi.graphics
{
   public class Text : Drawable
   {
      private const string DEFAULT_FONT_NAME = "Arial";
      private const float DEFAULT_FONT_SIZE = 14;
      private static readonly Brush DEFAULT_COLOR = Brushes.Black;

      private string message;
      private Font font;
      private Brush color;
      private Size calculatedSize;
      private bool sizeUpToDate;

      private Text(TextBuilder builder) : base(builder.GetX(), builder.GetY())
      {
         this.message = builder.GetMessage();
         this.font = builder.GetFont();
         this.color = builder.GetColor();
         this.sizeUpToDate = false;
      }
      protected override void DrawAt(Graphics g, int x, int y)
      {
         g.DrawString(message, GetFont(), color, new PointF(x, y));
      }

      public void setMessage(string message) { this.message = message; sizeUpToDate = false; FlagChange(); }
      public string getMessage() { return message; }
      public Font GetFont() { return font; }

      public override int GetHeight() { return GetSize().Height; }
      public override int GetWidth() { return GetSize().Width; }
      private Size GetSize()
      {
         if (!sizeUpToDate)
         {
            // calculation may be intensive -- implement a cache for better performance
            calculatedSize = System.Windows.Forms.TextRenderer.MeasureText(message, font);
         }
         return calculatedSize;
      }

      public class TextBuilder
      {
         private string message;
         private string fontName;
         private float fontSize;
         private Brush color;
         private int x;
         private int y;

         public TextBuilder(string message)
         {
            this.message = message;
            this.x = 0;
            this.y = 0;
            this.fontName = DEFAULT_FONT_NAME;
            this.fontSize = DEFAULT_FONT_SIZE;
            this.color = DEFAULT_COLOR;
         }

         public TextBuilder WithX(int x) { this.x = x; return this; }
         public TextBuilder WithY(int y) { this.y = y; return this; }
         public TextBuilder WithXY(int x, int y) { this.x = x; this.y = y; return this; }
         public TextBuilder WithFontName(string fontName) { this.fontName = fontName; return this; }
         public TextBuilder WithFontSize(float fontSize) { this.fontSize = fontSize; return this; }
         public TextBuilder WithColor(Brush color) { this.color = color; return this; }

         public string GetMessage() { return message; }
         public int GetX() { return x; }
         public int GetY() { return y; }
         public Font GetFont() { return new Font(fontName, (float)fontSize); }
         public Brush GetColor() { return color; }

         public Text Build() { return new Text(this); }
      }

   }
}
