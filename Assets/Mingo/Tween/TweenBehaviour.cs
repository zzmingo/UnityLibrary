using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Mingo.Tween {

  public class TweenBehaviour : MonoBehaviour {

    public TweenInstance Instance { get { return instance; } }
    
    private TweenInstance instance;

    void Awake() {
      instance = new TweenInstance(transform);
    }

    void FixedUpdate() {
      if (!instance.completed && instance.Update(Time.deltaTime)) {
        Destroy(this);
      }
    }

  }

}