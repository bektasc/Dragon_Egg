using ScriptableObjects;
using TMPro;
using UnityEngine;

public class FlameText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private ScriptableEvent _flameChange;
    [SerializeField] private IntegerValue _flameValue;

    private void Awake()
    {
        _flameValue.value = 600;
    }
    private void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        _text.text = _flameValue.value.ToString();
    }

    private void OnEnable()
    {
        _flameChange.Subscribe(UpdateText);
    }

    private void OnDisable()
    {
        _flameChange.Unsubscribe(UpdateText);
    }

}
