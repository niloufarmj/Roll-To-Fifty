using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    [SerializeField] Image filledProgressBar;
    public float fillDuration = 10f; // Fill duration in seconds

    private float fillStartTime;

    public UserData userData;

    void Start()
    {
        fillStartTime = Time.time;
        filledProgressBar.type = Image.Type.Filled;
    }

    void Update()
    {
        float elapsedTime = Time.time - fillStartTime;
        float fillAmount = Mathf.Clamp01(elapsedTime / fillDuration);

        if (fillAmount > 0.9f)
        {
            if (!string.IsNullOrEmpty(userData.PlayerName))
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                SceneManager.LoadScene("SignUp");
            }
            
        }

        filledProgressBar.fillAmount = fillAmount;
    }


}
