using GameResources;
using ScriptableObjects;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private ScriptableEvent _flameChange;
    [SerializeField] private IntegerValue _flameValue;
 

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
        Debug.Log($"Sold item for {item._goldValue} gold");
        _flameValue.value += item._goldValue;
        _flameChange.InvokeAction();
        Destroy(item.gameObject);
    }
}
