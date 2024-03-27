using NorthwindBusiness.Abstract;
using NorthwindBusiness.Concrete;
using NorthwindEntities.Concrete;
using NrthwindDataAccess.Concrete.EntityFramework;
using NrthwindDataAccess.Concrete.NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindWebFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
            IProductService _productService = new ProductManager(new EfProductDal());
            ICategoryService _categoryService = new CategoryManager(new EfCategoryDal());
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";

            cbxCategory2.DataSource = _categoryService.GetAll();
            cbxCategory2.DisplayMember = "CategoryName";
            cbxCategory2.ValueMember = "CategoryId";

            cbxUpdateCategory.DataSource = _categoryService.GetAll();
            cbxUpdateCategory.DisplayMember = "CategoryName";
            cbxUpdateCategory.ValueMember = "CategoryId";
        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch
            {

              
            }
        }

        private void tbxProductName_TextChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(tbxProductName.Text))
            {
                dgwProduct.DataSource = _productService.GetProductsByName(tbxProductName.Text);
            }
            else
            {
                LoadProducts();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productService.Add(new Product()
            {
                CategoryId = Convert.ToInt32(cbxCategory2.SelectedValue),
                ProductName = tbxProductName2.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                QuantityPerUnit = tbxQuantityPerUnit.Text,
                UnitsInStock = Convert.ToInt16(tbxStock.Text)
            });
            LoadProducts();
            MessageBox.Show("Ürün Eklendi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product()
            {
               ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
               ProductName = tbxUpdateProductName.Text,
               CategoryId = Convert.ToInt32(cbxUpdateCategory.SelectedValue),
               UnitsInStock = Convert.ToInt16(tbxUpdateStock.Text),
               UnitPrice = Convert.ToDecimal(tbxUpdateUnitPrice.Text),
               QuantityPerUnit = tbxUpdateQuantityPerUnit.Text,
            });
            LoadProducts();
            MessageBox.Show("Ürün Güncellendi");
        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxUpdateProductName.Text = dgwProduct.CurrentRow.Cells[1].Value.ToString();
            cbxUpdateCategory.SelectedValue = dgwProduct.CurrentRow.Cells[2].Value;
            tbxUpdateUnitPrice.Text = dgwProduct.CurrentRow.Cells[3].Value.ToString();
            tbxUpdateQuantityPerUnit.Text = dgwProduct.CurrentRow.Cells[4].Value.ToString();
            tbxUpdateStock.Text = dgwProduct.CurrentRow.Cells[5].Value.ToString();


        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productService.Delete(new Product
            {
                ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
            MessageBox.Show("Ürün Silindi");
        }
    }
}
