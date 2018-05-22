using System;
using UnityEngine;

namespace NRPG {

  public class PlayerWallCollisionResolver : MonoBehaviour {

    private bool mShouldAvoidWall = false;
    private PlayerMovement mPlayerMovement;

    void Awake() {
      mPlayerMovement = GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
      mShouldAvoidWall = collider.gameObject.CompareTag("Wall");
    }

    void LateUpdate() {
      if (!mShouldAvoidWall) {
        return;
      }
      mShouldAvoidWall = false;
      
    }

  }

}