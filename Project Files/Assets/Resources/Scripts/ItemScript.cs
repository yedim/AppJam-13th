using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {
    void DestoryItem()
    {
        Destroy(gameObject);
    }
    private void Start()
    {
        Invoke("DestoryItem", 0.4f);
    }
}
