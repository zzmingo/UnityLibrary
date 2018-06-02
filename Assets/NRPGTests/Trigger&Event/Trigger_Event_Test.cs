using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System;

namespace NRPG {

  public class Trigger_Event_Test {

    GameObject gameObject;

    [SetUp]
    public void SetUp() {
      gameObject = new GameObject();
    }

    [TearDown]
    public void TearDown() {
      GameObject.DestroyImmediate(gameObject);
    }

    [Test]
    public void TestProperties() {
      var trigger = gameObject.AddComponent<TestSupportTrigger>();
      var aEvent = gameObject.AddComponent<EmptyEvent>();
      trigger.OnTrigger();
      Assert.AreEqual(aEvent.state, EventState.Completed);
    }

  }

}