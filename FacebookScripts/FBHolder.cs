using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBHolder : MonoBehaviour {
    public GameObject DialogLoggedIn;
    public GameObject DialogLoggedOut;
    public GameObject DialogProfilePic;
    public GameObject scoreEntryPanel;
    public GameObject scoreScrollList;
    public GameObject leaderboard;


    private void Awake()
    {
        //FBManager.Instance.LoadFbEvents(this);
        FBManager.Instance.DialogLoggedIn = DialogLoggedIn;
        FBManager.Instance.DialogLoggedOut = DialogLoggedOut;
        FBManager.Instance.DialogProfilePic = DialogProfilePic;
        FBManager.Instance.scoreEntryPanel = scoreEntryPanel;
        FBManager.Instance.scoreScrollList = scoreScrollList;
        FBManager.Instance.leaderboard = leaderboard;
       
    }
}
