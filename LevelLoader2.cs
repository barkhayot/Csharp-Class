using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject playMode;
    public Slider slider;
    public Text progressText;

    public GameObject cityBoard;
    public GameObject upperSide;
    public GameObject startMode;
   public void LoadLevel(int sceneIndex)
   {
       StartCoroutine(LoadAsynchronously(sceneIndex));

   }

   IEnumerator LoadAsynchronously (int sceneIndex)
   {
       AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

       loadingScreen.SetActive(true);
       playMode.SetActive(false);
       cityBoard.SetActive(false);
       upperSide.SetActive(false);
       startMode.SetActive(false);

       while (!operation.isDone)
       {
           float progress = Mathf.Clamp01(operation.progress / .9f);
           slider.value = progress;
           progressText.text = progress * 100f + "%"; 

           yield return null;
       }
   }
}
