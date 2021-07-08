using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.graphics;
using phi.control;
using phi.control.input;
using phi;

namespace PhiGraphicsEngineExample
{
   class Scene1 : Scene
   {
      private const string TITLE = "This is scene 1";

      private struct BACK_MSG
      {
         private const string MSG = "Press Escape to go back";
         private const int X = 0;
         private const int Y = 20;
         public static Text GetText()
         {
            return new Text.TextBuilder(MSG).WithXY(X, Y).Build();
         }
      }
      private const System.Windows.Forms.Keys BACK_KEY =
            System.Windows.Forms.Keys.Escape;

      private struct SWITCH_MSG
      {
         private const string MSG = "Press 2 to switch to scene 2";
         private const int X = 0;
         private const int Y = 40;
         public static Text GetText()
         {
            return new Text.TextBuilder(MSG).WithXY(X, Y).Build();
         }
      }
      private const System.Windows.Forms.Keys SWITCH_TO_2_KEY =
         System.Windows.Forms.Keys.D2;

      private struct BALL_TOGGLE
      {
         private const string IMAGE = Config.FILE_HOME + "res/ButtonBackground.png";
         private const string TEXT = "Bounce Ball";
         private const int X = 250;
         private const int Y = 10;
         // OnClick is BounceBall; see constructor, BounceBall is non-static
         public static Button GetButton(Action onClick)
         {
            return new Button.ButtonBuilder(Image.FromFile(IMAGE), X, Y)
               .withText(TEXT).withOnClick(onClick).Build();
         }
      }


      private Text sceneTitle;
      private Text backMessage;
      private Text sceneSwitchMessage;
      private Ball ball;
      private bool ballToggler;
      private Button ballToggle;

      public Scene1(Scene prevScene) : base(prevScene)
      {
         sceneTitle = new Text.TextBuilder(TITLE).Build();
         backMessage = BACK_MSG.GetText();
         sceneSwitchMessage = SWITCH_MSG.GetText();
         ball = new Ball();
         ballToggle = BALL_TOGGLE.GetButton(BounceBall);
      }

      protected override void InitializeMe()
      {
         IO.KEYS.Subscribe(Back, BACK_KEY);
         IO.KEYS.Subscribe(SwitchTo2, SWITCH_TO_2_KEY);
         IO.FRAME_TIMER.Subscribe(MoveBall);
         IO.RENDERER.Add(sceneTitle);
         IO.RENDERER.Add(backMessage);
         IO.RENDERER.Add(sceneSwitchMessage);
         IO.RENDERER.Add(ball.GetDrawable(), 1);
         IO.RENDERER.Add(ballToggle);
         ballToggle.Initialize();
      }

      public void SwitchTo2()
      {
         SwitchTo(new Scene2(this));
      }

      public void MoveBall()
      {
         if(ballToggler)
         {
            if(ball.GetDrawable().GetX() > Config.WINDOW.WIDTH - ball.GetDrawable().GetWidth())
            {
               ballToggler = !ballToggler;
            }
            else
            {
               ball.GetDrawable().SetX(ball.GetDrawable().GetX() + 3);
            }
         }
         else
         {
            if (ball.GetDrawable().GetX() <= 0)
            {
               ballToggler = !ballToggler;
            }
            else
            {
               ball.GetDrawable().SetX(ball.GetDrawable().GetX() - 3);
            }
         }
      }

      public void BounceBall()
      {
         ballToggler = !ballToggler;
      }

   }
}
