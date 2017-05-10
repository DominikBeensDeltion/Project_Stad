using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [Header("Player")]
    public GameObject player;

    [Header("Fade")]
    public Image fadeOverlay;

    [Header("Inventory")]
    public GameObject inventoryPanel;

    [Header("Pause Menu")]
    public bool gamePaused;
    public bool canPause = true;

    [Header("WaveCountdown")]
    public WaveManager wm;
    public Text waveText;
    public Text countdownText;

    [Header("Ammo")]                        //TEMP
    public Text currentAmmoText;            //TEMP
    public Text totalAmmoText;              //TEMP
    public AttackShuriken attackShurken;    //TEMP

    [Header("Notice")]
    public GameObject noticeTextPanel;
    public Text noticeText;
    public bool noticePanelActive;

    [Header("Stats")]
    public GameObject statsPanel;
    public Text statsText;
    //public Player playerScript;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        //playerScript = player.GetComponent<Player>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    if (inventoryPanel.activeInHierarchy == false)
        //    {
        //        inventoryPanel.SetActive(true);
        //    }
        //    else
        //    {
        //        inventoryPanel.SetActive(false);
        //    }
        //}

        currentAmmoText.text = attackShurken.currentAmmo.ToString();    //TEMP
        totalAmmoText.text = attackShurken.totalAmmo.ToString();        //TEMP

        if (wm.canCountDown)
        {
            waveText.text = "Wave " + wm.nextWave + " is starting in";
            countdownText.text = wm.nextWaveCountDown.ToString("0");
        }

        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            StartCoroutine(PauseGame());
        }

        statsText.text = "Max Health: " + player.GetComponent<Entity>().stats.maxHealth + "\n" +
                         "Attack Damage: " + player.GetComponent<Entity>().stats.attackDamage + "\n" +
                         "Atack Range: " + player.GetComponent<Entity>().stats.attackRange + "\n" +
                         "Movement Speed: " + player.GetComponent<Entity>().stats.moveSpeed + "\n" +
                         "Jump Height: " + player.GetComponent<Entity>().stats.jumpForce + "\n" +
                         "Defence: " + player.GetComponent<Entity>().stats.defence;
    }

    internal void StartCoroutine()
    {
        throw new NotImplementedException();
    }

    public IEnumerator FadeIn()
    {
        fadeOverlay.enabled = true;

        fadeOverlay.canvasRenderer.SetAlpha(1.0f);
        fadeOverlay.CrossFadeAlpha(0f, 1f, false);

        yield return new WaitForSeconds(1.0f);

        fadeOverlay.enabled = false;
    }

    public IEnumerator PauseGame()
    {
        if (gamePaused == false)
        {
            gamePaused = true;
            canPause = false;

            fadeOverlay.enabled = true;

            fadeOverlay.canvasRenderer.SetAlpha(0.1f);
            fadeOverlay.CrossFadeAlpha(1f, 1f, false);

            yield return new WaitForSeconds(1.0f);

            Time.timeScale = 0;
            canPause = true;
        }
        else if (gamePaused == true)
        {
            Time.timeScale = 1;
            canPause = false;

            fadeOverlay.enabled = true;

            fadeOverlay.canvasRenderer.SetAlpha(1.0f);
            fadeOverlay.CrossFadeAlpha(0f, 1f, false);

            yield return new WaitForSeconds(1.0f);

            gamePaused = false;
            canPause = true;
        }
    }

    public IEnumerator NoticePopUp(string noticetext, float f)
    {
        noticePanelActive = true;
        noticeText.text = noticetext;
        noticeTextPanel.SetActive(true);

        yield return new WaitForSeconds(f);

        noticeTextPanel.SetActive(false);
        noticePanelActive = false;
    }
}
