using System;
using UnityEngine;

namespace Mingo.Tween {

  public class UIColorBridge : Bridge<RectTransform> {

    public override Type SupportedType { get { return typeof(RectTransform); } }

    public override string[] SupportedKeys { get {
      return new string[] {
        "color",
        "alpha"
      };
    } }

    public override object GetValue(RectTransform target, string key) {
      var renderer = target.GetComponent<CanvasRenderer>();
      switch (key) {
        case "color": return renderer.GetColor();
        case "alpha": return renderer.GetAlpha();
        default: return 0;
      }
    }

    public override void SetValue(RectTransform target, string key, object value, object delta) {
      var renderer = target.GetComponent<CanvasRenderer>();
      switch (key) {
        case "color": renderer.SetColor((Color) value); break;
        case "alpha": renderer.SetAlpha((float) value); break;
        default: return;
      }
    }

  }

}
