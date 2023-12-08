using GameResources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject rareDragon;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerInteraction player)) return;
        
        if (player.HoldingItem != null)
        {
            WinGame(player.HoldingItem);
        }
    }

    private void WinGame(Eggs item)
    {
        if (item.name == "RareEgg(Clone)")
        {
            winScreen.SetActive(true);
            rareDragon.SetActive(true);
            Time.timeScale = 0;
        }
    }
     
}
