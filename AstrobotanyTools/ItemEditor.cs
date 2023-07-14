using AstrobotanyLibrary.Classes.Enums;
using AstrobotanyLibrary.Classes.Objects.Items;
using AstrobotanyLibrary.Classes.Utility;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace AstrobotanyTools
{
    public partial class ItemEditor : ChildForm
    {
        public ItemEditor()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private string filePath { get; set; }
        private string Title { get; set; }
        private bool Saved { get; set; }
        private Item Item { get; set; }
        private Bitmap Sprite { get; set; }
        private Pen Pen { get; set; }
        public bool Paintbrush { get; set; }

        private void ItemEditor_Load(object sender, EventArgs e)
        {
            Title = Text;
            Item = new Item();
            Saved = true;
            cboItemRarity.DataSource = Enum.GetValues(typeof(ItemCategory));
            cboItemRarity.SelectedItem = ItemCategory.Misc;
            openFileDialog.InitialDirectory = @"D:\Programming\TurnBasedGame\Assets";
            Pen = new Pen(Color.Black, 1);

            Sprite = new Bitmap(16, 16);
        }

        private void pbColourPrimary_Click(object sender, EventArgs e)
        {
            if (colourDialog.ShowDialog() == DialogResult.OK)
            {
                pbColourPrimary.BackColor = colourDialog.Color;
                Pen.Color = pbColourPrimary.BackColor;
            }
        }
        private void pbColourSecondary_Click(object sender, EventArgs e)
        {
            if (colourDialog.ShowDialog() == DialogResult.OK)
            {
                pbColourSecondary.BackColor = colourDialog.Color;
                Pen.Color = pbColourPrimary.BackColor;
            }
        }
        private void lblSwapColours_Click(object sender, EventArgs e)
        {
            Color secondary = pbColourSecondary.BackColor;
            pbColourSecondary.BackColor = pbColourPrimary.BackColor;
            pbColourPrimary.BackColor = secondary;

            Pen.Color = pbColourPrimary.BackColor;
        }

        private void cboItemRarity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemCategory category = (ItemCategory)cboItemRarity.SelectedValue;
            string hexvalue = ((int)category).ToString("X6");
            pbCategoryColour.BackColor = ColorTranslator.FromHtml($"#{hexvalue}");
        }

        public void SetSaved(bool state)
        {
            Saved = state;
            Text = Saved ? Title : Title + "*";
        }
        public override void SaveFile()
        {
            if (string.IsNullOrEmpty(filePath))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Save Item";
                    saveFileDialog.Filter = "Binary File (*.bin)|*.bin";

                    switch (saveFileDialog.ShowDialog())
                    {
                        case DialogResult.OK:
                            filePath = saveFileDialog.FileName;
                            break;
                        default: return;
                    }
                }
            }

            using (Stream stream = File.Open(filePath, FileMode.Create))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, Item);
            }

            SetSaved(true);
        }
        public override void SaveFileAs()
        {
            filePath = string.Empty;
            this.SaveFile();
        }
        public override void LoadFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = filePath;
                openFileDialog.Title = "Open Item";
                openFileDialog.Filter = "Binary File (*.bin)|*.bin";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    using (Stream stream = File.Open(filePath, FileMode.Open))
                    {
                        var binaryFormatter = new BinaryFormatter();
                        Item = (Item)binaryFormatter.Deserialize(stream);
                    }

                    txtName.Text = Item.Name;
                    txtDescription.Text = Item.Description;

                    string imagePath = Path.ChangeExtension(filePath, "png");
                    if (!string.IsNullOrWhiteSpace(imagePath))
                    {
                        Bitmap loadedImage = new Bitmap(imagePath);
                        Bitmap scaledImage = new Bitmap(pbSprite.Width, pbSprite.Height);

                        using (Graphics g = Graphics.FromImage(scaledImage))
                        {
                            g.InterpolationMode = InterpolationMode.NearestNeighbor;
                            g.PixelOffsetMode = PixelOffsetMode.Half;
                            g.DrawImage(loadedImage, new Rectangle(Point.Empty, scaledImage.Size));
                        }

                        pbSprite.Image = scaledImage;
                    }

                    SetSaved(true);
                }
            }
        }

        private void btnBrush_Click(object sender, EventArgs e)
        {
            Paintbrush = true;
        }
        private void btnPencil_Click(object sender, EventArgs e)
        {
            Paintbrush = false;
        }

        private void PaintToSprite(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    using (Graphics graphics = Graphics.FromImage(Sprite))
                    {
                        float brushSize = Math.Clamp((int)((float)nudBrushSize.Value), 1, 8);

                        if (Paintbrush)
                            graphics.FillEllipse(
                                Pen.Brush,
                                (int)Math.Floor(e.X / 30f) - (brushSize / 2),
                                (int)Math.Floor(e.Y / 30f) - (brushSize / 2),
                                brushSize, brushSize);
                        else
                            graphics.FillRectangle(
                                Pen.Brush,
                                (int)Math.Floor(e.X / 30f) - (brushSize / 2),
                                (int)Math.Floor(e.Y / 30f) - (brushSize / 2),
                                brushSize, brushSize);

                        pbSprite.Image = Sprite;
                    }
                    return;
                case MouseButtons.Right:
                    using (Graphics graphics = Graphics.FromImage(Sprite))
                    {
                        Pen eraser = new Pen(Color.Transparent, 1);
                        float brushSize = Math.Clamp((int)((float)nudBrushSize.Value), 1, 8);

                        if (Paintbrush)
                            graphics.FillEllipse(
                                eraser.Brush,
                                (int)Math.Floor(e.X / 30f) - (brushSize / 2),
                                (int)Math.Floor(e.Y / 30f) - (brushSize / 2),
                                brushSize, brushSize);
                        else
                            graphics.FillRectangle(
                                eraser.Brush,
                                (int)Math.Floor(e.X / 30f) - (brushSize / 2),
                                (int)Math.Floor(e.Y / 30f) - (brushSize / 2),
                                brushSize, brushSize);

                        pbSprite.Image = Sprite;
                    }
                    return;
                case MouseButtons.Middle:
                    pbColourPrimary.BackColor = Sprite.GetPixel((int)Math.Floor(e.X / 30f), (int)Math.Floor(e.Y / 30f));
                    return;
                default:
                    return;
            }
        }
        private void pbSprite_MouseMove(object sender, MouseEventArgs e)
        {
            PaintToSprite(sender, e);
        }
        private void pbSprite_MouseClick(object sender, MouseEventArgs e)
        {
            PaintToSprite(sender, e);
        }
    }
}