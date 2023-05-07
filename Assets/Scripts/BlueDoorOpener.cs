using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDoorOpener : MonoBehaviour
{// Observer
    // When player triggers the button:

    void Start()
    {
        ButtonMechanics.OnPressed += DoorOpener;
    }

    private void OnDestroy()
    {
        ButtonMechanics.OnPressed -= DoorOpener;
    }

    public void DoorOpener()
    {
        if (gameObject == null) { return; }
        transform.Translate(Vector3.down * Time.deltaTime);
        Invoke("DoorDestroyer", 3f);
    }

    void DoorDestroyer()
    {
        Destroy(gameObject);
    }
}
