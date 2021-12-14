using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class system : MonoBehaviour
{
    public Button startbuton;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void basla()
    {
        startbuton.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void nextlvl()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
