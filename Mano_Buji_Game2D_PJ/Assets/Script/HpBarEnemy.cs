using UnityEngine;
using System.Collections;

public class HpBarEnemy : MonoBehaviour {

	float _maxScaleX;
	EnemyStatus _enemyStatus;

	void Start () {
		_maxScaleX = transform.localScale.x;
		_enemyStatus = transform.parent.GetComponent<EnemyStatus> ();
	}
	
	void Update () {


		float barScaleX = _maxScaleX * (_enemyStatus.CurrentHp / _enemyStatus.MaxHp);
		transform.localScale = new Vector3(barScaleX, transform.localScale.y,transform.localScale.z);
	}
}
