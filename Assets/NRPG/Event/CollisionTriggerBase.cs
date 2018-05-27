using System;
using UnityEngine;

namespace NRPG {

  public enum TriggerTiming {
    OnEnter,
    OnStay,
    OnExit
  }

  public abstract class CollisionTriggerBase : TriggerBase {

    public TriggerTiming timing = TriggerTiming.OnEnter;

    public abstract bool CanTrigger(Collider2D other);

    void OnTriggerEnter2D(Collider2D other) {
      Debug.Log("ontrigger " + timing + " " + other.tag + " " + NRPGUtils.IsPlayer(other));
      OnTrigger(TriggerTiming.OnEnter, other);
    }

    void OnTriggerStay2D(Collider2D other) {
      OnTrigger(TriggerTiming.OnStay, other);
    }

    void OnTriggerExit2D(Collider2D other) {
      OnTrigger(TriggerTiming.OnExit, other);
    }

    void OnTrigger(TriggerTiming timing, Collider2D other) {
      if (timing != this.timing) {
        return;
      } 
      if (CanTrigger(other)) {
        OnTrigger();
      }
    }
  }

}