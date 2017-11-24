using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour {


    public bool isSettingMenuOpen;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Image menuHolder;
    [SerializeField] private Button soundBtn;
    [SerializeField] private Button musicBtn;
    [SerializeField] private Button vibrationBtn;
    [SerializeField] private Button infoBtn;

    [SerializeField] private Image soundOn;
    [SerializeField] private Image soundOff;

    [SerializeField] private Image musicOn;
    [SerializeField] private Image musicOff;

    [SerializeField] private Image vibrationOn;
    [SerializeField] private Image vibrationOff;

    [SerializeField] private Button start;
    public Animation anim;

    private void Awake()
    {
        GameManager.instance.LoadManagers(this);
        
    }
    // Use this for initialization
    void Start () {
 
        isSettingMenuOpen = false;
        menuHolder.gameObject.SetActive(false);
        settingsButton = settingsButton.GetComponent<Button>();
        soundBtn = soundBtn.GetComponent<Button>();
       
       
    }

    public void StartGame()
    {
        {
            SceneManager.LoadScene(1);
        }
    }

    public void SettingMenuHandle()
    {
        if(isSettingMenuOpen)
        {
            //close menu
            isSettingMenuOpen = false;
            menuHolder.gameObject.SetActive(false);
            anim.Play();


        }
        else
        {
            //show menu
            isSettingMenuOpen = true;
            menuHolder.gameObject.SetActive(true);
            anim.Play();
        }
    }

    public void ChangeValue(string _value)
    {
        Debug.Log(PlayerPrefs.GetInt(_value));
        PlayerPrefs.SetInt(_value, Convert.ToBoolean(PlayerPrefs.GetInt(_value)) ? 0 : 1);

        switch (_value)
        {
            case "sound":
                if(PlayerPrefs.GetInt("sound") == 1)
                {
                    Debug.Log("SOff");
                    //PlayerPrefs.SetInt("sound", 1);
                    //soundBtn.GetComponent<Image>().sprite = soundOff.GetComponent<Sprite>();
                    soundBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sound Off");
                }
                else
                {
                    Debug.Log("Son");
                    //   PlayerPrefs.SetInt("sound", 0);
                    //soundBtn.GetComponent<Image>().sprite = soundOn.GetComponent<Sprite>();
                    soundBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sound On");
                }
                break;
            case "music":
                if (PlayerPrefs.GetInt("music") == 1)
                {
                    Debug.Log("MOff");
                    //PlayerPrefs.SetInt("music", 1);
                    // soundBtn.GetComponent<Image>().sprite = musicOff.GetComponent<Sprite>();
                    musicBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Music Off");
                    
                }
                else
                {
                    Debug.Log("Mon");
                    //PlayerPrefs.SetInt("music", 0);
                    // soundBtn.GetComponent<Image>().sprite = musicOn.GetComponent<Sprite>();
                    musicBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Music On");
                }
                break;
            case "vibration":
                if (PlayerPrefs.GetInt("vibration") == 1)
                {
                    Debug.Log("vibroff");
                    //PlayerPrefs.SetInt("vibration", 1);
                    // soundBtn.GetComponent<Image>().sprite = vibrationOff.GetComponent<Sprite>();
                    vibrationBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Vibration Off");

                }
                if (PlayerPrefs.GetInt("vibration") == 0)
                {
                    Debug.Log("vibron");
                    //PlayerPrefs.SetInt("vibration", 0);
                    //soundBtn.GetComponent<Image>().sprite = vibrationOn.GetComponent<Sprite>();
                    vibrationBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Vibration On");

                }
                break;
            default:
                break;
        }
    }   
}
