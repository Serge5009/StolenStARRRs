using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyInput : MonoBehaviour
{

    float selection_Heavy;
    [Space(5)]
    [Header("Rifle")]
    public GameObject RifleSprite;
    public GameObject RifleSelected;

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
    [Header("Back")]
    public GameObject BackSprite;
    public GameObject BackSelected;

    [Space(5)]
    public GameObject RifleBuy;
    public GameObject shotgunBuy;
    public GameObject akBuy;
    public GameObject RPGBuy;
    public GameObject BackBuy;

    const int MAX_SELECTION = 5;
    // Start is called before the first frame update
    void Start()
    {
        selection_Heavy = 0; // selection starts with 0


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) //checking input
        {
            //slection goes down
            if (selection_Heavy <= MAX_SELECTION)
            {
                selection_Heavy++;

            }

            if (selection_Heavy > MAX_SELECTION)
            {
                selection_Heavy = 1;

            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // selection goes up
            if (selection_Heavy >= 1)
            {
                selection_Heavy--;
            }

            if (selection_Heavy < 1)
            {
                selection_Heavy = MAX_SELECTION;
            }
        }

        if (selection_Heavy == 1)
        {

            RifleSprite.SetActive(false);
            RifleSelected.SetActive(true);
            RifleBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                RifleBuy.SetActive(true);
                UI_Shop.shop.BuyRifle();

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

            BackSprite.SetActive(true);
            BackSelected.SetActive(false);
            BackBuy.SetActive(false);
        }

        if (selection_Heavy == 2)
        {
            shotgunSprite.SetActive(false);
            shotgunSelected.SetActive(true);
            shotgunBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                shotgunBuy.SetActive(true);
                UI_Shop.shop.BuyShotgun();
            }

            RifleSprite.SetActive(true);
            RifleSelected.SetActive(false);
            RifleBuy.SetActive(false);

            akSprite.SetActive(true);
            akSelected.SetActive(false);
            akBuy.SetActive(false);

            RPGSprite.SetActive(true);
            RPGSelected.SetActive(false);
            RPGBuy.SetActive(false);

            BackSprite.SetActive(true);
            BackSelected.SetActive(false);
            BackBuy.SetActive(false);
        }
        if (selection_Heavy == 3)
        {
            akSprite.SetActive(false);
            akSelected.SetActive(true);
            akBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                akBuy.SetActive(true);
                UI_Shop.shop.BuyAK();
            }

            shotgunSprite.SetActive(true);
            shotgunSelected.SetActive(false);
            shotgunBuy.SetActive(false);

            RifleSprite.SetActive(true);
            RifleSelected.SetActive(false);
            RifleBuy.SetActive(false);

            RPGSprite.SetActive(true);
            RPGSelected.SetActive(false);
            RPGBuy.SetActive(false);

            BackSprite.SetActive(true);
            BackSelected.SetActive(false);
            BackBuy.SetActive(false);
        }

        if(selection_Heavy == 4)
        {
            RPGSprite.SetActive(false);
            RPGSelected.SetActive(true);
            RPGBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                RPGBuy.SetActive(true);
                UI_Shop.shop.BuyRPG();
            }

            RifleSprite.SetActive(true);
            RifleSelected.SetActive(false);
            RifleBuy.SetActive(false);

            shotgunSprite.SetActive(true);
            shotgunSelected.SetActive(false);
            shotgunBuy.SetActive(false);

            akSprite.SetActive(true);
            akSelected.SetActive(false);
            akBuy.SetActive(false);

            BackSprite.SetActive(true);
            BackSelected.SetActive(false);
            BackBuy.SetActive(false);
        }

        if (selection_Heavy == 5)
        {
            BackSprite.SetActive(false);
            BackSelected.SetActive(true);
            BackBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                BackBuy.SetActive(true);
                UI_Shop.shop.Back();
            }
            shotgunSprite.SetActive(true);
            shotgunSelected.SetActive(false);
            shotgunBuy.SetActive(false);

            RifleSprite.SetActive(true);
            RifleSelected.SetActive(false);
            RifleBuy.SetActive(false);

            akSprite.SetActive(true);
            akSelected.SetActive(false);
            akBuy.SetActive(false);

            RPGSprite.SetActive(true);
            RPGSelected.SetActive(false);
            RPGBuy.SetActive(false);
        }

    }
}
