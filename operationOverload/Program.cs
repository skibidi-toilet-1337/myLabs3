using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operationOverload {
  internal class Program {

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
      showMenu();
      //test();

    }
  }
}
