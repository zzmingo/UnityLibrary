using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Mingo.Tween {

  public static class GameObjectExtensions {

    public static void ClearAllTweens(this GameObject gameObject) {
      foreach(var tween in gameObject.GetComponents<TweenBehaviour>()) {
        GameObject.Destroy(tween);
      }
    }

    public static TweenInstance TweenBy(this GameObject gameObject, params object[] properties) {
      var tween = gameObject.AddComponent<TweenBehaviour>();
      return tween.Instance.By(properties);
    }

    public static TweenInstance TweenBy(this GameObject gameObject, TweenProps properties) {
      var tween = gameObject.AddComponent<TweenBehaviour>();
      return tween.Instance.By(properties);
    }

    public static TweenInstance TweenTo(this GameObject gameObject, params object[] properties) {
      var tween = gameObject.AddComponent<TweenBehaviour>();
      return tween.Instance.To(properties);
    }

    public static TweenInstance TweenTo(this GameObject gameObject, TweenProps properties) {
      var tween = gameObject.AddComponent<TweenBehaviour>();
      return tween.Instance.To(properties);
    }

    public static TweenInstance QuadInTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Quad.In);
    }

    public static TweenInstance QuadOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Quad.Out);
    }
  
    public static TweenInstance QuadInOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Quad.InOut);
    }
  
    public static TweenInstance CubicInTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Cubic.In);
    }

    public static TweenInstance CubicOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Cubic.Out);
    }
  
    public static TweenInstance CubicInOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Cubic.InOut);
    }

    public static TweenInstance QuartInTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Quart.In);
    }

    public static TweenInstance QuartOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Quart.Out);
    }

    public static TweenInstance QuartInOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Quart.InOut);
    }

    public static TweenInstance QuintInTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Quint.In);
    }

    public static TweenInstance QuintOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Quint.Out);
    }

    public static TweenInstance QuintInOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Quint.InOut);
    }

    public static TweenInstance SinInTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Sin.In);
    }

    public static TweenInstance SinOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Sin.Out);
    }

    public static TweenInstance SinInOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Sin.InOut);
    }

    public static TweenInstance ExpInTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Exp.In);
    }

    public static TweenInstance ExpOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Exp.Out);
    }

    public static TweenInstance ExpInOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Exp.InOut);
    }

    public static TweenInstance CircInTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Circ.In);
    }
  
    public static TweenInstance CircOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Circ.Out);
    }
  
    public static TweenInstance CircInOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Circ.InOut);
    }
  
    public static TweenInstance ElastInTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Elast.In);
    }
  
    public static TweenInstance ElastOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Elast.Out);
    }
  
    public static TweenInstance ElastInOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Elast.InOut);
    }
  
    public static TweenInstance BackInTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Back.In);
    }
  
    public static TweenInstance BackOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Back.Out);
    }
  
    public static TweenInstance BackInOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Back.InOut);
    }
    public static TweenInstance BounceInTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Bounce.In);
    }
  
    public static TweenInstance BounceOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Bounce.Out);
    }

    public static TweenInstance BounceInOutTo(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Bounce.InOut);
    }

    public static TweenInstance QuadInBy(this GameObject gameObject, TweenProps properties) {
      return TweenTo(gameObject, properties).Easing(Easing.Quad.In);
    }

    public static TweenInstance QuadOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Quad.Out);
    }
  
    public static TweenInstance QuadInOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Quad.InOut);
    }
  
    public static TweenInstance CubicInBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Cubic.In);
    }

    public static TweenInstance CubicOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Cubic.Out);
    }
  
    public static TweenInstance CubicInOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Cubic.InOut);
    }

    public static TweenInstance QuartInBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Quart.In);
    }

    public static TweenInstance QuartOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Quart.Out);
    }

    public static TweenInstance QuartInOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Quart.InOut);
    }

    public static TweenInstance QuintInBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Quint.In);
    }

    public static TweenInstance QuintOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Quint.Out);
    }

    public static TweenInstance QuintInOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Quint.InOut);
    }

    public static TweenInstance SinInBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Sin.In);
    }

    public static TweenInstance SinOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Sin.Out);
    }

    public static TweenInstance SinInOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Sin.InOut);
    }

    public static TweenInstance ExpInBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Exp.In);
    }

    public static TweenInstance ExpOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Exp.Out);
    }

    public static TweenInstance ExpInOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Exp.InOut);
    }

    public static TweenInstance CircInBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Circ.In);
    }
  
    public static TweenInstance CircOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Circ.Out);
    }
  
    public static TweenInstance CircInOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Circ.InOut);
    }
  
    public static TweenInstance ElastInBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Elast.In);
    }
  
    public static TweenInstance ElastOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Elast.Out);
    }
  
    public static TweenInstance ElastInOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Elast.InOut);
    }
  
    public static TweenInstance BackInBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Back.In);
    }
  
    public static TweenInstance BackOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Back.Out);
    }
  
    public static TweenInstance BackInOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Back.InOut);
    }
    public static TweenInstance BounceInBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Bounce.In);
    }
  
    public static TweenInstance BounceOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Bounce.Out);
    }

    public static TweenInstance BounceInOutBy(this GameObject gameObject, TweenProps properties) {
      return TweenBy(gameObject, properties).Easing(Easing.Bounce.InOut);
    }

  }

}