using System;
using UnityEngine;

namespace NRPG {

  public class PlayerCollisionTrigger : CollisionTriggerBase {

    override public bool CanTrigger(Collider2D other) {
      return NRPGUtils.IsPlayer(other);
    }

  }

}