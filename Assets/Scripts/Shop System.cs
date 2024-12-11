using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    private GameUI gameUI;
    public AudioClip errorSound;
    private AudioSource errorSoundSource;
    public AudioClip moneySound;
    private AudioSource moneySoundSource;

    public PlayerController playerController;

    public EnemyMovement enemyMovement;
    
    //Cost of each ability
    private int speedBoostCost = 50;
    private int bulletSpeedCost = 40;
    private int slowEnemiesCost = 30;

    // Start is called before the first frame update
    void Start()
    {
        gameUI = GameObject.Find("Game Manager").GetComponent<GameUI>();

        errorSoundSource = GetComponent<AudioSource>();
        moneySoundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playErrorSound(){
        errorSoundSource.PlayOneShot(errorSound);
    }

    public void playMoneySound(){
        moneySoundSource.PlayOneShot(moneySound);
    }

    
    public void BuySpeedBoost(){
        if(gameUI.cash >= speedBoostCost){ 
            gameUI.UpdateScore(-speedBoostCost);
            playMoneySound();

            speedBoostUpgrade();
        }

        else{
            playErrorSound();
        }
    }

    public void BuyBulletSpeed(){
        if(gameUI.cash >= bulletSpeedCost){ 
            gameUI.UpdateScore(-bulletSpeedCost);
            playMoneySound();

            bulletSpeedUpgrade();
        }

        else{
            playErrorSound();
        }
    }

    public void BuySlowEnemiesUpgrade(){
        if(gameUI.cash >= slowEnemiesCost){ 
            gameUI.UpdateScore(-slowEnemiesCost);
            playMoneySound();

            slowEnemiesUpgrade();
        }

        else{
            playErrorSound();
        }
    }

    public void speedBoostUpgrade(){ // can be bought repeatedly to increase speed
        playerController.speed = playerController.speed + 2f;
    }

    public void bulletSpeedUpgrade(){ // also available multiple times
        playerController.bulletSpeed = playerController.bulletSpeed + 2f;
    }

    public void slowEnemiesUpgrade(){ // also available multiple times
        enemyMovement.speed = enemyMovement.speed - 2f;
    }
}
