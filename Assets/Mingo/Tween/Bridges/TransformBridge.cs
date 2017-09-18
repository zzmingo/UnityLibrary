using System;
using UnityEngine;

namespace Mingo.Tween {

  public class TransformBridge : Bridge<Transform> {

    private static Vector3 sharedVector3 = new Vector3();

    public override Type SupportedType { get { return typeof(Transform); } }

    public override string[] SupportedKeys { get {
      return new string[] {
        "x", "y", "z", "position",
        "scaleX", "scaleY", "scaleZ", "scale",
        "rotationX", "rotationY", "rotationZ", "rotation"
      };
    } }

    public override object GetValue(Transform target, string key) {
      switch (key) {
        case "x": return target.position.x;
        case "y": return target.position.y;
        case "z": return target.position.z;
        case "position": return target.position;
        case "scaleX": return target.localScale.x;
        case "scaleY": return target.localScale.y;
        case "scaleZ": return target.localScale.z;
        case "scale": return target.localScale;
        case "rotationX": return target.eulerAngles.x;
        case "rotationY": return target.eulerAngles.y;
        case "rotationZ": return target.eulerAngles.z;
        case "rotation": return target.eulerAngles;
        default: return 0;
      }
    }

    public override void SetValue(Transform target, string key, object value, object delta) {
      switch (key) {
        case "x": target.Translate((float) delta, 0, 0); break;
        case "y": target.Translate(0, (float) delta, 0); break;
        case "z": target.Translate(0, 0, (float) delta); break;
        case "position": target.position = (Vector3) value; break;
        case "scaleX":
          sharedVector3.Set((float) delta, 0, 0);
          target.localScale += sharedVector3;
          break;
        case "scaleY":
          sharedVector3.Set(0, (float) delta, 0);
          target.localScale += sharedVector3;
          break;
        case "scaleZ":
          sharedVector3.Set(0, 0, (float) delta);
          target.localScale += sharedVector3;
          break;
        case "scale":
          target.localScale = (Vector3) value;
          break;
        case "rotationX": target.Rotate((float) value, 0, 0); break;
        case "rotationY": target.Rotate(0, (float) value, 0); break;
        case "rotationZ": target.Rotate(0, 0, (float) value); break;
        case "rotation": target.eulerAngles = (Vector3) value; break;
        default: return;
      }
    }

  }

}
