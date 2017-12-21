using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScipt : MonoBehaviour {
    public GameObject Player;
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, Player.transform.position.y, -10);
    }
}
