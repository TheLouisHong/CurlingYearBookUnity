using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadYearbook : MonoBehaviour
{
    public string YearbookSceneName = "Yearbook";
    public void DoIt() {
        SceneManager.LoadScene(YearbookSceneName);
    }
}
