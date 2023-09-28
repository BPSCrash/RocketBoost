using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Finish":
                Debug.Log("FINISH");
                break;
            case "Obstacle":
                Debug.Log("OBSTACLE");
                break;
            case "Friendly":
                Debug.Log("FRIENDLY");
                break;
            case "Fuel":
                Debug.Log("FUEL");
                break;
            default:
                Debug.Log("YOU BLEW UP");
                break;
        }
    }
}
