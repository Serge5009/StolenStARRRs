using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Shop : MonoBehaviour
{
    public static UI_Shop shop;
    [SerializeField]
    Transform container;
    private Transform shopItemTemplate;

   void Awake()
   {/*
        if (shop != null)
        {
            Destroy(shop);
        }
        else
        {
            shop = this;

        }
        */
       //container = transform.Find("container");
       if(!container)
        {
            Debug.Log("asd");
        }
    }

    //public int cost1 = 200;
   

    private void Start()
    {
      

    }
    /*
    private void CreateItemButton(Sprite itemSprite, string itemName, int itemCost, int posIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 30f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * posIndex);

        shopItemTransform.Find("itemName").GetComponent<TextMeshPro>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshPro>().SetText(itemCost.ToString());

        shopItemTransform.Find("ItemImage").GetComponent<Image>().sprite = itemSprite;

    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Debug.Log("qwe");
            container.gameObject.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Debug.Log("qwe");
            container.gameObject.SetActive(false);
        }

    }
}
