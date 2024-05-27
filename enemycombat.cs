using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycombat : MonoBehaviour//dusmanin saldirisini yapar.colider kontrol edilerek hasar verilir.
{
    public Transform enemyattackpoint;
    public LayerMask player_layer;
    public float enemyattackrange=0.5f;
    public int enemyattackdamage = 10;

    public void DamagePlayer()
    {
        Collider2D[] dusmana_vurmak=Physics2D.OverlapCircleAll(enemyattackpoint.position,enemyattackrange,player_layer);
        foreach(Collider2D enemy in dusmana_vurmak){
            enemy.GetComponent<Characterhealth>().TakeDamage(enemyattackdamage);
            FindObjectOfType<AudioManager>().Play("swordsound2");
            FindObjectOfType<AudioManager>().Play("enemyhurt");
        }
    }
    
    void OnDrawGizmosSelected(){
        if(enemyattackpoint == null){
           return; 
        }
        Gizmos.DrawWireSphere(enemyattackpoint.position,enemyattackrange);
    }
}
