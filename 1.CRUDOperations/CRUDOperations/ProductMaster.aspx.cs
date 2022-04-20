using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CRUDOperations
{
    public partial class ProductMaster : System.Web.UI.Page
    {
        BLL_ProductMaster objBLL_ProductMaster = new BLL_ProductMaster();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearForm();
            }
        }

        void ClearForm()
        {
            hfProductID.Value = string.Empty;
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            btnDelete.Enabled = false;
            btnSave.Text = "Save";
            lblSuccessMessage.Text = string.Empty;
            lblErrorMessage.Text = string.Empty;
            GetProductData();
        }

        void GetProductData()
        {
            try
            {
                DataTable dtProducts = null;
                dtProducts = objBLL_ProductMaster.GetProductData(hfProductID.Value == "" ? 0 : Convert.ToInt16(hfProductID.Value));

                if (dtProducts.Rows.Count > 0)
                {
                    gvProducts.DataSource = dtProducts;
                    gvProducts.DataBind();
                }
                else
                {
                    dtProducts.Rows.Add(dtProducts.NewRow());
                    gvProducts.DataSource = dtProducts;
                    gvProducts.DataBind();
                    gvProducts.Rows[0].Cells.Clear();
                    gvProducts.Rows[0].Cells.Add(new TableCell());
                    gvProducts.Rows[0].Cells[0].ColumnSpan = dtProducts.Columns.Count;
                    gvProducts.Rows[0].Cells[0].Text = "No Data found...!";
                    gvProducts.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Insert_Update();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        //Insert/Update
        private void Insert_Update()
        {
            try
            {
                string result = string.Empty;
                int productid = hfProductID.Value == "" ? 0 : Convert.ToInt16(hfProductID.Value);
                string productcode = txtProductCode.Text.Trim();
                string productname = txtProductName.Text.Trim();
                int qty = Convert.ToInt16(txtQty.Text.Trim());
                decimal price = Convert.ToDecimal(txtPrice.Text.Trim());
                string remarks = txtRemarks.Text.Trim();

                result = objBLL_ProductMaster.Insert_Update_Product(productid, productcode, productname, qty, price, remarks);

                if (result.ToLower().Contains("saved") || result.ToLower().Contains("updated"))
                {             
                    ClearForm();
                    lblSuccessMessage.Text = result;
                }
                else
                {
                    lblErrorMessage.Text = result;
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        //Edit Grid
        protected void gvProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            lblErrorMessage.Text = string.Empty;
            lblSuccessMessage.Text = string.Empty;
            hfProductID.Value = gvProducts.DataKeys[e.NewEditIndex].Value.ToString();
            Edit(Convert.ToInt16(hfProductID.Value));
        }

        private void Edit(int ProductID)
        {
            try
            {
                DataTable dtProducts = null;
                dtProducts = objBLL_ProductMaster.GetProductData(ProductID);

                if (dtProducts.Rows.Count > 0)
                {
                    hfProductID.Value = dtProducts.Rows[0]["ProductID"].ToString();
                    txtProductCode.Text = dtProducts.Rows[0]["ProductCode"].ToString();
                    txtProductName.Text = dtProducts.Rows[0]["ProductName"].ToString();
                    txtQty.Text = dtProducts.Rows[0]["Qty"].ToString();
                    txtPrice.Text = dtProducts.Rows[0]["Price"].ToString();
                    txtRemarks.Text = dtProducts.Rows[0]["Remarks"].ToString();
                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        //Delete
        private void Delete()
        {
            try
            {
                string result = string.Empty;
                int productid = hfProductID.Value == "" ? 0 : Convert.ToInt16(hfProductID.Value);
                
                result = objBLL_ProductMaster.Delete_Product(productid);

                if (result.ToLower().Contains("deleted"))
                {
                    ClearForm();
                    lblSuccessMessage.Text = result;                    
                }
                else
                {
                    lblErrorMessage.Text = result;
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}