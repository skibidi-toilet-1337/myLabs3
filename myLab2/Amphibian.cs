using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myLab2 {
  internal class Amphibian : Animal {
    public int skinMoisture;
    public override void GetInfo() {
      Console.WriteLine($"Nickname: {nickname}, Age: {age}, Habitat: {habitat}, Food type: {foodType}, Color: {color}, Skin moisture: {skinMoisture}");
    }
    public Amphibian(string nickname, int age, string habitat, string foodType, string color, int skinMoisture) : base(nickname, age, habitat, foodType, color) { 
      this.skinMoisture = skinMoisture;
    }
  }
}