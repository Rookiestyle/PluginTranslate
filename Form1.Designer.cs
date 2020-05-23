namespace RSPluginTranslate
{
	partial class Form1
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.bMergeInTranslation = new System.Windows.Forms.Button();
			this.cbIncludeText = new System.Windows.Forms.CheckBox();
			this.bLoadClass = new System.Windows.Forms.Button();
			this.bLoadXML = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbVersion = new System.Windows.Forms.TextBox();
			this.bSaveXML = new System.Windows.Forms.Button();
			this.bSaveCS = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.tbString = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.cbStrings = new System.Windows.Forms.ComboBox();
			this.tbPluginName = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "xml";
			this.openFileDialog1.Filter = "Language files|*.xml";
			this.openFileDialog1.RestoreDirectory = true;
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "cs";
			this.saveFileDialog1.Filter = "Visual C# class file|*.cs";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.bMergeInTranslation);
			this.groupBox1.Controls.Add(this.cbIncludeText);
			this.groupBox1.Controls.Add(this.bLoadClass);
			this.groupBox1.Controls.Add(this.bLoadXML);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(530, 150);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input";
			// 
			// bMergeInTranslation
			// 
			this.bMergeInTranslation.Location = new System.Drawing.Point(226, 73);
			this.bMergeInTranslation.Name = "bMergeInTranslation";
			this.bMergeInTranslation.Size = new System.Drawing.Size(300, 42);
			this.bMergeInTranslation.TabIndex = 13;
			this.bMergeInTranslation.Text = "Load and merge translation xml";
			this.bMergeInTranslation.UseVisualStyleBackColor = true;
			this.bMergeInTranslation.Click += new System.EventHandler(this.bLoadXML_Click);
			// 
			// cbIncludeText
			// 
			this.cbIncludeText.AutoSize = true;
			this.cbIncludeText.Checked = true;
			this.cbIncludeText.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbIncludeText.Location = new System.Drawing.Point(22, 117);
			this.cbIncludeText.Name = "cbIncludeText";
			this.cbIncludeText.Size = new System.Drawing.Size(129, 24);
			this.cbIncludeText.TabIndex = 11;
			this.cbIncludeText.Text = "Include texts ";
			this.cbIncludeText.UseVisualStyleBackColor = true;
			// 
			// bLoadClass
			// 
			this.bLoadClass.Location = new System.Drawing.Point(22, 25);
			this.bLoadClass.Name = "bLoadClass";
			this.bLoadClass.Size = new System.Drawing.Size(198, 42);
			this.bLoadClass.TabIndex = 10;
			this.bLoadClass.Text = "Load class file";
			this.bLoadClass.UseVisualStyleBackColor = true;
			this.bLoadClass.Click += new System.EventHandler(this.bLoadClass_Click);
			// 
			// bLoadXML
			// 
			this.bLoadXML.Location = new System.Drawing.Point(22, 73);
			this.bLoadXML.Name = "bLoadXML";
			this.bLoadXML.Size = new System.Drawing.Size(198, 42);
			this.bLoadXML.TabIndex = 12;
			this.bLoadXML.Text = "Load translation XML";
			this.bLoadXML.UseVisualStyleBackColor = true;
			this.bLoadXML.Click += new System.EventHandler(this.bLoadXML_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.tbVersion);
			this.groupBox2.Controls.Add(this.bSaveXML);
			this.groupBox2.Controls.Add(this.bSaveCS);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
			this.groupBox2.Location = new System.Drawing.Point(794, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(500, 150);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Output";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 20);
			this.label2.TabIndex = 14;
			this.label2.Text = "Version:";
			// 
			// tbVersion
			// 
			this.tbVersion.Location = new System.Drawing.Point(144, 25);
			this.tbVersion.Name = "tbVersion";
			this.tbVersion.Size = new System.Drawing.Size(120, 26);
			this.tbVersion.TabIndex = 13;
			// 
			// bSaveXML
			// 
			this.bSaveXML.Location = new System.Drawing.Point(22, 57);
			this.bSaveXML.Name = "bSaveXML";
			this.bSaveXML.Size = new System.Drawing.Size(198, 42);
			this.bSaveXML.TabIndex = 11;
			this.bSaveXML.Text = "Save translation XML";
			this.bSaveXML.UseVisualStyleBackColor = true;
			this.bSaveXML.Click += new System.EventHandler(this.bSaveXML_Click);
			// 
			// bSaveCS
			// 
			this.bSaveCS.Location = new System.Drawing.Point(226, 57);
			this.bSaveCS.Name = "bSaveCS";
			this.bSaveCS.Size = new System.Drawing.Size(198, 42);
			this.bSaveCS.TabIndex = 12;
			this.bSaveCS.Text = "Generate class file";
			this.bSaveCS.UseVisualStyleBackColor = true;
			this.bSaveCS.Click += new System.EventHandler(this.bSaveClass_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.AutoSize = true;
			this.groupBox3.Controls.Add(this.panel3);
			this.groupBox3.Controls.Add(this.panel2);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new System.Drawing.Point(0, 150);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(1294, 455);
			this.groupBox3.TabIndex = 13;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Plugin name and texts";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.tbString);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(3, 104);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1288, 348);
			this.panel3.TabIndex = 15;
			// 
			// tbString
			// 
			this.tbString.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbString.Location = new System.Drawing.Point(0, 0);
			this.tbString.Multiline = true;
			this.tbString.Name = "tbString";
			this.tbString.Size = new System.Drawing.Size(1288, 348);
			this.tbString.TabIndex = 13;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Controls.Add(this.cbStrings);
			this.panel2.Controls.Add(this.tbPluginName);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(3, 22);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1288, 82);
			this.panel2.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 20);
			this.label1.TabIndex = 9;
			this.label1.Text = "PluginName:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(374, 49);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(150, 30);
			this.button1.TabIndex = 16;
			this.button1.Text = "Set string";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// cbStrings
			// 
			this.cbStrings.FormattingEnabled = true;
			this.cbStrings.Location = new System.Drawing.Point(16, 51);
			this.cbStrings.Name = "cbStrings";
			this.cbStrings.Size = new System.Drawing.Size(352, 28);
			this.cbStrings.TabIndex = 15;
			this.cbStrings.SelectedIndexChanged += new System.EventHandler(this.cbStrings_SelectionChangeCommitted);
			// 
			// tbPluginName
			// 
			this.tbPluginName.Location = new System.Drawing.Point(138, 19);
			this.tbPluginName.Name = "tbPluginName";
			this.tbPluginName.Size = new System.Drawing.Size(338, 26);
			this.tbPluginName.TabIndex = 14;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(10);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1294, 150);
			this.panel1.TabIndex = 14;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1294, 605);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.panel1);
			this.Name = "Form1";
			this.Text = "Rookiestyle Plugin Translate";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button bMergeInTranslation;
		private System.Windows.Forms.CheckBox cbIncludeText;
		private System.Windows.Forms.Button bLoadClass;
		private System.Windows.Forms.Button bLoadXML;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox tbVersion;
		private System.Windows.Forms.Button bSaveXML;
		private System.Windows.Forms.Button bSaveCS;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox cbStrings;
		private System.Windows.Forms.TextBox tbPluginName;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox tbString;
		private System.Windows.Forms.Label label2;
	}
}

