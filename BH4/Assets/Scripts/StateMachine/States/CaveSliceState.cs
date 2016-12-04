using Assets.Code.Interfaces; //This state is for the verticle slice.
using System.Collections.Generic;
using UnityEngine;              //Author: Axel Stenkrona.

namespace Assets.Code.States
{
    public class CaveSliceState : IStateBase
    {
        private StateMachine _stateMachine;
        private AudioManager _audioManager;
     
        private AllAudioUsedInScene aauis;
        private Dictionary<string, AudioClip> musparts;

        private bool debugLog;




        public CaveSliceState(StateMachine stateMachine_Ref)
        {
            CheckDebugLogBool(stateMachine_Ref);

            if (debugLog) Debug.Log("Constructing SliceState");
            _stateMachine = stateMachine_Ref; // <<<< StateMachine
            _audioManager = stateMachine_Ref._audioManager; // <<<< AudioManager

            aauis = new AllAudioUsedInScene();
            musparts = new Dictionary<string, AudioClip>();
            aauis.musicAudioPackage.mus_dictionary.Add("CaveTrollMusic", musparts);

            _stateMachine.tuva = GameObject.Find("Tuva");
            _audioManager.AllAudioSources.Add("tuvaFootStep", stateMachine_Ref.tuva.transform.GetChild(2).GetComponent<AudioSource>());
            _audioManager.AllAudioSources.Add("tuvaDIA", stateMachine_Ref.tuva.transform.GetChild(3).GetComponent<AudioSource>());


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

            //Folay:
            aauis.tuvaAudioPackage.foley.Add("caveFootSteps", Resources.LoadAll<AudioClip>("Audio/Actor/Tuva/FootSteps/Cave"));

            //Music
            aauis.musicAudioPackage.mus_dictionary["CaveTrollMusic"].Add("wholeMelody", Resources.Load<AudioClip>("Audio/Music/Troll/Whole/Melody"));
            aauis.musicAudioPackage.mus_dictionary["CaveTrollMusic"].Add("wholeBass", Resources.Load<AudioClip>("Audio/Music/Troll/Whole/Bass"));
            aauis.musicAudioPackage.mus_dictionary["CaveTrollMusic"].Add("wholePercussion", Resources.Load<AudioClip>("Audio/Music/Troll/Whole/Percussion"));
            aauis.musicAudioPackage.musicTracks.Add("Trollin", Resources.Load<AudioClip>("Audio/Music/Troll/Trollin"));


            //atm
            aauis.atm = Resources.Load<AudioClip>("Audio/BackgroundTracks/Audio_ForestBackground");
            _audioManager.AllAudioSources["atm"].clip = aauis.atm;



            if (debugLog) Debug.Log("SliceState Loaded");
        }
        public void UnloadAssets()
        {
            if (debugLog) Debug.Log("Unloading not needed Assets");
           
            if (debugLog) Debug.Log("Assets unloaded.");

        }


        public void CheckDebugLogBool(StateMachine o)
        {
            if (o.DebugLog) debugLog = true;
        }
    }
}

