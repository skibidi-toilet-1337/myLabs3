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
        "1: Set matrix A\n" +
        "2: Set matrix B\n" +
        "3: A + B\n" +
        "4: A * B\n" +
        "5: A > B\n" +
        "6: A < B\n" +
        "7: A <= B\n" +
        "8: A >= B\n" +
        "9: A == B\n" +
        "10: A != B\n" +
        "11: Det A\n" +
        "12: Det B\n" +
        "13: Inv A\n" +
        "14: Inv B\n" +
        "15: Show matrices\n" +
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

      string option;
      matA = new squareMatrix(1, false);
      matB = new squareMatrix(1, false);
      while (true) {
        showMenu();
        option = Console.ReadLine();
        Console.WriteLine("");

        switch (option) {

          //Exit
          case "0":
            return;
          
          //Set matrix A
          case "1":
            matA.inputMatrix();
            break;

          //Set matrix B
          case "2":
            matB.inputMatrix();
            break;

          //A + B
          case "3":
            Console.WriteLine($"A + B:\n{matA + matB}");
            break;

          //A * B
          case "4":
            //Console.WriteLine($"A * B:\n{matA * matB}");
            break;

          //A > B
          case "5":
            break;

          //A < B
          case "6":
            break;

          //A <= B
          case "7":
            break;

          //A >= B
          case "8":
            break;

          //A == B
          case "9":
            break;

          //A != B
          case "10":
            break;

          //Det A
          case "11":
            break;

          //Det B
          case "12":
            break;

          //Inv A
          case "13":
            break;

          //Inv B
          case "14":
            break;

          //Show matrices
          case "15":
            Console.WriteLine($"Matrix A:\n{matA}\n");
            Console.WriteLine($"Matrix B:\n{matB}\n");
            break;

        }

      }

    }
  }
}
