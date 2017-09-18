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
        "left", "top", "right", "bottom",
        "width", "height",
        "scaleX", "scaleY"
      };
    } }

    public override object GetValue(RectTransform target, string key) {
      switch (key) {
        case "x": return target.anchoredPosition.x;
        case "y": return target.anchoredPosition.y;
        case "left": return target.offsetMin.x;
        case "bottom": return target.offsetMin.y;
        case "top": return target.offsetMax.y;
        case "right": return target.offsetMax.x;
        case "width": return target.rect.width;
        case "height": return target.rect.height;
        case "scaleX": return target.localScale.x;
        case "scaleY": return target.localScale.y;
        default: return 0;
      }
    }

    public override void SetValue(RectTransform target, string key, object value, object delta) {
      switch (key) {
        case "x":
          sharedVector2.Set((float) value, target.anchoredPosition.y);
          target.anchoredPosition = sharedVector2;
          break;
        case "y":
          sharedVector2.Set(target.anchoredPosition.x, (float) value);
          target.anchoredPosition = sharedVector2;
          break;
        case "left":
          sharedVector2.Set((float) value, target.offsetMin.y);
          target.offsetMin = sharedVector2;
          break;
        case "bottom":
          sharedVector2.Set(target.offsetMin.x, (float) value);
          target.offsetMin = sharedVector2;
          break;
        case "right":
          sharedVector2.Set((float) value, target.offsetMax.y);
          target.offsetMin = sharedVector2;
          break;
        case "top":
          sharedVector2.Set(target.offsetMax.x, (float) value);
          target.offsetMin = sharedVector2;
          break;
        case "width":
          sharedVector2.Set((float) value, target.sizeDelta.y);
          target.sizeDelta = sharedVector2;
          break;
        case "height":
          sharedVector2.Set(target.sizeDelta.x, (float) value);
          target.sizeDelta = sharedVector2;
          break;
        case "scaleX":
          sharedVector3.Set((float) delta, 0, 0);
          target.localScale += sharedVector3;
          break;
        case "scaleY":
          sharedVector3.Set(0, (float) delta, 0);
          target.localScale += sharedVector3;
          break;
        default: return;
      }
    }

  }

}
