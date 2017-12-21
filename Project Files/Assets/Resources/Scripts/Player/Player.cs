using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BoardManager boardManager;
    private BoxCollider2D playerCollider;
    private Rigidbody2D playerRigidbody;

    private void Awake()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LEFTUP") || collision.CompareTag("RIGHTUP"))
        {
            boardManager.FloorCountUp();
        }
    
    }
}
