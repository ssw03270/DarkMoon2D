using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public GameObject healthUI;
    public GameObject healthBar;

    private PlayerInfo playerInfo;

    // Start is called before the first frame update
    void Start()
    {
        playerInfo = player.GetComponent<PlayerInfo>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        float normalizedHealth = playerInfo.playerHealth / playerInfo.playerMaxHealth;
        healthBar.transform.localScale = new Vector3(normalizedHealth, 1f, 1f);

        healthUI.transform.position = Vector3.Lerp(healthUI.transform.position, player.transform.position, Time.fixedDeltaTime * playerInfo.moveSpeed * 5f);
    }
}
