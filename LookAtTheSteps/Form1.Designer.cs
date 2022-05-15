using System.Drawing;
using System.Windows.Forms;

namespace LookAtTheSteps
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // this.Instruction = new System.Windows.Forms.Label();
            this.ShowMoves = new System.Windows.Forms.Label();
            this.ZeroLevel = new System.Windows.Forms.Button();
            this.Menu = new System.Windows.Forms.Button();
            this.FirstLevel = new System.Windows.Forms.Button();
            this.ExitButtom = new System.Windows.Forms.Button();
            this.Inventory = new System.Windows.Forms.Label();
            this.Health = new System.Windows.Forms.Label();
            this.Win = new System.Windows.Forms.Label();
            this.NextLevel = new System.Windows.Forms.Button();
            this.Lose = new System.Windows.Forms.Label();
            this.PlayButtom = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.SecondLevel = new System.Windows.Forms.Button();
            this.StepsText = new System.Windows.Forms.Label();
            this.HealthText = new System.Windows.Forms.Label();
            this.RestartButtom = new System.Windows.Forms.Button();
            this.SuspendLayout();


            // Instruction.Text = "Смысл игры:" + "\n" +
            //                    "Вам нужно добраться до финиша за отведенное количество шагов. Игра нацелена на развитие логического мышления." +
            //                    "\n " + "\n" + 
            //                    "Инструкция:" + "\n" +
            //                    "Карта построена по аналогии с шахматной доской, где вы можете двигаться только по горизонтали и вертикали." +
            //                    "\n" +
            //                    "Для того, чтобы сделать ход, нужно нажать на квадратик в возможной зоне движения игрока - он подсветится красным," + "\n" + 
            //                    "нажмите еще раз на ту же область для подтверждения своего решения. Чтобы сбросить неверно выбранную клетку, нужно кликнуть в любую другую зону" +
            //                    "\n" +
            //                    "Для усложнения процесса на уровнях есть различные препятствия: лава и пушки, гарантированно наносящие персонажу урон." +
            //                    "\n" +
            //                    "Также присутствует объект, который можно забрать в инвентарь - камень, с его помощью вы можете закрывать лаву, тем самым превращая ее в проходимый квадратик." +
            //                    "\n" +
            //                    "Чтобы взять камень в инвентарь нужно сблизиться с ним до дистанции не более 1 клетки, далее нажать на него и подтвердить решение повторным кликом в ту же область." +
            //                    "\n" +
            //                    "Чтобы поставить камень, нужно нажать на клеточку в инвентаре и кликнуть в зону рядом с собой, также не более 1 клетки. Ставить камень можно только в пустую клетку и в лаву." +
            //                    "\n" +
            //                    "Нужно всегда следить за количеством здоровья и шагов!" + "\n" +
            //                    "Удачи, у Вас все получится!";
            // this.Instruction.BackColor = System.Drawing.Color.Transparent;
            // this.Instruction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            // this.Instruction.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            // this.Instruction.Location = new System.Drawing.Point(50, 50);
            // this.Instruction.Name = "ShowMoves";
            // this.Instruction.Size = new System.Drawing.Size(2000, 900);
            // this.Instruction.TabIndex = 0;
            // this.Instruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShowMoves
            // 
            this.ShowMoves.BackColor = System.Drawing.Color.Transparent;
            this.ShowMoves.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowMoves.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.ShowMoves.Location = new System.Drawing.Point(1155, 60);
            this.ShowMoves.Name = "ShowMoves";
            this.ShowMoves.Size = new System.Drawing.Size(70, 70);
            this.ShowMoves.TabIndex = 0;
            this.ShowMoves.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ZeroLevel
            // 
            ZeroLevel.FlatAppearance.BorderSize = 0;
            ZeroLevel.FlatStyle = FlatStyle.Flat;
            ZeroLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            ZeroLevel.BackColor = System.Drawing.Color.Transparent;
            this.ZeroLevel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.ZeroLevel.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 + 75, 
                Screen.PrimaryScreen.Bounds.Height / 2 - 300);
            this.ZeroLevel.Name = "ZeroLevel";
            this.ZeroLevel.Size = new System.Drawing.Size(350, 75);
            this.ZeroLevel.TabIndex = 1;
            this.ZeroLevel.Text = "Обучающий уровень";
            this.ZeroLevel.UseVisualStyleBackColor = false;
            this.ZeroLevel.Click += new System.EventHandler(this.LoadZeroLevel);
            // 
            // Menu
            // 
            Menu.FlatAppearance.BorderSize = 0;
            Menu.FlatStyle = FlatStyle.Flat;
            Menu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Menu.BackColor = System.Drawing.Color.Transparent;
            this.Menu.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.Menu.Location = new System.Drawing.Point(20, 10);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(140, 60);
            this.Menu.TabIndex = 2;
            this.Menu.Text = "Меню";
            this.Menu.UseVisualStyleBackColor = false;
            this.Menu.Click += new System.EventHandler(this.LoadMenu);
            // 
            // FirstLevel
            // 
            FirstLevel.FlatAppearance.BorderSize = 0;
            FirstLevel.FlatStyle = FlatStyle.Flat;
            FirstLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            FirstLevel.BackColor = System.Drawing.Color.Transparent;
            this.FirstLevel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.FirstLevel.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 + 75, 
                Screen.PrimaryScreen.Bounds.Height / 2 - 150);
            this.FirstLevel.Name = "FirstLevel";
            this.FirstLevel.Size = new System.Drawing.Size(350, 75);
            this.FirstLevel.TabIndex = 3;
            this.FirstLevel.Text = "Первый уровень";
            this.FirstLevel.UseVisualStyleBackColor = false;
            this.FirstLevel.Click += new System.EventHandler(this.LoadFirstLevel);
            // 
            // ExitButtom
            // 
            ExitButtom.FlatAppearance.BorderSize = 0;
            ExitButtom.FlatStyle = FlatStyle.Flat;
            ExitButtom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            ExitButtom.BackColor = System.Drawing.Color.Transparent;
            this.ExitButtom.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.ExitButtom.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 + 200, 
                Screen.PrimaryScreen.Bounds.Height / 2 + 175);
            this.ExitButtom.Name = "ExitButtom";
            this.ExitButtom.Size = new System.Drawing.Size(140, 50);
            this.ExitButtom.TabIndex = 4;
            this.ExitButtom.Text = "Выход";
            this.ExitButtom.UseVisualStyleBackColor = false;
            this.ExitButtom.Click += new System.EventHandler(this.Exit);
            // 
            // Inventory
            // 
            this.Inventory.BackColor = System.Drawing.Color.Transparent;
            this.Inventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Inventory.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Inventory.Location = new System.Drawing.Point(955, 910);
            this.Inventory.Name = "Inventory";
            this.Inventory.Size = new System.Drawing.Size(140, 50);
            this.Inventory.TabIndex = 5;
            this.Inventory.Text = "Инвентарь";
            this.Inventory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Health
            // 
            this.Health.BackColor = System.Drawing.Color.Transparent;
            this.Health.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Health.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.Health.Location = new System.Drawing.Point(825, 60);
            this.Health.Name = "Health";
            this.Health.Size = new System.Drawing.Size(70, 70);
            this.Health.TabIndex = 6;
            this.Health.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Win
            // 
            Win.FlatStyle = FlatStyle.Flat;
            Win.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Win.BackColor = System.Drawing.Color.Transparent;
            this.Win.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold);
            this.Win.Location = new System.Drawing.Point(100, 100);
            this.Win.Name = "Win";
            this.Win.Size = new System.Drawing.Size(2000, 900);
            this.Win.TabIndex = 7;
            this.Win.Text = "Поздравляю, вы прошли уровень!";
            // 
            // NextLevel
            // 
            NextLevel.FlatAppearance.BorderSize = 0;
            NextLevel.FlatStyle = FlatStyle.Flat;
            NextLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            NextLevel.BackColor = System.Drawing.Color.Transparent;
            this.NextLevel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline);
            this.NextLevel.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 + 100, 
                Screen.PrimaryScreen.Bounds.Height / 2 + 175);
            this.NextLevel.Name = "NextLevel";
            this.NextLevel.Size = new System.Drawing.Size(400, 75);
            this.NextLevel.TabIndex = 8;
            this.NextLevel.Text = "Перейти на следующий";
            this.NextLevel.UseVisualStyleBackColor = true;
            this.NextLevel.Click += new System.EventHandler(this.LoadNextLevel);
            // 
            // Lose
            // 
            Lose.FlatStyle = FlatStyle.Flat;
            Lose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Lose.BackColor = System.Drawing.Color.Transparent;
            this.Lose.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold);
            this.Lose.Location = new System.Drawing.Point(100, 100);
            this.Lose.Name = "Lose";
            this.Lose.Size = new System.Drawing.Size(2000, 900);
            this.Lose.TabIndex = 9;
            this.Lose.Text = "Вы проиграли, попробуйте еще раз";
            // 
            // PlayButtom
            // 
            PlayButtom.FlatAppearance.BorderSize = 0;
            PlayButtom.FlatStyle = FlatStyle.Flat;
            PlayButtom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            PlayButtom.BackColor = System.Drawing.Color.Transparent;
            this.PlayButtom.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.PlayButtom.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 + 200, 
                Screen.PrimaryScreen.Bounds.Height / 2);
            this.PlayButtom.Name = "PlayButtom";
            this.PlayButtom.Size = new System.Drawing.Size(150, 50);
            this.PlayButtom.TabIndex = 10;
            this.PlayButtom.Text = "Играть!";
            this.PlayButtom.UseVisualStyleBackColor = false;
            this.PlayButtom.Click += new System.EventHandler(this.ShowLevels);
            // 
            // Back
            // 
            Back.FlatAppearance.BorderSize = 0;
            Back.FlatStyle = FlatStyle.Flat;
            Back.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Back.BackColor = System.Drawing.Color.Transparent;
            this.Back.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.Back.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 + 75, 
                Screen.PrimaryScreen.Bounds.Height / 2 + 150);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(350, 75);
            this.Back.TabIndex = 11;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.GoBack);
            // 
            // SecondLevel
            // 
            SecondLevel.FlatAppearance.BorderSize = 0;
            SecondLevel.FlatStyle = FlatStyle.Flat;
            SecondLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            SecondLevel.BackColor = System.Drawing.Color.Transparent;
            this.SecondLevel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.SecondLevel.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 + 75, 
                Screen.PrimaryScreen.Bounds.Height / 2);
            this.SecondLevel.Name = "SecondLevel";
            this.SecondLevel.Size = new System.Drawing.Size(350, 75);
            this.SecondLevel.TabIndex = 12;
            this.SecondLevel.Text = "Второй уровень";
            this.SecondLevel.UseVisualStyleBackColor = false;
            this.SecondLevel.Click += new System.EventHandler(this.LoadSecondLevel);
            // 
            // StepsText
            // 
            this.StepsText.BackColor = System.Drawing.Color.Transparent;
            this.StepsText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StepsText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.StepsText.Location = new System.Drawing.Point(1125, 30);
            this.StepsText.Name = "StepsText";
            this.StepsText.Size = new System.Drawing.Size(125, 50);
            this.StepsText.TabIndex = 13;
            this.StepsText.Text = "Шаги:";
            this.StepsText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HealthText
            // 
            this.HealthText.BackColor = System.Drawing.Color.Transparent;
            this.HealthText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HealthText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.HealthText.Location = new System.Drawing.Point(800, 30);
            this.HealthText.Name = "HealthText";
            this.HealthText.Size = new System.Drawing.Size(125, 50);
            this.HealthText.TabIndex = 14;
            this.HealthText.Text = "Здоровье:";
            this.HealthText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            RestartButtom.FlatAppearance.BorderSize = 0;
            RestartButtom.FlatStyle = FlatStyle.Flat;
            this.RestartButtom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RestartButtom.BackColor = System.Drawing.Color.Transparent;
            this.RestartButtom.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.RestartButtom.Location = new System.Drawing.Point(5, 70);
            this.RestartButtom.Name = "Restart";
            this.RestartButtom.Size = new System.Drawing.Size(180, 60);
            this.RestartButtom.TabIndex = 15;
            this.RestartButtom.Text = "Перезапуск";
            this.RestartButtom.UseVisualStyleBackColor = false;
            this.RestartButtom.Click += new System.EventHandler(this.Restart);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 790);
            // Controls.Add(Instruction);
            this.Controls.Add(this.RestartButtom);
            this.Controls.Add(this.HealthText);
            this.Controls.Add(this.StepsText);
            this.Controls.Add(this.SecondLevel);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.PlayButtom);
            this.Controls.Add(this.Lose);
            this.Controls.Add(this.NextLevel);
            this.Controls.Add(this.Win);
            this.Controls.Add(this.Health);
            this.Controls.Add(this.Inventory);
            this.Controls.Add(this.ExitButtom);
            this.Controls.Add(this.FirstLevel);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.ZeroLevel);
            this.Controls.Add(this.ShowMoves);
            this.Name = "Form1";
            this.Text = "LookAtTheSteps";
            this.ResumeLayout(false);
        }
        
        // private System.Windows.Forms.Label Instruction;

        private System.Windows.Forms.Label StepsText;
        
        private System.Windows.Forms.Label HealthText;

        private System.Windows.Forms.Button RestartButtom;

        private System.Windows.Forms.Button SecondLevel;

        private System.Windows.Forms.Button Back;

        private System.Windows.Forms.Button PlayButtom;

        private System.Windows.Forms.Label Lose;

        private System.Windows.Forms.Button NextLevel;

        private System.Windows.Forms.Label Win;

        private System.Windows.Forms.Label Health;

        private System.Windows.Forms.Label Inventory;

        private System.Windows.Forms.Button ExitButtom;

        private System.Windows.Forms.Button FirstLevel;

        private System.Windows.Forms.Button Menu;

        private System.Windows.Forms.Button ZeroLevel;

        private System.Windows.Forms.Label ShowMoves;

        #endregion
    }
}