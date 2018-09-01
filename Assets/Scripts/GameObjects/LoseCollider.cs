using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider collision)
    {
        ElementSpawner.instance.continueSpawning = false;
        SceneManager.LoadScene((int)Scenes.Entry);
    }
}
