using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
	public class DeleteObject : MonoBehaviour
	{
		private ProgrammManager ProgrammManagerScript;

		private Button button;

		// Use this for initialization
		void Start()
		{
			ProgrammManagerScript = FindObjectOfType<ProgrammManager>();

			button = GetComponent<Button>();
			button.onClick.AddListener(DeleteObjectFunction);

		}

		void DeleteObjectFunction()
		{
			GameObject gameObject = GameObject.FindWithTag("logo");
			if (gameObject != null)
			{
				Destroy(gameObject);
			}

			ProgrammManagerScript.ChooseObject = false;
			ProgrammManagerScript.DeleteButton.SetActive(false);
		}
	}
}