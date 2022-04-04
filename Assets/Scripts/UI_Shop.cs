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
    [SerializeField]
    Transform buyCheckPistol;
    [SerializeField]
    Transform buyCheckPistol2;
    [SerializeField]
    Transform buyCheckPistol3;

    [SerializeField]
    Transform buyCheckAK;
    [SerializeField]
    Transform buyCheckAK2;
    [SerializeField]
    Transform buyCheckAK3;

    [SerializeField]
    Transform buyCheckRPG;
    [SerializeField]
    Transform buyCheckRPG2;
    [SerializeField]
    Transform buyCheckRPG3;

    [SerializeField]
    Transform buyCheckShotgun;
    [SerializeField]
    Transform buyCheckShotgun2;
    [SerializeField]
    Transform buyCheckShotgun3;

    public GameObject RPG;
    public GameObject shotgun;
    public GameObject pistol;
    public GameObject AK47;
    public Text HealthCost;
    public Text HealthCost2;
    public Text HealthCost3;
    public int cost = 100;
    public bool ShopShown = false;

    private Transform shopItemTemplate;
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

    private void Update()
    {
        if(Player.player.GunPrefab == RPG)
        {
            /*
            buyCheckRPG.gameObject.SetActive(false);
            buyCheckRPG2.gameObject.SetActive(false);
            buyCheckRPG3.gameObject.SetActive(false);
            */
            buyCheckPistol.gameObject.SetActive(false);
            buyCheckPistol2.gameObject.SetActive(false);
            buyCheckPistol3.gameObject.SetActive(false);

            buyCheckShotgun.gameObject.SetActive(false);
            buyCheckShotgun2.gameObject.SetActive(false);
            buyCheckShotgun3.gameObject.SetActive(false);

            buyCheckAK.gameObject.SetActive(false);
            buyCheckAK2.gameObject.SetActive(false);
            buyCheckAK3.gameObject.SetActive(false);
        }
        else if(Player.player.GunPrefab == pistol)
        {
            buyCheckShotgun.gameObject.SetActive(false);
            buyCheckShotgun2.gameObject.SetActive(false);
            buyCheckShotgun3.gameObject.SetActive(false);

            buyCheckAK.gameObject.SetActive(false);
            buyCheckAK2.gameObject.SetActive(false);
            buyCheckAK3.gameObject.SetActive(false);

            buyCheckRPG.gameObject.SetActive(false);
            buyCheckRPG2.gameObject.SetActive(false);
            buyCheckRPG3.gameObject.SetActive(false);

        }
        else if(Player.player.GunPrefab == shotgun)
        {
            buyCheckRPG.gameObject.SetActive(false);
            buyCheckRPG2.gameObject.SetActive(false);
            buyCheckRPG3.gameObject.SetActive(false);

            buyCheckPistol.gameObject.SetActive(false);
            buyCheckPistol2.gameObject.SetActive(false);
            buyCheckPistol3.gameObject.SetActive(false);

            buyCheckAK.gameObject.SetActive(false);
            buyCheckAK2.gameObject.SetActive(false);
            buyCheckAK3.gameObject.SetActive(false);
        }
        else if(Player.player.GunPrefab == AK47)
        {
            
           buyCheckRPG.gameObject.SetActive(false);
           buyCheckRPG2.gameObject.SetActive(false);
           buyCheckRPG3.gameObject.SetActive(false);
           
            buyCheckPistol.gameObject.SetActive(false);
            buyCheckPistol2.gameObject.SetActive(false);
            buyCheckPistol3.gameObject.SetActive(false);

            buyCheckShotgun.gameObject.SetActive(false);
            buyCheckShotgun2.gameObject.SetActive(false);
            buyCheckShotgun3.gameObject.SetActive(false);
        }

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
            ShopShown = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("checking player collision");
            container.gameObject.SetActive(false);
            ShopShown = false;
        }

    }

    public void BuyRPG()
    {

        if(Player.player.coins >= 150)
        {
            if (Player.player.GunPrefab == RPG)
            {
                Debug.Log("You already have this weapon");
                
            }
            else if(Player.player.GunPrefab != RPG)
            {
                Player.player.GunPrefab = RPG;
                Player.player.EquipWeapon();
                Player.player.coins -= 150;

                buyCheckRPG.gameObject.SetActive(true);
                buyCheckRPG2.gameObject.SetActive(true);
                buyCheckRPG3.gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Sorry! not enough coins for RPG");
        }

    }

    public void BuyPistol()
    {
        if (Player.player.coins >= 50)
        {
            if(Player.player.GunPrefab == pistol)
            {
                Debug.Log("You already have this weapon");

                

            }
            else if(Player.player.GunPrefab != pistol)
            {
                Player.player.GunPrefab = pistol;
                Player.player.EquipWeapon();
                Player.player.coins -= 50;

                buyCheckPistol.gameObject.SetActive(true);
                buyCheckPistol2.gameObject.SetActive(true);
                buyCheckPistol3.gameObject.SetActive(true);
            }
           
        }
        else
        {
            Debug.Log("Sorry! not enough coins for Pistol");
        }

       
    }

    public void BuyShotgun()
    {
        if (Player.player.coins >= 75)
        {
            if (Player.player.GunPrefab == shotgun)
            {
                Debug.Log("You already have this weapon");
                
            }
            else if (Player.player.GunPrefab != shotgun)
            {
                Player.player.GunPrefab = shotgun;
                Player.player.EquipWeapon();
                Player.player.coins -= 75;

                buyCheckShotgun.gameObject.SetActive(true);
                buyCheckShotgun2.gameObject.SetActive(true);
                buyCheckShotgun3.gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Sorry! not enough coins for Shotgun");
        }

    }

    public void BuyAK()
    {
        if (Player.player.coins >= 100)
        {
            if (Player.player.GunPrefab == AK47)
            {
                Debug.Log("You already have this weapon");

               
            }
            else if (Player.player.GunPrefab != AK47)
            {
                Player.player.GunPrefab = AK47;
                Player.player.EquipWeapon();
                Player.player.coins -= 100;

                buyCheckAK.gameObject.SetActive(true);
                buyCheckAK2.gameObject.SetActive(true);
                buyCheckAK3.gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Sorry! not enough coins for AK");
        }

    }

    public void BuyHealthUpgrade()
    {
                 
      if (Player.player.coins >= cost)
      {
         Player.player.health += 10;
         Player.player.coins -= cost;
         cost = cost * 2;

         HealthCost.text = cost.ToString();
         HealthCost2.text = cost.ToString();
         HealthCost3.text = cost.ToString();

      }
        else
        {
            Debug.Log("Sorry! not enough coins for Health Upgrade");
        }

    }

}
