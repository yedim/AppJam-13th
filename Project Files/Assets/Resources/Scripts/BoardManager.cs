using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Range
    {
        public float minimum;
        public float maximum;
    }

    public Player player;
    public GameObject mainCamera;
    public GameObject enemyTile;
    public GameObject[] backgroundTiles;
    public Range enemySpawnXRange;

    private int level = 1;
    private int floor = 1;
    private int health = 100;
    public GameObject Gameover;
    bool Gameoverbool = false;
    public int HP
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            if(health<=0)
            {
                player.GetComponent<Animator>().SetTrigger("Die");
                Gameover.SetActive(true);
                Gameoverbool = true;
                Time.timeScale = 0.01f;
            }
            if (health > 100)
                health = 100;
        }
    }
    private float mapY = -7.2f;
    private float floorY = 2.4f;
    private GameObject[] backgroundInstants = new GameObject[3];
    private GameObject[,] enemyInstants = new GameObject[3,3];

    private GameObject GrayHealthBar;
    private GameObject RedHealthBar;
    private Text FloorText;

    private void Start()
    {
        StartCoroutine("HPminus");
        DrawLevel(1);
        DrawLevel(2);

        GrayHealthBar = GameObject.Find("GrayHealthBar");
        RedHealthBar = GameObject.Find("RedHealthBar");
        FloorText = GameObject.Find("FloorText").GetComponent<Text>();
    }

    private void Update()
    {
        if (health >= 0)
        {
            UpdateHealthBar(health);
        }
        if(Gameoverbool)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene("Main");
            }
        }
        //Debug.Log("level : " + level + ", floor : " + floor);
    }
    IEnumerator HPminus()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            health--;
        }
    }

    private void ChangefloorText()
    {
        FloorText.text = floor + "층";
    }

    private void UpdateHealthBar(int health)
    {
        RedHealthBar.transform.localScale = new Vector3(health * 0.01f, 1.0f, 1.0f);
    }

    private void DrawLevel(int level)
    {
        // 배경 생성
        backgroundInstants[level%3] = Instantiate(backgroundTiles[level % 2], new Vector3(0f, mapY * (level - 1), 0f), Quaternion.identity) as GameObject;
        // 경찰 생성
        //for (int i = 0; i < 3; i++)
        //{
        //    enemyInstants[level % 3, i]
        //        = Instantiate(enemyTile, new Vector3(UnityEngine.Random.Range(enemySpawnXRange.minimum, enemySpawnXRange.maximum), mapY * (level - 1) + floorY * (i - 1) , 0f), Quaternion.identity) as GameObject;
        //}
    }

    private void DestroyLevel(int level)
    {
        // 배경 파괴
        Destroy(backgroundInstants[level % 3]);
        // 경찰 파괴
        for(int i = 0; i < 3; i++)
        {
            Destroy(enemyInstants[level % 3,i]);
        }
    }

    public void FloorCountUp()
    {
        floor++;
        ChangefloorText();
        if ((floor / 3 + 1) > level)
        {   
            level = floor / 3 + 1;
            if (backgroundInstants[0] != null)
            {
                DestroyLevel(level - 2);
            }
            DrawLevel(level + 1);
        }
    }
}
