using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public JoystickMovement joystickMovement;
    public float playerSpeed;
    private Rigidbody2D rb;
    private int subLevelNumber;
    void Start()
    {
        subLevelNumber = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (joystickMovement.joysticVect.y != 0)
        {
           // Debug.Log("Going Down");
            rb.velocity = new Vector2(joystickMovement.joysticVect.x * playerSpeed, joystickMovement.joysticVect.y * playerSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        

       // if (LevelPanel.Instance.levelName == "Receiving" && subLevelNumber == other.gameObject.GetComponent<SubLevelName>().subLevelNumber)
            if (subLevelNumber == other.gameObject.GetComponent<SubLevelName>().subLevelNumber)
            {

            other.gameObject.SetActive(false);

            if (subLevelNumber == 8) { 

            PlayerScore.Instance.UpdateScore();
            UiBgHandeler.Instance.BringIn();
            NarratorTextHandler.Instance.BringInNarrator(NarratorTextHandler.Instance.NReceiving, () =>
            {
                NarratorHandler.Instance.BringIn(NarratorHandler.Instance.spriteReceiving , ()=> {

                    LevelComplete.Instance.BringIn();
                });
            });

            }
            subLevelNumber++;
        }

        else 
        {
            
        }
    }
}
