using UnityEngine;
using System.Collections;

public class BlockBar : MonoBehaviour {

    float _maxScaleX;
    PlayerStatus _BlockStatus;

    void Start()
    {
        _maxScaleX = transform.localScale.x;
        _BlockStatus = transform.parent.GetComponent<PlayerStatus>();
    }

    void Update()
    {


        float barScaleX = _maxScaleX * (_BlockStatus.CurrentBlock / _BlockStatus.MaxBlock);
        transform.localScale = new Vector3(barScaleX, transform.localScale.y, transform.localScale.z);
    }
}
