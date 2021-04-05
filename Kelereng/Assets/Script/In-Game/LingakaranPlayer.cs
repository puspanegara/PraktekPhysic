using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingakaranPlayer : MonoBehaviour
{
    public UIController uiCtrl;
    public bool stay;
    public float timeCheck;
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
                uiCtrl.AbleWin();
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
