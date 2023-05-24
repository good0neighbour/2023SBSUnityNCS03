using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum SCROLL
{
    DISABLE_SCROLL = 0, //��ũ�� �Ҵ�
    ENABLE_SCROLL,      //��ũ�� ����
}

public class CGrid : MonoBehaviour
{
    [SerializeField]    //<-- ����Ƽ ������ �� ����
    GameObject[] mGameObjects = null;   //�غ�� �� ����( ���۸��� ��� )

    [SerializeField]
    float mScalarSpeed = 0.0f;  //��ũ�� �ӵ�

    [SerializeField]
    float mEdge = 0.0f; //���Ѽ�

    List<Vector3> mOriginPositionis = new List<Vector3>();  //�� ���ǵ��� ���� ��ġ�� ���


    SCROLL mIsScroll = SCROLL.DISABLE_SCROLL;


    // Start is called before the first frame update
    void Start()
    {
        //������ �ʱ� ���� ����ϰ� �Ѵ�.
        mOriginPositionis.Clear();

        foreach (var t in mGameObjects)
        {
            //Vector3�� struct�Ƿ� ������
            mOriginPositionis.Add(t.transform.position);
        }

        mIsScroll = SCROLL.ENABLE_SCROLL;
    }

    // Update is called once per frame
    void Update()
    {
        if (SCROLL.ENABLE_SCROLL == mIsScroll)
        {
            for (int ti = 0;  ti < mGameObjects.Length; ++ti)
        {
            var t = mGameObjects[ti];

            //Time.deltaTime ������ �ð� <-- ���� ������ �� �����ӿ� �ɸ��� �ð�
            //Vector3����ü
            t.transform.Translate((-1f) * Vector3.forward * mScalarSpeed * Time.deltaTime, Space.Self);

            if (t.transform.position.z <= mEdge)
            {
                //��ũ�� ���� ����
                float tDiffY = t.transform.position.z - mEdge;

                //������ ������ �����ص� �ҽ��ڵ� ������ ������
                // mOriginPositionis.Count - 1�� ǥ��
                t.transform.position = mOriginPositionis[mOriginPositionis.Count - 1] + new Vector3(0.0f, 0.0f, tDiffY);
            }

        }
        }
    }


    public void DoStopScroll()
    {
        //�ش� ������ ����� ���������ڴ�.
        //�̸��׸�, mScarlarSpeed�� 0���� �����ص� �ȴ�.
        //������, Update�Լ� ���Ǻο� �ڵ带 ������ϴ� ��찡 ���� �����ڴ�.
        //�׷��� �Ǵ� ������� �̿��Ѵ�.
        //�׷��� ������ ������ ����Ѵ�.

        mIsScroll = SCROLL.DISABLE_SCROLL;
    }
}
