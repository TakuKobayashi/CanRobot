using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// シーンマネージャー
/// </summary>
public class SceneManager : MonoBehaviour {
    //シーンのロード
    public void TitleLoad() { UnityEngine.SceneManagement.SceneManager.LoadScene("Title", LoadSceneMode.Additive); }
    public void MainLoad() { UnityEngine.SceneManagement.SceneManager.LoadScene("Main", LoadSceneMode.Additive); }
    public void GameClearLoad() { UnityEngine.SceneManagement.SceneManager.LoadScene("GameClear", LoadSceneMode.Additive); }
    public void GameOverLoad() { UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver", LoadSceneMode.Additive); }

    //シーンのアンロード
    public void TitleUnLoad() { UnityEngine.SceneManagement.SceneManager.UnloadScene("Title"); }
    public void MainUnLoad() { UnityEngine.SceneManagement.SceneManager.UnloadScene("Main"); }
    public void GameClearUnLoad() { UnityEngine.SceneManagement.SceneManager.UnloadScene("GameClear"); }
    public void GameOverUnLoad() { UnityEngine.SceneManagement.SceneManager.UnloadScene("GameOver"); }

}
