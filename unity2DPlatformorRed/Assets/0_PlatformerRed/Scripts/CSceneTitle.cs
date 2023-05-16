using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CSceneTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DoGoScenePlayGame", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DoGoScenePlayGame()
    {
        //장면 병합 Scene Merge : 여러 장면을 로드하여 하나의 장면을 구성하는 유니티에서 제공하는 기술이다.

        //맵(지형 정보)을 별도의 장면 '파일'로 다루도록 분리하였다.
        //UI를 별도의 장면 '파일'로 다루도록 분리하였다.
        //      <--작업 분담을 편리하게 할 수 있는 도구로 응용하였다.
        SceneManager.LoadScene("ScenePlayGame");
        SceneManager.LoadScene("SceneGrid_0", LoadSceneMode.Additive);
        SceneManager.LoadScene("SceneUIPlayGame", LoadSceneMode.Additive);

    }
}
