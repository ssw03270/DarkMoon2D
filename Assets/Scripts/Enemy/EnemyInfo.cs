using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public Transform targetPosition;
    public float moveSpeed = 5f;
    public float maxHealth = 10f;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        targetPosition = GameObject.Find("Player").transform;
    }
}
