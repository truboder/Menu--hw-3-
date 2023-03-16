using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueChangeDown : MonoBehaviour
{
    [SerializeField] private Slider _healthbar;
    [SerializeField] private float _loopTime;

    private float _value = 0;
    private float _epsilon = 0.01f;

    private void Start()
    {
        _healthbar.maxValue = Player.MaxHealth;
        _healthbar.minValue = Player.MinHealth;
        _healthbar.value = Player.MaxHealth;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_value) > _epsilon)
        {
            MoveSlider();
        }
    }
    
    private void MoveSlider()
    {        
        if (Mathf.Abs(_value) > _epsilon)
        {
            float speedBySecond = _value / _loopTime;
            float speedByUpdate = speedBySecond * Time.deltaTime;

            Debug.Log($"spByUp - {speedByUpdate}\n sumHlthSpByUp - {_healthbar.value + speedByUpdate}");

            if (speedByUpdate > 0)
            {
                if (_healthbar.value + speedByUpdate > _healthbar.maxValue)
                {
                    _healthbar.value = _healthbar.maxValue;
                    _value = 0;
                }
                else
                {
                    _value -= speedByUpdate;
                    _healthbar.value += speedByUpdate;
                }
            }
            else
            {
                if (_healthbar.value + speedByUpdate < _healthbar.minValue)
                {
                    _healthbar.value = _healthbar.minValue;
                    _value = 0;
                }
                else
                {
                    _value -= speedByUpdate;
                    _healthbar.value += speedByUpdate;
                }
            }
        }
    }

    public void OnButtonClicked(float value)
    {
        _value += value;
    }
}
