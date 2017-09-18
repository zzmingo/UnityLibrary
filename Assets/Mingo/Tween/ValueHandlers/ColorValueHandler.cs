using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Mingo.Tween {

  public class ColorValueHandler : ValueHandler<Color> {

    public override Type HandleType { get { return typeof(Vector3); } }

    public override Color Plus(Color a, Color b) {
      return a + b;
    }

    public override Color Subtract(Color a, Color b) {
      return a - b;
    }

    public override Color Easing(Color start, Color end, float easingValue) {
      return start + (end - start) * easingValue;
    }
    
  }

}