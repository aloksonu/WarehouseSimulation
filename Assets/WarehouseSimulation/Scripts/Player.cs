using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Player : MonoSingleton<Player>
{
    public JoystickMovement joystickMovement;
    public float playerSpeed;
    private Rigidbody2D rb;
    private int subLevelNumber;
    private Vector2 playerInitialPosition;
    [SerializeField] private GameObject[] gameObjectsSubProcess;
    void Start()
    {
       // LevelPanel.Instance.levelName = "Receiving";  // testin purpose later removed
        subLevelNumber = 1;
        SetLevel();
        SetPlayerPosition();
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

    internal void SetLevel()
    {
        if (LevelPanel.Instance.levelName == "Receiving")
        {
            foreach (GameObject g in gameObjectsSubProcess)
                g.SetActive(false);
            gameObjectsSubProcess[0].SetActive(true);
        }
        else if (LevelPanel.Instance.levelName == "Putaway")
        {
            foreach (GameObject g in gameObjectsSubProcess)
                g.SetActive(false);
            gameObjectsSubProcess[1].SetActive(true);
        }
    }

    internal void SetPlayerPosition()
    {
        playerInitialPosition = this.gameObject.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        

        if (LevelPanel.Instance.levelName == "Receiving" && subLevelNumber == other.gameObject.GetComponent<SubLevelName>().subLevelNumber)
          //  if (subLevelNumber == other.gameObject.GetComponent<SubLevelName>().subLevelNumber)
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
       else if (LevelPanel.Instance.levelName == "Putaway" && subLevelNumber == other.gameObject.GetComponent<SubLevelName>().subLevelNumber)

        {

            other.gameObject.SetActive(false);

            if (subLevelNumber == 3)
            {

                PlayerScore.Instance.UpdateScore();
                UiBgHandeler.Instance.BringIn();
                NarratorTextHandler.Instance.BringInNarrator(NarratorTextHandler.Instance.NPutaway, () =>
                {
                    NarratorHandler.Instance.BringIn(NarratorHandler.Instance.spritePutaway, () => {

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
