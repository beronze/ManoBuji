using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPBarBoss : MonoBehaviour {

	public Image Fill;
	public EnemyStatus _EnemyStatus;
	
	void Start () {
		
		_EnemyStatus = GameObject.Find ("Boss").GetComponent<EnemyStatus>();
		
	}
	
	void Update () {
		
		if (_EnemyStatus != null)
		{
			Fill.fillAmount = _EnemyStatus.CurrentHp/_EnemyStatus.MaxHp;
			
		}
	}
}
