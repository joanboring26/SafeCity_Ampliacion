using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public EquipManager e;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ReturnGame()
    {
        this.gameObject.SetActive(false);
        e.paused = false;
    }
    public void GoMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
