using System;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance { get; private set; }

    [SerializeField] private int money;

    public int CurrentMoney => money;

    public event Action<int> OnMoneyChanged;

    private void Awake()
    {
        Instance = this;
    }

    public void AddMoney(int _moneyValue)
    {
        money += _moneyValue;

        OnMoneyChanged?.Invoke(money);
    }

    public void SpendMoney(int _spendValue)
    {
        money -= _spendValue;
    }

    public bool CanAfford(int _value)
    {
        return money >= _value;
    }
}
