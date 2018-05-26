using System;
using UnityEngine;

namespace NRPG {

  public enum EventState {
    Ready,
    Processing,
    Completed,
  }

  public abstract class EventBase : MonoBehaviour {

    [HideInInspector]
    public EventState state;

    public bool CanProcess() {
      return true;
    }

    public abstract void Process();
  }

}