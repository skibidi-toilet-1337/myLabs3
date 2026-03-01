using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myLab2 {
  internal class Fish : Animal {
    public string waterType;
    public override void GetInfo() {
      Console.WriteLine($"Nickname: {nickname}, Age: {age}, Habitat: {habitat}, Food type: {foodType}, Color: {color}, Water type: {waterType}");
    }
    public Fish(string nickname, int age, string habitat, string foodType, string color, string waterType) : base(nickname, age, habitat, foodType, color) {
      this.waterType = waterType;
    }
  }
}
