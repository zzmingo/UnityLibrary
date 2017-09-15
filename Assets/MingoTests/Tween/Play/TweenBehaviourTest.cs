using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System;

namespace Mingo.Tween {

  public class TweenBehaviourTest {

    GameObject gameObject;
    Transform transform;
    TweenInstance tween;

    [SetUp]
    public void SetUp() {
      gameObject = new GameObject();
      transform = gameObject.transform;
      tween = gameObject.AddComponent<TweenBehaviour>().Instance;
    }

    [TearDown]
    public void TearDown() {
      GameObject.DestroyImmediate(gameObject);
    }
    
    
    [UnityTest]
    public IEnumerator TestTweenTo() {
      tween.To("x", 100, "scaleX", 2);
      yield return tween.WaitForComplete();
      Assert.True(tween.completed);
      Assert.AreEqual(100, transform.position.x);
      Assert.AreEqual(2f, transform.localScale.x);
      yield return 1;
      Assert.AreEqual(null, gameObject.GetComponent<TweenBehaviour>());
    }

    [UnityTest]
    public IEnumerator TestTweenBy() {
      transform.position = new Vector3(0, 50f, 0);
      tween.By("y", 100, "scaleY", 2);
      yield return tween.WaitForComplete();
      Assert.True(tween.completed);
      Assert.AreEqual(150f, transform.position.y);
      Assert.AreEqual(3f, transform.localScale.y);
      yield return 1;
      Assert.AreEqual(null, gameObject.GetComponent<TweenBehaviour>());
    }
  }

}