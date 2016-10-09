using UnityEngine;
using System.Collections;

public class MainCam : MonoBehaviour {

    public static MainCam S;

    // Use this for initialization
    void Start () {
        S = this;
    }
    
    // Update is called once per frame
    void Update () {
        Vector3 position = new Vector3(gameObject.transform.position.x,0,gameObject.transform.position.z);
        gameObject.transform.position = position;
    }
}
