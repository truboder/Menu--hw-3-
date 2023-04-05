using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static readonly float MaxHealth = 50f;
    public static readonly float MinHealth = 0f;

    [SerializeField] private ValueChangeDown _sliderChanger;

    private float _health = MaxHealth;

    public void Hit(float value)
    {
        if (_health - value >= MinHealth)
        {
            _health -= value;
        }
        else
        {
            _health = MinHealth;
        }

        _sliderChanger.OnButtonClicked(-value);
    }

    public void Heal(float value)
    {
        if (_health + value <= MaxHealth)
        {
            _health += value;
        }
        else
        {
            _health = MaxHealth;
        }
        
        _sliderChanger.OnButtonClicked(value);
    }
}
