using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CSceneTitle : MonoBehaviour
{
    public void OnGoScenePlayGame()
    {
        SceneManager.LoadScene("ScenePlayGame");
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("OnGoScenePlayGame", 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
