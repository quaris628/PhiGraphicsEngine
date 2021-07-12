﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.io;

namespace phi.graphics
{
   public class Button : Drawable
   {
      private Sprite sprite;
      private Text text;
      private Action onClick;

      private Button(ButtonBuilder b) : base(b.GetSprite().GetX(), b.GetSprite().GetY(), b.GetSprite().GetWidth(), b.GetSprite().GetHeight())
      {
         this.sprite = b.GetSprite();
         this.text = b.GetText();
         this.onClick = b.GetOnClick();
      }

      public void Initialize()
      {
         IO.MOUSE.CLICK.SubscribeOnDrawable(onClick, this);
      }

      protected override void DrawAt(Graphics g, int x, int y)
      {
         sprite.SetCenterXY(GetCenterX(), GetCenterY());
         sprite.Draw(g);
         if (text != null)
         {
            text.SetCenterXY(GetCenterX(), GetCenterY());
            text.Draw(g);
         }
      }

      public class ButtonBuilder
      {
         private Sprite sprite;
         private Text text;
         private Action onClick;

         public ButtonBuilder(Sprite sprite) { this.sprite = sprite; }
         public ButtonBuilder(ImageWrapper image, int x, int y) { this.sprite = new Sprite(image, x, y); }

         public ButtonBuilder withText(Text text) { this.text = text; return this; }
         public ButtonBuilder withText(string text) { this.text = new Text.TextBuilder(text).Build(); return this; }
         public ButtonBuilder withOnClick(Action onClick) { this.onClick = onClick; return this; }

         public Sprite GetSprite() { return sprite; }
         public Text GetText() { return text; }
         public Action GetOnClick() { return onClick; }

         public Button Build() { return new Button(this); }
      }

   }
}
