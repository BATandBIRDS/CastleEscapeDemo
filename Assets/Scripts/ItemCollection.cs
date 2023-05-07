using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{ // Subject
    [SerializeField] RawImage keyImg;
    [SerializeField] TextMeshPro lvlTxt;
    [SerializeField] int playerLevel = 5;

    public static event Action GotKey;
    public static event Action GotBook;
    public bool hasKey;
    public bool hasBook;

    void Start()
    {
        lvlTxt.text = "Lvl: " + playerLevel.ToString();
        hasKey = false;
        keyImg.enabled = false;
    }

    void Update()
    {
        DestroyTheWall();
        LvlTxtGreen();
    }

    public int GetPlayerLevel()
    {
        return playerLevel;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            //GOT KEY
            Destroy(other.gameObject);
            keyImg.enabled = true;
            hasKey = true;
        }
        else if (other.CompareTag("Book")) 
        {
            //LEVEL UP
            Destroy(other.gameObject);
            hasBook = true;
            playerLevel += 5;
            lvlTxt.text = "Lvl: " + playerLevel.ToString();
        }
    }

    void DestroyTheWall()
    {
        // Theres an invisible wall on purple door.
        // This destroys it if player got the key
        if (hasKey)
        {
            GotKey?.Invoke();
        }
    }

    void LvlTxtGreen()
    {
        // check again
        if(hasBook)
        {
            GotBook?.Invoke();
        }
    }
}
