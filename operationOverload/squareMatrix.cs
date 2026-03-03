using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operationOverload {
  public class squareMatrix : IComparable<squareMatrix>, ICloneable {

    private double[,] matrix;
    public int matrixSize;
    public const int hashValue = 31;

    private static int seed = 0;
    public squareMatrix(int size, bool isRandGen) {
      if (size <= 0) {
        throw new ArgumentException("The matrix size must be greater than zero.");
      }

      matrixSize = size;
      matrix = new double[size, size];

      Random randomGen = new Random(++seed + Environment.TickCount);
      
      for (int row = 0; row < size; ++row) {
        for (int col = 0; col < size; ++col) {

          if (isRandGen) {
            matrix[row, col] = randomGen.Next(-10, 10);
          } else {
            matrix[row, col] = 0;
          }

        }
      }
    }

    //public squareMatrix(double[,] newSqrtMatrix) {
    //  int rows = newSqrtMatrix.GetLength(0);
    //  int columns = newSqrtMatrix.GetLength(1);

    //  if (rows != columns) {
    //    throw new ArgumentException("Matrix should be square");
    //  }

    //  matrixSize = rows;
    //  matrix = new double[matrixSize, matrixSize];

    //  Array.Copy(newSqrtMatrix, matrix, newSqrtMatrix.Length);

    //}

    public static squareMatrix operator +(squareMatrix mat1, squareMatrix mat2) {

      squareMatrix result = new squareMatrix(mat1.matrixSize, false);

      for (int row = 0; row < mat1.matrixSize; ++row) {
        for (int col = 0; col < mat1.matrixSize; ++col) {
          result.matrix[row, col] = mat1.matrix[row, col] + mat2.matrix[row,col];
        }
      }
      return result;
    }

    public object Clone() {
      squareMatrix result = new squareMatrix(matrixSize, false);

      for (int row = 0; row < matrixSize; ++row) {
        for (int col = 0; col < matrixSize; ++col) {
          result.matrix[row, col] = this.matrix[row, col];
        }
      }
      return result;
    }

    public override string ToString() {

      string result = "";

      for (int row = 0; row < matrixSize; ++row) {
        for (int col = 0; col < matrixSize; ++col) {
          result += ((col == 0) ? ("") : ("\t")) + matrix[row, col];
        }
        result += "\n";
      }
      return result;
    }

    public int CompareTo(squareMatrix other) {
      throw new NotImplementedException();
    }

    public override bool Equals(object obj) {
      squareMatrix otherMatrix = obj as squareMatrix;

      if (this.matrixSize != otherMatrix.matrixSize) {
        throw new ArgumentException("The size of the matrices must be the same.");
      }

      for (int row = 0; row < matrixSize; ++row) {
        for (int col = 0; col < matrixSize; ++col) {

          if (otherMatrix.matrix[row, col] != this.matrix[row, col]) {
            return false;
          }
        }
      }
      return true;
    }

    public override int GetHashCode() {
      int hash = matrixSize;
      foreach (double value in matrix) {
        hash = hash * hashValue + value.GetHashCode();
      }
      return hash;
    }

  
  }
}
