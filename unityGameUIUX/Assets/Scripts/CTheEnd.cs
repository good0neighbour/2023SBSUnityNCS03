using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CTheEnd : MonoBehaviour
{
    [SerializeField]
    private float mMoveSceneTiming = 2.0f;

    private float mTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mMoveSceneTiming < mTimer)
        {
            SceneManager.LoadScene("SceneEnd");
        }

        mTimer += Time.deltaTime;
    }
}
