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
      tween.To("x", 100, "scaleX", 2);
      Assert.True(tween.started);
      Assert.AreEqual(1, tween.duration);
      Assert.AreEqual(0, tween.time);

      bool completed = tween.Update(0.5f);
      Assert.False(completed);
      Assert.AreEqual(0.5f, tween.time);
      Assert.AreEqual(50, transform.position.x);
      Assert.AreEqual(1.5f, transform.localScale.x);

      completed = tween.Update(1f);

      Assert.True(completed);
      Assert.True(tween.completed);
      Assert.AreEqual(100, transform.position.x);
      Assert.AreEqual(2f, transform.localScale.x);
    }

    [Test]
    public void TestTweenBy() {
      gameObject.transform.position = new Vector3(0, 50f, 0);
      var tween = new TweenInstance(gameObject.transform);
      tween.By("y", 100, "scaleY", 2);
      Assert.True(tween.started);
      Assert.AreEqual(1, tween.duration);
      Assert.AreEqual(0, tween.time);

      bool completed = tween.Update(0.5f);
      Assert.False(completed);
      Assert.AreEqual(0.5f, tween.time);
      Assert.AreEqual(100f, transform.position.y);
      Assert.AreEqual(2f, transform.localScale.y);

      completed = tween.Update(1f);

      Assert.True(completed);
      Assert.True(tween.completed);
      Assert.AreEqual(150f, transform.position.y);
      Assert.AreEqual(3f, transform.localScale.y);
    }

  }
}