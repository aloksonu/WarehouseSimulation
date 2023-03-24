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
        if (joystickMovement.joysticVect.y != 0  && NarrarorSubProcessTextHandeler.Instance.isNarratorOpen==false)
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
        else if (LevelPanel.Instance.levelName == "InventoryManagement")
        {
            foreach (GameObject g in gameObjectsSubProcess)
                g.SetActive(false);
            gameObjectsSubProcess[2].SetActive(true);
        }
        else if (LevelPanel.Instance.levelName == "Picking")
        {
            foreach (GameObject g in gameObjectsSubProcess)
                g.SetActive(false);
            gameObjectsSubProcess[3].SetActive(true);
        }
        else if (LevelPanel.Instance.levelName == "ItemSortation")
        {
            foreach (GameObject g in gameObjectsSubProcess)
                g.SetActive(false);
            gameObjectsSubProcess[4].SetActive(true);
        }
        else if (LevelPanel.Instance.levelName == "Packing")
        {
            foreach (GameObject g in gameObjectsSubProcess)
                g.SetActive(false);
            gameObjectsSubProcess[5].SetActive(true);
        }
        else if (LevelPanel.Instance.levelName == "Despatch")
        {
            foreach (GameObject g in gameObjectsSubProcess)
                g.SetActive(false);
            gameObjectsSubProcess[6].SetActive(true);
        }
    }

    internal void SetPlayerPosition()
    {
        playerInitialPosition = this.gameObject.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        

        if (LevelPanel.Instance.levelName == "Receiving" && subLevelNumber == other.gameObject.GetComponent<SubLevelName>().subLevelNumber)
            {

            other.gameObject.SetActive(false);
            if (subLevelNumber < 8)
                NarrarorSubProcessTextHandeler.Instance.BringInNarrator(NarrarorSubProcessTextHandeler.Instance.NReceiving[subLevelNumber-1]);
            if (subLevelNumber == 8) {

                NarrarorSubProcessTextHandeler.Instance.BringInNarrator(NarrarorSubProcessTextHandeler.Instance.NReceiving[subLevelNumber - 1],()=> {

                    UiBgHandeler.Instance.BringIn();
                    NarratorTextHandler.Instance.BringInNarrator(NarratorTextHandler.Instance.NReceiving, () =>
                    {
                        NarratorHandler.Instance.BringIn(NarratorHandler.Instance.spriteReceiving, () => {

                            LevelComplete.Instance.BringIn();
                        });
                    });

                });
            }
            PlayerScore.Instance.UpdateScore(10);
            subLevelNumber++;
        }
       else if (LevelPanel.Instance.levelName == "Putaway" && subLevelNumber == other.gameObject.GetComponent<SubLevelName>().subLevelNumber)

        {

            other.gameObject.SetActive(false);
            if (subLevelNumber < 3)
                NarrarorSubProcessTextHandeler.Instance.BringInNarrator(NarrarorSubProcessTextHandeler.Instance.NPutaway[subLevelNumber - 1]);
            if (subLevelNumber == 3)
            {

                NarrarorSubProcessTextHandeler.Instance.BringInNarrator(NarrarorSubProcessTextHandeler.Instance.NPutaway[subLevelNumber - 1], () => {

                    UiBgHandeler.Instance.BringIn();
                    NarratorTextHandler.Instance.BringInNarrator(NarratorTextHandler.Instance.NPutaway, () =>
                    {
                        NarratorHandler.Instance.BringIn(NarratorHandler.Instance.spritePutaway, () => {

                            LevelComplete.Instance.BringIn();
                        });
                    });

                });
            }
            PlayerScore.Instance.UpdateScore(10);
            subLevelNumber++;
        }

        else if (LevelPanel.Instance.levelName == "InventoryManagement" && subLevelNumber == other.gameObject.GetComponent<SubLevelName>().subLevelNumber)

        {

            other.gameObject.SetActive(false);
            if (subLevelNumber < 3)
                NarrarorSubProcessTextHandeler.Instance.BringInNarrator(NarrarorSubProcessTextHandeler.Instance.NInventoryManagement[subLevelNumber - 1]);
            if (subLevelNumber == 3)
            {

                NarrarorSubProcessTextHandeler.Instance.BringInNarrator(NarrarorSubProcessTextHandeler.Instance.NInventoryManagement[subLevelNumber - 1], () => {

                    UiBgHandeler.Instance.BringIn();
                    NarratorTextHandler.Instance.BringInNarrator(NarratorTextHandler.Instance.NInventoryManagement, () =>
                    {
                        NarratorHandler.Instance.BringIn(NarratorHandler.Instance.spriteInventoryManagement, () => {

                            LevelComplete.Instance.BringIn();
                        });
                    });

                });
            }
            PlayerScore.Instance.UpdateScore(10);
            subLevelNumber++;
        }

        else if (LevelPanel.Instance.levelName == "Picking" && subLevelNumber == other.gameObject.GetComponent<SubLevelName>().subLevelNumber)

        {

            other.gameObject.SetActive(false);
            if (subLevelNumber < 2)
                NarrarorSubProcessTextHandeler.Instance.BringInNarrator(NarrarorSubProcessTextHandeler.Instance.NPicking[subLevelNumber - 1]);
            if (subLevelNumber == 2)
            {

                NarrarorSubProcessTextHandeler.Instance.BringInNarrator(NarrarorSubProcessTextHandeler.Instance.NPicking[subLevelNumber - 1], () => {

                    UiBgHandeler.Instance.BringIn();
                    NarratorTextHandler.Instance.BringInNarrator(NarratorTextHandler.Instance.NPicking, () =>
                    {
                        NarratorHandler.Instance.BringIn(NarratorHandler.Instance.spritePicking, () => {

                            LevelComplete.Instance.BringIn();
                        });
                    });

                });
            }
            PlayerScore.Instance.UpdateScore(10);
            subLevelNumber++;
        }

        else if (LevelPanel.Instance.levelName == "ItemSortation" && subLevelNumber == other.gameObject.GetComponent<SubLevelName>().subLevelNumber)

        {

            other.gameObject.SetActive(false);
            if (subLevelNumber < 2)
                NarrarorSubProcessTextHandeler.Instance.BringInNarrator(NarrarorSubProcessTextHandeler.Instance.NItemSortation[subLevelNumber - 1]);
            if (subLevelNumber == 2)
            {

                NarrarorSubProcessTextHandeler.Instance.BringInNarrator(NarrarorSubProcessTextHandeler.Instance.NItemSortation[subLevelNumber - 1], () => {

                    UiBgHandeler.Instance.BringIn();
                    NarratorTextHandler.Instance.BringInNarrator(NarratorTextHandler.Instance.NItemSortation, () =>
                    {
                        NarratorHandler.Instance.BringIn(NarratorHandler.Instance.spriteItemSortation, () => {

                            LevelComplete.Instance.BringIn();
                        });
                    });

                });
            }
            PlayerScore.Instance.UpdateScore(10);
            subLevelNumber++;
        }

        else if (LevelPanel.Instance.levelName == "Packing" && subLevelNumber == other.gameObject.GetComponent<SubLevelName>().subLevelNumber)

        {

            other.gameObject.SetActive(false);
            if (subLevelNumber < 1)
                NarrarorSubProcessTextHandeler.Instance.BringInNarrator(NarrarorSubProcessTextHandeler.Instance.NPacking[subLevelNumber - 1]);
            if (subLevelNumber == 1)
            {

                NarrarorSubProcessTextHandeler.Instance.BringInNarrator(NarrarorSubProcessTextHandeler.Instance.NPacking[subLevelNumber - 1], () => {

                    UiBgHandeler.Instance.BringIn();
                    NarratorTextHandler.Instance.BringInNarrator(NarratorTextHandler.Instance.NPacking, () =>
                    {
                        NarratorHandler.Instance.BringIn(NarratorHandler.Instance.spritePacking, () => {

                            LevelComplete.Instance.BringIn();
                        });
                    });

                });
            }
            PlayerScore.Instance.UpdateScore(10);
            subLevelNumber++;
        }

        else if (LevelPanel.Instance.levelName == "Despatch" && subLevelNumber == other.gameObject.GetComponent<SubLevelName>().subLevelNumber)

        {

            other.gameObject.SetActive(false);
            if (subLevelNumber < 3)
                NarrarorSubProcessTextHandeler.Instance.BringInNarrator(NarrarorSubProcessTextHandeler.Instance.NDespatch[subLevelNumber - 1]);
            if (subLevelNumber == 3)
            {

                NarrarorSubProcessTextHandeler.Instance.BringInNarrator(NarrarorSubProcessTextHandeler.Instance.NDespatch[subLevelNumber - 1], () => {

                    UiBgHandeler.Instance.BringIn();
                    NarratorTextHandler.Instance.BringInNarrator(NarratorTextHandler.Instance.NDespatch, () =>
                    {
                        NarratorHandler.Instance.BringIn(NarratorHandler.Instance.spriteDespatch, () => {

                            LevelComplete.Instance.BringIn();
                        });
                    });

                });
            }
            PlayerScore.Instance.UpdateScore(10);
            subLevelNumber++;
        }

        else 
        {
            
        }
    }
}
