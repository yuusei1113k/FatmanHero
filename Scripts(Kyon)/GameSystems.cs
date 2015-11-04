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
        State state = new State();
        //選択ステージ
        private static StageName currentStage;
        //取得用
        public StageName getStageName()
        {
            return currentStage;
        }
        //セット用
        public void setStage(StageName e)
        {
            currentStage = e;
        }

        //タイトル画面へ
        public void toTitle()
        {
            state.setState(GameState.NotPlaying);
            Application.LoadLevel("Title");
        }

        //ステージセレクト画面へ
        public void toStageSelect()
        {
            state.setState(GameState.NotPlaying);
            Application.LoadLevel("StageSelect");
        }

        //LoadSceneへ
        public void toLoading()
        {
            Application.LoadLevel("LoadScene");
        }

        //リザルトへ
        public void toResult()
        {
            Application.LoadLevel("Result");
        }
    };
};