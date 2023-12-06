using GameResources;
using ScriptableObjects;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private ScriptableEvent _flameChange;
    [SerializeField] private ScriptableEvent _expChange;
    [SerializeField] private IntegerValue _flameValue;
    [SerializeField] private IntegerValue _expValue;


    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerInteraction player)) return;

        if (player.HoldingItem != null)
        {
            SellItem(player.HoldingItem);
        }
    }

    private void SellItem(Eggs item)
    {
        Debug.Log($"Sold item for {item._eggValue} flame!");
        _flameValue.value += item._eggValue;
        _flameChange.InvokeAction();

        _expValue.value = item._experience;
        _expChange.InvokeAction();
        Destroy(item.gameObject);
    }
}
