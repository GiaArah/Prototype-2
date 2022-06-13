using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float startHealth = 100f;
    private float health;
    public float damageAmount = 10f;
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        startHealth = health;
        damageAmount = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        health -= damageAmount;
        healthBar.fillAmount = (health / startHealth);

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //complete Game Over Screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
