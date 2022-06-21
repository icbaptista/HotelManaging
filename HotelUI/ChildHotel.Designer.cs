namespace HotelUI
{
    partial class ChildHotel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildHotel));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.hotel_dropdown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DreamEscape_groupbox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.description_box = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.DreamEscape_groupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(25, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(321, 246);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bell MT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(465, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dream Escape";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(514, 62);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // hotel_dropdown
            // 
            this.hotel_dropdown.FormattingEnabled = true;
            this.hotel_dropdown.Location = new System.Drawing.Point(141, 60);
            this.hotel_dropdown.Name = "hotel_dropdown";
            this.hotel_dropdown.Size = new System.Drawing.Size(1218, 28);
            this.hotel_dropdown.TabIndex = 4;
            this.hotel_dropdown.SelectedIndexChanged += new System.EventHandler(this.hotel_dropdown_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hotel";
            // 
            // DreamEscape_groupbox
            // 
            this.DreamEscape_groupbox.Controls.Add(this.label2);
            this.DreamEscape_groupbox.Controls.Add(this.description_box);
            this.DreamEscape_groupbox.Controls.Add(this.pictureBox1);
            this.DreamEscape_groupbox.Controls.Add(this.pictureBox2);
            this.DreamEscape_groupbox.Controls.Add(this.label1);
            this.DreamEscape_groupbox.Location = new System.Drawing.Point(70, 117);
            this.DreamEscape_groupbox.Name = "DreamEscape_groupbox";
            this.DreamEscape_groupbox.Size = new System.Drawing.Size(1289, 306);
            this.DreamEscape_groupbox.TabIndex = 6;
            this.DreamEscape_groupbox.TabStop = false;
            this.DreamEscape_groupbox.Text = "DreamEscape";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(465, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "                ";
            // 
            // description_box
            // 
            this.description_box.AutoSize = true;
            this.description_box.Location = new System.Drawing.Point(465, 179);
            this.description_box.Name = "description_box";
            this.description_box.Size = new System.Drawing.Size(73, 20);
            this.description_box.TabIndex = 3;
            this.description_box.Text = "                ";
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Sitka Display", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1414, 39);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pick the accomodation of your dreams!";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ChildHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1414, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DreamEscape_groupbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hotel_dropdown);
            this.Name = "ChildHotel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel";
            this.Load += new System.EventHandler(this.ChildHotel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.DreamEscape_groupbox.ResumeLayout(false);
            this.DreamEscape_groupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox hotel_dropdown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox DreamEscape_groupbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label description_box;
    }
}