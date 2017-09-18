using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;

namespace Mingo.Tween {

  public static class TweenTestUtils {

    public static void RandomUpdates(TweenInstance tween, float duration = 1f) {
      var steps = Random.Range(10, 50);
      var delta = duration / steps;
      for(int i=0; i<steps; i++) {
        tween.Update(delta);
      }
      tween.Update(delta);
    }

  }

}