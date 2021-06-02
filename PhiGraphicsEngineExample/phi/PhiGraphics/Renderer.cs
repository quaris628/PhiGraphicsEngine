using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi
{
   public class Renderer
   {
      public const string DEFAULT_BACKGROUND = WindowsForm.FILE_HOME + "phi/PhiGraphics/defaultBackground.png";

      private Image outputImage;
      private Image defaultBackground;
      private Image background;
      private SortedList<int, LinkedList<Renderable>> layers;
      private LinkedList<TextOverlay> texts;
      private bool isCentered;
      private ISprite centerSprite; //used to center the camera on a specific sprite
      private int center_X_Displacement; //How close to the edge the center gets before the screen displaces
      private int center_Y_Displacement; //How close to the top and bottom edges before the screen displaces
      private int displacementX;
      private int displacementY;
      private bool hasChanged;

      /**
       * Singleton Renderer class
       * Make sure to set the output image before rendering
       * @author Nathan Swartz
       */
      public static readonly Renderer obj = new Renderer();

      private Renderer()
      {
         this.defaultBackground = Image.FromFile(DEFAULT_BACKGROUND);
         this.background = (Image)this.defaultBackground.Clone();
         this.layers = new SortedList<int, LinkedList<Renderable>>();
         this.texts = new LinkedList<TextOverlay>();
         this.hasChanged = true;
         this.isCentered = false;
         this.centerSprite = null;
         this.center_X_Displacement = 0;
         this.center_Y_Displacement = 0;
         this.displacementX = 0;
         this.displacementY = 0;
      }

      /**
        * Sets the image to draw images on top of
        * Is also the output (pass by reference)
        * Should be set before any render() call; render() may throw an exception otherwise
        */
      public void setOutputImage(Image outputImage) { this.outputImage = outputImage; this.hasChanged = true; }
      /**
       * Sets the background that all drawn images are stacked on top of
       */
      public void setBackground(Image background)
      {
         if (background != null)
         {
            this.background = background;
         }
         else
         {
            this.background = (Image)this.defaultBackground.Clone();
         }

         this.hasChanged = true;
      }

      /**
       * Combines all images in the queue onto the output image
       * Starts with a clean background each time
       * Images appear stacked on top of each other, with the last added to the
       *    queue on top
       * Sprites are rendered first, text is always rendered last
       * 
       * (Note by Nathan, this method could be optimized (?*) to distribute
       *   the load of drawing each sprite in the queue to instead be done
       *   whenever a sprite is added. *Wouldn't change the total time needed.)
       * @author Nathan Swartz, Benjamin Lippincott
       */
      public void Render()
      {
         if (this.hasChanged)
         {
            Graphics g = Graphics.FromImage(outputImage);
            //g.Clear(SystemColors.AppWorkspace);
            g.DrawImage(background, 0, 0);
            calculateDisplacement();

            // render each renderable's sprite that is displaying
            foreach (KeyValuePair<int, LinkedList<Renderable>> kvp in layers)
            {
               foreach (Renderable renderable in kvp.Value)
               {
                  if (renderable.isDisplaying())
                  {
                     //Console.WriteLine(renderable);
                     ISprite s = renderable.getSprite();
                     g.DrawImage(s.getImage(),
                        s.getX() + displacementX,
                        s.getY() + displacementY);
                  }
               }
            }

            // render each text overlay, on top of every other layer
            foreach (TextOverlay t in texts)
            {
               using (Font f = t.getFont())
               {
                  g.DrawString(t.getMessage(), f, Brushes.Black, new PointF(t.getX(), t.getY()));
               }
            }

            g.Dispose();
            this.hasChanged = false;
         }
      }

      public void addRenderable(Renderable renderable, int layer)
      {
         if (!layers.ContainsKey(layer))
         {
            // create new sub-list for a new layer
            layers.Add(layer, new LinkedList<Renderable>());
         }
         layers[layer].AddLast(renderable); // layers.ElementAt(layer).Value.AddLast(renderable);
         this.hasChanged = true;
      }
      public void clearLayer(int layer) { layers.Remove(layer); this.hasChanged = true; }
      public void clearRenderables() { layers.Clear(); this.hasChanged = true; removeCenter(); }
      public void addText(TextOverlay t) { texts.AddLast(t); this.hasChanged = true; }
      public void clearTexts() { texts.Clear(); this.hasChanged = true; }
      public void clearAll() { clearRenderables(); clearTexts(); this.hasChanged = true; }

      /**
       * Attempts to center the camera on the sprite
       */
      public void centerCamera(ISprite s)
      {
         isCentered = true;
         centerSprite = s;
         this.center_X_Displacement = outputImage.Width / 2 - s.getImage().Width;
         this.center_Y_Displacement = outputImage.Height / 2 - s.getImage().Height;
      }

      /**
       * Sets Sprite s the center of the camera, and displaces the camera when the sprite gets within x of the width and y within the height
       */
      public void borderCamera(ISprite s, int x, int y)
      {
         isCentered = true;
         centerSprite = s;
         this.center_X_Displacement = x;
         this.center_Y_Displacement = y;
         this.hasChanged = true;
      }

      public void removeCenter()
      {
         centerSprite = null;
         isCentered = false;
      }

      private void calculateDisplacement()
      {
         if (isCentered)
         {
            displacementX += centerSprite.getImage().Width * isDisplacedX();
            displacementY += centerSprite.getImage().Height * isDisplacedY();
         }
         else
         {
            displacementX = 0;
            displacementY = 0;
         }
      }

      /**
       * Returns 1 if the center sprite is getting too close to the right edge,
       * Returns -1 if the center sprite is getting too close to the left edge
       * Returns 0 if the center sprite is not near any edge
       */
      private int isDisplacedX()
      {
         if (centerSprite.getX() + centerSprite.getImage().Width + displacementX + center_X_Displacement > outputImage.Width)
         {
            return -1;
         }
         else if (centerSprite.getX() + displacementX < center_X_Displacement && displacementX < 0)
         {
            return 1;
         }
         else
            return 0;

      }

      private int isDisplacedY()
      {
         if (centerSprite.getY() + centerSprite.getImage().Height + displacementY + center_Y_Displacement > outputImage.Height)
         {
            return -1;
         }
         else if (centerSprite.getY() + displacementY < center_Y_Displacement && displacementY < 0)
         {
            return 1;
         }
         else
            return 0;

      }

      public void HasChanged() { this.hasChanged = true; }
   }
}
