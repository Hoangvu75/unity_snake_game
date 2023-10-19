using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CooldownText : MonoBehaviour
{
    public Text textComponent;
    private Player _playerScript;
    private GameObject _cooldownDialog;

    void Start()
    {
        textComponent = GetComponent<Text>();
        textComponent.text = "3";
        
        var playerObject = GameObject.FindWithTag("Player");
        _playerScript = playerObject.GetComponent<Player>();

        _cooldownDialog = GameObject.FindWithTag("CooldownDialog");
    }

    private void Update()
    {
        textComponent.text = Math.Round((decimal)_playerScript.delayTimer, 1).ToString(CultureInfo.InvariantCulture);
        if (_playerScript.delayTimer <= 0f)
        {
            Destroy(_cooldownDialog);
        }
    }
}
