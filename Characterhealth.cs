using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characterhealth : MonoBehaviour
{
    public int maxhealth = 100;//yasounun cani
    public int currenthealth;//mevcud can
    public Healtbar healtbar;//can bari

    //enemy zamanla salddirisi
    public bool enemyattack;//dusman saldirisi
    public float enemytimer;//dusman zamanla saldirisi
    public Animator anim;


    void Start()
    {
        currenthealth = maxhealth;//mevcud cana yasounun canını esitlemişiz
        enemytimer = 1.5f;//zamanla atacagi
        anim = GetComponent<Animator>();
        
    }

    void EnemyAttackSpacing(){//yapacagi saldiridaki bosluk
        if(enemyattack == false){
            enemytimer -= Time.deltaTime;
        }

        if(enemytimer < 0){
            enemytimer = 0f;
        }

        if(enemytimer == 0f){
            enemyattack = true;
            enemytimer = 1.5f;
        }
    }

    void CharacterDamage()//yasounun saldirisindayken dusmanın saldirisini engelle
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            enemyattack = false;
        }
    }

    public void TakeDamage(int damage)//dusman saldiri hasari
    {
        if(enemyattack){

            currenthealth -= damage;
            enemyattack = false;

            anim.SetTrigger("hurt");
        }
        
        if(currenthealth <= 0){
            currenthealth = 0;
            Die();
        }

        healtbar.SetHealth(currenthealth);
    }

    void Die(){
        anim.SetBool("dieyasou",true);
        GetComponent<yasou>().enabled = false;
        Destroy(gameObject,2f);

    }

    void Update()
    {
        EnemyAttackSpacing();
        CharacterDamage();
        /*if(Input.GetKeyDown(KeyCode.X))
        {
            TakeDamage(20);
        }*/

    }
}
