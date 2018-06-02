using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace NRPG {

  [RequireComponent(typeof(CharacterMovement))]
  public class PlayerController : MonoBehaviour {

    private CharacterMovement mMovement;

    void Awake() {
      mMovement = GetComponent<CharacterMovement>();
    }

    void FixedUpdate() {
      float x = Input.GetAxis ("Horizontal");
      float y = Input.GetAxis ("Vertical");
      mMovement.setMovingAxis(x, y);
    }

  }

}