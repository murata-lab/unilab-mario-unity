using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    private StageManager stageManager;


    private void Start()
    {
        stageManager = FindObjectOfType<StageManager>();
    }

    public void LoadNextStage()
    {
        stageManager.LoadNextStage();
    }

    public void QuitGame()
    {
        stageManager.LoadFirstStage();
    }
}
