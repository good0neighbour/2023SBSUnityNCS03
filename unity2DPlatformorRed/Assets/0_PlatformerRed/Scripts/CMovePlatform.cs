using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMovePlatform : MonoBehaviour
{
    [SerializeField]
    GameObject[] mGO = null;    //��ġ�� ������ ���ӿ�����Ʈ N��

    //��ġ������ ��Ƶ� �����迭
    List<Vector2> mPositions = new List<Vector2>();

    [SerializeField]    //<--����Ƽ ������ �󿡼� ���������ϰ� ����
    float mTime = 0.0f; //������ �ɸ��� �ð�

    //����ġ
    float mWeight = 0.0f;
    float mDir = -1.0f;

    float mScalarSpeed = 0.0f;  //�ӷ�

    // Start is called before the first frame update
    void Start()
    {
        foreach (var t in mGO)
        {
            mPositions.Add(t.transform.position);
        }

        //      �ӵ� = �Ÿ� / �ð�

        //�Ÿ� ���ϱ�
        float tD = (mPositions[1] - mPositions[0]).magnitude;
        //(�������� - ��������) = ������ ũ���� ������ ������ ����
        //�ش� ������ ũ�⸦ ���ߴ�.
        //(���������� ������������ ũ�ٰ� ����)

        Debug.Log($"tD: {tD.ToString()}");

        //'�ӵ�(�� �߿��� �ӷ�)'�� ���Ѵ�
        if (mTime != 0.0f)
        {
            mScalarSpeed = tD / mTime;
        }
        //ó������ ���ʹ������� �̵��Ѵٰ� ����
        mDir = -1.0f * mScalarSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //��迡 ������ ���� �ٲٱ�( ���������� ��������� ��� )
        if (1.0f <= mWeight)
        {
            mDir = -1.0f * mScalarSpeed;    //������ ����� ���� ��������
        }
        else if (0.0f >= mWeight)
        {
            mDir = 1.0f * mScalarSpeed;     //���� ����� ������ ��������
        }


        //����ġ ����
        mWeight = mWeight + mDir * Time.deltaTime;  //�ð����

        Vector2 tPos = Vector2.Lerp(mPositions[0], mPositions[1], mWeight);
        //��ġ�� ���� ����
        this.transform.position = tPos;
    }
}
