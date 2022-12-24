using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDamage : MonoBehaviour
{
    public GameObject player;
    public GameObject bloodSplash;

    private PlayerInfo playerInfo;
    private BoxCollider2D boxCollider2D;
    private float activeTime = 0f;
    private float activeMinTime = 0.1f;
    private float activeMaxTime = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        playerInfo = player.GetComponent<PlayerInfo>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChangeActive();
    }
    void ChangeActive()
    {
        activeTime += Time.fixedDeltaTime;
        playerInfo.isAttacking = true;
        if (activeTime > activeMinTime)
        {
            boxCollider2D.enabled = true;
            if(activeTime > activeMaxTime)
            {
                gameObject.SetActive(false);
                boxCollider2D.enabled = false;
                playerInfo.isAttacking = false;
                activeTime = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.GetComponent<EnemyInfo>().health -= playerInfo.attackDamage;
            Destroy(Instantiate(bloodSplash, collision.transform.position, bloodSplash.transform.rotation), 1f);
            if(collision.GetComponent<EnemyInfo>().health <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
