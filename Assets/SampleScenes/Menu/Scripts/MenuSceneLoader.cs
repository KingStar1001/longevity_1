using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneLoader : MonoBehaviour
{
    public GameObject menuUI;

    private GameObject m_Go;

	void Awake ()
	{
	    // if (m_Go == null)
	    // {
	    //     m_Go = Instantiate(menuUI);
	    // }
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			SceneManager.LoadScene("Menu");
		}
	}

	public void GotoMenu(){
		SceneManager.LoadScene("Menu");
	}
}
