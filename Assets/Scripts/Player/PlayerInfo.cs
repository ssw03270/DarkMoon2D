using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float attackSpeed = 1f;

    public float moveSpeedDown = 1f;
    public float attackSpeedDown = 1f;

    public float attackCool = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AddTime();
    }
    public float GetMoveSpeed()
    {
        return moveSpeed* moveSpeedDown;
    }
    public bool IsAttackAble()
    {
        return attackCool > attackSpeed / attackSpeedDown;
    }
    public void AddTime()
    {
        attackCool += Time.deltaTime;
    }
}
