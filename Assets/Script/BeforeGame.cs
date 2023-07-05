using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BeforeGame : MonoBehaviour
{

    public void LoadFirstStage()
    {
        SceneManager.LoadScene("stage01");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
