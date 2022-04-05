using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonController : MonoBehaviour
{
    float selection;
    [Space(5)]
    [Header("Pistol")]
    public GameObject pistolSprite; //declaring pistol button sprite (default)
    public GameObject pistolSelected; // declaring pistl pistol button sprite (selected one)
    

    [Space(5)]
    [Header("Shotgun")]
    public GameObject shotgunSprite;
    public GameObject shotgunSelected;
    

    [Space(5)]
    [Header("AK-47")]
    public GameObject akSprite;
    public GameObject akSelected;
   

    [Space(5)]
    [Header("RPG")]
    public GameObject RPGSprite;
    public GameObject RPGSelected;


    [Space(5)]
    [Header("Health")]
    public GameObject healthSprite;
    public GameObject healthSelected;

    [Space(5)]
    [Header("attack")]
    public GameObject attackSprite;
    public GameObject attackSelected;

    [Space(5)]
    public GameObject pistolBuy;
    public GameObject shotgunBuy;
    public GameObject akBuy;
    public GameObject RPGBuy;
    public GameObject healthBuy;
    public GameObject attackBuy;

    const int MAX_SELECTION = 6;
    // Start is called before the first frame update
    void Start()
    {
        selection = 0; // selection starts with 0
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)) //checking input
        {
            //slection goes down
            if(selection <= MAX_SELECTION)
            {
                selection++;
            }

            if(selection > MAX_SELECTION)
            {
                selection = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // selection goes up
            if (selection >= 1)
            {
                selection--;
            }

            if (selection < 1)
            {
                selection = MAX_SELECTION;
            }
        }
        if(selection == 1)
        {
            pistolSprite.SetActive(false);
            pistolSelected.SetActive(true);
            pistolBuy.SetActive(false);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                pistolBuy.SetActive(true);
                UI_Shop.shop.BuyPistol();
            }

            shotgunSprite.SetActive(true);
            shotgunSelected.SetActive(false);
            shotgunBuy.SetActive(false);

            akSprite.SetActive(true);
            akSelected.SetActive(false);
            akBuy.SetActive(false);

            RPGSprite.SetActive(true);
            RPGSelected.SetActive(false);
            RPGBuy.SetActive(false);

            healthSprite.SetActive(true);
            healthSelected.SetActive(false);
            healthBuy.SetActive(false);

            attackSprite.SetActive(true);
            attackSelected.SetActive(false);
            attackBuy.SetActive(false);
        }

        if (selection == 2)
        {
            pistolSprite.SetActive(true);
            pistolSelected.SetActive(false);
            pistolBuy.SetActive(false);

            shotgunSprite.SetActive(false);
            shotgunSelected.SetActive(true);
            shotgunBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                shotgunBuy.SetActive(true);
                UI_Shop.shop.BuyShotgun();
            }


            akSprite.SetActive(true);
            akSelected.SetActive(false);
            akBuy.SetActive(false);

            RPGSprite.SetActive(true);
            RPGSelected.SetActive(false);
            RPGBuy.SetActive(false);

            healthSprite.SetActive(true);
            healthSelected.SetActive(false);
            healthBuy.SetActive(false);

            attackSprite.SetActive(true);
            attackSelected.SetActive(false);
            attackBuy.SetActive(false);
        }

        if(selection == 3)
        {
            pistolSprite.SetActive(true);
            pistolSelected.SetActive(false);
            pistolBuy.SetActive(false);

            shotgunSprite.SetActive(true);
            shotgunSelected.SetActive(false);
            shotgunBuy.SetActive(false);

            akSprite.SetActive(false);
            akSelected.SetActive(true);
            akBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                akBuy.SetActive(true);
                UI_Shop.shop.BuyAK();
            }

            RPGSprite.SetActive(true);
            RPGSelected.SetActive(false);
            RPGBuy.SetActive(false);

            healthSprite.SetActive(true);
            healthSelected.SetActive(false);
            healthBuy.SetActive(false);

            attackSprite.SetActive(true);
            attackSelected.SetActive(false);
            attackBuy.SetActive(false);
        }

        if (selection == 4)
        {
            pistolSprite.SetActive(true);
            pistolSelected.SetActive(false);
            pistolBuy.SetActive(false);

            shotgunSprite.SetActive(true);
            shotgunSelected.SetActive(false);
            shotgunBuy.SetActive(false);

            akSprite.SetActive(true);
            akSelected.SetActive(false);
            akBuy.SetActive(false);

            RPGSprite.SetActive(false);
            RPGSelected.SetActive(true);
            RPGBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                RPGBuy.SetActive(true);
                UI_Shop.shop.BuyRPG();
            }
            healthSprite.SetActive(true);
            healthSelected.SetActive(false);
            healthBuy.SetActive(false);

            attackSprite.SetActive(true);
            attackSelected.SetActive(false);
            attackBuy.SetActive(false);
        }

        if (selection == 5)
        {
            pistolSprite.SetActive(true);
            pistolSelected.SetActive(false);
            pistolBuy.SetActive(false);

            shotgunSprite.SetActive(true);
            shotgunSelected.SetActive(false);
            shotgunBuy.SetActive(false);

            akSprite.SetActive(true);
            akSelected.SetActive(false);
            akBuy.SetActive(false);

            RPGSprite.SetActive(true);
            RPGSelected.SetActive(false);
            RPGBuy.SetActive(false);

            healthSprite.SetActive(false);
            healthSelected.SetActive(true);
            healthBuy.SetActive(false);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                UI_Shop.shop.BuyHealthUpgrade();
                //Debug.Log("i MADE IT!");
            }
            attackSprite.SetActive(true);
            attackSelected.SetActive(false);
            attackBuy.SetActive(false);
        }

        if (selection == 6)
        {
            pistolSprite.SetActive(true);
            pistolSelected.SetActive(false);
            pistolBuy.SetActive(false);

            shotgunSprite.SetActive(true);
            shotgunSelected.SetActive(false);
            shotgunBuy.SetActive(false);

            akSprite.SetActive(true);
            akSelected.SetActive(false);
            akBuy.SetActive(false);

            RPGSprite.SetActive(true);
            RPGSelected.SetActive(false);
            RPGBuy.SetActive(false);

            healthSprite.SetActive(true);
            healthSelected.SetActive(false);
            healthBuy.SetActive(false);

            attackSprite.SetActive(false);
            attackSelected.SetActive(true);
            attackBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                UI_Shop.shop.BuyAttackUpgrade();
            }
        }
    }
}
