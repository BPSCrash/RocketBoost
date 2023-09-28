using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    RocketMovement _rocketMovement;
    SoundController _soundController;

    private void Start()
    {
        _rocketMovement = GetComponent<RocketMovement>();
        _soundController = GetComponent<SoundController>();
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Start":
                Debug.Log("START");
                break;
            case "Finish":
                Debug.Log("FINISH");
                _soundController.PlayWinSFX();
                NextLevel();
                break;
            case "Obstacle":
                Debug.Log("OBSTACLE");
                CrashSequence();
                break;
            case "Friendly":
                Debug.Log("FRIENDLY");
                break;
            case "Fuel":
                Debug.Log("FUEL");
                break;
            default:
                Debug.Log("YOU BLEW UP");
                CrashSequence();
                break;
        }
    }

    private void CrashSequence()
    {
        _soundController.PlayCrashSFX();
        _rocketMovement.isAlive(false);
        _rocketMovement.StopEverything();
        Invoke("ResetLevel", 1.5f);
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _rocketMovement.isAlive(true);
    }

    private void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex < SceneManager.sceneCount)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }

    }
}
