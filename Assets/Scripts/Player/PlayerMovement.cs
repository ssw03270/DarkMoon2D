using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cameraPosition;
    public GameObject attackRange;

    private PlayerInfo playerInfo;
    private PlayerInput playerInput;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GetComponent<PlayerInfo>();
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Rotation();
        Attack();
        SetAnimationSpeed();
    }

    private void Move()
    {
        if(playerInput.horizontal != 0 || playerInput.vertical != 0)
        {
            playerAnimator.SetBool("isMoving", true);
        }
        else
        {
            playerAnimator.SetBool("isMoving", false);
        }
        transform.position += new Vector3(playerInput.horizontal, playerInput.vertical, 0f) * Time.fixedDeltaTime * playerInfo.GetMoveSpeed();
        cameraPosition.position = transform.position + new Vector3(0, 0, -10);
    }
    private void Rotation()
    {
        if (!playerInfo.isAttacking)
        {
            if (playerInput.horizontal > 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (playerInput.horizontal < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            float mousePosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            if(transform.position.x < mousePosX)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        
    }
    private void Attack()
    {
        if (playerInput.mouseLeftClick && playerInfo.IsAttackAble())
        {
            playerAnimator.SetBool("attack", true);
            attackRange.SetActive(true);
            playerInfo.attackCool = 0f;
        }
    }

    private void SetAnimationSpeed()
    {
        var stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.move"))
        {
            playerAnimator.speed = playerInfo.moveSpeedRate;
        }

        if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.attack"))
        {
            playerAnimator.speed = playerInfo.attackSpeedRate;
        }
    }
}
