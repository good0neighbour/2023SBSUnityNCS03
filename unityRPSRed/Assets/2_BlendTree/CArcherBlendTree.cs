using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CArcherBlendTree : MonoBehaviour
{
    [SerializeField]
    Animator mAnimator = null;

    //����Ƽ ������ �� �����Ͽ� ����Ƽ �����ͻ󿡼� �׽�Ʈ ����
    [SerializeField]
    float mBlendX = 0.0f;

    //�ΰ��� �׽�Ʈ���� �׽�Ʈ ����
    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "blend tword 0"))
        {
            mBlendX -= 0.1f;

            mAnimator.SetFloat("BlendX", mBlendX);
        }
        if (GUI.Button(new Rect(100, 0, 100, 100), "blend tword 1"))
        {
            mBlendX += 0.1f;

            mAnimator.SetFloat("BlendX", mBlendX);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
