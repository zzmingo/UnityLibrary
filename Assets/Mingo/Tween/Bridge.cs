using System;
using UnityEngine;

namespace Mingo.Tween {

  public interface IBridge {

    Type SupportedType { get; }
    string[] SupportedKeys { get; }

    float GetValueFrom(object target, string key);
    void SetValueTo(object target, string key, float value, float delta);

  }

  public abstract class Bridge<T> : IBridge where T : class {

    public abstract Type SupportedType { get; }
   public abstract string[] SupportedKeys { get; }

    public float GetValueFrom(object target, string key) {
      return GetValue(target as T, key);
    }

    public void SetValueTo(object target, string key, float value, float delta) {
      SetValue(target as T, key, value, delta);
    }

    public abstract float GetValue(T target, string key);
    public abstract void SetValue(T target, string key, float value, float delta);

  }

}