using System;
using System.Collections.Generic;
using Tetris.domain;
using Tetris.domain.shapes;
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
        Timer inputTimer;
        Timer frameSleepTimer;
        InputReader inputReader;
        float vol_delta = 0.010f;

        private Azul.Texture pFont;
        private Azul.Texture pText;
        private Azul.Sprite pRedBird;
        private IrrKlang.ISoundEngine AudioEngine = null;
        private IrrKlang.ISound music = null;
        private IrrKlang.ISoundSource srcShoot = null;
        private IrrKlang.ISound sndShoot = null;
        private int startLevel = 1;
        private int frameSleepTimerDuration = 16;
        private int duration = 0;
        private int instantDropDuration = 25;
        private int inputTimerDuration = 0;
        private bool isPaused = false;


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

        // Author: Stahl Samuel, Yuetao Zhu, Brandon Wegner
        // Create game classes instances and draw initial game window 
        public override void Initialize()
        {
            this.SetWindowName("Tetris Framework");
            this.SetWidthHeight(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            this.SetClearColor(0.4f, 0.4f, 0.8f, 1.0f);
            duration = frameSleepTimerDuration * 54;
            inputTimerDuration = frameSleepTimerDuration * 18;
            state = new GameState();
            levelManager = new LevelManager(startLevel);
            scoreManager = new ScoreManager();
            lineCycleTimer = new Timer(duration);
            lineCycleTimer.ResetTimer();
            inputTimer = new Timer(inputTimerDuration);
            inputTimer.ResetTimer();
            frameSleepTimer = new Timer(frameSleepTimerDuration);
            frameSleepTimer.ResetTimer();
            inputReader = new InputReader();

            //INITIALIZE TEST STARTING GRID
            //Can be used for to speed up - and create testing scenarios
           // InitTestingBlockGrid_DoubleLineScenario(state.getGrid());
        }

        public void InitTestingBlockGrid_DoubleLineScenario(BlockGrid grid)
        {
            if (grid.GetGridRowCount() == 30 && grid.GetGridColumnCount() == 10)
            {
                GameShape shape1 = new SquareShape(new Block(0, 1));
                grid.PlaceShape(shape1);

                GameShape shape2 = new SquareShape(new Block(2, 1));
                grid.PlaceShape(shape2);

                GameShape shape3 = new SquareShape(new Block(4, 1));
                grid.PlaceShape(shape3);

                GameShape shape4 = new SquareShape(new Block(6, 1));
                grid.PlaceShape(shape4);

                //NOTE:: Line only removed on is.Placed update (when a block is placed -- checks if lines need to be removed)
                //GameShape shape5 = new SquareShape(new Block(8, 1));
                //grid.PlaceShape(shape5);
            }


        }

    // Author: Brandon Wegner
        public override void LoadContent()
        {
            AudioEngine = new IrrKlang.ISoundEngine();

            music = AudioEngine.Play2D("theme.wav", true);
            music.Volume = 0.2f;

            srcShoot = AudioEngine.AddSoundSourceFromFile("shoot.wav");
            sndShoot = AudioEngine.Play2D(srcShoot, false, false, false);
            sndShoot.Stop();

            pFont = new Azul.Texture("consolas20pt.tga");

            GlyphMan.AddXml("Consolas20pt.xml", pFont);

            pText = new Azul.Texture("unsorted.tga");

            pRedBird = new Azul.Sprite(pText, new Azul.Rect(903.0f, 797.0f, 46.0f, 46.0f),
                new Azul.Rect(300.0f, 100.0f, 30.0f, 30.0f));
        }

        // Author: Your Name Here
        public override void UnLoadContent()
        {
            //Please have game major review
            //Unsure what to upload
            //throw new NotImplementedException();

        }

        // Author: Stahl Samuel, Yuetao Zhu
        public override void Update()
        {
            if (frameSleepTimer.IsExpired())
            {
                AudioEngine.Update();
                if (music.Volume > 0.30f)
                {
                    vol_delta = -0.002f;
                }
                else if (music.Volume < 0.00f)
                {
                    vol_delta = 0.002f;
                }
                music.Volume += vol_delta;

                // Intentionally disabling sounds for now
                music.Volume = 0.000f;

                inputReader.GetInputs();
                if (!isPaused)
                {

                    BlockGrid grid = state.getGrid();
                    GameShape activeShape = state.getActiveShape();

                    // Things we need to check on every update:
                    // 1. activeShape is placed => trigger GameState.activateNext() and set active shape to new active shape
                    // 2. if timer is expired => reset timer and MovementManager.ApplyAction(InputAction.MoveDown,grid,shape);
                    // 3. if timer is not expired => processInput();

                    if (activeShape.isPlaced)
                    {
                        state.activateNext();
                        activeShape = state.getActiveShape();

                        // Tell BlockGrid whether new lines cleared
                        List<int> cl = grid.GetCompletedLines();
                        grid.RemoveLines(cl);
                        state.totalLinesCleared += cl.Count;
                        state.currentLevel = levelManager.UpdateLevel(state.totalLinesCleared);
                        state.currentScore = scoreManager.UpdateScore(cl.Count, state.currentLevel);
                        lineCycleTimer.ResetTimer();
                    }
                    if (lineCycleTimer.IsExpired())
                    {
                        MovementManager.ApplyAction(InputAction.MoveDown, grid, activeShape);
                        lineCycleTimer.ResetTimer();
                    }
                    else
                    {
                        if (inputTimer.IsExpired())
                        {
                            processInput(grid, activeShape);
                            inputTimer.ResetTimer();
                        }
                    }
                }
                else
                {
                    if (inputTimer.IsExpired())
                    {
                        // Paused
                        processInput(null, null);
                        inputTimer.ResetTimer();
                    }
                }
                frameSleepTimer.ResetTimer();
            }
        }

        private void togglePause()
        {
            if (isPaused)
            {
                isPaused = false;
            }
            else
            {
                isPaused = true;
            }
        }
        private void processInput(BlockGrid grid, GameShape activeShape)
        {
            InputAction curInput = inputReader.GetLastAction();

            switch (curInput)
            {
                case InputAction.Pause:
                    togglePause();
                    break;
                case InputAction.Null:
                    break;
                default:
                    if(!isPaused)
                        MovementManager.ApplyAction(curInput, grid, activeShape);
                    break;

            }
        }
    }
}
