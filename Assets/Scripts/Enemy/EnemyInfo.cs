using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public Transform targetPosition;
    
    public float moveSpeed = 5f;
    public float attackSpeed = 1f;
    
    public float enemyMaxHealth = 10f;
    public float enemyHealth;

    public float attackCool = 0f;
    public float attackDamage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = enemyMaxHealth;
        targetPosition = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        AddTime();
    }
    public void AddTime()
    {
        attackCool += Time.fixedDeltaTime;
    }
}
