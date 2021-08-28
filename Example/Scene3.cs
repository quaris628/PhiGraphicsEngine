using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phi.graphics.drawables;
using phi.control;
using phi.io;
using phi.phisics.Shapes;

namespace Example
{
   class Scene3 : Scene
   {
      // const config
      private const string TITLE = "This is scene 3, it uses SubscribeOnDrawable";

      private const string BACK_MSG = "Press Esc to go back";
      private const int BACK_MSG_Y = 20;
      private const Keys BACK_KEY = Keys.Escape;
      
      private const string SWITCH_MSG = "Press 4 to switch to scene 4";
      private const int SWITCH_MSG_Y = 40;
      private const Keys SWITCH_TO_4_KEY = Keys.D4;

      private const int SQUARES_N = 240;
      private const int SQUARES_M = 128;
      private const int SQUARES_SIZE = 5;
      private const int SQUARES_X = 0;
      private const int SQUARES_Y = 60;

      // mutable data
      private Text sceneTitle;
      private Text backMessage;
      private Text sceneSwitchMessage;

      private ColorChangingSquare[,] squares;

      // Constructors
      public Scene3(Scene prevScene) : base(prevScene)
      {
         sceneTitle = new Text.TextBuilder(TITLE).Build();
         backMessage = new Text.TextBuilder(BACK_MSG).WithY(BACK_MSG_Y).Build();
         sceneSwitchMessage = new Text.TextBuilder(SWITCH_MSG).WithY(SWITCH_MSG_Y).Build();

         squares = new ColorChangingSquare[SQUARES_N, SQUARES_M];
         Random r = new Random();
         for (int i = 0; i < SQUARES_N; i++)
         {
            for (int j = 0; j < SQUARES_M; j++)
            {
               squares[i, j] = new ColorChangingSquare(r.Next(), SQUARES_X + i * SQUARES_SIZE, SQUARES_Y + j * SQUARES_SIZE, SQUARES_SIZE);
            }
         }
      }

      protected override void InitializeMe()
      {
         IO.KEYS.Subscribe(Back, BACK_KEY);
         IO.KEYS.Subscribe(SwitchTo4, SWITCH_TO_4_KEY);

         IO.RENDERER.Add(sceneTitle);
         IO.RENDERER.Add(backMessage);
         IO.RENDERER.Add(sceneSwitchMessage);

         foreach (ColorChangingSquare sq in squares)
         {
            IO.RENDERER.Add(sq);
            IO.MOUSE.MOVE.SubscribeOnDrawable(sq.ChangeColorRandomly, sq);
         }

      }


      public void SwitchTo4()
      {
         SwitchTo(new Scene4(this));
      }
   }
}
