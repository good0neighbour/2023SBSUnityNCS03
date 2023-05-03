using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CSceneTitle : MonoBehaviour
{
    public void BtnGoScenePlayGame()
    {
        SceneManager.LoadScene("ScenePlayGame");
    }
}
