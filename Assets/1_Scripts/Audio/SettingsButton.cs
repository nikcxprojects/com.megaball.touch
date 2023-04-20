using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private PlayerPrefsVariables.List _playerPrefs;
    [SerializeField] private Image image;

    private bool _on;

    private void Start()
    {
        _on = PlayerPrefs.GetInt(PlayerPrefsVariables.GetByEnum(_playerPrefs), 1) == 1;
        UpdateUI();
    }

    public void Switch()
    {
        _on = !_on;
        UpdateUI();
    }
    
    private void UpdateUI()
    {
        if (_on)
        {
            image.color = Color.white;
            PlayerPrefs.SetInt(PlayerPrefsVariables.GetByEnum(_playerPrefs), 1);
        }
        else
        {
            image.color = Color.clear;
            PlayerPrefs.SetInt(PlayerPrefsVariables.GetByEnum(_playerPrefs), 0);
        }
    }
}
