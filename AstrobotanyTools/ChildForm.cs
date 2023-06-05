namespace AstrobotanyTools
{
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
        }

        public TabPage TabPage { get; set; }
        public TabControl TabCtrl { get; set; }

        private void ChildForm_Activated(object sender, EventArgs e)
        {
            TabCtrl.SelectedTab = TabPage;
            if (!TabCtrl.Visible)
                TabCtrl.Visible = true;
        }
        private void ChildForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.TabPage.Dispose();
            if (!TabCtrl.HasChildren)
                TabCtrl.Visible = false;
        }

        public virtual void SaveFile()
        {

        }
        public virtual void SaveFileAs()
        {

        }
        public virtual void LoadFile()
        {

        }
    }
}