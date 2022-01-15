using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSingleton
{
    //BOTTOM LEFT IS THE 0,0 OF THE GRID AND TOPRIGHT IS THE sizeX,sizeY of the grid!
    public Vector3 bottomLeft;
    public Vector3 topRight;
    public int sizeX;
    public int sizeY;

    public static GridSingleton gridManager;
    public float updateDelayTime = 0.5f;
    public float nextUpdateTime = 0f;
    public float fireFstrength = 5;

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

    public void Init(Vector3 gBottomLeft, Vector3 gTopRight)
    {
        bottomLeft = gBottomLeft;
        topRight = gTopRight;
        sizeX = 19;//valDist((int)gBottomLeft.x, (int)gTopRight.x) + 1;
        sizeY = 22;//valDist((int)gBottomLeft.y, (int)gTopRight.y) + 1;
       
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

    public Vector2 GiveGridPos(Vector3 gPosition)
    {
        return new Vector2((int)gPosition.x - (int)bottomLeft.x, (int)gPosition.y - (int)bottomLeft.y);
    }

    /*
    public static RaycastHit2D GetTileInfo(int x, int y)
    {
        RaycastHit2D hitInfo =  Physics2D.Linecast();
        return hitInfo;
    }
    */
}
