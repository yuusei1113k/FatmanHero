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
        private static StageName stageName;

        public StageName getStageName()
        {
            return stageName;
        }

        public void setStage(StageName e)
        {
            stageName = e;
        }
    };
};