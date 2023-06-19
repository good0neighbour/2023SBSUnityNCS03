using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CSeneEfx : MonoBehaviour
{
    //PostProcessing���ȿ�� ���� ���� ������Ʈ ����
    [SerializeField]
    GameObject[] mPPSs = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI()
    {
        if (GUI.Button(new Rect(0f, 0f, 100f, 50f), "test BloomDay"))
        {
            //clear
            foreach (var t in mPPSs)
            {
                t.SetActive(false);
            }

            mPPSs[0].SetActive(true);
            StartCoroutine(UpdatePPS_0());
        }

        if (GUI.Button(new Rect(100f, 0f, 100f, 50f), "test NormalDay"))
        {
            //clear
            foreach (var t in mPPSs)
            {
                t.SetActive(false);
            }

            mPPSs[0].SetActive(true);
            StartCoroutine(UpdatePPS_0_0());
        }

        if (GUI.Button(new Rect(0f, 100f, 100f, 50f), "test Fade out"))
        {
            //clear
            foreach (var t in mPPSs)
            {
                t.SetActive(false);
            }

            mPPSs[1].SetActive(true);
            StartCoroutine(UpdatePPS_1());
        }

        if (GUI.Button(new Rect(100f, 100f, 100f, 50f), "test Fade in"))
        {
            //clear
            foreach (var t in mPPSs)
            {
                t.SetActive(false);
            }

            mPPSs[1].SetActive(true);
            StartCoroutine(UpdatePPS_1_0());
        }
    }

    //IEnumerator + �ݺ������ + yield return
    //<-- ������ �����帧�� �����.
    IEnumerator UpdatePPS_0()
    {
        for(; ; )
        {
            mPPSs[0].GetComponent<PostProcessVolume>().weight += 0.1f;

            if (mPPSs[0].GetComponent<PostProcessVolume>().weight >= 1.0f)
            {
                StopAllCoroutines();    //�ڷ�ƾ ��� ����
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator UpdatePPS_0_0()
    {
        for(; ; )
        {
            mPPSs[0].GetComponent<PostProcessVolume>().weight -= 0.1f;

            if (mPPSs[0].GetComponent<PostProcessVolume>().weight <= 0.0f)
            {
                StopAllCoroutines();    //�ڷ�ƾ ��� ����
            }

            yield return new WaitForSeconds(0.1f);
        }
    }


    IEnumerator UpdatePPS_1()
    {
        for (; ; )
        {
            mPPSs[1].GetComponent<PostProcessVolume>().weight += 0.1f;

            if (mPPSs[1].GetComponent<PostProcessVolume>().weight >= 1.0f)
            {
                StopAllCoroutines();    //�ڷ�ƾ ��� ����
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator UpdatePPS_1_0()
    {
        for (; ; )
        {
            mPPSs[1].GetComponent<PostProcessVolume>().weight -= 0.1f;

            if (mPPSs[1].GetComponent<PostProcessVolume>().weight <= 0.0f)
            {
                StopAllCoroutines();    //�ڷ�ƾ ��� ����
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
