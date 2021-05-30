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
      private const System.Windows.Forms.Keys SWITCH_TO_SCENE_2 =
         System.Windows.Forms.Keys.D2;

      private TextOverlay sceneLabel;
      private TextOverlay sceneSwitchMessage;
      private Ball ball;
      private bool ballToggler;


      public Scene1()
      {
         sceneLabel = new TextOverlay("This is scene 1");
         sceneSwitchMessage = new TextOverlay(
            "Press 2 to switch to scene 2", 0, 20);
         ball = new Ball();
         
      }

      public override void Initialize()
      {
         Renderer.obj.addText(sceneLabel);
         Renderer.obj.addText(sceneSwitchMessage);
         Renderer.obj.addRenderable(ball, 0);
      }

      public override IScene OnKeyDownEvent(System.Windows.Forms.KeyEventArgs keyevent)
      {
         // by default, do not switch scenes
         System.Windows.Forms.Keys key = keyevent.KeyCode;
         IScene toSwitchTo = this;
         if (key == SWITCH_TO_SCENE_2)
         {
            toSwitchTo = new Scene2();
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
