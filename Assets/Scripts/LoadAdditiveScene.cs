using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAdditiveScene : MonoBehaviour
{
	[SerializeField]
	private string scene_name;
	
	//operacao assincrona
	//private AsyncOperation async_operation;
	//se a scene foi loadada
    private bool scene_loaded = false;
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player") && !scene_loaded)
        {
			//loada a scene
			scene_loaded = true;
            SceneManager.LoadSceneAsync(scene_name, LoadSceneMode.Additive);
		}
	}
	
	private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && scene_loaded)
        {
			//tira a scene
			scene_loaded = false;
            SceneManager.UnloadSceneAsync(scene_name);
		}
	}
}
