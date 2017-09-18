using System;
using UnityEngine;

namespace Mingo.Tween {

  public class ColorBridge : Bridge<Transform> {

    public override Type SupportedType { get { return typeof(Transform); } }

    public override string[] SupportedKeys { get {
      return new string[] {
        "color",
        "alpha"
      };
    } }

    public override object GetValue(Transform target, string key) {
      var renderer = target.GetComponent<Renderer>();
      switch (key) {
        case "color": return renderer.material.color;
        case "alpha": return renderer.material.color.a;
        default: return 0;
      }
    }

    public override void SetValue(Transform target, string key, object value, object delta) {
      var renderer = target.GetComponent<Renderer>();
      switch (key) {
        case "color": renderer.material.color = (Color) value; break;
        case "alpha":
          Color color = renderer.material.color;
          color.a = (float) value;
          renderer.material.color = color;
          break;
        default: return;
      }
    }

  }

}
