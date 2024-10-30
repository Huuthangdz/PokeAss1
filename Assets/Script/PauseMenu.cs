using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public void PauseButton()
    {
        Time.timeScale = 0;
    }
    public void ResumeButton()
    {
        Time.timeScale = 1;
    }
    public void PlayeAgain()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void Shop()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LastLevel", currentSceneIndex);

        // Chuyển sang scene Shop (index = 0)
        Time.timeScale = 1;  // Đảm bảo game tiếp tục không bị tạm dừng
        SceneManager.LoadScene(0);  // Shop có chỉ số là 0
    }
}
