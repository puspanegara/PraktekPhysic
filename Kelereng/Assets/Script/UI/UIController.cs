using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Public Area
    public GameObject Win3Stars;
    public GameObject Win2Stars;
    public GameObject Win1Stars;
    public GameObject losePanel;
    public GameObject pausePanel;
    public GameObject infoBintang;
    public GameObject[] stars;
    public bool playerWin;
    public bool playerLose;
    public bool openInfo;
    public bool pause;
    public Text uiStars;
    public Text text3Stars;
    public Text text2Stars;
    public Text text1Stars;

    GameManager gm;

    #endregion

    #region Private Area
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Win1Stars.SetActive(false);
        Win2Stars.SetActive(false);
        Win3Stars.SetActive(false);
        losePanel.SetActive(false);
        playerWin = false;
        playerLose = false;
    }
    public void Stars3()
    {
        Win3Stars.SetActive(true);
        playerWin = true;
    }
    public void Stars2()
    {
        Win2Stars.SetActive(true);
        playerWin = true;
    }
    public void Stars1()
    {
        Win1Stars.SetActive(true);
        playerWin = true;
    }
    public void PauseGame()
    {
        pause = true;
        pausePanel.SetActive(true);
    }
    public void ResumeGame()
    {
        pause = false;
        pausePanel.SetActive(false);
    }
    

    public void LoseLose()
    {
        losePanel.SetActive(true);
        playerLose = true;
    }

    public void InfoBintang()
    {
        if(openInfo == false)
        {
            infoBintang.SetActive(true);
            openInfo = true;
        }
        else
        {
            infoBintang.SetActive(false);
            openInfo = false;
        }
    }

}
