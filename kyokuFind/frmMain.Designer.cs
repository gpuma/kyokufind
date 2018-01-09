namespace kyokuFind
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lstGenres = new System.Windows.Forms.ListBox();
            this.lstAlbums = new System.Windows.Forms.ListBox();
            this.lstArtists = new System.Windows.Forms.ListBox();
            this.lblSongs = new System.Windows.Forms.Label();
            this.lblArtists = new System.Windows.Forms.Label();
            this.lblAlbums = new System.Windows.Forms.Label();
            this.lblGenres = new System.Windows.Forms.Label();
            this.lstSongs = new System.Windows.Forms.ListBox();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectMusicFolder = new System.Windows.Forms.Button();
            this.lblMusicPath = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(16, 45);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(39, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "search";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(58, 42);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(747, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lstGenres, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lstAlbums, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lstArtists, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSongs, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblArtists, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAlbums, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblGenres, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lstSongs, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 68);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(543, 420);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lstGenres
            // 
            this.lstGenres.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstGenres.FormattingEnabled = true;
            this.lstGenres.Location = new System.Drawing.Point(274, 233);
            this.lstGenres.Name = "lstGenres";
            this.lstGenres.Size = new System.Drawing.Size(266, 173);
            this.lstGenres.TabIndex = 6;
            // 
            // lstAlbums
            // 
            this.lstAlbums.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAlbums.FormattingEnabled = true;
            this.lstAlbums.Location = new System.Drawing.Point(3, 233);
            this.lstAlbums.Name = "lstAlbums";
            this.lstAlbums.Size = new System.Drawing.Size(265, 173);
            this.lstAlbums.TabIndex = 5;
            // 
            // lstArtists
            // 
            this.lstArtists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstArtists.FormattingEnabled = true;
            this.lstArtists.Location = new System.Drawing.Point(274, 23);
            this.lstArtists.Name = "lstArtists";
            this.lstArtists.Size = new System.Drawing.Size(266, 173);
            this.lstArtists.TabIndex = 4;
            this.lstArtists.DoubleClick += new System.EventHandler(this.lstArtists_DoubleClick);
            // 
            // lblSongs
            // 
            this.lblSongs.AutoSize = true;
            this.lblSongs.Location = new System.Drawing.Point(3, 0);
            this.lblSongs.Name = "lblSongs";
            this.lblSongs.Size = new System.Drawing.Size(37, 13);
            this.lblSongs.TabIndex = 0;
            this.lblSongs.Text = "Songs";
            // 
            // lblArtists
            // 
            this.lblArtists.AutoSize = true;
            this.lblArtists.Location = new System.Drawing.Point(274, 0);
            this.lblArtists.Name = "lblArtists";
            this.lblArtists.Size = new System.Drawing.Size(35, 13);
            this.lblArtists.TabIndex = 0;
            this.lblArtists.Text = "Artists";
            // 
            // lblAlbums
            // 
            this.lblAlbums.AutoSize = true;
            this.lblAlbums.Location = new System.Drawing.Point(3, 210);
            this.lblAlbums.Name = "lblAlbums";
            this.lblAlbums.Size = new System.Drawing.Size(41, 13);
            this.lblAlbums.TabIndex = 1;
            this.lblAlbums.Text = "Albums";
            // 
            // lblGenres
            // 
            this.lblGenres.AutoSize = true;
            this.lblGenres.Location = new System.Drawing.Point(274, 210);
            this.lblGenres.Name = "lblGenres";
            this.lblGenres.Size = new System.Drawing.Size(41, 13);
            this.lblGenres.TabIndex = 2;
            this.lblGenres.Text = "Genres";
            // 
            // lstSongs
            // 
            this.lstSongs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSongs.FormattingEnabled = true;
            this.lstSongs.Location = new System.Drawing.Point(3, 23);
            this.lstSongs.Name = "lstSongs";
            this.lstSongs.Size = new System.Drawing.Size(265, 173);
            this.lstSongs.TabIndex = 3;
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.BackColor = System.Drawing.Color.Black;
            this.txtConsole.ForeColor = System.Drawing.Color.White;
            this.txtConsole.Location = new System.Drawing.Point(566, 68);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(235, 420);
            this.txtConsole.TabIndex = 3;
            this.txtConsole.Text = "|";
            // 
            // btnSelectMusicFolder
            // 
            this.btnSelectMusicFolder.Location = new System.Drawing.Point(13, 13);
            this.btnSelectMusicFolder.Name = "btnSelectMusicFolder";
            this.btnSelectMusicFolder.Size = new System.Drawing.Size(113, 23);
            this.btnSelectMusicFolder.TabIndex = 4;
            this.btnSelectMusicFolder.Text = "Select Music Folder";
            this.btnSelectMusicFolder.UseVisualStyleBackColor = true;
            this.btnSelectMusicFolder.Click += new System.EventHandler(this.btnSelectMusicFolder_Click);
            // 
            // lblMusicPath
            // 
            this.lblMusicPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMusicPath.AutoSize = true;
            this.lblMusicPath.Location = new System.Drawing.Point(132, 18);
            this.lblMusicPath.Name = "lblMusicPath";
            this.lblMusicPath.Size = new System.Drawing.Size(93, 13);
            this.lblMusicPath.TabIndex = 5;
            this.lblMusicPath.Text = "No folder selected";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 500);
            this.Controls.Add(this.lblMusicPath);
            this.Controls.Add(this.btnSelectMusicFolder);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Name = "frmMain";
            this.Text = "kyokuFind";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lstGenres;
        private System.Windows.Forms.ListBox lstAlbums;
        private System.Windows.Forms.ListBox lstArtists;
        private System.Windows.Forms.Label lblSongs;
        private System.Windows.Forms.Label lblArtists;
        private System.Windows.Forms.Label lblAlbums;
        private System.Windows.Forms.Label lblGenres;
        private System.Windows.Forms.ListBox lstSongs;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnSelectMusicFolder;
        private System.Windows.Forms.Label lblMusicPath;
    }
}

