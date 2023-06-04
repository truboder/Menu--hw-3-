using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class ValueChangeDown : MonoBehaviour
{
    [SerializeField] private Slider _healthbar;
    [SerializeField] private float _loopTime;

    public static UnityEvent ChangeValue;

    public static float Value = 0;
    private float _epsilon = 0.01f;
    private Coroutine _coroutine;

    private void Start()
    {
        _healthbar.maxValue = Player.MaxHealth;
        _healthbar.minValue = Player.MinHealth;
        _healthbar.value = Player.MaxHealth;

        ChangeValue = new UnityEvent();

        ChangeValue.AddListener(StartMovement);       
    }

    public void StartMovement()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(MoveSlider());
        Debug.Log("Work");
    }
    
    private IEnumerator MoveSlider()
    {         
        while (Mathf.Abs(Value) > _epsilon)
        {
            float speedBySecond = Value / _loopTime;
            float speedByUpdate = speedBySecond * Time.deltaTime;

            if (speedByUpdate > 0)
            {
                Value = Mathf.Clamp(Value - speedByUpdate, 0, Value);
            }
            else
            {
                Value = Mathf.Clamp(Value + speedByUpdate, Value, 0);
            }

            _healthbar.value = Mathf.Clamp(_healthbar.value + speedByUpdate, _healthbar.minValue, _healthbar.maxValue);

            yield return new WaitForFixedUpdate();
        }
    }

    public void OnButtonClicked(float value)
    {
        Value += value;
    }
}
