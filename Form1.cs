using System;
using System.Windows.Forms;
using System.Xml;
using XMLReadWrite.Classes;

namespace XMLReadWrite
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblBookName;
		private System.Windows.Forms.Label lblReleaseYear;
		private System.Windows.Forms.ComboBox cboPublication;
		private System.Windows.Forms.Label lblPublication;
		private System.Windows.Forms.ComboBox cboReleaseYear;
		private System.Windows.Forms.ComboBox cboBookName;
		private System.Windows.Forms.Button cmdWriteToFile;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cboPublication = new System.Windows.Forms.ComboBox();
			this.lblPublication = new System.Windows.Forms.Label();
			this.cboReleaseYear = new System.Windows.Forms.ComboBox();
			this.lblReleaseYear = new System.Windows.Forms.Label();
			this.cboBookName = new System.Windows.Forms.ComboBox();
			this.lblBookName = new System.Windows.Forms.Label();
			this.cmdWriteToFile = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cboPublication
			// 
			this.cboPublication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPublication.Location = new System.Drawing.Point(112, 80);
			this.cboPublication.Name = "cboPublication";
			this.cboPublication.Size = new System.Drawing.Size(192, 21);
			this.cboPublication.TabIndex = 25;
			// 
			// lblPublication
			// 
			this.lblPublication.Location = new System.Drawing.Point(24, 80);
			this.lblPublication.Name = "lblPublication";
			this.lblPublication.Size = new System.Drawing.Size(88, 16);
			this.lblPublication.TabIndex = 24;
			this.lblPublication.Text = "Publication";
			// 
			// cboReleaseYear
			// 
			this.cboReleaseYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboReleaseYear.Location = new System.Drawing.Point(112, 48);
			this.cboReleaseYear.Name = "cboReleaseYear";
			this.cboReleaseYear.Size = new System.Drawing.Size(192, 21);
			this.cboReleaseYear.TabIndex = 23;
			// 
			// lblReleaseYear
			// 
			this.lblReleaseYear.Location = new System.Drawing.Point(24, 48);
			this.lblReleaseYear.Name = "lblReleaseYear";
			this.lblReleaseYear.Size = new System.Drawing.Size(88, 16);
			this.lblReleaseYear.TabIndex = 22;
			this.lblReleaseYear.Text = "Release Year";
			// 
			// cboBookName
			// 
			this.cboBookName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboBookName.Location = new System.Drawing.Point(112, 16);
			this.cboBookName.Name = "cboBookName";
			this.cboBookName.Size = new System.Drawing.Size(192, 21);
			this.cboBookName.TabIndex = 21;
			// 
			// lblBookName
			// 
			this.lblBookName.Location = new System.Drawing.Point(24, 16);
			this.lblBookName.Name = "lblBookName";
			this.lblBookName.Size = new System.Drawing.Size(88, 16);
			this.lblBookName.TabIndex = 20;
			this.lblBookName.Text = "Book Name";
			// 
			// cmdWriteToFile
			// 
			this.cmdWriteToFile.Location = new System.Drawing.Point(24, 128);
			this.cmdWriteToFile.Name = "cmdWriteToFile";
			this.cmdWriteToFile.Size = new System.Drawing.Size(280, 24);
			this.cmdWriteToFile.TabIndex = 26;
			this.cmdWriteToFile.Text = "&WriteToFile";
			this.cmdWriteToFile.Click += new System.EventHandler(this.cmdWriteToFile_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 165);
			this.Controls.Add(this.cmdWriteToFile);
			this.Controls.Add(this.cboPublication);
			this.Controls.Add(this.lblPublication);
			this.Controls.Add(this.cboReleaseYear);
			this.Controls.Add(this.lblReleaseYear);
			this.Controls.Add(this.cboBookName);
			this.Controls.Add(this.lblBookName);
			this.Name = "Form1";
			this.Text = "Creating C# application with XML";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
			
		}
		private void ReadXMLFileAndFillCombos()
		{
			try
			{
				string sStartupPath = Application.StartupPath;
				clsSValidator objclsSValidator = new clsSValidator(sStartupPath +  @"..\..\..\XMLFile1.xml", 
					sStartupPath +  @"..\..\..\XMLFile1.xsd");
				if (objclsSValidator.ValidateXMLFile()) return;
				XmlTextReader objXmlTextReader = new XmlTextReader(sStartupPath +  @"..\..\..\XMLFile1.xml"); 
				string sName="";
				while ( objXmlTextReader.Read() ) 
				{ 
					switch (objXmlTextReader.NodeType)
					{
						case XmlNodeType.Element:
							sName=objXmlTextReader.Name;
							break;
						case XmlNodeType.Text:
						switch(sName)
						{
							case "BookName":
								cboBookName.Items.Add(objXmlTextReader.Value);	
								break;
							case "ReleaseYear":
								cboReleaseYear.Items.Add(objXmlTextReader.Value);	
								break;
							case "Publication":
								cboPublication.Items.Add(objXmlTextReader.Value);	
								break;
						}
							break;
					}
				} 
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void Form1_Load(object sender, System.EventArgs e)
		{
			ReadXMLFileAndFillCombos();
		}
		private void WriteXMLFileUsingValuesFromCombos()
		{
			try
			{
				//XmlTextWriter is used below. This class helps us to write xml on 
				//many places like stream, console,file etc we are pushing the xml
				//on a file. Simply nest the Start & End method and its done 
				string sStartupPath = Application.StartupPath;
				XmlTextWriter objXmlTextWriter = new XmlTextWriter(sStartupPath +  @"\selected.xml",null); 
				objXmlTextWriter.Formatting = Formatting.Indented;
				objXmlTextWriter.WriteStartDocument();
				objXmlTextWriter.WriteStartElement("MySelectedValues");
				objXmlTextWriter.WriteStartElement("BookName");
				objXmlTextWriter.WriteString(cboBookName.Text); 
				objXmlTextWriter.WriteEndElement();
				objXmlTextWriter.WriteStartElement("ReleaseYear");
				objXmlTextWriter.WriteString(cboReleaseYear.Text); 
				objXmlTextWriter.WriteEndElement();
				objXmlTextWriter.WriteStartElement("Publication");
				objXmlTextWriter.WriteString(cboPublication.Text); 
				objXmlTextWriter.WriteEndElement();
				objXmlTextWriter.WriteEndElement();
				objXmlTextWriter.WriteEndDocument();
				objXmlTextWriter.Flush();
				objXmlTextWriter.Close();
				MessageBox.Show("The following file has been successfully created\r\n" 
					+ sStartupPath 
					+  @"\selected.xml","XML",MessageBoxButtons.OK,MessageBoxIcon.Information  );
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}

		}
		private void cmdWriteToFile_Click(object sender, System.EventArgs e)
		{
			WriteXMLFileUsingValuesFromCombos();
			
		}
	}
}
