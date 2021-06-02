using phi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhiGraphicsEngineExample
{
   class Scene2 : Scene
   {
      private const string TITLE = "This is scene 2";

      private const string BACK_MSG = "Press Backspace to go back";
      private const int BACK_MSG_Y = 20;
      private const System.Windows.Forms.Keys BACK_KEY =
         System.Windows.Forms.Keys.Back;
      
      private const string SWITCH_MSG = "Press 1 to switch to scene 1";
      private const int SWITCH_MSG_Y = 40;
      private const System.Windows.Forms.Keys SWITCH_TO_1_KEY =
         System.Windows.Forms.Keys.D1;

      private TextOverlay sceneTitle;
      private TextOverlay backMessage;
      private TextOverlay sceneSwitchMessage;

      public Scene2(IScene prevScene) : base(prevScene)
      {
         sceneTitle = new TextOverlay(TITLE);
         backMessage = new TextOverlay(BACK_MSG, 0, BACK_MSG_Y);
         sceneSwitchMessage = new TextOverlay(SWITCH_MSG, 0, SWITCH_MSG_Y);
      }

      public override void Initialize()
      {
         Renderer.obj.addText(sceneTitle);
         Renderer.obj.addText(backMessage);
         Renderer.obj.addText(sceneSwitchMessage);
      }

      public override IScene OnKeyDownEvent(System.Windows.Forms.Keys key)
      {
         // by default, do not switch scenes
         IScene toSwitchTo = this;
         if (key == BACK_KEY)
         {
            toSwitchTo = base.prevScene;
         }
         if (key == SWITCH_TO_1_KEY)
         {
            toSwitchTo = new Scene1(this);
         }
         return toSwitchTo;
      }

   }
}
