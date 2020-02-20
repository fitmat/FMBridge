using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{

    public LevelManager levelmanager;
    public Camera myCam;
    private Rigidbody2D player;
    private float maxWidth;
    private bool cancontrol = true;
    public Animator animator;

    float PlayerXLimit;
    float PlayerSingleDisplacement;
    float CameraXpos;
    float PlayerStartPosition;
   
    //string textstring = "Null";
    //string previousString = "Null";

    //variable to hold a reference to our SpriteRenderer component
    //private SpriteRenderer mySpriteRenderer;


    string FMResponseCount = "";


    private bool IsFacingRight;


    void Awake()
    {
        InitBLE.InitBLEFramework("54:6C:0E:20:A0:3B", 2);  //InitBLEFramework( String macaddress, int gameID )
    }
    
    
    void Update()
    {
        if (cancontrol)
        {
            //#if UNITY_ANDROID
            string FMResponse = InitBLE.PluginClass.CallStatic<string>("_getFMResponse");
            Debug.Log("UNITY FMResponse: " + FMResponse);
            //Sample FMResponse : 
           /*
                {response_count}.{response}
                1.Left Move
                2.Right Move
                3.Jumping
                4.Bending
            */

            string[] FMTokens = FMResponse.Split('.');
            Debug.Log("UNITY FMTokens: " + FMTokens[0]);
            
            if (!FMTokens[0].Equals(FMResponseCount))
            {
                FMResponseCount = FMTokens[0];
                if (FMTokens[1] == "Left Move")
                {
                    float targetwidth = Mathf.Clamp(player.position.x - PlayerSingleDisplacement, PlayerStartPosition - PlayerXLimit, PlayerStartPosition + PlayerXLimit);
                    Vector3 newPlayerPosition = new Vector3(targetwidth, player.position.y, 0.0f);
                    player.MovePosition(newPlayerPosition);
                }
                else if (FMTokens[1] == "Right Move")
                {
                    float targetwidth = Mathf.Clamp(player.position.x + PlayerSingleDisplacement, PlayerStartPosition - PlayerXLimit, PlayerStartPosition + PlayerXLimit);
                    Vector3 newPlayerPosition = new Vector3(targetwidth, player.position.y, 0.0f);
                    player.MovePosition(newPlayerPosition);
                }

            }

            //Read KeyBoard Input
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                float targetwidth = Mathf.Clamp(player.position.x - PlayerSingleDisplacement, PlayerStartPosition - PlayerXLimit, PlayerStartPosition + PlayerXLimit);
                Vector3 newPlayerPosition = new Vector3(targetwidth, player.position.y, 0.0f);
                player.MovePosition(newPlayerPosition);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                float targetwidth = Mathf.Clamp(player.position.x + PlayerSingleDisplacement, PlayerStartPosition - PlayerXLimit, PlayerStartPosition + PlayerXLimit);
                Vector3 newPlayerPosition = new Vector3(targetwidth, player.position.y, 0.0f);
                player.MovePosition(newPlayerPosition);
            }

            //Read Touch screen Input
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = myCam.ScreenToWorldPoint(touch.position);
                if (touch.phase == TouchPhase.Began)
                {
                    if (touchPosition.x < 0)
                    {
                        float targetwidth = Mathf.Clamp(player.position.x - PlayerSingleDisplacement, PlayerStartPosition - PlayerXLimit, PlayerStartPosition + PlayerXLimit);
                        Vector3 newPlayerPosition = new Vector3(targetwidth, player.position.y, 0.0f);
                        player.MovePosition(newPlayerPosition);
                    }
                    if (touchPosition.x > 0)
                    {
                        float targetwidth = Mathf.Clamp(player.position.x + PlayerSingleDisplacement, PlayerStartPosition - PlayerXLimit, PlayerStartPosition + PlayerXLimit);
                        Vector3 newPlayerPosition = new Vector3(targetwidth, player.position.y, 0.0f);
                        player.MovePosition(newPlayerPosition);
                    }
                }
            }
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        //mySpriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponent<Rigidbody2D>();
        IsFacingRight = false;
        if (myCam == null)
        {
            myCam = Camera.main;
        }
        Vector3 UpperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 SceneWidth = myCam.ScreenToWorldPoint(UpperCorner);
        maxWidth = SceneWidth.x;

        PlayerStartPosition = myCam.transform.position.x;
        Vector3 InitialPlayerPosition = new Vector3(PlayerStartPosition, player.position.y, 0.0f);
        player.MovePosition(InitialPlayerPosition);

        //Depending upon the scene, wheteher 3 laned or 5 laned, player movment would be restricted.
        if ((levelmanager.currentLevel == "ECLevel1") || (levelmanager.currentLevel == "ECLevel3"))
        {
            //Decide X displacement limits for the player.
            PlayerSingleDisplacement = (maxWidth / 2);
            PlayerXLimit = PlayerSingleDisplacement;
        }
        else if (levelmanager.currentLevel == "ECLevel2")
        {
            //Decide X displacement limits for the player.
            PlayerSingleDisplacement = (maxWidth / 4);
            PlayerXLimit = 2 * PlayerSingleDisplacement;
        }
    }

    

    public void toggelControl(bool toggle)
    {
        cancontrol = toggle;
    }

    //private void FlipPlayer()
    //{
    //    // if the variable isn't empty (we have a reference to our SpriteRenderer
    //    if (mySpriteRenderer != null)
    //    {
    //        Debug.Log("Flipping Player !!");
    //        //mySpriteRenderer.flipX = !mySpriteRenderer.flipX;
    //        IsFacingRight = !IsFacingRight;
    //    }
    //}

}

