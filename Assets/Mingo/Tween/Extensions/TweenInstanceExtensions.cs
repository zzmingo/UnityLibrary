using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Mingo.Tween {

  public static class TweenInstanceExtensions {

    public static TweenInstance QuadInTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Quad.In);
    }

    public static TweenInstance QuadOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Quad.Out);
    }
  
    public static TweenInstance QuadInOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Quad.InOut);
    }
  
    public static TweenInstance CubicInTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Cubic.In);
    }

    public static TweenInstance CubicOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Cubic.Out);
    }
  
    public static TweenInstance CubicInOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Cubic.InOut);
    }

    public static TweenInstance QuartInTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Quart.In);
    }

    public static TweenInstance QuartOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Quart.Out);
    }

    public static TweenInstance QuartInOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Quart.InOut);
    }

    public static TweenInstance QuintInTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Quint.In);
    }

    public static TweenInstance QuintOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Quint.Out);
    }

    public static TweenInstance QuintInOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Quint.InOut);
    }

    public static TweenInstance SinInTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Sin.In);
    }

    public static TweenInstance SinOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Sin.Out);
    }

    public static TweenInstance SinInOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Sin.InOut);
    }

    public static TweenInstance ExpInTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Exp.In);
    }

    public static TweenInstance ExpOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Exp.Out);
    }

    public static TweenInstance ExpInOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Exp.InOut);
    }

    public static TweenInstance CircInTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Circ.In);
    }
  
    public static TweenInstance CircOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Circ.Out);
    }
  
    public static TweenInstance CircInOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Circ.InOut);
    }
  
    public static TweenInstance ElastInTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Elast.In);
    }
  
    public static TweenInstance ElastOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Elast.Out);
    }
  
    public static TweenInstance ElastInOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Elast.InOut);
    }
  
    public static TweenInstance BackInTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Back.In);
    }
  
    public static TweenInstance BackOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Back.Out);
    }
  
    public static TweenInstance BackInOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Back.InOut);
    }
    public static TweenInstance BounceInTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Bounce.In);
    }
  
    public static TweenInstance BounceOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Bounce.Out);
    }

    public static TweenInstance BounceInOutTo(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Bounce.InOut);
    }

    public static TweenInstance QuadInBy(this TweenInstance tween, TweenProps properties) {
      return tween.To(properties).Easing(Easing.Quad.In);
    }

    public static TweenInstance QuadOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Quad.Out);
    }
  
    public static TweenInstance QuadInOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Quad.InOut);
    }
  
    public static TweenInstance CubicInBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Cubic.In);
    }

    public static TweenInstance CubicOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Cubic.Out);
    }
  
    public static TweenInstance CubicInOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Cubic.InOut);
    }

    public static TweenInstance QuartInBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Quart.In);
    }

    public static TweenInstance QuartOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Quart.Out);
    }

    public static TweenInstance QuartInOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Quart.InOut);
    }

    public static TweenInstance QuintInBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Quint.In);
    }

    public static TweenInstance QuintOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Quint.Out);
    }

    public static TweenInstance QuintInOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Quint.InOut);
    }

    public static TweenInstance SinInBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Sin.In);
    }

    public static TweenInstance SinOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Sin.Out);
    }

    public static TweenInstance SinInOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Sin.InOut);
    }

    public static TweenInstance ExpInBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Exp.In);
    }

    public static TweenInstance ExpOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Exp.Out);
    }

    public static TweenInstance ExpInOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Exp.InOut);
    }

    public static TweenInstance CircInBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Circ.In);
    }
  
    public static TweenInstance CircOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Circ.Out);
    }
  
    public static TweenInstance CircInOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Circ.InOut);
    }
  
    public static TweenInstance ElastInBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Elast.In);
    }
  
    public static TweenInstance ElastOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Elast.Out);
    }
  
    public static TweenInstance ElastInOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Elast.InOut);
    }
  
    public static TweenInstance BackInBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Back.In);
    }
  
    public static TweenInstance BackOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Back.Out);
    }
  
    public static TweenInstance BackInOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Back.InOut);
    }
    public static TweenInstance BounceInBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Bounce.In);
    }
  
    public static TweenInstance BounceOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Bounce.Out);
    }

    public static TweenInstance BounceInOutBy(this TweenInstance tween, TweenProps properties) {
      return tween.By(properties).Easing(Easing.Bounce.InOut);
    }

  }

}