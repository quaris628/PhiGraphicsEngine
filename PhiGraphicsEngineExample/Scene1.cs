using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.graphics;


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


      public Scene1(Scene prevScene) : base(prevScene)
      {
         sceneTitle = new Text.TextBuilder(TITLE).Build();
         backMessage = new Text.TextBuilder(BACK_MSG).WithY(BACK_MSG_Y).Build();
         sceneSwitchMessage = new Text.TextBuilder(SWITCH_MSG).WithY(SWITCH_MSG_Y).Build(); 
         ball = new Ball();
      }

      public override void Initialize(Renderer renderer)
      {
         base.Initialize(renderer);
         renderer.Add(sceneTitle, 0);
         renderer.Add(backMessage, 0);
         renderer.Add(sceneSwitchMessage, 0);
         renderer.Add(ball.GetDrawable(), 0);
      }

      public override Scene OnKeyDownEvent(System.Windows.Forms.KeyEventArgs e)
      {
         // by default, do not switch scenes
         System.Windows.Forms.Keys key = e.KeyCode;
         Scene toSwitchTo = this;
         if (key == BACK_KEY)
         {
            toSwitchTo = base.prevScene;
         }
         if (key == SWITCH_TO_2_KEY)
         {
            toSwitchTo = new Scene2(this);
         }
         return toSwitchTo;
      }

      public override Scene OnFrameTickEvent()
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
         return this;  
      }

   }
}
