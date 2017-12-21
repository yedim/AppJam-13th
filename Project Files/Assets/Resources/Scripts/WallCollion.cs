using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollion : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enermy"))
        {
            Debug.Log("eiwofnseiogsofs");
            collision.GetComponent<EnermyMovingAI>().EnermyDirectionCh();
        }
    }
}
