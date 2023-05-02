using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAniDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAniDamage()
    {
        Debug.Log("<color='blue'>ForAniDamage.OnAniDamage</color>");

        //gameObject.GetComponentInParent<CSlime>().gameObject.SetActive(false);
        gameObject.GetComponentInParent<CEnemy>().gameObject.SetActive(false);
    }
}
