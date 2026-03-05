using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operationOverload {
  internal class Program {
    static squareMatrix matA, matB;

    static void showMenu() {
      Console.WriteLine("\nMenu:\n" +
        "----------------\n" +
        "1: Gen matrix A\n" +
        "2: Gen matrix B\n" +
        "3: Set matrix A\n" +
        "4: Set matrix B\n" +
        "5: Show matrices\n" +
        "6: A + B\n" +
        "7: A * B\n" +
        "8: A > B\n" +
        "9: A < B\n" +
        "10: A <= B\n" +
        "11: A >= B\n" +
        "12: A == B\n" +
        "13: A != B\n" +
        "14: Det A\n" +
        "15: Det B\n" +
        "16: Inv A\n" +
        "17: Inv B\n" +
        "18: Clone A to B\n" +
        "19: Clone B to A\n" +
        "----------------\n" +
        "0: Exit\n");
      Console.Write("Select option: ");
    }

    static void test() {
      //squareMatrix sqrtMtrx = new squareMatrix(4, true);
      //Console.WriteLine(sqrtMtrx);
      //Console.WriteLine(sqrtMtrx.ToString());
      //Console.WriteLine(sqrtMtrx.GetHashCode());
      try {

        squareMatrix mat1 = new squareMatrix(3, true);
        Console.WriteLine(mat1);

        squareMatrix mat2 = new squareMatrix(3, true);
        Console.WriteLine(mat2);

        squareMatrix mat3 = new squareMatrix(3, false);

        if (mat3) {
          Console.WriteLine("true");
        } else {
          Console.WriteLine("false");
        }

        Console.WriteLine(mat3);
        mat3 = mat1 + mat2;
        Console.WriteLine(mat3);
        Console.WriteLine(mat3.determinant());
        Console.WriteLine(mat3.inverse());
      }

      catch (Exception ex) {
        Console.WriteLine(ex.ToString());
      }
    }
    static void Main(string[] args) {

      try {
        string option;
        int sizeA = 1;
        int sizeB = 1;

        matA = new squareMatrix(sizeA, false);
        matB = new squareMatrix(sizeB, false);

        while (true) {
          showMenu();
          option = Console.ReadLine();
          Console.WriteLine("");

          switch (option) {

            //Exit
            case "0":
              return;

            //Gen matrix A
            case "1":
              Console.Write("Enter size of matrix: ");
              if (int.TryParse(Console.ReadLine(), out int inSizeA)) {
                sizeA = inSizeA;
              } else {
                throw new matricesMismatchSize("Wrong value. Must be integer.");
              }
              matA = new squareMatrix(sizeA, true);
              break;

            //Gen matrix B
            case "2":
              Console.Write("Enter size of matrix: ");
              if (int.TryParse(Console.ReadLine(), out int inSizeB)) {
                sizeB = inSizeB;
              } else {
                throw new matricesMismatchSize("Wrong value. Must be integer.");
              }
              matB = new squareMatrix(sizeB, true);
              break;

            //Set matrix A
            case "3":
              matA.inputMatrix();
              break;

            //Set matrix B
            case "4":
              matB.inputMatrix();
              break;

            //Show matrices
            case "5":
              Console.WriteLine($"Matrix A:\n{matA}\n");
              Console.WriteLine($"Matrix B:\n{matB}\n");
              break;

            //A + B
            case "6":
              Console.WriteLine($"A + B:\n{matA + matB}");
              break;

            //A * B
            case "7":
              Console.WriteLine($"A * B:\n{matA * matB}");
              break;

            //A > B
            case "8":
              Console.WriteLine($"A > B:\n{matA > matB}");
              break;

            //A < B
            case "9":
              Console.WriteLine($"A < B:\n{matA < matB}");
              break;

            //A <= B
            case "10":
              Console.WriteLine($"A <= B:\n{matA <= matB}");
              break;

            //A >= B
            case "11":
              Console.WriteLine($"A >= B:\n{matA >= matB}");
              break;

            //A == B
            case "12":
              Console.WriteLine($"A == B:\n{matA == matB}");
              break;

            //A != B
            case "13":
              Console.WriteLine($"A != B:\n{matA != matB}");
              break;

            //Det A
            case "14":
              Console.WriteLine($"Det A:\n{matA.determinant()}");
              break;

            //Det B
            case "15":
              Console.WriteLine($"Det B:\n{matB.determinant()}");
              break;

            //Inv A
            case "16":
              Console.WriteLine($"Inv A:\n{matA.inverse()}");
              break;

            //Inv B
            case "17":
              Console.WriteLine($"Inv B:\n{matB.inverse()}");
              break;

            //Clone A to B
            case "18":
              Console.WriteLine($"Clone A to B:\n{matB = matA}");
              break;

            case "19":
              Console.WriteLine($"Clone B to A:\n{matA = matB}");
              break;
          }
        }
      }

      catch (Exception ex) {
        Console.WriteLine(ex.ToString());
      }
    }
  }
}
