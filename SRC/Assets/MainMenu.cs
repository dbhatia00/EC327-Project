﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene"); //Full_Stage is spealt wrong
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
