using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //UI
    public Image redUI;
    public Image greenUI;
    public Image yellowUI;

    Color redUIColor;
    Color greenUIColor;
    Color yellowUIColor;

    //Misc
    public bool canSwitch = true;
    float timeSwitch = 2;
    public int mouseSwitchValue = 0;

    public static ColorValue playerProjectileColor = ColorValue.Red;

    public AudioSource damageSound;
    public AudioSource switchColorSound;

    public GameObject player;

    //Score
    public TextMeshProUGUI scoreText;
    public static int scoreInt;

    public static int life;
    public GameObject[] lifeUI;

    public CameraShake cs;

    private void Start()
    {
        Cursor.visible = false;

        scoreInt = 0;
        life = 3;

        playerProjectileColor = ColorValue.Red;

        redUIColor = redUI.color;
        greenUIColor = greenUI.color;
        yellowUIColor = yellowUI.color;
    }

    void Update()
    {
        if(timeSwitch <= 0.3f)
        {
            timeSwitch += Time.deltaTime;
        }
        else
        {
            canSwitch = true;
        }

        SwitchColorKeyboard();

        SwitchColorMouse();

        //Update Score
        scoreText.text = scoreInt.ToString();

    }

    void SwitchColorKeyboard()
    {
        if (canSwitch)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Q))
            {
                redUI.rectTransform.sizeDelta = new Vector2(40, 40);
                greenUI.rectTransform.sizeDelta = new Vector2(25, 25);
                yellowUI.rectTransform.sizeDelta = new Vector2(25, 25);

                redUI.color = new Color(redUIColor.r, redUIColor.g, redUIColor.b, 1);
                greenUI.color = new Color(greenUIColor.r, greenUIColor.g, greenUIColor.b, 0.5f);
                yellowUI.color = new Color(yellowUIColor.r, yellowUIColor.g, yellowUIColor.b, 0.5f);

                canSwitch = false;
                timeSwitch = 0;

                mouseSwitchValue = 0;

                if (playerProjectileColor != ColorValue.Red)
                {
                    PlaySoundSwitchColor();
                }

                playerProjectileColor = ColorValue.Red;

            }

            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.W))
            {
                redUI.rectTransform.sizeDelta = new Vector2(25, 25);
                greenUI.rectTransform.sizeDelta = new Vector2(40, 40);
                yellowUI.rectTransform.sizeDelta = new Vector2(25, 25);

                redUI.color = new Color(redUIColor.r, redUIColor.g, redUIColor.b, 0.5f);
                greenUI.color = new Color(greenUIColor.r, greenUIColor.g, greenUIColor.b, 1);
                yellowUI.color = new Color(yellowUIColor.r, yellowUIColor.g, yellowUIColor.b, 0.5f);

                canSwitch = false;
                timeSwitch = 0;

                mouseSwitchValue = 1;

                if (playerProjectileColor != ColorValue.Green)
                {
                    PlaySoundSwitchColor();
                }

                playerProjectileColor = ColorValue.Green;

            }

            if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.E))
            {
                redUI.rectTransform.sizeDelta = new Vector2(25, 25);
                greenUI.rectTransform.sizeDelta = new Vector2(25, 25);
                yellowUI.rectTransform.sizeDelta = new Vector2(40, 40);

                redUI.color = new Color(redUIColor.r, redUIColor.g, redUIColor.b, 0.5f);
                greenUI.color = new Color(greenUIColor.r, greenUIColor.g, greenUIColor.b, 0.5f);
                yellowUI.color = new Color(yellowUIColor.r, yellowUIColor.g, yellowUIColor.b, 1);

                canSwitch = false;
                timeSwitch = 0;

                mouseSwitchValue = 2;

                if (playerProjectileColor != ColorValue.Yellow)
                {
                    PlaySoundSwitchColor();
                }

                playerProjectileColor = ColorValue.Yellow;

            }
        }
    }

    void SwitchColorMouse()
    {
        if (canSwitch)
        {
            if (Input.GetMouseButtonDown(1))
            {

                if(mouseSwitchValue == 2)
                {
                    mouseSwitchValue = 0;
                }
                else
                {
                    mouseSwitchValue += 1;
                }

                if (mouseSwitchValue == 0)
                {
                    redUI.rectTransform.sizeDelta = new Vector2(40, 40);
                    greenUI.rectTransform.sizeDelta = new Vector2(25, 25);
                    yellowUI.rectTransform.sizeDelta = new Vector2(25, 25);

                    redUI.color = new Color(redUIColor.r, redUIColor.g, redUIColor.b, 1);
                    greenUI.color = new Color(greenUIColor.r, greenUIColor.g, greenUIColor.b, 0.5f);
                    yellowUI.color = new Color(yellowUIColor.r, yellowUIColor.g, yellowUIColor.b, 0.5f);

                    canSwitch = false;
                    timeSwitch = 0;

                    playerProjectileColor = ColorValue.Red;

                    PlaySoundSwitchColor();
                }
                else if (mouseSwitchValue == 1)
                {
                    redUI.rectTransform.sizeDelta = new Vector2(25, 25);
                    greenUI.rectTransform.sizeDelta = new Vector2(40, 40);
                    yellowUI.rectTransform.sizeDelta = new Vector2(25, 25);

                    redUI.color = new Color(redUIColor.r, redUIColor.g, redUIColor.b, 0.5f);
                    greenUI.color = new Color(greenUIColor.r, greenUIColor.g, greenUIColor.b, 1);
                    yellowUI.color = new Color(yellowUIColor.r, yellowUIColor.g, yellowUIColor.b, 0.5f);

                    canSwitch = false;
                    timeSwitch = 0;

                    playerProjectileColor = ColorValue.Green;

                    PlaySoundSwitchColor();
                }
                else if (mouseSwitchValue == 2)
                {
                    redUI.rectTransform.sizeDelta = new Vector2(25, 25);
                    greenUI.rectTransform.sizeDelta = new Vector2(25, 25);
                    yellowUI.rectTransform.sizeDelta = new Vector2(40, 40);

                    redUI.color = new Color(redUIColor.r, redUIColor.g, redUIColor.b, 0.5f);
                    greenUI.color = new Color(greenUIColor.r, greenUIColor.g, greenUIColor.b, 0.5f);
                    yellowUI.color = new Color(yellowUIColor.r, yellowUIColor.g, yellowUIColor.b, 1);

                    canSwitch = false;
                    timeSwitch = 0;

                    playerProjectileColor = ColorValue.Yellow;

                    PlaySoundSwitchColor();
                }

            }

        }
    }

    public void DeleteLife()
    {
        life--;

        cs.StartCoroutine(cs.Shake(0.15f, 0.4f));
        damageSound.Play();

        if (life == 2)
        {
            lifeUI[2].gameObject.SetActive(false);
        }
        else if (life == 1)
        {
            lifeUI[1].gameObject.SetActive(false);
        }
        else if (life == 0)
        {
            Cursor.visible = true;

            lifeUI[0].gameObject.SetActive(false);
            SetScore();
            
            StartCoroutine(PlayerLose());
        }
    }

    public void SetScore()
    {
        int highscore = PlayerPrefs.GetInt("Highscore");

        if (scoreInt > highscore)
        {
            PlayerPrefs.SetInt("Highscore", scoreInt);
            PlayerPrefs.Save();
        }
    }

    void PlaySoundSwitchColor()
    {
        if (player != null)
        {
            switchColorSound.Play();
        }
    }

    IEnumerator PlayerLose()
    {

        Destroy(player.gameObject);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("End");
    }
}

public enum ColorValue { Red, Green, Yellow};
