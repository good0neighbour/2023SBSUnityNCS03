using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ("Actor" == other.tag)
        {
            Destroy(gameObject);
            ++GameManager.Instance.ItemNum;
            CSliderItemCount.Instance.UpdateUI();
        }
    }
}
