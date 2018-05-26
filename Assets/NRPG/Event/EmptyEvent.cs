using System;
using UnityEngine;

namespace NRPG {

  public class EmptyEvent : EventBase {

    public override void Process() {
      this.state = EventState.Completed;
    }

  }

}