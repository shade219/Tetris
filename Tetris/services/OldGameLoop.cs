using System;
using System.Diagnostics;
using Tetris.domain;
using Tetris.services;

namespace Tetris
{
    class OldGameLoop : Azul.Game
    {
        // Data: --------------------------------------------

            // Audio: ---------------------------------------
            IrrKlang.ISoundEngine AudioEngine = null;

            IrrKlang.ISound music = null;
            public float vol_delta = 0.005f;

            IrrKlang.ISoundSource srcShoot = null;
            IrrKlang.ISound sndShoot = null;

            // Font: ----------------------------------------
            Azul.Texture pFont;

            // Demo: ----------------------------------------
            Azul.Texture pText;
            Azul.Sprite pRedBird;
            GameStats stats;
            int statsCount = 0;
            int count = 0;
            Azul.AZUL_KEY prevEnterKey = 0;


        //*************************************************
        //  test code of block grid
        //*************************************************
        private BlockGrid grid;
            //



        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before
        //      starting to run.  This is where it can query for any required services
        //      and load any non-graphic related content.
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("Tetris Framework");
            this.SetWidthHeight(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            this.SetClearColor(0.4f, 0.4f, 0.8f, 1.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {
            //---------------------------------------------------------------------------------------------------------
            // Audio
            //---------------------------------------------------------------------------------------------------------

            // Create the Audio Engine
            AudioEngine = new IrrKlang.ISoundEngine();

            // Play a sound file
            music = AudioEngine.Play2D("theme.wav",true);
            music.Volume = 0.2f;

            // Resident loads
            srcShoot = AudioEngine.AddSoundSourceFromFile("shoot.wav");
            sndShoot = AudioEngine.Play2D(srcShoot, false, false, false);
            sndShoot.Stop();

            //---------------------------------------------------------------------------------------------------------
            // Setup Font
            //---------------------------------------------------------------------------------------------------------

            // Font - texture
            pFont = new Azul.Texture("consolas20pt.tga");
            Debug.Assert(pFont != null);

            GlyphMan.AddXml("Consolas20pt.xml", pFont);

            //---------------------------------------------------------------------------------------------------------
            // Load the Textures
            //---------------------------------------------------------------------------------------------------------

            // Red bird texture
            pText = new Azul.Texture("unsorted.tga");
            Debug.Assert(pText != null);

            //---------------------------------------------------------------------------------------------------------
            // Create Sprites
            //---------------------------------------------------------------------------------------------------------

            pRedBird = new Azul.Sprite(pText, new Azul.Rect(903.0f, 797.0f, 46.0f, 46.0f), new Azul.Rect(300.0f, 100.0f, 30.0f, 30.0f));
            Debug.Assert(pRedBird != null);

            //---------------------------------------------------------------------------------------------------------
            // Demo variables
            //---------------------------------------------------------------------------------------------------------

            stats = new GameStats();

            //*************************************************
            //  test code of block grid
            //*************************************************
            grid = BlockGrid.BasicBlockGridInitialize();

        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        {
            // Snd update - Need to be called once a frame
            AudioEngine.Update();

            //-----------------------------------------------------------
            // Input Test
            //-----------------------------------------------------------

            // InputTest.KeyboardTest();
            // InputTest.MouseTest();

            //-----------------------------------------------------------
            // Sound Experiments
            //-----------------------------------------------------------

            // Adjust music theme volume
            if (music.Volume > 0.30f)
            {
                vol_delta = -0.002f;
            }
            else if (music.Volume < 0.00f)
            {
                vol_delta = 0.002f;
            }
            music.Volume += vol_delta;

            //--------------------------------------------------------
            // Rotate Sprite
            //--------------------------------------------------------

            pRedBird.angle = pRedBird.angle + 0.01f;
            pRedBird.Update();

            //--------------------------------------------------------
            // Keyboard test
            //--------------------------------------------------------

            // Quick hack to have a one off call.
            // you need to release the keyboard between calls
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ENTER) && prevEnterKey == 0)
            {
                prevEnterKey = Azul.AZUL_KEY.KEY_ENTER;
                sndShoot = AudioEngine.Play2D(srcShoot, false, false, false);
            }
            else
            {
                if (!Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ENTER))
                {
                    prevEnterKey = 0;
                }
            }

            //--------------------------------------------------------
            // Stats test
            //--------------------------------------------------------

            stats.setScore(stats.getScore() + 1);
            if (statsCount % 400 == 0)
            {
                stats.setLevelNum(stats.getLevelNum() + 1);
            }
            if (statsCount % 50 == 0)
            {
                stats.setLineCount(stats.getLineCount() + 1);
            }
            statsCount++;
        }


        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            // Draw sprite with texture
            pRedBird.Render();

            // Update background
            SOM.drawBackground();
            SOM.drawStrings(stats);

            // Draw one box, demo at position 1,1
            SOM.drawBox(1, 1, DrawColor.Shade.COLOR_LT_GREEN);

            // Test play field
            SOM.drawBox(Constants.GAME_MIN_X, Constants.GAME_MIN_Y, DrawColor.Shade.COLOR_ORANGE);
            SOM.drawBox(Constants.GAME_MAX_X, Constants.GAME_MIN_Y, DrawColor.Shade.COLOR_YELLOW);
            SOM.drawBox(Constants.GAME_MIN_X, Constants.GAME_MAX_Y, DrawColor.Shade.COLOR_RED);
            SOM.drawBox(Constants.GAME_MAX_X, Constants.GAME_MAX_Y, DrawColor.Shade.COLOR_BLUE);

            // Cycle all the tetris pieces
            if (count < 2 * 10)
            {
                ShapeRenderer.drawLine(Constants.PREVIEW_WINDOW_X, Constants.PREVIEW_WINDOW_Y, ShapeRenderer.Orientation.ORIENT_0);

                ShapeRenderer.drawLine(3, 3, ShapeRenderer.Orientation.ORIENT_0);
                ShapeRenderer.drawL1(5, 8, ShapeRenderer.Orientation.ORIENT_0);
                ShapeRenderer.drawL2(5, 14, ShapeRenderer.Orientation.ORIENT_0);
                ShapeRenderer.drawT(5, 19, ShapeRenderer.Orientation.ORIENT_0);
                ShapeRenderer.drawZ1(5, 23, ShapeRenderer.Orientation.ORIENT_0);
                ShapeRenderer.drawZ2(5, 28, ShapeRenderer.Orientation.ORIENT_0);
                ShapeRenderer.drawSquare(8, 4, ShapeRenderer.Orientation.ORIENT_0);
            }
            else if (count < 2 * 20)
            {
                ShapeRenderer.drawLine(Constants.PREVIEW_WINDOW_X, Constants.PREVIEW_WINDOW_Y, ShapeRenderer.Orientation.ORIENT_1);

                ShapeRenderer.drawLine(3, 3, ShapeRenderer.Orientation.ORIENT_1);
                ShapeRenderer.drawL1(5, 8, ShapeRenderer.Orientation.ORIENT_1);
                ShapeRenderer.drawL2(5, 14, ShapeRenderer.Orientation.ORIENT_1);
                ShapeRenderer.drawT(5, 19, ShapeRenderer.Orientation.ORIENT_1);
                ShapeRenderer.drawZ1(5, 23, ShapeRenderer.Orientation.ORIENT_1);
                ShapeRenderer.drawZ2(5, 28, ShapeRenderer.Orientation.ORIENT_1);
                ShapeRenderer.drawSquare(8, 4, ShapeRenderer.Orientation.ORIENT_1);
            }
            else if (count < 2 * 30)
            {
                ShapeRenderer.drawLine(Constants.PREVIEW_WINDOW_X, Constants.PREVIEW_WINDOW_Y, ShapeRenderer.Orientation.ORIENT_2);

                ShapeRenderer.drawLine(3, 3, ShapeRenderer.Orientation.ORIENT_2);
                ShapeRenderer.drawL1(5, 8, ShapeRenderer.Orientation.ORIENT_2);
                ShapeRenderer.drawL2(5, 14, ShapeRenderer.Orientation.ORIENT_2);
                ShapeRenderer.drawT(5, 19, ShapeRenderer.Orientation.ORIENT_2);
                ShapeRenderer.drawZ1(5, 23, ShapeRenderer.Orientation.ORIENT_2);
                ShapeRenderer.drawZ2(5, 28, ShapeRenderer.Orientation.ORIENT_2);
                ShapeRenderer.drawSquare(8, 4, ShapeRenderer.Orientation.ORIENT_2);
            }
            else
            {
                ShapeRenderer.drawLine(Constants.PREVIEW_WINDOW_X, Constants.PREVIEW_WINDOW_Y, ShapeRenderer.Orientation.ORIENT_3);

                ShapeRenderer.drawLine(3, 3, ShapeRenderer.Orientation.ORIENT_3);
                ShapeRenderer.drawL1(5, 8, ShapeRenderer.Orientation.ORIENT_3);
                ShapeRenderer.drawL2(5, 14, ShapeRenderer.Orientation.ORIENT_3);
                ShapeRenderer.drawT(5, 19, ShapeRenderer.Orientation.ORIENT_3);
                ShapeRenderer.drawZ1(5, 23, ShapeRenderer.Orientation.ORIENT_3);
                ShapeRenderer.drawZ2(5, 28, ShapeRenderer.Orientation.ORIENT_3);
                ShapeRenderer.drawSquare(8, 4, ShapeRenderer.Orientation.ORIENT_3);
            }

            if (count > 2 * 40)
                count = 0;
            else
                count++;



            //*************************************************
            //  test code of block grid
            //*************************************************
            grid.Draw();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {

        }

    }
}
