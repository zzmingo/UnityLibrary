using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Mingo.Tween {

  public static class GameObjectExtensions {

    public static TweenInstance To(this GameObject gameObject, TweenProps properties, float duration=1f) {
      var tween = gameObject.AddComponent<TweenBehaviour>();
      return tween.Instance.To(properties, duration);
    }

    public static TweenInstance QuadIn(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Quadratic.In);
    }

    public static TweenInstance QuadOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Quadratic.Out);
    }
  
    public static TweenInstance QuadInOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Quadratic.InOut);
    }
  
    public static TweenInstance CubicIn(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Cubic.In);
    }

    public static TweenInstance CubicOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Cubic.Out);
    }
  
    public static TweenInstance CubicInOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Cubic.InOut);
    }

    public static TweenInstance QuartIn(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Quartic.In);
    }

    public static TweenInstance QuartOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Quartic.Out);
    }

    public static TweenInstance QuartInOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Quartic.InOut);
    }

    public static TweenInstance QuintIn(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Quintic.In);
    }

    public static TweenInstance QuintOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Quintic.Out);
    }

    public static TweenInstance QuintInOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Quintic.InOut);
    }

    public static TweenInstance SinIn(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Sinusoidal.In);
    }

    public static TweenInstance SinOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Sinusoidal.Out);
    }

    public static TweenInstance SinInOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Sinusoidal.InOut);
    }

    public static TweenInstance ExpIn(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Exponential.In);
    }

    public static TweenInstance ExpOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Exponential.Out);
    }

    public static TweenInstance ExpInOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Exponential.InOut);
    }

    public static TweenInstance CircIn(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Circular.In);
    }
  
    public static TweenInstance CircOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Circular.Out);
    }
  
    public static TweenInstance CircInOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Circular.InOut);
    }
  
    public static TweenInstance ElastIn(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Elastic.In);
    }
  
    public static TweenInstance ElastOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Elastic.Out);
    }
  
    public static TweenInstance ElastInOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Elastic.InOut);
    }
  
    public static TweenInstance BackIn(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Back.In);
    }
  
    public static TweenInstance BackOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Back.Out);
    }
  
    public static TweenInstance BackInOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Back.InOut);
    }
    public static TweenInstance BounceIn(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Bounce.In);
    }
  
    public static TweenInstance BounceOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Bounce.Out);
    }

    public static TweenInstance BounceInOut(this GameObject gameObject, TweenProps properties, float duration=1f) {
      return To(gameObject, properties, duration).Easing(Easing.Bounce.InOut);
    }

  }

}