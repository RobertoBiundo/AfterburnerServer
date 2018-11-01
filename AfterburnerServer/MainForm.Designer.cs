namespace AfterburnerServer
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose( );
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent( )
		{
			this.btToggleServer = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbServerStatus = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btToggleServer
			// 
			this.btToggleServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
			this.btToggleServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btToggleServer.FlatAppearance.BorderSize = 0;
			this.btToggleServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btToggleServer.Font = new System.Drawing.Font("Roboto", 10F);
			this.btToggleServer.ForeColor = System.Drawing.Color.White;
			this.btToggleServer.Location = new System.Drawing.Point(12, 279);
			this.btToggleServer.Name = "btToggleServer";
			this.btToggleServer.Size = new System.Drawing.Size(456, 64);
			this.btToggleServer.TabIndex = 1;
			this.btToggleServer.Text = "START";
			this.btToggleServer.UseVisualStyleBackColor = false;
			this.btToggleServer.Click += new System.EventHandler(this.BT_ToggleServer_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Roboto Medium", 16F);
			this.label1.Location = new System.Drawing.Point(12, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(456, 40);
			this.label1.TabIndex = 2;
			this.label1.Text = "Afterburner Server";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Roboto", 8F);
			this.label2.Location = new System.Drawing.Point(12, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(456, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "version 1.0.0 Alpha";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbServerStatus
			// 
			this.lbServerStatus.Font = new System.Drawing.Font("Roboto", 10F);
			this.lbServerStatus.Location = new System.Drawing.Point(11, 82);
			this.lbServerStatus.Name = "lbServerStatus";
			this.lbServerStatus.Size = new System.Drawing.Size(456, 194);
			this.lbServerStatus.TabIndex = 0;
			this.lbServerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(480, 355);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btToggleServer);
			this.Controls.Add(this.lbServerStatus);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "MainForm";
			this.Text = "Form1";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btToggleServer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbServerStatus;
	}
}

