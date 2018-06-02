namespace NRPG {

  public enum CharacterMovingDirection {
    Up = 1, Down = 2, Left = 3, Right = 4
  }

  public static class CharacterMovingDirectionMethods {

    public static int Value(this CharacterMovingDirection direction) {
      return (int) direction;
    }

  }

}