using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : CoinManager
{
    [SerializeField] int health;
    public HealtBar healtBar;
    public Rigidbody2D rb;
    
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }

    }
    public bool Isdead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else return false;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Isdead();
        healtBar.SetHealth(health);
    }

    public virtual void Init(int newHealth)
    {
        health = newHealth;
        healtBar.SetMaxHealth(newHealth);
        rb = GetComponent<Rigidbody2D>();
    }

}
