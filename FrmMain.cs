using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace FilesDuplicatesAnalyzer
{
   public partial class FrmMain : Form
   {

	  //private string[] FileExtensions = { "mp4", "avi", "mkv" };
	  private string[] FileExtensions = { "jpg", "png" };
	  public SearchOption SearchOptionType = SearchOption.TopDirectoryOnly;

	  public FrmMain()
	  {
		 InitializeComponent();
	  }

	  private void Button_Click(object sender, EventArgs e)
	  {
		 try
		 {
			using var fbd = new FolderBrowserDialog();
			DialogResult result = fbd.ShowDialog();

			if(result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
			{
			   #region old code
			   //string[] files = Directory.GetFiles(fbd.SelectedPath);

			   //if(files.Length >= 1)
			   //{
			   //   DuplicatesAnalyzer analyzer = new();
			   //   string[] duplicateFiles = analyzer.FindDuplicateFiles(fbd.SelectedPath, FileExtensions, SearchOptionType);
			   //}
			   #endregion

			   // images
			   DuplicatesAnalyzer analyzer = new();
			   string[] duplicatedFiles = analyzer.AlanyzeImages(fbd.SelectedPath, "jpg", SearchOptionType);

			   if(duplicatedFiles.Length >= 1)
			   {
				  Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" {duplicatedFiles.Length} files found");

				  int row = tlpContenedor.RowCount;
				  tlpContenedor.Dock = DockStyle.Fill; // Rellenar todo el espacio del formulario
				  tlpContenedor.AutoScroll = true; // Habilitar el desplazamiento automático si hay muchas imágenes
				  Panel panel = new Panel();
				  panel.AutoScroll = true;


				  foreach(string archivo in duplicatedFiles)
				  {
					 string[] rutas = archivo.Split('|'); // Separar las rutas

					 if(rutas.Length == 2)
					 {
						PictureBox pictureBox = new PictureBox();
						pictureBox.ImageLocation = rutas[0];
						//pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
						pictureBox.Size = new Size(180, 200);
						Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" Original: {rutas[0]}");


						PictureBox pictureBoxDuplicado = new PictureBox();
						pictureBoxDuplicado.ImageLocation = rutas[1];
						//pictureBoxDuplicado.SizeMode = PictureBoxSizeMode.AutoSize;
						pictureBoxDuplicado.Size = new Size(180, 200);
						Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" Duplicated: {rutas[1]}");

						tlpContenedor.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Agregar una nueva fila automáticamente

						tlpContenedor.Controls.Add(pictureBox, 0, row);
						tlpContenedor.Controls.Add(pictureBoxDuplicado, 1, row);

						row++;

					 }
				  }

				  panel.Controls.Add(tlpContenedor); // Agregar el TableLayoutPanel al panel
				  panel.Dock = DockStyle.Fill; // Rellenar todo el espacio del panel

				  grpbDupFiles.Controls.Add(panel); // Agregar el panel al GroupBox

				  tlpContenedor.Parent = panel;
			   }
			   else
			   {
				  Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + " 0 files found");
			   }
			}
		 }
		 catch(Exception ex)
		 {
			Debug.WriteLine(DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + $" Exception(general): {ex.Message}");
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