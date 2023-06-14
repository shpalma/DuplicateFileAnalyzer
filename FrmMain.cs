namespace FilesDuplicatesAnalyzer
{
   public partial class FrmMain : Form
   {

	  private string[] FileExtensions = { "mp4", "avi", "mkv" };
	  public SearchOption SearchOptionType = SearchOption.TopDirectoryOnly;

	  public FrmMain()
	  {
		 InitializeComponent();
	  }

	  private void Button_Click(object sender, EventArgs e)
	  {
		 using var fbd = new FolderBrowserDialog();
		 DialogResult result = fbd.ShowDialog();

		 if(result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
		 {
			string[] files = Directory.GetFiles(fbd.SelectedPath);

			if(files.Length >= 1)
			{
			   DuplicatesAnalyzer analyzer = new();
			   string[] duplicateFiles = analyzer.FindDuplicateFiles(fbd.SelectedPath, FileExtensions, SearchOptionType);
			}
			//else
			//   lblFilesInFolderResult.Text = $"0 files found!";
		 }
	  }

	  private void chkbSubFolders_CheckedChanged(object sender, EventArgs e)
	  {
		 if(chkbSubFolders.Checked)
		 {
			SearchOptionType = SearchOption.AllDirectories;
		 }
		 else
			SearchOptionType = SearchOption.TopDirectoryOnly;
	  }
   }
}