using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeInput : MonoBehaviour
{
    float selection_Melee;
    [Space(5)]
    [Header("Health")]
    public GameObject HealthSprite;
    public GameObject HealthSelected;
    [Space(5)]
    [Header("Attack")]
    public GameObject AttackSprite;
    public GameObject AttackSelected;

    [Space(5)]
    [Header("Back")]
    public GameObject BackSprite;
    public GameObject BackSelected;

    [Space(5)]
    public GameObject HealthBuy;
    public GameObject AttackBuy;
    public GameObject BackBuy;

    const int MAX_SELECTION = 3;
    // Start is called before the first frame update
    void Start()
    {
        selection_Melee = 0; // selection starts with 0


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) //checking input
        {
            //slection goes down
            if (selection_Melee <= MAX_SELECTION)
            {
                selection_Melee++;

            }

            if (selection_Melee > MAX_SELECTION)
            {
                selection_Melee = 1;

            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // selection goes up
            if (selection_Melee >= 1)
            {
                selection_Melee--;
            }

            if (selection_Melee < 1)
            {
                selection_Melee = MAX_SELECTION;
            }
        }

        if (selection_Melee == 1)
        {

            HealthSprite.SetActive(false);
            HealthSelected.SetActive(true);
            HealthBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                UI_Shop.shop.BuyHealthUpgrade();
               
            }
            AttackSprite.SetActive(true);
            AttackSelected.SetActive(false);
            AttackBuy.SetActive(false);

            BackSprite.SetActive(true);
            BackSelected.SetActive(false);
            BackBuy.SetActive(false);
        }

        if (selection_Melee == 2)
        {
            HealthSprite.SetActive(true);
            HealthSelected.SetActive(false);
            HealthBuy.SetActive(false);

            AttackSprite.SetActive(false);
            AttackSelected.SetActive(true);
            AttackBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                UI_Shop.shop.BuyAttackUpgrade();
            }
            BackSprite.SetActive(true);
            BackSelected.SetActive(false);
            BackBuy.SetActive(false);
        }

        if (selection_Melee == 3)
        {
            BackSprite.SetActive(false);
            BackSelected.SetActive(true);
            BackBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                BackBuy.SetActive(true);
                UI_Shop.shop.Back();
            }

            HealthSprite.SetActive(true);
            HealthSelected.SetActive(false);
            HealthBuy.SetActive(false);

            AttackSprite.SetActive(true);
            AttackSelected.SetActive(false);
            AttackBuy.SetActive(false);
        }

    }
}
