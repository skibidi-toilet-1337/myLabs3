using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myLab2 {
  internal class Mammal : Animal {
    public bool hasFur;
    public override void GetInfo() {
      Console.WriteLine($"Nickname: {nickname}, Age: {age}, Habitat: {habitat}, Food type: {foodType}, Color: {color}, has Fur: {hasFur}");
    }
    public Mammal(string nickname, int age, string habitat, string foodType, string color, bool hasFur) : base(nickname, age, habitat, foodType, color) {
      this.hasFur = hasFur;
    }
  }
}
