using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneController : MonoBehaviour
{

    private static SceneController m_Instance;

    public static SceneController Instance
    {
        get
        {
            if(m_Instance != null) return m_Instance;
            return null;
        }
    }
    
    public Loader m_Loader;

    [SerializeField] private string[] m_levelFileNames;

    private void Awake()
    {
        m_Instance = this;
        DontDestroyOnLoad(this);
    }

    public void LoadLevel(string fileName)
    {
        StartCoroutine(LoadScene(fileName));
    }

    private IEnumerator LoadScene(string fileName)
    {
        yield return null;

        AsyncOperation ao = SceneManager.LoadSceneAsync(1);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            if (ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;

                m_Loader = GetComponent<Loader>();
                m_Loader.Load(fileName);
            }
            yield return null;
        }
    }

    //private void LoadScene(string fileName)
    //{
    //    AsyncOperation async = SceneManager.LoadSceneAsync(1);
    //    if (async.progress >= 9.0f)
    //    {
    //        Debug.Log("Async Op >= 9.0f");
    //        m_Loader = FindObjectOfType<Loader>();
    //        m_Loader.Load(fileName);
    //    }
    //}
}
