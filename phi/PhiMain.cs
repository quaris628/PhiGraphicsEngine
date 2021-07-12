using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using phi.control;

namespace phi
{
   public static class PhiMain
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      public static void Main(Scene entryScene, DefaultConfig config)
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new WindowsForm(entryScene, config));
      }

      public static void Main() { }
   }
}
