using ScriptableObjects;
using TMPro;
using UnityEngine;

public class ExpLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textExp;
    [SerializeField] private TextMeshProUGUI _textLevel;
    [SerializeField] private ScriptableEvent _expChange;
    [SerializeField] private IntegerValue _expValue;
    [SerializeField] public NestUnlocker _nestUnlocker;

    private int _levelExp = 0;
    private int _unlockNext = 0;
    public static int _level = 1;

    private void Awake()
    {
        _expValue.value = 0;
    }
    private void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        _levelExp += _expValue.value;
        ExpCounter();
        ExpText();
        CheckUnlock();
    }

    private void OnEnable()
    {
        _expChange.Subscribe(UpdateText);
    }

    private void OnDisable()
    {
        _expChange.Unsubscribe(UpdateText);
    }

    private void ExpText()
    {
        if (_level == 1) _textExp.text = $"Exp: {_levelExp}/100";
        if (_level == 2) _textExp.text = $"Exp: {_levelExp}/200";
        if (_level == 3) _textExp.text = $"Exp: {_levelExp}/400";
        if (_level >= 4) _textExp.text = $"Exp: {_levelExp}";
    }

    private void ExpCounter()
    {
        if (_level == 1 && _levelExp >= 100)
        {
            _levelExp -= 100;
            _level++;
            _unlockNext = 1;
        }

        if (_level == 2 && _levelExp >= 200)
        {
            _levelExp -= 200;
            _level++;
            _unlockNext = 1;
        }

        if (_level == 3 && _levelExp >= 400)
        {
            _levelExp -= 400;
            _level++;
            _unlockNext = 1;
        }
    }

    private void CheckUnlock()
    {
        _textLevel.text = "Lv. " + _level.ToString();
        if (_unlockNext == 1)
        {
            _nestUnlocker.NestUnlock();
            _unlockNext = 0;
        }
    }

}
