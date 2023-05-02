using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using TMPro;

public class CUIResult : MonoBehaviour
{
    public TMPro.TMP_Text mpTxtScore = null;

    // Start is called before the first frame update
    void Start()
    {
        string tString = $"SCORE {CRyuMgrMono.GetInst.mScore.ToString()}";
        mpTxtScore.text = tString;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGoSceneTitle()
    {
        SceneManager.LoadScene("SceneTitle");
    }
}
