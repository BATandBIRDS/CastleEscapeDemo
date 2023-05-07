using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTriggerWall : MonoBehaviour
{
    // Theres only 1 scene. win & loose panels are in it as inactive.

    [SerializeField] GameObject winPanel;

    private void Start()
    {
        winPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            winPanel.SetActive(true);
        }
    }
}
