using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Mingo.Tween {

  public static class TweenInstanceExtensions {

    public static TweenInstance QuadIn(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Quadratic.In);
    }

    public static TweenInstance QuadOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Quadratic.Out);
    }
  
    public static TweenInstance QuadInOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Quadratic.InOut);
    }
  
    public static TweenInstance CubicIn(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Cubic.In);
    }

    public static TweenInstance CubicOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Cubic.Out);
    }
  
    public static TweenInstance CubicInOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Cubic.InOut);
    }

    public static TweenInstance QuartIn(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Quartic.In);
    }

    public static TweenInstance QuartOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Quartic.Out);
    }

    public static TweenInstance QuartInOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Quartic.InOut);
    }

    public static TweenInstance QuintIn(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Quintic.In);
    }

    public static TweenInstance QuintOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Quintic.Out);
    }

    public static TweenInstance QuintInOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Quintic.InOut);
    }

    public static TweenInstance SinIn(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Sinusoidal.In);
    }

    public static TweenInstance SinOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Sinusoidal.Out);
    }

    public static TweenInstance SinInOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Sinusoidal.InOut);
    }

    public static TweenInstance ExpIn(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Exponential.In);
    }

    public static TweenInstance ExpOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Exponential.Out);
    }

    public static TweenInstance ExpInOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Exponential.InOut);
    }

    public static TweenInstance CircIn(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Circular.In);
    }
  
    public static TweenInstance CircOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Circular.Out);
    }
  
    public static TweenInstance CircInOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Circular.InOut);
    }
  
    public static TweenInstance ElastIn(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Elastic.In);
    }
  
    public static TweenInstance ElastOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Elastic.Out);
    }
  
    public static TweenInstance ElastInOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Elastic.InOut);
    }
  
    public static TweenInstance BackIn(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Back.In);
    }
  
    public static TweenInstance BackOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Back.Out);
    }
  
    public static TweenInstance BackInOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Back.InOut);
    }
    public static TweenInstance BounceIn(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Bounce.In);
    }
  
    public static TweenInstance BounceOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Bounce.Out);
    }

    public static TweenInstance BounceInOut(this TweenInstance tween, TweenProps properties, float duration=1f) {
      return tween.To(properties, duration).Easing(Easing.Bounce.InOut);
    }

  }

}