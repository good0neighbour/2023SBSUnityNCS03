using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CSceneTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DoGoScenePlayGame", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DoGoScenePlayGame()
    {
        //��� ���� Scene Merge : ���� ����� �ε��Ͽ� �ϳ��� ����� �����ϴ� ����Ƽ���� �����ϴ� ����̴�.

        //��(���� ����)�� ������ ��� '����'�� �ٷ絵�� �и��Ͽ���.
        //UI�� ������ ��� '����'�� �ٷ絵�� �и��Ͽ���.
        //      <--�۾� �д��� ���ϰ� �� �� �ִ� ������ �����Ͽ���.
        SceneManager.LoadScene("ScenePlayGame");
        SceneManager.LoadScene("SceneGrid_0", LoadSceneMode.Additive);
        SceneManager.LoadScene("SceneUIPlayGame", LoadSceneMode.Additive);

    }
}
