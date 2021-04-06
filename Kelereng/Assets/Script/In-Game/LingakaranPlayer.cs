using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingakaranPlayer : MonoBehaviour
{
    public UIController uiCtrl;
    public bool stay;
    public float timeCheck;
    public GameManager gm;
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
                if (gm.moveCount == gm.move3Stars)
                {
                    uiCtrl.Stars3();
                }
                else if (gm.moveCount == gm.move2Stars)
                {
                    uiCtrl.Stars2();
                }
                else if (gm.moveCount == gm.move1Stars)
                {
                    uiCtrl.Stars1();
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
