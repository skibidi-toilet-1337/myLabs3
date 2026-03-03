using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operationOverload {
  internal class Program {
    static void Main(string[] args) {
      //squareMatrix sqrtMtrx = new squareMatrix(4, true);
      //Console.WriteLine(sqrtMtrx);
      //Console.WriteLine(sqrtMtrx.ToString());
      //Console.WriteLine(sqrtMtrx.GetHashCode());

      squareMatrix mat1 = new squareMatrix(4, true);
      Console.WriteLine(mat1);

      squareMatrix mat2 = new squareMatrix(4, true);
      Console.WriteLine(mat2);

      squareMatrix mat3 = new squareMatrix(4, false);
      Console.WriteLine(mat3);
      mat3 = mat1 + mat2;
      Console.WriteLine(mat3);
    }
  }
}
