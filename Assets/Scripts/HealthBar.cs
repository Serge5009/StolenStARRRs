using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image Square;
    public float CurrentHealth; //= Player.player.health;
    private float MaxHealth = 100f;

    private void Start()
    {
        Square = GetComponent<Image>();
    }

    private void Update()
    {
        CurrentHealth = Player.player.health;
        Square.fillAmount = CurrentHealth / MaxHealth;
    }
}
