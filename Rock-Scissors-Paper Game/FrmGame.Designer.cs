namespace Rock_Scissors_Paper_Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.gbBGameRequirements = new System.Windows.Forms.GroupBox();
            this.cbComputer = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbPlayer2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rbComputer = new System.Windows.Forms.RadioButton();
            this.rbPlayer2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.cbPlayer1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRounds = new System.Windows.Forms.ComboBox();
            this.gbBStartGame = new System.Windows.Forms.GroupBox();
            this.btnPress = new System.Windows.Forms.Button();
            this.btnChoicePlayer2OrComputer = new System.Windows.Forms.Button();
            this.btnChoicePlayer1 = new System.Windows.Forms.Button();
            this.gbBCountWin = new System.Windows.Forms.GroupBox();
            this.lblDrawCounter = new System.Windows.Forms.Label();
            this.lblDraw = new System.Windows.Forms.Label();
            this.lblCountWinlayer2OrComputer = new System.Windows.Forms.Label();
            this.lblCountWinPlayer1 = new System.Windows.Forms.Label();
            this.lblComputerCount = new System.Windows.Forms.Label();
            this.lblPlayer2Count = new System.Windows.Forms.Label();
            this.lblPlayer1Count = new System.Windows.Forms.Label();
            this.picTurn = new System.Windows.Forms.PictureBox();
            this.btnPaperChoice = new System.Windows.Forms.Button();
            this.btnScissorsChoice = new System.Windows.Forms.Button();
            this.btnStoneChoice = new System.Windows.Forms.Button();
            this.picPlayer2OrComputer = new System.Windows.Forms.PictureBox();
            this.lblNameComputerInGame = new System.Windows.Forms.Label();
            this.lblNamePlayer2InGame = new System.Windows.Forms.Label();
            this.picPlayer1 = new System.Windows.Forms.PictureBox();
            this.lblNamePlayer1InGame = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.gbBGameInfo = new System.Windows.Forms.GroupBox();
            this.lblRoundsInGameInfo = new System.Windows.Forms.Label();
            this.lblRounds = new System.Windows.Forms.Label();
            this.lblNamePlayer2OrComputerInGameInfo = new System.Windows.Forms.Label();
            this.lblNamePlayer1InGameInfo = new System.Windows.Forms.Label();
            this.lblComputer = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.picWinner = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblNumberOfRound = new System.Windows.Forms.Label();
            this.picLosser = new System.Windows.Forms.PictureBox();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnFilliinfo = new System.Windows.Forms.Button();
            this.btnRestGame = new System.Windows.Forms.Button();
            this.gbBGameRequirements.SuspendLayout();
            this.gbBStartGame.SuspendLayout();
            this.gbBCountWin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTurn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2OrComputer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.gbBGameInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLosser)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(256, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(525, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stone-Paper-Scissors Game";
            // 
            // gbBGameRequirements
            // 
            this.gbBGameRequirements.Controls.Add(this.cbComputer);
            this.gbBGameRequirements.Controls.Add(this.label7);
            this.gbBGameRequirements.Controls.Add(this.cbPlayer2);
            this.gbBGameRequirements.Controls.Add(this.label6);
            this.gbBGameRequirements.Controls.Add(this.rbComputer);
            this.gbBGameRequirements.Controls.Add(this.rbPlayer2);
            this.gbBGameRequirements.Controls.Add(this.label5);
            this.gbBGameRequirements.Controls.Add(this.cbPlayer1);
            this.gbBGameRequirements.Controls.Add(this.label4);
            this.gbBGameRequirements.Controls.Add(this.label3);
            this.gbBGameRequirements.Controls.Add(this.label2);
            this.gbBGameRequirements.Controls.Add(this.cbRounds);
            this.gbBGameRequirements.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBGameRequirements.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gbBGameRequirements.Location = new System.Drawing.Point(12, 137);
            this.gbBGameRequirements.Name = "gbBGameRequirements";
            this.gbBGameRequirements.Size = new System.Drawing.Size(236, 457);
            this.gbBGameRequirements.TabIndex = 2;
            this.gbBGameRequirements.TabStop = false;
            this.gbBGameRequirements.Text = "Game Requirements";
            this.gbBGameRequirements.Enter += new System.EventHandler(this.gbBGameInfo_Enter);
            // 
            // cbComputer
            // 
            this.cbComputer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbComputer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComputer.Enabled = false;
            this.cbComputer.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbComputer.ForeColor = System.Drawing.Color.Black;
            this.cbComputer.FormattingEnabled = true;
            this.cbComputer.Items.AddRange(new object[] {
            "Alpha",
            "Alexa",
            "Siri",
            "Cortana",
            "Computer"});
            this.cbComputer.Location = new System.Drawing.Point(24, 405);
            this.cbComputer.Name = "cbComputer";
            this.cbComputer.Size = new System.Drawing.Size(191, 26);
            this.cbComputer.TabIndex = 12;
            this.cbComputer.SelectedIndexChanged += new System.EventHandler(this.cbComputer_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(36, 383);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 19);
            this.label7.TabIndex = 11;
            this.label7.Text = "-Computer :";
            // 
            // cbPlayer2
            // 
            this.cbPlayer2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbPlayer2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlayer2.Enabled = false;
            this.cbPlayer2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPlayer2.ForeColor = System.Drawing.Color.Black;
            this.cbPlayer2.FormattingEnabled = true;
            this.cbPlayer2.Items.AddRange(new object[] {
            "Marwan",
            "Abdullah",
            "Mohamed",
            "Ahmed"});
            this.cbPlayer2.Location = new System.Drawing.Point(24, 331);
            this.cbPlayer2.Name = "cbPlayer2";
            this.cbPlayer2.Size = new System.Drawing.Size(191, 26);
            this.cbPlayer2.TabIndex = 10;
            this.cbPlayer2.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(36, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "-Player2 :";
            // 
            // rbComputer
            // 
            this.rbComputer.AutoSize = true;
            this.rbComputer.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbComputer.ForeColor = System.Drawing.Color.Black;
            this.rbComputer.Location = new System.Drawing.Point(120, 258);
            this.rbComputer.Name = "rbComputer";
            this.rbComputer.Size = new System.Drawing.Size(110, 23);
            this.rbComputer.TabIndex = 8;
            this.rbComputer.TabStop = true;
            this.rbComputer.Text = "Computer";
            this.rbComputer.UseVisualStyleBackColor = true;
            this.rbComputer.CheckedChanged += new System.EventHandler(this.rbComputer_CheckedChanged);
            // 
            // rbPlayer2
            // 
            this.rbPlayer2.AutoSize = true;
            this.rbPlayer2.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPlayer2.ForeColor = System.Drawing.Color.Black;
            this.rbPlayer2.Location = new System.Drawing.Point(24, 258);
            this.rbPlayer2.Name = "rbPlayer2";
            this.rbPlayer2.Size = new System.Drawing.Size(90, 23);
            this.rbPlayer2.TabIndex = 7;
            this.rbPlayer2.TabStop = true;
            this.rbPlayer2.Text = "Player2";
            this.rbPlayer2.UseVisualStyleBackColor = true;
            this.rbPlayer2.CheckedChanged += new System.EventHandler(this.rbPlayer2_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(101, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 31);
            this.label5.TabIndex = 6;
            this.label5.Text = "Vs";
            // 
            // cbPlayer1
            // 
            this.cbPlayer1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbPlayer1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlayer1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPlayer1.ForeColor = System.Drawing.Color.Black;
            this.cbPlayer1.FormattingEnabled = true;
            this.cbPlayer1.Items.AddRange(new object[] {
            "Marwan",
            "Abdullah",
            "Mohamed",
            "Ahmed"});
            this.cbPlayer1.Location = new System.Drawing.Point(24, 176);
            this.cbPlayer1.Name = "cbPlayer1";
            this.cbPlayer1.Size = new System.Drawing.Size(191, 26);
            this.cbPlayer1.TabIndex = 5;
            this.cbPlayer1.SelectedIndexChanged += new System.EventHandler(this.cbPlayer1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(36, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "-Player1 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(36, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "2- Players` names";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(36, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "1- How many round?";
            // 
            // cbRounds
            // 
            this.cbRounds.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbRounds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRounds.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRounds.ForeColor = System.Drawing.Color.Black;
            this.cbRounds.FormattingEnabled = true;
            this.cbRounds.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbRounds.Location = new System.Drawing.Point(24, 77);
            this.cbRounds.Name = "cbRounds";
            this.cbRounds.Size = new System.Drawing.Size(191, 26);
            this.cbRounds.TabIndex = 0;
            this.cbRounds.SelectedIndexChanged += new System.EventHandler(this.cbRounds_SelectedIndexChanged);
            // 
            // gbBStartGame
            // 
            this.gbBStartGame.Controls.Add(this.btnPress);
            this.gbBStartGame.Controls.Add(this.btnChoicePlayer2OrComputer);
            this.gbBStartGame.Controls.Add(this.btnChoicePlayer1);
            this.gbBStartGame.Controls.Add(this.gbBCountWin);
            this.gbBStartGame.Controls.Add(this.picTurn);
            this.gbBStartGame.Controls.Add(this.btnPaperChoice);
            this.gbBStartGame.Controls.Add(this.btnScissorsChoice);
            this.gbBStartGame.Controls.Add(this.btnStoneChoice);
            this.gbBStartGame.Controls.Add(this.picPlayer2OrComputer);
            this.gbBStartGame.Controls.Add(this.lblNameComputerInGame);
            this.gbBStartGame.Controls.Add(this.lblNamePlayer2InGame);
            this.gbBStartGame.Controls.Add(this.picPlayer1);
            this.gbBStartGame.Controls.Add(this.lblNamePlayer1InGame);
            this.gbBStartGame.Controls.Add(this.pictureBox3);
            this.gbBStartGame.Controls.Add(this.gbBGameInfo);
            this.gbBStartGame.Controls.Add(this.label10);
            this.gbBStartGame.Controls.Add(this.label8);
            this.gbBStartGame.Controls.Add(this.picWinner);
            this.gbBStartGame.Controls.Add(this.label9);
            this.gbBStartGame.Controls.Add(this.lblNumberOfRound);
            this.gbBStartGame.Controls.Add(this.picLosser);
            this.gbBStartGame.Enabled = false;
            this.gbBStartGame.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBStartGame.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gbBStartGame.Location = new System.Drawing.Point(297, 137);
            this.gbBStartGame.Name = "gbBStartGame";
            this.gbBStartGame.Size = new System.Drawing.Size(645, 463);
            this.gbBStartGame.TabIndex = 4;
            this.gbBStartGame.TabStop = false;
            this.gbBStartGame.Text = "Game";
            // 
            // btnPress
            // 
            this.btnPress.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.btnPress.Font = new System.Drawing.Font("Cooper Black", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPress.ForeColor = System.Drawing.Color.Green;
            this.btnPress.Image = ((System.Drawing.Image)(resources.GetObject("btnPress.Image")));
            this.btnPress.Location = new System.Drawing.Point(15, 20);
            this.btnPress.Name = "btnPress";
            this.btnPress.Size = new System.Drawing.Size(632, 342);
            this.btnPress.TabIndex = 8;
            this.btnPress.Text = "Press";
            this.btnPress.UseVisualStyleBackColor = true;
            this.btnPress.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnChoicePlayer2OrComputer
            // 
            this.btnChoicePlayer2OrComputer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChoicePlayer2OrComputer.Font = new System.Drawing.Font("Cooper Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoicePlayer2OrComputer.ForeColor = System.Drawing.Color.Black;
            this.btnChoicePlayer2OrComputer.Location = new System.Drawing.Point(518, 240);
            this.btnChoicePlayer2OrComputer.Name = "btnChoicePlayer2OrComputer";
            this.btnChoicePlayer2OrComputer.Size = new System.Drawing.Size(62, 41);
            this.btnChoicePlayer2OrComputer.TabIndex = 31;
            this.btnChoicePlayer2OrComputer.Tag = "";
            this.btnChoicePlayer2OrComputer.UseVisualStyleBackColor = true;
            // 
            // btnChoicePlayer1
            // 
            this.btnChoicePlayer1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChoicePlayer1.Font = new System.Drawing.Font("Cooper Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoicePlayer1.ForeColor = System.Drawing.Color.Black;
            this.btnChoicePlayer1.Location = new System.Drawing.Point(83, 240);
            this.btnChoicePlayer1.Name = "btnChoicePlayer1";
            this.btnChoicePlayer1.Size = new System.Drawing.Size(62, 41);
            this.btnChoicePlayer1.TabIndex = 30;
            this.btnChoicePlayer1.Tag = "";
            this.btnChoicePlayer1.UseVisualStyleBackColor = true;
            this.btnChoicePlayer1.Click += new System.EventHandler(this.btnChoicePlayer1_Click);
            // 
            // gbBCountWin
            // 
            this.gbBCountWin.Controls.Add(this.lblDrawCounter);
            this.gbBCountWin.Controls.Add(this.lblDraw);
            this.gbBCountWin.Controls.Add(this.lblCountWinlayer2OrComputer);
            this.gbBCountWin.Controls.Add(this.lblCountWinPlayer1);
            this.gbBCountWin.Controls.Add(this.lblComputerCount);
            this.gbBCountWin.Controls.Add(this.lblPlayer2Count);
            this.gbBCountWin.Controls.Add(this.lblPlayer1Count);
            this.gbBCountWin.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBCountWin.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gbBCountWin.Location = new System.Drawing.Point(362, 358);
            this.gbBCountWin.Name = "gbBCountWin";
            this.gbBCountWin.Size = new System.Drawing.Size(279, 99);
            this.gbBCountWin.TabIndex = 12;
            this.gbBCountWin.TabStop = false;
            this.gbBCountWin.Text = "Count Win";
            // 
            // lblDrawCounter
            // 
            this.lblDrawCounter.AutoSize = true;
            this.lblDrawCounter.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrawCounter.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblDrawCounter.Location = new System.Drawing.Point(104, 68);
            this.lblDrawCounter.Name = "lblDrawCounter";
            this.lblDrawCounter.Size = new System.Drawing.Size(103, 19);
            this.lblDrawCounter.TabIndex = 17;
            this.lblDrawCounter.Text = "In Progress";
            this.lblDrawCounter.Visible = false;
            // 
            // lblDraw
            // 
            this.lblDraw.AutoSize = true;
            this.lblDraw.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDraw.ForeColor = System.Drawing.Color.Black;
            this.lblDraw.Location = new System.Drawing.Point(21, 68);
            this.lblDraw.Name = "lblDraw";
            this.lblDraw.Size = new System.Drawing.Size(61, 19);
            this.lblDraw.TabIndex = 16;
            this.lblDraw.Text = "Draw:";
            this.lblDraw.Visible = false;
            // 
            // lblCountWinlayer2OrComputer
            // 
            this.lblCountWinlayer2OrComputer.AutoSize = true;
            this.lblCountWinlayer2OrComputer.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountWinlayer2OrComputer.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCountWinlayer2OrComputer.Location = new System.Drawing.Point(104, 45);
            this.lblCountWinlayer2OrComputer.Name = "lblCountWinlayer2OrComputer";
            this.lblCountWinlayer2OrComputer.Size = new System.Drawing.Size(103, 19);
            this.lblCountWinlayer2OrComputer.TabIndex = 15;
            this.lblCountWinlayer2OrComputer.Text = "In Progress";
            this.lblCountWinlayer2OrComputer.Visible = false;
            // 
            // lblCountWinPlayer1
            // 
            this.lblCountWinPlayer1.AutoSize = true;
            this.lblCountWinPlayer1.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountWinPlayer1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCountWinPlayer1.Location = new System.Drawing.Point(104, 25);
            this.lblCountWinPlayer1.Name = "lblCountWinPlayer1";
            this.lblCountWinPlayer1.Size = new System.Drawing.Size(103, 19);
            this.lblCountWinPlayer1.TabIndex = 13;
            this.lblCountWinPlayer1.Text = "In Progress";
            this.lblCountWinPlayer1.Visible = false;
            this.lblCountWinPlayer1.Click += new System.EventHandler(this.lblCountWinPlayer1_Click);
            // 
            // lblComputerCount
            // 
            this.lblComputerCount.AutoSize = true;
            this.lblComputerCount.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComputerCount.ForeColor = System.Drawing.Color.Black;
            this.lblComputerCount.Location = new System.Drawing.Point(7, 45);
            this.lblComputerCount.Name = "lblComputerCount";
            this.lblComputerCount.Size = new System.Drawing.Size(101, 19);
            this.lblComputerCount.TabIndex = 13;
            this.lblComputerCount.Text = "Computer: ";
            this.lblComputerCount.Visible = false;
            this.lblComputerCount.Click += new System.EventHandler(this.lblComputerCount_Click);
            // 
            // lblPlayer2Count
            // 
            this.lblPlayer2Count.AutoSize = true;
            this.lblPlayer2Count.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2Count.ForeColor = System.Drawing.Color.Black;
            this.lblPlayer2Count.Location = new System.Drawing.Point(17, 45);
            this.lblPlayer2Count.Name = "lblPlayer2Count";
            this.lblPlayer2Count.Size = new System.Drawing.Size(81, 19);
            this.lblPlayer2Count.TabIndex = 14;
            this.lblPlayer2Count.Text = "Player2: ";
            this.lblPlayer2Count.Visible = false;
            // 
            // lblPlayer1Count
            // 
            this.lblPlayer1Count.AutoSize = true;
            this.lblPlayer1Count.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1Count.ForeColor = System.Drawing.Color.Black;
            this.lblPlayer1Count.Location = new System.Drawing.Point(17, 25);
            this.lblPlayer1Count.Name = "lblPlayer1Count";
            this.lblPlayer1Count.Size = new System.Drawing.Size(81, 19);
            this.lblPlayer1Count.TabIndex = 13;
            this.lblPlayer1Count.Text = "Player1: ";
            this.lblPlayer1Count.Visible = false;
            // 
            // picTurn
            // 
            this.picTurn.Image = ((System.Drawing.Image)(resources.GetObject("picTurn.Image")));
            this.picTurn.Location = new System.Drawing.Point(272, 84);
            this.picTurn.Name = "picTurn";
            this.picTurn.Size = new System.Drawing.Size(101, 89);
            this.picTurn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTurn.TabIndex = 29;
            this.picTurn.TabStop = false;
            // 
            // btnPaperChoice
            // 
            this.btnPaperChoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaperChoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPaperChoice.Font = new System.Drawing.Font("Cooper Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaperChoice.ForeColor = System.Drawing.Color.Black;
            this.btnPaperChoice.Location = new System.Drawing.Point(293, 305);
            this.btnPaperChoice.Name = "btnPaperChoice";
            this.btnPaperChoice.Size = new System.Drawing.Size(62, 41);
            this.btnPaperChoice.TabIndex = 28;
            this.btnPaperChoice.Tag = "Paper";
            this.btnPaperChoice.Text = "Paper";
            this.btnPaperChoice.UseVisualStyleBackColor = true;
            this.btnPaperChoice.Click += new System.EventHandler(this.button_Click);
            // 
            // btnScissorsChoice
            // 
            this.btnScissorsChoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScissorsChoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnScissorsChoice.Font = new System.Drawing.Font("Cooper Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScissorsChoice.ForeColor = System.Drawing.Color.Black;
            this.btnScissorsChoice.Location = new System.Drawing.Point(367, 305);
            this.btnScissorsChoice.Name = "btnScissorsChoice";
            this.btnScissorsChoice.Size = new System.Drawing.Size(62, 41);
            this.btnScissorsChoice.TabIndex = 27;
            this.btnScissorsChoice.Tag = "Scissors";
            this.btnScissorsChoice.Text = "Scissors";
            this.btnScissorsChoice.UseVisualStyleBackColor = true;
            this.btnScissorsChoice.Click += new System.EventHandler(this.button_Click);
            // 
            // btnStoneChoice
            // 
            this.btnStoneChoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStoneChoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStoneChoice.Font = new System.Drawing.Font("Cooper Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStoneChoice.ForeColor = System.Drawing.Color.Black;
            this.btnStoneChoice.Location = new System.Drawing.Point(219, 305);
            this.btnStoneChoice.Name = "btnStoneChoice";
            this.btnStoneChoice.Size = new System.Drawing.Size(62, 41);
            this.btnStoneChoice.TabIndex = 26;
            this.btnStoneChoice.Tag = "Stone";
            this.btnStoneChoice.Text = "Stone";
            this.btnStoneChoice.UseVisualStyleBackColor = true;
            this.btnStoneChoice.Click += new System.EventHandler(this.button_Click);
            // 
            // picPlayer2OrComputer
            // 
            this.picPlayer2OrComputer.Location = new System.Drawing.Point(476, 145);
            this.picPlayer2OrComputer.Name = "picPlayer2OrComputer";
            this.picPlayer2OrComputer.Size = new System.Drawing.Size(131, 89);
            this.picPlayer2OrComputer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPlayer2OrComputer.TabIndex = 24;
            this.picPlayer2OrComputer.TabStop = false;
            // 
            // lblNameComputerInGame
            // 
            this.lblNameComputerInGame.AutoSize = true;
            this.lblNameComputerInGame.ForeColor = System.Drawing.Color.Black;
            this.lblNameComputerInGame.Location = new System.Drawing.Point(472, 122);
            this.lblNameComputerInGame.Name = "lblNameComputerInGame";
            this.lblNameComputerInGame.Size = new System.Drawing.Size(108, 21);
            this.lblNameComputerInGame.TabIndex = 23;
            this.lblNameComputerInGame.Text = "Computer";
            this.lblNameComputerInGame.Click += new System.EventHandler(this.lblNameComputerInGame_Click);
            // 
            // lblNamePlayer2InGame
            // 
            this.lblNamePlayer2InGame.AutoSize = true;
            this.lblNamePlayer2InGame.ForeColor = System.Drawing.Color.Black;
            this.lblNamePlayer2InGame.Location = new System.Drawing.Point(472, 122);
            this.lblNamePlayer2InGame.Name = "lblNamePlayer2InGame";
            this.lblNamePlayer2InGame.Size = new System.Drawing.Size(84, 21);
            this.lblNamePlayer2InGame.TabIndex = 22;
            this.lblNamePlayer2InGame.Text = "Player2";
            this.lblNamePlayer2InGame.Visible = false;
            // 
            // picPlayer1
            // 
            this.picPlayer1.Location = new System.Drawing.Point(48, 145);
            this.picPlayer1.Name = "picPlayer1";
            this.picPlayer1.Size = new System.Drawing.Size(131, 89);
            this.picPlayer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPlayer1.TabIndex = 19;
            this.picPlayer1.TabStop = false;
            // 
            // lblNamePlayer1InGame
            // 
            this.lblNamePlayer1InGame.AutoSize = true;
            this.lblNamePlayer1InGame.ForeColor = System.Drawing.Color.Black;
            this.lblNamePlayer1InGame.Location = new System.Drawing.Point(44, 122);
            this.lblNamePlayer1InGame.Name = "lblNamePlayer1InGame";
            this.lblNamePlayer1InGame.Size = new System.Drawing.Size(84, 21);
            this.lblNamePlayer1InGame.TabIndex = 18;
            this.lblNamePlayer1InGame.Text = "Player1";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(220, 179);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(214, 120);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            // 
            // gbBGameInfo
            // 
            this.gbBGameInfo.Controls.Add(this.lblRoundsInGameInfo);
            this.gbBGameInfo.Controls.Add(this.lblRounds);
            this.gbBGameInfo.Controls.Add(this.lblNamePlayer2OrComputerInGameInfo);
            this.gbBGameInfo.Controls.Add(this.lblNamePlayer1InGameInfo);
            this.gbBGameInfo.Controls.Add(this.lblComputer);
            this.gbBGameInfo.Controls.Add(this.lblPlayer2);
            this.gbBGameInfo.Controls.Add(this.lblPlayer1);
            this.gbBGameInfo.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBGameInfo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gbBGameInfo.Location = new System.Drawing.Point(6, 362);
            this.gbBGameInfo.Name = "gbBGameInfo";
            this.gbBGameInfo.Size = new System.Drawing.Size(620, 95);
            this.gbBGameInfo.TabIndex = 6;
            this.gbBGameInfo.TabStop = false;
            this.gbBGameInfo.Text = "Game Info";
            this.gbBGameInfo.Enter += new System.EventHandler(this.gbBGameInfo_Enter_1);
            // 
            // lblRoundsInGameInfo
            // 
            this.lblRoundsInGameInfo.AutoSize = true;
            this.lblRoundsInGameInfo.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoundsInGameInfo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblRoundsInGameInfo.Location = new System.Drawing.Point(91, 26);
            this.lblRoundsInGameInfo.Name = "lblRoundsInGameInfo";
            this.lblRoundsInGameInfo.Size = new System.Drawing.Size(103, 19);
            this.lblRoundsInGameInfo.TabIndex = 13;
            this.lblRoundsInGameInfo.Text = "In Progress";
            this.lblRoundsInGameInfo.Visible = false;
            // 
            // lblRounds
            // 
            this.lblRounds.AutoSize = true;
            this.lblRounds.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRounds.ForeColor = System.Drawing.Color.Black;
            this.lblRounds.Location = new System.Drawing.Point(5, 25);
            this.lblRounds.Name = "lblRounds";
            this.lblRounds.Size = new System.Drawing.Size(80, 19);
            this.lblRounds.TabIndex = 12;
            this.lblRounds.Text = "Rounds: ";
            this.lblRounds.Visible = false;
            // 
            // lblNamePlayer2OrComputerInGameInfo
            // 
            this.lblNamePlayer2OrComputerInGameInfo.AutoSize = true;
            this.lblNamePlayer2OrComputerInGameInfo.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamePlayer2OrComputerInGameInfo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblNamePlayer2OrComputerInGameInfo.Location = new System.Drawing.Point(104, 64);
            this.lblNamePlayer2OrComputerInGameInfo.Name = "lblNamePlayer2OrComputerInGameInfo";
            this.lblNamePlayer2OrComputerInGameInfo.Size = new System.Drawing.Size(103, 19);
            this.lblNamePlayer2OrComputerInGameInfo.TabIndex = 11;
            this.lblNamePlayer2OrComputerInGameInfo.Text = "In Progress";
            this.lblNamePlayer2OrComputerInGameInfo.Visible = false;
            // 
            // lblNamePlayer1InGameInfo
            // 
            this.lblNamePlayer1InGameInfo.AutoSize = true;
            this.lblNamePlayer1InGameInfo.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamePlayer1InGameInfo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblNamePlayer1InGameInfo.Location = new System.Drawing.Point(92, 45);
            this.lblNamePlayer1InGameInfo.Name = "lblNamePlayer1InGameInfo";
            this.lblNamePlayer1InGameInfo.Size = new System.Drawing.Size(103, 19);
            this.lblNamePlayer1InGameInfo.TabIndex = 9;
            this.lblNamePlayer1InGameInfo.Text = "In Progress";
            this.lblNamePlayer1InGameInfo.Visible = false;
            this.lblNamePlayer1InGameInfo.Click += new System.EventHandler(this.lblNamePlayer1InGameInfo_Click);
            // 
            // lblComputer
            // 
            this.lblComputer.AutoSize = true;
            this.lblComputer.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComputer.ForeColor = System.Drawing.Color.Black;
            this.lblComputer.Location = new System.Drawing.Point(5, 64);
            this.lblComputer.Name = "lblComputer";
            this.lblComputer.Size = new System.Drawing.Size(101, 19);
            this.lblComputer.TabIndex = 10;
            this.lblComputer.Text = "Computer: ";
            this.lblComputer.Visible = false;
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2.ForeColor = System.Drawing.Color.Black;
            this.lblPlayer2.Location = new System.Drawing.Point(5, 64);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(81, 19);
            this.lblPlayer2.TabIndex = 9;
            this.lblPlayer2.Text = "Player2: ";
            this.lblPlayer2.Visible = false;
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1.ForeColor = System.Drawing.Color.Black;
            this.lblPlayer1.Location = new System.Drawing.Point(5, 45);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(81, 19);
            this.lblPlayer1.TabIndex = 8;
            this.lblPlayer1.Text = "Player1: ";
            this.lblPlayer1.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(21, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 19);
            this.label10.TabIndex = 15;
            this.label10.Text = "Losser:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(223, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 19);
            this.label8.TabIndex = 7;
            this.label8.Text = "Round: ";
            // 
            // picWinner
            // 
            this.picWinner.Location = new System.Drawing.Point(545, 20);
            this.picWinner.Name = "picWinner";
            this.picWinner.Size = new System.Drawing.Size(94, 64);
            this.picWinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWinner.TabIndex = 14;
            this.picWinner.TabStop = false;
            this.picWinner.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(463, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "Winner:";
            // 
            // lblNumberOfRound
            // 
            this.lblNumberOfRound.AutoSize = true;
            this.lblNumberOfRound.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRound.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblNumberOfRound.Location = new System.Drawing.Point(301, 25);
            this.lblNumberOfRound.Name = "lblNumberOfRound";
            this.lblNumberOfRound.Size = new System.Drawing.Size(45, 19);
            this.lblNumberOfRound.TabIndex = 8;
            this.lblNumberOfRound.Text = "0 / 0";
            this.lblNumberOfRound.Click += new System.EventHandler(this.lblNumberOfRound_Click);
            // 
            // picLosser
            // 
            this.picLosser.Location = new System.Drawing.Point(94, 25);
            this.picLosser.Name = "picLosser";
            this.picLosser.Size = new System.Drawing.Size(94, 64);
            this.picLosser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLosser.TabIndex = 16;
            this.picLosser.TabStop = false;
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.LightGray;
            this.btnStartGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.btnStartGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartGame.Font = new System.Drawing.Font("Cooper Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnStartGame.Location = new System.Drawing.Point(549, 95);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(93, 36);
            this.btnStartGame.TabIndex = 5;
            this.btnStartGame.Text = "StartGame";
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFilliinfo
            // 
            this.btnFilliinfo.BackColor = System.Drawing.Color.LightGray;
            this.btnFilliinfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.btnFilliinfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnFilliinfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilliinfo.Font = new System.Drawing.Font("Cooper Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilliinfo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnFilliinfo.Location = new System.Drawing.Point(450, 95);
            this.btnFilliinfo.Name = "btnFilliinfo";
            this.btnFilliinfo.Size = new System.Drawing.Size(93, 36);
            this.btnFilliinfo.TabIndex = 7;
            this.btnFilliinfo.Text = "Fill Info";
            this.btnFilliinfo.UseVisualStyleBackColor = false;
            this.btnFilliinfo.Visible = false;
            this.btnFilliinfo.Click += new System.EventHandler(this.btnFilliinfo_Click);
            // 
            // btnRestGame
            // 
            this.btnRestGame.BackColor = System.Drawing.Color.LightGray;
            this.btnRestGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSlateGray;
            this.btnRestGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnRestGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestGame.Font = new System.Drawing.Font("Cooper Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestGame.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnRestGame.Location = new System.Drawing.Point(648, 95);
            this.btnRestGame.Name = "btnRestGame";
            this.btnRestGame.Size = new System.Drawing.Size(93, 36);
            this.btnRestGame.TabIndex = 8;
            this.btnRestGame.Text = "ResetGame";
            this.btnRestGame.UseVisualStyleBackColor = false;
            this.btnRestGame.Visible = false;
            this.btnRestGame.Click += new System.EventHandler(this.btnRestGame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1002, 626);
            this.Controls.Add(this.btnRestGame);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.btnFilliinfo);
            this.Controls.Add(this.gbBStartGame);
            this.Controls.Add(this.gbBGameRequirements);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Rock-Paper-Scissors";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbBGameRequirements.ResumeLayout(false);
            this.gbBGameRequirements.PerformLayout();
            this.gbBStartGame.ResumeLayout(false);
            this.gbBStartGame.PerformLayout();
            this.gbBCountWin.ResumeLayout(false);
            this.gbBCountWin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTurn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer2OrComputer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.gbBGameInfo.ResumeLayout(false);
            this.gbBGameInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLosser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbBGameRequirements;
        private System.Windows.Forms.ComboBox cbRounds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPlayer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbComputer;
        private System.Windows.Forms.RadioButton rbPlayer2;
        private System.Windows.Forms.ComboBox cbPlayer2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbComputer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbBStartGame;
        private System.Windows.Forms.GroupBox gbBGameInfo;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnFilliinfo;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblComputer;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Label lblNamePlayer2OrComputerInGameInfo;
        private System.Windows.Forms.Label lblNamePlayer1InGameInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblNumberOfRound;
        private System.Windows.Forms.GroupBox gbBCountWin;
        private System.Windows.Forms.Label lblCountWinlayer2OrComputer;
        private System.Windows.Forms.Label lblCountWinPlayer1;
        private System.Windows.Forms.Label lblComputerCount;
        private System.Windows.Forms.Label lblPlayer2Count;
        private System.Windows.Forms.Label lblPlayer1Count;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox picWinner;
        private System.Windows.Forms.PictureBox picLosser;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblNamePlayer1InGame;
        private System.Windows.Forms.PictureBox picPlayer1;
        private System.Windows.Forms.PictureBox picPlayer2OrComputer;
        private System.Windows.Forms.Label lblNameComputerInGame;
        private System.Windows.Forms.Label lblNamePlayer2InGame;
        private System.Windows.Forms.Button btnPaperChoice;
        private System.Windows.Forms.Button btnScissorsChoice;
        private System.Windows.Forms.Button btnStoneChoice;
        private System.Windows.Forms.PictureBox picTurn;
        private System.Windows.Forms.Button btnPress;
        private System.Windows.Forms.Label lblDrawCounter;
        private System.Windows.Forms.Label lblDraw;
        private System.Windows.Forms.Button btnChoicePlayer1;
        private System.Windows.Forms.Button btnChoicePlayer2OrComputer;
        private System.Windows.Forms.Label lblRoundsInGameInfo;
        private System.Windows.Forms.Label lblRounds;
        private System.Windows.Forms.Button btnRestGame;
    }
}

