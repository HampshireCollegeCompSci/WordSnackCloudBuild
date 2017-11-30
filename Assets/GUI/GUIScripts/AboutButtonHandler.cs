using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AboutButtonHandler : MonoBehaviour {
	public Texture aboutUnselected;
	public Texture aboutSelected;
	MeshRenderer mAbout;
	public bool buttonPressed = false;
    public bool clickSound;

	// Use this for initialization
	void Start () {
		mAbout = gameObject.GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name != "StartScreenTest") {
			mAbout.GetComponent<Renderer>().material.mainTexture = aboutUnselected;
		}
	}
	
	void OnMouseDown(){
		if(mAbout.GetComponent<Renderer>().material.mainTexture == aboutUnselected){
			mAbout.GetComponent<Renderer>().material.mainTexture = aboutSelected;
		}
    }
     void OnMouseUp()
    {
        if (mAbout.GetComponent<Renderer>().material.mainTexture == aboutSelected)
        {
            mAbout.GetComponent<Renderer>().material.mainTexture = aboutUnselected;
        }
    }
     void OnMouseUpAsButton()
     {
         if (mAbout.GetComponent<Renderer>().material.mainTexture == aboutSelected)
         {
             mAbout.GetComponent<Renderer>().material.mainTexture = aboutUnselected;
         }
         buttonPressed = true;
         clickSound = true;
        SceneManager.LoadSceneAsync("About");
     }
	
}
