﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float throwSpeed = 1f;
    [SerializeField] float damage = 50f;    

    // Update is called once per frame
    void Update()
    {
        transform.Translate( Vector2.right * throwSpeed * Time.deltaTime );
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        //Debug.Log("I've been hit!!");
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if ( attacker && health )
        {
            health.TakeDamage(damage);

            Destroy(gameObject);
        }

    }

    
}
