using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSizeSpriteToCamera : MonoBehaviour {
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Camera.main.orthographicSize = 720 / (2 * 100f);
        Screen.SetResolution(1280, 720, false);
    }
}
