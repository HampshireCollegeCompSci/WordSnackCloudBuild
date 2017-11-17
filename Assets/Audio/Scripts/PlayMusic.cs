﻿using UnityEngine;
using System.Collections;
public class PlayMusic : MonoBehaviour
{
	
		public GameObject audio;
		AudioManager audioManager;
	
		//PlayButtonHandler playButtonHandler;
		//AboutButtonHandler aboutButtonHandler;

		//public GameObject selecter;
		//CharacterSelectUI charSel;

		public GameObject VariableControl;
		VariableControl variables;

		//public GameObject wordControl;
		//wordBuildingController words;

		// public GameObject character;
		//Character charac;

		int numSelected = 0;

		//ReceiptMove receipt;
		//public GameObject receiptScript;

		//GoBackToMenu toMenu;
		//public GameObject toMenuScript;

		//bool playedVictory = false;

		int i = 0;

		//LetterController letterController;
	
		//Booleans for Stove Sound Looping.
		bool sizzleStart = false;
		bool sizzleEnd = false;
		bool playedSteamEnd = false;
		bool sizzled = false;

		//Boolean 
		//bool letterGen;


		//public GameObject audioManager;
	
		// Use this for initialization
		void Start ()
		{
		
				audioManager = audio.GetComponent<AudioManager> ();
				audioManager.SetAllVolume ();


				if (Application.loadedLevelName == "SplashScreen") {
						//Plays the Space Ship Sound with a possible delay.
						Invoke ("SpaceShipSound", 0);
				}

				if (Application.loadedLevelName == "ScoreScreen") {

                        audioManager.Play(16);
				}

		}
	
		// Update is called once per frame
		void Update ()
		{

                //Splash Screen Sounds

                if (GameObject.Find("VariableController") && (variables != GameObject.Find("VariableController").GetComponent<VariableControl>()))
                {
                    variables = GameObject.Find("VariableController").GetComponent<VariableControl>();
                }

				if (Application.loadedLevelName == "About") {
						if (GameObject.Find ("Text").GetComponent<AboutUsMove> ().clickSound) {
								audioManager.Play (1);
								GameObject.Find ("Text").GetComponent<AboutUsMove> ().clickSound = false;
						}
				}


				if (Application.loadedLevelName == "SplashScreen") {
						//Stops any other music or sound tracks that may still be playing.
						audioManager.Stop (34);
						audioManager.Stop (35);
                        audioManager.Stop(5);
						audioManager.Stop (20);
						audioManager.Stop (16);
						audioManager.Stop (14);
						//Plays the Menu Music
						audioManager.PlayLoop (4);
				}

				if (Application.loadedLevelName == "StartScreenTest") {
						//Stops any music that should not be playing
						audioManager.Stop (34);
						audioManager.Stop (35);
                        audioManager.Stop(5);
						audioManager.Stop (20);
						audioManager.Stop (16);
						audioManager.Stop (14);

						//Plays the menu music only if it is not already playing.
						if (audioManager.audioSourceArray [4].isPlaying == false) {
								audioManager.PlayLoop (4);
						}
						//Click sound for Play button and About Button.
						if (GameObject.Find ("PlayButton").GetComponent<PlayButtonHandler> ().buttonPressed == true || GameObject.Find ("AboutButton").GetComponent<AboutButtonHandler> ().buttonPressed == true) {
								audioManager.Play (1);
						}
				}

				//Sounds for Character Select Screen
				if (Application.loadedLevelName == "CharacterSelectTest") {

						//Stops any sounds that should not be playing.
						audioManager.Stop (34);
						audioManager.Stop (35);
                        audioManager.Stop(5);
						audioManager.Stop (20);
						audioManager.Stop (16);
						audioManager.Stop (14);

						//Plays menu music if it is not already playing.
						if (audioManager.audioSourceArray [4].isPlaying == false) {
								audioManager.PlayLoop (4);
						}
						//////////////////////////////////
						//Character Select Sound effects//
						//////////////////////////////////

						//Plays Click sound when first character is selected. Plays second character selected sound when second character is selected.
						if (variables.currentCharacterSelectNum > numSelected) {
								if (numSelected == 0) {
										audioManager.Play (1);
								} else {
										audioManager.Play (1);
										Invoke ("CharacterSelectTwo", .3f);
								}
								//Debug.Log("ding");
								numSelected++;
								if (variables.currentCharacterSelectNum == 0) {
										numSelected = 0;
								}
						}

						//Plays click sound when characters are unselected.
						if (variables.currentCharacterSelectNum < numSelected) {
								audioManager.Play (1);
								numSelected--;
								Debug.Log (numSelected.ToString ());
						}

						//Plays "FeedMe" sound when feed them button is pressed.
						if (GameObject.Find ("feedMe").GetComponent<CharacterSelectUI> ().FeedPressed == true) {
								audioManager.Play (2);
								GameObject.Find ("feedMe").GetComponent<CharacterSelectUI> ().FeedPressed = false;
						}
				}
				////////////////////////////
				//Word Making Phase Sounds//
				////////////////////////////
				if (Application.loadedLevelName == "WordMaking") {
						//Stops the Menu Music.
						audioManager.Stop (4);
						//Loops the GamePlay Music.
						if (variables.instructionsDone && !variables.paused) {
								if (!variables.timedMode) {
										audioManager.PlayLoop (34);
								} else if (variables.timedMode && !audioManager.audioSourceArray[35].isPlaying) {
										audioManager.Play (35);
								}
						}
						NewOnStove ();
						Sizzle ();
						RejectedSound ();
						Chewing ();
						Shuffle ();
						Pause ();
						ClickSound ();
						TimedWarning ();
						KitchenClosed ();
                        Mute();
                        WhatTheFunk();

				}
				///////////////////////
				//Score Screen Sounds//
				///////////////////////
				if (Application.loadedLevelName == "ScoreScreen") {
						//Stops the GamePlay Music
						audioManager.Stop (34);
						audioManager.Stop (35);
                        audioManager.Stop(5);
						// if (gameObject.GetComponent<ReceiptMove>().winSound == true)

						//////////////////
						//LOOPED VERSION//
						//////////////////

						//if (GameObject.Find("ReceiptPrefab").transform.position.y < 1.20)
						//{
						//    audioManager.PlayLoop(20);
						//    audioManager.PlayLoop(14);
						//    //  audioManager.FadeOut(17);
						//    //receipt.winSound = false;
						//}
						//else if (playedVictory == false && audioManager.audioSourceArray[14].isPlaying == false)
						//{
						//    // audioManager.KillAll();
						//    audioManager.Play(15);
						//    playedVictory = true;
						//    Debug.Log("helllyeah");
						//}

						//Loops the Victory Music until receipt stops moving.
						//if (GameObject.Find("ReceiptPrefab").transform.position.y < 1.20)
						//{


						//}

						//Loops the Receipt printing sounds while the receipt is both on screen and moving.
						for (int x = 1; x == 1; x++) {
								if ((1.20 > GameObject.Find ("ReceiptPrefab").transform.position.y) && (GameObject.Find ("ReceiptPrefab").transform.position.y > -6.5)) {
										if (GameObject.Find ("ReceiptPrefab").GetComponent<ReceiptMover> ().Touched == false) {
												audioManager.PlayLoop (20);
										} else {
												audioManager.Stop (20);
										}
								}
						}
        
						//Click Sound for Menu Button
						if (GameObject.Find ("Menu").GetComponent<GoBackToMenu> ().clickSound == true) {
								Debug.Log ("it has played");
								audioManager.Play (1);
								GameObject.Find ("Menu").GetComponent<GoBackToMenu> ().clickSound = false;
						}
						//Click Sound for Play Again Button.
						if (GameObject.Find ("PlayAgain").GetComponent<PlayAgain> ().clickSound == true) {
								audioManager.Play (1);
								GameObject.Find ("PlayAgain").GetComponent<PlayAgain> ().clickSound = false;
						}
			
				}
                else
                {
                    audioManager.Stop(20);
                    audioManager.Stop(16);
                }


		}



		// Update is called once per frame

		//NewOnStove plays letter select sound when letters move to the stove, letter deselect sound when moving letters off the stove.
		void NewOnStove ()
		{
				// if (GameObject.Find("letterGeneration").GetComponent<LetterController>().numLettersOnStove == 0)
				//{
				//  i = 0;
				// }
				if (GameObject.Find ("letterGeneration").GetComponent<LetterController> ().numLettersOnStove > i) {
						audioManager.Play (6);
						i++;
				}
				if (GameObject.Find ("letterGeneration").GetComponent<LetterController> ().numLettersOnStove < i) {
                    if (!audioManager.audioSourceArray[8].isPlaying && !audioManager.audioSourceArray[18].isPlaying)
                    {
                        audioManager.Play(8);
                    }
						i--;
				}
		}
		//Method to play Happy sounds when a character likes a word.
		//void HappySound()
		//{
		//    if (variables.happySound > 0)
		//    {
		//        audioManager.Play(variables.happySound);
		//        variables.bonus = false;
		//        variables.happySound = 0;
		//    }
		//}
	
		//RejectedSound plays the rejected sound when a character is fed something that is not a word.
		void RejectedSound ()
		{
				if (variables.sadSound != 0 && !audioManager.audioSourceArray[12].isPlaying) {
						audioManager.Play (variables.sadSound);
						variables.sadSound = 0;
				}
		}

		//Sizzle plays the sizzle sound when letters are on the stove.
		void Sizzle ()
		{
				//Stops any sizzling if there are no letters on the stove.
				if (GameObject.Find ("letterGeneration").GetComponent<LetterController> ().numLettersOnStove == 0) {
						sizzleStart = false;
						sizzleEnd = false;
		   
						audioManager.Stop (10);
				}
				//Plays the beginning of the sizzle sound when a letter is added to the stove.
				if (sizzleStart == false && GameObject.Find ("letterGeneration").GetComponent<LetterController> ().numLettersOnStove > 0) {
						audioManager.Play (9); // start sound goes 
						sizzleStart = true;
		   
				}
				//Loops the middle of the sizzle sound while the letter is on the stove.
				if (sizzleStart == true && audioManager.audioSourceArray [9].isPlaying == false && GameObject.Find ("letterGeneration").GetComponent<LetterController> ().numLettersOnStove > 0) {
//           audioManager.SetVolume(11, 0.2f); //play sizzle loop
						audioManager.PlayLoop (10);
						sizzled = true;
						playedSteamEnd = false;

				} else {
						audioManager.Stop (10);
				}
				//Plays the end of the sizzle sound when the letter is removed from the stove.
				if (playedSteamEnd == false && audioManager.audioSourceArray [9].isPlaying == false && sizzled == true && GameObject.Find ("letterGeneration").GetComponent<LetterController> ().numLettersOnStove == 0) {
						audioManager.Play (11);
						Debug.Log ("steamend");
						playedSteamEnd = true;

				}



		
		}
		//Plays the sounds related to feeding a character an actual word.
		void Chewing ()
		{
				//First plays Chewing sound if the character is not the trash character, otherwise plays the trash sound.
				if (variables.chewing == true) {
                        variables.chewed = true;
						audioManager.Play (variables.eatingSound);
						audioManager.Play (variables.chewingSound);
						audioManager.Play (variables.eatingSound);
						variables.chewing = false;
						//Next, checks for tastes if the character is not the trash character.
						if (variables.chewingSound == 13) {

                            if (variables.mostRecentWordScore >= 100)
                            {
                                audioManager.Play(38);
                            }

                            else if (variables.bigMealSound)
                            {
                                audioManager.Play(39);
                            }
                            
                            //If only one taste is met, play "Taste matched sound.
                            //if ((variables.timeToHighlightTaste[0] && variables.timeToHighlightTaste[1]) || (variables.timeToHighlightTaste[2] && variables.timeToHighlightTaste[3]))
                            else if (variables.doubleTasteSound)
                            {
                                audioManager.Play(23);
                                variables.doubleTasteSound = false;
                            }
                            else if (variables.bonus)
                            {
                                audioManager.Play(21);
                                Debug.Log("Taste");

                            }
                            //If no tastes are met, play neutral sound.
                            else
                            {
                                audioManager.Play(22);
                                Debug.Log("Neutral");
                            }
						}
						MoreDelayedLetterGeneration ();
						Debug.Log ("Letter Generation");

				}
				// words.bothTastes = false;
		}
		void Shuffle ()
		{
				if (variables.shuffleSound == true)
						audioManager.Play (19);
				variables.shuffleSound = false;

				; 
		}
		void LetterGenerationSound ()
		{
				audioManager.Play (7);
				//      variables.letterGenerationSound = false;
				Debug.Log ("generation");
		}
		void DelayedLetterGeneration ()
		{
				Invoke ("LetterGenerationSound", 0.5f);
		}
		void MoreDelayedLetterGeneration ()
		{
				Invoke ("LetterGenerationSound", 0.4f);
		}
		void Pause ()
		{
            if (GameObject.Find("resumeButton"))
            {
                if (GameObject.Find("resumeButton").activeSelf)
                {
                    for (int j = 2; j < audioManager.volumeArray.Length; j++)
                    {
                        audioManager.SetVolume(j, 0);
                    }
                    audioManager.Pause(34);
                    audioManager.Pause(35);
                    audioManager.Pause(36);
                    audioManager.Pause(5);
                }
                else
                    for (int i = 1; i < audioManager.audioSourceArray.Length; i++)
                    {
                        if (audioManager.audioSourceArray[i].volume != audioManager.volumeArray[i])
                        {
                            audioManager.SetVolume(i, audioManager.volumeArray[i]);
                        }
                    }
            }
				//else if (GameObject.Find("VariableController").GetComponent<LetterController>().gamePaused == true)
				//{

				//}
		}
		//void SuccessSound()
		//{
		//    audioManager.Play(13);
		//}
		//void DelayedSuccessSound()
		//{
		//    Invoke("SuccessSound", 0.5f);
		//}
		void ClickSound ()
		{
				if (Application.loadedLevelName == "WordMaking") {
						if (GameObject.Find ("pauseButton").GetComponent<pause> ().clickSound == true) {
								audioManager.Play (1);
								GameObject.Find ("pauseButton").GetComponent<pause> ().clickSound = false;
						}

						if (variables.paused == true) {
								if (GameObject.Find ("resumeButton").GetComponent<resumeButton> ().clickSound == true) {
										audioManager.Play (1);
										GameObject.Find ("resumeButton").GetComponent<resumeButton> ().clickSound = false;
								}
								if (GameObject.Find ("exitButton").GetComponent<exitGameplayButton> ().clickSound == true) {
										audioManager.Play (1);
										GameObject.Find ("exitButton").GetComponent<exitGameplayButton> ().clickSound = false;
								}
						}

				}

		}
		void SpaceShipSound ()
		{
				audioManager.Play (26);
		}

		void TimedWarning ()
		{
            if (Application.loadedLevelName == "WordMaking")
            {
                //30 second bell
                if (Mathf.RoundToInt(variables.globalTimer) == 30)
                {
                    if (!audioManager.audioSourceArray[28].isPlaying)
                    {
                        //for (int x = 1; x == 1; x++)
                        //{
                        audioManager.Play(28);
                        //}
                    }
                }
                //15 Second Bell
                if (Mathf.RoundToInt(variables.globalTimer) == 15)
                {
                    if (!audioManager.audioSourceArray[27].isPlaying)
                    {
                        //for (int x = 1; x == 1; x++)
                        //{
                        audioManager.Play(27);
                        //}
                    }
                }
                //Ticking

                if (!variables.timedMode)
                {
                    audioManager.SetVolume(36, 0.0f);
                }
                else
                {
                    audioManager.SetVolume(36, audioManager.volumeArray[36]);
                }

                if (Mathf.RoundToInt(variables.globalTimer) == 14)
                {
                    if (!audioManager.audioSourceArray[36].isPlaying && variables.timedMode)
                    {
                        //for (int x = 1; x == 1; x++)
                        //{
                        audioManager.Play(36);
                        //}
                    }


                }
            }
            else
            {
                audioManager.Stop(27);
                audioManager.Stop(28);
                audioManager.Stop(36);
            }
		}
		void CharacterSelectTwo ()
		{
				audioManager.Play (3);
		}
		void KitchenClosed ()
		{
				if (variables.bellSound && !audioManager.audioSourceArray [37].isPlaying) {
						audioManager.Play (37);
						variables.bellSound = false;
				}
		}

        void Mute()
        {
            if (variables.mute)
            {
                audioManager.MuteAll();
            }
            else
            {
                audioManager.SetAllVolume();
            }
        }

        void WhatTheFunk()
        {
            if (variables.funky == true)
            {
                audioManager.Stop(34);
                audioManager.Stop(35);
                if (!variables.paused)
                {
                    audioManager.PlayLoop(5);
                }
                if (variables.paused)
                {
                    audioManager.Pause(5);
                }
            }
            else
            {
                audioManager.Stop(5);
            }
        }
}