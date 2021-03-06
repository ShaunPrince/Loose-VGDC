﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public GameObject gameOverPanel;

    private Text gameOverText;
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText = gameOverPanel.transform.GetChild(0).GetComponent<Text>();
        gameOverPanel.SetActive(false);
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseGame()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameObject.Find("Main Camera").transform.parent = null;
        gameOverPanel.SetActive(true);
        gameOverText.text = "You Lose\nScore: " + levelManager.score.ToString();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        UnityEngine.Application.Quit();
    }
}
