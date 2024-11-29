using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    //public Animator animator;
    public void LoadingGame()
    {
        //StartCoroutine(Transition());
        SceneManager.LoadScene(1);
    }

    //IEnumerator Transition()
    //{
    //    animator.SetBool("FadeIn", true);
    //    animator.SetBool("FadeOut", false);
    //    yield return new WaitForSeconds(1);
    //}
}
