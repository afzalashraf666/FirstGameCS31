using System;
using System.IO;
using GameFramework;
using System.Windows.Forms;

namespace FirstGameCS31
{
    public partial class GameWindow : Form
    {
        Game game = Game.getInstance();
        GameFactory gameFactory = GameFactory.GetOneGameFactory();
        MoveKeyBoard keyBoardControl = new MoveKeyBoard();
        public GameWindow()
        {
            InitializeComponent();
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            //Getting Keyboard Movement from factory
            GameObject newobj = gameFactory.CreateGameObject(player, 4, Movement.Keyboard, ObjectsType.player);

            //Getting Right Movement from factory
            GameObject newobj2 = gameFactory.CreateGameObject(enemy1, 1, Movement.Right, ObjectsType.enemy);

            //Default left movement,if movement not specified
            GameObject newobj3 = gameFactory.CreateGameObject(enemy2, 4, ObjectsType.enemy);
            CollisionDetection CDObject = new CollisionDetection(newobj, newobj3, new DecreaseHealth());

            game.addGameObject(newobj);
            game.addGameObject(newobj2);
            game.addGameObject(newobj3);
            game.addCollision(CDObject);
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            game.Update();
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                keyBoardControl.KeyDown(MMentKeys.Left);
            }

            else if (e.KeyCode == Keys.Right)
            {
                keyBoardControl.KeyDown(MMentKeys.Right);
            }
        }

        private void GameWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                keyBoardControl.KeyUp(MMentKeys.Left);
            }

            else if (e.KeyCode == Keys.Right)
            {
                keyBoardControl.KeyUp(MMentKeys.Right);
            }
        }
    }
}