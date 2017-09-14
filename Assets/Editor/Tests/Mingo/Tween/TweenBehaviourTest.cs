using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System;

namespace Mingo.Tween {

  public class TweenBehaviourTest {
    
    
    [UnityTest]
    public IEnumerator TestTweenTo() {
      yield return new MonoBehaviourTest<TweenBehaviourTestHelper>();
      Assert.True(true);
    }


    class TweenBehaviourTestHelper : MonoBehaviour, IMonoBehaviourTest {

      public bool IsTestFinished {
        get { return frameCount >= 10; }
      }

      void Awake() {
      }

      private int frameCount = 0;
      void Update() {
        frameCount++;
      }

    }
  }

}