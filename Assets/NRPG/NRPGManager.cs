using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace NRPG {

  public class NRPGMananager {

    public static readonly NRPGMananager shared = new NRPGMananager();

    public GameObject GetPlayer() {
      return GameObject.FindWithTag(NRPGSettings.playerTagName);
    }

  }

}