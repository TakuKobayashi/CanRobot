using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
namespace CanRobot{
    /// <summary>
    /// シーンマネージャー
    /// </summary>
    public class SceneManager : MonoBehaviour {
        //シーンのロード
        public static void TitleLoad() { UnityEngine.SceneManagement.SceneManager.LoadScene("Title", LoadSceneMode.Single); }
        public static void MainLoad() { UnityEngine.SceneManagement.SceneManager.LoadScene("Main", LoadSceneMode.Single); }
        public static void GameClearLoad(int num) { UnityEngine.SceneManagement.SceneManager.LoadScene("GameClear" + num.ToString("00"), LoadSceneMode.Single); }
        public static void GameOverLoad() { UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver", LoadSceneMode.Single); }

        //シーンのアンロード
        public static void TitleUnLoad() { UnityEngine.SceneManagement.SceneManager.UnloadScene("Title"); }
        public static void MainUnLoad() { UnityEngine.SceneManagement.SceneManager.UnloadScene("Main"); }
        public static void GameClearUnLoad() { UnityEngine.SceneManagement.SceneManager.UnloadScene("GameClear"); }
        public static void GameOverUnLoad() { UnityEngine.SceneManagement.SceneManager.UnloadScene("GameOver"); }

    }
}
