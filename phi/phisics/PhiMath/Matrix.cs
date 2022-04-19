using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phi.phisics.PhiMath
{
   public class MatrixException : Exception
   {
      public MatrixException() : base() { }
      public MatrixException(String message) : base(message) { }
      public MatrixException(String message, Exception inner) : base(message, inner) { } 
   }
   public class Matrix
   {
      private float[,] matrix;

      public Matrix(float[,] matrix)
      {
         this.matrix = matrix;
      }

      public Matrix(int degree)
      {
         this.matrix = new float[degree, degree];
         for(int c = 0; c < degree; c++)
         {
            this.matrix[c, c] = 1;
         }
      }

      #region Operator Overloads
      public static bool operator == (Matrix a, Matrix b)
      {
         if (a.matrix.GetLength(0) != b.matrix.GetLength(0) || a.matrix.GetLength(1) != b.matrix.GetLength(1))
         {
            return false;
         }
         else
         {
            for (int x = 0; x < a.matrix.GetLength(0); x++)
            {
               for (int y = 0; y < a.matrix.GetLength(1); y++)
               {
                  if(a.matrix[x,y] != b.matrix[x,y])
                  {
                     //throw new MatrixException(x + " " + y + ": " + a.matrix[x, y] + ", " + b.matrix[x, y]);
                     return false;
                  }
               }
            }
            return true;
         }
      }
      public static bool operator != (Matrix a, Matrix b)
      {
         return !(a == b);
      }

      public static Matrix operator *(Matrix a, Matrix b)
      {
         if(a.matrix.GetLength(1) != b.matrix.GetLength(0))
         {
            throw new MatrixException("Invalid Matrix Dimensions");
         }
         else
         {
            float[,] newMatrix = new float[a.matrix.GetLength(1), b.matrix.GetLength(0)];
            for(int x = 0; x < a.matrix.GetLength(1); x++)
            {
               for (int y = 0; y < b.matrix.GetLength(0); y++)
               {
                  float sum = 0;
                  for(int z = 0; z < a.matrix.GetLength(1); z++)
                  {
                     sum += a.matrix[x, z] * b.matrix[z, y];
                  }
                  newMatrix[x, y] = sum;
               }
            }
            return new Matrix(newMatrix);
         }
      }

      public static Matrix operator *(Matrix a, float b)
      {
         float[,] newMatrix = new float[a.matrix.GetLength(1), a.matrix.GetLength(0)];
         for (int x = 0; x < a.matrix.GetLength(1); x++)
         {
            for (int y = 0; y < a.matrix.GetLength(0); y++)
            {
               
               newMatrix[x, y] = a.matrix[x,y] * b;
            }
         }
         return new Matrix(newMatrix);
      }

      public static Matrix operator *(float b, Matrix a)
      {
         float[,] newMatrix = new float[a.matrix.GetLength(1), a.matrix.GetLength(0)];
         for (int x = 0; x < a.matrix.GetLength(1); x++)
         {
            for (int y = 0; y < a.matrix.GetLength(0); y++)
            {

               newMatrix[x, y] = a.matrix[x, y] * b;
            }
         }
         return new Matrix(newMatrix);
      }

      public static Matrix operator +(Matrix a, Matrix b)
      {
         if (a.matrix.GetLength(1) != b.matrix.GetLength(0))
         {
            throw new MatrixException("Invalid Matrix Dimensions");
         }
         float[,] newMatrix = new float[a.matrix.GetLength(1), a.matrix.GetLength(0)];
         for (int x = 0; x < a.matrix.GetLength(1); x++)
         {
            for (int y = 0; y < a.matrix.GetLength(0); y++)
            {

               newMatrix[x, y] = a.matrix[x, y] + b.matrix[x,y];
            }
         }
         return new Matrix(newMatrix);
      }

      public static Matrix operator -(Matrix a, Matrix b)
      {
         return a + (-1 * b);
      }
      #endregion

      public void Transpose()
      {
         //todo implement transpose
      }

      public float Determinate()
      {
         //todo implement determinate
         return 0;
      }

      public void Inverse()
      {

      }

   }
}
