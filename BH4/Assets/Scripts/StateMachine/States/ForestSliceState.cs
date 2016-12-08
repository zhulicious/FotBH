﻿using Assets.Code.Interfaces; //This state is for the verticle slice.
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.States
{
    public class ForestSliceState : IStateBase
    {
        private StateMachine _stateMachine;
        private AudioManager _audioManager;
        private Dictionary<string, AudioClip> forestCreatureTrack;
        private AllAudioUsedInScene aauis;
       
        private Dictionary<string, AudioClip> gameover;

        private bool debugLog;




        public ForestSliceState(StateMachine stateMachine_Ref)
        {
            CheckDebugLogBool(stateMachine_Ref);

            if (debugLog) Debug.Log("Constructing SliceState");

          
            _stateMachine = stateMachine_Ref;
            _audioManager = stateMachine_Ref._audioManager;
            aauis = _audioManager.AAUIS;
            forestCreatureTrack = aauis.musicAudioPackage.mus_dictionary["ForestCreature"];
           
            gameover = new Dictionary<string, AudioClip>();
            _stateMachine.tuva = GameObject.Find("Tuva");

            UnloadAssets();
            LoadAssets();

            _audioManager.PlayATM(true);

            if (debugLog) Debug.Log("SliceState constructed!");

        }
        public void StateUpdate()
        {

        }
        public void LoadAssets()
        {
            if (debugLog) Debug.Log("Loading Assets for SliceState...");
            //ForestCreature
            aauis.fcAudioPackage.fx.Add("screams", Resources.LoadAll<AudioClip>("Audio/Actor/ForestCreature"));

            //TuvaFolay
            aauis.tuvaAudioPackage.foley.Add("puddleFootsteps", Resources.LoadAll<AudioClip>("Audio/Actor/Tuva/FootSteps/Puddles"));
            aauis.tuvaAudioPackage.foley.Add("grassFootsteps", Resources.LoadAll<AudioClip>("Audio/Actor/Tuva/FootSteps/Grass"));
            aauis.tuvaAudioPackage.foley.Add("woodFootsteps", Resources.LoadAll<AudioClip>("Audio/Actor/Tuva/FootSteps/Wood"));


            //LyktGubben
            aauis.lgAudioPackage.foley.Add("grassFootsteps", Resources.LoadAll<AudioClip>("Audio/Actor/Tuva/FootSteps/Grass"));

            //ATM
            aauis.atm["atm_one"] = Resources.Load<AudioClip>("Audio/BackgroundTracks/Audio_ForestBackground");
            aauis.atm["atm_two"] = Resources.Load<AudioClip>("Audio/SoundFX/Environment/Miscellaneous/Audio_OwlHooting");
            _audioManager.AllAudioSources["atm_one"].clip = aauis.atm["atm_one"];
            _audioManager.AllAudioSources["atm_two"].clip = aauis.atm["atm_two"];

            //Music
           


            forestCreatureTrack.Add("wholeBass", Resources.Load<AudioClip>("Audio/Music/TreeCreature/Bass"));
            forestCreatureTrack.Add("wholeMelody", Resources.Load<AudioClip>("Audio/Music/TreeCreature/High"));
            forestCreatureTrack.Add("wholePercussion", Resources.Load<AudioClip>("Audio/Music/TreeCreature/Percussion"));

            
                _audioManager.AllAudioSources["musicBass"].clip = forestCreatureTrack["wholeBass"]; //Placing audiotracks in correct audiosource.
                _audioManager.AllAudioSources["musicMelody"].clip = forestCreatureTrack["wholeMelody"];
                _audioManager.AllAudioSources["musicPercussion"].clip = forestCreatureTrack["wholePercussion"];

            aauis.musicAudioPackage.musicTracks.Add("GameOver", Resources.Load<AudioClip>("Audio/Music/GameOver"));
            


           
            




            if (debugLog) Debug.Log("SliceState Loaded");
        }
        public void UnloadAssets()
        {
            if (debugLog) Debug.Log("Unloading not needed Assets");

            _audioManager.PlayATM(false);
            aauis.atm["atm_one"] = null;
            
            if (debugLog) Debug.Log("Assets unloaded.");

        }


        public void CheckDebugLogBool(StateMachine o)
        {
            if (o.DebugLog) debugLog = true;
        }
    }
}
