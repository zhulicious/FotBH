using Assets.Code.Interfaces; //This state is for the verticle slice.
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.States
{
    public class ForestSliceState : IStateBase
    {
        private StateMachine _stateMachine;
        private AudioManager _audioManager;
        private AudioKing audioKing;
        private AllAudioUsedInScene aauis;
        private Dictionary<string, AudioClip> forestCreatureTrack;
        private Dictionary<string, AudioClip> deathTrack;

        private bool debugLog;




        public ForestSliceState(StateMachine stateMachine_Ref)
        {
            CheckDebugLogBool(stateMachine_Ref);

            if (debugLog) Debug.Log("Constructing SliceState");

          
            _stateMachine = stateMachine_Ref;
            _audioManager = stateMachine_Ref._audioManager;
            aauis = _audioManager.AAUIS;
            forestCreatureTrack = new Dictionary<string, AudioClip>();
            deathTrack = new Dictionary<string, AudioClip>();
            _stateMachine.tuva = GameObject.Find("Tuva");

            UnloadAssets();
            LoadAssets();

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

            //Tuva
            aauis.tuvaAudioPackage.foley.Add("puddleFootsteps", Resources.LoadAll<AudioClip>("Audio/Actor/Tuva/FootSteps/Puddles"));
            aauis.tuvaAudioPackage.foley.Add("grassFootsteps", Resources.LoadAll<AudioClip>("Audio/Actor/Tuva/FootSteps/Grass"));

            //LyktGubben
            aauis.lgAudioPackage.foley.Add("grassFootsteps", Resources.LoadAll<AudioClip>("Audio/Actor/Tuva/FootSteps/Grass"));

            //ATM
            

            //Music
            forestCreatureTrack.Add("wholeBass", Resources.Load<AudioClip>("Audio/Music/TreeCreature/Bass"));
            forestCreatureTrack.Add("wholeHigh", Resources.Load<AudioClip>("Audio/Music/TreeCreature/High"));
            forestCreatureTrack.Add("wholePercussion", Resources.Load<AudioClip>("Audio/Music/TreeCreature/Percussion"));

            deathTrack.Add("wholeChoir", Resources.Load<AudioClip>("Audio/Music/Death/ChoirWhole"));
            deathTrack.Add("wholeBass", Resources.Load<AudioClip>("Audio/Music/Death/BassWhole"));
            deathTrack.Add("wholeRhytm", Resources.Load<AudioClip>("Audio/Music/Death/RhytmWhole"));
            deathTrack.Add("wholePercussion", Resources.Load<AudioClip>("Audio/Music/Death/PercussionWhole"));
            


            aauis.musicAudioPackage.mus_dictionary.Add("ForestCreature", forestCreatureTrack);
            aauis.musicAudioPackage.mus_dictionary.Add("Death", deathTrack);




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

