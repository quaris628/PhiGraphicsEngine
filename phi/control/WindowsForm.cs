using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using phi.io;
using phi.other;

namespace phi.control
{
   partial class WindowsForm : Form
   {
      private Scene entryScene;
      private Config config;
      private PictureBox pictureBox;
      
      public WindowsForm(Scene entryScene, Config config)
      {
         this.entryScene = entryScene;
         this.config = config;

         Application.EnableVisualStyles();
         //Application.SetCompatibleTextRenderingDefault(false);
         InitializeComponent();
         Load += new EventHandler(FormLoad);
      }

      private void FormLoad(object sender, EventArgs e)
      {
         // set window properites
         Size = new Size(config.GetWindowWidth(), config.GetWindowHeight());
         Text = config.GetWindowTitle();

         // set up a picture box, to hold an image, the same size as the window
         pictureBox = new PictureBox();
         pictureBox.Size = Size;
         pictureBox.Image = Image.FromFile(config.GetRenderDefaultBackground());
         Controls.Add(pictureBox); // is this line needed? -- Yes, I think so

         // Setup key input event handling
         KeyPreview = true;
         KeyDown += new KeyEventHandler(IO.KEYS.KeyInputEvent);

         // Setup mouse input event handling
         pictureBox.MouseClick += new MouseEventHandler(IO.MOUSE.CLICK.Event);
         pictureBox.MouseDown += new MouseEventHandler(IO.MOUSE.DOWN.Event);
         pictureBox.MouseUp += new MouseEventHandler(IO.MOUSE.UP.Event);
         pictureBox.MouseMove += new MouseEventHandler(IO.MOUSE.MOVE.Event);
         
         // Set output to the picturebox image
         IO.RENDERER.SetOutput(pictureBox.Image);
         IO.RENDERER.SetBackground(Image.FromFile(config.GetRenderDefaultBackground()));
         IO.RENDERER.SetDefaultLayer(config.GetRenderDefaultLayer());
         // picturebox image must be updated to the new image on each render frame
         IO.FRAME_TIMER.LockedSubscribe(new Random().Next(), RefreshPictureBox);
         
         IO.FRAME_TIMER.SetFPS(config.GetRenderFPS());

         entryScene.Initialize();
         IO.FRAME_TIMER.Start();
      }

      private void RefreshPictureBox()
      {
         pictureBox.Image = pictureBox.Image; // Do not delete; forces some sort of update
      }

      public static void Exit() { Application.Exit(); }
   }
}
