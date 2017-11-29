namespace QuickViewer
{
	partial class QuickViewer
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickViewer));
			this.dataGridMembers = new Tekla.Structures.Dialog.UIControls.DataGrid();
			this.labelDataGrid = new System.Windows.Forms.Label();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.cmbBoxMember = new System.Windows.Forms.ComboBox();
			this.logo = new System.Windows.Forms.PictureBox();
			this.txtBoxSearch = new System.Windows.Forms.TextBox();
			this.lblSearch = new System.Windows.Forms.Label();
			this.txtBoxStatus = new System.Windows.Forms.TextBox();
			this.txtBoxModelInfo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tree1 = new Tekla.Structures.Dialog.UIControls.Tree();
			((System.ComponentModel.ISupportInitialize)(this.dataGridMembers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridMembers
			// 
			this.dataGridMembers.AllowUserToAddRows = false;
			this.dataGridMembers.AllowUserToDeleteRows = false;
			this.dataGridMembers.AllowUserToOrderColumns = true;
			this.dataGridMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridMembers.BackgroundColor = System.Drawing.Color.White;
			this.dataGridMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridMembers.GridColor = System.Drawing.SystemColors.ControlLight;
			this.dataGridMembers.Location = new System.Drawing.Point(12, 152);
			this.dataGridMembers.Name = "dataGridMembers";
			this.dataGridMembers.RowTemplate.Height = 24;
			this.dataGridMembers.Size = new System.Drawing.Size(750, 427);
			this.dataGridMembers.TabIndex = 1;
			this.dataGridMembers.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridMembers_CellBeginEdit);
			this.dataGridMembers.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMembers_CellValueChanged);
			this.dataGridMembers.SelectionChanged += new System.EventHandler(this.dataGridMembers_SelectionChanged);
			// 
			// labelDataGrid
			// 
			this.labelDataGrid.AutoSize = true;
			this.labelDataGrid.Location = new System.Drawing.Point(12, 100);
			this.labelDataGrid.Name = "labelDataGrid";
			this.labelDataGrid.Size = new System.Drawing.Size(100, 17);
			this.labelDataGrid.TabIndex = 2;
			this.labelDataGrid.Text = "Member Name";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(657, 113);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(105, 33);
			this.btnRefresh.TabIndex = 5;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// cmbBoxMember
			// 
			this.cmbBoxMember.FormattingEnabled = true;
			this.cmbBoxMember.Location = new System.Drawing.Point(12, 120);
			this.cmbBoxMember.Name = "cmbBoxMember";
			this.cmbBoxMember.Size = new System.Drawing.Size(206, 24);
			this.cmbBoxMember.TabIndex = 4;
			this.cmbBoxMember.SelectedIndexChanged += new System.EventHandler(this.cmbBoxMember_SelectedIndexChanged);
			// 
			// logo
			// 
			this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
			this.logo.Location = new System.Drawing.Point(274, 19);
			this.logo.Margin = new System.Windows.Forms.Padding(10);
			this.logo.Name = "logo";
			this.logo.Padding = new System.Windows.Forms.Padding(20);
			this.logo.Size = new System.Drawing.Size(256, 55);
			this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.logo.TabIndex = 5;
			this.logo.TabStop = false;
			this.logo.Click += new System.EventHandler(this.logo_Click);
			// 
			// txtBoxSearch
			// 
			this.txtBoxSearch.Location = new System.Drawing.Point(274, 122);
			this.txtBoxSearch.Name = "txtBoxSearch";
			this.txtBoxSearch.Size = new System.Drawing.Size(256, 22);
			this.txtBoxSearch.TabIndex = 6;
			this.txtBoxSearch.TextChanged += new System.EventHandler(this.txtBoxSearch_TextChanged);
			// 
			// lblSearch
			// 
			this.lblSearch.AutoSize = true;
			this.lblSearch.Location = new System.Drawing.Point(274, 101);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(152, 17);
			this.lblSearch.TabIndex = 7;
			this.lblSearch.Text = "Search Assembly Mark";
			// 
			// txtBoxStatus
			// 
			this.txtBoxStatus.Location = new System.Drawing.Point(66, 588);
			this.txtBoxStatus.Name = "txtBoxStatus";
			this.txtBoxStatus.Size = new System.Drawing.Size(294, 22);
			this.txtBoxStatus.TabIndex = 8;
			// 
			// txtBoxModelInfo
			// 
			this.txtBoxModelInfo.Location = new System.Drawing.Point(471, 588);
			this.txtBoxModelInfo.Name = "txtBoxModelInfo";
			this.txtBoxModelInfo.Size = new System.Drawing.Size(291, 22);
			this.txtBoxModelInfo.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 591);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 17);
			this.label1.TabIndex = 10;
			this.label1.Text = "Status";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(378, 591);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 17);
			this.label2.TabIndex = 11;
			this.label2.Text = "Model Name";
			// 
			// tree1
			// 
			this.tree1.BackColor = System.Drawing.Color.White;
			this.tree1.Location = new System.Drawing.Point(496, 379);
			this.tree1.Name = "tree1";
			this.tree1.Size = new System.Drawing.Size(8, 8);
			this.tree1.TabIndex = 12;
			// 
			// QuickViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(774, 622);
			this.Controls.Add(this.tree1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtBoxModelInfo);
			this.Controls.Add(this.txtBoxStatus);
			this.Controls.Add(this.lblSearch);
			this.Controls.Add(this.txtBoxSearch);
			this.Controls.Add(this.cmbBoxMember);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.logo);
			this.Controls.Add(this.labelDataGrid);
			this.Controls.Add(this.dataGridMembers);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "QuickViewer";
			this.Text = "Quick Viewer";
			((System.ComponentModel.ISupportInitialize)(this.dataGridMembers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private Tekla.Structures.Dialog.UIControls.DataGrid dataGridMembers;
		private System.Windows.Forms.Label labelDataGrid;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.ComboBox cmbBoxMember;
		private System.Windows.Forms.PictureBox logo;
		private System.Windows.Forms.TextBox txtBoxSearch;
		private System.Windows.Forms.Label lblSearch;
		private System.Windows.Forms.TextBox txtBoxStatus;
		private System.Windows.Forms.TextBox txtBoxModelInfo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Tekla.Structures.Dialog.UIControls.Tree tree1;
	}
}

