namespace Pedal_Power_Interface_v2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LED1 = new System.Windows.Forms.Button();
            this.txtest = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.zgc1 = new ZedGraph.ZedGraphControl();
            this.panel5 = new System.Windows.Forms.Panel();
            this.W_max_lbl = new System.Windows.Forms.Label();
            this.max_power_lbl = new System.Windows.Forms.Label();
            this.txMAX_POWER = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.W_ave_lbl = new System.Windows.Forms.Label();
            this.ave_power_lbl = new System.Windows.Forms.Label();
            this.txAVE_POWER = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.time_lbl = new System.Windows.Forms.Label();
            this.txTIME = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Wh_lbl = new System.Windows.Forms.Label();
            this.Energy_lbl = new System.Windows.Forms.Label();
            this.txENERGY = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.W_lbl = new System.Windows.Forms.Label();
            this.txPOWER = new System.Windows.Forms.Label();
            this.Power_lbl = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tx1 = new System.Windows.Forms.TextBox();
            this.tx2 = new System.Windows.Forms.TextBox();
            this.tx3 = new System.Windows.Forms.TextBox();
            this.tx4 = new System.Windows.Forms.TextBox();
            this.tx5 = new System.Windows.Forms.TextBox();
            this.tx6 = new System.Windows.Forms.TextBox();
            this.tx7 = new System.Windows.Forms.TextBox();
            this.tx8 = new System.Windows.Forms.TextBox();
            this.tx9 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PowerLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LED1
            // 
            this.LED1.BackColor = System.Drawing.Color.Red;
            this.LED1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LED1.Location = new System.Drawing.Point(13, 464);
            this.LED1.Name = "LED1";
            this.LED1.Size = new System.Drawing.Size(160, 27);
            this.LED1.TabIndex = 1;
            this.LED1.UseVisualStyleBackColor = false;
            // 
            // txtest
            // 
            this.txtest.Location = new System.Drawing.Point(17, 18);
            this.txtest.Name = "txtest";
            this.txtest.Size = new System.Drawing.Size(260, 20);
            this.txtest.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 9);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(940, 446);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.zgc1);
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(932, 417);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PEDAL POWER";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // zgc1
            // 
            this.zgc1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zgc1.Location = new System.Drawing.Point(331, 14);
            this.zgc1.Name = "zgc1";
            this.zgc1.ScrollGrace = 0;
            this.zgc1.ScrollMaxX = 0;
            this.zgc1.ScrollMaxY = 0;
            this.zgc1.ScrollMaxY2 = 0;
            this.zgc1.ScrollMinX = 0;
            this.zgc1.ScrollMinY = 0;
            this.zgc1.ScrollMinY2 = 0;
            this.zgc1.Size = new System.Drawing.Size(589, 392);
            this.zgc1.TabIndex = 35;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.W_max_lbl);
            this.panel5.Controls.Add(this.max_power_lbl);
            this.panel5.Controls.Add(this.txMAX_POWER);
            this.panel5.Location = new System.Drawing.Point(17, 210);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(308, 50);
            this.panel5.TabIndex = 34;
            // 
            // W_max_lbl
            // 
            this.W_max_lbl.AutoSize = true;
            this.W_max_lbl.Location = new System.Drawing.Point(253, 13);
            this.W_max_lbl.Name = "W_max_lbl";
            this.W_max_lbl.Size = new System.Drawing.Size(18, 13);
            this.W_max_lbl.TabIndex = 36;
            this.W_max_lbl.Text = "W";
            this.W_max_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // max_power_lbl
            // 
            this.max_power_lbl.AutoSize = true;
            this.max_power_lbl.Location = new System.Drawing.Point(3, 13);
            this.max_power_lbl.Name = "max_power_lbl";
            this.max_power_lbl.Size = new System.Drawing.Size(33, 13);
            this.max_power_lbl.TabIndex = 35;
            this.max_power_lbl.Text = "MAX:";
            this.max_power_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txMAX_POWER
            // 
            this.txMAX_POWER.AutoSize = true;
            this.txMAX_POWER.Location = new System.Drawing.Point(133, 13);
            this.txMAX_POWER.Name = "txMAX_POWER";
            this.txMAX_POWER.Size = new System.Drawing.Size(57, 13);
            this.txMAX_POWER.TabIndex = 29;
            this.txMAX_POWER.Text = "MaxPower";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.W_ave_lbl);
            this.panel4.Controls.Add(this.ave_power_lbl);
            this.panel4.Controls.Add(this.txAVE_POWER);
            this.panel4.Location = new System.Drawing.Point(17, 266);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(308, 50);
            this.panel4.TabIndex = 34;
            // 
            // W_ave_lbl
            // 
            this.W_ave_lbl.AutoSize = true;
            this.W_ave_lbl.Location = new System.Drawing.Point(253, 13);
            this.W_ave_lbl.Name = "W_ave_lbl";
            this.W_ave_lbl.Size = new System.Drawing.Size(18, 13);
            this.W_ave_lbl.TabIndex = 37;
            this.W_ave_lbl.Text = "W";
            this.W_ave_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ave_power_lbl
            // 
            this.ave_power_lbl.AutoSize = true;
            this.ave_power_lbl.Location = new System.Drawing.Point(3, 13);
            this.ave_power_lbl.Name = "ave_power_lbl";
            this.ave_power_lbl.Size = new System.Drawing.Size(61, 13);
            this.ave_power_lbl.TabIndex = 36;
            this.ave_power_lbl.Text = "AVERAGE:";
            this.ave_power_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txAVE_POWER
            // 
            this.txAVE_POWER.AutoSize = true;
            this.txAVE_POWER.Location = new System.Drawing.Point(133, 13);
            this.txAVE_POWER.Name = "txAVE_POWER";
            this.txAVE_POWER.Size = new System.Drawing.Size(56, 13);
            this.txAVE_POWER.TabIndex = 30;
            this.txAVE_POWER.Text = "AvePower";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.time_lbl);
            this.panel3.Controls.Add(this.txTIME);
            this.panel3.Location = new System.Drawing.Point(17, 154);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(308, 50);
            this.panel3.TabIndex = 33;
            // 
            // time_lbl
            // 
            this.time_lbl.AutoSize = true;
            this.time_lbl.Location = new System.Drawing.Point(3, 13);
            this.time_lbl.Name = "time_lbl";
            this.time_lbl.Size = new System.Drawing.Size(36, 13);
            this.time_lbl.TabIndex = 34;
            this.time_lbl.Text = "TIME:";
            this.time_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txTIME
            // 
            this.txTIME.AutoSize = true;
            this.txTIME.Location = new System.Drawing.Point(121, 5);
            this.txTIME.Name = "txTIME";
            this.txTIME.Size = new System.Drawing.Size(30, 13);
            this.txTIME.TabIndex = 31;
            this.txTIME.Text = "Time";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.Wh_lbl);
            this.panel2.Controls.Add(this.Energy_lbl);
            this.panel2.Controls.Add(this.txENERGY);
            this.panel2.Location = new System.Drawing.Point(17, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(308, 64);
            this.panel2.TabIndex = 32;
            // 
            // Wh_lbl
            // 
            this.Wh_lbl.AutoSize = true;
            this.Wh_lbl.Location = new System.Drawing.Point(243, 13);
            this.Wh_lbl.Name = "Wh_lbl";
            this.Wh_lbl.Size = new System.Drawing.Size(24, 13);
            this.Wh_lbl.TabIndex = 34;
            this.Wh_lbl.Text = "Wh";
            // 
            // Energy_lbl
            // 
            this.Energy_lbl.AutoSize = true;
            this.Energy_lbl.Location = new System.Drawing.Point(3, 13);
            this.Energy_lbl.Name = "Energy_lbl";
            this.Energy_lbl.Size = new System.Drawing.Size(55, 13);
            this.Energy_lbl.TabIndex = 33;
            this.Energy_lbl.Text = "ENERGY:";
            this.Energy_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txENERGY
            // 
            this.txENERGY.AutoSize = true;
            this.txENERGY.Location = new System.Drawing.Point(132, 13);
            this.txENERGY.Name = "txENERGY";
            this.txENERGY.Size = new System.Drawing.Size(14, 13);
            this.txENERGY.TabIndex = 28;
            this.txENERGY.Text = "E";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.W_lbl);
            this.panel1.Controls.Add(this.txPOWER);
            this.panel1.Controls.Add(this.Power_lbl);
            this.panel1.Location = new System.Drawing.Point(17, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 64);
            this.panel1.TabIndex = 25;
            // 
            // W_lbl
            // 
            this.W_lbl.AutoSize = true;
            this.W_lbl.Location = new System.Drawing.Point(253, 13);
            this.W_lbl.Name = "W_lbl";
            this.W_lbl.Size = new System.Drawing.Size(18, 13);
            this.W_lbl.TabIndex = 33;
            this.W_lbl.Text = "W";
            // 
            // txPOWER
            // 
            this.txPOWER.AutoSize = true;
            this.txPOWER.Location = new System.Drawing.Point(133, 13);
            this.txPOWER.Name = "txPOWER";
            this.txPOWER.Size = new System.Drawing.Size(14, 13);
            this.txPOWER.TabIndex = 32;
            this.txPOWER.Text = "P";
            // 
            // Power_lbl
            // 
            this.Power_lbl.AutoSize = true;
            this.Power_lbl.Location = new System.Drawing.Point(3, 13);
            this.Power_lbl.Name = "Power_lbl";
            this.Power_lbl.Size = new System.Drawing.Size(51, 13);
            this.Power_lbl.TabIndex = 10;
            this.Power_lbl.Text = "POWER:";
            this.Power_lbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Controls.Add(this.txtest);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(932, 417);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Diagnostics";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tx1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tx2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tx3, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tx4, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.tx5, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.tx6, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.tx7, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.tx8, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.tx9, 1, 8);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(260, 47);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(142, 238);
            this.tableLayoutPanel2.TabIndex = 31;
            // 
            // tx1
            // 
            this.tx1.Location = new System.Drawing.Point(74, 3);
            this.tx1.Name = "tx1";
            this.tx1.Size = new System.Drawing.Size(65, 20);
            this.tx1.TabIndex = 0;
            // 
            // tx2
            // 
            this.tx2.Location = new System.Drawing.Point(74, 29);
            this.tx2.Name = "tx2";
            this.tx2.Size = new System.Drawing.Size(65, 20);
            this.tx2.TabIndex = 1;
            // 
            // tx3
            // 
            this.tx3.Location = new System.Drawing.Point(74, 55);
            this.tx3.Name = "tx3";
            this.tx3.Size = new System.Drawing.Size(65, 20);
            this.tx3.TabIndex = 2;
            // 
            // tx4
            // 
            this.tx4.Location = new System.Drawing.Point(74, 81);
            this.tx4.Name = "tx4";
            this.tx4.Size = new System.Drawing.Size(65, 20);
            this.tx4.TabIndex = 3;
            // 
            // tx5
            // 
            this.tx5.Location = new System.Drawing.Point(74, 107);
            this.tx5.Name = "tx5";
            this.tx5.Size = new System.Drawing.Size(65, 20);
            this.tx5.TabIndex = 4;
            // 
            // tx6
            // 
            this.tx6.Location = new System.Drawing.Point(74, 133);
            this.tx6.Name = "tx6";
            this.tx6.Size = new System.Drawing.Size(65, 20);
            this.tx6.TabIndex = 5;
            // 
            // tx7
            // 
            this.tx7.Location = new System.Drawing.Point(74, 159);
            this.tx7.Name = "tx7";
            this.tx7.Size = new System.Drawing.Size(65, 20);
            this.tx7.TabIndex = 6;
            // 
            // tx8
            // 
            this.tx8.Location = new System.Drawing.Point(74, 185);
            this.tx8.Name = "tx8";
            this.tx8.Size = new System.Drawing.Size(65, 20);
            this.tx8.TabIndex = 7;
            // 
            // tx9
            // 
            this.tx9.Location = new System.Drawing.Point(74, 211);
            this.tx9.Name = "tx9";
            this.tx9.Size = new System.Drawing.Size(65, 20);
            this.tx9.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox6, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox7, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 44);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(158, 186);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(82, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(73, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(82, 55);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(73, 20);
            this.textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(82, 81);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(73, 20);
            this.textBox4.TabIndex = 3;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(82, 107);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(73, 20);
            this.textBox5.TabIndex = 4;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(82, 133);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(73, 20);
            this.textBox6.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Current:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Power:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Energy:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Max Power:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Ave Power:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(82, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(73, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Voltage:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(82, 159);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(73, 20);
            this.textBox7.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Time:";
            // 
            // PowerLabel
            // 
            this.PowerLabel.AutoSize = true;
            this.PowerLabel.Location = new System.Drawing.Point(3, 14);
            this.PowerLabel.Name = "PowerLabel";
            this.PowerLabel.Size = new System.Drawing.Size(51, 13);
            this.PowerLabel.TabIndex = 10;
            this.PowerLabel.Text = "POWER:";
            this.PowerLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(193, 464);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(752, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 556);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.LED1);
            this.Name = "Form1";
            this.Text = "PEDAL POWER MONITOR";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button LED1;
        private System.Windows.Forms.TextBox txtest;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label PowerLabel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label txTIME;
        private System.Windows.Forms.Label txAVE_POWER;
        private System.Windows.Forms.Label txMAX_POWER;
        private System.Windows.Forms.Label txENERGY;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Power_lbl;
        private System.Windows.Forms.Label txPOWER;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Energy_lbl;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label max_power_lbl;
        private System.Windows.Forms.Label ave_power_lbl;
        private System.Windows.Forms.Label time_lbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label7;
        private ZedGraph.ZedGraphControl zgc1;
        private System.Windows.Forms.Label Wh_lbl;
        private System.Windows.Forms.Label W_lbl;
        private System.Windows.Forms.Label W_max_lbl;
        private System.Windows.Forms.Label W_ave_lbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tx1;
        private System.Windows.Forms.TextBox tx2;
        private System.Windows.Forms.TextBox tx3;
        private System.Windows.Forms.TextBox tx4;
        private System.Windows.Forms.TextBox tx5;
        private System.Windows.Forms.TextBox tx6;
        private System.Windows.Forms.TextBox tx7;
        private System.Windows.Forms.TextBox tx8;
        private System.Windows.Forms.TextBox tx9;
    }
}

