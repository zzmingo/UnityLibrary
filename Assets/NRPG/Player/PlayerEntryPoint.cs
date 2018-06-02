using System;
using UnityEngine;

namespace NRPG {

  public class PlayerEntryPoint : MonoBehaviour {

    void Awake() {
      // set player at entry point if exists
      var entryPoint = GameObject.FindObjectOfType<PlayerEntryPoint>();
      if (entryPoint == null) {
        Debug.LogWarning("Player entry point not found");
      } else {
        setPlayerPositionByEntryPoint(NRPGMananager.shared.GetPlayer(), entryPoint);
      }
      
    }

    protected virtual void setPlayerPositionByEntryPoint(GameObject player, PlayerEntryPoint entryPoint) {
      player.transform.position = entryPoint.transform.position;
    }

  }

}