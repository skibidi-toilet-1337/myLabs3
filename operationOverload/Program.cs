using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operationOverload {
  internal class Program {
    static void Main(string[] args) {
      squareMatrix sqrtMtrx = new squareMatrix(4);
      //Console.WriteLine(sqrtMtrx);
      Console.WriteLine(sqrtMtrx.ToString());

    }
  }
}
