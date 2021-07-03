﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi.graphics
{
   public class Line : PenDrawable
   {
      public Line(int startX, int startY, int endX, int endY)
         : base(startX, startY, endX - startX, endY - startY) { }

      protected override void DrawAt(Graphics g, int x, int y)
      {
         int x2 = x + GetWidth();
         int y2 = y + GetHeight();
         g.DrawLine(GetPen(), x, y, x2, y2);
      }

   }
}
