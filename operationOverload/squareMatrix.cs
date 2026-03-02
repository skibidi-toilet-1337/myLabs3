using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operationOverload {
  public class squareMatrix {

    private double[,] matrix;
    public int matrixSize;

    public squareMatrix(int size) {

      if (size <= 0) {
        throw new ArgumentException("The matrix size must be greater than zero.");
      }

        matrixSize = size;
        matrix = new double[size, size];

        Random randomGen = new Random();
        for (int x = 0; x < size; x++) {
          for (int y = 0; y < size; y++) {
            matrix[x,y] = randomGen.Next(-10, 10);
          Console.WriteLine(matrix[x,y]);

          }
        }

      

    }

  }
}
