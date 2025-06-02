using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public Transform playerSpawn;
    public GameObject uiPrefab;
    public Transform hudParent;
    public GameObject playerPrefab;

     GameManager gameManager;
    
    
    void Start()
    {
        GameObject newUI = Instantiate(uiPrefab, hudParent);
        GameObject newPlayer = Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation);
        Player playerScript = newPlayer.GetComponent<Player>();
        if (playerScript != null)
        {
            PlayerStats boostBar = newUI.GetComponent<PlayerStats>();
            playerScript.boostBar = boostBar;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
