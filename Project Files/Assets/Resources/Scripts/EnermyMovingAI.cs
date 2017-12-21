using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMovingAI : MovingScript
{
    public MoveType EnermyMoveType;
    private void Start()
    {
        StartPosition = gameObject.transform.position;
    }
    private void Update()
    {
        DirectionCheck();
        EnermyMoving();
    }


    private Vector3 StartPosition;//방향을 바꾸고 StartPosition 다시초기화 
    private void EnermyMoving()
    {
        switch (EnermyMoveType)
        {
            case MoveType.Left:
                RightMoving();
                break;
            case MoveType.Right:
                RightMoving();
                break;
        }
    }
    private void DirectionCheck()
    {
        Vector2 CheckVector;
        if(EnermyMoveType==MoveType.Left)
        {
            CheckVector = Camera.main.WorldToScreenPoint(StartPosition - gameObject.transform.position);
            if (CheckVector.x > 300 && Random.Range(0, 300) == 99)
            {
                StartPosition = gameObject.transform.position;
                EnermyMoveType = MoveType.Right;
            }
        }
        else if (EnermyMoveType == MoveType.Right)
        {
            CheckVector = Camera.main.WorldToScreenPoint(gameObject.transform.position - StartPosition);
            if (CheckVector.x > 300 && Random.Range(0, 300) == 99)
            {
                StartPosition = gameObject.transform.position;
                EnermyMoveType = MoveType.Left;
            }
        }
    }
    public void EnermyDirectionCh()
    {
        if (EnermyMoveType == MoveType.Left)
        {
            EnermyMoveType = MoveType.Right;
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (EnermyMoveType == MoveType.Right)
        {
            EnermyMoveType = MoveType.Left;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
