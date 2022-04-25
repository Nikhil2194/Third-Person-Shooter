using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int startingHealth = 5;

    private int currentHealth;
    //[SerializeField] ParticleSystem dieEffect;

    public AudioSource Death;
    public AudioClip DeathSoundFX;
    private Animator animator;

   


    private void OnEnable()
    {
        currentHealth = startingHealth;
    }
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth = currentHealth - damageAmount;

        if (currentHealth <= 0)
        {
            //DeathSound();
            // Die();
            animator.SetTrigger("death");
        }
    }
   

   /* private void Die()
    {
        
        // dieEffect.Play();
        //gameObject.SetActive(false);
       
    }*/


   
}
