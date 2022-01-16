using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public GameObject l;
    public GameObject m;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LevelsButton()
    {
        l.SetActive(true);
        m.SetActive(false);
    }
    public void BackButton()
    {
        l.SetActive(false);
        m.SetActive(true);
    }

    public void ExitButton()
    {

    }
}
