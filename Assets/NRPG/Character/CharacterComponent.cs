using UnityEngine;

namespace NRPG {

  public class CharacterComponent : MonoBehaviour {

    public CharacterMovingDirection direction = CharacterMovingDirection.Down;
    public bool walking = false; 

    private Animator mAnimator;

    void Awake() {
      mAnimator = GetComponent<Animator>();
    }

    void Update() {
      if (walking != mAnimator.GetBool("walking")) {
        mAnimator.SetBool("walking", walking);
      }
      int direction = this.direction.Value();
      if (direction != mAnimator.GetInteger("direction")) {
        mAnimator.SetInteger("direction", direction);
      }
    }

  }

}