using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSceneAudioMixer_step_0 : MonoBehaviour
{
    public AudioSource mAsBGM = null;
    public AudioSource mAsEffect = null;
    public AudioSource mAsShot = null;



    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 150, 100), "play asEffect"))
        {
            mAsEffect.Play();
        }
        if (GUI.Button(new Rect(150, 0, 150, 100), "play asShot"))
        {
            mAsShot.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mAsBGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
