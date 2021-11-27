using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMarker : MonoBehaviour
{
    public Transform bottomLeft;
    public Transform topRight;

    GridSingleton gridRef;

    private void Awake()
    {
        gridRef = GridSingleton.getRef();
        gridRef.Init(bottomLeft.position, topRight.position);
    }

}
