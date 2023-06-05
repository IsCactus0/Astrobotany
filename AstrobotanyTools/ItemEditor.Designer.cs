namespace AstrobotanyTools
{
    partial class ItemEditor
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
            pbSprite = new SpriteBox();
            txtName = new TextBox();
            lblName = new Label();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblSprite = new Label();
            pbColourPrimary = new PictureBox();
            pbColourSecondary = new PictureBox();
            colourDialog = new ColorDialog();
            lblSwapColours = new Label();
            cboItemRarity = new ComboBox();
            lblItemCategory = new Label();
            pbCategoryColour = new PictureBox();
            openFileDialog = new OpenFileDialog();
            btnLoadImage = new Button();
            nudValue = new NumericUpDown();
            lblValue = new Label();
            label1 = new Label();
            btnPencil = new Button();
            btnBrush = new Button();
            nudBrushSize = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pbSprite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbColourPrimary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbColourSecondary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCategoryColour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudBrushSize).BeginInit();
            SuspendLayout();
            // 
            // pbSprite
            // 
            pbSprite.BackColor = Color.FromArgb(32, 26, 34);
            pbSprite.BorderStyle = BorderStyle.Fixed3D;
            pbSprite.Location = new Point(268, 47);
            pbSprite.Name = "pbSprite";
            pbSprite.Size = new Size(480, 480);
            pbSprite.SizeMode = PictureBoxSizeMode.Zoom;
            pbSprite.TabIndex = 1;
            pbSprite.TabStop = false;
            pbSprite.MouseClick += pbSprite_MouseClick;
            pbSprite.MouseMove += pbSprite_MouseMove;
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(32, 26, 34);
            txtName.BorderStyle = BorderStyle.None;
            txtName.Font = new Font("Monomaniac One", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.ForeColor = Color.White;
            txtName.Location = new Point(12, 47);
            txtName.Name = "txtName";
            txtName.Size = new Size(242, 31);
            txtName.TabIndex = 2;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Monomaniac One", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(12, 9);
            lblName.Name = "lblName";
            lblName.Size = new Size(69, 35);
            lblName.TabIndex = 3;
            lblName.Text = "NAME";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Monomaniac One", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescription.ForeColor = Color.White;
            lblDescription.Location = new Point(12, 81);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(141, 35);
            lblDescription.TabIndex = 5;
            lblDescription.Text = "DESCRIPTION";
            // 
            // txtDescription
            // 
            txtDescription.BackColor = Color.FromArgb(32, 26, 34);
            txtDescription.BorderStyle = BorderStyle.None;
            txtDescription.Font = new Font("Monomaniac One", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtDescription.ForeColor = Color.White;
            txtDescription.Location = new Point(12, 119);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(242, 238);
            txtDescription.TabIndex = 4;
            // 
            // lblSprite
            // 
            lblSprite.AutoSize = true;
            lblSprite.Font = new Font("Monomaniac One", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblSprite.ForeColor = Color.White;
            lblSprite.Location = new Point(268, 9);
            lblSprite.Name = "lblSprite";
            lblSprite.Size = new Size(84, 35);
            lblSprite.TabIndex = 6;
            lblSprite.Text = "SPRITE";
            // 
            // pbColourPrimary
            // 
            pbColourPrimary.BackColor = Color.Black;
            pbColourPrimary.BorderStyle = BorderStyle.Fixed3D;
            pbColourPrimary.Location = new Point(268, 540);
            pbColourPrimary.Name = "pbColourPrimary";
            pbColourPrimary.Size = new Size(48, 48);
            pbColourPrimary.TabIndex = 7;
            pbColourPrimary.TabStop = false;
            pbColourPrimary.Click += pbColourPrimary_Click;
            // 
            // pbColourSecondary
            // 
            pbColourSecondary.BackColor = Color.White;
            pbColourSecondary.BorderStyle = BorderStyle.Fixed3D;
            pbColourSecondary.Location = new Point(292, 564);
            pbColourSecondary.Name = "pbColourSecondary";
            pbColourSecondary.Size = new Size(48, 48);
            pbColourSecondary.TabIndex = 8;
            pbColourSecondary.TabStop = false;
            pbColourSecondary.Click += pbColourSecondary_Click;
            // 
            // colourDialog
            // 
            colourDialog.FullOpen = true;
            // 
            // lblSwapColours
            // 
            lblSwapColours.AutoSize = true;
            lblSwapColours.BackColor = Color.Transparent;
            lblSwapColours.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblSwapColours.ForeColor = SystemColors.Control;
            lblSwapColours.Location = new Point(317, 535);
            lblSwapColours.Name = "lblSwapColours";
            lblSwapColours.Size = new Size(30, 25);
            lblSwapColours.TabIndex = 9;
            lblSwapColours.Text = "⇆";
            lblSwapColours.Click += lblSwapColours_Click;
            // 
            // cboItemRarity
            // 
            cboItemRarity.BackColor = Color.FromArgb(32, 26, 34);
            cboItemRarity.Font = new Font("Monomaniac One", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            cboItemRarity.ForeColor = Color.White;
            cboItemRarity.FormattingEnabled = true;
            cboItemRarity.ImeMode = ImeMode.Disable;
            cboItemRarity.Location = new Point(12, 489);
            cboItemRarity.Name = "cboItemRarity";
            cboItemRarity.Size = new Size(188, 38);
            cboItemRarity.TabIndex = 10;
            cboItemRarity.SelectedIndexChanged += cboItemRarity_SelectedIndexChanged;
            // 
            // lblItemCategory
            // 
            lblItemCategory.AutoSize = true;
            lblItemCategory.Font = new Font("Monomaniac One", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblItemCategory.ForeColor = Color.White;
            lblItemCategory.Location = new Point(12, 451);
            lblItemCategory.Name = "lblItemCategory";
            lblItemCategory.Size = new Size(120, 35);
            lblItemCategory.TabIndex = 11;
            lblItemCategory.Text = "CATEGORY";
            // 
            // pbCategoryColour
            // 
            pbCategoryColour.BackColor = Color.Transparent;
            pbCategoryColour.Location = new Point(216, 489);
            pbCategoryColour.Name = "pbCategoryColour";
            pbCategoryColour.Size = new Size(38, 38);
            pbCategoryColour.TabIndex = 12;
            pbCategoryColour.TabStop = false;
            // 
            // btnLoadImage
            // 
            btnLoadImage.FlatStyle = FlatStyle.Flat;
            btnLoadImage.Font = new Font("Monomaniac One", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnLoadImage.ForeColor = Color.Thistle;
            btnLoadImage.Location = new Point(565, 540);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(183, 72);
            btnLoadImage.TabIndex = 13;
            btnLoadImage.Text = "Load Image";
            btnLoadImage.UseVisualStyleBackColor = true;
            // 
            // nudValue
            // 
            nudValue.BackColor = Color.FromArgb(32, 26, 34);
            nudValue.BorderStyle = BorderStyle.None;
            nudValue.Font = new Font("Monomaniac One", 24F, FontStyle.Regular, GraphicsUnit.Point);
            nudValue.ForeColor = Color.FromArgb(162, 207, 118);
            nudValue.Location = new Point(12, 398);
            nudValue.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudValue.Name = "nudValue";
            nudValue.Size = new Size(242, 50);
            nudValue.TabIndex = 14;
            nudValue.TextAlign = HorizontalAlignment.Center;
            nudValue.ThousandsSeparator = true;
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Font = new Font("Monomaniac One", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblValue.ForeColor = Color.White;
            lblValue.Location = new Point(12, 360);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(86, 35);
            lblValue.TabIndex = 15;
            lblValue.Text = "VALUE:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(444, 535);
            label1.Name = "label1";
            label1.Size = new Size(0, 86);
            label1.TabIndex = 16;
            // 
            // btnPencil
            // 
            btnPencil.Cursor = Cursors.Hand;
            btnPencil.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnPencil.ForeColor = Color.FromArgb(46, 39, 48);
            btnPencil.Location = new Point(419, 540);
            btnPencil.Name = "btnPencil";
            btnPencil.Size = new Size(60, 72);
            btnPencil.TabIndex = 18;
            btnPencil.Text = "✏";
            btnPencil.UseVisualStyleBackColor = true;
            btnPencil.Click += btnPencil_Click;
            // 
            // btnBrush
            // 
            btnBrush.Cursor = Cursors.Hand;
            btnBrush.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnBrush.ForeColor = Color.FromArgb(46, 39, 48);
            btnBrush.Location = new Point(353, 540);
            btnBrush.Name = "btnBrush";
            btnBrush.Size = new Size(60, 72);
            btnBrush.TabIndex = 19;
            btnBrush.Text = "🖌";
            btnBrush.UseVisualStyleBackColor = true;
            btnBrush.Click += btnBrush_Click;
            // 
            // nudBrushSize
            // 
            nudBrushSize.BackColor = Color.FromArgb(32, 26, 34);
            nudBrushSize.Font = new Font("Monomaniac One", 33F, FontStyle.Regular, GraphicsUnit.Point);
            nudBrushSize.ForeColor = Color.White;
            nudBrushSize.Location = new Point(485, 540);
            nudBrushSize.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            nudBrushSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudBrushSize.Name = "nudBrushSize";
            nudBrushSize.Size = new Size(74, 71);
            nudBrushSize.TabIndex = 20;
            nudBrushSize.TextAlign = HorizontalAlignment.Center;
            nudBrushSize.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // ItemEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 39, 48);
            ClientSize = new Size(784, 632);
            Controls.Add(nudBrushSize);
            Controls.Add(btnBrush);
            Controls.Add(btnPencil);
            Controls.Add(label1);
            Controls.Add(lblValue);
            Controls.Add(nudValue);
            Controls.Add(btnLoadImage);
            Controls.Add(pbCategoryColour);
            Controls.Add(lblItemCategory);
            Controls.Add(cboItemRarity);
            Controls.Add(pbColourPrimary);
            Controls.Add(pbColourSecondary);
            Controls.Add(lblSprite);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(pbSprite);
            Controls.Add(lblSwapColours);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ItemEditor";
            StartPosition = FormStartPosition.CenterParent;
            Text = " ";
            Load += ItemEditor_Load;
            ((System.ComponentModel.ISupportInitialize)pbSprite).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbColourPrimary).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbColourSecondary).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCategoryColour).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudBrushSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SpriteBox pbSprite;
        private TextBox txtName;
        private Label lblName;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblSprite;
        private PictureBox pbColourPrimary;
        private PictureBox pbColourSecondary;
        private ColorDialog colourDialog;
        private Label lblSwapColours;
        private ComboBox cboItemRarity;
        private Label lblItemCategory;
        private PictureBox pbCategoryColour;
        private OpenFileDialog openFileDialog;
        private Button btnLoadImage;
        private NumericUpDown nudValue;
        private Label lblValue;
        private Label label1;
        private Button btnPencil;
        private Button btnBrush;
        private NumericUpDown nudBrushSize;
    }
}