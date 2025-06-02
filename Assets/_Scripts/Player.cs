using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro;
using JetBrains.Annotations;
using System.Data;

public class Player : MonoBehaviour
{
    public bool playerAlive = true;
    public int activeScore = 0;
    public float maxBoost = 100f;
    [SerializeField] public float currentBoost;
    public PlayerStats boostBar;
    public TextMeshProUGUI ScoreRoll;
    public bool hasFuel = true;
    public ParticleSystem boostParticles;
    private ParticleSystem explode;
    private ParticleSystem smoke;
    private ParticleSystem warning;
    private ParticleSystem electric;
    
    void Start()
    {
        currentBoost = maxBoost;
        boostBar.SetMaxBoost(maxBoost);
        ScoreRoll = GameObject.Find("ScoreCounterDisplay").GetComponent<TextMeshProUGUI>();
                
    }
    void OnEnable()
    {
        boostParticles = transform.Find("Thruster_PS").GetComponent<ParticleSystem>();
        explode = transform.Find("Explode_PS").GetComponent<ParticleSystem>();
        smoke = transform.Find("Smoke_PS").GetComponent<ParticleSystem>();
        warning = transform.Find("Warning_PS").GetComponent<ParticleSystem>();
        electric = transform.Find("Electric_PS").GetComponent<ParticleSystem>();

        boostParticles.Play();
    }

    void Update()
    {
        ScoreCounter();
        
        if (hasFuel)
        {
            // Debug.Log("HAS FUEL");
        }
        
        if (currentBoost<=0)
        {
            hasFuel = false;
        }
        
        if (currentBoost>=1)
        {
            hasFuel = true;
        }

        if (Input.GetKey(KeyCode.Space) && currentBoost > 0)
        {
            UseBoost(0.4f);
            var emission = boostParticles.emission;
            emission.rateOverTime = 500;
        }
        else
        {
            var emission = boostParticles.emission;
            emission.rateOverTime = 10;
        }

            if (Input.GetKeyDown(KeyCode.Space) && currentBoost > 0)
        {
            SoundManager.Play(SoundType.BOOST, 0.8f);
        }

    }
    

    
    void UseBoost(float boostActive)
    {
        currentBoost -= boostActive;

        boostBar.SetBoost(currentBoost);
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject boostPickup = other.gameObject;
        if (other.gameObject.CompareTag("BoostItem") && currentBoost < maxBoost)
        {
            currentBoost += 20f;
            boostBar.SetBoost(currentBoost);
            Debug.Log("BOOST PICKUP");
            Object.Destroy(boostPickup);
            SoundManager.Play(SoundType.PICKUP, 1);
        }

        if (other.gameObject.CompareTag("Tunnel"))
        {
            if (playerAlive == true)
            {
                warning.Stop();
                SoundManager.Stop(SoundType.WARNING);
                Debug.Log("ENTERED BOUNDS");
            }
        }
    }

    public float GetCurrentBoost() { return currentBoost; }

    void ScoreCounter()
    {
        if (playerAlive == true)
        {
            activeScore ++;
            ScoreRoll.text = activeScore.ToString();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") && playerAlive == true)
        {
            playerAlive = false;

            explode.Play();
            smoke.Play();
            warning.Stop();

            if (activeScore > PlayerPrefs.GetInt("HighScore", 0))
            {
            PlayerPrefs.SetInt("HighScore", activeScore);
            PlayerPrefs.Save();
            }
            GameManager.instance.EndGame();
        }
        if (collision.gameObject.CompareTag("WarpWall") && playerAlive == true)
        {
            playerAlive = false;

            electric.Play();
            smoke.Play();
            warning.Stop();
            
            if (activeScore > PlayerPrefs.GetInt("HighScore", 0))
            {
            PlayerPrefs.SetInt("HighScore", activeScore);
            PlayerPrefs.Save();
            }
            GameManager.instance.EndGameB();
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Asteroid") && playerAlive == true)
        {
            Debug.Log("NEAR MISS");
            SoundManager.Play(SoundType.NEARMISS, 0.6f);
        }
        if (other.gameObject.CompareTag("Tunnel"))
        {
            if (playerAlive == true)
            {
                warning.Play();
                SoundManager.Play(SoundType.WARNING, 0.2f, 1, true);
                Debug.Log("EXITED BOUNDS");
            }
        }
    }

    

}
