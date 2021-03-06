using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum LIGHT_WEAPONS
{
    PISTOL,
    BLUNDERBUSS,
    BANANA,
    KNIFE,

    NUM_LIGHT_WEAPONS
}

public enum HEAVY_WEAPONS
{
    AK,
    RIFLE,
    ROCKET,
    SHOTGUN,

    NUM_HEAVY_WEAPONS
}




public class UI_Shop : MonoBehaviour
{
    LIGHT_WEAPONS activeLight;
    HEAVY_WEAPONS activeHeavy;

    public static UI_Shop shop;
    [Space(5)]
    [SerializeField]
    Transform Container;
    [SerializeField]
    Transform HeavyContainer;
    [SerializeField]
    Transform LightContainer;
    [SerializeField]
    Transform MeleeContainer;

    [Space(5)]
    [SerializeField]
    Transform buyCheckPistol;
    [SerializeField]
    Transform buyCheckPistol2;
    [SerializeField]
    Transform buyCheckPistol3;

    [Space(5)]
    [SerializeField]
    Transform buyCheckAK;
    [SerializeField]
    Transform buyCheckAK2;
    [SerializeField]
    Transform buyCheckAK3;

    [Space(5)]
    [SerializeField]
    Transform buyCheckRPG;
    [SerializeField]
    Transform buyCheckRPG2;
    [SerializeField]
    Transform buyCheckRPG3;

    [Space(5)]
    [SerializeField]
    Transform buyCheckShotgun;
    [SerializeField]
    Transform buyCheckShotgun2;
    [SerializeField]
    Transform buyCheckShotgun3;

    [Space(5)]
    [SerializeField]
    Transform buyCheckBanana;
    [SerializeField]
    Transform buyCheckBanana2;
    [SerializeField]
    Transform buyCheckBanana3;

    [Space(5)]
    [SerializeField]
    Transform buyCheckBlunder;
    [SerializeField]
    Transform buyCheckBlunder2;
    [SerializeField]
    Transform buyCheckBlunder3;

    [Space(5)]
    [SerializeField]
    Transform buyCheckKnife;
    [SerializeField]
    Transform buyCheckKnife2;
    [SerializeField]
    Transform buyCheckKnife3;

    [Space(5)]
    [SerializeField]
    Transform buyCheckRifle;
    [SerializeField]
    Transform buyCheckRifle2;
    [SerializeField]
    Transform buyCheckRifle3;

    [Space(5)]
    public GameObject RPG;
    public GameObject shotgun;
    public GameObject pistol;
    public GameObject AK47;
    public GameObject Banana;
    public GameObject Blunder;
    public GameObject Knife;
    public GameObject Rifle;

    [Space(5)]
    public Text HealthCost;
    public Text HealthCost2;
    public Text HealthCost3;

    [Space(5)]
    public Text attackCost;
    public Text attackCost2;
    public Text attackCost3;

    [Space(5)]
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
       if(!HeavyContainer || !LightContainer || !MeleeContainer)
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
        //  Heavy
        if(activeHeavy == HEAVY_WEAPONS.ROCKET)
        {
            ShotgunSetFalse();
            AKSetFalse();
            RifleSetFalse();
            RPGSetActive();
        }
        if(activeHeavy == HEAVY_WEAPONS.SHOTGUN)
        {
            ShotgunSetActive();
            AKSetFalse();
            RifleSetFalse();
            RPGSetFalse();
        }
        if(activeHeavy == HEAVY_WEAPONS.AK)
        {
            ShotgunSetFalse();
            AKSetActive();
            RifleSetFalse();
            RPGSetFalse();
        }
        if (activeHeavy == HEAVY_WEAPONS.RIFLE)
        {
            ShotgunSetFalse();
            AKSetFalse();
            RifleSetActive();
            RPGSetFalse();
        }

        //  Light
        if (activeLight == LIGHT_WEAPONS.PISTOL)
        {
            BananaSetFalse();
            BlunderSetFalse();
            KnifeSetFalse();
            PistolSetActive();
        }
        if (activeLight == LIGHT_WEAPONS.BANANA)
        {
            BananaSetActive();
            BlunderSetFalse();
            KnifeSetFalse();
            PistolSetFalse();
        }
        if (activeLight == LIGHT_WEAPONS.BLUNDERBUSS)
        {
            BananaSetFalse();
            BlunderSetActive();
            KnifeSetFalse();
            PistolSetFalse();
        }
        if (activeLight == LIGHT_WEAPONS.KNIFE)
        {
            BananaSetFalse();
            BlunderSetFalse();
            KnifeSetActive();
            PistolSetFalse();
        }

    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("checking player collision");
            Container.gameObject.SetActive(true);
            ShopShown = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("checking player collision");
            Container.gameObject.SetActive(false);
            CloseLightShop();
            CloseMeleeShop();
            CloseHeavyShop();
            ShopShown = false;
        }

    }

    public void OpenHeavyShop()
    {
        HeavyContainer.gameObject.SetActive(true);
        ShopShown = true;
        CloseLightShop();
        CloseMeleeShop();
        Container.gameObject.SetActive(false);
    }
    void CloseHeavyShop()
    {
        HeavyContainer.gameObject.SetActive(false);
        //ShopShown = false;
    }

    public void OpenLightShop()
    {
        LightContainer.gameObject.SetActive(true);
        ShopShown = true;
        CloseHeavyShop();
        CloseMeleeShop();
        Container.gameObject.SetActive(false);
    }
    void CloseLightShop()
    {
        LightContainer.gameObject.SetActive(false);
        //ShopShown = false;
    }
    public void OpenMeleeShop()
    {
        MeleeContainer.gameObject.SetActive(true);
        ShopShown = true;
        CloseHeavyShop();
        CloseLightShop();
        Container.gameObject.SetActive(false);
    }
    void CloseMeleeShop()
    {
        MeleeContainer.gameObject.SetActive(false);
        //ShopShown = false;
    }

    public void Back()
    {
        CloseHeavyShop();
        CloseMeleeShop();
        CloseLightShop();
        Container.gameObject.SetActive(true);
    }
    public void BuyRPG()
    {

        if(Player.player.coins >= 150)
        {
            if (Player.player.GunPrefabs[((int)Player.GUN_TYPES.HEAVY_GUN)] == RPG)
            {
                Debug.Log("You already have this weapon");
                
            }
            else if(Player.player.GunPrefabs[((int)Player.GUN_TYPES.HEAVY_GUN)] != RPG)
            {
                Player.player.GunPrefabs[((int)Player.GUN_TYPES.HEAVY_GUN)] = RPG;
                Player.player.EquipWeapon();
                Player.player.coins -= 150;

                activeHeavy = HEAVY_WEAPONS.ROCKET;
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
            if(Player.player.GunPrefabs[((int)Player.GUN_TYPES.LIGHT_GUN)] == pistol)
            {
                Debug.Log("You already have this weapon");

            }
            else if(Player.player.GunPrefabs[((int)Player.GUN_TYPES.LIGHT_GUN)] != pistol)
            {
                Player.player.GunPrefabs[((int)Player.GUN_TYPES.LIGHT_GUN)] = pistol;
                Player.player.EquipWeapon();
                Player.player.coins -= 50;

                activeLight = LIGHT_WEAPONS.PISTOL;
            }

        }
        else
        {
            Debug.Log("Sorry! not enough coins for Pistol");
        }

       
    }

    public void BuyBanana()
    {
        if (Player.player.coins >= 100)
        {
            if (Player.player.GunPrefabs[((int)Player.GUN_TYPES.LIGHT_GUN)] == Banana)
            {
                Debug.Log("You already have this weapon");

            }
            else if (Player.player.GunPrefabs[((int)Player.GUN_TYPES.LIGHT_GUN)] != Banana)
            {
                Player.player.GunPrefabs[((int)Player.GUN_TYPES.LIGHT_GUN)] = Banana;
                Player.player.EquipWeapon();
                Player.player.coins -= 100;

                activeLight = LIGHT_WEAPONS.BANANA;
            }

        }
        else
        {
            Debug.Log("Sorry! not enough coins for Banana");
        }


    }

    public void BuyBlunder()
    {
        if (Player.player.coins >= 150)
        {
            if (Player.player.GunPrefabs[((int)Player.GUN_TYPES.LIGHT_GUN)] == Blunder)
            {
                Debug.Log("You already have this weapon");

            }
            else if (Player.player.GunPrefabs[((int)Player.GUN_TYPES.LIGHT_GUN)] != Blunder)
            {
                Player.player.GunPrefabs[((int)Player.GUN_TYPES.LIGHT_GUN)] = Blunder;
                Player.player.EquipWeapon();
                Player.player.coins -= 150;

                activeLight = LIGHT_WEAPONS.BLUNDERBUSS;
            }

        }
        else
        {
            Debug.Log("Sorry! not enough coins for Blunder");
        }


    }

    public void BuyKnife()
    {
        if (Player.player.coins >= 250)
        {
            if (Player.player.GunPrefabs[((int)Player.GUN_TYPES.LIGHT_GUN)] == Knife)
            {
                Debug.Log("You already have this weapon");

            }
            else if (Player.player.GunPrefabs[((int)Player.GUN_TYPES.LIGHT_GUN)] != Knife)
            {
                Player.player.GunPrefabs[((int)Player.GUN_TYPES.LIGHT_GUN)] = Knife;
                Player.player.EquipWeapon();
                Player.player.coins -= 250;

                activeLight = LIGHT_WEAPONS.KNIFE;
            }

        }
        else
        {
            Debug.Log("Sorry! not enough coins for Knife");
        }


    }
    public void BuyShotgun()
    {
        if (Player.player.coins >= 75)
        {
            if (Player.player.GunPrefabs[((int)Player.GUN_TYPES.HEAVY_GUN)] == shotgun)
            {
                Debug.Log("You already have this weapon");
                
            }
            else if (Player.player.GunPrefabs[((int)Player.GUN_TYPES.HEAVY_GUN)] != shotgun)
            {
                Player.player.GunPrefabs[((int)Player.GUN_TYPES.HEAVY_GUN)] = shotgun;
                Player.player.EquipWeapon();
                Player.player.coins -= 75;

                activeHeavy = HEAVY_WEAPONS.SHOTGUN;
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
            if (Player.player.GunPrefabs[((int)Player.GUN_TYPES.HEAVY_GUN)] == AK47)
            {
                Debug.Log("You already have this weapon");

               
            }
            else if (Player.player.GunPrefabs[((int)Player.GUN_TYPES.HEAVY_GUN)] != AK47)
            {
                Player.player.GunPrefabs[((int)Player.GUN_TYPES.HEAVY_GUN)] = AK47;
                Player.player.EquipWeapon();
                Player.player.coins -= 100;

                activeHeavy = HEAVY_WEAPONS.AK;
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
            if (Player.player.GunPrefabs[((int)Player.GUN_TYPES.HEAVY_GUN)] == Rifle)
            {
                Debug.Log("You already have this weapon");

            }
            else if (Player.player.GunPrefabs[((int)Player.GUN_TYPES.HEAVY_GUN)] != Rifle)
            {
                Player.player.GunPrefabs[((int)Player.GUN_TYPES.HEAVY_GUN)] = Rifle;
                Player.player.EquipWeapon();
                Player.player.coins -= 150;

                activeHeavy = HEAVY_WEAPONS.RIFLE;
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

    //rifle
    void RifleSetFalse()
    {
        buyCheckRifle.gameObject.SetActive(false);
        buyCheckRifle2.gameObject.SetActive(false);
        buyCheckRifle3.gameObject.SetActive(false);
    }
    void RifleSetActive()
    {
        buyCheckRifle.gameObject.SetActive(true);
        buyCheckRifle2.gameObject.SetActive(true);
        buyCheckRifle3.gameObject.SetActive(true);
    }
    //rpg
    void RPGSetFalse()
    {
        buyCheckRPG.gameObject.SetActive(false);
        buyCheckRPG2.gameObject.SetActive(false);
        buyCheckRPG3.gameObject.SetActive(false);
    }

    void RPGSetActive()
    {
        buyCheckRPG.gameObject.SetActive(true);
        buyCheckRPG2.gameObject.SetActive(true);
        buyCheckRPG3.gameObject.SetActive(true);
    }
    //pistol
    void PistolSetFalse()
    {
        buyCheckPistol.gameObject.SetActive(false);
        buyCheckPistol2.gameObject.SetActive(false);
        buyCheckPistol3.gameObject.SetActive(false);
    }

    void PistolSetActive()
    {
        buyCheckPistol.gameObject.SetActive(true);
        buyCheckPistol2.gameObject.SetActive(true);
        buyCheckPistol3.gameObject.SetActive(true);
    }
    //shotgun
    void ShotgunSetFalse()
    {
        buyCheckShotgun.gameObject.SetActive(false);
        buyCheckShotgun2.gameObject.SetActive(false);
        buyCheckShotgun3.gameObject.SetActive(false);
    }

    void ShotgunSetActive()
    {
        buyCheckShotgun.gameObject.SetActive(true);
        buyCheckShotgun2.gameObject.SetActive(true);
        buyCheckShotgun3.gameObject.SetActive(true);
    }
    //ak
    void AKSetFalse()
    {
        buyCheckAK.gameObject.SetActive(false);
        buyCheckAK2.gameObject.SetActive(false);
        buyCheckAK3.gameObject.SetActive(false);
    }

    void AKSetActive()
    {
        buyCheckAK.gameObject.SetActive(true);
        buyCheckAK2.gameObject.SetActive(true);
        buyCheckAK3.gameObject.SetActive(true);
    }
    //banana
    void BananaSetFalse()
    {
        buyCheckBanana.gameObject.SetActive(false);
        buyCheckBanana2.gameObject.SetActive(false);
        buyCheckBanana3.gameObject.SetActive(false);
    }

    void BananaSetActive()
    {
        buyCheckBanana.gameObject.SetActive(true);
        buyCheckBanana2.gameObject.SetActive(true);
        buyCheckBanana3.gameObject.SetActive(true);
    }
    //blunder
    void BlunderSetFalse()
    {
        buyCheckBlunder.gameObject.SetActive(false);
        buyCheckBlunder2.gameObject.SetActive(false);
        buyCheckBlunder3.gameObject.SetActive(false);
    }

    void BlunderSetActive()
    {
        buyCheckBlunder.gameObject.SetActive(true);
        buyCheckBlunder2.gameObject.SetActive(true);
        buyCheckBlunder3.gameObject.SetActive(true);
    }
    //knife
    void KnifeSetFalse()
    {
        buyCheckKnife.gameObject.SetActive(false);
        buyCheckKnife2.gameObject.SetActive(false);
        buyCheckKnife3.gameObject.SetActive(false);
    }

    void KnifeSetActive()
    {
        buyCheckKnife.gameObject.SetActive(true);
        buyCheckKnife2.gameObject.SetActive(true);
        buyCheckKnife3.gameObject.SetActive(true);
    }
}
