using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class ElectronicProductForm : Form
    {
        public ElectronicProductForm()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            this.BackColor = Color.FromArgb(240, 240, 245);
            this.ForeColor = Color.FromArgb(40, 40, 50);
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }

        private ElectronicProductData electronicProductData = new ElectronicProductData();
        private List<ElectronicProduct> electronicProducts = new List<ElectronicProduct>();
        private BindingSource _src = new BindingSource();

        private void ElectronicForm_Load(object sender, EventArgs e)
        {
            CreateSampleData();

            
        }

        private void CreateSampleData()
        {
            throw new NotImplementedException();
        }
    }
}
