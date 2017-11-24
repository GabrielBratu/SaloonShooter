using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
//    [SerializeField] private Button start;
    public SettingsManager settingsManager;
    public FBManager fbHolder;
    public bool hasFbStarted = false;
    public int deathCount;

    void Awake()
    {
        
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
          DontDestroyOnLoad(gameObject);
          
//        InitGame();
    }


    //void InitGame()
    //{
    //    //Call the SetupScene function of the BoardManager script, pass it current level number.
    //    //LoadManagers();
    //    //start.onClick.AddListener(StartGame);
    //}

    private void Update()
    {
        //if ((Input.touchCount == 1) &&
        // (Input.GetTouch(0).phase == TouchPhase.Began))
        //{
        //    SceneManager.LoadScene("1");
        //}
    }

    //public void StartGame()
    //{
    //    {
    //        SceneManager.LoadScene(1);
    //    }
    //}

    public void LoadManagers(SettingsManager _settingsManager)
    {
        settingsManager = _settingsManager;
    }

    public void LoadFbEvents(FBManager _fbHolder)
    {
        fbHolder = _fbHolder;

        //DialogLoggedIn = _fbHolder.DialogLoggedIn;
        // DialogLoggedOut = fbHolder.DialogLoggedOut.GetComponent<GameObject>();
        //  DialogProfilePic = fbHolder.DialogProfilePic.GetComponent<GameObject>();
        // scoreEntryPanel = fbHolder.scoreEntryPanel.GetComponent<GameObject>();
        //  scoreScrollList = fbHolder.scoreScrollList.GetComponent<GameObject>();
        //leaderboard = fbHolder.leaderboard.GetComponent<GameObject>();
    }
}
