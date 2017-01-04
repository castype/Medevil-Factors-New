using UnityEngine;
using System.Collections;

public class AnswerHandler2 : MonoBehaviour
{


    private float delay = 1.5f;
    private float timeRemaining;
    SpriteRenderer spriteRenderer;

    void FixedUpdate()
    {

        if (spriteRenderer.enabled == true  &&  Player_New.Instance.equationNum == 2)
        {

            if (timeRemaining > 0)
            {
                // Reduce the remaining time by time passed since last update (frame)
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = delay;

                {
                    GameObject objr = GameObject.Find("Correct_Right");
                    SpriteRenderer objrsr = objr.GetComponent<SpriteRenderer>();
                    objrsr.enabled = false;

                    GameObject objm = GameObject.Find("Wrong_Middle");
                    SpriteRenderer objmsr = objm.GetComponent<SpriteRenderer>();
                    objmsr.enabled = false;

                    GameObject objl = GameObject.Find("Wrong_Left");
                    SpriteRenderer objlsr = objl.GetComponent<SpriteRenderer>();
                    objlsr.enabled = false;

                    GameObject equation = GameObject.Find("equation2");
                    SpriteRenderer equationsr = equation.GetComponent<SpriteRenderer>();
                    equationsr.enabled = false;

                    GameObject shield2 = GameObject.Find("shield-2");
                    shield2.SetActive(false);

                    GameObject shield16 = GameObject.Find("shield-16");
                    shield16.SetActive(false);

                    GameObject shield4 = GameObject.Find("shield-4");
                    shield4.SetActive(false);

                    Player_New.Instance.equationNum = 3;
                    timeRemaining = delay;
                }

            }
        }
    }

    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        timeRemaining = delay;
    }




}
