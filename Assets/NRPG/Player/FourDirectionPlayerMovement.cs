using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace NRPG {

  public class FourDirectionPlayerMovement : PlayerMovement {

    public Tilemap tilemap;
    public float speed = 1;

    private float mLastMoveX, mLastMoveY;

    protected override void setEntryPoint(PlayerEntryPoint entryPoint) {
      var entryPos = Vector3Int.FloorToInt(entryPoint.transform.position);
      transform.position = tilemap.GetCellCenterLocal(entryPos);
    }

    protected override void Move(float x, float y) {
      if (x != 0 && y != 0) {
        if (mLastMoveX == 0) {
          mLastMoveY = y;
        } else if (mLastMoveY == 0) {
          mLastMoveX = x;
        }
      } else {
        if (x != 0) {
          x = x > 0 ? 1 : -1;
        }
        if (y != 0) {
          y = y > 0 ? 1 : -1;
        }
        mLastMoveX = x;
        mLastMoveY = y;
      }
      
      var cellSize = tilemap.cellSize;
      var moveDelta = new Vector3(
        mLastMoveX * speed * cellSize.x / 12,
        mLastMoveY * speed * cellSize.y / 12,
        0
      );

      transform.Translate(moveDelta);
    }

  }

}