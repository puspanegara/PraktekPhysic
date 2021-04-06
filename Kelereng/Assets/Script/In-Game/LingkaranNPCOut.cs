using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingkaranNPCOut : MonoBehaviour
{
    public UIController uiCtrl;
    public bool stay;
    public float timeCheck;
    public int coutNPC;
    public GameManager gm;

    void Update()
    {
        Win();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "NPC")
        {
            coutNPC += 1;
            Debug.Log("Marbles in Circle : " + coutNPC);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            coutNPC -= 1;
            Debug.Log("Marbles in Circle : " + coutNPC);
        }
    }
    public void Win()
    {
        if (coutNPC == 0)
        {
            if (timeCheck > 0)
            {
                timeCheck -= Time.deltaTime;
                Debug.Log("Out Circle : " + timeCheck);
            }
            else
            {
                if (gm.moveCount == gm.move3Stars)
                {
                    stay = true;
                    uiCtrl.Stars3();
                }
                else if (gm.moveCount == gm.move2Stars)
                {
                    stay = true;
                    uiCtrl.Stars2();
                }
                else if (gm.moveCount == gm.move1Stars)
                {
                    stay = true;
                    uiCtrl.Stars1();
                }
            }
        }
    }
}
