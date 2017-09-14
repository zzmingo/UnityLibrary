using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System;

namespace Mingo.Tween {

  public class TweenInstanceTest {

    GameObject gameObject;
    Transform transform;

    [SetUp]
    public void SetUp() {
      TweenManager.CheckInit();
      gameObject = new GameObject();
      transform = gameObject.transform;
    }

    [TearDown]
    public void TearDown() {
      GameObject.DestroyImmediate(gameObject);
    }


    [Test]
    public void TestTweenTo() {
      var tween = new TweenInstance(gameObject.transform);
      tween.To(TN.p("x", 100, "scaleX", 2), 1);
      Assert.True(tween.Started);
      Assert.AreEqual(tween.Duration, 1);
      Assert.AreEqual(tween.Time, 0);

      bool completed = tween.Update(0.5f);
      Assert.False(completed);
      Assert.AreEqual(tween.Time, 0.5f);
      Assert.AreEqual(transform.position.x, 50);

      completed = tween.Update(1f);

      Assert.True(completed);
      Assert.True(tween.Completed);
      Assert.AreEqual(transform.position.x, 100);
    }

  }
}