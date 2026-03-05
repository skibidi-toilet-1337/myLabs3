using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace operationOverload {

  public class matrixNotInvertible : Exception {
    public matrixNotInvertible(string message) : base(message) {
    }
  }

  public class matricesMismatchSize : Exception {
    public matricesMismatchSize(string message) : base(message) {
    }
  }

  public class squareMatrix : IComparable<squareMatrix>, ICloneable {
    private double[,] matrix;
    private int matrixSize;
    private const int hashValue = 31;
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

    public void inputMatrix() {
      Console.Write("Set size: ");
      if (int.TryParse(Console.ReadLine(), out int inMatSize)) {
        matrixSize = inMatSize;
      } else {
        throw new matricesMismatchSize("Wrong value. Must be integer.");
      }

      matrix = new double[matrixSize, matrixSize];

      for (int row = 0; row < matrixSize; ++row) {
        for (int col = 0; col < matrixSize; ++col) {

          //cout << "enter num of " << row + 1 << "; " << column + 1 << ": ";
          Console.Write($"Enter [{row + 1},{col + 1}] = ");

          if (double.TryParse(Console.ReadLine(), out double value)) {
            matrix[row, col] = value;
          } else {
            throw new ArgumentException("Wrong value. Must be double.");
          }
        }
      }
    }

    public static squareMatrix operator +(squareMatrix mat1, squareMatrix mat2) {

      if (mat1.matrixSize != mat2.matrixSize) {
        throw new matricesMismatchSize("The size of the matrices must be the same.");
      }

      squareMatrix result = new squareMatrix(mat1.matrixSize, false);

      for (int row = 0; row < mat1.matrixSize; ++row) {
        for (int col = 0; col < mat1.matrixSize; ++col) {
          result.matrix[row, col] = mat1.matrix[row, col] + mat2.matrix[row, col];
        }
      }
      return result;
    }

    public static squareMatrix operator *(squareMatrix mat1, squareMatrix mat2) {

      if (mat1.matrixSize != mat2.matrixSize) {
        throw new matricesMismatchSize("The size of the matrices must be the same.");
      }

      squareMatrix result = new squareMatrix(mat1.matrixSize, false);

      for (int row = 0; row < mat1.matrixSize; ++row) {
        for (int col = 0; col < mat1.matrixSize; ++col) {
          result.matrix[row, col] = 0;

          for (int index = 0; index < mat1.matrixSize; ++index) {
            result.matrix[row, col] += mat1.matrix[row, index] * mat2.matrix[index, col];
          }
        }
      }
      return result;
    }

    public static bool operator >(squareMatrix mat1, squareMatrix mat2) {

      if (mat1.matrixSize != mat2.matrixSize) {
        throw new matricesMismatchSize("The size of the matrices must be the same.");
      }

      return mat1.determinant() > mat2.determinant();
    }

    public static bool operator <(squareMatrix mat1, squareMatrix mat2) {

      if (mat1.matrixSize != mat2.matrixSize) {
        throw new matricesMismatchSize("The size of the matrices must be the same.");
      }

      return mat1.determinant() < mat2.determinant();
    }

    public static bool operator >=(squareMatrix mat1, squareMatrix mat2) {

      if (mat1.matrixSize != mat2.matrixSize) {
        throw new matricesMismatchSize("The size of the matrices must be the same.");
      }

      return mat1.determinant() >= mat2.determinant();
    }

    public static bool operator <=(squareMatrix mat1, squareMatrix mat2) {

      if (mat1.matrixSize != mat2.matrixSize) {
        throw new matricesMismatchSize("The size of the matrices must be the same.");
      }

      return mat1.determinant() <= mat2.determinant();
    }

    public static bool operator ==(squareMatrix mat1, squareMatrix mat2) {

      if (mat1.matrixSize != mat2.matrixSize) {
        throw new matricesMismatchSize("The size of the matrices must be the same.");
      }

      return mat1.Equals(mat2);
    }

    public static bool operator !=(squareMatrix mat1, squareMatrix mat2) {

      if (mat1.matrixSize != mat2.matrixSize) {
        throw new matricesMismatchSize("The size of the matrices must be the same.");
      }

      return !mat1.Equals(mat2);
    }

    public static bool operator true(squareMatrix mat1) {
      return mat1.determinant() != 0;
    }

    public static bool operator false(squareMatrix mat1) {
      return mat1.determinant() == 0;
    }

    public squareMatrix inverse() {
      double det = determinant();

      if (det == 0) {
        throw new matrixNotInvertible("There is no inverse matrix because the determinant is zero.");
      }

      int size = matrixSize;
      squareMatrix resultMat = new squareMatrix(size, false);

      for (int row = 0; row < size; ++row) {
        for (int col = 0; col < size; ++col) {
          double[,] minorMat = calcMinor(matrix, row, col);
          resultMat.matrix[row, col] = Math.Pow(-1, row + col) * calcDeterminant(minorMat) / det;
        }
      }
      return resultMat;
    }

    public double determinant() {
      return calcDeterminant(matrix);
    }

    public double calcDeterminant(double[,] detMat) {

      int size = detMat.GetLength(0);

      if (size == 1) {
        return detMat[0, 0];
      }

      if (size == 2) {
        return detMat[0, 0] * detMat[1, 1] - detMat[0, 1] * detMat[1, 0];
      }

      double det = 0;

      for (int power = 0; power < size; ++power) {
        double[,] minor = calcMinor(detMat, 0, power);
        det += detMat[0, power] * Math.Pow(-1, power) * calcDeterminant(minor);
      }
      return det;
    }

    private double[,] calcMinor(double[,] minorMat, int row, int col) {

      int size = minorMat.GetLength(0);
      double[,] minor = new double[size - 1, size - 1];
      int localRow = 0;
      int localCol = 0;

      for (int cycleRow = 0; cycleRow < size; ++cycleRow) {
        if (cycleRow == row) continue;
        localCol = 0;

        for (int cycleCol = 0; cycleCol < size; ++cycleCol) {
          if (cycleCol == col) continue;
          minor[localRow, localCol] = minorMat[cycleRow, cycleCol];
          ++localCol;
        }
        ++localRow;
      }
      return minor;
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
        throw new matricesMismatchSize("The size of the matrices must be the same.");
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
