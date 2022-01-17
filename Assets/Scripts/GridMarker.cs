using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridMarker : MonoBehaviour
{
    public Transform bottomLeft;
    public Transform topRight;
    public float DebugFFS;
    public float sDebugFFS = 5;
    GridSingleton gridRef;
    public Slider s;
    public GameObject winUI;

    private void Awake()
    {
        gridRef = GridSingleton.getRef();
        gridRef.Init(bottomLeft.position, topRight.position);
        sDebugFFS = gridRef.fireFstrength;


    }
    private void Start()
    {
        s.maxValue = gridRef.fireFstrength;
    }
    private void Update()
    {
        DebugFFS = gridRef.fireFstrength;

        s.value = sDebugFFS - gridRef.fireFstrength;

        if(gridRef.fireFstrength <= 0)
        {
            winUI.SetActive(true);
        }

    }

}
