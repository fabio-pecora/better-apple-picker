using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;

    public GameObject badApplePrefab;

    public static float bottomY = -10;
    //Beginning time of the fist timer 
    public float firstTargetTime = 15f;

    //Begginning time of the second timer
    public float secondTargetTime = 25f;


    //Speed at which the Apple Tree moves
    public float speed = 1.0f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    //Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    //Rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 1.0f;

    public float secondsBetweenBadAppleDrops = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
        Invoke("DropBadApple", 6f);
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //Decreas the timers
        firstTargetTime -= Time.deltaTime;
        secondTargetTime -= Time.deltaTime;
        //Basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        } 
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
        
        if (firstTargetTime <= 0.0f)                                //When the first timer reaches 0
        {
            Physics.gravity = new Vector3(0, -25, 0);               //Increasing the gravity to make the apples fall faster
            secondsBetweenAppleDrops = 0.5f;                        //Making the apple drop faster
        }
        if (secondTargetTime <= 0.0f)                               //When the second tiemr reaches 0
        {
            Physics.gravity = new Vector3(0, -30, 0);               //Keep increasing the gravity
            secondsBetweenAppleDrops = 0.25f;                       //Keep increasing the dropping 
        }
        
    }
    
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);

    }

    void DropBadApple()
    {
        GameObject badApple = Instantiate<GameObject>(badApplePrefab);
        badApple.transform.position = transform.position;
        Invoke("DropBadApple", secondsBetweenBadAppleDrops);
    }

}
