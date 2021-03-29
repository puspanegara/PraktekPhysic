using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Public Area
    public GameObject winPanel;
    public GameObject losePanel;
    public bool playerWin;
    public bool playerLose;
    public Text uiMoveCount;
    public Text uiStars;
    #endregion

    #region Private Area
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        playerWin = false;
        playerLose = false;
    }

    public void AbleWin()
    {
        winPanel.SetActive(true);
        playerWin = true;
    }

    public void DisableWin()
    {
        winPanel.SetActive(false);
        playerWin = false;
    }

    public void LoseLose()
    {
        losePanel.SetActive(true);
        playerLose = true;
    }
}
