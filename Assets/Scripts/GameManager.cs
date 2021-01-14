using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager S;
    private int _baseHealth = 100;
    private int _baseDamage = 10;

    private float _baseHealthUISize;

    [SerializeField]
    private RectTransform _healthUI;

    private void Awake()
    {
        S = this;
    }

    private void Start()
    {
        _baseHealthUISize = _healthUI.sizeDelta.x;
    }

    public void TakeDamage()
    {
        _baseHealth -= _baseDamage;
        _healthUI.sizeDelta = new Vector2(_baseHealth * _baseHealthUISize / 100f, _healthUI.sizeDelta.y);
    }
}
