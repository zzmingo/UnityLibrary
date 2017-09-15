using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Mingo.Tween {

  public interface IValueHandler {

    Type HandleType { get; }
    
    object DoPlus(object a, object b);
    object DoSubtract(object a, object b);
    object DoEasing(object start, object end, float easingValue);

  }

  public abstract class ValueHandler<T> : IValueHandler {

    public abstract Type HandleType { get; }

    public virtual object DoPlus(object a, object b) {
      T newA = (T) Convert.ChangeType(a, typeof(T));
      T newB = (T) Convert.ChangeType(b, typeof(T));
      return Plus(newA, newB);
    }

    public virtual object DoSubtract(object a, object b) {
      T newA = (T) Convert.ChangeType(a, typeof(T));
      T newB = (T) Convert.ChangeType(b, typeof(T));
      return Subtract(newA, newB);
    }

    public object DoEasing(object start, object end, float easingValue) {
      T newStart = (T) Convert.ChangeType(start, typeof(T));
      T newEnd = (T) Convert.ChangeType(end, typeof(T));
      return Easing(newStart, newEnd, easingValue);
    }

    public abstract T Plus(T a, T b);
    public abstract T Subtract(T a, T b);
    public abstract T Easing(T start, T end, float easingValue);

  }

}