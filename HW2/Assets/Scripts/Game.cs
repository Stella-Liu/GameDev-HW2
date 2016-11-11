using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	public AudioSource sfxSource;
	public AudioClip roarSound;
	public AudioClip collectSound;
	public AudioClip screamSound;

	public string room;
	public string action;
	public string myText;
	public int counter = 0;
	private bool hint = false;
	private bool goNext = false;
	
	//Items
	private bool teddy_bear = false;
	private bool watch = false;
	private bool blue_paint = false;
	private bool ring = false;
	private bool ribbon = false;
	private bool found_boy = false;
	private bool found_box = false;
	private bool key = false;
	private bool solved = false;

	private string up_door;
	private string down_door;
	private string left_door;
	private string right_door;

	// Use this for initialization
	void Start () {
		room = "intro";
	}

	void playSFX(){
		sfxSource.Play();
		return;
	}
	
	// Update is called once per frame
	void Update () {

		up_door = "null";
		down_door = "null";
		left_door = "null";
		right_door = "null";

		//Intro
		if(room == "intro"){
			myText = "Welcome to the Puzzle House.\n\nOnce you have entered, you can't leave the house alive, unless you complete all the puzzles.\n\nEnjoy your time here.\n\n\nPress SpaceBar To Continue";
			if(Input.GetKeyDown(KeyCode.Space)){
				room = "scale_room";
			}
		}

		//Scale Room
		if(room == "scale_room"){
			myText = "Scale Room\n\nYou entered the first room and see a table. On the table was a piece of paper and a scale that had gold on one side and feather on the other.";
			myText += "A question appears before you; which is heavier?\n\nPress Up to look at the scale\nPress Down to read the paper";
			if(Input.GetKeyDown(KeyCode.UpArrow) && action != "look_at_paper"){
				action = "look_at_scale";
			}
			else if(Input.GetKeyDown(KeyCode.DownArrow) && action != "look_at_scale"){
				action = "look_at_paper";
			}
			if(action == "look_at_scale"){
			myText = "You looked at the scale and saw the feathers were on the higher end and the gold were on lower end. You said gold were heavier. The floor tile underneath you disappeared and down you went, into the jaws of a large titanoboa.\n\nPress Backspace to go Back ";
			}
			else if(action == "look_at_paper"){
				myText = "On the paper, it said 'Which is heavier: a ton of gold or a ton of feathers?' You said none are heavier than the other. There was silence and a door opened. \n\n\nPress Up To Continue";
				goNext = true;
			}
		}

		//2nd Puzzle - Hopeless Man
		if(room == "hopeless_man"){
			myText = "Hopeless Man's Room\n\nIn the next room, you see a man crouching in a corner. \n\nYou approach the guy and asked what is wrong? \n\nThe man replied, I don't remember how many people are in my family! I am SO ashamed of myself. I was given a hint, but I can't understand it. Could you help me? \n\nPress Up to help\nPress Down to look around";	
			goNext = false;
			if(action == "help_man"){
			myText = "Hopeless Man's Room\n\nAlright, I'll help you. The man tells you the hint: My family consists of me and my wife. We have six daughters and each daughter has one brother. \nHow many people are in his family? \n\n\nPress Up for 8\nPress Down for 9\nPress Left for 12\nPress Right for 14";
			}
			else if(action == "look_around"){
				myText = "Hopeless Man's Room\n\nYou walk to walk away and the man holds onto your leg. He starts screaming saying you gotta help him or else. \n\n\nPress Up to help him\nPress Down to get him to release you";
			}
			else if(action == "man_ending_one"){
				myText = "The man's grip got stronger and you tripped onto the floor. The man hovers over you and screams sorry while holding your neck, choking you. Sorry.\n\nPress Backspace to go Back";
			}
			else if(action == "man_ending_two"){
				myText = "The man immediately screamed out the number and nothing happened. He stared at you hopelessly and started mumbling, you lied, you lied, you lied to me! You deserve to die!!\n\nPress Backspace to go Back";
			}
			else if(action == "man_passed"){
				myText = "Hopeless Man's Room\n\nThe man immediately screamed out the number and a woman appeared. She hugged him and the man turn around and said thank you before leaving with her. A door magically appeared.\n\n\nPress Up To Continue";
				goNext = true;
			}
		}

		//3rd Puzzle - Truth, Wisdom, Lie
		if(room == "truth_wisdom_liar"){
			myText = "In the next room, there were 3 doors in front of you and 3 ladies. Their names are:\nTruth (who always tells the truth)\nLie (who always lies)\nWisdom (who sometimes lies)\n\nThe ladies had nametags on them. Would you like to look at the nametags or talk to them? \n\n\nPress Up to look at name tags.\nPress Down to talk to them.";
			goNext = false;

			if(action == "look_at_nametags"){
			myText = "As you were approaching them, one of the doors opened and a monster appears. It spots you and starts charging at you. You start to run towards a door. \n\nPress Left to go to the Middle Door \nPress Right to go to the Right Door";
			}
			else if(action == "run_middle"){
				myText = "You ran towards the middle door and tried to open the door, but it was locked. Bye. The monster grabbed you by the head and swallowed you whole.\n\nPress Backspace to go Back";
			}
			else if(action == "run_right"){
				myText = "You ran towards the right door and the door opened. \n\n=_=' You guessed, instead of trying to solve it...\n\nPress Up To Continue";
				goNext = true;
			}
			else if(action == "talk"){
				myText = "Who do you want to talk to?\n\nPress Left to go to the Left Girl\nPress Up to go to the Middle Girl\nPress Right to go to the Right Girl\nPress Down to read Question";
			}
			else if(action == "talk_left"){
				myText = "Left Girl\n\nWho are you?\nGo away! You should have never come to this wretched house.\n\nWho is standing next to you?\nHer NAME is Truth.\n\nPress Backspace to go Back";
			}
			else if(action == "talk_middle"){
				myText = "Middle Girl\n\nWho are you?\nMy name is Wisdom. I'm sorry about my sisters; it's been a while since we've seen anyone new here.\n\nWho is standing to your left?\nTruth\n\nWho is standing to your right?\nLie\n\nPress Backspace to go Back";
			}
			else if(action == "talk_right"){
				myText = "Right Girl\n\nWho are you?\nLooks away.\n\nWho is standing next to you?\nLie\n\nPress Backspace to go Back";
			}
			else if(action == "hint"){
				myText = "When you ask the girl on the left, 'Who is standing next to you?' She answers Truth.\n\nWhen you asked the middle girl, 'Who are you?' She answers Wisdom.\n\nWhen you asked the girl on the right, 'Who is standing next to you?' She answers Lie. \n\nThink about who is definitely lying. Both sides have different answers for who is in the middle.\n\n\nPress Backspace to go Back";
			}
			else if(action == "question"){
				myText = "Who do you trust your life with?\n\nPress Left to go to the Left Girl\nPress Up to go to the Middle Girl\nPress Right to go to the Right Girl\n\nPress Backspace to go Back";
				if(hint){
					myText = "Who do you trust your life with?\n\nPress Left to go to the Left Girl\nPress Up to go to the Middle Girl\nPress Right to go to the Right Girl\nPress Down to read Hint\n\nPress Backspace to go Back";	
				}
			}
			else if(action == "choose_left"){
				myText = "Left Girl\n\nYou enter a dark room and noticed a pair of glowing eyes staring at you.\n\nPress Spacebar to Continue";
				if(Input.GetKeyDown(KeyCode.Space)){
					sfxSource.clip = roarSound;
					sfxSource.Play();
					room = "monster";
				}
			}
			else if(action == "choose_middle"){
				myText = "Middle Girl\n\nYou enter a dark room and started to walk forward.";
				if(Input.GetKeyDown(KeyCode.Space)){
					sfxSource.clip = screamSound;
					sfxSource.Play();
					room = "pit";
				}
			}
			else if(action == "choose_right"){
				myText = "Right Girl\n\nYou enter the room and the door closed behind you. It was very bright and so you couldn't keep your eyes open to see what is around you. \n\n\n Press Up to Continue";
				goNext = true;
			}
		}
		
		if(room == "monster"){
			//Maybe talk to the monster.... I don't know... Add some silly jokes here and have the player die anyways in the end
			myText = "Roar.\n\nHello?\n\nRoar, ro roar roar.\n\n(Inner thought: Oh no...)\n\nROAR!!!\n\nThe monster got too fed up with you and decided to eat you.\n\nPress Backspace to go Back";
		}
		if(room == "pit"){
			myText = "AHHHhhhhhhhhhhhh......! \n\nPress Backspace to go Back";
		}

		//4th Puzzle - The Four Rooms
		if(room == "hallway"){
			goNext = false;
			myText = "You see five doors and a table in the middle of the hallway. You walk up to the table. On this table consists of: \na toy car\na copper box\n\nPress Up To Continue\nPress Down to Look at the Copper Box";
			if(Input.GetKeyDown(KeyCode.DownArrow) && action != "solve_box" && counter < 1){
				action = "look_box";
				counter = 0;
			}
			else if(Input.GetKeyDown(KeyCode.UpArrow)&& action != "solve_box" && counter < 1){
				room = "hallway";
				counter = 1;
			}
			else if(counter == 1){
				myText = "Press Up to go to the door\n\nPress Left to go to Talkative Girl's Room\n\nPress Right to go to Tiny Boy's Room\n\nPress Down to go down the Hallway";
				if(Input.GetKeyDown(KeyCode.UpArrow) && action != "solve_box"){
					room = "door";
				}
				else if(Input.GetKeyDown(KeyCode.LeftArrow) && action != "solve_box"){
					room = "talkative_girl";
					action = "null";
				}
				else if(Input.GetKeyDown(KeyCode.RightArrow) && action != "solve_box"){
					room = "tiny_boy";
					action = "null";
				}
				else if(Input.GetKeyDown(KeyCode.DownArrow)){
					counter = 2;
					action = "null";
				}
			}
			else if(counter == 2){
				myText = "Press Left to go to Dancing Girl's Room\n\nPress Right to go to Ribbon Girl's Room\n\nPress Up to go up the Hallway\n\nPress Down to Look at Copper Box";
				if(Input.GetKeyDown(KeyCode.DownArrow)){
					action = "look_box";
				}
				else if(Input.GetKeyDown(KeyCode.LeftArrow)){
					action = "null";
					room = "dancing_girl";
										
				}
				else if(Input.GetKeyDown(KeyCode.RightArrow)){
					action = "null";
					room = "ribbon_girl";
				}
				else if(Input.GetKeyDown(KeyCode.UpArrow)){
					action = "null";
					counter = 1;
				}
			}
			if(action == "look_box"){
				if(solved && counter == 2 && ring){
					if(Input.GetKeyDown(KeyCode.DownArrow)){
						action = "box_empty";
						if(action == "box_empty"){
							myText = "It is empty.\n\nPress Backspace to go Back";
						}	
					}
				}
				else{
					myText = "The copper box is locked. \n\nPress Spacebar to try solve the box";
					if(Input.GetKeyDown(KeyCode.Space) && !solved){
						counter = 0;
						action = "solve_box";
					}
				}
			}
			if(action == "solve_box"){
				myText = "Do you remember the answers?\n\nPress Spacebar to Continue";
				if(Input.GetKeyDown(KeyCode.Space) && counter < 1){
					counter = 1;
				}
				if(counter == 1){
					myText = "Which is heavier: a ton of gold or a ton of feathers?\n\nA)Gold\nB)for Feathers\nC)Neither";
					if(Input.GetKeyDown(KeyCode.A)){
						action = "sorry";
					}
					else if(Input.GetKeyDown(KeyCode.B)){
						action = "sorry";
					}
					else if(Input.GetKeyDown(KeyCode.C)){
						counter = 2;
					}
				}
				else if(counter == 2){
					myText = "My family consists of me and my wife. We have six daughters and each daughter has one brother.\nHow many people are in his family?\n\nPress the number.";
					if(Input.GetKeyDown(KeyCode.Alpha9)){
						counter = 3;
					}
				}
				else if(counter == 3){
					myText = "When you ask the girl on the left, 'Who is standing next to you?' She answers Truth.\n\nWhen you asked the middle girl, 'Who are you?' She answers Wisdom.\n\nWhen you asked the girl on the right, 'Who is standing next to you?' She answers Lie.\n\nWho is who?\n\nA) Wisdom, Truth, Lie\nB)Wisdom, Lie, Truth\nC)Truth, Wisdom, Lie\nD)Truth, Lie, Wisdom\nE)Lie, Truth, Wisdom\nF)Lie, Wisdom, Truth";
					if(Input.GetKeyDown(KeyCode.A)){
						action = "sorry";
					}
					else if(Input.GetKeyDown(KeyCode.B)){
						action = "correct_answer";
						sfxSource.clip = collectSound;
						sfxSource.Play();
					}
					else if(Input.GetKeyDown(KeyCode.C)){
						action = "sorry";
					}
					else if(Input.GetKeyDown(KeyCode.D)){
						action = "sorry";
					}
					else if(Input.GetKeyDown(KeyCode.E)){
						action = "sorry";
					}
					else if(Input.GetKeyDown(KeyCode.F)){
						action = "sorry";
					}
				}
			}
			if(action == "correct_answer"){
				solved = true;
				ring = true;
				myText = "Congratulation, you opened the box and found a ring.\n\nPress Spacebar to Continue";
				if(Input.GetKeyDown(KeyCode.Space)){
					action = "null";
					counter = 1;
				}
			}
			else if(action == "sorry"){
				myText = "Sorry. \n\nPress Spacebar to Continue";
				if(Input.GetKeyDown(KeyCode.Space)){
					action = "null";
				}
			}
		}


		if(room == "ribbon_girl"){
			myText = "Ribbon Girl's Room\n\nYou see a girl holding a teddy bear sitting on her bed. She doesn't seem happy.\n\nPress Up to Talk to her\nPress Backspace for Maybe later...";
			if(action == "talk_girl"){
				myText = "Ribbon Girl's Room\n\nWhat's wrong?\n\nIt's all my fault! It is because I lost it that made mommy mad at daddy.\n\nPress Spacebar to Continue";
				if(Input.GetKeyDown(KeyCode.Space)){
					action = "ask_me";
				}
			}
			if(action == "ask_me"){
				myText = "Ribbon Girl's Room\n\nI lost her ring. Did you see it?!\n\nPress Up to Give her ring\nPress Down to Reply no";
			}
			if(action == "give_ring_girl"){
				myText = "Ribbon Girl's Room\n\nI stumbled upon this in the hallway, is this the ring you are looking for?\n\nIT IS!!!Here, I will give you this teddy bear in exchange for finding me the ring.\n\nObtained Teddy Bear*\n\nPress Backspace to go Back to the Hallway";
				teddy_bear = true;
			}
			if(action == "reply_no"){
				myText = "Ribbon Girl's Room\n\nOh... Press Backspace to go Back";
			}
		}
		
		if(room == "dancing_girl"){
			if(!blue_paint){
				myText = "Dancing Girl's Room\n\nYou start to open the door but as soon as you turned the knob, the door flung open violently as a burst of wind blows at you.\n\nBarely able to see, you try to \n\nPress Left to Close the door\nPress Up to Talk to the tornado\nPress Right to Try to stop the tornado\n\nPress Backspace to go Back";
				if(Input.GetKeyDown(KeyCode.LeftArrow)){
		 			action = "close_door";
		 		}
			}
			else{
				myText = "Dancing Gir's Room'\n\nHi again stranger. I'm sorry about eariler.\n\nPress Spacebar to Continue";
				if(Input.GetKeyDown(KeyCode.Space)){
					action = "hasItem";
				}
			}
			//Close the door
			if(action == "close_door"){
				myText = "You push your hardest to close the door. But it simply won't budge.\n\nA mouse comes by and uses its tail to close the door. He smirks at you and run back to his home. Press Backspace";
			}
			//Talk to tornado
			else if(action == "talk_tornado"){
				myText = "Your voice gets drowned out.";
			}
			//Stop tornado
			else if(action == "stop_tornado"){
				if(ribbon){
					myText = "Dancing Girl's Room\n\nThank you stranger. It was hard to stop spinning once I start to spin because I don't know when to stop. Here is some blue paint in return for helping me.\n\nObtained Blue Paint*\n\nPress Backspace to go Back to the Hallway";
					blue_paint = true;
				}
				else{
					myText = "You get torn to shreds.";
				}
			}
			//hasItem
			else if(action == "hasItem"){
				if(watch){
					myText = "Dancing Girl's Room\n\nHere is a watch. This will help you with timing yourself hopefully.\n\nOh~ You are so nice. Here, this is for you.\n\nObtained key*\n\nPress Backspace to go Back";
					key = true;
				}
				else{
					myText = "Dancing Girl's Room\n\nMy sister would usually time me so I don't create a mess. Sigh~\n\nPress Backspace to go Back ";
				}
			}
		}

		if(room == "talkative_girl"){
			//What's your story? Get teddy bear gives ribbon from teddy bear
			myText = "Talkative Girl\n\nHi. It is so lonely by myself. You know, my favorite color is... blahblahblahblahblahblahblahblah.\n\nYou start to zone out and noticed a doll missing from her collection.\n\nHey! Are you listening?\n\nUh. Yeah. \n\nPress Up to Show Teddy Bear\nPress Backspace to go Back";
			//
			if(action == "give_teddy_bear_girl"){
				myText = "Here is a teddy bear.\n\nMy collection is complete now.\nThank you!\n\nShe grabs a ribbon from another teddy bear and gives it to you.\n\nObtained Ribbon*\n\nPress Backspace to go Back to the Hallway";
				ribbon = true;
			}
		}

		if(room == "tiny_boy"){
			//What's your story? Get blue car
			if(!found_boy){
				myText = "Tiny Boy's Room\n\nYou walk in the room and don't see anyone in the room.\n\nHi\n\nO-O Who's there?\n\n Um... I'm down here.\n\nPress Spacebar to look around the room";
				if(Input.GetKeyDown(KeyCode.Space) && action == "null"){
					action = "look_around_room";
				}
			}
			else if(found_boy && !blue_paint){
				myText = "Tiny Boy's Room\n\nHi. Did you find my blue toy car?\nPress Backspace to go Back";
			}
			else{
				action = "give_toy_car";
			}
			//Look around room
			if(action == "look_around_room"){
				myText = "Tiny Boy's Room\n\nPress Left to look under the Table\nPress Up to look under the Bed\nPress Right to look behind the Chair";
			}
			else if(action == "look_table"){
				myText = "Tiny Boy's Room\n\nOh! Why are you hiding under the table?\n\nI'm looking for something.\n\nPress Spacebar to Continue";
				found_boy = true;
				if(Input.GetKeyDown(KeyCode.Space)){
					action = "ask_boy";
				}
			}
			else if(action == "look_bed"){
				myText = "Tiny Boy's Room\n\nYou found a family of dust bunnies under the bed.\n\nPress Backspace to go Back";
			}
			else if(action == "look_chair"){
				myText = "Tiny Boy's Room\n\nYou found nothing behind the chair.\n\nPress Backspace to go Back";
			}
			else if(action == "ask_boy"){
				myText = "Tiny Boy's Room\n\nAre you looking for ....\n\nPress Left for Teddy Bear\nPress Up for Ring\nPress Down for Toy Car\nPress Right for copper box\n\nPress Backspace to go Back";
			}
			else if(action == "give_copper_box"){
				myText = "Tiny Boy's Room\n\nNo.\n\nThat belongs to my sister who has lost my mom's ring. She forgot the combination to open her locked case.\n\nPress Backspace to go Back";
			}
			else if(action == "give_teddy_bear"){
				myText = "Tiny Boy's Room\n\nNo.\n\nPress Backspace to go Back";
			}
			else if(action == "give_ring"){
				myText = "Tiny Boy's Room\n\nNo silly. I'm not a girl.\n\nPress Backspace to go Back";
			}
			else if(action == "give_toy_car"){
				if(blue_paint){
					myText = "Tiny Boy's Room\n\nWow! It's my toy car. Here! Have this watch, it doesn't fit me anyways.\n\nObtained Watch*\n\nPress Backspace to go Back";
					watch = true;
					if(Input.GetKeyDown(KeyCode.Backspace)){
						room = "hallway";
					}
				}
				else{
					myText = "Tiny Boy's Room\n\nHow did you know I lost toy car?\n\nShow him the toy car.\n\n...no..That's not my toy car. My toy car is blue.\n\nPress Backspace to go Back";
				}
			}
		}	

		if(room == "door"){
			//hasKey
			if(!key){
				myText = "The door is locked.\n\nPress Backspace to go Back";
			}
			else{
				myText = "The key fits the keyhole. You turn the knob of the door and you are free!\n\nCongratuations. You win!";
			}
		}



		//Press Backspace to go Back
		if(Input.GetKeyDown(KeyCode.Backspace)){
		 	if(action == "look_at_scale" || action == "run_middle"){
		 		action = "null";
		 	}
		 	else if(action == "man_ending_one"){
		 		action = "look_around";
		 	}
		 	else if(action == "man_ending_two"){
		 		action = "help_man";
		 	}
		 	else if(room == "pit" || room == "monster"){
		 		room = "truth_wisdom_liar";
		 		action = "null";
		 	}
		 	else if(action == "question" || action == "talk_middle" || action == "talk_right" || action == "talk_left"){
		 		action = "talk";
		 	}
		 	else if(action == "hint"){
		 		action = "question";
		 	}
		 	else if(action == "look_chair" || action == "look_bed"){
		 		action = "look_around_room";
		 	}
		 	else if(action == "give_ring" || action == "give_toy_car" || action == "give_copper_box" || action == "give_teddy_bear"){
		 		action = "ask_boy";
		 	}
		 	else if((action == "stop_tornado" && !ribbon) || action == "talk_tornado" || action == "close_door" || action == "look_box" || action == "look_bed" || action == "look_chair"){
		 		action = "null";
		 	}
		 	else if(room == "tiny_boy" || room == "dancing_girl" || room == "talkative_girl" || room == "ribbon_girl" || (room == "door" && !key)){
		 		room = "hallway";
		 	}
		}

		//Press Up to move to different rooms and for different choices
		if(Input.GetKeyDown(KeyCode.UpArrow)){
		 	if(goNext){
		 		if(room == "scale_room"){
		 			room = "hopeless_man";
		 			action = "null";
		 		}
		 		else if(room == "hopeless_man"){
		 			room = "truth_wisdom_liar";
		 			action = "null";
		 		}
		 		else if(room == "truth_wisdom_liar"){
		 			room = "hallway";
		 			action = "null";
		 		}
		 		return;
		 	}
		 	
		 	else if(action == "help_man"){
		 		action = "man_ending_two";
		 	}
		 	else if(action != "man_ending_two" && action != "man_ending_one"){
		 	 	if(action == "look_around"){
		 	 		action = "help_man";
		 	 	} 
		 	 	else if(room == "hopeless_man"){
		 	 		action = "help_man";
		 	 		hint = true;
		 	 	}
		 	}

		 	if(room == "truth_wisdom_liar" && action == "null"){
		 		sfxSource.clip = roarSound;
		 		sfxSource.Play();				
				action = "look_at_nametags";
		 	}
		 	else if(action == "talk"){
		 		action = "talk_middle";
		 	}
		 	else if(action == "question"){
				action = "choose_middle";
			}

			if(room == "tiny_boy" && action == "look_around_room"){
				action = "look_bed";
			}

			if(room == "tiny_boy" && action == "ask_boy"){
		 		action = "give_ring";
		 	}

		 	if(room == "ribbon_girl" && action != "ask_me"){
		 		action = "talk_girl";
		 	}
		 	
		 	if(action == "ask_me"){
				if(ring){
					action = "give_ring_girl";
				}
		 	}

		 	if(teddy_bear && room == "talkative_girl"){
		 		action = "give_teddy_bear_girl";
		 	}

		 	if(room == "dancing_girl" && action == "null"){
		 		action = "talk_tornado";
		 	}
		}

		//Press Down
	 	if(Input.GetKeyDown(KeyCode.DownArrow)){
	 		if(room == "hopeless_man" && action == "null"){
				action = "look_around";
			}
			else if(room == "truth_wisdom_liar" && action == "null"){
		 		action = "talk";
		 	}
	 		else if(action == "help_man"){
				action = "man_passed";
			}
	 		else if(action == "look_around"){
	 			action = "man_ending_one";
	 		}
	 		else if(action == "talk"){
	 			action = "question";
	 		}
	 		else if(hint){
	 			if(action == "question"){
	 				action = "hint";
	 			}
	 		}
	 		if(action == "ask_boy"){
		 		action = "give_toy_car";
		 	}

		 	else if(action == "ask_me"){
		 		action = "reply_no";
		 	}

		 	else if(action == "look_box"){
		 		counter = 0;
		 		if(solved){
		 			room = "hallway";
		 			action = "null";
		 		}
		 		else{
		 			action = "solve_box";
		 		}
		 	}
		}
		
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			if(action == "help_man"){
				action = "man_ending_two";
			}
			else if(action == "look_at_nametags"){
				action = "run_middle";
			}
			else if(action == "talk"){
				action = "talk_left";
			}
			else if(action == "question"){
				action = "choose_left";
			}
			else if(action == "look_around_room"){
				action = "look_table";
			}
			else if(action == "ask_boy" && room == "tiny_boy"){
		 		action = "give_teddy_bear";
		 	}
		}

		if(Input.GetKeyDown(KeyCode.RightArrow)){
			if(action == "help_man"){
				action = "man_ending_two";
			}
			else if(action == "look_at_nametags"){
				action = "run_right";
			}
			else if(action == "talk"){
				action = "talk_right";
			}
			else if(action == "question"){
				action = "choose_right";
			}
			else if(room == "tiny_boy" && action == "look_around_room"){
				action = "look_chair";
			}
			else if(action == "ask_boy"){
		 		action = "give_copper_box";
		 	}
		 	else if(room == "dancing_girl" && action == "null"){
		 		action = "stop_tornado";
		 	}
		}

		GetComponent<Text>().text = myText;

	}
}
