using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public EquipManager e;
    public string nextLevel;
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

    public void GoNextLevel()
    {
        SceneManager.LoadScene("nextLevel");
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GridSingleton.getRef().fireFstrength = 4;
    }

}
