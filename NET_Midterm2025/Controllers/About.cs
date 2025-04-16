using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace NET_Midterm2025.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            // Group information
            ViewBag.GroupName = "Nhóm 020-036-041-047131 NET_Midterm2025";
            ViewBag.ProjectName = "Dự án giữa kỳ ASP.NET Core";
            ViewBag.ProjectDescription = "Xây dựng ứng dụng web quản lý thư viện sử dụng ASP.NET Core";
            ViewBag.Semester = "Học kỳ II năm học 2024-2025";

            // List of 5 members with student IDs
            ViewBag.Members = new List<MemberInfo>
            {
                new MemberInfo { Name = "Văn Hữu Đan", StudentId = "4801104020" },
                new MemberInfo { Name = "Nguyễn Thị Mỹ Duyên", StudentId = "48010104036" },
                new MemberInfo { Name = "Trịnh Trung Hiển", StudentId = "4801104041" },
                new MemberInfo { Name = "Nguyễn Khánh Hoài", StudentId = "4801104047"},
                new MemberInfo { Name = "Nguyễn Trần Thông", StudentId = "4801104131"}
            };

            return View();
        }
    }

    // Helper class for member information
    public class MemberInfo
    {
        public string Name { get; set; }
        public string StudentId { get; set; }
        public string Role { get; set; }
    }
}