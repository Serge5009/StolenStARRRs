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
    Transform LightContainer;
    [SerializeField]
    Transform MeleeContainer;

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

    [SerializeField]
    Transform buyCheckBanana;
    [SerializeField]
    Transform buyCheckBanana2;
    [SerializeField]
    Transform buyCheckBanana3;

    [SerializeField]
    Transform buyCheckBlunder;
    [SerializeField]
    Transform buyCheckBlunder2;
    [SerializeField]
    Transform buyCheckBlunder3;

    [SerializeField]
    Transform buyCheckKnife;
    [SerializeField]
    Transform buyCheckKnife2;
    [SerializeField]
    Transform buyCheckKnife3;

    [SerializeField]
    Transform buyCheckRifle;
    [SerializeField]
    Transform buyCheckRifle2;
    [SerializeField]
    Transform buyCheckRifle3;

    public GameObject RPG;
    public GameObject shotgun;
    public GameObject pistol;
    public GameObject AK47;
    public GameObject Banana;
    public GameObject Blunder;
    public GameObject Knife;
    public GameObject Rifle;

    public Text HealthCost;
    public Text HealthCost2;
    public Text HealthCost3;

    public Text attackCost;
    public Text attackCost2;
    public Text attackCost3;

    public int HCost = 100;
    public int ACost = 100;
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
       if(!container || !LightContainer || !MeleeContainer)
        {
            Debug.Log("Just checking container");
        }
    }

    //public int cost1 = 200;
   

    void Start()
    {
        

    }

    private void Update()
    {
        if(Player.player.GunPrefab == RPG)
        {
            PistolSetFalse();
            ShotgunSetFalse();
            AKSetFalse();
            RifleSetFalse();
        
        }
        else if(Player.player.GunPrefab == pistol)
        {
            RPGSetFalse();
            ShotgunSetFalse();
            AKSetFalse();
            RifleSetFalse();

        }
        else if(Player.player.GunPrefab == shotgun)
        {
            RPGSetFalse();
            PistolSetFalse();
            AKSetFalse();
            RifleSetFalse();
        }
        else if(Player.player.GunPrefab == AK47)
        {
            RPGSetFalse();
            PistolSetFalse();
            ShotgunSetFalse();
            RifleSetFalse();

        }

    }
   
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

    public void BuyRifle()
    {
        if (Player.player.coins >= 150)
        {
            if (Player.player.GunPrefab == Rifle)
            {
                Debug.Log("You already have this weapon");

            }
            else if (Player.player.GunPrefab != Rifle)
            {
                Player.player.GunPrefab = Rifle;
                Player.player.EquipWeapon();
                Player.player.coins -= 150;

                buyCheckRifle.gameObject.SetActive(true);
                buyCheckRifle2.gameObject.SetActive(true);
                buyCheckRifle3.gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Sorry! not enough coins for Rifle");
        }

    }

    public void BuyHealthUpgrade()
    {
                 
      if (Player.player.coins >= HCost)
      {
         Player.player.health += 10;
            Debug.Log("Player Health now:" + Player.player.health);
            Player.player.coins -= HCost;
         HCost = HCost * 2;

         HealthCost.text = HCost.ToString();
         HealthCost2.text = HCost.ToString();
         HealthCost3.text = HCost.ToString();

      }
        else
        {
            Debug.Log("Sorry! not enough coins for Health Upgrade");
        }

    }

    public void BuyAttackUpgrade()
    {
        if (Player.player.coins >= ACost)
        {

            //projScript.damage += 1;

            PowerUpsController powerControl = Player.player.gameObject.GetComponent<PowerUpsController>();
            powerControl.bonusATK += 5;

            //Debug.Log("Player Damage now" + projScript.damage);
            Player.player.coins -= ACost;
            ACost = ACost * 2;

            attackCost.text = ACost.ToString();
            attackCost2.text = ACost.ToString();
            attackCost3.text = ACost.ToString();

        }
        else
        {
            Debug.Log("Sorry! not enough coins for attack Upgrade");
        }
    }

    void RifleSetFalse()
    {
        buyCheckRifle.gameObject.SetActive(false);
        buyCheckRifle2.gameObject.SetActive(false);
        buyCheckRifle3.gameObject.SetActive(false);
    }

    void RPGSetFalse()
    {
        buyCheckRPG.gameObject.SetActive(false);
        buyCheckRPG2.gameObject.SetActive(false);
        buyCheckRPG3.gameObject.SetActive(false);
    }

    void PistolSetFalse()
    {
        buyCheckPistol.gameObject.SetActive(false);
        buyCheckPistol2.gameObject.SetActive(false);
        buyCheckPistol3.gameObject.SetActive(false);
    }

    void ShotgunSetFalse()
    {
        buyCheckShotgun.gameObject.SetActive(false);
        buyCheckShotgun2.gameObject.SetActive(false);
        buyCheckShotgun3.gameObject.SetActive(false);
    }

    void AKSetFalse()
    {
        buyCheckAK.gameObject.SetActive(false);
        buyCheckAK2.gameObject.SetActive(false);
        buyCheckAK3.gameObject.SetActive(false);
    }

    void BananaSetFalse()
    {
        buyCheckBanana.gameObject.SetActive(false);
        buyCheckBanana2.gameObject.SetActive(false);
        buyCheckBanana3.gameObject.SetActive(false);
    }

    void BlunderSetFalse()
    {
        buyCheckBlunder.gameObject.SetActive(false);
        buyCheckBlunder2.gameObject.SetActive(false);
        buyCheckBlunder3.gameObject.SetActive(false);
    }

    void KnifeSetFalse()
    {
        buyCheckKnife.gameObject.SetActive(false);
        buyCheckKnife2.gameObject.SetActive(false);
        buyCheckKnife3.gameObject.SetActive(false);
    }
}
