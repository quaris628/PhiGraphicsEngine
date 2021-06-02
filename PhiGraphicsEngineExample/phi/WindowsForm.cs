using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phi
{
   public partial class WindowsForm : Form
   {
      private static readonly IScene ENTRY_SCENE =
         new PhiGraphicsEngineExample.Scene1(null);
      public const string FILE_HOME = "../../";
      public const int WIN_HEIGHT = 400;
      public const int WIN_WIDTH = 600;
      private const int FPS = 60;

      private PictureBox pictureBox;
      private Timer frameTimer = new Timer();

      private IScene activeScene;

      public WindowsForm()
      {
         InitializeComponent();
      }

      // Should be run on Load -- set in VS designer,
      //    right-click properties -> events (lightning) -> Load field
      /**
       * Runs once when form created
       * @author Nathan Swartz, heavily modified from Ben's original method
       */
      private void WindowsForm_Load(object sender, EventArgs e)
      {
         Console.Write("Loading Form\n");

         // set size of the window
         this.Size = new Size(WIN_WIDTH, WIN_HEIGHT);

         // create a picture box, to hold an image, the same size as the window
         pictureBox = new PictureBox();
         pictureBox.Height = WIN_HEIGHT;
         pictureBox.Width = WIN_WIDTH;
         pictureBox.Image = Image.FromFile(Renderer.DEFAULT_BACKGROUND);
         Renderer.obj.setPictureBox(pictureBox);

         // set up keypress detection
         this.KeyPreview = true;
         this.KeyDown += new KeyEventHandler(WindowsForm_KeyDown);

         // set up timer
         this.frameTimer.Tick += new EventHandler(frameTimer_Tick);
         this.frameTimer.Interval = 1000 / FPS;
         this.frameTimer.Enabled = true;
         this.frameTimer.Start();

         // set up MainMenu as "entry point"-ish
         activeScene = ENTRY_SCENE;
         Renderer.obj.setBackground(activeScene.GetBackgroundImage());
         activeScene.Initialize();

         this.Controls.Add(pictureBox); // is this line needed?
      }

      // Should be run on KeyDown -- set in VS designer,
      //    right-click properties -> events (lightning) -> KeyDown field
      /**
       * Runs when any key is pressed
       * @author Nathan Swartz
       */
      private void WindowsForm_KeyDown(object sender, KeyEventArgs e)
      {
         switchSceneTo(activeScene.OnKeyDownEvent(e.KeyCode));
      }

      /**
       * Runs once each frame
       * @author Nathan Swartz
       */
      private void frameTimer_Tick(object sender, EventArgs e)
      {
         IScene newScene = activeScene.OnFrameTickEvent();
         Renderer.obj.Render();
         switchSceneTo(newScene);
      }

      private void switchSceneTo(IScene newScene)
      {
         if (newScene == null)
         {
            Application.Exit();
         }
         else if (!activeScene.Equals(newScene))
         {
            // clean up old scene
            Renderer.obj.clearAll();
            activeScene.Close();

            // display new scene
            Renderer.obj.setBackground(newScene.GetBackgroundImage());
            newScene.Initialize();

            activeScene = newScene;
         }
      }
   }
}
