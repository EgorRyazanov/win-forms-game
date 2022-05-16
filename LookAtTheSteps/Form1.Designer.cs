using System.Drawing;
using System.Windows.Forms;

namespace LookAtTheSteps
{
    partial class Form1
    {
       
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        
        private void InitializeComponent()
        {
            Instruction = new System.Windows.Forms.Label();
            ShowMoves = new System.Windows.Forms.Label();
            ZeroLevel = new System.Windows.Forms.Button();
            GameMenu = new System.Windows.Forms.Button();
            FirstLevel = new System.Windows.Forms.Button();
            ExitButtom = new System.Windows.Forms.Button();
            Inventory = new System.Windows.Forms.Label();
            Health = new System.Windows.Forms.Label();
            Win = new System.Windows.Forms.Label();
            NextLevel = new System.Windows.Forms.Button();
            Lose = new System.Windows.Forms.Label();
            PlayButtom = new System.Windows.Forms.Button();
            Back = new System.Windows.Forms.Button();
            SecondLevel = new System.Windows.Forms.Button();
            StepsText = new System.Windows.Forms.Label();
            HealthText = new System.Windows.Forms.Label();
            RestartButtom = new System.Windows.Forms.Button();
            ShowInstruction = new System.Windows.Forms.Button();
            CloseInstructin = new System.Windows.Forms.Button();
            SuspendLayout();


            Instruction.Text = "Смысл игры:" + "\n" +
                               "Вам нужно добраться до финиша за отведенное количество шагов. Игра нацелена на развитие логического мышления." +
                               "\n " + "\n" + 
                               "Инструкция:" + "\n" +
                               "Карта построена по аналогии с шахматной доской, где вы можете двигаться только по горизонтали и вертикали." +
                               "\n" +
                               "Для того, чтобы сделать ход, нужно нажать на квадратик в возможной зоне движения игрока - он подсветится красным," + "\n" + 
                               "нажмите еще раз на ту же область для подтверждения своего решения. Чтобы сбросить неверно выбранную клетку, нужно кликнуть в любую другую зону" +
                               "\n" +
                               "Для усложнения процесса на уровнях есть различные препятствия: лава и пушки, гарантированно наносящие персонажу урон." +
                               "\n" +
                               "Также присутствует объект, который можно забрать в инвентарь - камень, с его помощью вы можете закрывать лаву, тем самым превращая ее в проходимый квадратик." +
                               "\n" +
                               "Чтобы взять камень в инвентарь нужно сблизиться с ним до дистанции не более 1 клетки, далее нажать на него и подтвердить решение повторным кликом в ту же область." +
                               "\n" +
                               "Чтобы поставить камень, нужно нажать на клеточку в инвентаре и кликнуть в зону рядом с собой, также не более 1 клетки." + "\n" + 
                               "Ставить камень можно только в пустую клетку и в лаву." + 
                               "\n" +
                               "Нужно дойти за зеленого квадрата, при этом следя за количеством здоровья и шагов." + "\n" + "\n"+
                               "Удачи, у Вас все получится!";
            Instruction.BackColor = System.Drawing.Color.Transparent;
            Instruction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Instruction.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            Instruction.Location = new System.Drawing.Point(170, 50);
            Instruction.Name = "Instruction";
            Instruction.Size = new System.Drawing.Size(1700, 900);
            Instruction.TabIndex = 0;
            Instruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            
            ShowMoves.BackColor = System.Drawing.Color.Transparent;
            ShowMoves.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ShowMoves.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            ShowMoves.Location = new System.Drawing.Point(1155, 60);
            ShowMoves.Name = "ShowMoves";
            ShowMoves.Size = new System.Drawing.Size(70, 70);
            ShowMoves.TabIndex = 0;
            ShowMoves.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            
            ZeroLevel.FlatAppearance.BorderSize = 0;
            ZeroLevel.FlatStyle = FlatStyle.Flat;
            ZeroLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            ZeroLevel.BackColor = System.Drawing.Color.Transparent;
            ZeroLevel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            ZeroLevel.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 + 75, 
                Screen.PrimaryScreen.Bounds.Height / 2 - 200);
            ZeroLevel.Name = "ZeroLevel";
            ZeroLevel.Size = new System.Drawing.Size(350, 75);
            ZeroLevel.TabIndex = 1;
            ZeroLevel.Text = "Обучающий уровень";
            ZeroLevel.UseVisualStyleBackColor = false;
            ZeroLevel.Click += new System.EventHandler(this.LoadZeroLevel);
            
            
            GameMenu.FlatAppearance.BorderSize = 0;
            GameMenu.FlatStyle = FlatStyle.Flat;
            GameMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            GameMenu.BackColor = System.Drawing.Color.Transparent;
            GameMenu.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            GameMenu.Location = new System.Drawing.Point(20, 10);
            GameMenu.Name = "Menu";
            GameMenu.Size = new System.Drawing.Size(140, 60);
            GameMenu.TabIndex = 2;
            GameMenu.Text = "Меню";
            GameMenu.UseVisualStyleBackColor = false;
            GameMenu.Click += new System.EventHandler(this.LoadMenu);
            
            
            FirstLevel.FlatAppearance.BorderSize = 0;
            FirstLevel.FlatStyle = FlatStyle.Flat;
            FirstLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            FirstLevel.BackColor = System.Drawing.Color.Transparent;
            FirstLevel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            FirstLevel.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 + 75, 
                Screen.PrimaryScreen.Bounds.Height / 2 - 50);
            FirstLevel.Name = "FirstLevel";
            FirstLevel.Size = new System.Drawing.Size(350, 75);
            FirstLevel.TabIndex = 3;
            FirstLevel.Text = "1 уровень";
            FirstLevel.UseVisualStyleBackColor = false;
            FirstLevel.Click += new System.EventHandler(this.LoadFirstLevel);
           
            
            ExitButtom.FlatAppearance.BorderSize = 0;
            ExitButtom.FlatStyle = FlatStyle.Flat;
            ExitButtom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            ExitButtom.BackColor = System.Drawing.Color.Transparent;
            ExitButtom.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            ExitButtom.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 + 200, 
                Screen.PrimaryScreen.Bounds.Height / 2 + 175);
            ExitButtom.Name = "ExitButtom";
            ExitButtom.Size = new System.Drawing.Size(140, 50);
            ExitButtom.TabIndex = 4;
            ExitButtom.Text = "Выход";
            ExitButtom.UseVisualStyleBackColor = false;
            ExitButtom.Click += new System.EventHandler(this.Exit);
            
            
            Inventory.BackColor = System.Drawing.Color.Transparent;
            Inventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Inventory.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            Inventory.Location = new System.Drawing.Point(955, 910);
            Inventory.Name = "Inventory";
            Inventory.Size = new System.Drawing.Size(140, 50);
            Inventory.TabIndex = 5;
            Inventory.Text = "Инвентарь";
            Inventory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            
            Health.BackColor = System.Drawing.Color.Transparent;
            Health.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Health.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            Health.Location = new System.Drawing.Point(825, 60);
            Health.Name = "Health";
            Health.Size = new System.Drawing.Size(70, 70);
            Health.TabIndex = 6;
            Health.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            
            Win.FlatStyle = FlatStyle.Flat;
            Win.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Win.BackColor = System.Drawing.Color.Transparent;
            Win.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold);
            Win.Location = new System.Drawing.Point(100, 100);
            Win.Name = "Win";
            Win.Size = new System.Drawing.Size(2000, 900);
            Win.TabIndex = 7;
            Win.Text = "Поздравляю, вы прошли уровень!";
            
            
            NextLevel.FlatAppearance.BorderSize = 0;
            NextLevel.FlatStyle = FlatStyle.Flat;
            NextLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            NextLevel.BackColor = System.Drawing.Color.Transparent;
            NextLevel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline);
            NextLevel.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 + 100, 
                Screen.PrimaryScreen.Bounds.Height / 2 + 175);
            NextLevel.Name = "NextLevel";
            NextLevel.Size = new System.Drawing.Size(400, 75);
            NextLevel.TabIndex = 8;
            NextLevel.Text = "Перейти на следующий";
            NextLevel.UseVisualStyleBackColor = true;
            NextLevel.Click += new System.EventHandler(this.LoadNextLevel);
            
            
            Lose.FlatStyle = FlatStyle.Flat;
            Lose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Lose.BackColor = System.Drawing.Color.Transparent;
            Lose.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold);
            Lose.Location = new System.Drawing.Point(100, 100);
            Lose.Name = "Lose";
            Lose.Size = new System.Drawing.Size(2000, 900);
            Lose.TabIndex = 9;
            Lose.Text = "Вы проиграли, попробуйте еще раз";
            
            
            PlayButtom.FlatAppearance.BorderSize = 0;
            PlayButtom.FlatStyle = FlatStyle.Flat;
            PlayButtom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            PlayButtom.BackColor = System.Drawing.Color.Transparent;
            PlayButtom.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            PlayButtom.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 + 200, 
                Screen.PrimaryScreen.Bounds.Height / 2);
            PlayButtom.Name = "PlayButtom";
            PlayButtom.Size = new System.Drawing.Size(150, 50);
            PlayButtom.TabIndex = 10;
            PlayButtom.Text = "Играть!";
            PlayButtom.UseVisualStyleBackColor = false;
            PlayButtom.Click += new System.EventHandler(this.ShowLevels);
            
            
            Back.FlatAppearance.BorderSize = 0;
            Back.FlatStyle = FlatStyle.Flat;
            Back.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Back.BackColor = System.Drawing.Color.Transparent;
            Back.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            Back.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 + 75, 
                Screen.PrimaryScreen.Bounds.Height / 2 + 250);
            Back.Name = "Back";
            Back.Size = new System.Drawing.Size(350, 75);
            Back.TabIndex = 11;
            Back.Text = "Назад";
            Back.UseVisualStyleBackColor = false;
            Back.Click += new System.EventHandler(this.GoBack);
            
            
            SecondLevel.FlatAppearance.BorderSize = 0;
            SecondLevel.FlatStyle = FlatStyle.Flat;
            SecondLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            SecondLevel.BackColor = System.Drawing.Color.Transparent;
            SecondLevel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            SecondLevel.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width / 2 + 75, 
                Screen.PrimaryScreen.Bounds.Height / 2 + 100);
            SecondLevel.Name = "SecondLevel";
            SecondLevel.Size = new System.Drawing.Size(350, 75);
            SecondLevel.TabIndex = 12;
            SecondLevel.Text = "2 уровень";
            SecondLevel.UseVisualStyleBackColor = false;
            SecondLevel.Click += new System.EventHandler(this.LoadSecondLevel);
            
            
            StepsText.BackColor = System.Drawing.Color.Transparent;
            StepsText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            StepsText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            StepsText.Location = new System.Drawing.Point(1125, 30);
            StepsText.Name = "StepsText";
            StepsText.Size = new System.Drawing.Size(125, 50);
            StepsText.TabIndex = 13;
            StepsText.Text = "Шаги:";
            StepsText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            
            HealthText.BackColor = System.Drawing.Color.Transparent;
            HealthText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            HealthText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            HealthText.Location = new System.Drawing.Point(800, 30);
            HealthText.Name = "HealthText";
            HealthText.Size = new System.Drawing.Size(125, 50);
            HealthText.TabIndex = 14;
            HealthText.Text = "Здоровье:";
            HealthText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            
            ShowInstruction.FlatAppearance.BorderSize = 0;
            ShowInstruction.FlatStyle = FlatStyle.Flat;
            ShowInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            ShowInstruction.BackColor = System.Drawing.Color.Transparent;
            ShowInstruction.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            ShowInstruction.Location = new System.Drawing.Point(5, 130);
            ShowInstruction.Name = "ShowInstruction";
            ShowInstruction.Size = new System.Drawing.Size(180, 80);
            ShowInstruction.TabIndex = 15;
            ShowInstruction.Text = "Показать" + "\n" + "Инструкцию";
            ShowInstruction.UseVisualStyleBackColor = false;
            ShowInstruction.Click += new System.EventHandler(this.ShowInstructionLabel);
            
            
            CloseInstructin.FlatAppearance.BorderSize = 0;
            CloseInstructin.FlatStyle = FlatStyle.Flat;
            CloseInstructin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            CloseInstructin.BackColor = System.Drawing.Color.Transparent;
            CloseInstructin.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            CloseInstructin.Location = new System.Drawing.Point(5, 130);
            CloseInstructin.Name = "CloseInstructionLabel";
            CloseInstructin.Size = new System.Drawing.Size(180, 80);
            CloseInstructin.TabIndex = 15;
            CloseInstructin.Text = "Скрыть" + "\n" + "Инструкцию";
            CloseInstructin.UseVisualStyleBackColor = false;
            CloseInstructin.Click += new System.EventHandler(this.CloseInstructionLabel);
            
            
            RestartButtom.FlatAppearance.BorderSize = 0;
            RestartButtom.FlatStyle = FlatStyle.Flat;
            RestartButtom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            RestartButtom.BackColor = System.Drawing.Color.Transparent;
            RestartButtom.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            RestartButtom.Location = new System.Drawing.Point(5, 70);
            RestartButtom.Name = "Restart";
            RestartButtom.Size = new System.Drawing.Size(180, 60);
            RestartButtom.TabIndex = 15;
            RestartButtom.Text = "Перезапуск";
            RestartButtom.UseVisualStyleBackColor = false;
            RestartButtom.Click += new System.EventHandler(this.Restart);
            
            
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(921, 790);
            Controls.Add(CloseInstructin);
            Controls.Add(Instruction);
            Controls.Add(ShowInstruction);
            Controls.Add(RestartButtom);
            Controls.Add(HealthText);
            Controls.Add(StepsText);
            Controls.Add(SecondLevel);
            Controls.Add(Back);
            Controls.Add(PlayButtom);
            Controls.Add(Lose);
            Controls.Add(NextLevel);
            Controls.Add(Win);
            Controls.Add(Health);
            Controls.Add(Inventory);
            Controls.Add(ExitButtom);
            Controls.Add(FirstLevel);
            Controls.Add(GameMenu);
            Controls.Add(ZeroLevel);
            Controls.Add(ShowMoves);
            Name = "Form1";
            Text = "LookAtTheSteps";
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button CloseInstructin;

        private System.Windows.Forms.Button ShowInstruction;
        
        private System.Windows.Forms.Label Instruction;

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

        private System.Windows.Forms.Button GameMenu;

        private System.Windows.Forms.Button ZeroLevel;

        private System.Windows.Forms.Label ShowMoves;

        #endregion
    }
}