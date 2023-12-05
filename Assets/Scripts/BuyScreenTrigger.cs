using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuyScreenTrigger : MonoBehaviour
{
    [SerializeField] private IntegerValue _flameValue;
    [SerializeField] private ScriptableEvent _flameChange;
    [SerializeField] private TextMeshProUGUI _noMoneyText;
    [SerializeField] private TextMeshProUGUI _buyText;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private GameObject DragonNest;
    
    public GameObject buyPanel;
    public GameObject willBeDestroyed;
    private GameObject currentNest;
    
    public Button buyButton;

    

    private int _price;
    private string _item;

    private void OnTriggerEnter(Collider other)
    {
        currentNest = DragonNest;
        buyPanel.SetActive(true);

        BuyNest();
        
        Button btn = buyButton.GetComponent<Button>();
        btn.onClick.RemoveAllListeners();   //declaring multiple listeners are available. add listener adds new listener instead of override
        UnityAction action1 = TaskOnClick;
        btn.onClick.AddListener(action1);

        /* Buraya mümkün bir örnek býrakýyorum
         * btn.onClick.RemoveListener(TaskOnClick);
         * btn.onClick.AddListener(TaskOnClick);
         */

        _buyText.text = $"Do you want to buy {_item}?";
        _buttonText.text = $"{_price}";
        _noMoneyText.text = "";
    }
    
    private void OnTriggerExit(Collider other)
    {
        buyPanel.SetActive(false);
    }

    private void TaskOnClick()
    {
        if (_flameValue.value >= _price)
        {
            currentNest.SetActive(true);
            _flameValue.value -= _price;
            _flameChange.InvokeAction();
            Destroy(willBeDestroyed);
            buyPanel.SetActive(false);
        }

        else _noMoneyText.text = "Not Enough Flame!";
    }

    private void BuyNest()
    {
        if (DragonNest.name.Equals("WindDragonNest"))
        {
            _price = 50;
            _item = "Wind Dragon Nest";
        }

        if (DragonNest.name.Equals("SkyDragonNest"))
        {
            _price = 100;
            _item = "Sky Dragon Nest";
        }

        if (DragonNest.name.Equals("SoulDragonNest"))
        {
            _price = 200;
            _item = "Soul Dragon Nest";
        }

        if (DragonNest.name.Equals("FireDragonNest"))
        {
            _price = 300;
            _item = "Fire Dragon Nest";
        }
    }

}
