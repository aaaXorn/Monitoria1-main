using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
	private string scene_name;
	
	public void Botao()
	{
		//cena que vai ser modificada na scene ChangeScene
		StaticVars.load_scene = scene_name;
		//muda a cena
		SceneManager.LoadScene("ChangeScene");
	}
}
