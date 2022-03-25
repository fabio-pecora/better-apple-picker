using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{

    [Header("Set in Inspector")]
    public GameObject basketPrefab;

    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for(int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed()
    {
        //Just reset the apple falling if the red apple fall
         if(GameObject.FindWithTag("Apple") != null && GameObject.FindWithTag("BadApple") == null) {
            //Destroy all of the falling apples
            GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
            foreach (GameObject go in tAppleArray)
            {
                Destroy(go);
            }
        }
        //Only delete a basket if we miss a good apple, if we miss a bad apple no basket will be removed 
        if(GameObject.FindWithTag("Apple") != null && GameObject.FindWithTag("BadApple") == null)
        {
            //Destroy one of the baskets!
            //Get the index of the last basket in basketList
            int basketIndex = basketList.Count - 1;
            //Get a reference to the basket GameObject
            GameObject tBasketGO = basketList[basketIndex];
            //Remove the basket from the list and destroy the GameObject
            basketList.RemoveAt(basketIndex);
            Destroy(tBasketGO);
        }

        //if there are no baskets left, restart the game
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("Scene_0");
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
