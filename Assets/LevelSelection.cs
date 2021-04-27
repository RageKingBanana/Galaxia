﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public int scoreRequiredToUnlockNext = -1;
    private int levelReached;
    public Button[] levelButtons;
    public int prevLevelPlayed;
    public int Iskor;
    public double compare;
    public string levelU;
    public char[] levelUc = new char[5];
    void Start()
    {
        NiceFunc();


    }
    private void Update()
    {

    }
    public void NiceFunc()
    {
        // Kunin yung nakastore na data
        levelReached = PlayerPrefs.GetInt("levelReached", 1);
        Iskor = PlayerPrefs.GetInt("iskor");
        levelU = PlayerPrefs.GetString("levelU");

        prevLevelPlayed = PlayerPrefs.GetInt("levelClicked");

        Debug.Log(Iskor);
        Debug.Log(levelU);

        // Pag walang laman yung levelU, defaulter to
        if (levelU == "")
        {
            PlayerPrefs.SetString("levelU", "10000");
            levelU = PlayerPrefs.GetString("levelU");
        }

        //naka string kasi si levelU, need ko nakaarray para mabago yung each character
        levelUc = levelU.ToCharArray(0, levelUc.Length);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
        //compare = PlayerPrefs.GetInt("iskor3");
        //compare = (Iskor + compare) * 0.50;
        // Taga set ng Level to kung unlocked nya na yung next or hindi
        for (int i = 0; i < levelUc.Length; i++)
            if (Iskor > scoreRequiredToUnlockNext && prevLevelPlayed == i)
                levelUc[prevLevelPlayed] = '1';

        string str = new string(levelUc);
        PlayerPrefs.SetString("levelU", str);
        //PlayerPrefs.SetInt("iskor3", 0);
        PlayerPrefs.SetInt("iskor", 0);
        for (int x = 0; x < levelButtons.Length; x++)
        {
            if (levelUc[x] == '1' && x < 5)
                levelButtons[x].interactable = true;
        }

    }
}