using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LingakaranPlayer : MonoBehaviour
{
    public UIController uiCtrl;
    public bool stay;
    public float timeCheck;
    public GameManager gm;
    public int levelIndex;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(timeCheck > 0)
            {
                timeCheck -= Time.deltaTime;
                Debug.Log("Time left : " + timeCheck);
            }
            else 
            {
                stay = true;
                if (stay == true)
                {
                    if(gm.moveCount <= gm.move3Stars)
                    {
                        gm.starsNum = 3;
                        uiCtrl.Stars3();
                        Debug.Log(gm.starsNum);
                    }
                    if (gm.moveCount == gm.move2Stars)
                    {
                        gm.starsNum = 2;
                        uiCtrl.Stars2();
                        Debug.Log(gm.starsNum);
                    }
                    if(gm.moveCount >= gm.move1Stars)
                    {
                        gm.starsNum = 1;
                        uiCtrl.Stars1();
                        Debug.Log(gm.starsNum);
                    }
                    gm.currentStarsNum = gm.starsNum;

                    if (gm.currentStarsNum > PlayerPrefs.GetInt("Lv" + levelIndex))
                    {
                        PlayerPrefs.SetInt("Lv" + levelIndex, gm.starsNum);
                    }

                    Debug.Log("Current Stars: " + PlayerPrefs.GetInt("Lv" + levelIndex, gm.starsNum));
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            timeCheck = 5f;
            Debug.Log("Out Circle : " + timeCheck);
        }
    }

}
