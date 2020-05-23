using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using PluginTranslationOwn;

namespace RSPluginTranslate
{
	public partial class MainForm : Form
	{
		private StringDictionary m_strings = new StringDictionary();
		private string m_placeholder = "PLACEHOLDER-REMOVE-WHEN-SAVING!";

		private static long m_TranslationVersion = 0;

		public MainForm()
		{
			InitializeComponent();
		}

		private void bLoadXML_Click(object sender, EventArgs e)
		{
			openFileDialog1.DefaultExt = "xml";
			openFileDialog1.Filter = "Language xml files|*.xml";
			if (openFileDialog1.ShowDialog() != DialogResult.OK)
				return;

			string filename = openFileDialog1.FileName;

			string translation = File.ReadAllText(filename);

			XmlSerializer xs = new XmlSerializer(m_strings.GetType());
			if (sender is Button && (sender as Button).Name == "bMergeInTranslation")
			{
				StringDictionary m_translatedstrings = (StringDictionary)xs.Deserialize(new StringReader(translation));
				foreach (var x in m_translatedstrings)
				{
					if (m_strings.ContainsKey(x.Key)) m_strings[x.Key] = x.Value;
					else
					{
						if (MessageBox.Show(x.Key + " is only defined in merged translation. Keep?", "Keep text?", MessageBoxButtons.YesNo) == DialogResult.Yes)
							m_strings[x.Key] = x.Value;
					}
				}
			}
			else
			{
				m_strings = (StringDictionary)xs.Deserialize(new StringReader(translation));
				label1.Text = m_strings.Count().ToString() + " imported";
				tbPluginName.Text = KeePassLib.Utility.UrlUtil.GetFileName(filename);
				if (tbPluginName.Text.IndexOf(".") > -1)
					tbPluginName.Text = tbPluginName.Text.Substring(0, tbPluginName.Text.IndexOf("."));
			}
			tbVersion.Text = m_TranslationVersion.ToString();
			InitStrings();
		}

		private void bSaveClass_Click(object sender, EventArgs e)
		{
			saveFileDialog1.DefaultExt = "cs";
			saveFileDialog1.Filter = "Visual C# class files|*.cs";
			saveFileDialog1.FileName = "PluginTranslation.cs";
			if (saveFileDialog1.ShowDialog() != DialogResult.OK)
				return;
			string filename = saveFileDialog1.FileName;

			string content = Resource.ClassStart.Replace("{0}", tbPluginName.Text);
			content = content.Replace("{1}", m_TranslationVersion.ToString());

			foreach (KeyValuePair<string, string> kvp in m_strings)
			{
				string field = Resource.ClassField.Replace("{0}", kvp.Key);
				string v = string.IsNullOrEmpty(kvp.Value) ? string.Empty : "@\"" + kvp.Value.Replace("\"", "\\\"") + "\"";
				field = field.Replace("\"{1}\"", v);
				content += field;
			}

			content += Resource.ClassEnd;

			File.WriteAllText(filename, content);
			MessageBox.Show("Check TranslationVersion!");
		}

		private void bSaveXML_Click(object sender, EventArgs e)
		{
			saveFileDialog1.DefaultExt = "xml";
			saveFileDialog1.Filter = "Language xml files|*.xml";
			saveFileDialog1.FileName = tbPluginName.Text.Replace(" ", string.Empty) + ".template.language.xml";
			if (saveFileDialog1.ShowDialog() != DialogResult.OK)
				return;
			string filename = saveFileDialog1.FileName;

			var serializer = new XmlSerializer(m_strings.GetType());
			var settings = new XmlWriterSettings
			{
				Encoding = new UTF8Encoding(true),
				Indent = true,
				OmitXmlDeclaration = false,
				NewLineHandling = NewLineHandling.None
			};

			using (var stringWriter = new UTF8StringWriter())
			{
				if (!string.IsNullOrEmpty(tbVersion.Text))
					long.TryParse(tbVersion.Text, out m_TranslationVersion);
				using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
				{
					serializer.Serialize(xmlWriter, m_strings);
				}

				string content = stringWriter.ToString();
				content = content.Replace(m_placeholder, string.Empty);
				File.WriteAllText(filename, content);

			}
			MessageBox.Show("Check TranslationVersion!");
		}

		private void bLoadClass_Click(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Visual C# class files|*.cs";
			openFileDialog1.FileName = "PluginTranslation.cs";
			if (openFileDialog1.ShowDialog() != DialogResult.OK)
				return;

			string filename = openFileDialog1.FileName;
			string file = File.ReadAllText(filename);

			Assembly asm = BuildAssembly(file);
			if (asm != null)
			{
				Type type = asm.GetType("PluginTranslation.PluginTranslate");
				PropertyInfo[] props = type.GetProperties(BindingFlags.Static | BindingFlags.Public);
				m_strings.Clear();
				foreach (PropertyInfo p in props)
				{
					if (p.Name == "PluginName")
						continue;
					string v = p.GetValue(type, null) as string;
					m_strings[p.Name] = cbIncludeText.Checked ? v : m_placeholder;
				}
				FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.Public);
				foreach (FieldInfo f in fields)
				{
					if (f.Name == "PluginName")
						continue;
					if (!f.IsInitOnly)
						continue;
					string v = f.GetValue(type) as string;
					m_strings[f.Name] = cbIncludeText.Checked ? v : m_placeholder;
				}

				tbPluginName.Text = type.GetField("PluginName").GetValue(type) as string;
			}
			else
			{
				MessageBox.Show("Could not load class file, using Regex instead");
				string sPreserveNewline = "°~°";
				string sReplaceNewline = "°!°";
				file = file.Replace("\"); }", "\";" + sPreserveNewline);
				file = file.Replace("\";\r\n", "\";" + sPreserveNewline);
				file = file.Replace("\";\r", "\";" + sPreserveNewline);
				file = file.Replace("\";\r", "\";" + sPreserveNewline);
				file = file.Replace("\r\n", "\n");
				file = file.Replace("\r", "\n");
				file = file.Replace("\n", sReplaceNewline);
				file = file.Replace(sPreserveNewline, "\n");

				//Regex r = new Regex("TryGet\\(\"(\\w+)\", \"\\([\\w\\s]+\\)\"", RegexOptions.CultureInvariant | RegexOptions.Compiled);
				Regex r = new Regex(@"TryGet\(""(\w+)"", @?""(.*)"";", RegexOptions.Multiline | RegexOptions.CultureInvariant);
				MatchCollection matches = r.Matches(file);

				if (matches.Count == 0)
				{
					r = new Regex(@"public static readonly string (\w+) = @?""(.*)"";", RegexOptions.Multiline | RegexOptions.CultureInvariant);// | RegexOptions.CultureInvariant);// | RegexOptions.Compiled);
					matches = r.Matches(file);
				}
				m_strings.Clear();
				foreach (Match match in matches)
				{
					m_strings.Add(match.Groups[1].Value, match.Groups[2].Value.Replace(sReplaceNewline, "\n"));
				}

				r = new Regex("public const string PluginName = \"([\\w ]+)\";", RegexOptions.CultureInvariant | RegexOptions.Compiled);
				Match m = r.Match(file);
				if (m.Groups.Count > 1)
					tbPluginName.Text = m.Groups[1].Value;
			}
			InitStrings();
		}

		private void InitStrings()
		{
			cbStrings.Items.Clear();
			foreach (var x in m_strings)
				cbStrings.Items.Add(x.Key);
		}

		private Assembly BuildAssembly(string code)
		{
			CSharpCodeProvider provider =
			   new CSharpCodeProvider(new Dictionary<String, String> { { "CompilerVersion", "v3.5" } });
			CompilerParameters compilerparams = new CompilerParameters();
			compilerparams.GenerateExecutable = false;
			compilerparams.GenerateInMemory = true;
			compilerparams.ReferencedAssemblies.Add(KeePass.Util.WinUtil.GetExecutable());
			compilerparams.ReferencedAssemblies.Add("System.dll");
			compilerparams.ReferencedAssemblies.Add("System.Xml.dll");
			compilerparams.ReferencedAssemblies.Add("System.Windows.Forms.dll");
			compilerparams.ReferencedAssemblies.Add(typeof(KeePass.Plugins.PlgxPlugin).Assembly.Location);
			compilerparams.ReferencedAssemblies.Add(typeof(KeePass.Util.AppLocator).Assembly.Location);
			compilerparams.ReferencedAssemblies.Add(typeof(KeePassLib.Utility.AppLogEx).Assembly.Location);
			string x = Assembly.GetAssembly(typeof(PluginTools.PluginDebug)).Location;
			compilerparams.ReferencedAssemblies.Add(x);
			CompilerResults results = provider.CompileAssemblyFromSource(compilerparams, code);
			if (results.Errors.HasErrors)
			{
				StringBuilder errors = new StringBuilder("Compiler Errors :\r\n");
				foreach (CompilerError error in results.Errors)
				{
					errors.AppendFormat("Line {0},{1}\t: {2}\n",
						   error.Line, error.Column, error.ErrorText);
				}
				MessageBox.Show((errors.ToString()));
				return null;
			}
			else
			{
				return results.CompiledAssembly;
			}
		}

		private void cbStrings_SelectionChangeCommitted(object sender, EventArgs e)
		{
			string x = m_strings[cbStrings.SelectedItem as string];
			x = x.Replace("\r\n", "\n");
			x = x.Replace("\r", "\n");
			tbString.Lines = x.Split('\n');
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string x = tbString.Text;
			x = x.Replace("\\t", "\t");
			x = x.Replace("\r\n", "\n");
			x = x.Replace("\r", "\n");
			m_strings[cbStrings.SelectedItem as string] = x;
		}


		private void Form1_Resize(object sender, EventArgs e)
		{
			tbString.Height = ClientSize.Height - (button1.Top + button1.Height + 20);
		}
	}

	public class UTF8StringWriter : StringWriter
	{
		public override Encoding Encoding
		{
			get
			{
				return Encoding.UTF8;
			}
		}
	}
}