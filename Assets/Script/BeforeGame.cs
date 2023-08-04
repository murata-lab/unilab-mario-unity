using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BeforeGame : MonoBehaviour
{
    // ゲーム前の画面を表示
    public void LoadFirstStage()
    {
        SceneManager.LoadScene("stage01");
    }
}
