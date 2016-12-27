using UnityEngine;
using System.Collections;

public class BtmChangeSce : MonoBehaviour {

	public void ChageScene(string scenename){
        
		Application.LoadLevel (scenename);
        Time.timeScale = 1;
	}

}
