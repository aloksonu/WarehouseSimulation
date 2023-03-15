using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public JoystickMovement joystickMovement;
    public float playerSpeed;
    private Rigidbody2D rb;
    void Start()
    {
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
        

        if (other.CompareTag("Receiving"))
        {
            Debug.Log("Item is Received");
            PlayerScore.Instance.UpdateScore();
            UiBgHandeler.Instance.BringIn();
            NarratorTextHandler.Instance.BringInNarrator(NarratorTextHandler.Instance.NReceiving, () =>
            {
                NarratorHandler.Instance.BringIn(NarratorHandler.Instance.spriteReceiving , ()=> {

                    LevelComplete.Instance.BringIn();
                });
            });
           // NarratorHandler.Instance.BringIn(NarratorHandler.Instance.spriteReceiving);
        }

        else if (other.CompareTag("LaserObstacal"))
        {
            
        }

        else if (other.CompareTag("IceSawStaticObstacal"))
        {
            
        }
        else if (other.CompareTag("IceSawMovingObstacal"))
        {
            
        }
        else if (other.CompareTag("DrainHoleObstacal"))
        {
            
        }

        else if (other.CompareTag("LeftBoundary"))
        {
            
        }

        else if (other.CompareTag("RightBoundary"))
        {
           
        }
    }
}
