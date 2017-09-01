using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public GameObject[] m_Menus;

    public GameObject m_LevelSetList;
    private GameObject[] m_LevelSets;

    private GameObject m_ReturnButton;

	// Use this for initialization
	void Start () {
        m_ReturnButton = m_Menus[1].transform.GetChild(2).gameObject;

        m_LevelSets = new GameObject[m_LevelSetList.transform.childCount];
        for (int i = 0; i < m_LevelSetList.transform.childCount; i++)
        {
            m_LevelSets[i] =  m_LevelSetList.transform.GetChild(i).gameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GotoLevelSelect()
    {
        m_Menus[0].SetActive(false);
        m_Menus[1].SetActive(true);
        m_LevelSetList.SetActive(true);
    }

    public void GotoMainMenu()
    {
        m_Menus[1].SetActive(false);
        m_Menus[0].SetActive(true);
        m_LevelSetList.SetActive(false);
    }

    public void ReturnFromSet(int _setNumber)
    {
        m_LevelSets[_setNumber].transform.GetChild(0).gameObject.SetActive(false);
        for (int i = 0; i < m_LevelSets.Length; i++)
        {
            m_LevelSets[i].transform.GetChild(1).gameObject.SetActive(true);
        }

        m_LevelSets[_setNumber].transform.GetChild(2).gameObject.SetActive(false);
        m_ReturnButton.SetActive(true);
    }

    public void GotoOptions()
    {

    }

    public void GotoQuit()
    {
        Application.Quit();
    }

    public void GotoLevelSet(int _setNumber)
    {
        m_ReturnButton.SetActive(false);
        m_LevelSets[_setNumber].transform.GetChild(2).gameObject.SetActive(true);
        //Debug.Log("Level: " + _setNumber.ToString() + " Selected");
        m_LevelSets[_setNumber].transform.GetChild(0).gameObject.SetActive(true);
        for (int i = 0; i < m_LevelSets.Length; i++)
        {
            m_LevelSets[i].transform.GetChild(1).gameObject.SetActive(false);
        }
    }

}
