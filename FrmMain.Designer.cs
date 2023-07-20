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
		 System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
		 grpbSetUp = new GroupBox();
		 chkbFileTypeImages = new CheckBox();
		 lblLabelFileTypeAnalyze = new Label();
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
		 ssStatus = new StatusStrip();
		 tspbStatus = new ToolStripProgressBar();
		 btnDDuplicated = new Button();
		 btnSetUp = new Button();
		 grpbSetUp.SuspendLayout();
		 grpbDupFiles.SuspendLayout();
		 ((System.ComponentModel.ISupportInitialize)dgvDuplicate).BeginInit();
		 ssStatus.SuspendLayout();
		 SuspendLayout();
		 // 
		 // grpbSetUp
		 // 
		 grpbSetUp.Controls.Add(chkbFileTypeImages);
		 grpbSetUp.Controls.Add(lblLabelFileTypeAnalyze);
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
		 // chkbFileTypeImages
		 // 
		 chkbFileTypeImages.AutoSize = true;
		 chkbFileTypeImages.Location = new Point(183, 30);
		 chkbFileTypeImages.Name = "chkbFileTypeImages";
		 chkbFileTypeImages.Size = new Size(96, 29);
		 chkbFileTypeImages.TabIndex = 9;
		 chkbFileTypeImages.Text = "Images";
		 chkbFileTypeImages.UseVisualStyleBackColor = true;
		 // 
		 // lblLabelFileTypeAnalyze
		 // 
		 lblLabelFileTypeAnalyze.AutoSize = true;
		 lblLabelFileTypeAnalyze.Location = new Point(6, 27);
		 lblLabelFileTypeAnalyze.Name = "lblLabelFileTypeAnalyze";
		 lblLabelFileTypeAnalyze.Size = new Size(172, 25);
		 lblLabelFileTypeAnalyze.TabIndex = 8;
		 lblLabelFileTypeAnalyze.Text = "File type to analyze: ";
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
		 btnResetSetUp.Image = Properties.Resources.icons8_compose_bluetone_16;
		 btnResetSetUp.ImageAlign = ContentAlignment.MiddleRight;
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
		 btnSelectFolder.Image = Properties.Resources.icons8_documents_bluetone_16;
		 btnSelectFolder.ImageAlign = ContentAlignment.MiddleRight;
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
		 // ssStatus
		 // 
		 ssStatus.ImageScalingSize = new Size(24, 24);
		 ssStatus.Items.AddRange(new ToolStripItem[] { tspbStatus });
		 ssStatus.Location = new Point(0, 773);
		 ssStatus.Name = "ssStatus";
		 ssStatus.Size = new Size(932, 28);
		 ssStatus.TabIndex = 2;
		 // 
		 // tspbStatus
		 // 
		 tspbStatus.Name = "tspbStatus";
		 tspbStatus.Size = new Size(150, 20);
		 // 
		 // btnDDuplicated
		 // 
		 btnDDuplicated.Image = Properties.Resources.icons8_garbage_can_bluetone_16;
		 btnDDuplicated.ImageAlign = ContentAlignment.MiddleRight;
		 btnDDuplicated.Location = new Point(17, 704);
		 btnDDuplicated.Name = "btnDDuplicated";
		 btnDDuplicated.Size = new Size(193, 34);
		 btnDDuplicated.TabIndex = 3;
		 btnDDuplicated.Text = "Delete duplicated";
		 btnDDuplicated.UseVisualStyleBackColor = true;
		 btnDDuplicated.Click += btnDDuplicated_Click;
		 // 
		 // btnSetUp
		 // 
		 btnSetUp.Image = Properties.Resources.icons8_cog_bluetone_16;
		 btnSetUp.ImageAlign = ContentAlignment.MiddleRight;
		 btnSetUp.Location = new Point(806, 704);
		 btnSetUp.Name = "btnSetUp";
		 btnSetUp.Size = new Size(105, 34);
		 btnSetUp.TabIndex = 4;
		 btnSetUp.Text = "SetUp";
		 btnSetUp.UseVisualStyleBackColor = true;
		 // 
		 // FrmMain
		 // 
		 AutoScaleDimensions = new SizeF(10F, 25F);
		 AutoScaleMode = AutoScaleMode.Font;
		 ClientSize = new Size(932, 801);
		 Controls.Add(btnSetUp);
		 Controls.Add(btnDDuplicated);
		 Controls.Add(ssStatus);
		 Controls.Add(grpbDupFiles);
		 Controls.Add(grpbSetUp);
		 Icon = (Icon)resources.GetObject("$this.Icon");
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
	  private StatusStrip ssStatus;
	  private ToolStripProgressBar tspbStatus;
	  private CheckBox chkbFileTypeImages;
	  private Label lblLabelFileTypeAnalyze;
	  private Button btnDDuplicated;
	  private Button btnSetUp;
   }
}