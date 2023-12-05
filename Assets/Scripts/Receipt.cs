using GameResources;
using UnityEngine;

[CreateAssetMenu(fileName = "New Receipt", menuName = "Arcade/Receipt")]

public class Receipt : ScriptableObject
{
    
    public Eggs _eggs;
    public float _GenerateTime;
}
