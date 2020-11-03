using System;
using System.Collections.Generic;
using Tetris.domain;
using Tetris.ui;

namespace Tetris.services
{

    // Authors: Stahl Samuel, Yuetao Zhu
    // Description:
    public class GameManager : Azul.Game
    {
        GameState state;
        LevelManager levelManager;
        ScoreManager scoreManager;
        Timer lineCycleTimer;
        int totalLinesCleared;
        int currentLevel;


        // Author: Your Name Here
        // Not sure about creator
        //public GameManager()    
        //{

        //}

        // Author: Stahl Samuel, Yuetao Zhu
        public override void Draw()
        {
            StateRenderer.Draw(state);
        }

        // Author: Stahl Samuel, Yuetao Zhu
        // Create game classes instances and draw initial game window 
        public override void Initialize()
        {
            int startLevel = 0;
            int duration = 1;

            state = new GameState();
            levelManager = new LevelManager(startLevel);
            scoreManager = new ScoreManager();
            lineCycleTimer = new Timer(duration);
            StateRenderer.Draw(state);
        }

        // Author: Your Name Here
        public override void LoadContent()
        {
            throw new NotImplementedException();
        }

        // Author: Your Name Here
        public override void UnLoadContent()
        {
            throw new NotImplementedException();
        }

        // Author: Stahl Samuel, Yuetao Zhu
        public override void Update()
        { 
            BlockGrid grid = state.getGrid();               // apis needed from team-7
            GameShape activeShape = state.getActiveShape(); // apis needed from team-7

            // Thins we need to check on every update:
            // 1. activeShape is placed => set activeShape to nextShape and nextShape = ShapeGenerator.GenerateShape(currentLevel);;
            // 2. if timer is expired => reset timer and MovementManager.moveDown();
            // 3. if timer is not expired => MovementManager(InputAction.getInputs());
            if (activeShape.isPlaced)
            {
                activeShape = state.getNextShape();
                state.nextShape = ShapeGenerator.GenerateShape(currentLevel);
                MovementManager.ApplyAction(InputAction.MoveDown, grid, activeShape);

                // Tell BlockGrid whether new lines cleared
                List<int> cl = grid.GetCompletedLines();
                grid.RemoveLines(cl);
                state.totalLinesCleared += cl.Count;
                state.currentLevel = levelManager.UpdateLevel(state.totalLinesCleared);
                scoreManager.UpdateScore(cl.Count,state.currentLevel);
            }
            else
            {
                checkTimerAndMoveShape(grid, activeShape);
            }

            
            throw new NotImplementedException();

        }

        private void checkTimerAndMoveShape(BlockGrid grid, GameShape activeShape)
        {
            if (lineCycleTimer.IsExpired())
            {
                MovementManager.ApplyAction(InputAction.MoveDown, grid, activeShape);
                lineCycleTimer.ResetTimer();
            } else
            {
                MovementManager.ApplyAction(InputReader.GetInputs(), grid, activeShape);
            }
        }
    }
}
