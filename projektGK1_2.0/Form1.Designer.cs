namespace projektGK1_2._0
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mSlider = new System.Windows.Forms.TrackBar();
            this.kdSlider = new System.Windows.Forms.TrackBar();
            this.ksSlider = new System.Windows.Forms.TrackBar();
            this.manual = new System.Windows.Forms.RadioButton();
            this.randomParameters = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.full = new System.Windows.Forms.RadioButton();
            this.hybrid = new System.Windows.Forms.RadioButton();
            this.aproximate = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.staticL = new System.Windows.Forms.RadioButton();
            this.RandomL = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.openVectorTexture = new System.Windows.Forms.Button();
            this.staticVector = new System.Windows.Forms.RadioButton();
            this.loadVectorTexture = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openFile = new System.Windows.Forms.Button();
            this.selectColor = new System.Windows.Forms.Button();
            this.selectObjectColor = new System.Windows.Forms.RadioButton();
            this.loadTexture = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.drawing_panel = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.LabelSize = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksSlider)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawing_panel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.35922F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.64078F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.drawing_panel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1545, 862);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LabelSize);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1336, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 858);
            this.panel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.mSlider);
            this.groupBox4.Controls.Add(this.kdSlider);
            this.groupBox4.Controls.Add(this.ksSlider);
            this.groupBox4.Controls.Add(this.manual);
            this.groupBox4.Controls.Add(this.randomParameters);
            this.groupBox4.Location = new System.Drawing.Point(16, 388);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(175, 210);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "kd ks parameters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "m";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kd";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ks";
            // 
            // mSlider
            // 
            this.mSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mSlider.Location = new System.Drawing.Point(32, 145);
            this.mSlider.Maximum = 100;
            this.mSlider.Minimum = 1;
            this.mSlider.Name = "mSlider";
            this.mSlider.Size = new System.Drawing.Size(137, 45);
            this.mSlider.TabIndex = 1;
            this.mSlider.Value = 1;
            this.mSlider.Scroll += new System.EventHandler(this.mSlider_Scroll);
            // 
            // kdSlider
            // 
            this.kdSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kdSlider.Location = new System.Drawing.Point(31, 94);
            this.kdSlider.Maximum = 100;
            this.kdSlider.Name = "kdSlider";
            this.kdSlider.Size = new System.Drawing.Size(137, 45);
            this.kdSlider.TabIndex = 1;
            this.kdSlider.Value = 50;
            this.kdSlider.Scroll += new System.EventHandler(this.kdSlider_Scroll);
            // 
            // ksSlider
            // 
            this.ksSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ksSlider.Location = new System.Drawing.Point(31, 43);
            this.ksSlider.Maximum = 100;
            this.ksSlider.Name = "ksSlider";
            this.ksSlider.Size = new System.Drawing.Size(137, 45);
            this.ksSlider.TabIndex = 1;
            this.ksSlider.Value = 50;
            this.ksSlider.Scroll += new System.EventHandler(this.ksSlider_Scroll);
            // 
            // manual
            // 
            this.manual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.manual.AutoSize = true;
            this.manual.Checked = true;
            this.manual.Location = new System.Drawing.Point(6, 19);
            this.manual.Name = "manual";
            this.manual.Size = new System.Drawing.Size(60, 17);
            this.manual.TabIndex = 0;
            this.manual.TabStop = true;
            this.manual.Text = "Manual";
            this.manual.UseVisualStyleBackColor = true;
            // 
            // randomParameters
            // 
            this.randomParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.randomParameters.AutoSize = true;
            this.randomParameters.Location = new System.Drawing.Point(7, 187);
            this.randomParameters.Name = "randomParameters";
            this.randomParameters.Size = new System.Drawing.Size(65, 17);
            this.randomParameters.TabIndex = 0;
            this.randomParameters.Text = "Random";
            this.randomParameters.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.full);
            this.groupBox3.Controls.Add(this.hybrid);
            this.groupBox3.Controls.Add(this.aproximate);
            this.groupBox3.Location = new System.Drawing.Point(16, 291);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(175, 91);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Calculation Method";
            // 
            // full
            // 
            this.full.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.full.AutoSize = true;
            this.full.Checked = true;
            this.full.Location = new System.Drawing.Point(6, 19);
            this.full.Name = "full";
            this.full.Size = new System.Drawing.Size(41, 17);
            this.full.TabIndex = 0;
            this.full.TabStop = true;
            this.full.Text = "Full";
            this.full.UseVisualStyleBackColor = true;
            this.full.CheckedChanged += new System.EventHandler(this.full_CheckedChanged);
            // 
            // hybrid
            // 
            this.hybrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hybrid.AutoSize = true;
            this.hybrid.Location = new System.Drawing.Point(6, 65);
            this.hybrid.Name = "hybrid";
            this.hybrid.Size = new System.Drawing.Size(55, 17);
            this.hybrid.TabIndex = 0;
            this.hybrid.Text = "Hybrid";
            this.hybrid.UseVisualStyleBackColor = true;
            // 
            // aproximate
            // 
            this.aproximate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aproximate.AutoSize = true;
            this.aproximate.Location = new System.Drawing.Point(6, 42);
            this.aproximate.Name = "aproximate";
            this.aproximate.Size = new System.Drawing.Size(77, 17);
            this.aproximate.TabIndex = 0;
            this.aproximate.Text = "Aproximate";
            this.aproximate.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.staticL);
            this.groupBox5.Controls.Add(this.RandomL);
            this.groupBox5.Location = new System.Drawing.Point(17, 604);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(175, 66);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Vector L";
            // 
            // staticL
            // 
            this.staticL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.staticL.AutoSize = true;
            this.staticL.Checked = true;
            this.staticL.Location = new System.Drawing.Point(6, 19);
            this.staticL.Name = "staticL";
            this.staticL.Size = new System.Drawing.Size(52, 17);
            this.staticL.TabIndex = 0;
            this.staticL.TabStop = true;
            this.staticL.Text = "Static";
            this.staticL.UseVisualStyleBackColor = true;
            this.staticL.CheckedChanged += new System.EventHandler(this.staticL_CheckedChanged);
            // 
            // RandomL
            // 
            this.RandomL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RandomL.AutoSize = true;
            this.RandomL.Location = new System.Drawing.Point(6, 42);
            this.RandomL.Name = "RandomL";
            this.RandomL.Size = new System.Drawing.Size(65, 17);
            this.RandomL.TabIndex = 0;
            this.RandomL.Text = "Random";
            this.RandomL.UseVisualStyleBackColor = true;
            this.RandomL.CheckedChanged += new System.EventHandler(this.RandomL_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.openVectorTexture);
            this.groupBox2.Controls.Add(this.staticVector);
            this.groupBox2.Controls.Add(this.loadVectorTexture);
            this.groupBox2.Location = new System.Drawing.Point(17, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vector N";
            // 
            // openVectorTexture
            // 
            this.openVectorTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openVectorTexture.Location = new System.Drawing.Point(18, 65);
            this.openVectorTexture.Name = "openVectorTexture";
            this.openVectorTexture.Size = new System.Drawing.Size(149, 25);
            this.openVectorTexture.TabIndex = 2;
            this.openVectorTexture.Text = "Open File";
            this.openVectorTexture.UseVisualStyleBackColor = true;
            this.openVectorTexture.Visible = false;
            this.openVectorTexture.Click += new System.EventHandler(this.openVectorTexture_Click);
            // 
            // staticVector
            // 
            this.staticVector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.staticVector.AutoSize = true;
            this.staticVector.Checked = true;
            this.staticVector.Location = new System.Drawing.Point(6, 19);
            this.staticVector.Name = "staticVector";
            this.staticVector.Size = new System.Drawing.Size(52, 17);
            this.staticVector.TabIndex = 0;
            this.staticVector.TabStop = true;
            this.staticVector.Text = "Static";
            this.staticVector.UseVisualStyleBackColor = true;
            this.staticVector.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // loadVectorTexture
            // 
            this.loadVectorTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadVectorTexture.AutoSize = true;
            this.loadVectorTexture.Location = new System.Drawing.Point(6, 42);
            this.loadVectorTexture.Name = "loadVectorTexture";
            this.loadVectorTexture.Size = new System.Drawing.Size(88, 17);
            this.loadVectorTexture.TabIndex = 0;
            this.loadVectorTexture.Text = "Load Texture";
            this.loadVectorTexture.UseVisualStyleBackColor = true;
            this.loadVectorTexture.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.openFile);
            this.groupBox1.Controls.Add(this.selectColor);
            this.groupBox1.Controls.Add(this.selectObjectColor);
            this.groupBox1.Controls.Add(this.loadTexture);
            this.groupBox1.Location = new System.Drawing.Point(16, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 130);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Object Color";
            // 
            // openFile
            // 
            this.openFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openFile.Location = new System.Drawing.Point(18, 100);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(150, 25);
            this.openFile.TabIndex = 2;
            this.openFile.Text = "Open File";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Visible = false;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // selectColor
            // 
            this.selectColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectColor.Location = new System.Drawing.Point(18, 42);
            this.selectColor.Name = "selectColor";
            this.selectColor.Size = new System.Drawing.Size(150, 26);
            this.selectColor.TabIndex = 1;
            this.selectColor.Text = "Select Color";
            this.selectColor.UseVisualStyleBackColor = true;
            this.selectColor.Click += new System.EventHandler(this.selectColor_Click);
            // 
            // selectObjectColor
            // 
            this.selectObjectColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectObjectColor.AutoSize = true;
            this.selectObjectColor.Checked = true;
            this.selectObjectColor.Location = new System.Drawing.Point(6, 19);
            this.selectObjectColor.Name = "selectObjectColor";
            this.selectObjectColor.Size = new System.Drawing.Size(116, 17);
            this.selectObjectColor.TabIndex = 0;
            this.selectObjectColor.TabStop = true;
            this.selectObjectColor.Text = "Select Object Color";
            this.selectObjectColor.UseVisualStyleBackColor = true;
            this.selectObjectColor.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // loadTexture
            // 
            this.loadTexture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadTexture.AutoSize = true;
            this.loadTexture.Location = new System.Drawing.Point(6, 74);
            this.loadTexture.Name = "loadTexture";
            this.loadTexture.Size = new System.Drawing.Size(88, 17);
            this.loadTexture.TabIndex = 0;
            this.loadTexture.Text = "Load Texture";
            this.loadTexture.UseVisualStyleBackColor = true;
            this.loadTexture.CheckedChanged += new System.EventHandler(this.loadTexture_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(16, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select Light  Color";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // drawing_panel
            // 
            this.drawing_panel.BackColor = System.Drawing.Color.White;
            this.drawing_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawing_panel.Location = new System.Drawing.Point(2, 2);
            this.drawing_panel.Margin = new System.Windows.Forms.Padding(2);
            this.drawing_panel.Name = "drawing_panel";
            this.drawing_panel.Size = new System.Drawing.Size(1330, 858);
            this.drawing_panel.TabIndex = 1;
            this.drawing_panel.TabStop = false;
            this.drawing_panel.SizeChanged += new System.EventHandler(this.drawing_panel_SizeChanged);
            this.drawing_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawing_panel_Paint);
            this.drawing_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawing_panel_MouseDown);
            this.drawing_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawing_panel_MouseMove);
            this.drawing_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawing_panel_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(18, 698);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 5;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(174, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Value = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 673);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Grid Size:";
            // 
            // LabelSize
            // 
            this.LabelSize.AutoSize = true;
            this.LabelSize.Location = new System.Drawing.Point(72, 673);
            this.LabelSize.Name = "LabelSize";
            this.LabelSize.Size = new System.Drawing.Size(13, 13);
            this.LabelSize.TabIndex = 5;
            this.LabelSize.Text = "5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1545, 862);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksSlider)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawing_panel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox drawing_panel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton loadTexture;
        private System.Windows.Forms.Button selectColor;
        private System.Windows.Forms.RadioButton selectObjectColor;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button openVectorTexture;
        private System.Windows.Forms.RadioButton staticVector;
        private System.Windows.Forms.RadioButton loadVectorTexture;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton full;
        private System.Windows.Forms.RadioButton aproximate;
        private System.Windows.Forms.RadioButton hybrid;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton manual;
        private System.Windows.Forms.RadioButton randomParameters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar ksSlider;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar kdSlider;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar mSlider;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton staticL;
        private System.Windows.Forms.RadioButton RandomL;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label LabelSize;
    }
}

