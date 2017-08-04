using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using CCWin;
using System.Reflection;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using Microsoft.Office.Interop;
using Microsoft.Office.Core;
using Microsoft.Reporting.WinForms;

namespace Device_Management
{
    public partial class main : Skin_VS

    {

        BindingSource bs;
        MyEventArgs receivedata;
        Captchahelper.Captcha temp;
        public main()
        {
            InitializeComponent();
        }
        public void reset_tabpage()
        {
            this.tabPage2.Parent = null;
            this.tabPage3.Parent = null;
            this.tabPage4.Parent = null;
            this.tabPage5.Parent = null;
            this.tabPage6.Parent = null;
            this.tabPage7.Parent = null;
            this.tabPage8.Parent = null;
            this.tabPage9.Parent = null;
            this.tabPage10.Parent = null;
            this.tabPage11.Parent = null;
            this.tabPage12.Parent = null;
            this.tabPage1.Parent = null;
            this.myPage1.Parent = null;
            this.myPage2.Parent = null;
            this.myPage3.Parent = null;
            this.myPage4.Parent = null;
        }
        public void userdata(object sender, MyEventArgs e)
        {
            receivedata = new MyEventArgs();
            receivedata.id = e.id;
            receivedata.privilege = e.privilege;
            receivedata.name = e.name;
        }


        #region   数据报表  
        private List<ReportParameter>report_os()
        {
            DataTable dt1 = helper.ExecuteDataTable("select * from device_sheet where device_state=@state1 or device_state=@state2", new SqlParameter("state1", "outstock"), new SqlParameter("state2", "refund"));
            DataRow dr1 = dt1.Rows[0];
            string tag = "";
            switch (receivedata.privilege)
            {
                case 0:
                    tag = "普通用户";
                    break;
                case 1:
                    tag = "管理员";
                    break;
                case 2:
                    tag = "系统管理员";
                    break;
            }
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            var reportParams = new List<ReportParameter>()
            {
                new ReportParameter("ReportParameter1", dr1["id"].ToString()),
                new ReportParameter("ReportParameter2", receivedata.name),
                new ReportParameter("ReportParameter3", receivedata.id),
                new ReportParameter("ReportParameter4", tag),
                new ReportParameter("ReportParameter5", date),
                new ReportParameter("ReportParameter6", date),
                new ReportParameter("ReportParameter7",  dr1["trans_id"].ToString()),
                new ReportParameter("ReportParameter8",  dr1["trans_name"].ToString()),
            };
            return reportParams;
           }    
        private List<ReportParameter> report_is()
        {
            DataTable dt1 = helper.ExecuteDataTable("select * from device_request_sheet");
            DataRow dr = dt1.Rows[0];
            string tag = "";
            switch (receivedata.privilege)
            {
                case 0:
                    tag = "普通用户";
                    break;
                case 1:
                    tag = "管理员";
                    break;
                case 2:
                    tag = "系统管理员";
                    break;
            }
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            string dt = Convert.ToDateTime(dr["produce_date"]).ToString("yyyy/MM/dd"); 
            var reportParams = new List<ReportParameter>()
            {
                new ReportParameter("ReportParameter1", dr["id"].ToString()),
                new ReportParameter("ReportParameter2", receivedata.name),
                new ReportParameter("ReportParameter3", receivedata.id),
                new ReportParameter("ReportParameter4", tag),
                new ReportParameter("ReportParameter5", date),
                new ReportParameter("ReportParameter6", dt),
                new ReportParameter("ReportParameter7", dr["trans_name"].ToString()),
                new ReportParameter("ReportParameter8", dr["maintain_name"].ToString()),
            };
            return reportParams;
        }
        private DataTable getdt_os()
        {
            DataTable dt = helper.ExecuteDataTable("select * from device_sheet where device_state=@state1 or device_state=@state2", new SqlParameter("state1", "outstock"), new SqlParameter("state2", "refund"));
            DataTable temp = new DataTable();
            temp.Columns.Add("device_id", typeof(string));
            temp.Columns.Add("name", typeof(string));
            temp.Columns.Add("size", typeof(string));
            temp.Columns.Add("brand", typeof(string));
            temp.Columns.Add("sector_id", typeof(string));
            temp.Columns.Add("repair_num", typeof(Int32));         
            temp.Columns.Add("device_lifetime", typeof(Int32));
            temp.Columns.Add("in_date", typeof(string));
            temp.Columns.Add("id", typeof(Int32));
            temp.Columns.Add("trans_id", typeof(string));
            temp.Columns.Add("trans_name", typeof(string));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                DataRow drs = temp.NewRow();
                drs["device_id"] = dr["device_id"].ToString();
                drs["name"] = dr["name"].ToString();
                drs["size"] = dr["size"].ToString();
                drs["brand"] = dr["brand"].ToString();
                drs["sector_id"] = dr["sector_id"].ToString();
                drs["repair_num"] = Convert.ToInt32(dr["repair_num"]);
                drs["device_lifetime"] = Convert.ToInt32(dr["device_lifetime"]);
                drs["in_date"] =Convert.ToDateTime(dr["in_date"]).ToString("yyyy/MM/dd");
                drs["id"] = Convert.ToInt32(dr["id"]);
                drs["trans_id"] = dr["trans_id"].ToString();
                drs["trans_name"] = dr["trans_name"].ToString();
                temp.Rows.Add(drs);
            }
            return temp;
        }
        private DataTable getdt_is()
        {
            DataTable dt = helper.ExecuteDataTable("select * from device_request_sheet");
            DataTable temp = new DataTable();
            temp.Columns.Add("device_id", typeof(string));
            temp.Columns.Add("name", typeof(string));
            temp.Columns.Add("size", typeof(string));
            temp.Columns.Add("brand", typeof(string));
            temp.Columns.Add("cost", typeof(Int32));
            temp.Columns.Add("in_date", typeof(string));
            temp.Columns.Add("produce_date", typeof(string));
            temp.Columns.Add("maintain_id", typeof(string));
            temp.Columns.Add("maintain_name", typeof(string));
            temp.Columns.Add("trans_id", typeof(string));
            temp.Columns.Add("trans_name", typeof(string));
            temp.Columns.Add("sector_id", typeof(string));
            temp.Columns.Add("sector", typeof(string));
            temp.Columns.Add("user_id", typeof(string));
            temp.Columns.Add("user_name", typeof(string));
            temp.Columns.Add("num", typeof(Int32));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                DataRow drs = temp.NewRow();
                drs["device_id"] = dr["device_id"].ToString();
                drs["name"] = dr["name"].ToString();
                drs["size"] = dr["size"].ToString();
                drs["brand"] = dr["brand"].ToString();
                drs["cost"] = Convert.ToInt32(dr["cost"]);
                drs["in_date"] = Convert.ToDateTime(dr["in_date"]).ToString("yyyy/MM/dd");
                drs["produce_date"] = Convert.ToDateTime(dr["produce_date"]).ToString("yyyy/MM/dd");
                drs["maintain_id"] = dr["maintain_id"].ToString();
                drs["maintain_name"] = dr["maintain_name"].ToString();
                drs["trans_id"] = dr["trans_id"].ToString();
                drs["sector_id"] = dr["sector_id"].ToString();
                drs["trans_name"] = dr["trans_name"].ToString();
                drs["sector_id"] = dr["sector_id"].ToString();
                drs["sector"] = dr["sector"].ToString();
                drs["user_id"] = receivedata.id;
                drs["user_id"] = receivedata.name;
                drs["num"] = Convert.ToInt32(dr["num"]);
                temp.Rows.Add(drs);
            }
            return temp;
        }
        public static void altercheader_drs(DataGridView dgv)
        {
            dgv.Columns[0].HeaderCell.Value = "流水编号";
            dgv.Columns[1].HeaderCell.Value = "设备型号";
            dgv.Columns[2].HeaderCell.Value = "设备名称";
            dgv.Columns[3].HeaderCell.Value = "规格";
            dgv.Columns[4].HeaderCell.Value = "品牌";
            dgv.Columns[5].HeaderCell.Value = "花费";
            dgv.Columns[6].HeaderCell.Value = "入库日期";
            dgv.Columns[7].HeaderCell.Value = "生产日期";
            dgv.Columns[8].HeaderCell.Value = "维修编号";
            dgv.Columns[9].HeaderCell.Value = "维修公司";
            dgv.Columns[10].HeaderCell.Value = "物流编号";
            dgv.Columns[11].HeaderCell.Value = "物流公司";
            dgv.Columns[12].HeaderCell.Value = "科室编号";
            dgv.Columns[13].HeaderCell.Value = "订购数量";
            dgv.Columns[14].HeaderCell.Value = "所属科室";
        }
        public static void altercheader_ds(DataGridView dgv)
        {
            dgv.Columns[0].HeaderCell.Value = "流水编号";
            dgv.Columns[1].HeaderCell.Value = "设备型号";
            dgv.Columns[2].HeaderCell.Value = "设备名称";
            dgv.Columns[3].HeaderCell.Value = "规格";
            dgv.Columns[4].HeaderCell.Value = "品牌";
            dgv.Columns[5].HeaderCell.Value = "科室编号";
            dgv.Columns[6].HeaderCell.Value = "修理次数";
            dgv.Columns[7].HeaderCell.Value = "使用年数";
            dgv.Columns[8].HeaderCell.Value = "设备状态";
            dgv.Columns[9].HeaderCell.Value = "备注信息";
            dgv.Columns[10].HeaderCell.Value = "入库日期";
            dgv.Columns[11].HeaderCell.Value = "生产日期";
            dgv.Columns[12].HeaderCell.Value = "物流编号";
            dgv.Columns[13].HeaderCell.Value = "物流公司";
        }
        #endregion
        #region 订购申请
        private void or_tc()
        {
            this.or_did.DataBindings.Add("Text", bs, "device_id", true);
            this.or_name.DataBindings.Add("Text", bs, "name", true);
            this.or_size.DataBindings.Add("Text", bs, "size", true);
            this.or_brand.DataBindings.Add("Text", bs, "brand", true);
            this.or_price.DataBindings.Add("Text", bs, "cost", true);
            this.or_ind.DataBindings.Add("Text", bs, "in_date", true);
            this.or_pd.DataBindings.Add("Text", bs, "produce_date", true);
            this.or_mid.DataBindings.Add("Text", bs, "maintain_id", true);
            this.or_main.DataBindings.Add("Text", bs, "maintain_name", true);
            this.or_tid.DataBindings.Add("Text", bs, "trans_id", true);
            this.or_tran.DataBindings.Add("Text", bs, "trans_name", true);
            this.or_seid.DataBindings.Add("Text", bs, "sector_id", true);
            this.or_num.DataBindings.Add("Text", bs, "num", true);
            this.or_sector.DataBindings.Add("Text", bs, "sector", true);
            this.or_oid.DataBindings.Add("Text", bs, "id", true);
        }
        private void or_clear()
        {
            this.or_did.Text = "";
            this.or_name.Text = "";
            this.or_size.Text = "";
            this.or_brand.Text = "";
            this.or_price.Text = "";
            this.or_ind.Text = "";
            this.or_pd.Text = "";
            this.or_mid.Text = "";
            this.or_main.Text = "";
            this.or_tid.Text = "";
            this.or_tran.Text = "";
            this.or_seid.Text = "";
            this.or_num.Text = "";
            this.or_sector.Text = "";
            this.or_oid.Text = "";
        }
        private void or_ac()
        {
            this.or_did.DataBindings.Clear();
            this.or_name.DataBindings.Clear();
            this.or_size.DataBindings.Clear();
            this.or_brand.DataBindings.Clear();
            this.or_price.DataBindings.Clear();
            this.or_ind.DataBindings.Clear();
            this.or_pd.DataBindings.Clear();
            this.or_mid.DataBindings.Clear();
            this.or_main.DataBindings.Clear();
            this.or_tid.DataBindings.Clear();
            this.or_tran.DataBindings.Clear();
            this.or_seid.DataBindings.Clear();
            this.or_num.DataBindings.Clear();
            this.or_sector.DataBindings.Clear();
            this.or_oid.DataBindings.Clear();

        }
        private void or_search_Click(object sender, EventArgs e)
        {
            or_ac();
            tr_ac();
            rr_ac();
            DataTable dt = helper.ExecuteDataTable("select * from device_request_sheet", new SqlParameter("id", b_uid.Text));
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("不存在申请入库的项");
                this.dg1.DataSource = null;
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = dt;
                this.dg1.DataSource = bs;
                altercheader_drs(dg1);
                or_tc();
            }
        }
        private void or_cancel_Click(object sender, EventArgs e)
        {
            or_ac();
            tr_ac();
            rr_ac();
            helper.ExecuteNonQuery("delete from device_request_sheet where id=@id", new SqlParameter("id", or_oid.Text));
            helper.ExecuteNonQuery("delete from device_user_sheet where device_lsid=@oid", new SqlParameter("oid", or_oid.Text));
            DataTable dt = helper.ExecuteDataTable("select * from device_request_sheet");
            if (dt.Rows.Count <= 0)
            {
                this.dg1.DataSource = null;
                MessageBox.Show("不存在可撤销的项");
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = dt;
                this.dg1.DataSource = bs;
                altercheader_drs(dg1);
                or_tc();
            }

        }
        private void or_submit_Click(object sender, EventArgs e)
        {
            or_ac();
            tr_ac();
            rr_ac();
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            string datetime = DateTime.Now.ToString();
            helper.ExecuteNonQuery("insert into device_request_sheet values (@id,@name,@size,@brand,@cost,@ind,@pd,@mid,@main,@tid,@tran,@seid,@num,@sector)", new SqlParameter("id", or_did.Text), new SqlParameter("name", or_name.Text), new SqlParameter("size", or_size.Text), new SqlParameter("brand", or_brand.Text), new SqlParameter("cost", or_price.Text), new SqlParameter("ind", date), new SqlParameter("pd", or_pd.Text), new SqlParameter("mid", or_mid.Text), new SqlParameter("main", or_main.Text), new SqlParameter("tid", or_tid.Text), new SqlParameter("tran", or_tran.Text), new SqlParameter("seid", or_seid.Text), new SqlParameter("num", or_num.Text), new SqlParameter("sector", or_sector.Text));
            helper.ExecuteNonQuery("insert into device_user_sheet values(@did,@id,@uid,@rs,@seid,@info,@date,@type,@fd)", new SqlParameter("did", or_did.Text), new SqlParameter("id", or_oid.Text), new SqlParameter("uid", receivedata.id), new SqlParameter("rs", "unaudited"), new SqlParameter("seid", or_seid.Text), new SqlParameter("info", ""), new SqlParameter("date", datetime), new SqlParameter("type", "instock"), new SqlParameter("fd", ""));
            DataTable dt = helper.ExecuteDataTable("select * from device_request_sheet");
            bs = new BindingSource();
            bs.DataSource = dt;
            this.dg1.DataSource = bs;
            altercheader_drs(dg1);
            or_tc();
        }
        private void or_report_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            //重置数据源
            reportViewer1.LocalReport.ReportPath = "../../Report_is.rdlc";
            //读取RDLC文件路径
            DataTable dt = getdt_is();
            //数据源数据设定
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);     
            //绑定数据源              
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(report_is());
            reportViewer1.RefreshReport();
            reset_tabpage();
            this.tabcontroll.SelectedTab = this.tabPage12;
            tabPage12.Parent = tabcontroll;
        }
        #endregion
        #region 退货申请
        private void tr_tc()
        {
            this.tr_id.DataBindings.Add("Text", bs, "id", true);
            this.tr_name.DataBindings.Add("Text", bs, "name", true);
            this.tr_sector.DataBindings.Add("Text", bs, "sector_id", true);
            this.tr_lt.DataBindings.Add("Text", bs, "device_lifetime", true);
            this.tr_did.DataBindings.Add("Text", bs, "device_id", true);
            this.tr_size.DataBindings.Add("Text", bs, "size", true);
            this.tr_rt.DataBindings.Add("Text", bs, "repair_num", true);
            this.tr_ind.DataBindings.Add("Text", bs, "in_date", true);
            this.tr_info.DataBindings.Add("Text", bs, "info", true);
            this.tr_tid.DataBindings.Add("Text", bs, "trans_id", true);
            this.tr_tn.DataBindings.Add("Text", bs, "trans_name", true);
        }
        private void tr_clear()
        {
            this.tr_id.Text = "";
            this.tr_name.Text = "";
            this.tr_sector.Text = "";
            this.tr_lt.Text = "";
            this.tr_did.Text = "";
            this.tr_size.Text = "";
            this.tr_rt.Text = "";
            this.tr_ind.Text = "";
            this.tr_info.Text = "";
            this.tr_tid.Text = "";
            this.tr_tn.Text = "";

        }
        private void tr_ac()
        {
            this.tr_id.DataBindings.Clear();
            this.tr_name.DataBindings.Clear();
            this.tr_sector.DataBindings.Clear();
            this.tr_lt.DataBindings.Clear();
            this.tr_did.DataBindings.Clear();
            this.tr_size.DataBindings.Clear();
            this.tr_rt.DataBindings.Clear();
            this.tr_ind.DataBindings.Clear();
            this.tr_info.DataBindings.Clear();
            this.tr_tid.DataBindings.Clear();
            this.tr_tn.DataBindings.Clear();
        }
        private void tr_search_Click(object sender, EventArgs e)
        {
            or_ac();
            tr_ac();
            rr_ac();
            DataTable dt = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "normal"));
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("不存在可申请退货或报废的项");
                this.dg1.DataSource = null;
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = dt;
                this.dg1.DataSource = bs;
                altercheader_ds(dg1);
                tr_tc();
            }
        }

        private void tr_submit_t()
        {
            helper.ExecuteNonQuery("update device_sheet set device_state=@state,trans_id=@tid,trans_name=@tn where id=@id", new SqlParameter("state", "pre_refund"), new SqlParameter("tid", tr_tid.Text),new SqlParameter("tn", tr_tn.Text), new SqlParameter("id", tr_id.Text));
            string date = DateTime.Now.ToString();
            helper.ExecuteNonQuery("insert into device_user_sheet values(@did,@id,@uid,@rs,@seid,@info,@date,@state,@fd)", new SqlParameter("did", tr_did.Text), new SqlParameter("id", tr_id.Text), new SqlParameter("uid", receivedata.id), new SqlParameter("rs", "unaudited"), new SqlParameter("seid", rr_sector.Text), new SqlParameter("info", tr_info.Text), new SqlParameter("date", date), new SqlParameter("state", "refund"), new SqlParameter("fd", ""));
            DataTable dt = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "normal"));
            if (dt.Rows.Count <= 0)
            {
                this.dg1.DataSource = null;
                MessageBox.Show("不存在可申请退货或报废的项");
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = dt;
                this.dg1.DataSource = bs;
                altercheader_ds(dg1);
                tr_tc();
            }
        }
        private void tr_submit_d()
        {
            helper.ExecuteNonQuery("update device_sheet set device_state=@state,trans_id=@tid,trans_name=@tn where id=@id", new SqlParameter("state", "pre_discard"), new SqlParameter("tid", tr_tid.Text), new SqlParameter("tn", tr_tn.Text), new SqlParameter("id", tr_id.Text));
            string date = DateTime.Now.ToString();
            helper.ExecuteNonQuery("insert into device_user_sheet values(@did,@id,@uid,@rs,@seid,@info,@date,@state,@fd)", new SqlParameter("did", tr_did.Text), new SqlParameter("id", tr_id.Text), new SqlParameter("uid", receivedata.id), new SqlParameter("rs", "unaudited"), new SqlParameter("seid", rr_sector.Text), new SqlParameter("info", tr_info.Text), new SqlParameter("date", date), new SqlParameter("state", "discard"), new SqlParameter("fd", ""));
            DataTable dt = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "normal"));
            if (dt.Rows.Count <= 0)
            {
                this.dg1.DataSource = null;
                MessageBox.Show("不存在可申请退货或报废的项");
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = dt;
                this.dg1.DataSource = bs;
                altercheader_ds(dg1);
                tr_tc();
            }
        }
        private void tr_bf_Click(object sender, EventArgs e)
        {
            or_ac();
            tr_ac();
            rr_ac();
            switch (request_type.Text)
            {
                case "报废申请":
                    tr_submit_d();
                    break;
                case "退货申请":
                    tr_submit_t();
                    break;
                default:
                    tr_submit_d();
                    break;
            }
        }
        #endregion
        #region 报修申请
        private void rr_tc()
        {
            this.rr_id.DataBindings.Add("Text", bs, "id", true);
            this.rr_name.DataBindings.Add("Text", bs, "name", true);
            this.rr_sector.DataBindings.Add("Text", bs, "sector_id", true);
            this.rr_lt.DataBindings.Add("Text", bs, "device_lifetime", true);
            this.rr_did.DataBindings.Add("Text", bs, "device_id", true);
            this.rr_size.DataBindings.Add("Text", bs, "size", true);
            this.rr_rt.DataBindings.Add("Text", bs, "repair_num", true);
            this.rr_ind.DataBindings.Add("Text", bs, "in_date", true);
            this.rr_info.DataBindings.Add("Text", bs, "info", true);
        }
        private void rr_clear()
        {
            this.rr_id.Text = "";
            this.rr_name.Text = "";
            this.rr_sector.Text = "";
            this.rr_lt.Text = "";
            this.rr_did.Text = "";
            this.rr_size.Text = "";
            this.rr_rt.Text = "";
            this.rr_ind.Text = "";
            this.rr_info.Text = "";
        }
        private void rr_ac()
        {
            this.rr_id.DataBindings.Clear();
            this.rr_name.DataBindings.Clear();
            this.rr_sector.DataBindings.Clear();
            this.rr_lt.DataBindings.Clear();
            this.rr_did.DataBindings.Clear();
            this.rr_size.DataBindings.Clear();
            this.rr_rt.DataBindings.Clear();
            this.rr_ind.DataBindings.Clear();
            this.rr_info.DataBindings.Clear();
        }
        private void rr_search_Click(object sender, EventArgs e)
        {
            or_ac();
            tr_ac();
            rr_ac();
            DataTable dt = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "normal"));
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("不存在可申请报修的项");
                this.dg1.DataSource = null;
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = dt;
                this.dg1.DataSource = bs;
                altercheader_ds(dg1);
                rr_tc();
            }
        }

        private void rr_submit_Click(object sender, EventArgs e)
        {
            or_ac();
            tr_ac();
            rr_ac();
            helper.ExecuteNonQuery("update device_sheet set device_state=@state where id=@id", new SqlParameter("state", "pre_repair"), new SqlParameter("id", rr_id.Text));
            string datetime = DateTime.Now.ToString();
            helper.ExecuteNonQuery("insert into device_user_sheet values(@did,@id,@uid,@rs,@seid,@info,@date,@state,@fd)", new SqlParameter("did", rr_did.Text), new SqlParameter("id", rr_id.Text), new SqlParameter("uid", receivedata.id), new SqlParameter("rs", "unaudited"), new SqlParameter("seid", rr_sector.Text), new SqlParameter("info", rr_info.Text), new SqlParameter("date", datetime), new SqlParameter("state", "repair"), new SqlParameter("fd", ""));
            DataTable dt = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "normal"));
            if (dt.Rows.Count <= 0)
            {
                this.dg1.DataSource = null;
                MessageBox.Show("不存在可申请退货或报废的项");
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = dt;
                this.dg1.DataSource = bs;
                altercheader_ds(dg1);
                rr_tc();
            }
        }
        #endregion

        #region 维护管理
        private void wm_tc()
        {
            this.wm_id.DataBindings.Add("Text", bs, "id", true);
            this.wm_name.DataBindings.Add("Text", bs, "name", true);
            this.wm_sector.DataBindings.Add("Text", bs, "sector_id", true);
            this.wm_lt.DataBindings.Add("Text", bs, "device_lifetime", true);
            this.wm_did.DataBindings.Add("Text", bs, "device_id", true);
            this.wm_size.DataBindings.Add("Text", bs, "size", true);
            this.wm_rn.DataBindings.Add("Text", bs, "repair_num", true);
            this.wm_ind.DataBindings.Add("Text", bs, "in_date", true);
            this.wm_info.DataBindings.Add("Text", bs, "info", true);
        }
        private void wm_clear()
        {
            this.wm_id.Text = "";
            this.wm_name.Text = "";
            this.wm_sector.Text = "";
            this.wm_lt.Text = "";
            this.wm_did.Text = "";
            this.wm_size.Text = "";
            this.wm_rn.Text = "";
            this.wm_ind.Text = "";
            this.wm_info.Text = "";
        }
        private void wm_ac()
        {
            this.wm_id.DataBindings.Clear();
            this.wm_name.DataBindings.Clear();
            this.wm_sector.DataBindings.Clear();
            this.wm_lt.DataBindings.Clear();
            this.wm_did.DataBindings.Clear();
            this.wm_size.DataBindings.Clear();
            this.wm_rn.DataBindings.Clear();
            this.wm_ind.DataBindings.Clear();
            this.wm_info.DataBindings.Clear();
        }
        private void wm_submit_Click(object sender, EventArgs e)
        {
            helper.ExecuteNonQuery("update device_sheet set device_lifetime=@lt , info=@info where id=@id", new SqlParameter("lt", wm_lt.Text), new SqlParameter("info", wm_info.Text), new SqlParameter("id", tr_id.Text));
        }

        private void wm_search_Click(object sender, EventArgs e)
        {
            wm_ac();
            DataTable dt = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "normal"));
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("不存在可维护的项");
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = dt;
                this.dg2.DataSource = bs;
                altercheader_ds(dg2);
                tr_tc();
            }
            wm_tc();
        }
        #endregion
        private void um_tc()
        {
            this.u_sid.DataBindings.Add("Text", bs, "staff_id", true);
            this.u_seid.DataBindings.Add("Text", bs, "sector_id", true);
            this.u_sname.DataBindings.Add("Text", bs, "sector_name", true);
            this.u_pn.DataBindings.Add("Text", bs, "position", true);
            this.u_name.DataBindings.Add("Text", bs, "name", true);
            this.u_gender.DataBindings.Add("Text", bs, "gender", true);

        }
        private void um_clear()
        {

            this.u_sid.Text = "";
            this.u_seid.Text = "";
            this.u_sname.Text = "";
            this.u_pn.Text = "";
            this.u_name.Text = "";
            this.u_gender.Text = "";

        }
        private void um_ac()
        {

            this.u_sid.DataBindings.Clear();
            this.u_seid.DataBindings.Clear();
            this.u_sname.DataBindings.Clear();
            this.u_pn.DataBindings.Clear();
            this.u_name.DataBindings.Clear();
            this.u_gender.DataBindings.Clear();

        }
        private void search_Click(object sender, EventArgs e)
        {
            um_ac();
            DataTable dt = helper.ExecuteDataTable("select * from doctor_sheet ", new SqlParameter("staff_id", u_sid.Text));
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("搜索相关项不存在");
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = dt;
                this.dgw1.DataSource = bs;
                um_tc();

            }
        }
        private void add_Click(object sender, EventArgs e)
        {
            um_ac();
            helper.ExecuteNonQuery("insert into user_sheet values(@name,@sid,@gender,@seid,@sector,@position)", new SqlParameter("name", u_name.Text), new SqlParameter("sid", u_sid.Text), new SqlParameter("gender", u_gender.Text), new SqlParameter("seid", u_seid.Text), new SqlParameter("sector", u_sname.Text), new SqlParameter("position", u_pn.Text));
            DataTable dt = helper.ExecuteDataTable("select * from doctor_sheet");
            bs = new BindingSource();
            bs.DataSource = dt;
            this.dgw1.DataSource = bs;
            um_tc();
        }
        private void update_Click(object sender, EventArgs e)
        {
            um_ac();
            helper.ExecuteNonQuery("update doctor_sheet set name=@name,gender=@gender,sector_id=@seid,sector_name=@sn,position=@pn where staff_id=@staff_id ", new SqlParameter("name", u_name.Text), new SqlParameter("sid", u_sid.Text), new SqlParameter("gender", u_gender.Text), new SqlParameter("seid", u_seid.Text), new SqlParameter("sn", u_sname.Text), new SqlParameter("pn", u_pn.Text), new SqlParameter("staff_id", u_sid.Text));
            DataTable dt = helper.ExecuteDataTable("select * from doctor_sheet");
            bs = new BindingSource();
            bs.DataSource = dt;
            this.dgw1.DataSource = bs;
            um_tc();

        }

        private void delete_Click(object sender, EventArgs e)
        {
            um_ac();
            helper.ExecuteNonQuery("delete from doctor_sheet where staff_id=@staff_id", new SqlParameter("staff_id", u_sid.Text));
            DataTable dt = helper.ExecuteDataTable("select * from doctor_sheet");
            bs = new BindingSource();
            bs.DataSource = dt;
            this.dgw1.DataSource = bs;
            um_tc();
        }
        //
        private void bm_tc()
        {
            this.b_uid.DataBindings.Add("Text", bs, "user_id", true);
            this.b_pwd.DataBindings.Add("Text", bs, "pwd", true);
            this.b_et.DataBindings.Add("Text", bs, "error_time", true);
            this.b_privilege.DataBindings.Add("Text", bs, "privilege", true);
            this.b_rtime.DataBindings.Add("Text", bs, "register_time", true);
            this.b_cd.DataBindings.Add("Text", bs, "check_data", true);
        }
        private void bm_clear()
        {
            this.b_uid.Text = "";
            this.b_pwd.Text = "";
            this.b_et.Text = "";
            this.b_privilege.Text = "";
            this.b_rtime.Text = "";
            this.b_cd.Text = "";
        }
        private void bm_ac()
        {
            this.b_uid.DataBindings.Clear();
            this.b_pwd.DataBindings.Clear();
            this.b_et.DataBindings.Clear();
            this.b_privilege.DataBindings.Clear();
            this.b_rtime.DataBindings.Clear();
            this.b_cd.DataBindings.Clear();
        }
        private void b_search_Click(object sender, EventArgs e)
        {
            bm_ac();
            DataTable dt = helper.ExecuteDataTable("select * from user_sheet");//where user_id=@id", new SqlParameter("id", b_uid.Text)//
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("搜索相关项不存在");
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = dt;
                this.dgw2.DataSource = bs;
                bm_tc();

            }
        }
        private void b_update_Click(object sender, EventArgs e)
        {
            bm_ac();
            helper.ExecuteNonQuery("update user_sheet set privilege=@privilege where user_id=@id ", new SqlParameter("privilege", b_privilege.Text), new SqlParameter("id", b_uid.Text));
            DataTable dt = helper.ExecuteDataTable("select * from user_sheet");
            bs = new BindingSource();
            bs.DataSource = dt;
            this.dgw2.DataSource = bs;
            bm_tc();
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            bm_ac();
            helper.ExecuteNonQuery("delete from user_sheet where user_id=@id", new SqlParameter("staff_id", b_uid.Text));
            DataTable dt = helper.ExecuteDataTable("select * from user_sheet");
            bs = new BindingSource();
            bs.DataSource = dt;
            this.dgw2.DataSource = bs;
            bm_tc();
        }
        //
        private void im_tc()
        {
            this.im_oid.DataBindings.Add("Text", bs, "id", true);
            this.im_id.DataBindings.Add("Text", bs, "device_id", true);
            this.im_dn.DataBindings.Add("Text", bs, "name", true);
            this.im_size.DataBindings.Add("Text", bs, "size", true);
            this.im_brand.DataBindings.Add("Text", bs, "brand", true);
            this.im_cost.DataBindings.Add("Text", bs, "cost", true);
            this.im_indate.DataBindings.Add("Text", bs, "in_date", true);
            this.im_pd.DataBindings.Add("Text", bs, "produce_date", true);
            this.im_mid.DataBindings.Add("Text", bs, "maintain_id", true);
            this.im_main.DataBindings.Add("Text", bs, "maintain_name", true);
            this.im_tid.DataBindings.Add("Text", bs, "trans_id", true);
            this.im_trans.DataBindings.Add("Text", bs, "trans_name", true);
            this.im_seid.DataBindings.Add("Text", bs, "sector_id", true);
            this.im_num.DataBindings.Add("Text", bs, "num", true);
            this.im_sector.DataBindings.Add("Text", bs, "sector", true);


        }
        private void im_clear()
        {
            this.im_id.Text = "";
            this.im_dn.Text = "";
            this.im_size.Text = "";
            this.im_brand.Text = "";
            this.im_cost.Text = "";
            this.im_indate.Text = "";
            this.im_pd.Text = "";
            this.im_mid.Text = "";
            this.im_main.Text = "";
            this.im_tid.Text = "";
            this.im_trans.Text = "";
            this.im_seid.Text = "";
            this.im_num.Text = "";
            this.im_sector.Text = "";
            this.im_oid.Text = "";

        }
        private void im_ac()
        {
            this.im_id.DataBindings.Clear();
            this.im_dn.DataBindings.Clear();
            this.im_size.DataBindings.Clear();
            this.im_brand.DataBindings.Clear();
            this.im_cost.DataBindings.Clear();
            this.im_indate.DataBindings.Clear();
            this.im_pd.DataBindings.Clear();
            this.im_mid.DataBindings.Clear();
            this.im_main.DataBindings.Clear();
            this.im_tid.DataBindings.Clear();
            this.im_trans.DataBindings.Clear();
            this.im_seid.DataBindings.Clear();
            this.im_num.DataBindings.Clear();
            this.im_sector.DataBindings.Clear();
            this.im_oid.DataBindings.Clear();

        }
        private void im_add_Click(object sender, EventArgs e)
        {
            im_ac();
            int temp = Convert.ToInt32(im_num.Text);
            DataTable t1 = helper.ExecuteDataTable("select * from device_request_sheet where device_id=@did", new SqlParameter("did", im_id.Text));
            if (t1.Rows.Count <= 0)
            {
                MessageBox.Show("请输入申请入库设备的信息");
            }
            else
            {
                DataTable test = helper.ExecuteDataTable("select * from device_register_sheet where device_id=@id", new SqlParameter("id", im_id.Text));
                if (test.Rows.Count <= 0)
                {
                    helper.ExecuteNonQuery("insert into device_register_sheet values(@id,@name,@size,@brand,@cost,@ind,@pd,@mid,@main,@tid,@tran,@seid,@num,@sector)", new SqlParameter("id", im_id.Text), new SqlParameter("name", im_dn.Text), new SqlParameter("size", im_size.Text), new SqlParameter("brand", im_brand.Text), new SqlParameter("cost", im_cost.Text), new SqlParameter("ind", im_indate.Text), new SqlParameter("pd", im_pd.Text), new SqlParameter("mid", im_mid.Text), new SqlParameter("main", im_main.Text), new SqlParameter("tid", im_tid.Text), new SqlParameter("tran", im_trans.Text), new SqlParameter("seid", im_seid.Text), new SqlParameter("num", im_num.Text), new SqlParameter("sector", im_sector.Text));
                    helper.ExecuteNonQuery("delete from device_request_sheet where id=@id", new SqlParameter("id", im_oid.Text));
                    for (int i = 1; i <= temp; i++)
                    {
                        helper.ExecuteNonQuery("insert into device_sheet (device_id,name,size,brand,sector_id,repair_num,device_lifetime,device_state,info,in_date,produce_date,trans_id,trans_name) values(@did,@name,@size,@brand,@seid,@rn,@lt,@state,@info,@ind,@pd,@tid,@tn)", new SqlParameter("did", im_id.Text), new SqlParameter("name", im_dn.Text), new SqlParameter("size", im_size.Text), new SqlParameter("brand", im_brand.Text), new SqlParameter("id", im_id.Text), new SqlParameter("seid", im_seid.Text), new SqlParameter("rn", '0'), new SqlParameter("lt", '0'), new SqlParameter("state", "normal"), new SqlParameter("info", ""), new SqlParameter("ind", im_indate.Text), new SqlParameter("pd", im_pd.Text), new SqlParameter("tid", ""), new SqlParameter("tn", ""));
                    }
                }
                else
                {
                    DataRow dr = test.Rows[0];
                    int num = Convert.ToInt32(dr["num"]);
                    temp += num;
                    helper.ExecuteNonQuery("update device_register_sheet set num=@num where device_id=@id", new SqlParameter("num", temp), new SqlParameter("id", im_id.Text));
                    helper.ExecuteNonQuery("delete from device_request_sheet where id=@id", new SqlParameter("id", im_oid.Text));
                    for (int i = 1; i <= temp; i++)
                    {
                        helper.ExecuteNonQuery("insert into device_sheet (device_id,name,size,brand,sector_id,repair_num,device_lifetime,device_state,info,in_date,produce_date,trans_id,trans_name) values(@did,@name,@size,@brand,@seid,@rn,@lt,@state,@info,@ind,@pd,@tid,@tn)", new SqlParameter("did", im_id.Text), new SqlParameter("name", im_dn.Text), new SqlParameter("size", im_size.Text), new SqlParameter("brand", im_brand.Text), new SqlParameter("id", im_id.Text), new SqlParameter("seid", im_seid.Text), new SqlParameter("rn", '0'), new SqlParameter("lt", '0'), new SqlParameter("state", "normal"), new SqlParameter("info", ""), new SqlParameter("ind", im_indate.Text), new SqlParameter("pd", im_pd.Text), new SqlParameter("tid", ""), new SqlParameter("tn", ""));
                    }
                }
                string date = DateTime.Now.ToString();
                helper.ExecuteNonQuery("update device_user_sheet set request_state = @rs,finish_date=@fd where device_lsid = @id", new SqlParameter("rs", "success"), new SqlParameter("fd", date), new SqlParameter("id", im_id.Text));
                DataTable dt = helper.ExecuteDataTable("select * from device_request_sheet");
                bs = new BindingSource();
                bs.DataSource = dt;
                this.dgw3.DataSource = bs;
                altercheader_drs(dgw3);
                im_tc();
            }

        }

        private void im_search_Click(object sender, EventArgs e)
        {
            im_ac();
            DataTable dt = helper.ExecuteDataTable("select * from device_request_sheet", new SqlParameter("id", b_uid.Text));
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("不存在申请入库的项");
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = dt;
                this.dgw3.DataSource = bs;
                altercheader_drs(dgw3);
                im_tc();
            }
        }
        //
        private void om_tc()
        {
            this.om_id.DataBindings.Add("Text", bs, "id", true);
            this.om_name.DataBindings.Add("Text", bs, "name", true);
            this.om_sector.DataBindings.Add("Text", bs, "sector_id", true);
            this.om_lifetime.DataBindings.Add("Text", bs, "device_lifetime", true);
            this.om_did.DataBindings.Add("Text", bs, "device_id", true);
            this.om_size.DataBindings.Add("Text", bs, "size", true);
            this.om_rt.DataBindings.Add("Text", bs, "repair_num", true);
            this.om_indate.DataBindings.Add("Text", bs, "in_date", true);
            this.om_pd.DataBindings.Add("Text", bs, "produce_date", true);
            this.om_brand.DataBindings.Add("Text", bs, "brand", true);
            this.om_state.DataBindings.Add("Text", bs, "device_state", true);
            this.om_tid.DataBindings.Add("Text", bs, "trans_id", true);
            this.om_tn.DataBindings.Add("Text", bs, "trans_name", true);
            this.om_seid.DataBindings.Add("Text", bs, "sector_id", true);

        }
        private void om_clear()
        {
            this.om_id.Text = "";
            this.om_name.Text = "";
            this.om_sector.Text = "";
            this.om_lifetime.Text = "";
            this.om_did.Text = "";
            this.om_size.Text = "";
            this.om_rt.Text = "";
            this.om_indate.Text = "";
            this.om_state.Text = "";
            this.om_tid.Text = "";
            this.om_tn.Text = "";
            this.om_pd.Text = "";
            this.om_seid.Text = "";
            this.om_brand.Text = "";
        }
        private void om_ac()
        {
            this.om_id.DataBindings.Clear();
            this.om_name.DataBindings.Clear();
            this.om_sector.DataBindings.Clear();
            this.om_lifetime.DataBindings.Clear();
            this.om_did.DataBindings.Clear();
            this.om_size.DataBindings.Clear();
            this.om_rt.DataBindings.Clear();
            this.om_indate.DataBindings.Clear();
            this.om_state.DataBindings.Clear();
            this.om_tid.DataBindings.Clear();
            this.om_tn.DataBindings.Clear();
            this.om_pd.DataBindings.Clear();
            this.om_seid.DataBindings.Clear();
            this.om_brand.DataBindings.Clear();
        }
        private void om_delete_Click(object sender, EventArgs e)
        {
            om_ac();
            DataTable test1 = helper.ExecuteDataTable("select * from device_sheet where device_state=@state1 or device_state=@state2", new SqlParameter("state1", "outstock"), new SqlParameter("state2", "refund"));
            if (test1.Rows.Count <= 0)
            {
                MessageBox.Show("不存在申请出库项!");
                return;
            }
            else
            {
                DataTable temp = helper.ExecuteDataTable("select * from device_register_sheet where device_id=@id", new SqlParameter("id", om_did.Text));
                DataRow dr = temp.Rows[0];
                int num = Convert.ToInt32(dr["num"]);
                if (num > 1)
                {
                    num -= 1;
                    helper.ExecuteNonQuery("delete from device_sheet where id=@id", new SqlParameter("id", om_id.Text));
                    helper.ExecuteNonQuery("update device_register_sheet set num=@num where device_id=@id", new SqlParameter("num", num.ToString()), new SqlParameter("id", om_did.Text));
                    helper.ExecuteNonQuery("insert into stockout_sheet (inner_id,device_id,name,size,brand,sector_id,repair_num,device_lifetime,device_state,in_date,produce_date,trans_id,trans_name,info) values(@inid,@did,@name,@size,@brand,@seid,@rn,@lt,@state,@ind,@pd,@tid,@tn,@info)", new SqlParameter("inid", om_id.Text), new SqlParameter("did", om_did.Text), new SqlParameter("name", om_name.Text), new SqlParameter("size", om_size.Text), new SqlParameter("brand", om_brand.Text), new SqlParameter("id", om_id.Text), new SqlParameter("seid", om_seid.Text), new SqlParameter("rn", om_rt.Text), new SqlParameter("lt", om_lifetime.Text), new SqlParameter("state", om_state.Text),  new SqlParameter("ind", om_indate.Text), new SqlParameter("pd", om_pd.Text), new SqlParameter("tid", om_tid.Text), new SqlParameter("tn", om_tn.Text), new SqlParameter("info", ""));

                }
                else
                {
                    helper.ExecuteNonQuery("insert into stockout_sheet (inner_id,device_id,name,size,brand,sector_id,repair_num,device_lifetime,device_state,in_date,produce_date,trans_id,trans_name,info) values(@inid,@did,@name,@size,@brand,@seid,@rn,@lt,@state,@ind,@pd,@tid,@tn,@info)", new SqlParameter("inid", om_id.Text), new SqlParameter("did", om_did.Text), new SqlParameter("name", om_name.Text), new SqlParameter("size", om_size.Text), new SqlParameter("brand", om_brand.Text), new SqlParameter("id", om_id.Text), new SqlParameter("seid", om_seid.Text), new SqlParameter("rn", om_rt.Text), new SqlParameter("lt", om_lifetime.Text), new SqlParameter("state", om_state.Text), new SqlParameter("ind", om_indate.Text), new SqlParameter("pd", om_pd.Text), new SqlParameter("tid", om_tid.Text), new SqlParameter("tn", om_tn.Text), new SqlParameter("info", ""));
                    helper.ExecuteNonQuery("delete from device_sheet where id=@id", new SqlParameter("id", om_id.Text));
                    helper.ExecuteNonQuery("delete from device_register_sheet where device_id=@id", new SqlParameter("id", om_did.Text));

                }
                string date = DateTime.Now.ToString();
                helper.ExecuteNonQuery("update device_user_sheet set request_state = @rs,finish_date=@fd where device_lsid = @id", new SqlParameter("rs", "success"), new SqlParameter("fd", date), new SqlParameter("id", om_id.Text));
                DataTable test = helper.ExecuteDataTable("select * from device_sheet where device_state=@state1 or device_state=@state2", new SqlParameter("state1", "outstock"), new SqlParameter("state2", "refund"));
                bs = new BindingSource();
                bs.DataSource = test;
                this.dgw4.DataSource = bs;
                altercheader_ds(dgw4);
                om_tc();
            }
        }

        private void om_submit_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = "../../Report_os.rdlc";
            DataTable dt = getdt_os();
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);                   
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(report_os());
            reportViewer1.RefreshReport();
            reset_tabpage();
            this.tabcontroll.SelectedTab = this.tabPage12;
            tabPage12.Parent = tabcontroll;
        }
        private void om_search_Click(object sender, EventArgs e)
        {
            om_ac();
            DataTable test = helper.ExecuteDataTable("select * from device_sheet where device_state=@state1 or device_state=@state2", new SqlParameter("state1", "outstock"), new SqlParameter("state2", "refund"));
            if (test.Rows.Count <= 0)
            {
                MessageBox.Show("不存在出库相关项");
                this.dgw4.DataSource = null;
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = test;
                this.dgw4.DataSource = bs;
                altercheader_ds(dgw4);
                om_tc();
            }
        }
        //
        private void dm_tc()
        {
            this.dm_id.DataBindings.Add("Text", bs, "id", true);
            this.dm_name.DataBindings.Add("Text", bs, "name", true);
            this.dm_sector.DataBindings.Add("Text", bs, "sector_id", true);
            this.dm_lifetime.DataBindings.Add("Text", bs, "device_lifetime", true);
            this.dm_did.DataBindings.Add("Text", bs, "device_id", true);
            this.dm_size.DataBindings.Add("Text", bs, "size", true);
            this.dm_rt.DataBindings.Add("Text", bs, "repair_num", true);
            this.dm_indate.DataBindings.Add("Text", bs, "in_date", true);
            this.dm_state.DataBindings.Add("Text", bs, "device_state", true);
            this.dm_info.DataBindings.Add("Text", bs, "info", true);

        }
        private void dm_clear()
        {
            this.dm_id.Text = "";
            this.dm_name.Text = "";
            this.dm_sector.Text = "";
            this.dm_lifetime.Text = "";
            this.dm_did.Text = "";
            this.dm_size.Text = "";
            this.dm_rt.Text = "";
            this.dm_indate.Text = "";
            this.dm_state.Text = "";
            this.dm_info.Text = "";
        }
        private void dm_ac()
        {
            this.dm_id.DataBindings.Clear();
            this.dm_name.DataBindings.Clear();
            this.dm_sector.DataBindings.Clear();
            this.dm_lifetime.DataBindings.Clear();
            this.dm_did.DataBindings.Clear();
            this.dm_size.DataBindings.Clear();
            this.dm_rt.DataBindings.Clear();
            this.dm_indate.DataBindings.Clear();
            this.dm_state.DataBindings.Clear();
            this.dm_info.DataBindings.Clear();
        }
        private void dm_search_r()
        {
            DataTable test = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "pre_repair"));
            if (test.Rows.Count <= 0)
            {
                MessageBox.Show("不存在报修相关项");
                this.dgw5.DataSource = null;
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = test;
                this.dgw5.DataSource = bs;
                altercheader_ds(dgw5);
                dm_tc();
            }
        }
        private void dm_search_d()
        {
            DataTable test = helper.ExecuteDataTable("select * from device_sheet where device_state=@state ", new SqlParameter("state", "pre_discard"));
            if (test.Rows.Count <= 0)
            {
                MessageBox.Show("不存在报修相关项");
                this.dgw5.DataSource = null;
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = test;
                this.dgw5.DataSource = bs;
                altercheader_ds(dgw5);
                dm_tc();
            }
        }
        private void dm_search_t()
        {

            DataTable test = helper.ExecuteDataTable("select * from device_sheet where device_state=@state ", new SqlParameter("state", "pre_refund"));
            if (test.Rows.Count <= 0)
            {
                MessageBox.Show("不存在报修相关项");
                this.dgw5.DataSource = null;
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = test;
                this.dgw5.DataSource = bs;
                altercheader_ds(dgw5);
                dm_tc();
            }
        }
        private void dm_search_Click(object sender, EventArgs e)
        {
            dm_ac();
            switch (request_choice.Text)
            {
                case "报修申请":
                    dm_cancel_r();
                    break;
                case "报废申请":
                    dm_search_d();
                    break;
                case "退货申请":
                    dm_search_t();
                    break;
                default:
                    dm_search_r();
                    break;
            }

        }
        private void dm_cancel_r()
        {
            DataTable test = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "pre_repair"));
            if (test.Rows.Count <= 0)
            {
                MessageBox.Show("不存在报修相关项");
                this.dgw5.DataSource = null;
                return;
            }
            else
            {
                helper.ExecuteNonQuery("update device_sheet set device_state=@state where id=@id", new SqlParameter("state", "normal"), new SqlParameter("id", dr_id.Text));
                bs = new BindingSource();
                bs.DataSource = test;
                this.dgw5.DataSource = bs;
                altercheader_ds(dgw5);
                dm_tc();
            }
        }
        private void dm_cancel_d()
        {
            DataTable test = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "pre_discard"));
            if (test.Rows.Count <= 0)
            {
                MessageBox.Show("不存在报修相关项");
                this.dgw5.DataSource = null;
                return;
            }
            else
            {
                helper.ExecuteNonQuery("update device_sheet set device_state=@state where id=@id", new SqlParameter("state", "normal"), new SqlParameter("id", dr_id.Text));
                bs = new BindingSource();
                bs.DataSource = test;
                this.dgw5.DataSource = bs;
                altercheader_ds(dgw5);
                dm_tc();
            }
        }
        private void dm_cancel_t()
        {
            DataTable test = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "pre_refund"));
            if (test.Rows.Count <= 0)
            {
                MessageBox.Show("不存在报修相关项");
                this.dgw5.DataSource = null;
                return;
            }
            else
            {
                helper.ExecuteNonQuery("update device_sheet set device_state=@state where id=@id", new SqlParameter("state", "normal"), new SqlParameter("id", dr_id.Text));
                bs = new BindingSource();
                bs.DataSource = test;
                this.dgw5.DataSource = bs;
                altercheader_ds(dgw5);
                dm_tc();
            }
        }
        private void dm_cancel_Click(object sender, EventArgs e)
        {
            dm_ac();
            switch (request_choice.Text)
            {
                case "报修申请":
                    dm_search_r();
                    break;
                case "报废申请":
                    dm_search_d();
                    break;
                case "退货申请":
                    dm_search_t();
                    break;
                default:
                    dm_search_r();
                    break;
            }

        }
        private void dm_submit_r()
        {
            helper.ExecuteNonQuery("update device_sheet set device_state=@state where id=@id", new SqlParameter("state", "repair"), new SqlParameter("id", dm_id.Text));
            string date = DateTime.Now.ToString();
            helper.ExecuteNonQuery("update device_user_sheet set request_state = @rs,finish_date=@fd where device_lsid = @id", new SqlParameter("rs", "wait"), new SqlParameter("fd", date), new SqlParameter("id", dm_id.Text));
            DataTable test = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "pre_repair"));
            if (test.Rows.Count <= 0)
            {
                this.dgw5.DataSource = null;
                MessageBox.Show("报修申请已处理完毕");
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = test;
                this.dgw5.DataSource = bs;
                altercheader_ds(dgw5);
                dm_tc();
            }
        }
        private void dm_submit_d()
        {
            helper.ExecuteNonQuery("update device_sheet set device_state=@state where id=@id", new SqlParameter("state", "discard"), new SqlParameter("id", dm_id.Text));
            string date = DateTime.Now.ToString();
            helper.ExecuteNonQuery("update device_user_sheet set request_state = @rs,finish_date=@fd where device_lsid = @id", new SqlParameter("rs", "wait"), new SqlParameter("fd", date), new SqlParameter("id", dm_id.Text));
            DataTable test = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "pre_discard"));
            if (test.Rows.Count <= 0)
            {
                this.dgw5.DataSource = null;
                MessageBox.Show("报废申请已处理完毕");
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = test;
                this.dgw5.DataSource = bs;
                altercheader_ds(dgw5);
                dm_tc();
            }
        }
        private void dm_submit_t()
        {
            helper.ExecuteNonQuery("update device_sheet set device_state=@state where id=@id", new SqlParameter("state", "in_refund"), new SqlParameter("id", dm_id.Text));
            string date = DateTime.Now.ToString();
            helper.ExecuteNonQuery("update device_user_sheet set request_state = @rs,finish_date=@fd where device_lsid = @id", new SqlParameter("rs", "wait"), new SqlParameter("fd", date), new SqlParameter("id", dm_id.Text));
            DataTable test = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "pre_refund"));
            if (test.Rows.Count <= 0)
            {
                this.dgw5.DataSource = null;
                MessageBox.Show("退货申请已处理完毕");
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = test;
                this.dgw5.DataSource = bs;
                altercheader_ds(dgw5);
                dm_tc();
            }
        }
        private void dm_submit_Click(object sender, EventArgs e)
        {
            dm_ac();
            switch (request_choice.Text)
            {
                case "报修申请":
                    dm_submit_r();
                    break;
                case "报废申请":
                    dm_submit_d();
                    break;
                case "退货申请":
                    dm_submit_t();
                    break;
                default:
                    dm_submit_r();
                    break;
            }
        }
        //
        private void dr_tc()
        {
            this.dr_id.DataBindings.Add("Text", bs, "id", true);
            this.dr_name.DataBindings.Add("Text", bs, "name", true);
            this.dr_sector.DataBindings.Add("Text", bs, "sector_id", true);
            this.dr_lifetime.DataBindings.Add("Text", bs, "device_lifetime", true);
            this.dr_did.DataBindings.Add("Text", bs, "device_id", true);
            this.dr_size.DataBindings.Add("Text", bs, "size", true);
            this.dr_rt.DataBindings.Add("Text", bs, "repair_num", true);
            this.dr_indate.DataBindings.Add("Text", bs, "in_date", true);
            this.dr_state.DataBindings.Add("Text", bs, "device_state", true);
            this.dr_info.DataBindings.Add("Text", bs, "info", true);

        }
        private void dr_clear()
        {
            this.dr_id.Text = "";
            this.dr_name.Text = "";
            this.dr_sector.Text = "";
            this.dr_lifetime.Text = "";
            this.dr_did.Text = "";
            this.dr_size.Text = "";
            this.dr_rt.Text = "";
            this.dr_indate.Text = "";
            this.dr_state.Text = "";
            this.dr_info.Text = "";
        }
        private void dr_ac()
        {
            this.dr_id.DataBindings.Clear();
            this.dr_name.DataBindings.Clear();
            this.dr_sector.DataBindings.Clear();
            this.dr_lifetime.DataBindings.Clear();
            this.dr_did.DataBindings.Clear();
            this.dr_size.DataBindings.Clear();
            this.dr_rt.DataBindings.Clear();
            this.dr_indate.DataBindings.Clear();
            this.dr_state.DataBindings.Clear();
            this.dr_info.DataBindings.Clear();
        }
        private void dr_sr_m()
        {
            DataTable test = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "repair"));
            if (test.Rows.Count <= 0)
            {
                MessageBox.Show("不存在需要维修的相关项");
                this.dgw6.DataSource = null;
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = test;
                this.dgw6.DataSource = bs;
                altercheader_ds(dgw6);
                dr_tc();
            }
        }
        private void dr_sr_d()
        {
            DataTable test = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "discard"));
            if (test.Rows.Count <= 0)
            {
                MessageBox.Show("不存在有潜在报废可能的相关项");
                this.dgw6.DataSource = null;
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = test;
                this.dgw6.DataSource = bs;
                altercheader_ds(dgw6);
                dr_tc();
            }
        }
        private void dr_sr_t()
        {
            DataTable test = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "in_refund"));
            if (test.Rows.Count <= 0)
            {
                MessageBox.Show("退货请求已经处理完成！");
                this.dgw6.DataSource = null;
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = test;
                this.dgw6.DataSource = bs;
                altercheader_ds(dgw6);
                dr_tc();
            }
        }
        private void dr_sr_Click(object sender, EventArgs e)
        {
            dr_ac();
            switch (service_choice.Text)
            {
                case "维修":
                    dr_sr_m();
                    break;
                case "报废":
                    dr_sr_d();
                    break;
                case "退货":
                    dr_sr_t();
                    break;
                default:
                    dr_sr_m();
                    break;
            }

        }
        private void dr_submit_r()
        {
            DataTable test = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "repair"));
            if (test.Rows.Count <= 0)
            {
                this.dgw6.DataSource = null;
                MessageBox.Show("不存在需要维修的相关项");
                return;
            }
            else
            {
                DataRow dr = test.Rows[0];
                int num = Convert.ToInt32(dr["repair_num"]);
                num += 1;
                helper.ExecuteNonQuery("update device_sheet set repair_num=@repair_num , device_state=@state where id=@id", new SqlParameter("repair_num", num), new SqlParameter("state", "normal"), new SqlParameter("id", dr_id.Text));
                string date = DateTime.Now.ToString();
                helper.ExecuteNonQuery("update device_user_sheet set request_state = @rs,finish_date=@fd where device_lsid = @id", new SqlParameter("rs", "success"), new SqlParameter("fd", date), new SqlParameter("id", dr_id.Text));
                DataTable test1 = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "repair"));
                bs = new BindingSource();
                bs.DataSource = test1;
                this.dgw6.DataSource = bs;
                altercheader_ds(dgw6);
                dr_tc();
            }
        }
        private void dr_submit_d()
        {
            helper.ExecuteNonQuery("update device_sheet set device_state=@state where id=@id", new SqlParameter("state", "outstock"), new SqlParameter("id", dr_id.Text));
            string date = DateTime.Now.ToString();
            helper.ExecuteNonQuery("update device_user_sheet set request_state = @rs,finish_date=@fd where device_lsid = @id", new SqlParameter("rs", "success"), new SqlParameter("fd", date), new SqlParameter("id", dr_id.Text));
            DataTable test = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "discard"));
            if (test.Rows.Count <= 0)
            {
                this.dgw6.DataSource = null;
                MessageBox.Show("不存在有潜在报废可能的相关项");
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = test;
                this.dgw6.DataSource = bs;
                altercheader_ds(dgw6);
                dr_tc();
            }
        }
        private void dr_submit_t()
        {
            helper.ExecuteNonQuery("update device_sheet set device_state=@state where id=@id", new SqlParameter("state", "refund"), new SqlParameter("id", dr_id.Text));
            string date = DateTime.Now.ToString();
            helper.ExecuteNonQuery("update device_user_sheet set request_state = @rs,finish_date=@fd where device_lsid = @id", new SqlParameter("rs", "success"), new SqlParameter("fd", date), new SqlParameter("id", dr_id.Text));
            DataTable test = helper.ExecuteDataTable("select * from device_sheet where device_state=@state", new SqlParameter("state", "in_refund"));
            if (test.Rows.Count <= 0)
            {
                this.dgw6.DataSource = null;
                MessageBox.Show("不存在有潜在报废可能的相关项");
                return;
            }
            else
            {
                bs = new BindingSource();
                bs.DataSource = test;
                this.dgw6.DataSource = bs;
                altercheader_ds(dgw6);
                dr_tc();
            }
        }
        private void dr_repair_Click(object sender, EventArgs e)
        {
            dr_ac();
            switch (service_choice.Text)
            {
                case "维修":
                    dr_submit_r();
                    break;
                case "报废":
                    dr_submit_d();
                    break;
                case "退货":
                    dr_submit_t();
                    break;
                default:
                    dr_submit_r();
                    break;
            }
        }
        //
        private void ds_tc()
        {
            this.ds_id.DataBindings.Add("Text", bs, "id", true);
            this.ds_name.DataBindings.Add("Text", bs, "name", true);
            this.ds_brand.DataBindings.Add("Text", bs, "brand", true);
            this.ds_sector.DataBindings.Add("Text", bs, "sector_id", true);
            this.ds_lifetime.DataBindings.Add("Text", bs, "device_lifetime", true);
            this.ds_did.DataBindings.Add("Text", bs, "device_id", true);
            this.ds_size.DataBindings.Add("Text", bs, "size", true);
            this.ds_rt.DataBindings.Add("Text", bs, "repair_num", true);
            this.ds_ind.DataBindings.Add("Text", bs, "in_date", true);
            this.ds_state.DataBindings.Add("Text", bs, "device_state", true);
            this.ds_info.DataBindings.Add("Text", bs, "info", true);
            this.ds_pd.DataBindings.Add("Text", bs, "produce_date", true);
        }
        private void ds_clear()
        {
            this.ds_id.Text = "";
            this.ds_brand.Text = "";
            this.ds_name.Text = "";
            this.ds_sector.Text = "";
            this.ds_lifetime.Text = "";
            this.ds_did.Text = "";
            this.ds_size.Text = "";
            this.ds_rt.Text = "";
            this.ds_ind.Text = "";
            this.ds_state.Text = "";
            this.ds_info.Text = "";
            this.ds_pd.Text = "";
        }
        private void ds_ac()
        {
            this.ds_id.DataBindings.Clear();
            this.ds_brand.DataBindings.Clear();
            this.ds_name.DataBindings.Clear();
            this.ds_sector.DataBindings.Clear();
            this.ds_lifetime.DataBindings.Clear();
            this.ds_did.DataBindings.Clear();
            this.ds_size.DataBindings.Clear();
            this.ds_rt.DataBindings.Clear();
            this.ds_ind.DataBindings.Clear();
            this.ds_state.DataBindings.Clear();
            this.ds_info.DataBindings.Clear();
            this.ds_pd.DataBindings.Clear();
        }
        private void ds_search_Click(object sender, EventArgs e)
        {
            cs_ac();
            ds_ac();
            DataTable dt = helper.ExecuteDataTable("select * from device_sheet where 1=1 and(id=@id or @id='') and(device_id=@did or @did='') and(name=@name or @name='') and(size=@size or @size ='') and(brand=@brand or @brand='') and(sector_id=@seid or @seid='') and(repair_num=@rn or @rn='') and(device_lifetime=@lt or @lt='') and(device_state=@st or @st='') and(in_date=@ind or @ind='') and(produce_date=@pd or @pd='')", new SqlParameter("id", ds_id.Text), new SqlParameter("did", ds_did.Text), new SqlParameter("name", ds_name.Text), new SqlParameter("size", ds_size.Text), new SqlParameter("brand", ds_brand.Text), new SqlParameter("seid", ds_sector.Text), new SqlParameter("rn", ds_rt.Text), new SqlParameter("lt", ds_lifetime.Text), new SqlParameter("st", ds_state.Text), new SqlParameter("ind", ds_ind.Text), new SqlParameter("pd", ds_pd.Text));
            bs = new BindingSource();
            bs.DataSource = dt;
            this.dgw7.DataSource = bs;
            altercheader_ds(dgw7);
            ds_tc();

        }
        //
        private void cs_tc()
        {
            this.cs_id.DataBindings.Add("Text", bs, "device_id", true);
            this.cs_name.DataBindings.Add("Text", bs, "name", true);
            this.cs_brand.DataBindings.Add("Text", bs, "brand", true);
            this.cs_sector.DataBindings.Add("Text", bs, "sector", true);
            this.cs_seid.DataBindings.Add("Text", bs, "sector_id", true);
            this.cs_num.DataBindings.Add("Text", bs, "num", true);
            this.cs_main.DataBindings.Add("Text", bs, "maintain_name", true);
            this.cs_size.DataBindings.Add("Text", bs, "size", true);
            this.cs_mid.DataBindings.Add("Text", bs, "maintain_id", true);
            this.cs_ind.DataBindings.Add("Text", bs, "in_date", true);
            this.cs_tid.DataBindings.Add("Text", bs, "trans_id", true);
            this.cs_trans.DataBindings.Add("Text", bs, "trans_name", true);
            this.cs_pd.DataBindings.Add("Text", bs, "produce_date", true);
            this.cs_price.DataBindings.Add("text", bs, "cost", true);
        }
        private void cs_clear()
        {
            this.cs_id.Text = "";
            this.cs_brand.Text = "";
            this.cs_name.Text = "";
            this.cs_sector.Text = "";
            this.cs_seid.Text = "";
            this.cs_num.Text = "";
            this.cs_mid.Text = "";
            this.cs_main.Text = "";
            this.cs_size.Text = "";
            this.cs_trans.Text = "";
            this.cs_ind.Text = "";
            this.cs_tid.Text = "";
            this.cs_pd.Text = "";
            this.cs_price.Text = "";
        }
        private void cs_ac()
        {
            this.cs_id.DataBindings.Clear();
            this.cs_brand.DataBindings.Clear();
            this.cs_name.DataBindings.Clear();
            this.cs_sector.DataBindings.Clear();
            this.cs_seid.DataBindings.Clear();
            this.cs_num.DataBindings.Clear();
            this.cs_mid.DataBindings.Clear();
            this.cs_main.DataBindings.Clear();
            this.cs_size.DataBindings.Clear();
            this.cs_trans.DataBindings.Clear();
            this.cs_ind.DataBindings.Clear();
            this.cs_tid.DataBindings.Clear();
            this.cs_pd.DataBindings.Clear();
            this.cs_price.DataBindings.Clear();
        }
        private void cs_search_Click(object sender, EventArgs e)
        {
            ds_ac();
            cs_ac();
            DataTable dt = helper.ExecuteDataTable("select * from device_register_sheet where 1 = 1 and(device_id = @id or @id ='') and(name = @name or @name = '') and(size = @size or @size = '') and(brand = @brand or @brand = '') and(cost=@cost or @cost='') and(sector_id = @seid or @seid = '') and(sector = @s or @s='') and(maintain_id = @mid or @mid= '') and(maintain_name = @main or @main = '') and(in_date = @ind or @ind = '') and(produce_date = @pd or @pd = '') and(trans_id=@tid or @tid='') and(trans_name=@trans or @trans='')", new SqlParameter("id", cs_id.Text), new SqlParameter("name", cs_name.Text), new SqlParameter("size", cs_size.Text), new SqlParameter("brand", cs_brand.Text), new SqlParameter("cost", cs_price.Text), new SqlParameter("seid", ds_sector.Text), new SqlParameter("s", cs_sector.Text), new SqlParameter("mid", cs_mid.Text), new SqlParameter("main", cs_main.Text), new SqlParameter("ind", ds_ind.Text), new SqlParameter("pd", ds_pd.Text), new SqlParameter("tid", cs_tid.Text), new SqlParameter("trans", cs_trans.Text));
            bs = new BindingSource();
            bs.DataSource = dt;
            this.dgw7.DataSource = bs;
            altercheader_drs(dgw7);
            cs_tc();
        }
        //

        private void btn_request_Click(object sender, EventArgs e)
        {
            this.dg1.DataSource = null;
            or_ac();
            tr_ac();
            rr_ac();
            tr_clear();
            or_clear();
            rr_clear();
            reset_tabpage();
            this.tabcontroll.SelectedTab = this.tabPage1;
            tabPage1.Parent = tabcontroll;
        }

        private void btn_user_Click(object sender, EventArgs e)
        {
            reset_tabpage();
            um_ac();
            um_clear();
            dgw1.DataSource = null;
            this.tabcontroll.SelectedTab = this.tabPage3;
            tabPage3.Parent = tabcontroll;
        }

        private void btn_pm_Click(object sender, EventArgs e)
        {
            reset_tabpage();
            bm_ac();
            bm_clear();
            dgw2.DataSource = null;
            this.tabcontroll.SelectedTab = this.tabPage4;
            tabPage4.Parent = tabcontroll;
        }
        private void btn_in_Click(object sender, EventArgs e)
        {
            reset_tabpage();
            im_ac();
            im_clear();
            dgw3.DataSource = null;
            this.tabcontroll.SelectedTab = this.tabPage5;
            tabPage5.Parent = tabcontroll;
        }
        private void btn_out_Click(object sender, EventArgs e)
        {
            reset_tabpage();
            om_ac();
            om_clear();
            dgw4.DataSource = null;
            this.tabcontroll.SelectedTab = this.tabPage6;
            tabPage6.Parent = tabcontroll;
        }
        private void btn_dm_Click(object sender, EventArgs e)
        {
            reset_tabpage();
            dm_ac();
            dm_clear();
            dgw5.DataSource = null;
            this.tabcontroll.SelectedTab = this.tabPage7;
            tabPage7.Parent = tabcontroll;
        }

        private void btn_dd_Click(object sender, EventArgs e)
        {
            reset_tabpage();
            dr_ac();
            dr_clear();
            dgw6.DataSource = null;
            this.tabcontroll.SelectedTab = this.tabPage8;
            tabPage8.Parent = tabcontroll;
        }
        private void btn_asearch_Click(object sender, EventArgs e)
        {
            reset_tabpage();
            ds_ac();
            cs_ac();
            cs_clear();
            ds_clear();
            dgw7.DataSource = null;
            this.tabcontroll.SelectedTab = this.tabPage9;
            tabPage9.Parent = tabcontroll;
        }
        private void btn_help_Click(object sender, EventArgs e)
        {
            wm_ac();
            wm_clear();
            dg2.DataSource = null;
            reset_tabpage();
            this.tabcontroll.SelectedTab = this.tabPage2;
            tabPage2.Parent = tabcontroll;
        }
        private void btn_sta_Click(object sender, EventArgs e)
        {
            reset_tabpage();
            this.tabcontroll.SelectedTab = this.tabPage10;
            tabPage10.Parent = tabcontroll;
        }
        private void btn_mo_Click(object sender, EventArgs e)
        {
            reset_tabpage();
            switch (receivedata.privilege)
            {
                case 0:
                    {
                        myPage4.Parent = null;
                        this.tabPage11.Parent = tabcontroll;
                        this.myPage1.Parent = mcpage;
                        myPage1.Parent = mcpage;
                        break;
                    }
                case 1:
                    {
                        myPage4.Parent = null;
                        this.tabPage11.Parent = tabcontroll;
                        this.myPage2.Parent = mcpage;
                        myPage2.Parent = mcpage;
                        break;
                    }
                case 2:
                    {
                        myPage4.Parent = null;
                        this.tabPage11.Parent = tabcontroll;
                        this.myPage3.Parent = mcpage;
                        myPage3.Parent = mcpage;
                        break;
                    }
            }
        }
        private void btn_pd_Click(object sender, EventArgs e)
        {
            reset_tabpage();
            this.tabcontroll.SelectedTab = this.tabPage11;
            tabPage11.Parent = tabcontroll;
            this.mcpage.SelectedTab = this.myPage4;
            myPage4.Parent = mcpage;
            myPage1.Parent = null;
            myPage2.Parent = null;
            myPage3.Parent = null;
            temp = Captchahelper.captcha(p_checkb);
            p_checkb.Image = temp.bmp;
        }



        private void btn_my_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                this.panel1.Visible = true;
            }
            else
                panel1.Visible = false;

        }

        private void btn_um_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == false)
            {
                this.panel2.Visible = true;
            }
            else
                panel2.Visible = false;

        }

        private void btn_io_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == false)
            {
                panel3.Visible = true;
            }
            else
                panel3.Visible = false;

        }

        private void btn_mt_Click(object sender, EventArgs e)
        {
            if (panel4.Visible == false)
            {
                panel4.Visible = true;
            }
            else
                panel4.Visible = false;
        }

        private void btn_cs_Click(object sender, EventArgs e)
        {
            if (panel5.Visible == false)
            {
                panel5.Visible = true;
            }
            else
                panel5.Visible = false;
        }
        private void btn_mc_click(object sender, EventArgs e)
        {
            if (panel6.Visible == false)
            {
                panel6.Visible = true;
            }
            else
                panel6.Visible = false;
        }


        private void skinTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void skinButton2_Click(object sender, EventArgs e)
        {

        }

        private void skinButton1_Click(object sender, EventArgs e)
        {

        }

        private void skinPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 视图ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void makeup_Click(object sender, EventArgs e)
        {
            skin obj = new skin();
            obj.Eventimg += new changeImg(imgchg);
            obj.Eventiro += new changeiro(irochg);
            obj.Show();
        }
        public void irochg(Color iro)
        {
            this.BackgroundImage = null;
            toolStripMenuItem1.Image = null;
            this.BackColor = iro;
        }
        private void imgchg(Image img)
        {
            this.BackgroundImage = img;


        }
        private void skinPictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void skinButton22_Click(object sender, EventArgs e)
        {

        }

        private void skinDateTimePicker1_SelectedValueChange(object sender, string Item)
        {

        }
        private void listload(CCWin.SkinControl.SkinListView lv)
        {
            string id = receivedata.id;
            DataTable dt = helper.ExecuteDataTable("select * from device_user_sheet where user_id=@id", new SqlParameter("id", id));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string type = dr["state"].ToString();
                string device_info = dr["device_id"].ToString() + dr["device_lsid"].ToString();
                string request_date = dr["request_date"].ToString();
                string finish_date = dr["finish_date"].ToString();
                string status = dr["request_state"].ToString();
                ListViewItem lvi = new ListViewItem();
                lvi.Text = type;
                lvi.SubItems.Add(device_info);
                lvi.SubItems.Add(request_date);
                lvi.SubItems.Add(finish_date);
                lvi.SubItems.Add(status);
                lv.Items.Add(lvi);
            }
        }

        private void system_manager_Load(object sender, EventArgs e)
        {
            reset_tabpage();
            switch (receivedata.privilege)
            {
                case 0:
                    {
                        this.tabPage11.Parent = tabcontroll;
                        this.myPage1.Parent = mcpage;
                        stb1_id.Text = receivedata.id;
                        stb1_name.Text = receivedata.name;
                        stb1_tag.Text = "普通用户";
                        btn_um.Visible = false;
                        btn_io.Visible = false;
                        btn_mt.Visible = false;
                        panel2.Visible = false;
                        panel3.Visible = false;
                        panel4.Visible = false;
                        listload(listview1);
                        break;
                    }
                case 1:
                    {
                        this.tabPage11.Parent = tabcontroll;
                        this.myPage2.Parent = mcpage;
                        stb2_id.Text = receivedata.id;
                        stb2_name.Text = receivedata.name;
                        stb2_tag.Text = "管理员";
                        btn_um.Visible = false;
                        btn_my.Visible = false;
                        panel1.Visible = false;
                        panel2.Visible = false;
                        listload(listview2);
                        break;
                    }
                case 2:
                    {
                        this.tabPage11.Parent = tabcontroll;
                        this.myPage3.Parent = mcpage;
                        stb3_id.Text = receivedata.id;
                        stb3_name.Text = receivedata.name;
                        stb3_tag.Text = "系统管理员";
                        listload(listview3);
                        break;
                    }
            }
            new Thread(() =>
            {
                while (true)
                {
                    try { skinDateTimePicker1.BeginInvoke(new MethodInvoker(() => skinDateTimePicker1.Text = DateTime.Now.ToString())); }
                    catch { }
                    Thread.Sleep(1000);
                }
            })
            { IsBackground = true }.Start();
            this.reportViewer1.RefreshReport();
        }
        private void mc_edit1_Click(object sender, EventArgs e)
        {
            myPage1.Parent = null;
            myPage3.Parent = null;
            myPage2.Parent = null;
            tabPage11.Parent = null;
            temp = Captchahelper.captcha(p_checkb);
            p_checkb.Image = temp.bmp;
            myPage4.Parent = tabcontroll;
        }
        public void os_chart()
        {
            bool flag = true;
            DataTable dt1 = helper.ExecuteDataTable("select distinct  main.device_id ,ISNULL(sub.subnum, 0)  from stockout_sheet as main left join (select device_id,count(*) as subnum from stockout_sheet  where device_state=@state group by device_id )as sub on main.device_id=sub.device_id ", new SqlParameter("state", "outstock"));
            //查询出库设备中报废设备的数目用于生成柱状图1
            DataTable dt2 = helper.ExecuteDataTable("select distinct  main.device_id ,ISNULL(sub.subnum, 0)  from stockout_sheet as main left join (select device_id,count(*) as subnum from stockout_sheet  where device_state=@state group by device_id )as sub on main.device_id=sub.device_id ", new SqlParameter("state", "refund"));
            //查询出库设备中退货设备的数目用于生成柱状图2
            chart1.Series.Clear();
            Series series1 = new Series("dt1");
            Series series2 = new Series("dt2");
            series1.ChartType = SeriesChartType.Column;
            series2.ChartType = SeriesChartType.Column;
            chart1.ChartAreas[0].AxisX.Title = "设备型号";
            chart1.ChartAreas[0].AxisY.Title = "统计件数";
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                series1.Points.AddXY(dt1.Rows[i][0], dt1.Rows[i][1]);//依次在柱状图一加入点
            }
            series1.LegendText = "报废产品";
            chart1.Series.Add(series1);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                series2.Points.AddXY(dt2.Rows[i][0], dt2.Rows[i][1]);//依次在柱状图二加入点
            }
            series2.LegendText = "退货产品";
            chart1.Series.Add(series2);
        }
        public void bf_chart()
        {
            DataTable dt1 = helper.ExecuteDataTable("select distinct  main.device_id ,ISNULL(sub.subnum, 0)  from stockout_sheet as main left join (select device_id,count(*) as subnum from stockout_sheet  where device_state=@state group by device_id )as sub on main.device_id=sub.device_id", new SqlParameter("state", "outstock"));
            DataTable dt2 = helper.ExecuteDataTable("select distinct device_register_sheet.device_id,device_register_sheet.num  from device_register_sheet  join stockout_sheet on device_register_sheet.device_id=stockout_sheet.device_id  and stockout_sheet.device_state='outstock'");
            chart1.Series.Clear();
            Series series1 = new Series("dt1");
            Series series2 = new Series("dt2");
            series1.ChartType = SeriesChartType.Column;
            series2.ChartType = SeriesChartType.Column;
            chart1.ChartAreas[0].AxisX.Title = "设备型号";
            chart1.ChartAreas[0].AxisY.Title = "统计件数";
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                series1.Points.AddXY(dt1.Rows[i][0], dt1.Rows[i][1]);
            }
            series1.LegendText = "报废产品";
            chart1.Series.Add(series1);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                series2.Points.AddXY(dt2.Rows[i][0], dt2.Rows[i][1]);
            }
            series2.LegendText = "现有库存";
            chart1.Series.Add(series2);
        }
        private void sta_search_Click(object sender, EventArgs e)
        {
            os_chart();
            switch (chart_choice.Text)
            {
                case "设备出库统计":
                    os_chart();
                    break;
                case "设备完好性统计":
                    bf_chart();
                    break;
                default:
                    os_chart();
                    break;
            }
        }

        private void 注销QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            login obj = new login();
            obj.Show();
        }

        private void p_checkb_Click(object sender, EventArgs e)
        {
            temp = Captchahelper.captcha(p_checkb);
            p_checkb.Image = temp.bmp;
        }

        private void md_submit_Click(object sender, EventArgs e)
        {
            string gender = null;
            if (md_male.Checked == true)
                gender = "male";
            else if (md_female.Checked == true)
                gender = "female";
            else
                gender = "";
            if (md_rcpwd.Text == md_pwd.Text)
            {
                if (md_check.Text == temp.check)
                {
                    string id = receivedata.id;
                    helper.ExecuteNonQuery("update user_sheet set name=@name,pwd=@pwd,check_data=@cdata,gender=@gender where user_id=@id", new SqlParameter("name", md_name.Text), new SqlParameter("pwd", md_pwd.Text), new SqlParameter("cdata", md_cd.Text), new SqlParameter("gender", gender), new SqlParameter("id", id));
                    MessageBox.Show("信息修改成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("验证码错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("两次输入密码不一致!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void md_cancel_Click(object sender, EventArgs e)
        {

        }

        private void myPage4_Click(object sender, EventArgs e)
        {

        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            or_ac();
            tr_ac();
            rr_ac();
            wm_ac();
            um_ac();
            bm_ac();
            im_ac();
            om_ac();
            dm_ac();
            dr_ac();
            ds_ac();
            cs_ac();
            wm_ac();
            wm_clear();
            cs_clear();
            ds_clear();
            om_clear();
            dm_clear();
            dr_clear();
            im_clear();
            um_clear();
            bm_clear();
            wm_clear();
            tr_clear();
            or_clear();
            rr_clear();

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void skinLabel163_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void stabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void stabPage3_Click(object sender, EventArgs e)
        {

        }

        private void skinListView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void CHECK_Click(object sender, EventArgs e)
        {
           

        }

        private void skinPanel28_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }

