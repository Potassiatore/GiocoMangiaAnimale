namespace GiocoMangiaAnimale
{
    partial class Application
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Title = new Label();
            StartGame = new Button();
            ChatDiSistema = new Label();
            ChatSistema = new TableLayoutPanel();
            MatriceDiGioco = new TableLayoutPanel();
            MuoviGliAnimali = new Button();
            SuspendLayout();
            // 
            // Title
            // 
            Title.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Title.AutoSize = true;
            Title.BackColor = Color.Khaki;
            Title.Font = new Font("Segoe Print", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            Title.Location = new Point(2, 8);
            Title.Name = "Title";
            Title.Size = new Size(262, 62);
            Title.TabIndex = 0;
            Title.Text = "The life game";
            Title.Click += label1_Click;
            // 
            // StartGame
            // 
            StartGame.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            StartGame.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            StartGame.BackColor = Color.GreenYellow;
            StartGame.Cursor = Cursors.Hand;
            StartGame.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            StartGame.Location = new Point(12, 496);
            StartGame.Name = "StartGame";
            StartGame.Size = new Size(122, 42);
            StartGame.TabIndex = 1;
            StartGame.Text = "StartGame";
            StartGame.UseVisualStyleBackColor = false;
            StartGame.Click += StartGame_Click;
            // 
            // ChatDiSistema
            // 
            ChatDiSistema.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ChatDiSistema.AutoSize = true;
            ChatDiSistema.BackColor = Color.FloralWhite;
            ChatDiSistema.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ChatDiSistema.Location = new Point(12, 70);
            ChatDiSistema.Name = "ChatDiSistema";
            ChatDiSistema.Size = new Size(0, 18);
            ChatDiSistema.TabIndex = 3;
            ChatDiSistema.Click += label2_Click;
            // 
            // ChatSistema
            // 
            ChatSistema.BackColor = Color.Gold;
            ChatSistema.ColumnCount = 1;
            ChatSistema.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ChatSistema.Location = new Point(12, 70);
            ChatSistema.Name = "ChatSistema";
            ChatSistema.RowCount = 10;
            ChatSistema.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ChatSistema.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ChatSistema.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ChatSistema.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ChatSistema.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ChatSistema.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ChatSistema.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ChatSistema.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ChatSistema.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ChatSistema.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            ChatSistema.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            ChatSistema.Size = new Size(321, 424);
            ChatSistema.TabIndex = 4;
            ChatSistema.Paint += tableLayoutPanel1_Paint;
            // 
            // MatriceDiGioco
            // 
            MatriceDiGioco.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MatriceDiGioco.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            MatriceDiGioco.ColumnCount = 6;
            MatriceDiGioco.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            MatriceDiGioco.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            MatriceDiGioco.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            MatriceDiGioco.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            MatriceDiGioco.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            MatriceDiGioco.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            MatriceDiGioco.Location = new Point(352, 29);
            MatriceDiGioco.Name = "MatriceDiGioco";
            MatriceDiGioco.RowCount = 6;
            MatriceDiGioco.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            MatriceDiGioco.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            MatriceDiGioco.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            MatriceDiGioco.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            MatriceDiGioco.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            MatriceDiGioco.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            MatriceDiGioco.Size = new Size(510, 465);
            MatriceDiGioco.TabIndex = 5;
            MatriceDiGioco.Paint += MatriceDiGioco_Paint;
            // 
            // MuoviGliAnimali
            // 
            MuoviGliAnimali.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            MuoviGliAnimali.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MuoviGliAnimali.BackColor = Color.GreenYellow;
            MuoviGliAnimali.Cursor = Cursors.Hand;
            MuoviGliAnimali.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            MuoviGliAnimali.Location = new Point(140, 496);
            MuoviGliAnimali.Name = "MuoviGliAnimali";
            MuoviGliAnimali.Size = new Size(193, 42);
            MuoviGliAnimali.TabIndex = 6;
            MuoviGliAnimali.Text = "Muovi";
            MuoviGliAnimali.UseVisualStyleBackColor = false;
            MuoviGliAnimali.Click += MuoviGliAnimali_Click;
            // 
            // Application
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Khaki;
            ClientSize = new Size(874, 545);
            Controls.Add(MuoviGliAnimali);
            Controls.Add(MatriceDiGioco);
            Controls.Add(ChatSistema);
            Controls.Add(ChatDiSistema);
            Controls.Add(StartGame);
            Controls.Add(Title);
            HelpButton = true;
            Name = "Application";
            Text = "Application";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Title;
        private Button StartGame;
        private Label ChatDiSistema;
        private TableLayoutPanel ChatSistema;
        private TableLayoutPanel MatriceDiGioco;
        private Button MuoviGliAnimali;
    }
}
