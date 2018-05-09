using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {

    int canTeleport = 0;
    int attempts;
    int trophyReq;
    int trophyCount;
    string lastKey;
    bool spedUp = false;

    Renderer myRenderer;
    LevelControl levelControl;
    Vector2 startingPos;
    Rigidbody2D myRigidbody;
    SpriteRenderer redSquare; 
    float redValue = 1;
    float blueValue = 0;
    float greenValue = 0;

    float startingSpeed = 0.5f;
    float maxSpeed = 2.0f;
    float ratioSpeed = 0f;
    float accel = 0.2f;
    [SerializeField] float currentSpeed;

    void Start () {

        levelControl = FindObjectOfType<LevelControl>();
        startingSpeed = levelControl.StartingSpeed;
        maxSpeed = levelControl.MaxSpeed;
        trophyReq = levelControl.TrophyReq;
        currentSpeed = startingSpeed;
        myRigidbody = GetComponent<Rigidbody2D>();
        redSquare = GetComponent<SpriteRenderer>();
        myRenderer = GetComponent<Renderer>();
        StartCoroutine(RenderDelay());
    }


    IEnumerator RenderDelay()
    {
        yield return new WaitForSeconds(0.25f);
        while (true)
        {
            if (!myRenderer.isVisible)
            {
                Debug.Log("It's Gone, Son");
            }
            yield return null;
        }
    }
       

    void Update () {

        SpeedSet();
        SpeedChange();

        ratioSpeed = (1 / (maxSpeed - startingSpeed)) * (currentSpeed - startingSpeed);
        redValue = (1 - ratioSpeed);                                           
        blueValue = ratioSpeed;
        redSquare.color = new Color(redValue, greenValue, blueValue);        //Blue Shift
    }    //End update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SlowBlock")
        {
            SlowBlock slowBlock = collision.GetComponent<SlowBlock>();
            currentSpeed -= slowBlock.SlowValue;
            SpeedChange();
        }
        if (collision.gameObject.tag == "SpeedBlock")
        {
            SpeedBlock speedBlock = collision.GetComponent<SpeedBlock>();
            currentSpeed += speedBlock.SpeedValue;
            SpeedChange();
        }
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Hit Wall");
            levelControl.LoseLevel();
        }
        if (collision.gameObject.tag == "Trophy")
        {
            Debug.Log("GG");
            trophyCount++;
            Destroy(collision.gameObject);
            if (trophyCount < trophyReq ) {
                Debug.Log(trophyCount);
            }else
            {
                levelControl.WinLevel();
            }
        }
        if (collision.gameObject.tag == "TeleBlock" && canTeleport == 0)
        {
            canTeleport += 2;
            TeleBlock teleBlock = collision.GetComponent<TeleBlock>();
            gameObject.transform.position = teleBlock.Teleport.position;
        }
        if (collision.gameObject.tag == "TriggerBlock")
        {
            TriggerBlock triggerBlock = collision.GetComponent<TriggerBlock>();
            for (int i = 0; i < triggerBlock.toMove.Length; i++)
            {
                if (triggerBlock.toMove[i].GetComponent<Wall>().Moving)
                {
                    triggerBlock.toMove[i].GetComponent<Wall>().Moving = false;
                }
                else
                {
                    triggerBlock.toMove[i].GetComponent<Wall>().Moving = true;
                }
            }
        }

        if (currentSpeed < startingSpeed) { currentSpeed = startingSpeed; } //speed cap and minimim
    if (currentSpeed > maxSpeed) { currentSpeed = maxSpeed;  }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TeleBlock") { canTeleport--; }
    }

    private void SpeedSet ()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentSpeed <= maxSpeed) { currentSpeed += accel; }
            lastKey = "A";
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentSpeed <= maxSpeed) { currentSpeed += accel; }
            lastKey = "D";
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentSpeed <= maxSpeed) { currentSpeed += accel; }
            lastKey = "W";
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentSpeed <= maxSpeed) { currentSpeed += accel; }
            lastKey = "S";
        }
        spedUp = true;
    }
    private void SpeedChange ()
    {
        if (spedUp)
        {

            if (lastKey == "A")
            {
                myRigidbody.velocity = new Vector2(currentSpeed * -1, 0);
            }

            if (lastKey == "D")
            {
                myRigidbody.velocity = new Vector2(currentSpeed, 0);
            }

            if (lastKey == "W")
            {
                myRigidbody.velocity = new Vector2(0, currentSpeed);
            }

            if (lastKey == "S")
            {
                myRigidbody.velocity = new Vector2(0, currentSpeed * -1);
            }
            spedUp = false;
        }
    }
   
} //the End
