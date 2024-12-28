using GuildedRose.Model;
using GuildedRose.UI;

namespace GuildedRose
{
    public partial class MainForm : Form
    {
        private List<UserRequestListener> listeners = new ();

        public MainForm(Inventory inventory)
        {
            InitializeComponent();
            var items = new ItemTableModel(textBox1);
            inventory.AddInventoryListener(items);

            AddListener(inventory);
        }

        public void AddListener(UserRequestListener listener)
        {
            listeners.Add(listener);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            listeners.ForEach(listener => listener.AddItemToInventory(itemTextBox.Text));
        }
    }
}
