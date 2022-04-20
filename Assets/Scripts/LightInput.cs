using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInput : MonoBehaviour
{
    float selection_Light;
    [Space(5)]
    [Header("Pistol")]
    public GameObject PistolSprite;
    public GameObject PistolSelected;

    [Space(5)]
    [Header("Banana")]
    public GameObject BananaSprite;
    public GameObject BananaSelected;


    [Space(5)]
    [Header("Bluster")]
    public GameObject BlusterSprite;
    public GameObject BlusterSelected;


    [Space(5)]
    [Header("Knife")]
    public GameObject KnifeSprite;
    public GameObject KnifeSelected;

    [Space(5)]
    [Header("Back")]
    public GameObject BackSprite;
    public GameObject BackSelected;

    [Space(5)]
    public GameObject PistolBuy;
    public GameObject BananaBuy;
    public GameObject BlusterBuy;
    public GameObject KnifeBuy;
    public GameObject BackBuy;

    const int MAX_SELECTION = 5;
    // Start is called before the first frame update
    void Start()
    {
        selection_Light = 0; // selection starts with 0


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) //checking input
        {
            //slection goes down
            if (selection_Light <= MAX_SELECTION)
            {
                selection_Light++;

            }

            if (selection_Light > MAX_SELECTION)
            {
                selection_Light = 1;

            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // selection goes up
            if (selection_Light >= 1)
            {
                selection_Light--;
            }

            if (selection_Light < 1)
            {
                selection_Light = MAX_SELECTION;
            }
        }

        if (selection_Light == 1)
        {

            PistolSprite.SetActive(false);
            PistolSelected.SetActive(true);
            PistolBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                PistolBuy.SetActive(true);
                UI_Shop.shop.BuyPistol();
            }

            BananaSprite.SetActive(true);
            BananaSelected.SetActive(false);
            BananaBuy.SetActive(false);

            BlusterSprite.SetActive(true);
            BlusterSelected.SetActive(false);
            BlusterBuy.SetActive(false);

            KnifeSprite.SetActive(true);
            KnifeSelected.SetActive(false);
            KnifeBuy.SetActive(false);

            BackSprite.SetActive(true);
            BackSelected.SetActive(false);
            BackBuy.SetActive(false);
        }

        if (selection_Light == 2)
        {

            BananaSprite.SetActive(false);
            BananaSelected.SetActive(true);
            BananaBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                BananaBuy.SetActive(true);
                UI_Shop.shop.BuyBanana();
            }

            PistolSprite.SetActive(true);
            PistolSelected.SetActive(false);
            PistolBuy.SetActive(false);

            BlusterSprite.SetActive(true);
            BlusterSelected.SetActive(false);
            BlusterBuy.SetActive(false);

            KnifeSprite.SetActive(true);
            KnifeSelected.SetActive(false);
            KnifeBuy.SetActive(false);

            BackSprite.SetActive(true);
            BackSelected.SetActive(false);
            BackBuy.SetActive(false);
        }
        if (selection_Light == 3)
        {
            BlusterSprite.SetActive(false);
            BlusterSelected.SetActive(true);
            BlusterBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                BlusterBuy.SetActive(true);
                UI_Shop.shop.BuyBlunder();
            }

            PistolSprite.SetActive(true);
            PistolSelected.SetActive(false);
            PistolBuy.SetActive(false);

            BananaSprite.SetActive(true);
            BananaSelected.SetActive(false);
            BananaBuy.SetActive(false);

            KnifeSprite.SetActive(true);
            KnifeSelected.SetActive(false);
            KnifeBuy.SetActive(false);

            BackSprite.SetActive(true);
            BackSelected.SetActive(false);
            BackBuy.SetActive(false);
        }

        if (selection_Light == 4)
        {
            KnifeSprite.SetActive(false);
            KnifeSelected.SetActive(true);
            KnifeBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                KnifeBuy.SetActive(true);
                UI_Shop.shop.BuyKnife();
            }

            BlusterSprite.SetActive(true);
            BlusterSelected.SetActive(false);
            BlusterBuy.SetActive(false);

            PistolSprite.SetActive(true);
            PistolSelected.SetActive(false);
            PistolBuy.SetActive(false);

            BananaSprite.SetActive(true);
            BananaSelected.SetActive(false);
            BananaBuy.SetActive(false);

            BackSprite.SetActive(true);
            BackSelected.SetActive(false);
            BackBuy.SetActive(false);
        }

        if (selection_Light == 5)
        {
            BackSprite.SetActive(false);
            BackSelected.SetActive(true);
            BackBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                BackBuy.SetActive(true);
                UI_Shop.shop.Back();
            }

            BlusterSprite.SetActive(true);
            BlusterSelected.SetActive(false);
            BlusterBuy.SetActive(false);

            PistolSprite.SetActive(true);
            PistolSelected.SetActive(false);
            PistolBuy.SetActive(false);

            BananaSprite.SetActive(true);
            BananaSelected.SetActive(false);
            BananaBuy.SetActive(false);

            KnifeSprite.SetActive(true);
            KnifeSelected.SetActive(false);
            KnifeBuy.SetActive(false);
        }

    }
}
