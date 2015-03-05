PlayAnimation lastPlayedPa = null;

//how does this work
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

			StopAnimation sa = GameObject.Find("model2").GetComponent<StopAnimation>();

		if(hover_state == HoverState.HOVER){
			//stop playing script when you look away
			sa.StopingAnimation();
				
		}
			hover_state = HoverState.NONE;
	}
