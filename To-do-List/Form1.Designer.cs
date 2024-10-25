namespace To_do_List
{
    partial class Form1
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
            textNewTask = new TextBox();
            AddTask = new Button();
            ListTask = new ListBox();
            DeleteTask = new Button();
            SafeTask = new Button();
            EditTask = new Button();
            LoadTask = new Button();
            SuspendLayout();
            // 
            // textNewTask
            // 
            textNewTask.BackColor = SystemColors.Menu;
            textNewTask.Location = new Point(8, 9);
            textNewTask.Name = "textNewTask";
            textNewTask.Size = new Size(364, 23);
            textNewTask.TabIndex = 0;
            textNewTask.TextChanged += textNewTask_TextChanged;
            textNewTask.KeyDown += textNewTask_KeyDown;
            // 
            // AddTask
            // 
            AddTask.Location = new Point(378, 9);
            AddTask.Name = "AddTask";
            AddTask.Size = new Size(64, 64);
            AddTask.TabIndex = 1;
            AddTask.Text = "ADD TEXT";
            AddTask.UseVisualStyleBackColor = true;
            AddTask.Click += AddTask_Click;
            // 
            // ListTask
            // 
            ListTask.BackColor = SystemColors.MenuText;
            ListTask.ForeColor = SystemColors.MenuBar;
            ListTask.FormattingEnabled = true;
            ListTask.ItemHeight = 15;
            ListTask.Location = new Point(8, 38);
            ListTask.Name = "ListTask";
            ListTask.SelectionMode = SelectionMode.MultiExtended;
            ListTask.Size = new Size(364, 394);
            ListTask.TabIndex = 2;
            ListTask.SelectedIndexChanged += ListTask_SelectedIndexChanged;
            ListTask.DoubleClick += ListTask_DoubleClick;
            ListTask.KeyDown += ListTask_KeyDown;
            // 
            // DeleteTask
            // 
            DeleteTask.Location = new Point(448, 9);
            DeleteTask.Name = "DeleteTask";
            DeleteTask.Size = new Size(64, 64);
            DeleteTask.TabIndex = 3;
            DeleteTask.Text = "DELETE TEXT";
            DeleteTask.UseVisualStyleBackColor = true;
            DeleteTask.Click += DeleteTask_Click;
            // 
            // SafeTask
            // 
            SafeTask.Location = new Point(378, 79);
            SafeTask.Name = "SafeTask";
            SafeTask.Size = new Size(64, 64);
            SafeTask.TabIndex = 4;
            SafeTask.Text = "SAVE TEXT";
            SafeTask.UseVisualStyleBackColor = true;
            SafeTask.Click += SafeTask_Click;
            // 
            // EditTask
            // 
            EditTask.Location = new Point(448, 79);
            EditTask.Name = "EditTask";
            EditTask.Size = new Size(64, 64);
            EditTask.TabIndex = 5;
            EditTask.Text = "EDIT TEXT";
            EditTask.UseVisualStyleBackColor = true;
            EditTask.Click += EditTask_Click;
            // 
            // LoadTask
            // 
            LoadTask.Location = new Point(408, 149);
            LoadTask.Name = "LoadTask";
            LoadTask.Size = new Size(64, 64);
            LoadTask.TabIndex = 6;
            LoadTask.Text = "LOAD TEXT";
            LoadTask.UseVisualStyleBackColor = true;
            LoadTask.Click += LoadTask_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(804, 451);
            Controls.Add(LoadTask);
            Controls.Add(EditTask);
            Controls.Add(SafeTask);
            Controls.Add(DeleteTask);
            Controls.Add(ListTask);
            Controls.Add(AddTask);
            Controls.Add(textNewTask);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "To Do List";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textNewTask;
        private Button AddTask;
        private ListBox ListTask;
        private Button DeleteTask;
        private Button SafeTask;
        private Button EditTask;
        private Button LoadTask;
    }
}
