using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotheEnd : MonoBehaviour
{
    public SceneLoader CurrentSceneLoader;
    public bool IsTriggerEndScene = false;
    // Start is called before the first frame update
    void Start()
    {
        CurrentSceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTriggerEndScene)
        {
            CurrentSceneLoader.LoadEndScene();
            IsTriggerEndScene = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsTriggerEndScene = true;
        }
    }
}
