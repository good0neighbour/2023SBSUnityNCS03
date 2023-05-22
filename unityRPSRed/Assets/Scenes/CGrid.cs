using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGrid : MonoBehaviour
{
    [SerializeField]    //<-- ����Ƽ ������ �� ����
    GameObject[] mGameObjects = null;   //�غ�� �� ����( ���۸��� ��� )

    [SerializeField]
    float mScalarSpeed = 0.0f;  //��ũ�� �ӵ�

    [SerializeField]
    float mEdge = 0.0f; //���Ѽ�

    List<Vector3> mOriginPositionis = new List<Vector3>();  //�� ���ǵ��� ���� ��ġ�� ���


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
    }

    // Update is called once per frame
    void Update()
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
