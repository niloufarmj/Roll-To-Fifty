using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] public GameObject PlayButtonUI, PlayButtonFilledUI;
    [SerializeField] public Button PlayButton;

    private void Start()
    {
        PlayButton.onClick.AddListener(() => playClicked());
    }

    public void playClicked()
    {
        PlayButtonFilledUI.SetActive(true);
        PlayButtonUI.SetActive(false);
        SceneManager.LoadScene("Game");
    }

}
