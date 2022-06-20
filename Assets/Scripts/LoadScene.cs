using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
	private Image image;
    [SerializeField]
	private Text text;

    private void Start()
    {
        //comeca o load
        StartCoroutine(LoadAsync(StaticVars.load_scene));
        
        //SceneManager.LoadScene(StaticVars.load_scene);
    }
	
    private IEnumerator LoadAsync(string sceneIndex)
    {
		//faz o load scene de forma assincrona
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
		
		//enquanto o load scene nao acaba
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
			
			//mostra o progresso da operacao
            image.fillAmount = progress;
            text.text = progress * 100f + "%";

            yield return null;
        }

        yield break;
    }
}
