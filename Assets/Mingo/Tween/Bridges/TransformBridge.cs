using System;
using UnityEngine;

namespace Mingo.Tween {

  public class TransformBridge : Bridge<Transform> {

    private static Vector3 sharedVector3 = new Vector3();

    public override Type SupportedType { get { return typeof(Transform); } }

    public override string[] SupportedKeys { get {
      return new string[] {
        "x", "y", "z", "scaleX", "scaleY", "scaleZ"
      };
    } }

    public override float GetValue(Transform target, string key) {
      switch (key) {
        case "x": return target.position.x;
        case "y": return target.position.y;
        case "z": return target.position.z;
        case "scaleX": return target.localScale.x;
        case "scaleY": return target.localScale.y;
        case "scaleZ": return target.localScale.z;
        default: return 0;
      }
    }

    public override void SetValue(Transform target, string key, float value, float delta) {
      switch (key) {
        case "x": target.Translate(delta, 0, 0); break;
        case "y": target.Translate(0, delta, 0); break;
        case "z": target.Translate(0, 0, delta); break;
        case "scaleX":
          sharedVector3.Set(delta, 0, 0);
          target.localScale += sharedVector3;
          break;
        case "scaleY":
          sharedVector3.Set(delta, 0, 0);
          target.localScale += sharedVector3;
          break;
        case "scaleZ":
          sharedVector3.Set(delta, 0, 0);
          target.localScale += sharedVector3;
          break;
        default: return;
      }
    }

  }

}
