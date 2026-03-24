# WebApp - Quản Lý Thư Viện

Ứng dụng web quản lý thư viện được xây dựng bằng ASP.NET Core MVC, Entity Framework Core và MySQL. Repo hiện tại đã có kết nối đến cơ sở dữ liệu `QLTHUVIEN` và đang triển khai rõ nét nhất module quản lý sách.

## Tổng quan

Dự án cung cấp giao diện web để:

- Xem danh sách sách trong thư viện
- Tìm kiếm theo tên sách hoặc ISBN
- Lọc theo thể loại và trạng thái
- Xem chi tiết sách
- Thêm, sửa, xóa sách

Ngoài module `Sách`, `DbContext` đã khai báo thêm nhiều bảng liên quan đến hệ thống thư viện như người dùng, mượn trả, đặt mượn, bài đăng, bình luận, vị trí, tác giả, thể loại, nhà xuất bản...

## Công nghệ sử dụng

- .NET 10 (`net10.0`)
- ASP.NET Core MVC
- Entity Framework Core 10
- MySQL qua gói `MySql.EntityFrameworkCore`
- Bootstrap 5 và Bootstrap Icons

## Cấu trúc thư mục

```text
WebApp/
|-- Controllers/        # HomeController, SachController
|-- Data/               # QuanLyThuVienContext và mapping CSDL
|-- Models/             # Các entity của hệ thống
|-- Views/              # Razor Views
|-- wwwroot/            # CSS, JS, thư viện client-side
|-- Program.cs          # Cấu hình app và pipeline
|-- appsettings.json    # Logging + connection string
|-- WebApp.csproj
```

## Yêu cầu môi trường

Cần chuẩn bị:

- .NET SDK 10.0 trở lên
- MySQL Server
- Một database tên `QLTHUVIEN`

## Cấu hình cơ sở dữ liệu

Chuỗi kết nối mặc định đang nằm trong `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=QLTHUVIEN;User=root"
}
```

Bạn nên cập nhật lại cho phù hợp với máy local, ví dụ:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Port=3306;Database=QLTHUVIEN;User=root;Password=your_password;"
}
```

Lưu ý:

- Repo hiện chưa có thư mục `Migrations`
- Repo cũng chưa kèm file `.sql` khởi tạo schema
- `QuanLyThuVienContext` cho thấy dự án đang được scaffold từ một cơ sở dữ liệu đã tồn tại

Nếu bạn clone repo vào máy mới, cần tạo sẵn database/schema `QLTHUVIEN` và các bảng tương ứng trước khi chạy ứng dụng.

## Cách chạy dự án

1. Khôi phục package:

```bash
dotnet restore
```

2. Build dự án:

```bash
dotnet build
```

3. Chạy ứng dụng:

```bash
dotnet run
```

Sau khi chạy, mở URL được in ra trong terminal, thường là:

- `http://localhost:xxxx`
- `https://localhost:xxxx`

## Tính năng hiện có

### 1. Trang chủ

- Route: `/`
- Đang sử dụng giao diện mặc định của ASP.NET Core MVC

### 2. Quản lý sách

- Route: `/Sach`
- Danh sách sách kèm hình ảnh, ISBN, thể loại, nhà xuất bản, số lượng, trạng thái
- Tìm kiếm theo tiêu đề hoặc mã ISBN
- Lọc theo thể loại
- Lọc theo trạng thái
- Thêm sách mới qua form nhập liệu
- Chỉnh sửa thông tin sách
- Xem chi tiết sách
- Xóa sách

## Một số file quan trọng

- `Program.cs`: đăng ký MVC, `DbContext` và route mặc định
- `Data/QuanLyThuVienContext.cs`: ánh xạ bảng/quan hệ trong MySQL
- `Controllers/SachController.cs`: xử lý CRUD và bộ lọc sách
- `Views/Sach/Index.cshtml`: giao diện danh sách sách
- `Views/Sach/Create.cshtml`: form thêm sách

## Kiểm tra nhanh

Mình đã xác nhận repo build thành công bằng lệnh:

```bash
dotnet build
```

Kết quả: `Build succeeded.`

## Hướng phát triển tiếp

Nếu tiếp tục mở rộng dự án, nên ưu tiên:

- Thêm `Migrations` hoặc file SQL khởi tạo CSDL
- Bổ sung module tác giả, thể loại, nhà xuất bản, mượn trả
- Thêm validation và thông báo lỗi thân thiện hơn
- Hoàn thiện trang chủ và điều hướng hệ thống
- Viết README cho deployment và seed dữ liệu mẫu

## Giấy phép

Repo có file `LICENSE`.
