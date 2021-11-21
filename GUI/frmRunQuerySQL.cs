using System;
using FastColoredTextBoxNS;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TESTByMe;
using Common;

namespace WindowsFormsApp1
{
    public partial class frmRunQuerySQL : Form
    {
        public frmRunQuerySQL(BLL.BLLDatabase bLLDatabase, string database)
        {
            _bllDatabase = bLLDatabase;
            InitializeComponent();
            _database = database;
        }
        private BLL.BLLDatabase _bllDatabase;
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string query = fctb.Text;
            string msg = string.Empty;
            var dt = _bllDatabase.ExcuteQuery(out msg, query);
            int i = 1;
            tabCtrl_Result.TabPages.Clear();
            if (dt != null)
            {
                foreach (DataTable item in dt.Tables)
                {
                    TabPage tab = new TabPage($"resutl {i}");
                    DataGridView dataGridView = new DataGridView();
                    dataGridView.DataSource = item;
                    dataGridView.Dock = DockStyle.Fill;
                    tab.Controls.Add(dataGridView);
                    tabCtrl_Result.TabPages.Add(tab);
                    i++;
                }

            }

            if (!string.IsNullOrEmpty(msg))
            {
                TabPage tabPage = new TabPage("lỗi");
                RichTextBox richTextBox = new RichTextBox();
                richTextBox.Text = msg;
                richTextBox.SelectionFont = new Font("Tahoma", 15, FontStyle.Bold);
                richTextBox.Dock = DockStyle.Fill;
                tabPage.Controls.Add(richTextBox);

                tabCtrl_Result.TabPages.Add(tabPage);
            }
            split_main.Panel2Collapsed = false;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fctb.Text = "";
        }


        bool hideCollapsed;
        string lang = "SQL";

        //styles
        TextStyle BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        TextStyle BoldStyle = new TextStyle(null, null, FontStyle.Bold | FontStyle.Underline);
        TextStyle GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        TextStyle MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        TextStyle GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        TextStyle BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Italic);
        TextStyle MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        AutocompleteMenu popupMenu;




        private void BuildAutocompleteMenu()
        {
            List<AutocompleteItem> items = new List<AutocompleteItem>();
            GetIDEConFig getIDEConFig = new GetIDEConFig();

            foreach (var item in getIDEConFig.LoadDeclarationSnippets())
                items.Add(new DeclarationSnippet(item) { ImageIndex = 0 });

            foreach (var item in getIDEConFig.LoadMethodsSQL())
                items.Add(new AutocompleteItem(item.Key)
                {
                    ToolTipTitle = item.Key,
                    ToolTipText = item.Description
                });

            foreach (var item in getIDEConFig.LoadProperty())
                items.Add(new MethodAutocompleteItem(item) { ImageIndex = 2 });

            foreach (var item in getIDEConFig.LoadDataTypesSQL())
                items.Add(new AutocompleteItem(item.Key)
                {
                    ToolTipTitle = item.Key,
                    ToolTipText = item.Description
                });
            foreach (var item in getIDEConFig.LoadKeyWordsSQL())
                items.Add(new AutocompleteItem(item.Key)
                {
                    ToolTipTitle = item.Key,
                    ToolTipText = item.Description,
                });

            foreach (var item in LoadDataTableSQL())
                items.Add(new AutocompleteItem(item) { ImageIndex = 3 });


            items.Add(new InsertSpaceSnippet());
            items.Add(new InsertSpaceSnippet(@"^(\w+)([=<>!:]+)(\w+)$"));
            items.Add(new InsertEnterSnippet());

            //set as autocomplete source
            popupMenu.Items.SetAutocompleteItems(items);
        }

        private IEnumerable<string> LoadDataTableSQL()
        {
            return _bllDatabase.GetTB(_database);
        }

        private void InitStylesPriority()
        {
            //add this style explicitly for drawing under other styles
            fctb.AddStyle(SameWordsStyle);
        }
        private void fctb_AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            //block {}
            if (Regex.IsMatch(args.LineText, @"^[^""']*\{.*\}[^""']*$"))
                return;
            //start of block {}
            if (Regex.IsMatch(args.LineText, @"^[^""']*\{"))
            {
                args.ShiftNextLines = args.TabLength;
                return;
            }
            //end of block {}
            if (Regex.IsMatch(args.LineText, @"}[^""']*$"))
            {
                args.Shift = -args.TabLength;
                args.ShiftNextLines = -args.TabLength;
                return;
            }
            //label
            if (Regex.IsMatch(args.LineText, @"^\s*\w+\s*:\s*($|//)") &&
                !Regex.IsMatch(args.LineText, @"^\s*default\s*:"))
            {
                args.Shift = -args.TabLength;
                return;
            }
            //some statements: case, default
            if (Regex.IsMatch(args.LineText, @"^\s*(case|default)\b.*:\s*($|//)"))
            {
                args.Shift = -args.TabLength / 2;
                return;
            }
            //is unclosed operator in previous line ?
            if (Regex.IsMatch(args.PrevLineText, @"^\s*(if|for|foreach|while|[\}\s]*else)\b[^{]*$"))
                if (!Regex.IsMatch(args.PrevLineText, @"(;\s*$)|(;\s*//)"))//operator is unclosed
                {
                    args.Shift = args.TabLength;
                    return;
                }
        }
        private void frmRunQuerySQL_Load(object sender, EventArgs e)
        {

            popupMenu = new AutocompleteMenu(fctb);
            popupMenu.Items.ImageList = imageList1;
            popupMenu.ForeColor = Color.White;
            popupMenu.BackColor = Color.Gray;
            popupMenu.SelectedColor = Color.Purple;
            popupMenu.SearchPattern = @"[\w\.:=!<>]";
            popupMenu.AllowTabKey = true;
            popupMenu.AlwaysShowTooltip = true;
            //
            hideCollapsed = true;
            split_main.Panel2Collapsed = hideCollapsed;
            BuildAutocompleteMenu();
            menuStrip1.Items.Add(new ToolStripLabel($"Database: {_database}"));

            lang = "SQL";
            fctb.Text = "";
            fctb.ClearStylesBuffer();
            fctb.Range.ClearStyle(StyleIndex.All);
            InitStylesPriority();
            fctb.AutoIndentNeeded -= fctb_AutoIndentNeeded;
            //
            switch (lang)
            {
                //For example, we will highlight the syntax of C# manually, although could use built-in highlighter
                case "CSharp (custom highlighter)":
                    fctb.Language = Language.Custom;
                    fctb.CommentPrefix = "//";
                    fctb.AutoIndentNeeded += fctb_AutoIndentNeeded;
                    //call OnTextChanged for refresh syntax highlighting
                    fctb.OnTextChanged();
                    break;
                case "CSharp (built-in highlighter)": fctb.Language = Language.CSharp; break;
                case "VB": fctb.Language = Language.VB; break;
                case "HTML": fctb.Language = Language.HTML; break;
                case "XML": fctb.Language = Language.XML; break;
                case "SQL": fctb.Language = Language.SQL; break;
                case "PHP": fctb.Language = Language.PHP; break;
                case "JS": fctb.Language = Language.JS; break;
                case "Lua": fctb.Language = Language.Lua; break;
                case "JSON": fctb.Language = Language.JSON; break;
            }
            fctb.OnSyntaxHighlight(new TextChangedEventArgs(fctb.Range));
            miChangeColors.Enabled = lang != "CSharp (custom highlighter)";
        }
        Random rnd = new Random();
        private string _database;

        private void miChangeColors_Click(object sender, EventArgs e)
        {
            var styles = new Style[] { fctb.SyntaxHighlighter.BlueBoldStyle, fctb.SyntaxHighlighter.BlueStyle, fctb.SyntaxHighlighter.BoldStyle, fctb.SyntaxHighlighter.BrownStyle, fctb.SyntaxHighlighter.GrayStyle, fctb.SyntaxHighlighter.GreenStyle, fctb.SyntaxHighlighter.MagentaStyle, fctb.SyntaxHighlighter.MaroonStyle, fctb.SyntaxHighlighter.RedStyle };
            fctb.SyntaxHighlighter.AttributeStyle = styles[rnd.Next(styles.Length)];
            fctb.SyntaxHighlighter.ClassNameStyle = styles[rnd.Next(styles.Length)];
            fctb.SyntaxHighlighter.CommentStyle = styles[rnd.Next(styles.Length)];
            fctb.SyntaxHighlighter.CommentTagStyle = styles[rnd.Next(styles.Length)];
            fctb.SyntaxHighlighter.KeywordStyle = styles[rnd.Next(styles.Length)];
            fctb.SyntaxHighlighter.NumberStyle = styles[rnd.Next(styles.Length)];
            fctb.SyntaxHighlighter.StringStyle = styles[rnd.Next(styles.Length)];

            fctb.OnSyntaxHighlight(new TextChangedEventArgs(fctb.Range));
        }

        private void fctb_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (lang)
            {
                case "CSharp (custom highlighter)":
                    //For sample, we will highlight the syntax of C# manually, although could use built-in highlighter
                    CSharpSyntaxHighlight(e);//custom highlighting
                    break;
                default:
                    break;//for highlighting of other languages, we using built-in FastColoredTextBox highlighter
            }

            if (fctb.Text.Trim().StartsWith("<?xml"))
            {
                fctb.Language = Language.XML;

                fctb.ClearStylesBuffer();
                fctb.Range.ClearStyle(StyleIndex.All);
                InitStylesPriority();
                fctb.AutoIndentNeeded -= fctb_AutoIndentNeeded;

                fctb.OnSyntaxHighlight(new TextChangedEventArgs(fctb.Range));
            }
        }

        private void fctb_SelectionChangedDelayed(object sender, EventArgs e)
        {
            fctb.VisibleRange.ClearStyle(SameWordsStyle);
            if (!fctb.Selection.IsEmpty)
                return;//user selected diapason

            //get fragment around caret
            var fragment = fctb.Selection.GetFragment(@"\w");
            string text = fragment.Text;
            if (text.Length == 0)
                return;
            //highlight same words
            var ranges = fctb.VisibleRange.GetRanges("\\b" + text + "\\b").ToArray();
            if (ranges.Length > 1)
                foreach (var r in ranges)
                    r.SetStyle(SameWordsStyle);
        }
        private void CSharpSyntaxHighlight(TextChangedEventArgs e)
        {
            fctb.LeftBracket = '(';
            fctb.RightBracket = ')';
            fctb.LeftBracket2 = '\x0';
            fctb.RightBracket2 = '\x0';
            //clear style of changed range
            e.ChangedRange.ClearStyle(BlueStyle, BoldStyle, GrayStyle, MagentaStyle, GreenStyle, BrownStyle);

            //string highlighting
            e.ChangedRange.SetStyle(BrownStyle, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            //comment highlighting
            e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft);
            //number highlighting
            e.ChangedRange.SetStyle(MagentaStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
            //attribute highlighting
            e.ChangedRange.SetStyle(GrayStyle, @"^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline);
            //class name highlighting
            e.ChangedRange.SetStyle(BoldStyle, @"\b(class|struct|enum|interface)\s+(?<range>\w+?)\b");
            //keyword highlighting
            e.ChangedRange.SetStyle(BlueStyle, @"\b(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while|add|alias|ascending|descending|dynamic|from|get|global|group|into|join|let|orderby|partial|remove|select|set|value|var|where|yield)\b|#region\b|#endregion\b");

            //clear folding markers
            e.ChangedRange.ClearFoldingMarkers();

            //set folding markers
            e.ChangedRange.SetFoldingMarkers("{", "}");//allow to collapse brackets block
            e.ChangedRange.SetFoldingMarkers(@"#region\b", @"#endregion\b");//allow to collapse #region blocks
            e.ChangedRange.SetFoldingMarkers(@"/\*", @"\*/");//allow to collapse comment block
        }
        private void fctb_Load(object sender, EventArgs e)
        {

        }

        private void mnu_hideResult_Click(object sender, EventArgs e)
        {
            hideCollapsed = !hideCollapsed;
            split_main.Panel2Collapsed = hideCollapsed;

        }
    }
    /// <summary>
    /// This autocomplete item appears after dot
    /// </summary>
    public class MethodAutocompleteItem : AutocompleteItem
    {
        string firstPart;
        string lowercaseText;

        public MethodAutocompleteItem(string text)
            : base(text)
        {
            lowercaseText = Text.ToLower();
        }

        public override CompareResult Compare(string fragmentText)
        {
            int i = fragmentText.LastIndexOf('.');
            if (i < 0)
                return CompareResult.Hidden;
            string lastPart = fragmentText.Substring(i + 1);
            firstPart = fragmentText.Substring(0, i);

            if (lastPart == "") return CompareResult.Visible;
            if (Text.StartsWith(lastPart, StringComparison.InvariantCultureIgnoreCase))
                return CompareResult.VisibleAndSelected;
            if (lowercaseText.Contains(lastPart.ToLower()))
                return CompareResult.Visible;

            return CompareResult.Hidden;
        }

        public override string GetTextForReplace()
        {
            return firstPart + "." + Text;
        }
    }
    class DeclarationSnippet : SnippetAutocompleteItem
    {
        public DeclarationSnippet(string snippet)
            : base(snippet)
        {
        }

        public override CompareResult Compare(string fragmentText)
        {
            var pattern = Regex.Escape(fragmentText);
            if (Regex.IsMatch(Text, "\\b" + pattern, RegexOptions.IgnoreCase))
                return CompareResult.Visible;
            return CompareResult.Hidden;
        }
    }

    /// <summary>
    /// Divides numbers and words: "123AND456" -> "123 AND 456"
    /// Or "i=2" -> "i = 2"
    /// </summary>
    class InsertSpaceSnippet : AutocompleteItem
    {
        string pattern;

        public InsertSpaceSnippet(string pattern) : base("")
        {
            this.pattern = pattern;
        }

        public InsertSpaceSnippet()
            : this(@"^(\d+)([a-zA-Z_]+)(\d*)$")
        {
        }

        public override CompareResult Compare(string fragmentText)
        {
            if (Regex.IsMatch(fragmentText, pattern))
            {
                Text = InsertSpaces(fragmentText);
                if (Text != fragmentText)
                    return CompareResult.Visible;
            }
            return CompareResult.Hidden;
        }

        public string InsertSpaces(string fragment)
        {
            var m = Regex.Match(fragment, pattern);
            if (m == null)
                return fragment;
            if (m.Groups[1].Value == "" && m.Groups[3].Value == "")
                return fragment;
            return (m.Groups[1].Value + " " + m.Groups[2].Value + " " + m.Groups[3].Value).Trim();
        }

        public override string ToolTipTitle
        {
            get
            {
                return Text;
            }
        }
    }

    /// <summary>
    /// Inerts line break after '}'
    /// </summary>
    class InsertEnterSnippet : AutocompleteItem
    {
        Place enterPlace = Place.Empty;

        public InsertEnterSnippet()
            : base("[Line break]")
        {
        }

        public override CompareResult Compare(string fragmentText)
        {
            var r = Parent.Fragment.Clone();
            while (r.Start.iChar > 0)
            {
                if (r.CharBeforeStart == '}')
                {
                    enterPlace = r.Start;
                    return CompareResult.Visible;
                }

                r.GoLeftThroughFolded();
            }

            return CompareResult.Hidden;
        }

        public override string GetTextForReplace()
        {
            //extend range
            Range r = Parent.Fragment;
            Place end = r.End;
            r.Start = enterPlace;
            r.End = r.End;
            //insert line break
            return Environment.NewLine + r.Text;
        }

        public override void OnSelected(AutocompleteMenu popupMenu, SelectedEventArgs e)
        {
            base.OnSelected(popupMenu, e);
            if (Parent.Fragment.tb.AutoIndent)
                Parent.Fragment.tb.DoAutoIndent();
        }

        public override string ToolTipTitle
        {
            get
            {
                return "Insert line break after '}'";
            }
        }
    }
    public class CustomReadFile : StreamReader
    {
        public CustomReadFile(string path, Encoding encoding) : base(path, encoding)
        {

        }
        public virtual String ReadLine()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                int ch = Read();
                if (ch == -1) break;
                if (ch == '\r' || ch == '\n')
                {
                    if (ch == '\r' && Peek() == '\n') Read();
                    return sb.ToString();
                }
                sb.Append((char)ch);
            }
            if (sb.Length > 0) return sb.ToString();
            return null;
        }

    }
}