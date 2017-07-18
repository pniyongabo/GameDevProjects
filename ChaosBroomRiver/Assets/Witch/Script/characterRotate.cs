using UnityEngine;
using System.Collections;

public class characterRotate : MonoBehaviour {

	public GameObject frog;
	
	
	
	private Rect FpsRect ;
	private string frpString;
	
	private GameObject instanceObj;
	public GameObject[] gameObjArray=new GameObject[15];
	public AnimationClip[] AniList  = new AnimationClip[15];
	
	float minimum = 2.0f;
	float maximum = 50.0f;
	float touchNum = 0f;
	string touchDirection ="forward"; 
	private GameObject Warrior;
	
	// Use this for initialization
	void Start () {
		
		//frog.animation["dragon_03_ani01"].blendMode=AnimationBlendMode.Blend;
		//frog.animation["dragon_03_ani02"].blendMode=AnimationBlendMode.Blend;
		//Debug.Log(frog.GetComponent("dragon_03_ani01"));
		
		//Instantiate(gameObjArray[0], gameObjArray[0].transform.position, gameObjArray[0].transform.rotation);
	}
	
 void OnGUI() {
if (GUI.Button(new Rect(20, 20, 70, 40),"Idle")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Idle");
	  }
	    if (GUI.Button(new Rect(90, 20, 70, 40),"Idle2")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Idle2");			
	  } 
	    if (GUI.Button(new Rect(160, 20, 70, 40),"Talk")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Talk");
	  }
		if (GUI.Button(new Rect(230, 20, 70, 40),"Walk")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
			frog.GetComponent<Animation>().CrossFade("Walk");			
	  } 
	    if (GUI.Button(new Rect(300, 20, 70, 40),"R-Walk")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("R-Walk");			
	  }
	    if (GUI.Button(new Rect(370, 20, 70, 40),"L-Walk")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
			frog.GetComponent<Animation>().CrossFade("L-Walk");
	  }
		if (GUI.Button(new Rect(440, 20, 70, 40),"Run")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
			frog.GetComponent<Animation>().CrossFade("Run");			
	  }
	    if (GUI.Button(new Rect(510, 20, 70, 40),"R-Run")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("R-Run");			
	  }
	    if (GUI.Button(new Rect(580, 20, 70, 40),"L-Run")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("L-Run");			
	  } 
	    if (GUI.Button(new Rect(650, 20, 70, 40),"B-Walk")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("B-Walk");			
	  }
	    if (GUI.Button(new Rect(720, 20, 70, 40),"")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("");
	  }	  
		if (GUI.Button(new Rect(790, 20, 70, 40),"Jump")){
		 frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Jump");
	  }
		if (GUI.Button(new Rect(20, 65, 70, 40),"")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
			frog.GetComponent<Animation>().CrossFade("");
	  }
		if (GUI.Button(new Rect(90, 65, 70, 40),"")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
			frog.GetComponent<Animation>().CrossFade("");
	  } 
		if (GUI.Button(new Rect(160, 65, 70, 40),"Mount")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
			frog.GetComponent<Animation>().CrossFade("Mount");
	  }  
		if (GUI.Button(new Rect(230, 65, 70, 40),"Mount_idle")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
			frog.GetComponent<Animation>().CrossFade("Mount_idle");
	  }
		if (GUI.Button(new Rect(300, 65, 70, 40),"L-Mount")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
			frog.GetComponent<Animation>().CrossFade("L-Mount");			
	  } 
		if (GUI.Button(new Rect(370, 65, 70, 40),"R-Mount")){
			frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
			frog.GetComponent<Animation>().CrossFade("R-Mount");			
	  } 		
		if (GUI.Button(new Rect(440, 65, 70, 40),"Accelerate")){
			frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
			frog.GetComponent<Animation>().CrossFade("Accelerate");			
	  } 
		if (GUI.Button(new Rect(510, 65, 70, 40),"Brake")){
			frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
			frog.GetComponent<Animation>().CrossFade("Brake");			
	  } 
		if (GUI.Button(new Rect(580, 65, 70, 40),"Dismount")){
			frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
			frog.GetComponent<Animation>().CrossFade("Dismount");			
	  }
		if (GUI.Button(new Rect(650, 65, 70, 40),"Magic_stance")){
			frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
			frog.GetComponent<Animation>().CrossFade("Magic_stance");			
	  }		
		if (GUI.Button(new Rect(720, 65, 70, 40),"Magic1")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
			frog.GetComponent<Animation>().CrossFade("Magic1");
	  } 
		if (GUI.Button(new Rect(790, 65, 70, 40),"Magic2")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
			frog.GetComponent<Animation>().CrossFade("Magic2");
	  }		
			if (GUI.Button(new Rect(20, 110, 70, 40),"Magic3")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
			frog.GetComponent<Animation>().CrossFade("Magic3");
	  } 
		if (GUI.Button(new Rect(90, 110, 70, 40),"Magic4")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
			frog.GetComponent<Animation>().CrossFade("Magic4");
	  } 
		if (GUI.Button(new Rect(160, 110, 70, 40),"Attack1")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Attack1");
	  } 
		if (GUI.Button(new Rect(230, 110, 70, 40),"Damage")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("Damage");
	  }
		if (GUI.Button(new Rect(300, 110, 70, 40),"Stun")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
			frog.GetComponent<Animation>().CrossFade("Stun");
	  }	
	    if (GUI.Button(new Rect(370, 110, 70, 40),"Down")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Down");
	  }
		if (GUI.Button(new Rect(440, 110, 70, 40),"Up")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
			frog.GetComponent<Animation>().CrossFade("Up");			
	  } 
			    if (GUI.Button(new Rect(510, 110, 70, 40),"Dead")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
			frog.GetComponent<Animation>().CrossFade("Dead");
	  }	
		if (GUI.Button(new Rect(580, 110, 70, 40),"Dead2")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
			frog.GetComponent<Animation>().CrossFade("Dead2");
	  }
	    if (GUI.Button(new Rect(650, 110, 70, 40),"Pose")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Pose");			
	  } 
//	    if (GUI.Button(new Rect(720, 110, 70, 40),"Buff")){
//		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
//		  	frog.GetComponent<Animation>().CrossFade("Buff");
//	  }
//	    if (GUI.Button(new Rect(790, 110, 70, 40),"Down")){
//		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
//		  	frog.GetComponent<Animation>().CrossFade("Down");			
//	  } 
//	    if (GUI.Button(new Rect(20, 155, 70, 40),"Up")){
//		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
//		  	frog.GetComponent<Animation>().CrossFade("Up");			
//	  } 
//	    if (GUI.Button(new Rect(90, 155, 70, 40),"Damage")){
//		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
//		  	frog.GetComponent<Animation>().CrossFade("Damage");			
//	  } 
//	    if (GUI.Button(new Rect(160, 155, 70, 40),"Dead")){
//		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
//		  	frog.GetComponent<Animation>().CrossFade("Dead");			
//	  } 

//	    if (GUI.Button(new Rect(230, 155, 70, 40),"Dead2")){
//		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
//		  	frog.GetComponent<Animation>().CrossFade("Dead2");			
//	  }

//	    if (GUI.Button(new Rect(300, 65, 70, 40),"")){
//		  frog.animation.wrapMode= WrapMode.Once;
//		  	frog.animation.CrossFade("");
//	  }
//	    if (GUI.Button(new Rect(370, 65, 70, 40),"")){
//		  frog.animation.wrapMode= WrapMode.Once;
//		  	frog.animation.CrossFade("");			
//	  } 

//				if (GUI.Button(new Rect(580, 470, 120, 40),"Ver ")){
//		  frog.animation.wrapMode= WrapMode.Loop;
//		  	frog.animation.CrossFade("Idle");
//	  }
 }
	
	// Update is called once per frame
	void Update () {
		
		//if(Input.GetMouseButtonDown(0)){
		
			//touchNum++;
			//touchDirection="forward";
		 // transform.position = new Vector3(0, 0,Mathf.Lerp(minimum, maximum, Time.time));
			//Debug.Log("touchNum=="+touchNum);
		//}
		/*
		if(touchDirection=="forward"){
			if(Input.touchCount>){
				touchDirection="back";
			}
		}
	*/
		 
		//transform.position = Vector3(Mathf.Lerp(minimum, maximum, Time.time), 0, 0);
	if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
		//frog.transform.Rotate(Vector3.up * Time.deltaTime*30);
	}
	
}
