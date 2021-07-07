using phi.control;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi.graphics
{
   public class Button : Sprite
   {
      private Text text;
      private Action onClick;

      private Button(ButtonBuilder b) : base(b.GetImage(), b.GetX(), b.GetY())
      {
         this.text = b.GetText();
         this.onClick = b.GetOnClick();
      }

      public void Initialize()
      {
         IO.MOUSE.CLICK.SubscribeOnDrawable(onClick, this);
      }

      protected override void DrawAt(Graphics g, int x, int y)
      {
         base.DrawAt(g, x, y);
         if (text != null)
         {
            CenterText();
            text.Draw(g);
         }
      }

      // set the position of the button's message, centered vertically and horizontally on the button's sprite
      private void CenterText()
      {
         text.SetX(GetCenterX() - text.GetWidth() / 2);
         text.SetY(GetCenterY() - text.GetHeight() / 2);
      }

      public class ButtonBuilder
      {
         private Image image;
         private int x, y;
         private Text text;
         private Action onClick;

         public ButtonBuilder(Sprite sprite)
         {
            image = sprite.GetImage();
            x = sprite.GetX();
            y = sprite.GetY();
         }

         public ButtonBuilder(Image image, int x, int y)
         {
            this.image = image;
            this.x = x;
            this.y = y;
         }

         public ButtonBuilder withText(Text text) { this.text = text; return this; }
         public ButtonBuilder withText(string text) { this.text = new Text.TextBuilder(text).Build(); return this; }
         public ButtonBuilder withOnClick(Action onClick) { this.onClick = onClick; return this; }
         public Image GetImage() { return image; }
         public int GetX() { return x; }
         public int GetY() { return y; }
         public Text GetText() { return text; }
         public Action GetOnClick() { return onClick; }
         public Button Build() { return new Button(this); }
      }

   }
}
