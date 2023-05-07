using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBreaker : MonoBehaviour
{
    // Every single enemy is responsible for one red lock on golden door

    [SerializeField] GameObject OneEnemyOneRedLock;

    void Update()
    {
        BreakRedLock();
    }

    void BreakRedLock()
    {
        if (OneEnemyOneRedLock == null) {
        Destroy(gameObject);}
    }
}
