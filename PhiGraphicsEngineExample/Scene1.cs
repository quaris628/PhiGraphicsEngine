using phi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

      private TextOverlay sceneTitle;
      private TextOverlay backMessage;
      private TextOverlay sceneSwitchMessage;
      private Ball ball;
      private bool ballToggler;


      public Scene1(IScene prevScene) : base(prevScene)
      {
         sceneTitle = new TextOverlay(TITLE);
         backMessage = new TextOverlay(BACK_MSG, 0, BACK_MSG_Y);
         sceneSwitchMessage = new TextOverlay(SWITCH_MSG, 0, SWITCH_MSG_Y);
         ball = new Ball();
      }

      public override void Initialize()
      {
         Renderer.obj.addText(sceneTitle);
         Renderer.obj.addText(backMessage);
         Renderer.obj.addText(sceneSwitchMessage);
         Renderer.obj.addRenderable(ball, 0);
      }

      public override IScene OnKeyDownEvent(System.Windows.Forms.KeyEventArgs keyevent)
      {
         // by default, do not switch scenes
         System.Windows.Forms.Keys key = keyevent.KeyCode;
         IScene toSwitchTo = this;
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

      public override IScene OnFrameTickEvent()
      {
         if(ballToggler)
         {
            if(ball.getSprite().getX() > 300)
            {
               ballToggler = !ballToggler;
            }
            else
            {
               ball.getSprite().setX(ball.getSprite().getX() + 3);
            }
         }
         else
         {
            if (ball.getSprite().getX() <= 0)
            {
               ballToggler = !ballToggler;
            }
            else
            {
               ball.getSprite().setX(ball.getSprite().getX() - 3);
            }
         }
         return this;  
      }

   }
}
