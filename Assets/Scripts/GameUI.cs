using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public int cash;
    public TextMeshProUGUI CashText;

    // Start is called before the first frame update
    void Start()
    {
        cash = 0;
        CashText.text = "Cash: " + "$" + cash;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd){
        cash += scoreToAdd;
        CashText.text = "Cash: " + "$" + cash;
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
