using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonController : MonoBehaviour
{
    [SerializeField] public GameObject FilledPlayButton;
    private void OnMouseEnter()
    {
        FilledPlayButton.SetActive(true);
    }

    private void OnMouseExit()
    {
        FilledPlayButton.SetActive(false);
    }
}
