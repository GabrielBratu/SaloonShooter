using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStatus : MonoBehaviour {

    public bool isUsed = false;
    public string hold = "";
    public string type = "";
    public Collider2D myCollider;

    private void Awake()
    {
        myCollider = this.gameObject.GetComponent<Collider2D>();
    }

}
