using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandartInputOutput2 {
  internal class Program {
    static void Main(string[] args) {

      FileStream fs = new FileStream("D:\\FullNameSerialize.bin", FileMode.OpenOrCreate, FileAccess.Write);
      TextFile fnc = new TextFile("Ivan", "Ivanov", "Ivanovich");
      fnc.Print();
      fnc.Print();
      fnc.Serialize(fs);
      fnc = new TextFile("Petr", "Petrov", "Petrovich");
      fnc.Print();
      fs = new FileStream("D:\\FullNameSerialize.bin", FileMode.OpenOrCreate, FileAccess.Read);
      fnc.Deserialize(fs);
      fnc.Print();

    }
  }
}
