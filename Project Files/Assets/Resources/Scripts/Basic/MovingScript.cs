using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour {
    public enum MoveType
    {
        Right,
        Left,
        RightDown,
        LeftDown,
    }
    public float Speed;

    public void LeftMoving()
    {
        gameObject.transform.Translate(Vector2.left * Time.deltaTime * Speed);
    }
    public void RightMoving()
    {
        gameObject.transform.Translate(Vector2.right * Time.deltaTime * Speed);
    }
    public void UpMoving()
    {
        gameObject.transform.Translate(Vector2.up * Time.deltaTime * Speed);
    }
    public void DownMoving()
    {
        gameObject.transform.Translate(Vector2.down * Time.deltaTime * Speed);
    }
}
