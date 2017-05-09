using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public UIManager uim;
    public WaveManager wm;

    private void Start()
    {
        uim = GameObject.FindWithTag("UIM").GetComponent<UIManager>();
        wm = GameObject.FindWithTag("GM").GetComponent<WaveManager>();

        uim.StartCoroutine(uim.FadeIn());
        wm.StartCountDown();
    }

    private void Update()
    {
        if (Input.GetButton("c"))
        {
            uim.statsPanel.SetActive(true);
        }

        if (Input.GetButtonUp("c"))
        {
            uim.statsPanel.SetActive(false);
        }
    }
}
