namespace FilesDuplicatesAnalyzer
{
   partial class FrmMain
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
		 if(disposing && (components != null))
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
		 grpbSetUp = new GroupBox();
		 lblDuplicatedFilesResult = new Label();
		 lblDuplicatedFiles = new Label();
		 btnResetSetUp = new Button();
		 lblFilesInFolderResult = new Label();
		 lblFilesInFolder = new Label();
		 chkbSubFolders = new CheckBox();
		 btnSelectFolder = new Button();
		 lblSelectFolder = new Label();
		 grpbDupFiles = new GroupBox();
		 dgvDuplicate = new DataGridView();
		 chkbDeleteDuplicated = new CheckBox();
		 ssStatus = new StatusStrip();
		 tspbStatus = new ToolStripProgressBar();
		 grpbSetUp.SuspendLayout();
		 grpbDupFiles.SuspendLayout();
		 ((System.ComponentModel.ISupportInitialize)dgvDuplicate).BeginInit();
		 ssStatus.SuspendLayout();
		 SuspendLayout();
		 // 
		 // grpbSetUp
		 // 
		 grpbSetUp.Controls.Add(lblDuplicatedFilesResult);
		 grpbSetUp.Controls.Add(lblDuplicatedFiles);
		 grpbSetUp.Controls.Add(btnResetSetUp);
		 grpbSetUp.Controls.Add(lblFilesInFolderResult);
		 grpbSetUp.Controls.Add(lblFilesInFolder);
		 grpbSetUp.Controls.Add(chkbSubFolders);
		 grpbSetUp.Controls.Add(btnSelectFolder);
		 grpbSetUp.Controls.Add(lblSelectFolder);
		 grpbSetUp.Location = new Point(11, 12);
		 grpbSetUp.Name = "grpbSetUp";
		 grpbSetUp.Size = new Size(906, 263);
		 grpbSetUp.TabIndex = 0;
		 grpbSetUp.TabStop = false;
		 grpbSetUp.Text = "Set Up";
		 // 
		 // lblDuplicatedFilesResult
		 // 
		 lblDuplicatedFilesResult.AutoSize = true;
		 lblDuplicatedFilesResult.Location = new Point(179, 218);
		 lblDuplicatedFilesResult.Name = "lblDuplicatedFilesResult";
		 lblDuplicatedFilesResult.Size = new Size(34, 25);
		 lblDuplicatedFilesResult.TabIndex = 7;
		 lblDuplicatedFilesResult.Text = "[...]";
		 // 
		 // lblDuplicatedFiles
		 // 
		 lblDuplicatedFiles.AutoSize = true;
		 lblDuplicatedFiles.Location = new Point(6, 218);
		 lblDuplicatedFiles.Name = "lblDuplicatedFiles";
		 lblDuplicatedFiles.Size = new Size(142, 25);
		 lblDuplicatedFiles.TabIndex = 6;
		 lblDuplicatedFiles.Text = "Duplicated files: ";
		 // 
		 // btnResetSetUp
		 // 
		 btnResetSetUp.Location = new Point(449, 141);
		 btnResetSetUp.Name = "btnResetSetUp";
		 btnResetSetUp.Size = new Size(111, 33);
		 btnResetSetUp.TabIndex = 5;
		 btnResetSetUp.Text = "Reset";
		 btnResetSetUp.UseVisualStyleBackColor = true;
		 // 
		 // lblFilesInFolderResult
		 // 
		 lblFilesInFolderResult.AutoSize = true;
		 lblFilesInFolderResult.Location = new Point(179, 178);
		 lblFilesInFolderResult.Name = "lblFilesInFolderResult";
		 lblFilesInFolderResult.Size = new Size(34, 25);
		 lblFilesInFolderResult.TabIndex = 4;
		 lblFilesInFolderResult.Text = "[...]";
		 // 
		 // lblFilesInFolder
		 // 
		 lblFilesInFolder.AutoSize = true;
		 lblFilesInFolder.Location = new Point(6, 182);
		 lblFilesInFolder.Name = "lblFilesInFolder";
		 lblFilesInFolder.Size = new Size(126, 25);
		 lblFilesInFolder.TabIndex = 3;
		 lblFilesInFolder.Text = "Files in folder: ";
		 // 
		 // chkbSubFolders
		 // 
		 chkbSubFolders.AutoSize = true;
		 chkbSubFolders.Location = new Point(183, 145);
		 chkbSubFolders.Name = "chkbSubFolders";
		 chkbSubFolders.Size = new Size(132, 29);
		 chkbSubFolders.TabIndex = 2;
		 chkbSubFolders.Text = "Subfolders?";
		 chkbSubFolders.UseVisualStyleBackColor = true;
		 chkbSubFolders.CheckedChanged += chkbSubFolders_CheckedChanged;
		 // 
		 // btnSelectFolder
		 // 
		 btnSelectFolder.Location = new Point(332, 141);
		 btnSelectFolder.Name = "btnSelectFolder";
		 btnSelectFolder.Size = new Size(111, 33);
		 btnSelectFolder.TabIndex = 1;
		 btnSelectFolder.Text = "Select";
		 btnSelectFolder.UseVisualStyleBackColor = true;
		 btnSelectFolder.Click += Button_Click;
		 // 
		 // lblSelectFolder
		 // 
		 lblSelectFolder.AutoSize = true;
		 lblSelectFolder.Location = new Point(6, 145);
		 lblSelectFolder.Name = "lblSelectFolder";
		 lblSelectFolder.Size = new Size(159, 25);
		 lblSelectFolder.TabIndex = 0;
		 lblSelectFolder.Text = "Folder to Analyze: ";
		 // 
		 // grpbDupFiles
		 // 
		 grpbDupFiles.Controls.Add(dgvDuplicate);
		 grpbDupFiles.Location = new Point(11, 281);
		 grpbDupFiles.Name = "grpbDupFiles";
		 grpbDupFiles.Size = new Size(906, 417);
		 grpbDupFiles.TabIndex = 1;
		 grpbDupFiles.TabStop = false;
		 grpbDupFiles.Text = "Duplicated files";
		 // 
		 // dgvDuplicate
		 // 
		 dgvDuplicate.AllowUserToAddRows = false;
		 dgvDuplicate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		 dgvDuplicate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		 dgvDuplicate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		 dgvDuplicate.Location = new Point(6, 30);
		 dgvDuplicate.Name = "dgvDuplicate";
		 dgvDuplicate.RowHeadersWidth = 62;
		 dgvDuplicate.RowTemplate.Height = 33;
		 dgvDuplicate.Size = new Size(894, 375);
		 dgvDuplicate.TabIndex = 0;
		 // 
		 // chkbDeleteDuplicated
		 // 
		 chkbDeleteDuplicated.AutoSize = true;
		 chkbDeleteDuplicated.Location = new Point(17, 704);
		 chkbDeleteDuplicated.Name = "chkbDeleteDuplicated";
		 chkbDeleteDuplicated.Size = new Size(184, 29);
		 chkbDeleteDuplicated.TabIndex = 1;
		 chkbDeleteDuplicated.Text = "Delete duplicated?";
		 chkbDeleteDuplicated.UseVisualStyleBackColor = true;
		 // 
		 // ssStatus
		 // 
		 ssStatus.ImageScalingSize = new Size(24, 24);
		 ssStatus.Items.AddRange(new ToolStripItem[] { tspbStatus });
		 ssStatus.Location = new Point(0, 742);
		 ssStatus.Name = "ssStatus";
		 ssStatus.Size = new Size(930, 28);
		 ssStatus.TabIndex = 2;
		 // 
		 // tspbStatus
		 // 
		 tspbStatus.Name = "tspbStatus";
		 tspbStatus.Size = new Size(150, 20);
		 // 
		 // FrmMain
		 // 
		 AutoScaleDimensions = new SizeF(10F, 25F);
		 AutoScaleMode = AutoScaleMode.Font;
		 ClientSize = new Size(930, 770);
		 Controls.Add(ssStatus);
		 Controls.Add(chkbDeleteDuplicated);
		 Controls.Add(grpbDupFiles);
		 Controls.Add(grpbSetUp);
		 MaximizeBox = false;
		 MinimizeBox = false;
		 Name = "FrmMain";
		 Text = "Files Duplicates Analyzer";
		 grpbSetUp.ResumeLayout(false);
		 grpbSetUp.PerformLayout();
		 grpbDupFiles.ResumeLayout(false);
		 ((System.ComponentModel.ISupportInitialize)dgvDuplicate).EndInit();
		 ssStatus.ResumeLayout(false);
		 ssStatus.PerformLayout();
		 ResumeLayout(false);
		 PerformLayout();
	  }

	  #endregion

	  private GroupBox grpbSetUp;
	  private Label lblSelectFolder;
	  private CheckBox chkbSubFolders;
	  private Button btnSelectFolder;
	  private Label lblFilesInFolderResult;
	  private Label lblFilesInFolder;
	  private Button btnResetSetUp;
	  private Label lblDuplicatedFilesResult;
	  private Label lblDuplicatedFiles;
	  private GroupBox grpbDupFiles;
	  private DataGridView dgvDuplicate;
	  private CheckBox chkbDeleteDuplicated;
	  private StatusStrip ssStatus;
	  private ToolStripProgressBar tspbStatus;
   }
}