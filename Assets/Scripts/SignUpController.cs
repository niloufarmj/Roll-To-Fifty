using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignUpController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Button OKButton;
    [SerializeField] GameObject OKButtonUI, FilledOKButtonUI;
    [SerializeField] TMP_InputField NameText;

    public UserData userData;

    void Start()
    {
        if (!string.IsNullOrEmpty(userData.PlayerName))
        {
            SceneManager.LoadScene("MainMenu");
        }
        OKButton.onClick.AddListener(() => OkClicked());
    }

    private void FixedUpdate()
    {
        OKButton.interactable = !string.IsNullOrEmpty(NameText.text);
    }

    public void OkClicked()
    {
        OKButtonUI.SetActive(false);
        FilledOKButtonUI.SetActive(true);
        userData.PlayerName = NameText.text;
        SceneManager.LoadScene("MainMenu");
    }

}
