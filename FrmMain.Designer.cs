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
		 components = new System.ComponentModel.Container();
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
		 tlpContenedor = new TableLayoutPanel();
		 imglDupFiles = new ImageList(components);
		 imageList1 = new ImageList(components);
		 grpbSetUp.SuspendLayout();
		 grpbDupFiles.SuspendLayout();
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
		 grpbDupFiles.Controls.Add(tlpContenedor);
		 grpbDupFiles.Location = new Point(11, 281);
		 grpbDupFiles.Name = "grpbDupFiles";
		 grpbDupFiles.Size = new Size(906, 260);
		 grpbDupFiles.TabIndex = 1;
		 grpbDupFiles.TabStop = false;
		 grpbDupFiles.Text = "Duplicated files";
		 // 
		 // tlpContenedor
		 // 
		 tlpContenedor.AutoScroll = true;
		 tlpContenedor.ColumnCount = 4;
		 tlpContenedor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
		 tlpContenedor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
		 tlpContenedor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
		 tlpContenedor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
		 tlpContenedor.Location = new Point(6, 30);
		 tlpContenedor.Name = "tlpContenedor";
		 tlpContenedor.RowCount = 5;
		 tlpContenedor.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
		 tlpContenedor.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
		 tlpContenedor.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
		 tlpContenedor.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
		 tlpContenedor.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
		 tlpContenedor.Size = new Size(777, 206);
		 tlpContenedor.TabIndex = 0;
		 // 
		 // imglDupFiles
		 // 
		 imglDupFiles.ColorDepth = ColorDepth.Depth8Bit;
		 imglDupFiles.ImageSize = new Size(16, 16);
		 imglDupFiles.TransparentColor = Color.Transparent;
		 // 
		 // imageList1
		 // 
		 imageList1.ColorDepth = ColorDepth.Depth8Bit;
		 imageList1.ImageSize = new Size(16, 16);
		 imageList1.TransparentColor = Color.Transparent;
		 // 
		 // FrmMain
		 // 
		 AutoScaleDimensions = new SizeF(10F, 25F);
		 AutoScaleMode = AutoScaleMode.Font;
		 ClientSize = new Size(930, 600);
		 Controls.Add(grpbDupFiles);
		 Controls.Add(grpbSetUp);
		 Name = "FrmMain";
		 Text = "Files Duplicates Analyzer";
		 grpbSetUp.ResumeLayout(false);
		 grpbSetUp.PerformLayout();
		 grpbDupFiles.ResumeLayout(false);
		 ResumeLayout(false);
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
	  private ImageList imglDupFiles;
	  private TableLayoutPanel tlpContenedor;
	  private ImageList imageList1;
   }
}