using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSingleton
{
    int sizeX;
    int sizeY;

    public static GridSingleton gridManager;

    public BaseTile[][] map;

    public int valDist(int v1,int v2)
    {
        if(v1 > v2)
        {
            return Mathf.Abs(v1 - v2);
        }
        else
        {
            return Mathf.Abs(v2 - v1);
        }
    }

    public void Init(Vector3 bottomLeft, Vector3 topRight)
    {
        sizeX = valDist((int)bottomLeft.x, (int)topRight.x);
        sizeY = valDist((int)bottomLeft.z, (int)topRight.z);
        map = new BaseTile[sizeX][];
        for (int currX = 0; currX < sizeX; currX++)
        {
            map[currX] = new BaseTile[sizeY];
            for (int currY = 0; currY < sizeY; currY++)
            {
                map[currX][currY] = new BaseTile();
            }
        }
    }

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
