namespace GisConvert
{
    partial class AddContextMenuForm
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
            this.btnAddToRighClick = new System.Windows.Forms.Button();
            this.btnRemoveFromRightClick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddToRighClick
            // 
            this.btnAddToRighClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToRighClick.Location = new System.Drawing.Point(12, 77);
            this.btnAddToRighClick.Name = "btnAddToRighClick";
            this.btnAddToRighClick.Size = new System.Drawing.Size(121, 67);
            this.btnAddToRighClick.TabIndex = 0;
            this.btnAddToRighClick.Text = "Add GisConvert to Right-Click";
            this.btnAddToRighClick.UseVisualStyleBackColor = true;
            this.btnAddToRighClick.Click += new System.EventHandler(this.btnAddToRighClick_Click);
            // 
            // btnRemoveFromRightClick
            // 
            this.btnRemoveFromRightClick.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFromRightClick.Location = new System.Drawing.Point(150, 79);
            this.btnRemoveFromRightClick.Name = "btnRemoveFromRightClick";
            this.btnRemoveFromRightClick.Size = new System.Drawing.Size(122, 65);
            this.btnRemoveFromRightClick.TabIndex = 1;
            this.btnRemoveFromRightClick.Text = "Remove from Right-Click";
            this.btnRemoveFromRightClick.UseVisualStyleBackColor = true;
            this.btnRemoveFromRightClick.Click += new System.EventHandler(this.btnRemoveFromRightClick_Click);
            // 
            // AddContextMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnRemoveFromRightClick);
            this.Controls.Add(this.btnAddToRighClick);
            this.Name = "AddContextMenuForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddToRighClick;
        private System.Windows.Forms.Button btnRemoveFromRightClick;
    }
}

