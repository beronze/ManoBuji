using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HpBar : MonoBehaviour {

	public Image Fill;
	public PlayerStatus _PlayerStatus;

	void Start () {
	
		_PlayerStatus = GameObject.Find ("Player").GetComponent<PlayerStatus>();

	}
	
	void Update () {
	
		if (_PlayerStatus != null)
		{
			Fill.fillAmount = _PlayerStatus.CurrentHp/_PlayerStatus.MaxHp;

		}
	}
}
