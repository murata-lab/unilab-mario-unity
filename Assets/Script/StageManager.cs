using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public string[] stageScenes; // ステージシーン名の配列
    public int currentStageIndex; // 現在のステージのインデックス

    public void LoadNextStage()
    {
        // 次のステージのインデックスを計算
        int nextStageIndex = currentStageIndex + 1;

        // 次のステージをロードする
        SceneManager.LoadScene(stageScenes[nextStageIndex]);
    }

    public void LoadFirstStage()
    {
        SceneManager.LoadScene("BeforeGame");
    }
}
