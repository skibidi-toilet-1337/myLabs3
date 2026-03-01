using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myLab2 {
  internal class Bird : Animal {
    public float wingSpan;
    public override void GetInfo() {
      Console.WriteLine($"Nickname: {nickname}, Age: {age}, Habitat: {habitat}, Food type: {foodType}, Color: {color}, Wing span: {wingSpan}");
    }
    public Bird(string nickname, int age, string habitat, string foodType, string color, float wingSpan) : base(nickname, age, habitat, foodType, color) {
      this.wingSpan = wingSpan;
    }
  }
}
