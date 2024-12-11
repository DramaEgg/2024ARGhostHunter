using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossOver : MonoBehaviour
{
    public SceneLoader CurrentSceneLoader;
    public bool IsTriggerNextScene = false;

    private void Start()
    {
        CurrentSceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
    }

    private void Update()
    {
        if (IsTriggerNextScene)
        {
            CurrentSceneLoader.LoadNextScene();
            IsTriggerNextScene = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsTriggerNextScene = true;
        }
    }
}