using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI Instance { get; private set; }

    private Transform sitBtn;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        sitBtn = transform.Find("sitBtn");
        sitBtn.gameObject.SetActive(false);
    }
    public void ShowHint()
    {
        sitBtn.gameObject.SetActive(true);
    }
    public void HideHint()
    {
        sitBtn.gameObject.SetActive(false);
    }
}
