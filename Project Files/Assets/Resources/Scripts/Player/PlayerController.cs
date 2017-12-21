using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovingScript
{
    private SpriteRenderer[] Child;
    private MoveType PlayerMoveType;
    private void Start()
    {
        PlayerMoveType = MoveType.Right;
        Child = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        switch(PlayerMoveType)
        {
            case MoveType.Right:
                RightMoving();
                break;
            case MoveType.Left:
                RightMoving();
                break;
            case MoveType.RightDown:
                RightMoving();
                DownMoving();
                transform.rotation = Quaternion.identity;
                break;
            case MoveType.LeftDown:
                RightMoving();
                DownMoving();
                transform.rotation = Quaternion.Euler(0,180,0);
                break;
        }
    }
    public BoardManager boardmanager;
    public GameObject Item;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LEFT"))
        {
            PlayerMoveType = MoveType.Left;
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (collision.gameObject.CompareTag("RIGHT"))
        {
            PlayerMoveType = MoveType.Right;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (collision.gameObject.CompareTag("RIGHTUP"))
        {
            GetComponent<Animator>().SetTrigger("Stair");
            PlayerMoveType = MoveType.RightDown;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (collision.gameObject.CompareTag("LEFTUP"))
        {
            GetComponent<Animator>().SetTrigger("Stair");
            PlayerMoveType = MoveType.LeftDown;
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if(collision.gameObject.CompareTag("ItemHeal"))
        {
          
        }
        if (collision.gameObject.CompareTag("Enermy"))
        {
            if (GetComponent<PlayerSkillmanager>().AttackOn == true)
            {
                Destroy(collision.gameObject.GetComponent<EnermyMovingAI>());
                Instantiate(Item, collision.gameObject.transform.position, Quaternion.identity);
                Invoke("HPplus", 0.3f);
                collision.gameObject.GetComponent<Animation>().Play("Enemy_DaiAnimation");
            }
            else if (GetComponent<PlayerSkillmanager>().GhostOn == false)
            {
                Destroy(GetComponent<PlayerController>());
                boardmanager.HP = 0;
            }
            
        }
    }
    void HPplus()
    {
        boardmanager.HP += 30;
    }
}
