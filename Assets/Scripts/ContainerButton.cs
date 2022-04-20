using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerButton : MonoBehaviour
{
    float selection_Container;
    [Space(5)]
    [Header("Heavy")]
    public GameObject HeavySprite;
    public GameObject HeavySelected;
    [Space(5)]
    [Header("Light")]
    public GameObject LightSprite;
    public GameObject LightSelected;

    [Space(5)]
    [Header("Melee")]
    public GameObject MeleeSprite;
    public GameObject MeleeSelected;

    [Space(5)]
    public GameObject HContainerBuy;
    public GameObject LContainerBuy;
    public GameObject MContainerBuy;

    const int MAX_SELECTION = 3;
    // Start is called before the first frame update
    void Start()
    {
        selection_Container = 0; // selection starts with 0


    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) //checking input
        {
            //slection goes down
            if (selection_Container <= MAX_SELECTION)
            {
                selection_Container++;

            }

            if (selection_Container > MAX_SELECTION)
            {
                selection_Container = 1;

            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // selection goes up
            if (selection_Container >= 1)
            {
                selection_Container--;
            }

            if (selection_Container < 1)
            {
                selection_Container = MAX_SELECTION;
            }
        }
        
        if (selection_Container == 1)
        {

            LightSprite.SetActive(false);
            LightSelected.SetActive(true);
            LContainerBuy.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LContainerBuy.SetActive(true);
                UI_Shop.shop.OpenLightShop();
            }

            HeavySprite.SetActive(true);
            HeavySelected.SetActive(false);
            HContainerBuy.SetActive(false);

            MeleeSprite.SetActive(true);
            MeleeSelected.SetActive(false);
            MContainerBuy.SetActive(false);
        }

        if (selection_Container == 3)
        {
            HeavySprite.SetActive(false);
            HeavySelected.SetActive(true);
            HContainerBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                HContainerBuy.SetActive(true);
                UI_Shop.shop.OpenHeavyShop();
            }
            LightSprite.SetActive(true);
            LightSelected.SetActive(false);
            LContainerBuy.SetActive(false);

            MeleeSprite.SetActive(true);
            MeleeSelected.SetActive(false);
            MContainerBuy.SetActive(false);

        }

        if (selection_Container == 2)
        {
            MeleeSprite.SetActive(false);
            MeleeSelected.SetActive(true);
            MContainerBuy.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                MContainerBuy.SetActive(true);
                UI_Shop.shop.OpenMeleeShop();
            }

            LightSprite.SetActive(true);
            LightSelected.SetActive(false);
            LContainerBuy.SetActive(false);

            HeavySprite.SetActive(true);
            HeavySelected.SetActive(false);
            HContainerBuy.SetActive(false);
        }

    }

}
        