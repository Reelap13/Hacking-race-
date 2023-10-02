using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        _text.text = _levelNumber.ToString();
    }

    private void OnMouseDown()
    {
        LoadLevel();
    }

    public void LoadLevel()
    {
        PlayerPrefs.SetInt("Level_number", _levelNumber);
        SceneManager.LoadScene(1);
    }
}
