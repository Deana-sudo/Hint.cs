using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamectrl : MonoBehaviour {
	public GameObject lightPfb;
	public GameObject startPos;
	public GameObject particle;
    public float speed = 2000.0f;
    public GameObject FixedForceObject;
    public string sceneName;

    public GameObject gamepause;
    public bool pauseLock;

    private int Prefablength = 0;


	// Use this for initialization
	void Start () {
        gamepause.SetActive(false);

        pauseLock = false;
        

        FixedForceObject = GameObject.FindWithTag("DirChange");
        startPos = GameObject.FindWithTag("StartPos");
	}

	public void WhenPlaybuttonClicked() {
		GameObject LightPrefab = Instantiate (lightPfb, startPos.transform.position, Quaternion.identity);
        LightPrefab.name = lightPfb.name;
        //Instantiate (particle, startPos.transform.position, Quaternion.identity);
        
	}
    public void addforce()
    {
        lightPfb.GetComponent<Rigidbody2D>().AddForce(startPos.transform.up * Time.deltaTime * speed);
    }

    public void PauseButtonClick()
    {
        if (pauseLock == false)
        {
            gamepause.SetActive(true);
            pauseLock = true;
            Time.timeScale = 0.0f;
            return;
        }
        if (pauseLock == true)
        {
            gamepause.SetActive(false);
            pauseLock = false;
            Time.timeScale = 1.0f;
            return;
                
        }
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        Prefablength = GameObject.FindGameObjectsWithTag("Light_W").Length;
        if (Prefablength <= 0)
        {
        }
    }
    public void TriangleRecover()
    {
        GameObject[] triangle;
        triangle = GameObject.FindGameObjectsWithTag("Triangle");
        for(int i = 0; i < triangle.Length; i++)
        triangle[i].GetComponent<Tirangle>().OnStarting();
    }

    public void SceneReset()
    {
        Application.LoadLevel(sceneName);
    }
}
