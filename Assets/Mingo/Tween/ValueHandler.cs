using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mingo.Tween {

  public interface IValueHandler {
    
    object DoPlus(object a, object b);
    object DoEasing(object start, object end, float easingValue);

  }

  public abstract class ValueHandler<T> : IValueHandler where T : class {

    public object DoPlus(object a, object b) {
      return Plus(a as T, b as T);
    }

    public object DoEasing(object start, object end, float easingValue) {
      return Easing(start as T, end as T, easingValue);
    }

    public abstract T Plus(T a, T b);
    public abstract T Easing(T start, T end, float easingValue);

  }

}