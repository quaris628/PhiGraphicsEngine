using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using phi.control.input;
using phi.other;

namespace phi.control
{
   partial class WindowsForm : Form
   {
      private PictureBox pictureBox;

      public WindowsForm()
      {
         InitializeComponent();
         Load += new EventHandler(FormLoad);
      }

      private void FormLoad(object sender, EventArgs e)
      {
         // set window properites
         Size = new Size(Config.WINDOW.WIDTH, Config.WINDOW.HEIGHT);
         Text = Config.WINDOW.TITLE;

         // Setup input event delegation
         KeyPreview = true;
         KeyDown += new KeyEventHandler(IO.KEYS.KeyInputEvent);
         // todo
         //MouseClick += new MouseEventHandler(IO.MOUSE.ClickEvent);
         //MouseMove += new MouseEventHandler(IO.MOUSE.MoveEvent);

         // create a picture box, to hold an image, the same size as the window
         pictureBox = new PictureBox();
         pictureBox.Size = Size;
         pictureBox.Image = Image.FromFile(Config.RENDER.DEFAULT_BACKGROUND);
         Controls.Add(pictureBox); // is this line needed?
         IO.RENDERER.SetOutput(pictureBox.Image);
         IO.FRAME_TIMER.LockSubscribe(new Random().Next(), RefreshPictureBox);

         Config.ENTRY_SCENE.Initialize();
         IO.FRAME_TIMER.Start();
      }

      private void RefreshPictureBox()
      {
         pictureBox.Image = pictureBox.Image; // Do not delete; forces some sort of update
      }

      public static void Exit() { Application.Exit(); }
   }
}
