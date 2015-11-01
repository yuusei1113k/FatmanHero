using UnityEngine;
using System.Collections;
using System;

namespace GameSystems{

   enum GameState{
        Playing,
        NotPlaying,
        Pausing,
        StageClear,
        GameOver
    };

    enum StageName
    {
        Stage1,
        Stage2,
        Stage3
    };


    class State
    {
        private static GameState NowState;

        public GameState getState()
        {
            return NowState;
        }

        public void setState(GameState e)
        {
            NowState = e;
        }

    }

    class ScenChanger
    {
        private static StageName currentStage;

        public StageName getStageName()
        {
            return currentStage;
        }

        public void setStage(StageName e)
        {
            currentStage = e;
        }

        public void toResult()
        {
            Application.LoadLevel("Result");
        }
    };
};