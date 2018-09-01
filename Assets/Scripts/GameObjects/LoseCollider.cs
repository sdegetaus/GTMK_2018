using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        SceneManager.LoadScene((int)Scenes.Entry);
    }
}
