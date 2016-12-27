using UnityEngine;
using System.Collections;

public class CreateEnemy : MonoBehaviour {

    public GameObject _Enemy,PointStart;
    void Start()
    {
        StartCoroutine(_WaitStart());
	}

    IEnumerator _WaitStart()
    {
        GameObject objEnemy = Instantiate(_Enemy, PointStart.transform.position, PointStart.transform.rotation) as GameObject;
        yield return new WaitForSeconds(Random.Range(2.3F, 8.0F));
        StartCoroutine(_WaitStart());
    }
}
