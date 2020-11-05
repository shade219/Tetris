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
        float vol_delta = 0.005f;

        private Azul.Texture pFont;
        private Azul.Texture pText;
        private Azul.Sprite pRedBird;
        private IrrKlang.ISoundEngine AudioEngine = null;
        private IrrKlang.ISound music = null;
        private IrrKlang.ISoundSource srcShoot = null;
        private IrrKlang.ISound sndShoot = null;
        private int startLevel = 0;
        private int duration = 1;
        private BlockGrid grid;


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

            state = new GameState();
            levelManager = new LevelManager(startLevel);
            scoreManager = new ScoreManager();
            lineCycleTimer = new Timer(duration);
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

            grid = BlockGrid.BasicBlockGridInitialize();
        }

        // Author: Your Name Here
        public override void UnLoadContent()
        {
            throw new NotImplementedException();
        }

        // Author: Stahl Samuel, Yuetao Zhu
        public override void Update()
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

            /*
            BlockGrid grid = state.getGrid();               // apis needed from team-7
            GameShape activeShape = state.getActiveShape(); // apis needed from team-7

            // Things we need to check on every update:
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
            */
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
