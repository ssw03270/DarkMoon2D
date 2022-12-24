using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyInfo enemyInfo;
    // Start is called before the first frame update
    void Start()
    {
        enemyInfo = GetComponent<EnemyInfo>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, enemyInfo.targetPosition.position, Time.fixedDeltaTime * enemyInfo.moveSpeed);
    }

    private void Rotate()
    {
        if (enemyInfo.targetPosition.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (enemyInfo.targetPosition.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
