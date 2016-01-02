using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {

	void Update ()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }	
	}
}
