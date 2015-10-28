using UnityEngine;
using System.Collections;
using System;

namespace StageState{

   enum GameState{
        Playing,
        NotPlaying,
        Pausing,
        StageClear,
        GameOver
        
    };

    class State
    {
        private Enum NowState;

        public State(GameState e)
        {
            NowState = e;
        }

        public void setState(GameState e)
        {
            NowState = e;
        }

    }


};