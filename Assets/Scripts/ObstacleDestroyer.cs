using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{//observer

    // Theres an invisible wall on purple door.
    // This destroys it if player got the key
    void Start()
    {
        ItemCollection.GotKey += DestroyTheWall;
    }

    private void OnDestroy()
    {
        ItemCollection.GotKey -= DestroyTheWall;
    }

    void DestroyTheWall() 
    {
        if (gameObject == null) { return; }
        Destroy(gameObject);
    }
}
