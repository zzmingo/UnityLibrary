using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Mingo.Tween {

  public static class TransformExtensions {
    
    public static void ClearAllTweens(this Transform transform) {
      foreach(var tween in transform.gameObject.GetComponents<TweenBehaviour>()) {
        GameObject.Destroy(tween);
      }
    }

    public static TweenInstance TweenBy(this Transform transform, params object[] properties) {
      var tween = transform.gameObject.AddComponent<TweenBehaviour>();
      return tween.Instance.By(properties);
    }

    public static TweenInstance TweenBy(this Transform transform, TweenProps properties) {
      var tween = transform.gameObject.AddComponent<TweenBehaviour>();
      return tween.Instance.By(properties);
    }

    public static TweenInstance TweenTo(this Transform transform, params object[] properties) {
      var tween = transform.gameObject.AddComponent<TweenBehaviour>();
      return tween.Instance.To(properties);
    }

    public static TweenInstance TweenTo(this Transform transform, TweenProps properties) {
      var tween = transform.gameObject.AddComponent<TweenBehaviour>();
      return tween.Instance.To(properties);
    }

    public static TweenInstance QuadInTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Quad.In);
    }

    public static TweenInstance QuadOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Quad.Out);
    }
  
    public static TweenInstance QuadInOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Quad.InOut);
    }
  
    public static TweenInstance CubicInTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Cubic.In);
    }

    public static TweenInstance CubicOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Cubic.Out);
    }
  
    public static TweenInstance CubicInOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Cubic.InOut);
    }

    public static TweenInstance QuartInTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Quart.In);
    }

    public static TweenInstance QuartOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Quart.Out);
    }

    public static TweenInstance QuartInOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Quart.InOut);
    }

    public static TweenInstance QuintInTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Quint.In);
    }

    public static TweenInstance QuintOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Quint.Out);
    }

    public static TweenInstance QuintInOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Quint.InOut);
    }

    public static TweenInstance SinInTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Sin.In);
    }

    public static TweenInstance SinOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Sin.Out);
    }

    public static TweenInstance SinInOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Sin.InOut);
    }

    public static TweenInstance ExpInTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Exp.In);
    }

    public static TweenInstance ExpOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Exp.Out);
    }

    public static TweenInstance ExpInOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Exp.InOut);
    }

    public static TweenInstance CircInTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Circ.In);
    }
  
    public static TweenInstance CircOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Circ.Out);
    }
  
    public static TweenInstance CircInOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Circ.InOut);
    }
  
    public static TweenInstance ElastInTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Elast.In);
    }
  
    public static TweenInstance ElastOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Elast.Out);
    }
  
    public static TweenInstance ElastInOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Elast.InOut);
    }
  
    public static TweenInstance BackInTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Back.In);
    }
  
    public static TweenInstance BackOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Back.Out);
    }
  
    public static TweenInstance BackInOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Back.InOut);
    }
    public static TweenInstance BounceInTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Bounce.In);
    }
  
    public static TweenInstance BounceOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Bounce.Out);
    }

    public static TweenInstance BounceInOutTo(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Bounce.InOut);
    }

    public static TweenInstance QuadInBy(this Transform transform, TweenProps properties) {
      return TweenTo(transform, properties).Easing(Easing.Quad.In);
    }

    public static TweenInstance QuadOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Quad.Out);
    }
  
    public static TweenInstance QuadInOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Quad.InOut);
    }
  
    public static TweenInstance CubicInBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Cubic.In);
    }

    public static TweenInstance CubicOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Cubic.Out);
    }
  
    public static TweenInstance CubicInOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Cubic.InOut);
    }

    public static TweenInstance QuartInBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Quart.In);
    }

    public static TweenInstance QuartOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Quart.Out);
    }

    public static TweenInstance QuartInOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Quart.InOut);
    }

    public static TweenInstance QuintInBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Quint.In);
    }

    public static TweenInstance QuintOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Quint.Out);
    }

    public static TweenInstance QuintInOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Quint.InOut);
    }

    public static TweenInstance SinInBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Sin.In);
    }

    public static TweenInstance SinOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Sin.Out);
    }

    public static TweenInstance SinInOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Sin.InOut);
    }

    public static TweenInstance ExpInBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Exp.In);
    }

    public static TweenInstance ExpOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Exp.Out);
    }

    public static TweenInstance ExpInOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Exp.InOut);
    }

    public static TweenInstance CircInBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Circ.In);
    }
  
    public static TweenInstance CircOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Circ.Out);
    }
  
    public static TweenInstance CircInOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Circ.InOut);
    }
  
    public static TweenInstance ElastInBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Elast.In);
    }
  
    public static TweenInstance ElastOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Elast.Out);
    }
  
    public static TweenInstance ElastInOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Elast.InOut);
    }
  
    public static TweenInstance BackInBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Back.In);
    }
  
    public static TweenInstance BackOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Back.Out);
    }
  
    public static TweenInstance BackInOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Back.InOut);
    }
    public static TweenInstance BounceInBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Bounce.In);
    }
  
    public static TweenInstance BounceOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Bounce.Out);
    }

    public static TweenInstance BounceInOutBy(this Transform transform, TweenProps properties) {
      return TweenBy(transform, properties).Easing(Easing.Bounce.InOut);
    }

  }

}