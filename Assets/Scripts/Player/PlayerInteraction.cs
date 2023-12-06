using GameResources;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform _holdingPoint;

    public Eggs HoldingItem {  get; set; }
    private void OnTriggerEnter(Collider other)
    {
        if (HoldingItem != null) return;
        
        if (!other.TryGetComponent(out EggGenerator generator)) return;

        if (generator.HoldingItem == null)return;

        generator.HoldingItem.transform.position = _holdingPoint.position;
        generator.HoldingItem.transform.parent = _holdingPoint;
        HoldingItem = generator.HoldingItem;
        generator.HoldingItem = null;
        generator.Restart();
    }
}
