using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testHandle2DGUI : MonoBehaviour
{
    float mFPS = 0f; //�ʴ� ������
    float mTime = 0f;//�ð�����
    float mFrameTime = 0f;//������ �ð� ����

    public string mString = string.Empty;//read only �� ���ڿ�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //'�ʴ� ������'�� '������ �ð�'

        mFPS++;

        //timeScale ���� ������ �ð��� �帧�� ������ �� �ִ� ����

        //mTime += Time.deltaTime;    //�ð� ���� <--������ �ð� ���� <-- timeScale�� ������ ����
        mTime += Time.unscaledDeltaTime;    //�ð� ���� <--������ �ð� ���� <-- timeScale�� ������ ���� �ʴ´�

        if (mTime > 1f)
        {
            mFrameTime = mTime / mFPS;    //������ ������ �ð��� ����
            mTime -= 1f;    //�ð� ���� �ʱ�ȭ

            mString = $"FPS:{mFPS.ToString()}, Frame Time: {mFrameTime.ToString()}";

            mFPS = 0f;//FPS�ʱ�ȭ
        }

    }
}
