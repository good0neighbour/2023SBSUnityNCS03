using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CUITitle : MonoBehaviour
{
    //Animator mpAnimator = null;
    public GameObject fxImgFadeOut = null;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGoScenePlayGame()
    {
        fxImgFadeOut.SetActive(true);

        Invoke("DoGoScenePlayGame", 1.0f);
    }

    void DoGoScenePlayGame()
    {
        SceneManager.LoadScene("ScenePlayGame");
    }
}
