using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public string[] stageScenes;
    public int currentStageIndex;

    public void LoadNextStage()
    {
        int nextStageIndex = currentStageIndex + 1;
        SceneManager.LoadScene(stageScenes[nextStageIndex]);
    }
    

    // 何かあった時用のボタン操作
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("BeforeGame"); 
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("stage01"); 
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene("stage02"); 
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("stage03"); 
        }
    }
}
