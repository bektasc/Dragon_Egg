using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public Button _button;
    public GameObject _startScreen;

    private void Awake()
    {
        Time.timeScale = 0;
        Button btn = _button.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Time.timeScale = 1;
        Destroy(_startScreen);
    }

}
