using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoWindowApplication.BusinessObject
{
    class SinhVien
    {
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public DateTime NgaySinh { get; set; }
        public int GioiTinh { get; set; }
        public string Tinh { get; set; }
        public string MaKhoa { get; set; }
        public string DiaChi { get; set; }
        public Khoa Khoa { get; set; }

    }
}
