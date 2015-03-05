using UnityEngine;
using System.Collections;

public class VRCursor : MonoBehaviour {


PlayAnimation lastPlayedPa = null;

//could be a bool instead 
public enum HoverState{HOVER, NONE};
public HoverState hover_state = HoverState.NONE;

void CheckCollision()
    {
        RaycastHit hitInfo;

		

        if (Physics.Raycast(transform.position, cursor.transform.position - transform.position, out hitInfo)){

			if (hitInfo.collider.gameObject.tag == "Screen"){
				//do thing
			}

			PlayAnimation pa = hitInfo.collider.gameObject.GetComponent<PlayAnimation>();
		
			if(pa && hitInfo.collider.gameObject.tag =="content"){
				//get script to play animation 

				if(hover_state == HoverState.NONE){
					pa.StartAnimation();
				}
					hover_state = HoverState.HOVER; 
			}
		}
			//instead of having to find a gameobject here i want to stop the animation on the object i was looking at before
			StopAnimation sa = GameObject.Find("model2").GetComponent<StopAnimation>();
			//i think i need to take the variable from line 25 and hold it somewhere only to be triggered when your not looking 
			//at the the collider anymore. 


		if(hover_state == HoverState.HOVER){
			//stop playing script when you look away
			sa.StopingAnimation();
				
		}
			hover_state = HoverState.NONE;
	}
}
