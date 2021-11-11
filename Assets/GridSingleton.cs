using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSingleton
{
    public static GridSingleton gridManager;
    public static GridSingleton getRef()
    {
        if(gridManager == null)
        {
            gridManager = new GridSingleton();
            return gridManager;
        }
        return gridManager;
    }



    public static void MovGrid(Transform gTransform, int x, int y)
    {
        gTransform.position = gTransform.position + new Vector3(x, y, 0);
    }

    public static Vector2 GiveGridSnap(Vector2 snapPos)
    {
        return new Vector2(Mathf.Round(snapPos.x), Mathf.Round(snapPos.y));
    }

    /*
    public static RaycastHit2D GetTileInfo(int x, int y)
    {
        RaycastHit2D hitInfo =  Physics2D.Linecast();
        return hitInfo;
    }
    */
}
