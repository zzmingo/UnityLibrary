using UnityEngine;

namespace NRPG {

  public class NRPGUtils {

    public static bool IsPlayer(GameObject test) {
      return test != null && test.CompareTag("Player");
    }

    public static bool IsPlayer(Behaviour test) {
      return test != null && test.CompareTag("Player");
    }

    public static bool IsDestroyed(Object test) {
      return test == null || test.Equals(null);
    }

  }

}