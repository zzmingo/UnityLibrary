using System;
using UnityEngine;

namespace NRPG {

  [RequireComponent(typeof(CharacterComponent))]
  public class CharacterMovement : MonoBehaviour {

    public bool movementEnabled = true;
    public float speed = 1;

    private CharacterComponent mCharacter;
    private Vector3 mMoveAxis = Vector3.zero;

    public void setMovingAxis(float x, float y) {
      mMoveAxis.x = x;
      mMoveAxis.y = y;
      mMoveAxis.Normalize();
    }

    void Awake() {
      mCharacter = GetComponent<CharacterComponent>();
    }

    void Update() {
      if (movementEnabled) {
        if (mMoveAxis.x == 0 && mMoveAxis.y == 0) {
          mCharacter.walking = false;
          return;
        }

        mCharacter.walking = true;

        if (Math.Abs(mMoveAxis.x) > Math.Abs(mMoveAxis.y)) {
          if (mMoveAxis.x > 0) {
            mCharacter.direction = CharacterMovingDirection.Right;
          } else {
            mCharacter.direction = CharacterMovingDirection.Left;
          }
        } else {
          if (mMoveAxis.y > 0) {
            mCharacter.direction = CharacterMovingDirection.Up;
          } else {
            mCharacter.direction = CharacterMovingDirection.Down;
          }
        }

        Vector3 moveDelta = mMoveAxis * speed / 50;
        transform.Translate(moveDelta);
      }
    }

  }
}