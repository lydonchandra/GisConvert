namespace GisConvert
{
    partial class Ogr2ogrForm
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cmbOutputFormat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.lblOutEpsg = new System.Windows.Forms.Label();
            this.cmbOutEpsg = new System.Windows.Forms.ComboBox();
            this.btnBrowseDatabase = new System.Windows.Forms.Button();
            this.txtDbConnection = new System.Windows.Forms.TextBox();
            this.lblDsn = new System.Windows.Forms.Label();
            this.ttDsn = new System.Windows.Forms.ToolTip(this.components);
            this.chkUseDsn = new System.Windows.Forms.CheckBox();
            this.rtbFinalOgrCommand = new System.Windows.Forms.RichTextBox();
            this.lblFinalOgrCommand = new System.Windows.Forms.Label();
            this.btnOgrCommand = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpenCommandPrompt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbInputEpsg = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox1.Location = new System.Drawing.Point(0, 253);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(793, 233);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // cmbOutputFormat
            // 
            this.cmbOutputFormat.FormattingEnabled = true;
            this.cmbOutputFormat.Location = new System.Drawing.Point(161, 12);
            this.cmbOutputFormat.Name = "cmbOutputFormat";
            this.cmbOutputFormat.Size = new System.Drawing.Size(165, 21);
            this.cmbOutputFormat.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Output Format";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(606, 211);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(156, 28);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // lblOutEpsg
            // 
            this.lblOutEpsg.AutoSize = true;
            this.lblOutEpsg.Location = new System.Drawing.Point(63, 69);
            this.lblOutEpsg.Name = "lblOutEpsg";
            this.lblOutEpsg.Size = new System.Drawing.Size(71, 13);
            this.lblOutEpsg.TabIndex = 5;
            this.lblOutEpsg.Text = "Output EPSG";
            // 
            // cmbOutEpsg
            // 
            this.cmbOutEpsg.FormattingEnabled = true;
            this.cmbOutEpsg.Location = new System.Drawing.Point(161, 66);
            this.cmbOutEpsg.Name = "cmbOutEpsg";
            this.cmbOutEpsg.Size = new System.Drawing.Size(165, 21);
            this.cmbOutEpsg.TabIndex = 4;
            // 
            // btnBrowseDatabase
            // 
            this.btnBrowseDatabase.Location = new System.Drawing.Point(555, 89);
            this.btnBrowseDatabase.Name = "btnBrowseDatabase";
            this.btnBrowseDatabase.Size = new System.Drawing.Size(126, 26);
            this.btnBrowseDatabase.TabIndex = 6;
            this.btnBrowseDatabase.Text = "Browse Database";
            this.btnBrowseDatabase.UseVisualStyleBackColor = true;
            this.btnBrowseDatabase.Click += new System.EventHandler(this.btnBrowseDatabase_Click);
            // 
            // txtDbConnection
            // 
            this.txtDbConnection.Location = new System.Drawing.Point(161, 93);
            this.txtDbConnection.Name = "txtDbConnection";
            this.txtDbConnection.Size = new System.Drawing.Size(379, 20);
            this.txtDbConnection.TabIndex = 7;
            // 
            // lblDsn
            // 
            this.lblDsn.AutoSize = true;
            this.lblDsn.Location = new System.Drawing.Point(99, 96);
            this.lblDsn.Name = "lblDsn";
            this.lblDsn.Size = new System.Drawing.Size(30, 13);
            this.lblDsn.TabIndex = 8;
            this.lblDsn.Text = "DSN";
            // 
            // chkUseDsn
            // 
            this.chkUseDsn.AutoSize = true;
            this.chkUseDsn.Location = new System.Drawing.Point(521, 222);
            this.chkUseDsn.Name = "chkUseDsn";
            this.chkUseDsn.Size = new System.Drawing.Size(69, 17);
            this.chkUseDsn.TabIndex = 9;
            this.chkUseDsn.Text = "use DSN";
            this.chkUseDsn.UseVisualStyleBackColor = true;
            // 
            // rtbFinalOgrCommand
            // 
            this.rtbFinalOgrCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbFinalOgrCommand.Location = new System.Drawing.Point(0, 0);
            this.rtbFinalOgrCommand.Name = "rtbFinalOgrCommand";
            this.rtbFinalOgrCommand.Size = new System.Drawing.Size(601, 73);
            this.rtbFinalOgrCommand.TabIndex = 10;
            this.rtbFinalOgrCommand.Text = "";
            // 
            // lblFinalOgrCommand
            // 
            this.lblFinalOgrCommand.AutoSize = true;
            this.lblFinalOgrCommand.Location = new System.Drawing.Point(63, 130);
            this.lblFinalOgrCommand.Name = "lblFinalOgrCommand";
            this.lblFinalOgrCommand.Size = new System.Drawing.Size(94, 13);
            this.lblFinalOgrCommand.TabIndex = 11;
            this.lblFinalOgrCommand.Text = "Ogr2ogr command";
            // 
            // btnOgrCommand
            // 
            this.btnOgrCommand.Location = new System.Drawing.Point(161, 209);
            this.btnOgrCommand.Name = "btnOgrCommand";
            this.btnOgrCommand.Size = new System.Drawing.Size(165, 30);
            this.btnOgrCommand.TabIndex = 12;
            this.btnOgrCommand.Text = "Refresh OGR command";
            this.btnOgrCommand.UseVisualStyleBackColor = true;
            this.btnOgrCommand.Click += new System.EventHandler(this.btnOgrCommand_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.rtbFinalOgrCommand);
            this.panel1.Location = new System.Drawing.Point(161, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 73);
            this.panel1.TabIndex = 13;
            // 
            // btnOpenCommandPrompt
            // 
            this.btnOpenCommandPrompt.Location = new System.Drawing.Point(66, 146);
            this.btnOpenCommandPrompt.Name = "btnOpenCommandPrompt";
            this.btnOpenCommandPrompt.Size = new System.Drawing.Size(89, 59);
            this.btnOpenCommandPrompt.TabIndex = 14;
            this.btnOpenCommandPrompt.Text = "Open shell command prompt";
            this.btnOpenCommandPrompt.UseVisualStyleBackColor = true;
            this.btnOpenCommandPrompt.Click += new System.EventHandler(this.btnOpenCommandPrompt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Input EPSG";
            // 
            // cmbInputEpsg
            // 
            this.cmbInputEpsg.FormattingEnabled = true;
            this.cmbInputEpsg.Location = new System.Drawing.Point(161, 39);
            this.cmbInputEpsg.Name = "cmbInputEpsg";
            this.cmbInputEpsg.Size = new System.Drawing.Size(165, 21);
            this.cmbInputEpsg.TabIndex = 15;
            // 
            // Ogr2ogrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 486);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbInputEpsg);
            this.Controls.Add(this.btnOpenCommandPrompt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOgrCommand);
            this.Controls.Add(this.lblFinalOgrCommand);
            this.Controls.Add(this.chkUseDsn);
            this.Controls.Add(this.lblDsn);
            this.Controls.Add(this.txtDbConnection);
            this.Controls.Add(this.btnBrowseDatabase);
            this.Controls.Add(this.lblOutEpsg);
            this.Controls.Add(this.cmbOutEpsg);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbOutputFormat);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Ogr2ogrForm";
            this.ShowIcon = false;
            this.Text = "Ogr2ogr";
            this.Load += new System.EventHandler(this.Ogr2ogrForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox cmbOutputFormat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label lblOutEpsg;
        private System.Windows.Forms.ComboBox cmbOutEpsg;
        private System.Windows.Forms.Button btnBrowseDatabase;
        private System.Windows.Forms.TextBox txtDbConnection;
        private System.Windows.Forms.Label lblDsn;
        private System.Windows.Forms.ToolTip ttDsn;
        private System.Windows.Forms.CheckBox chkUseDsn;
        private System.Windows.Forms.RichTextBox rtbFinalOgrCommand;
        private System.Windows.Forms.Label lblFinalOgrCommand;
        private System.Windows.Forms.Button btnOgrCommand;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOpenCommandPrompt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbInputEpsg;
    }
}