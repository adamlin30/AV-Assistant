namespace AVAssistant
{
    partial class AV_Assistant
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AV_Assistant));
            this.avTabControl = new System.Windows.Forms.TabControl();
            this.downloadTabPage = new System.Windows.Forms.TabPage();
            this.dowloadGroupBox = new System.Windows.Forms.GroupBox();
            this.wgetLinks = new System.Windows.Forms.TextBox();
            this.infoTextBox = new System.Windows.Forms.TextBox();
            this.actressModeTabPage = new System.Windows.Forms.TabPage();
            this.actressModeGroupBox = new System.Windows.Forms.GroupBox();
            this.rankCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.VideoNumActressMode = new System.Windows.Forms.TextBox();
            this.actressVideoLabel = new System.Windows.Forms.Label();
            this.actressNameLabel = new System.Windows.Forms.Label();
            this.actressListBox = new System.Windows.Forms.ListBox();
            this.actressVideoTreeView = new System.Windows.Forms.TreeView();
            this.rankGroupBox = new System.Windows.Forms.GroupBox();
            this.videoModeTabPage = new System.Windows.Forms.TabPage();
            this.videoModeGroupBox = new System.Windows.Forms.GroupBox();
            this.genreCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.numOfFile = new System.Windows.Forms.TextBox();
            this.fileSize = new System.Windows.Forms.TextBox();
            this.vidoFileLabel = new System.Windows.Forms.Label();
            this.vidoListLabel = new System.Windows.Forms.Label();
            this.videoFileTreeView = new System.Windows.Forms.TreeView();
            this.videoListBox = new System.Windows.Forms.ListBox();
            this.videoListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nameAscendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameDescendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeAscendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeDescendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.searchCoverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortActressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genreGroupBox = new System.Windows.Forms.GroupBox();
            this.avStudioTabPage = new System.Windows.Forms.TabPage();
            this.studioDataGridView = new System.Windows.Forms.DataGridView();
            this.avActressTabPage = new System.Windows.Forms.TabPage();
            this.actressDataGridView = new System.Windows.Forms.DataGridView();
            this.avVideoTabPage = new System.Windows.Forms.TabPage();
            this.videoDataGridView = new System.Windows.Forms.DataGridView();
            this.avGenreTabPage = new System.Windows.Forms.TabPage();
            this.exportGenreButton = new System.Windows.Forms.Button();
            this.updateGenreButton = new System.Windows.Forms.Button();
            this.genreDataGridView = new System.Windows.Forms.DataGridView();
            this.rootDriveGroupBox = new System.Windows.Forms.GroupBox();
            this.rootDriveButton = new System.Windows.Forms.Button();
            this.rootDriveTextBox = new System.Windows.Forms.TextBox();
            this.avMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openActresscsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avActresscsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avStudiocsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avVideocsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabImageList = new System.Windows.Forms.ImageList(this.components);
            this.coverPictureBox = new System.Windows.Forms.PictureBox();
            this.thumbnailBrowser = new System.Windows.Forms.FlowLayoutPanel();
            this.avTabControl.SuspendLayout();
            this.downloadTabPage.SuspendLayout();
            this.dowloadGroupBox.SuspendLayout();
            this.actressModeTabPage.SuspendLayout();
            this.actressModeGroupBox.SuspendLayout();
            this.videoModeTabPage.SuspendLayout();
            this.videoModeGroupBox.SuspendLayout();
            this.videoListContextMenuStrip.SuspendLayout();
            this.avStudioTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studioDataGridView)).BeginInit();
            this.avActressTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actressDataGridView)).BeginInit();
            this.avVideoTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoDataGridView)).BeginInit();
            this.avGenreTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genreDataGridView)).BeginInit();
            this.rootDriveGroupBox.SuspendLayout();
            this.avMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coverPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // avTabControl
            // 
            this.avTabControl.Controls.Add(this.downloadTabPage);
            this.avTabControl.Controls.Add(this.actressModeTabPage);
            this.avTabControl.Controls.Add(this.videoModeTabPage);
            this.avTabControl.Controls.Add(this.avStudioTabPage);
            this.avTabControl.Controls.Add(this.avActressTabPage);
            this.avTabControl.Controls.Add(this.avVideoTabPage);
            this.avTabControl.Controls.Add(this.avGenreTabPage);
            this.avTabControl.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avTabControl.ItemSize = new System.Drawing.Size(120, 24);
            this.avTabControl.Location = new System.Drawing.Point(12, 104);
            this.avTabControl.Name = "avTabControl";
            this.avTabControl.SelectedIndex = 0;
            this.avTabControl.Size = new System.Drawing.Size(604, 470);
            this.avTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.avTabControl.TabIndex = 10;
            this.avTabControl.SelectedIndexChanged += new System.EventHandler(this.avTabControl_SelectedIndexChanged);
            // 
            // downloadTabPage
            // 
            this.downloadTabPage.Controls.Add(this.dowloadGroupBox);
            this.downloadTabPage.ImageIndex = 0;
            this.downloadTabPage.Location = new System.Drawing.Point(4, 28);
            this.downloadTabPage.Name = "downloadTabPage";
            this.downloadTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.downloadTabPage.Size = new System.Drawing.Size(596, 438);
            this.downloadTabPage.TabIndex = 0;
            this.downloadTabPage.Text = "Download";
            this.downloadTabPage.UseVisualStyleBackColor = true;
            // 
            // dowloadGroupBox
            // 
            this.dowloadGroupBox.Controls.Add(this.wgetLinks);
            this.dowloadGroupBox.Controls.Add(this.infoTextBox);
            this.dowloadGroupBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.dowloadGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dowloadGroupBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dowloadGroupBox.Location = new System.Drawing.Point(6, 6);
            this.dowloadGroupBox.Name = "dowloadGroupBox";
            this.dowloadGroupBox.Size = new System.Drawing.Size(584, 426);
            this.dowloadGroupBox.TabIndex = 2;
            this.dowloadGroupBox.TabStop = false;
            this.dowloadGroupBox.Text = "Setting";
            // 
            // wgetLinks
            // 
            this.wgetLinks.Location = new System.Drawing.Point(6, 193);
            this.wgetLinks.Multiline = true;
            this.wgetLinks.Name = "wgetLinks";
            this.wgetLinks.Size = new System.Drawing.Size(572, 227);
            this.wgetLinks.TabIndex = 1;
            // 
            // infoTextBox
            // 
            this.infoTextBox.Location = new System.Drawing.Point(6, 26);
            this.infoTextBox.Multiline = true;
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.Size = new System.Drawing.Size(572, 161);
            this.infoTextBox.TabIndex = 0;
            // 
            // actressModeTabPage
            // 
            this.actressModeTabPage.Controls.Add(this.actressModeGroupBox);
            this.actressModeTabPage.ImageIndex = 2;
            this.actressModeTabPage.Location = new System.Drawing.Point(4, 28);
            this.actressModeTabPage.Name = "actressModeTabPage";
            this.actressModeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.actressModeTabPage.Size = new System.Drawing.Size(596, 438);
            this.actressModeTabPage.TabIndex = 3;
            this.actressModeTabPage.Text = "Actress Mode";
            this.actressModeTabPage.UseVisualStyleBackColor = true;
            // 
            // actressModeGroupBox
            // 
            this.actressModeGroupBox.Controls.Add(this.rankCheckedListBox);
            this.actressModeGroupBox.Controls.Add(this.VideoNumActressMode);
            this.actressModeGroupBox.Controls.Add(this.actressVideoLabel);
            this.actressModeGroupBox.Controls.Add(this.actressNameLabel);
            this.actressModeGroupBox.Controls.Add(this.actressListBox);
            this.actressModeGroupBox.Controls.Add(this.actressVideoTreeView);
            this.actressModeGroupBox.Controls.Add(this.rankGroupBox);
            this.actressModeGroupBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.actressModeGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.actressModeGroupBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actressModeGroupBox.Location = new System.Drawing.Point(6, 6);
            this.actressModeGroupBox.Name = "actressModeGroupBox";
            this.actressModeGroupBox.Size = new System.Drawing.Size(584, 426);
            this.actressModeGroupBox.TabIndex = 6;
            this.actressModeGroupBox.TabStop = false;
            this.actressModeGroupBox.Text = "Setting";
            // 
            // rankCheckedListBox
            // 
            this.rankCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rankCheckedListBox.CheckOnClick = true;
            this.rankCheckedListBox.FormattingEnabled = true;
            this.rankCheckedListBox.Items.AddRange(new object[] {
            "10",
            "9",
            "8",
            "7",
            "6",
            "5",
            "-1"});
            this.rankCheckedListBox.Location = new System.Drawing.Point(243, 57);
            this.rankCheckedListBox.Name = "rankCheckedListBox";
            this.rankCheckedListBox.Size = new System.Drawing.Size(102, 154);
            this.rankCheckedListBox.TabIndex = 6;
            this.rankCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.rankCheckedListBox_ItemCheck);
            // 
            // VideoNumActressMode
            // 
            this.VideoNumActressMode.Location = new System.Drawing.Point(495, 17);
            this.VideoNumActressMode.Name = "VideoNumActressMode";
            this.VideoNumActressMode.ReadOnly = true;
            this.VideoNumActressMode.Size = new System.Drawing.Size(80, 27);
            this.VideoNumActressMode.TabIndex = 8;
            // 
            // actressVideoLabel
            // 
            this.actressVideoLabel.AutoSize = true;
            this.actressVideoLabel.Location = new System.Drawing.Point(349, 25);
            this.actressVideoLabel.Name = "actressVideoLabel";
            this.actressVideoLabel.Size = new System.Drawing.Size(98, 19);
            this.actressVideoLabel.TabIndex = 2;
            this.actressVideoLabel.Text = "Actress Video";
            // 
            // actressNameLabel
            // 
            this.actressNameLabel.AutoSize = true;
            this.actressNameLabel.Location = new System.Drawing.Point(6, 28);
            this.actressNameLabel.Name = "actressNameLabel";
            this.actressNameLabel.Size = new System.Drawing.Size(99, 19);
            this.actressNameLabel.TabIndex = 2;
            this.actressNameLabel.Text = "Actress Name";
            // 
            // actressListBox
            // 
            this.actressListBox.FormattingEnabled = true;
            this.actressListBox.ItemHeight = 19;
            this.actressListBox.Location = new System.Drawing.Point(6, 47);
            this.actressListBox.Name = "actressListBox";
            this.actressListBox.Size = new System.Drawing.Size(222, 365);
            this.actressListBox.TabIndex = 2;
            this.actressListBox.SelectedIndexChanged += new System.EventHandler(this.actressListBox_SelectedIndexChanged);
            // 
            // actressVideoTreeView
            // 
            this.actressVideoTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.actressVideoTreeView.Location = new System.Drawing.Point(353, 47);
            this.actressVideoTreeView.Name = "actressVideoTreeView";
            this.actressVideoTreeView.ShowLines = false;
            this.actressVideoTreeView.Size = new System.Drawing.Size(222, 365);
            this.actressVideoTreeView.TabIndex = 3;
            // 
            // rankGroupBox
            // 
            this.rankGroupBox.Location = new System.Drawing.Point(234, 37);
            this.rankGroupBox.Name = "rankGroupBox";
            this.rankGroupBox.Size = new System.Drawing.Size(114, 375);
            this.rankGroupBox.TabIndex = 17;
            this.rankGroupBox.TabStop = false;
            this.rankGroupBox.Text = "Rank";
            // 
            // videoModeTabPage
            // 
            this.videoModeTabPage.Controls.Add(this.videoModeGroupBox);
            this.videoModeTabPage.ImageIndex = 3;
            this.videoModeTabPage.Location = new System.Drawing.Point(4, 28);
            this.videoModeTabPage.Name = "videoModeTabPage";
            this.videoModeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.videoModeTabPage.Size = new System.Drawing.Size(596, 438);
            this.videoModeTabPage.TabIndex = 4;
            this.videoModeTabPage.Text = "Video Mode";
            this.videoModeTabPage.UseVisualStyleBackColor = true;
            // 
            // videoModeGroupBox
            // 
            this.videoModeGroupBox.Controls.Add(this.genreCheckedListBox);
            this.videoModeGroupBox.Controls.Add(this.numOfFile);
            this.videoModeGroupBox.Controls.Add(this.fileSize);
            this.videoModeGroupBox.Controls.Add(this.vidoFileLabel);
            this.videoModeGroupBox.Controls.Add(this.vidoListLabel);
            this.videoModeGroupBox.Controls.Add(this.videoFileTreeView);
            this.videoModeGroupBox.Controls.Add(this.videoListBox);
            this.videoModeGroupBox.Controls.Add(this.genreGroupBox);
            this.videoModeGroupBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.videoModeGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoModeGroupBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoModeGroupBox.Location = new System.Drawing.Point(6, 6);
            this.videoModeGroupBox.Name = "videoModeGroupBox";
            this.videoModeGroupBox.Size = new System.Drawing.Size(584, 426);
            this.videoModeGroupBox.TabIndex = 8;
            this.videoModeGroupBox.TabStop = false;
            this.videoModeGroupBox.Text = "Setting";
            // 
            // genreCheckedListBox
            // 
            this.genreCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.genreCheckedListBox.CheckOnClick = true;
            this.genreCheckedListBox.FormattingEnabled = true;
            this.genreCheckedListBox.Items.AddRange(new object[] {
            "Bondage",
            "Classic",
            "Clothed",
            "Cosplay",
            "Creampie",
            "Fetish",
            "Gangbang",
            "Lingerie",
            "RaceQueen",
            "Reserved"});
            this.genreCheckedListBox.Location = new System.Drawing.Point(243, 57);
            this.genreCheckedListBox.Name = "genreCheckedListBox";
            this.genreCheckedListBox.Size = new System.Drawing.Size(99, 220);
            this.genreCheckedListBox.TabIndex = 15;
            this.genreCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.genreCheckedListBox_ItemCheck);
            // 
            // numOfFile
            // 
            this.numOfFile.Location = new System.Drawing.Point(148, 17);
            this.numOfFile.Name = "numOfFile";
            this.numOfFile.ReadOnly = true;
            this.numOfFile.Size = new System.Drawing.Size(80, 27);
            this.numOfFile.TabIndex = 7;
            // 
            // fileSize
            // 
            this.fileSize.Location = new System.Drawing.Point(498, 17);
            this.fileSize.Name = "fileSize";
            this.fileSize.ReadOnly = true;
            this.fileSize.Size = new System.Drawing.Size(80, 27);
            this.fileSize.TabIndex = 7;
            // 
            // vidoFileLabel
            // 
            this.vidoFileLabel.AutoSize = true;
            this.vidoFileLabel.Location = new System.Drawing.Point(354, 25);
            this.vidoFileLabel.Name = "vidoFileLabel";
            this.vidoFileLabel.Size = new System.Drawing.Size(73, 19);
            this.vidoFileLabel.TabIndex = 6;
            this.vidoFileLabel.Text = "Video File";
            // 
            // vidoListLabel
            // 
            this.vidoListLabel.AutoSize = true;
            this.vidoListLabel.Location = new System.Drawing.Point(2, 25);
            this.vidoListLabel.Name = "vidoListLabel";
            this.vidoListLabel.Size = new System.Drawing.Size(73, 19);
            this.vidoListLabel.TabIndex = 5;
            this.vidoListLabel.Text = "Video List";
            // 
            // videoFileTreeView
            // 
            this.videoFileTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.videoFileTreeView.Location = new System.Drawing.Point(356, 47);
            this.videoFileTreeView.Name = "videoFileTreeView";
            this.videoFileTreeView.ShowLines = false;
            this.videoFileTreeView.Size = new System.Drawing.Size(222, 365);
            this.videoFileTreeView.TabIndex = 4;
            this.videoFileTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.videoFileTreeView_NodeMouseClick);
            this.videoFileTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.videoFileTreeView_NodeMouseDoubleClick);
            // 
            // videoListBox
            // 
            this.videoListBox.ContextMenuStrip = this.videoListContextMenuStrip;
            this.videoListBox.FormattingEnabled = true;
            this.videoListBox.ItemHeight = 19;
            this.videoListBox.Location = new System.Drawing.Point(6, 47);
            this.videoListBox.Name = "videoListBox";
            this.videoListBox.Size = new System.Drawing.Size(222, 365);
            this.videoListBox.TabIndex = 3;
            this.videoListBox.SelectedIndexChanged += new System.EventHandler(this.videoListBox_SelectedIndexChanged);
            this.videoListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.videoListBox_MouseDoubleClick);
            this.videoListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.videoListBox_MouseDown);
            // 
            // videoListContextMenuStrip
            // 
            this.videoListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameAscendingToolStripMenuItem,
            this.nameDescendingToolStripMenuItem,
            this.timeAscendingToolStripMenuItem,
            this.timeDescendingToolStripMenuItem,
            this.toolStripSeparator1,
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.searchCoverToolStripMenuItem,
            this.sortActressToolStripMenuItem});
            this.videoListContextMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.videoListContextMenuStrip.Name = "contextMenuStrip1";
            this.videoListContextMenuStrip.Size = new System.Drawing.Size(225, 192);
            // 
            // nameAscendingToolStripMenuItem
            // 
            this.nameAscendingToolStripMenuItem.Name = "nameAscendingToolStripMenuItem";
            this.nameAscendingToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.nameAscendingToolStripMenuItem.Text = "Sort by Name Ascending";
            this.nameAscendingToolStripMenuItem.Click += new System.EventHandler(this.nameAscendingToolStripMenuItem_Click);
            // 
            // nameDescendingToolStripMenuItem
            // 
            this.nameDescendingToolStripMenuItem.Name = "nameDescendingToolStripMenuItem";
            this.nameDescendingToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.nameDescendingToolStripMenuItem.Text = "Sort by Name Descending";
            this.nameDescendingToolStripMenuItem.Click += new System.EventHandler(this.nameDescendingToolStripMenuItem_Click);
            // 
            // timeAscendingToolStripMenuItem
            // 
            this.timeAscendingToolStripMenuItem.Name = "timeAscendingToolStripMenuItem";
            this.timeAscendingToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.timeAscendingToolStripMenuItem.Text = "Sort by Time Ascending";
            this.timeAscendingToolStripMenuItem.Click += new System.EventHandler(this.timeAscendingToolStripMenuItem_Click);
            // 
            // timeDescendingToolStripMenuItem
            // 
            this.timeDescendingToolStripMenuItem.Name = "timeDescendingToolStripMenuItem";
            this.timeDescendingToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.timeDescendingToolStripMenuItem.Text = "Sort by Time Descending";
            this.timeDescendingToolStripMenuItem.Click += new System.EventHandler(this.timeDescendingToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // searchCoverToolStripMenuItem
            // 
            this.searchCoverToolStripMenuItem.Name = "searchCoverToolStripMenuItem";
            this.searchCoverToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.searchCoverToolStripMenuItem.Text = "Search Cover";
            this.searchCoverToolStripMenuItem.Click += new System.EventHandler(this.searchCoverToolStripMenuItem_Click);
            // 
            // sortActressToolStripMenuItem
            // 
            this.sortActressToolStripMenuItem.Name = "sortActressToolStripMenuItem";
            this.sortActressToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.sortActressToolStripMenuItem.Text = "Sort Actress";
            this.sortActressToolStripMenuItem.Click += new System.EventHandler(this.sortActressToolStripMenuItem_Click);
            // 
            // genreGroupBox
            // 
            this.genreGroupBox.Location = new System.Drawing.Point(234, 37);
            this.genreGroupBox.Name = "genreGroupBox";
            this.genreGroupBox.Size = new System.Drawing.Size(114, 375);
            this.genreGroupBox.TabIndex = 16;
            this.genreGroupBox.TabStop = false;
            this.genreGroupBox.Text = "Genre";
            // 
            // avStudioTabPage
            // 
            this.avStudioTabPage.Controls.Add(this.studioDataGridView);
            this.avStudioTabPage.Location = new System.Drawing.Point(4, 28);
            this.avStudioTabPage.Name = "avStudioTabPage";
            this.avStudioTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.avStudioTabPage.Size = new System.Drawing.Size(596, 438);
            this.avStudioTabPage.TabIndex = 1;
            this.avStudioTabPage.Text = "AV Sudio";
            this.avStudioTabPage.UseVisualStyleBackColor = true;
            // 
            // studioDataGridView
            // 
            this.studioDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studioDataGridView.Location = new System.Drawing.Point(3, 3);
            this.studioDataGridView.Name = "studioDataGridView";
            this.studioDataGridView.RowTemplate.Height = 24;
            this.studioDataGridView.Size = new System.Drawing.Size(590, 426);
            this.studioDataGridView.TabIndex = 0;
            // 
            // avActressTabPage
            // 
            this.avActressTabPage.Controls.Add(this.actressDataGridView);
            this.avActressTabPage.Location = new System.Drawing.Point(4, 28);
            this.avActressTabPage.Name = "avActressTabPage";
            this.avActressTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.avActressTabPage.Size = new System.Drawing.Size(596, 438);
            this.avActressTabPage.TabIndex = 2;
            this.avActressTabPage.Text = "AV Actress";
            this.avActressTabPage.UseVisualStyleBackColor = true;
            // 
            // actressDataGridView
            // 
            this.actressDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.actressDataGridView.Location = new System.Drawing.Point(3, 3);
            this.actressDataGridView.Name = "actressDataGridView";
            this.actressDataGridView.RowTemplate.Height = 24;
            this.actressDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.actressDataGridView.Size = new System.Drawing.Size(590, 426);
            this.actressDataGridView.TabIndex = 1;
            // 
            // avVideoTabPage
            // 
            this.avVideoTabPage.Controls.Add(this.videoDataGridView);
            this.avVideoTabPage.Location = new System.Drawing.Point(4, 28);
            this.avVideoTabPage.Name = "avVideoTabPage";
            this.avVideoTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.avVideoTabPage.Size = new System.Drawing.Size(596, 438);
            this.avVideoTabPage.TabIndex = 6;
            this.avVideoTabPage.Text = "AV Video";
            this.avVideoTabPage.UseVisualStyleBackColor = true;
            // 
            // videoDataGridView
            // 
            this.videoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.videoDataGridView.Location = new System.Drawing.Point(3, 3);
            this.videoDataGridView.Name = "videoDataGridView";
            this.videoDataGridView.RowTemplate.Height = 24;
            this.videoDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.videoDataGridView.Size = new System.Drawing.Size(590, 426);
            this.videoDataGridView.TabIndex = 2;
            // 
            // avGenreTabPage
            // 
            this.avGenreTabPage.Controls.Add(this.exportGenreButton);
            this.avGenreTabPage.Controls.Add(this.updateGenreButton);
            this.avGenreTabPage.Controls.Add(this.genreDataGridView);
            this.avGenreTabPage.Location = new System.Drawing.Point(4, 28);
            this.avGenreTabPage.Name = "avGenreTabPage";
            this.avGenreTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.avGenreTabPage.Size = new System.Drawing.Size(596, 438);
            this.avGenreTabPage.TabIndex = 7;
            this.avGenreTabPage.Text = "AV Genre";
            this.avGenreTabPage.UseVisualStyleBackColor = true;
            // 
            // exportGenreButton
            // 
            this.exportGenreButton.Location = new System.Drawing.Point(406, 379);
            this.exportGenreButton.Name = "exportGenreButton";
            this.exportGenreButton.Size = new System.Drawing.Size(168, 38);
            this.exportGenreButton.TabIndex = 15;
            this.exportGenreButton.Text = "Export Genre";
            this.exportGenreButton.UseVisualStyleBackColor = true;
            this.exportGenreButton.Click += new System.EventHandler(this.exportGenreButton_Click);
            // 
            // updateGenreButton
            // 
            this.updateGenreButton.Location = new System.Drawing.Point(220, 379);
            this.updateGenreButton.Name = "updateGenreButton";
            this.updateGenreButton.Size = new System.Drawing.Size(171, 38);
            this.updateGenreButton.TabIndex = 16;
            this.updateGenreButton.Text = "Update Genre";
            this.updateGenreButton.UseVisualStyleBackColor = true;
            this.updateGenreButton.Click += new System.EventHandler(this.updateGenreButton_Click);
            // 
            // genreDataGridView
            // 
            this.genreDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.genreDataGridView.Location = new System.Drawing.Point(3, 3);
            this.genreDataGridView.Name = "genreDataGridView";
            this.genreDataGridView.RowTemplate.Height = 24;
            this.genreDataGridView.Size = new System.Drawing.Size(590, 426);
            this.genreDataGridView.TabIndex = 3;
            // 
            // rootDriveGroupBox
            // 
            this.rootDriveGroupBox.Controls.Add(this.rootDriveButton);
            this.rootDriveGroupBox.Controls.Add(this.rootDriveTextBox);
            this.rootDriveGroupBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rootDriveGroupBox.Location = new System.Drawing.Point(12, 27);
            this.rootDriveGroupBox.Name = "rootDriveGroupBox";
            this.rootDriveGroupBox.Size = new System.Drawing.Size(604, 71);
            this.rootDriveGroupBox.TabIndex = 11;
            this.rootDriveGroupBox.TabStop = false;
            this.rootDriveGroupBox.Text = "Root Drive";
            // 
            // rootDriveButton
            // 
            this.rootDriveButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rootDriveButton.Location = new System.Drawing.Point(490, 25);
            this.rootDriveButton.Name = "rootDriveButton";
            this.rootDriveButton.Size = new System.Drawing.Size(107, 27);
            this.rootDriveButton.TabIndex = 2;
            this.rootDriveButton.Text = "Browse...";
            this.rootDriveButton.UseVisualStyleBackColor = true;
            // 
            // rootDriveTextBox
            // 
            this.rootDriveTextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rootDriveTextBox.Location = new System.Drawing.Point(6, 26);
            this.rootDriveTextBox.Name = "rootDriveTextBox";
            this.rootDriveTextBox.Size = new System.Drawing.Size(475, 27);
            this.rootDriveTextBox.TabIndex = 3;
            // 
            // avMenuStrip
            // 
            this.avMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.avMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.avMenuStrip.Name = "avMenuStrip";
            this.avMenuStrip.Size = new System.Drawing.Size(1460, 24);
            this.avMenuStrip.TabIndex = 13;
            this.avMenuStrip.Text = "avMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openActresscsvToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openActresscsvToolStripMenuItem
            // 
            this.openActresscsvToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.avActresscsvToolStripMenuItem,
            this.avStudiocsvToolStripMenuItem,
            this.avVideocsvToolStripMenuItem});
            this.openActresscsvToolStripMenuItem.Name = "openActresscsvToolStripMenuItem";
            this.openActresscsvToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.openActresscsvToolStripMenuItem.Text = "Open";
            // 
            // avActresscsvToolStripMenuItem
            // 
            this.avActresscsvToolStripMenuItem.Name = "avActresscsvToolStripMenuItem";
            this.avActresscsvToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.avActresscsvToolStripMenuItem.Text = "AV_Actress.csv";
            // 
            // avStudiocsvToolStripMenuItem
            // 
            this.avStudiocsvToolStripMenuItem.Name = "avStudiocsvToolStripMenuItem";
            this.avStudiocsvToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.avStudiocsvToolStripMenuItem.Text = "AV_Studio.csv";
            // 
            // avVideocsvToolStripMenuItem
            // 
            this.avVideocsvToolStripMenuItem.Name = "avVideocsvToolStripMenuItem";
            this.avVideocsvToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.avVideocsvToolStripMenuItem.Text = "AV_Video.csv";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genreToolStripMenuItem,
            this.reloadToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.optionsToolStripMenuItem.Text = "Edit";
            // 
            // genreToolStripMenuItem
            // 
            this.genreToolStripMenuItem.Name = "genreToolStripMenuItem";
            this.genreToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.genreToolStripMenuItem.Text = "Genre.csv";
            this.genreToolStripMenuItem.Click += new System.EventHandler(this.genreToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // tabImageList
            // 
            this.tabImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tabImageList.ImageStream")));
            this.tabImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.tabImageList.Images.SetKeyName(0, "Automatic Download.png");
            this.tabImageList.Images.SetKeyName(1, "Manual Download.png");
            this.tabImageList.Images.SetKeyName(2, "Actress Mode.png");
            this.tabImageList.Images.SetKeyName(3, "Video Mode.png");
            // 
            // coverPictureBox
            // 
            this.coverPictureBox.Location = new System.Drawing.Point(622, 33);
            this.coverPictureBox.Name = "coverPictureBox";
            this.coverPictureBox.Size = new System.Drawing.Size(826, 586);
            this.coverPictureBox.TabIndex = 16;
            this.coverPictureBox.TabStop = false;
            // 
            // thumbnailBrowser
            // 
            this.thumbnailBrowser.AutoScroll = true;
            this.thumbnailBrowser.Location = new System.Drawing.Point(622, 33);
            this.thumbnailBrowser.Name = "thumbnailBrowser";
            this.thumbnailBrowser.Size = new System.Drawing.Size(838, 541);
            this.thumbnailBrowser.TabIndex = 17;
            this.thumbnailBrowser.MouseHover += new System.EventHandler(this.thumbnailBrowser_MouseHover);
            // 
            // AV_Assistant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 582);
            this.Controls.Add(this.rootDriveGroupBox);
            this.Controls.Add(this.avMenuStrip);
            this.Controls.Add(this.avTabControl);
            this.Controls.Add(this.coverPictureBox);
            this.Controls.Add(this.thumbnailBrowser);
            this.Name = "AV_Assistant";
            this.Text = "AV";
            this.avTabControl.ResumeLayout(false);
            this.downloadTabPage.ResumeLayout(false);
            this.dowloadGroupBox.ResumeLayout(false);
            this.dowloadGroupBox.PerformLayout();
            this.actressModeTabPage.ResumeLayout(false);
            this.actressModeGroupBox.ResumeLayout(false);
            this.actressModeGroupBox.PerformLayout();
            this.videoModeTabPage.ResumeLayout(false);
            this.videoModeGroupBox.ResumeLayout(false);
            this.videoModeGroupBox.PerformLayout();
            this.videoListContextMenuStrip.ResumeLayout(false);
            this.avStudioTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.studioDataGridView)).EndInit();
            this.avActressTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.actressDataGridView)).EndInit();
            this.avVideoTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.videoDataGridView)).EndInit();
            this.avGenreTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.genreDataGridView)).EndInit();
            this.rootDriveGroupBox.ResumeLayout(false);
            this.rootDriveGroupBox.PerformLayout();
            this.avMenuStrip.ResumeLayout(false);
            this.avMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coverPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl avTabControl;
        private System.Windows.Forms.TabPage downloadTabPage;
        private System.Windows.Forms.GroupBox dowloadGroupBox;
        private System.Windows.Forms.TextBox wgetLinks;
        private System.Windows.Forms.TextBox infoTextBox;
        private System.Windows.Forms.TabPage actressModeTabPage;
        private System.Windows.Forms.GroupBox actressModeGroupBox;
        public System.Windows.Forms.TextBox VideoNumActressMode;
        private System.Windows.Forms.CheckedListBox rankCheckedListBox;
        private System.Windows.Forms.Label actressVideoLabel;
        private System.Windows.Forms.Label actressNameLabel;
        public System.Windows.Forms.ListBox actressListBox;
        public System.Windows.Forms.TreeView actressVideoTreeView;
        private System.Windows.Forms.TabPage videoModeTabPage;
        private System.Windows.Forms.GroupBox videoModeGroupBox;
        public System.Windows.Forms.TextBox numOfFile;
        public System.Windows.Forms.TextBox fileSize;
        private System.Windows.Forms.Label vidoListLabel;
        public System.Windows.Forms.TreeView videoFileTreeView;
        public System.Windows.Forms.ListBox videoListBox;
        private System.Windows.Forms.TabPage avStudioTabPage;
        private System.Windows.Forms.DataGridView studioDataGridView;
        private System.Windows.Forms.TabPage avActressTabPage;
        public System.Windows.Forms.DataGridView actressDataGridView;
        private System.Windows.Forms.TabPage avVideoTabPage;
        public System.Windows.Forms.DataGridView videoDataGridView;
        private System.Windows.Forms.GroupBox rootDriveGroupBox;
        private System.Windows.Forms.TextBox rootDriveTextBox;
        private System.Windows.Forms.ContextMenuStrip videoListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem nameAscendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameDescendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeAscendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeDescendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem searchCoverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortActressToolStripMenuItem;
        private System.Windows.Forms.MenuStrip avMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openActresscsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avActresscsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avStudiocsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avVideocsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ImageList tabImageList;
        private System.Windows.Forms.Button rootDriveButton;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabPage avGenreTabPage;
        public System.Windows.Forms.DataGridView genreDataGridView;
        private System.Windows.Forms.Button exportGenreButton;
        private System.Windows.Forms.Button updateGenreButton;
        private System.Windows.Forms.CheckedListBox genreCheckedListBox;
        private System.Windows.Forms.ToolStripMenuItem genreToolStripMenuItem;
        public System.Windows.Forms.PictureBox coverPictureBox;
        private System.Windows.Forms.FlowLayoutPanel thumbnailBrowser;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.Label vidoFileLabel;
        private System.Windows.Forms.GroupBox genreGroupBox;
        private System.Windows.Forms.GroupBox rankGroupBox;
    }
}

