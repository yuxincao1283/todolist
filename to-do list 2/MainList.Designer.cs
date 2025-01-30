namespace to_do_list_2
{
    partial class MainList
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainList));
            AddItem = new Button();
            LoadingGif = new PictureBox();
            labelTodoTask = new Label();
            TodoExpandButton = new PictureBox();
            MissedExpandButton = new PictureBox();
            labelMissedTasks = new Label();
            PastExpandButton = new PictureBox();
            PanelTo_do = new Panel();
            PanelMissedTask = new Panel();
            tablepanelPastTask = new TableLayoutPanel();
            PanelPastTasks = new Panel();
            timerMinuteCheck = new System.Windows.Forms.Timer(components);
            todoTimer = new System.Windows.Forms.Timer(components);
            pastTimer = new System.Windows.Forms.Timer(components);
            missedTimer = new System.Windows.Forms.Timer(components);
            labelPastTask = new Label();
            label1 = new Label();
            updatecheck = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)LoadingGif).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TodoExpandButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MissedExpandButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PastExpandButton).BeginInit();
            SuspendLayout();
            // 
            // AddItem
            // 
            AddItem.Location = new Point(215, 12);
            AddItem.Name = "AddItem";
            AddItem.Size = new Size(169, 34);
            AddItem.TabIndex = 0;
            AddItem.Text = "Create Task";
            AddItem.UseVisualStyleBackColor = true;
            AddItem.Click += button1_Click;
            // 
            // LoadingGif
            // 
            LoadingGif.BackgroundImageLayout = ImageLayout.Zoom;
            LoadingGif.Image = (Image)resources.GetObject("LoadingGif.Image");
            LoadingGif.Location = new Point(12, 12);
            LoadingGif.Name = "LoadingGif";
            LoadingGif.Size = new Size(36, 34);
            LoadingGif.SizeMode = PictureBoxSizeMode.Zoom;
            LoadingGif.TabIndex = 1;
            LoadingGif.TabStop = false;
            LoadingGif.Click += pictureBox1_Click;
            // 
            // labelTodoTask
            // 
            labelTodoTask.AutoSize = true;
            labelTodoTask.Location = new Point(50, 141);
            labelTodoTask.Name = "labelTodoTask";
            labelTodoTask.Size = new Size(79, 20);
            labelTodoTask.TabIndex = 3;
            labelTodoTask.Text = "To-do list";
            labelTodoTask.Click += label1_Click;
            // 
            // TodoExpandButton
            // 
            TodoExpandButton.Image = Properties.Resources.frame1;
            TodoExpandButton.Location = new Point(12, 141);
            TodoExpandButton.Name = "TodoExpandButton";
            TodoExpandButton.Size = new Size(23, 20);
            TodoExpandButton.SizeMode = PictureBoxSizeMode.Zoom;
            TodoExpandButton.TabIndex = 5;
            TodoExpandButton.TabStop = false;
            TodoExpandButton.Tag = "2";
            TodoExpandButton.Click += expandClick;
            // 
            // MissedExpandButton
            // 
            MissedExpandButton.Image = Properties.Resources.frame1;
            MissedExpandButton.Location = new Point(12, 105);
            MissedExpandButton.Name = "MissedExpandButton";
            MissedExpandButton.Size = new Size(23, 20);
            MissedExpandButton.SizeMode = PictureBoxSizeMode.Zoom;
            MissedExpandButton.TabIndex = 6;
            MissedExpandButton.TabStop = false;
            MissedExpandButton.Tag = "1";
            MissedExpandButton.Click += expandClick;
            // 
            // labelMissedTasks
            // 
            labelMissedTasks.AutoSize = true;
            labelMissedTasks.ForeColor = Color.Red;
            labelMissedTasks.Location = new Point(50, 105);
            labelMissedTasks.Name = "labelMissedTasks";
            labelMissedTasks.Size = new Size(101, 20);
            labelMissedTasks.TabIndex = 7;
            labelMissedTasks.Text = "Missed tasks";
            labelMissedTasks.Click += label3_Click;
            // 
            // PastExpandButton
            // 
            PastExpandButton.Image = Properties.Resources.frame1;
            PastExpandButton.InitialImage = Properties.Resources.expand;
            PastExpandButton.Location = new Point(12, 69);
            PastExpandButton.Name = "PastExpandButton";
            PastExpandButton.Size = new Size(23, 20);
            PastExpandButton.SizeMode = PictureBoxSizeMode.Zoom;
            PastExpandButton.TabIndex = 9;
            PastExpandButton.TabStop = false;
            PastExpandButton.Tag = "0";
            PastExpandButton.Click += expandClick;
            // 
            // PanelTo_do
            // 
            PanelTo_do.BorderStyle = BorderStyle.FixedSingle;
            PanelTo_do.Location = new Point(47, 164);
            PanelTo_do.Name = "PanelTo_do";
            PanelTo_do.Size = new Size(337, 2);
            PanelTo_do.TabIndex = 10;
            // 
            // PanelMissedTask
            // 
            PanelMissedTask.BackColor = Color.WhiteSmoke;
            PanelMissedTask.BorderStyle = BorderStyle.FixedSingle;
            PanelMissedTask.Location = new Point(47, 128);
            PanelMissedTask.Name = "PanelMissedTask";
            PanelMissedTask.Size = new Size(337, 2);
            PanelMissedTask.TabIndex = 11;
            PanelMissedTask.Paint += panel2_Paint;
            // 
            // tablepanelPastTask
            // 
            tablepanelPastTask.AutoSize = true;
            tablepanelPastTask.ColumnCount = 2;
            tablepanelPastTask.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablepanelPastTask.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tablepanelPastTask.Location = new Point(47, 86);
            tablepanelPastTask.Name = "tablepanelPastTask";
            tablepanelPastTask.RowCount = 2;
            tablepanelPastTask.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablepanelPastTask.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tablepanelPastTask.Size = new Size(0, 0);
            tablepanelPastTask.TabIndex = 12;
            tablepanelPastTask.Paint += tableLayoutPanel1_Paint;
            // 
            // PanelPastTasks
            // 
            PanelPastTasks.BorderStyle = BorderStyle.FixedSingle;
            PanelPastTasks.Location = new Point(47, 92);
            PanelPastTasks.Name = "PanelPastTasks";
            PanelPastTasks.Size = new Size(337, 2);
            PanelPastTasks.TabIndex = 12;
            // 
            // timerMinuteCheck
            // 
            timerMinuteCheck.Enabled = true;
            timerMinuteCheck.Interval = 30000;
            timerMinuteCheck.Tick += timerMinuteCheck_Tick;
            // 
            // todoTimer
            // 
            todoTimer.Interval = 28;
            todoTimer.Tick += Timer_Tick;
            // 
            // pastTimer
            // 
            pastTimer.Interval = 28;
            pastTimer.Tick += Timer_Tick;
            // 
            // missedTimer
            // 
            missedTimer.Interval = 28;
            missedTimer.Tick += Timer_Tick;
            // 
            // labelPastTask
            // 
            labelPastTask.AutoSize = true;
            labelPastTask.Location = new Point(50, 69);
            labelPastTask.Name = "labelPastTask";
            labelPastTask.Size = new Size(79, 20);
            labelPastTask.TabIndex = 8;
            labelPastTask.Text = "Past tasks";
            labelPastTask.Click += label4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 19);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 13;
            label1.Text = "Cloud ";
            // 
            // updatecheck
            // 
            updatecheck.Interval = 5000;
            updatecheck.Tick += updatecheck_Tick;
            // 
            // MainList
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(406, 524);
            Controls.Add(label1);
            Controls.Add(PanelPastTasks);
            Controls.Add(tablepanelPastTask);
            Controls.Add(PanelMissedTask);
            Controls.Add(PanelTo_do);
            Controls.Add(PastExpandButton);
            Controls.Add(labelPastTask);
            Controls.Add(labelMissedTasks);
            Controls.Add(MissedExpandButton);
            Controls.Add(TodoExpandButton);
            Controls.Add(labelTodoTask);
            Controls.Add(LoadingGif);
            Controls.Add(AddItem);
            Name = "MainList";
            Text = "To-do list";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)LoadingGif).EndInit();
            ((System.ComponentModel.ISupportInitialize)TodoExpandButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)MissedExpandButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)PastExpandButton).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddItem;
        private PictureBox LoadingGif;
        private Label labelTodoTask;
        private Label label2;
        private PictureBox TodoExpandButton;
        private PictureBox MissedExpandButton;
        private Label labelMissedTasks;
        private PictureBox PastExpandButton;
        private Panel PanelTo_do;
        private Panel PanelMissedTask;
        private TableLayoutPanel tablepanelPastTask;
        private PictureBox pictureBox4;
        private Panel PanelPastTasks;
        private System.Windows.Forms.Timer timerMinuteCheck;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer todoTimer;
        private System.Windows.Forms.Timer pastTimer;
        private System.Windows.Forms.Timer missedTimer;
        private Label labelPastTask;
        private Label label1;
        private System.Windows.Forms.Timer updatecheck;
    }
}
