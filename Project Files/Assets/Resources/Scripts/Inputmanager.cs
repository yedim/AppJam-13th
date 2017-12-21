using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputmanager : MonoBehaviour {
    public PlayerController Player;

    void Update () {
		if(Input.GetKey(KeyCode.RightArrow))
            Player.RightMoving();
        else if(Input.GetKey(KeyCode.LeftArrow))
            Player.LeftMoving();

        if (Input.GetKey(KeyCode.UpArrow))
            Player.UpMoving();
        else if (Input.GetKey(KeyCode.DownArrow))
            Player.DownMoving();
    }
}
