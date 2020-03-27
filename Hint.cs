using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{

    public GameObject[] HintUIpos; // hintUi Location Object
    public GameObject[] Plats; // plat object
    public Transform[] HintLocalpos; // Answer Or First plat Location
    public Vector3[] HintMovingPos;

    private int Click;

    //declare Gameobject and put in a Transform array

    void Start()
    {
        Plats = GameObject.FindGameObjectsWithTag("Plat");
        HintUIpos = GameObject.FindGameObjectsWithTag("Hint");
        for (int i = 0; i < Plats.Length; i++)
        {
            HintLocalpos[i] = Plats[i].transform.parent.gameObject.transform;

            HintMovingPos[i] = (Plats[i].transform.parent.gameObject.transform.position);
            Plats[i].transform.parent.gameObject.transform.position = HintUIpos[i].transform.position;
        }

    }
    public void HintClicked()
    {
        if (Click == 3)
        {
            Debug.Log("3Times");
            return;
        }
        Debug.Log(Click);
        // HintUIpos[Click].transform.position = Plats[Click].transform.position;

        Plats[Click].transform.parent.gameObject.transform.position = HintMovingPos[Click];
        Click++;
        // make a function, put a Object to hint location and return to UI
    }
}