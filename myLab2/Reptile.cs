using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myLab2 {
  internal class Reptile : Animal {
    public bool isVenomous;
    public override void GetInfo() {
      Console.WriteLine($"Nickname: {nickname}, Age: {age}, Habitat: {habitat}, Food type: {foodType}, Color: {color}, is Venomous: {isVenomous}");
    }
    public Reptile(string nickname, int age, string habitat, string foodType, string color, bool isVenomous) : base(nickname, age, habitat, foodType, color) {
      this.isVenomous = isVenomous;
    }
  }
}
