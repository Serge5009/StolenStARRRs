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

    public GameObject RPG;
    public GameObject shotgun;
    public GameObject pistol;
    public GameObject AK47;
    void Awake()
   {
        if (shop != null)
        {
            Destroy(shop);
        }
        else
        {
            shop = this;

        }
        
       //container = transform.Find("container");
       if(!container)
        {
            Debug.Log("Just checking container");
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
        if (collision.tag == "Player")
        {
            Debug.Log("checking player collision");
            container.gameObject.SetActive(true);
           
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("checking player collision");
            container.gameObject.SetActive(false);
        }

    }

    public void BuyRPG()
    {
        if(Player.player.coins >= 150)
        {
            Player.player.GunPrefab = RPG;
            Player.player.EquipWeapon();
            Player.player.coins -= 150;
        }
       
    }

    public void BuyPistol()
    {
        if (Player.player.coins >= 50)
        {
            Player.player.GunPrefab = pistol;
            Player.player.EquipWeapon();
            Player.player.coins -= 50;
        }
        
    }

    public void BuyShotgun()
    {
        if (Player.player.coins >= 75)
        {
            Player.player.GunPrefab = shotgun;
            Player.player.EquipWeapon();
            Player.player.coins -= 75;
        }
       
    }

    public void BuyAK()
    {
        if (Player.player.coins >= 100)
        {
            Player.player.GunPrefab = AK47;
            Player.player.EquipWeapon();
            Player.player.coins -= 100;
        }

    }
}
