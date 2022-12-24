using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public float playerHealth = 100f;
    public float playerMaxHealth = 100f;

    public float moveSpeed = 5f;
    public float attackSpeed = 1f;
    public float dashSpeed = 3f;

    public float attackDamage = 1f;

    public float dashPower = 2f;

    public float moveSpeedRate = 1f;
    public float attackSpeedRate = 1f;
    public float dashSpeedRate = 1f;

    public float attackDamageUp = 1f;

    public float attackCool = 0f;
    public float dashCool = 0f;

    public bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AddTime();
    }
    public float GetMoveSpeed()
    {
        return moveSpeed* moveSpeedRate;
    }
    public bool IsAttackAble()
    {
        return attackCool > attackSpeed / attackSpeedRate;
    }
    public bool IsDashAble()
    {
        return dashCool > dashSpeed / dashSpeedRate;
    }
    public void AddTime()
    {
        attackCool += Time.fixedDeltaTime;
        dashCool += Time.fixedDeltaTime;
    }
}
