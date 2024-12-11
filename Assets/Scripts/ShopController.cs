using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public GameObject player; //holding the player object
    public GameObject shopUI; //holding the shop ui object
    private PlayerController playerController; //referencing the player controller script

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>(); //holding the player component
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Check for a trigger on the shop sensor
    private void OnTriggerEnter(Collider other){
        if(other.gameObject == player){
            //Display the shopUI
            shopUI.SetActive(true);

            //Disable player movement
            playerController.DisableMovement();
        }
    }

    //To be referenced by the back button in the shop UI
    public void CloseShop(){
        playerController.EnableMovement();
    }
}
