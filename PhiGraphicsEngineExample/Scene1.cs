using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.graphics;
using phi.control;
using phi.control.input;

namespace PhiGraphicsEngineExample
{
   class Scene1 : Scene
   {
      private const string TITLE = "This is scene 1";

      private const string BACK_MSG = "Press Escape to go back";
      private const int BACK_MSG_Y = 20;
      private const System.Windows.Forms.Keys BACK_KEY =
         System.Windows.Forms.Keys.Escape;

      private const string SWITCH_MSG = "Press 2 to switch to scene 2";
      private const int SWITCH_MSG_Y = 40;
      private const System.Windows.Forms.Keys SWITCH_TO_2_KEY =
         System.Windows.Forms.Keys.D2;

      private Text sceneTitle;
      private Text backMessage;
      private Text sceneSwitchMessage;
      private Ball ball;
      private bool ballToggler;
      private Button ballControl;

      public Scene1(Scene prevScene) : base(prevScene)
      {
         sceneTitle = new Text.TextBuilder(TITLE).Build();
         backMessage = new Text.TextBuilder(BACK_MSG).WithY(BACK_MSG_Y).Build();
         sceneSwitchMessage = new Text.TextBuilder(SWITCH_MSG).WithY(SWITCH_MSG_Y).Build(); 
         ball = new Ball();
         ballControl = new Button.ButtonBuilder((Sprite)ball.GetDrawable()).withText("Toggle").withOnClick(ToggleBall).Build();
         ballControl.SetXY(250, 10);
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
         ballControl.Initialize();
         IO.RENDERER.Add(ballControl);
      }

      public void SwitchTo2()
      {
         SwitchTo(new Scene2(this));
      }

      public void MoveBall()
      {
         if(ballToggler)
         {
            if(ball.GetDrawable().GetX() > 300)
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

      public void ToggleBall()
      {
         ballToggler = !ballToggler;
      }

   }
}
