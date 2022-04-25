using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float attackRefershRate= 1.5f;
    Detection Detection;
    private Health healthTarget;
    private float attackTimer;
    public AudioSource source;
    public AudioClip firingEnemy;
    [SerializeField] private ParticleSystem EnemyfiringEffect;

    private void Awake()
    {
        Detection = GetComponent<Detection>();
        Detection.OnAggro += AggroDetection_OnAggro;
        
    }
    private void AggroDetection_OnAggro(Transform target)
    {
        Health health = target.GetComponent<Health>();
        if (health != null)
        {
            healthTarget = health;
        }
    }


    void Update()
    {
        if (healthTarget != null)
        {
            attackTimer += Time.deltaTime;
            if (CanAttack())
            {
                Attack();
            }

        }
    }
    private bool CanAttack()
    {
        return attackTimer >= attackRefershRate;
    }
    private void Attack()
    {
        EnemyFiringSound();
        attackTimer = 0;
        healthTarget.TakeDamage(1);
    }

    private void EnemyFiringSound()
    {
        EnemyfiringEffect.Play();
        source.clip = firingEnemy;
        source.Play();
    }
}
