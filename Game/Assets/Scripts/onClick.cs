using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onClick : MonoBehaviour
{
    private AssetBundle loadedAssetBundle;
    private string[] scenePaths;

    //void Start()
    //{
    //    loadedAssetBundle = AssetBundle.LoadFromFile("Assets/Scenes");
    //    scenePaths = loadedAssetBundle.GetAllScenePaths();
    //}
    public void openScene()
    {
        SceneManager.LoadScene("Scenes/Room 1", LoadSceneMode.Single);
    }
}
