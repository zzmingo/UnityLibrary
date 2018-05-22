using System;
using UnityEngine;

namespace NRPG {

  public abstract class PlayerMovement : MonoBehaviour {

    public bool movementEnabled = true;
    public Vector3 previousPosition;

    void Awake() {

      // set player at entry point if exists
      var entryPoint = GameObject.FindObjectOfType<PlayerEntryPoint>();
      if (entryPoint == null) {
        Debug.LogWarning("Player entry point not found");
      } else {
        setEntryPoint(entryPoint);
      }
      
    }

    void Update() {
      if (movementEnabled) {
        float x = Input.GetAxis ("Horizontal");
        float y = Input.GetAxis ("Vertical");
        previousPosition = transform.position;
        Move(x, y);
      }
    }

    protected abstract void setEntryPoint(PlayerEntryPoint entryPoint);
    
    protected abstract void Move(float x, float y);

  }

}