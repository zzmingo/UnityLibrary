using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Mingo.Tween {

  public static class TransformExtensions {

    public static TweenInstance To(this Transform transform, TweenProps properties, float duration=1f) {
      var tween = transform.gameObject.AddComponent<TweenBehaviour>();
      return tween.Instance.To(properties, duration);
    }

    public static TweenInstance QuadIn(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Quadratic.In);
    }

    public static TweenInstance QuadOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Quadratic.Out);
    }
  
    public static TweenInstance QuadInOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Quadratic.InOut);
    }
  
    public static TweenInstance CubicIn(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Cubic.In);
    }

    public static TweenInstance CubicOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Cubic.Out);
    }
  
    public static TweenInstance CubicInOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Cubic.InOut);
    }

    public static TweenInstance QuartIn(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Quartic.In);
    }

    public static TweenInstance QuartOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Quartic.Out);
    }

    public static TweenInstance QuartInOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Quartic.InOut);
    }

    public static TweenInstance QuintIn(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Quintic.In);
    }

    public static TweenInstance QuintOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Quintic.Out);
    }

    public static TweenInstance QuintInOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Quintic.InOut);
    }

    public static TweenInstance SinIn(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Sinusoidal.In);
    }

    public static TweenInstance SinOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Sinusoidal.Out);
    }

    public static TweenInstance SinInOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Sinusoidal.InOut);
    }

    public static TweenInstance ExpIn(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Exponential.In);
    }

    public static TweenInstance ExpOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Exponential.Out);
    }

    public static TweenInstance ExpInOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Exponential.InOut);
    }

    public static TweenInstance CircIn(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Circular.In);
    }
  
    public static TweenInstance CircOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Circular.Out);
    }
  
    public static TweenInstance CircInOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Circular.InOut);
    }
  
    public static TweenInstance ElastIn(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Elastic.In);
    }
  
    public static TweenInstance ElastOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Elastic.Out);
    }
  
    public static TweenInstance ElastInOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Elastic.InOut);
    }
  
    public static TweenInstance BackIn(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Back.In);
    }
  
    public static TweenInstance BackOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Back.Out);
    }
  
    public static TweenInstance BackInOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Back.InOut);
    }
    public static TweenInstance BounceIn(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Bounce.In);
    }
  
    public static TweenInstance BounceOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Bounce.Out);
    }

    public static TweenInstance BounceInOut(this Transform transform, TweenProps properties, float duration=1f) {
      return To(transform, properties, duration).Easing(Easing.Bounce.InOut);
    }

  }

}