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
      private const System.Windows.Forms.Keys SWITCH_TO_SCENE_1 =
         System.Windows.Forms.Keys.D1;

      private TextOverlay sceneLabel;
      private TextOverlay sceneSwitchMessage;

      public Scene2()
      {
         sceneLabel = new TextOverlay("This is scene 2");
         sceneSwitchMessage = new TextOverlay(
            "Press 1 to switch to scene 1", 0, 20);
      }

      public override void Initialize()
      {
         Renderer.obj.addText(sceneLabel);
         Renderer.obj.addText(sceneSwitchMessage);
      }

      public override IScene OnKeyDownEvent(System.Windows.Forms.Keys key)
      {
         // by default, do not switch scenes
         IScene toSwitchTo = this;
         if (key == SWITCH_TO_SCENE_1)
         {
            toSwitchTo = new Scene1();
         }
         return toSwitchTo;
      }

   }
}
