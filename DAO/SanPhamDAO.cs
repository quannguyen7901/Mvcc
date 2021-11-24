﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OJB;
using System.Data;

namespace DAO
{
    public class SanPhamDAO
    {
        DataHelper dh = new DataHelper();
        public List<SanPham> GetSanPham()
        {
            DataTable dt = dh.FillDataTable("Select *  from sanpham");
            return ToList(dt);
        }
        public List<SanPham> GetSanPhamLoai(string madong)
        {
            DataTable dt = dh.FillDataTable("Select *  from sanpham where MaDong =" + madong + ";");
            return ToList(dt);
        }
        public List<SanPham> ToList(DataTable dt)
        {
            List<SanPham> l = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), int.Parse(dr[4].ToString()), int.Parse(dr[5].ToString()), dr[6].ToString());
                l.Add(sp);
            }
            return l;
        }
        public string ThemSP(SanPham sp)
        {
            string sql = "Insert into SP VALUES('" + sp.MaSP + "','" + sp.TenSP + "','" + ","
                + sp.ThongSoKT + "','" + sp.MaDong + "'," + sp.KichThuoc + "," + sp.KhoiLuong + ",'" + sp.HinhAnh+"');";
            return dh.ExecuteNonQuery(sql);
        }
        public string SuaSP(SanPham sp)
        {
            string sql = "update set SP set TenSP='" + sp.TenSP + "," + ",ThongSoKT='" + sp.ThongSoKT + ",MaDong='" + sp.MaDong +
                "KichThuoc='" + sp.KichThuoc + ",KhoiLuong='" + sp.KhoiLuong + "HinhAnh='" + sp.HinhAnh+ " where MaSP= '" + sp.MaSP ;
            return dh.ExecuteNonQuery(sql);
        }
        public string Xoa(string sp)
        {
            string sql = "Delete from SP where MaSP= '" + sp+"';";
            return dh.ExecuteNonQuery(sql);
        }
    }
}
