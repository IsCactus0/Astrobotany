namespace AstrobotanyTools
{
    public partial class Menu : Form
    {
        public int TabCount { get; protected set; } = 0;

        public Menu()
        {
            InitializeComponent();
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(26, 21, 28);
            DoubleBuffered = true;
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createNewChildForm(new ItemEditor());
        }
        private void plantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // createNewChildForm(new PlantEditor());
        }
        private void questToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // createNewChildForm(new QuestEditor());
        }
        private void roomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // createNewChildForm(new RoomEditor());
        }
        private void characterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // createNewChildForm(new CharacterEditor());
        }
        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // createNewChildForm(new TileEditor());
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ChildForm childForm in MdiChildren)
                if (childForm.TabPage.Equals(tabController.SelectedTab))
                    childForm.LoadFile();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ChildForm childForm in MdiChildren)
                if (childForm.TabPage.Equals(tabController.SelectedTab))
                    childForm.SaveFile();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ChildForm childForm in MdiChildren)
                if (childForm.TabPage.Equals(tabController.SelectedTab))
                    childForm.SaveFileAs();
        }
        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ChildForm childForm in MdiChildren)
                childForm.SaveFile();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Save changes before exiting?", "Exit", MessageBoxButtons.YesNoCancel);
            switch (result)
            {
                case DialogResult.Yes:
                    foreach (ChildForm childForm in this.MdiChildren)
                        childForm.SaveFile();
                    Application.Exit();
                    break;
                case DialogResult.No:
                    Application.Exit();
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    break;
            }
        }
        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ChildForm childForm in this.MdiChildren)
                childForm.Close();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void createNewChildForm(ChildForm frmChild)
        {
            TabPage childTab = new TabPage();

            frmChild.MdiParent = this;
            frmChild.Text = "New Item " + TabCount.ToString();
            frmChild.TabCtrl = tabController;

            childTab.Parent = tabController;
            childTab.Text = frmChild.Text;
            childTab.Show();

            frmChild.TabPage = childTab;
            frmChild.Show();
            TabCount++;

            tabController.SelectedTab = childTab;
        }
        private void tabController_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ChildForm childForm in this.MdiChildren)
                if (childForm.TabPage.Equals(tabController.SelectedTab))
                    childForm.Select();
        }
    }
}
