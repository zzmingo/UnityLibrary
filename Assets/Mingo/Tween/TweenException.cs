using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Mingo.Tween {

  public class TweenException : UnityException {

    public static TweenException BridgeKeyHasBeenUsed(string key, Type type) {
      return new TweenException(String.Format("This key has been used for the type of {1}: {0}", key, type.FullName));
    }

    public static TweenException InvalidKey(string key, Type type) {
      return new TweenException(String.Format("This key is invalid for the type of {1}: {0}", key, type.FullName));
    }

    public static TweenException NotATweenTarget(Type type) {
      return new TweenException(String.Format("This object is not a tween target: {0}", type.FullName));
    }

    public static TweenException ArgsMustBeEven() {
      return new TweenException("T.p(...) requires an even number of arguments!");
    }

    public TweenException(string message): base(message) {}

  }

}