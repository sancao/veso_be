using System;
namespace veso_be.Entities
{
    public class DaiLy
    {
        public int Id { get; set; }
        public string MaDaiLy { get; set; }
        public string TenDaiLy { get; set; }
        public string DiaChi { get; set; }
        public string SoDeienThoai { get; set; }
        public int CapDaiLy { get; set; }
        public int DaiLyQuanLy { get; set; }
        public int NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
    }
}