﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.graphics;


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

      private Text sceneTitle;
      private Text backMessage;
      private Text sceneSwitchMessage;

      public Scene2(Scene prevScene) : base(prevScene)
      {
         sceneTitle = new Text.TextBuilder(TITLE).Build();
         backMessage = new Text.TextBuilder(BACK_MSG).WithY(BACK_MSG_Y).Build();
         sceneSwitchMessage = new Text.TextBuilder(SWITCH_MSG).WithY(SWITCH_MSG_Y).Build();
      }

      public override void Initialize(Renderer renderer)
      {
         base.Initialize(renderer);
         renderer.Add(sceneTitle, 0);
         renderer.Add(backMessage, 0);
         renderer.Add(sceneSwitchMessage, 0);
      }

      public override Scene OnKeyDownEvent(System.Windows.Forms.KeyEventArgs keyevent)
      {
         // by default, do not switch scenes
         System.Windows.Forms.Keys key = keyevent.KeyCode;
         Scene toSwitchTo = this;
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
