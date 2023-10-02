using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine;

public class ShowingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private bool _isAnim;
    private bool _isActive;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isActive)
            {
                if (_isAnim)
                    _isAnim = false;
                else
                {
                    GameController.Instance.LevelController.StartGame();
                    _isActive = false;
                    gameObject.SetActive(false);
                }
            }
        }
    }

    public void ShowText(string text)
    {
        if (text == "")
        {
            GameController.Instance.LevelController.StartGame();
            gameObject.SetActive(false);
            return;
        }
        _isActive = true;
        if (_isAnim)
            StopAllCoroutines();
        StartCoroutine(SpawnSentence(text));
    }

    public void StartGame()
    {
        GameController.Instance.LevelController.StartGame();
        _isActive = false;
        gameObject.SetActive(false);
    }

    IEnumerator SpawnSentence(string sentence)
    {
        _isAnim = true;
        _text.text = "";
        foreach (char letter in sentence)
        {
            if (_isAnim)
            {
                _text.text += letter;
                yield return new WaitForSeconds(0.02f);
            }
            else
            {
                _text.text = sentence;
                break;
            }
        }
        _isAnim = false;
    }
}
