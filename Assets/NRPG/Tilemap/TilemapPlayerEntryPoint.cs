using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace NRPG {

  public class TilemapPlayerEntryPoint : PlayerEntryPoint {

    public Tilemap tilemap;

    protected override void setPlayerPositionByEntryPoint(GameObject player, PlayerEntryPoint entryPoint) {
      player.transform.position = tilemap.GetCellCenterWorld(tilemap.WorldToCell(entryPoint.transform.position));
    }

  }

}