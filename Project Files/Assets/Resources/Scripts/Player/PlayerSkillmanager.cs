using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillmanager : MonoBehaviour {
    public bool GhostOn = false;
    private SpriteRenderer[] Child;
    private void Start()
    {
        Child = GetComponentsInChildren<SpriteRenderer>();
        StartCoroutine("GhostHPminus");
    }
    public bool AttackOn = false;
    public void Skill_Attack()
    {
        AttackOn = true;
        GetComponent<Animator>().SetTrigger("Attack");
        Invoke("Skill_AttackOff", 0.5f);
    }
    private void Skill_AttackOff()
    {
        AttackOn = false;
    }
    public BoardManager _boardmanager;
    IEnumerator GhostHPminus()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (GhostOn == true)
                _boardmanager.HP -= 2;
        }
    }
    public  void Skill_HideStart()
    {
        GhostOn = true;
        for (int i = 0; i < Child.Length; i++)
        {
            Child[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.3f);
        }
    }

    public void Skill_HideEnd()
    {
        GhostOn = false;
        for (int i = 0; i < Child.Length; i++)
        {
            Child[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }

}
