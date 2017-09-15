using System;
using UnityEngine;

namespace Mingo.Tween {

  public class RectTransformBridge : Bridge<RectTransform> {

    private static Vector2 sharedVector2 = new Vector2();
    private static Vector3 sharedVector3 = new Vector3();

    public override Type SupportedType { get { return typeof(RectTransform); } }

    public override string[] SupportedKeys { get {
      return new string[] {
        "x", "y", 
        "scaleX", "scaleY"
      };
    } }

    public override float GetValue(RectTransform target, string key) {
      switch (key) {
        case "x": return target.anchoredPosition.x;
        case "y": return target.anchoredPosition.y;
        case "scaleX": return target.localScale.x;
        case "scaleY": return target.localScale.y;
        default: return 0;
      }
    }

    public override void SetValue(RectTransform target, string key, float value, float delta) {
      switch (key) {
        case "x":
          sharedVector2.Set(value, target.anchoredPosition.y);
          target.anchoredPosition = sharedVector2;
          break;
        case "y":
          sharedVector2.Set(target.anchoredPosition.x, value);
          target.anchoredPosition = sharedVector2;
          break;
        case "scaleX":
          sharedVector3.Set(delta, 0, 0);
          target.localScale += sharedVector3;
          break;
        case "scaleY":
          sharedVector3.Set(0, delta, 0);
          target.localScale += sharedVector3;
          break;
        default: return;
      }
    }

  }

}
