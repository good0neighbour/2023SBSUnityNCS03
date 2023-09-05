using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CSceneAudioMixer_step_3 : MonoBehaviour
{
    public AudioSource mAsBGM = null;
    public AudioSource mAsEffect = null;
    public AudioSource mAsShot = null;


    public AudioMixerSnapshot mSsDefault = null;
    public AudioMixerSnapshot mSsDistorsionBGM = null;
    public AudioMixerSnapshot mSsDistorsionEfx = null;


    //¿Àµð¿À ¹Í¼­
    public AudioMixer mAudioMixer = null;

    //¸¶½ºÅÍ º¼·ý
    float mMasterVolume = 0.0f;

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



        if (GUI.Button(new Rect(0, 100, 150, 100), "Master Volume Up"))
        {
            mMasterVolume += 1.0f;
            mAudioMixer.SetFloat("MasterVolume", mMasterVolume);

            Debug.Log($"master volume: {mMasterVolume.ToString()}");
        }
        if (GUI.Button(new Rect(150, 100, 150, 100), "Master Volume Down"))
        {
            mMasterVolume -= 1.0f;
            mAudioMixer.SetFloat("MasterVolume", mMasterVolume);

            Debug.Log($"master volume: {mMasterVolume.ToString()}");
        }




        if (GUI.Button(new Rect(0, 200, 150, 100), "BGM Volume"))
        {
            
        }
        if (GUI.Button(new Rect(150, 200, 150, 100), "Efx Volume"))
        {
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        mAudioMixer.GetFloat("MasterVolume", out mMasterVolume);
        Debug.Log($"master volume: {mMasterVolume.ToString()}");


        mAsBGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
