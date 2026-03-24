-- ============================================
-- HỆ THỐNG QUẢN LÝ THƯ VIỆN - DỮ LIỆU MẪU
-- ============================================

USE quan_ly_thu_vien;

-- ============================================
-- 1. NGƯỜI DÙNG
-- ============================================
INSERT INTO nguoi_dung (ho_ten, gioi_tinh, ngay_sinh, cccd, email, sdt, dia_chi, ma_so_the, loai_the, hinh_anh, ngay_tao, ngay_het_han, ngay_khoa_the, li_do_khoa, ngay_thay_doi, li_do_thay_doi, danh_tieng, quyen, trang_thai) VALUES
('Nguyễn Văn An',    'Nam',  '1995-03-15 00:00:00', '079095001234', 'an.nguyen@gmail.com',    '0901234567', '123 Lê Lợi, Q.1, TP.HCM',          'TV-2024-0001', 'Sinh viên',  NULL, '2024-01-10 08:00:00', '2025-12-31 23:59:59', NULL, NULL, NULL, NULL, 100, 'doc_gia',    'Hoạt động'),
('Trần Thị Bích',    'Nữ',   '1998-07-22 00:00:00', '079098002345', 'bich.tran@gmail.com',    '0912345678', '45 Nguyễn Huệ, Q.1, TP.HCM',       'TV-2024-0002', 'Sinh viên',  NULL, '2024-02-05 09:30:00', '2025-12-31 23:59:59', NULL, NULL, NULL, NULL, 85,  'doc_gia',    'Hoạt động'),
('Lê Minh Cường',    'Nam',  '1990-11-08 00:00:00', '079090003456', 'cuong.le@yahoo.com',     '0923456789', '78 Trần Hưng Đạo, Q.5, TP.HCM',    'TV-2024-0003', 'Giảng viên', NULL, '2024-01-15 10:00:00', '2026-06-30 23:59:59', NULL, NULL, NULL, NULL, 150, 'doc_gia',    'Hoạt động'),
('Phạm Thị Dung',    'Nữ',   '2000-04-30 00:00:00', '079000004567', 'dung.pham@gmail.com',    '0934567890', '12 Hai Bà Trưng, Q.3, TP.HCM',     'TV-2024-0004', 'Sinh viên',  NULL, '2024-03-01 08:15:00', '2025-12-31 23:59:59', '2024-09-15 00:00:00', 'Trả sách trễ nhiều lần', NULL, NULL, 20, 'doc_gia', 'Bị khóa'),
('Hoàng Văn Em',     'Nam',  '1988-12-25 00:00:00', '079088005678', 'em.hoang@outlook.com',   '0945678901', '90 Võ Văn Tần, Q.3, TP.HCM',       'TV-2024-0005', 'Nghiên cứu sinh', NULL, '2024-01-20 14:00:00', '2026-12-31 23:59:59', NULL, NULL, NULL, NULL, 200, 'doc_gia', 'Hoạt động'),
('Võ Thị Phương',    'Nữ',   '1992-06-18 00:00:00', '079092006789', 'phuong.vo@gmail.com',    '0956789012', '34 Pasteur, Q.1, TP.HCM',           'TV-2024-0006', 'Giảng viên', NULL, '2024-02-10 09:00:00', '2026-06-30 23:59:59', NULL, NULL, NULL, NULL, 120, 'doc_gia', 'Hoạt động'),
('Đặng Quốc Giang',  'Nam',  '1985-09-05 00:00:00', '079085007890', 'giang.dang@gmail.com',   '0967890123', '56 Nam Kỳ Khởi Nghĩa, Q.1, TP.HCM','TV-2024-0007', 'Nhân viên',  NULL, '2024-01-02 07:30:00', '2026-12-31 23:59:59', NULL, NULL, NULL, NULL, 0,   'thu_thu',    'Hoạt động'),
('Ngô Thị Hương',    'Nữ',   '1993-01-12 00:00:00', '079093008901', 'huong.ngo@gmail.com',    '0978901234', '67 Điện Biên Phủ, Bình Thạnh, TP.HCM', 'TV-2024-0008', 'Nhân viên', NULL, '2024-01-02 07:30:00', '2026-12-31 23:59:59', NULL, NULL, NULL, NULL, 0, 'thu_thu', 'Hoạt động'),
('Bùi Thanh Inh',    'Nam',  '2001-08-20 00:00:00', '079001009012', 'inh.bui@gmail.com',      '0989012345', '23 Cách Mạng Tháng 8, Q.10, TP.HCM','TV-2024-0009', 'Sinh viên',  NULL, '2024-04-12 11:00:00', '2025-12-31 23:59:59', NULL, NULL, NULL, NULL, 60,  'doc_gia',    'Hoạt động'),
('Lý Thị Kim',       'Nữ',   '1997-02-14 00:00:00', '079097010123', 'kim.ly@gmail.com',       '0990123456', '89 Nguyễn Thị Minh Khai, Q.1, TP.HCM','TV-2024-0010','Sinh viên', NULL, '2024-05-20 10:30:00', '2025-12-31 23:59:59', NULL, NULL, NULL, NULL, 75,  'doc_gia',    'Hoạt động'),
('Admin Thư Viện',   'Nam',  '1980-01-01 00:00:00', '079080000001', 'admin@thuvien.edu.vn',   '0900000001', 'Thư viện Trung tâm, TP.HCM',        'TV-ADMIN-001', 'Quản trị',   NULL, '2024-01-01 00:00:00', '2030-12-31 23:59:59', NULL, NULL, NULL, NULL, 0,   'admin',      'Hoạt động');

-- ============================================
-- 2. TÁC GIẢ
-- ============================================
INSERT INTO tac_gia (ten, ngay_sinh, que_huong) VALUES
('Nguyễn Nhật Ánh',       '1955-05-07 00:00:00', 'Quảng Nam'),
('Tô Hoài',               '1920-09-27 00:00:00', 'Hà Nội'),
('Nam Cao',                '1915-10-29 00:00:00', 'Hà Nam'),
('Nguyễn Du',              '1766-01-03 00:00:00', 'Hà Tĩnh'),
('Vũ Trọng Phụng',        '1912-10-20 00:00:00', 'Hà Nội'),
('Robert C. Martin',      '1952-12-05 00:00:00', 'Hoa Kỳ'),
('Martin Fowler',         '1963-12-18 00:00:00', 'Anh'),
('Thomas H. Cormen',      '1956-01-01 00:00:00', 'Hoa Kỳ'),
('Andrew S. Tanenbaum',   '1944-03-16 00:00:00', 'Hoa Kỳ'),
('Yuval Noah Harari',     '1976-02-24 00:00:00', 'Israel'),
('Dale Carnegie',         '1888-11-24 00:00:00', 'Hoa Kỳ'),
('Nguyễn Hữu Thọ',       '1975-06-10 00:00:00', 'TP.HCM');

-- ============================================
-- 3. THỂ LOẠI
-- ============================================
-- Thể loại cha
INSERT INTO the_loai (id, ten, the_loai_cha, trang_thai) VALUES
(1,  'Văn học',            NULL, 'Hoạt động'),
(2,  'Khoa học - Công nghệ', NULL, 'Hoạt động'),
(3,  'Kinh tế - Xã hội',  NULL, 'Hoạt động'),
(4,  'Giáo trình',         NULL, 'Hoạt động'),
(5,  'Kỹ năng sống',       NULL, 'Hoạt động');

-- Thể loại con
INSERT INTO the_loai (id, ten, the_loai_cha, trang_thai) VALUES
(6,  'Tiểu thuyết',        1,  'Hoạt động'),
(7,  'Truyện ngắn',        1,  'Hoạt động'),
(8,  'Thơ ca',             1,  'Hoạt động'),
(9,  'Công nghệ thông tin', 2,  'Hoạt động'),
(10, 'Toán học',           2,  'Hoạt động'),
(11, 'Vật lý',            2,  'Hoạt động'),
(12, 'Quản trị kinh doanh', 3,  'Hoạt động'),
(13, 'Tài chính',         3,  'Hoạt động'),
(14, 'Lập trình',         4,  'Hoạt động'),
(15, 'Mạng máy tính',     4,  'Hoạt động'),
(16, 'Phát triển bản thân', 5,  'Hoạt động');

-- ============================================
-- 4. NHÀ XUẤT BẢN
-- ============================================
INSERT INTO nha_xuat_ban (ten, dia_chi, sdt, email, website, ghi_chu, trang_thai) VALUES
('NXB Trẻ',               '161B Lý Chính Thắng, Q.3, TP.HCM',     '02839316289', 'info@nxbtre.com.vn',       'https://www.nxbtre.com.vn',    'Nhà xuất bản hàng đầu Việt Nam', 'Hoạt động'),
('NXB Kim Đồng',          '55 Quang Trung, Hai Bà Trưng, Hà Nội', '02439434730', 'info@nxbkimdong.com.vn',   'https://www.nxbkimdong.com.vn', NULL, 'Hoạt động'),
('NXB Giáo Dục',          '81 Trần Hưng Đạo, Hoàn Kiếm, Hà Nội', '02438222235', 'info@nxbgd.vn',            'https://www.nxbgd.vn',         'Chuyên giáo trình', 'Hoạt động'),
('NXB Tổng hợp TP.HCM',  '62 Nguyễn Thị Minh Khai, Q.1, TP.HCM', '02838225340', 'info@nxbhcm.com.vn',       'https://www.nxbhcm.com.vn',    NULL, 'Hoạt động'),
('NXB Đại học Quốc gia',  'Khu phố 6, Linh Trung, Thủ Đức, TP.HCM','02837242181','info@vnuhcmpress.edu.vn',  'https://www.vnuhcmpress.edu.vn', 'Giáo trình đại học', 'Hoạt động'),
('Pearson Education',     'London, United Kingdom',                  NULL,          'support@pearson.com',      'https://www.pearson.com',       'Sách quốc tế', 'Hoạt động'),
('O\'Reilly Media',       'Sebastopol, California, USA',             NULL,          'info@oreilly.com',         'https://www.oreilly.com',       'Sách CNTT quốc tế', 'Hoạt động');

-- ============================================
-- 5. SÁCH
-- ============================================
INSERT INTO sach (tieu_de, ma_isbn, slug, ban_mem, nam_xuat_ban, phien_ban, gia_tien, so_trang, ngon_ngu, mo_ta, hinh_anh, so_luong_nhap, so_luong_ton, so_luong_cho_muon, trang_thai, theloai_id, nhaxuatban_id) VALUES
('Mắt Biếc',                          '978-604-1-12345-1', 'mat-biec',                    NULL, '2019', 'Tái bản lần 5',  85000,  300, 'Tiếng Việt', 'Câu chuyện tình yêu trong sáng thời học trò tại một ngôi làng nhỏ miền Trung.',                    '/images/mat-biec.jpg',           10, 7, 3,  'Hoạt động', 6,  1),
('Tôi Thấy Hoa Vàng Trên Cỏ Xanh',   '978-604-1-12345-2', 'toi-thay-hoa-vang',           NULL, '2018', 'Tái bản lần 3',  75000,  280, 'Tiếng Việt', 'Tuổi thơ trong trẻo ở miền quê qua con mắt của hai anh em Thiều và Tường.',                        '/images/hoa-vang.jpg',           8,  5, 2,  'Hoạt động', 6,  1),
('Dế Mèn Phiêu Lưu Ký',              '978-604-2-12345-3', 'de-men-phieu-luu-ky',         NULL, '2020', 'Tái bản lần 10', 55000,  200, 'Tiếng Việt', 'Hành trình phiêu lưu của chú Dế Mèn qua thế giới côn trùng đầy sinh động.',                       '/images/de-men.jpg',             15, 12, 3, 'Hoạt động', 6,  2),
('Chí Phèo',                          '978-604-2-12345-4', 'chi-pheo',                    NULL, '2021', 'Tái bản lần 8',  45000,  150, 'Tiếng Việt', 'Bi kịch của người nông dân bị tha hóa trong xã hội phong kiến.',                                    '/images/chi-pheo.jpg',           12, 10, 2, 'Hoạt động', 7,  2),
('Truyện Kiều',                       '978-604-3-12345-5', 'truyen-kieu',                 NULL, '2022', 'Tái bản lần 20', 120000, 400, 'Tiếng Việt', 'Kiệt tác văn học Việt Nam - truyện thơ lục bát kể về cuộc đời nàng Kiều.',                         '/images/truyen-kieu.jpg',        20, 18, 2, 'Hoạt động', 8,  4),
('Số Đỏ',                             '978-604-1-12345-6', 'so-do',                       NULL, '2020', 'Tái bản lần 6',  65000,  250, 'Tiếng Việt', 'Tiểu thuyết trào phúng phê phán xã hội Việt Nam thời Pháp thuộc.',                                 '/images/so-do.jpg',              8,  6, 1,  'Hoạt động', 6,  1),
('Clean Code',                        '978-0-13-235088-4', 'clean-code',                  '/ebooks/clean-code.pdf', '2008', '1st Edition', 350000, 464, 'Tiếng Anh', 'A Handbook of Agile Software Craftsmanship. Hướng dẫn viết code sạch, dễ bảo trì.',               '/images/clean-code.jpg',         5,  3, 2,  'Hoạt động', 14, 6),
('Refactoring',                       '978-0-13-475759-9', 'refactoring',                 '/ebooks/refactoring.pdf', '2018', '2nd Edition', 400000, 418, 'Tiếng Anh', 'Improving the Design of Existing Code. Kỹ thuật cải thiện mã nguồn.',                             '/images/refactoring.jpg',        4,  3, 1,  'Hoạt động', 14, 6),
('Introduction to Algorithms',        '978-0-26-204630-5', 'intro-to-algorithms',         NULL, '2022', '4th Edition', 500000, 1312, 'Tiếng Anh', 'Giáo trình kinh điển về thuật toán và cấu trúc dữ liệu (CLRS).',                                  '/images/clrs.jpg',               6,  5, 1,  'Hoạt động', 9,  6),
('Computer Networks',                 '978-0-13-288552-8', 'computer-networks',           NULL, '2021', '6th Edition', 450000, 960,  'Tiếng Anh', 'Giáo trình mạng máy tính toàn diện của Tanenbaum.',                                                '/images/computer-networks.jpg',  4,  3, 1,  'Hoạt động', 15, 6),
('Sapiens: Lược Sử Loài Người',      '978-604-1-12345-7', 'sapiens',                     NULL, '2020', 'Bản dịch lần 2', 180000, 550, 'Tiếng Việt', 'Hành trình 70.000 năm của loài người từ loài vượn đến chủ nhân thế giới.',                         '/images/sapiens.jpg',            10, 8, 2,  'Hoạt động', 12, 1),
('Đắc Nhân Tâm',                     '978-604-1-12345-8', 'dac-nhan-tam',                NULL, '2021', 'Bản dịch lần 15', 90000, 320, 'Tiếng Việt', 'Nghệ thuật giao tiếp và ứng xử trong cuộc sống.',                                                 '/images/dac-nhan-tam.jpg',       20, 15, 5, 'Hoạt động', 16, 1),
('Nhập Môn Lập Trình Python',        '978-604-5-12345-9', 'nhap-mon-lap-trinh-python',   '/ebooks/python.pdf', '2023', 'Xuất bản lần 1', 150000, 400, 'Tiếng Việt', 'Giáo trình lập trình Python dành cho sinh viên năm nhất.',                                        '/images/python.jpg',             15, 12, 3, 'Hoạt động', 14, 5),
('Cơ Sở Dữ Liệu',                   '978-604-5-12345-0', 'co-so-du-lieu',               '/ebooks/csdl.pdf', '2022', 'Xuất bản lần 2', 130000, 350, 'Tiếng Việt', 'Giáo trình cơ sở dữ liệu quan hệ dành cho sinh viên CNTT.',                                       '/images/csdl.jpg',               12, 10, 2, 'Hoạt động', 14, 5),
('Toán Cao Cấp A1',                  '978-604-5-12345-A', 'toan-cao-cap-a1',             NULL, '2021', 'Xuất bản lần 5', 95000,  280, 'Tiếng Việt', 'Giáo trình Toán cao cấp phần Đại số tuyến tính và Giải tích.',                                    '/images/toan-a1.jpg',            20, 18, 2, 'Hoạt động', 10, 3);

-- ============================================
-- 6. SÁCH - TÁC GIẢ
-- ============================================
INSERT INTO sach_tacgia (sach_id, tac_gia_id, vai_tro, thu_tu) VALUES
(1,  1,  'Tác giả',     1),
(2,  1,  'Tác giả',     1),
(3,  2,  'Tác giả',     1),
(4,  3,  'Tác giả',     1),
(5,  4,  'Tác giả',     1),
(6,  5,  'Tác giả',     1),
(7,  6,  'Tác giả',     1),
(8,  7,  'Tác giả',     1),
(9,  8,  'Tác giả',     1),
(10, 9,  'Tác giả',     1),
(11, 10, 'Tác giả',     1),
(12, 11, 'Tác giả',     1),
(13, 12, 'Tác giả',     1),
(14, 12, 'Tác giả',     1),
(15, 12, 'Tác giả',     1);

-- ============================================
-- 7. VỊ TRÍ
-- ============================================
INSERT INTO vi_tri (gia_sach, phong, tang, khu_vuc) VALUES
('A-01', 'Phòng đọc 1',     'Tầng 1', 'Khu A - Văn học Việt Nam'),
('A-02', 'Phòng đọc 1',     'Tầng 1', 'Khu A - Văn học Việt Nam'),
('A-03', 'Phòng đọc 1',     'Tầng 1', 'Khu A - Văn học Việt Nam'),
('B-01', 'Phòng đọc 2',     'Tầng 2', 'Khu B - CNTT & Khoa học'),
('B-02', 'Phòng đọc 2',     'Tầng 2', 'Khu B - CNTT & Khoa học'),
('B-03', 'Phòng đọc 2',     'Tầng 2', 'Khu B - CNTT & Khoa học'),
('C-01', 'Phòng giáo trình','Tầng 3', 'Khu C - Giáo trình'),
('C-02', 'Phòng giáo trình','Tầng 3', 'Khu C - Giáo trình'),
('D-01', 'Phòng tổng hợp',  'Tầng 1', 'Khu D - Sách tổng hợp'),
('D-02', 'Phòng tổng hợp',  'Tầng 1', 'Khu D - Sách tổng hợp');

-- ============================================
-- 8. ĐĂNG KÝ CÁ BIỆT
-- ============================================
INSERT INTO dang_ky_ca_biet (ma_ca_biet, tinh_trang, trang_thai, ngay_cho_muon, ngay_nhan_sach, ghi_chu, vitri_id, sach_id) VALUES
('CB-0001', 'Mới',       'Sẵn sàng',    NULL,                        '2024-01-15 00:00:00', NULL,                    1,  1),
('CB-0002', 'Mới',       'Đang mượn',    '2024-10-01 00:00:00',       '2024-01-15 00:00:00', NULL,                    1,  1),
('CB-0003', 'Tốt',       'Sẵn sàng',    NULL,                        '2024-01-15 00:00:00', NULL,                    1,  2),
('CB-0004', 'Tốt',       'Đang mượn',    '2024-10-05 00:00:00',       '2024-01-15 00:00:00', NULL,                    1,  2),
('CB-0005', 'Mới',       'Sẵn sàng',    NULL,                        '2024-02-01 00:00:00', NULL,                    2,  3),
('CB-0006', 'Cũ',        'Sẵn sàng',    NULL,                        '2020-06-01 00:00:00', 'Bìa hơi cũ',           2,  3),
('CB-0007', 'Tốt',       'Sẵn sàng',    NULL,                        '2024-03-01 00:00:00', NULL,                    2,  4),
('CB-0008', 'Mới',       'Sẵn sàng',    NULL,                        '2024-03-01 00:00:00', NULL,                    3,  5),
('CB-0009', 'Tốt',       'Đang mượn',    '2024-10-10 00:00:00',       '2024-01-20 00:00:00', NULL,                    4,  7),
('CB-0010', 'Mới',       'Sẵn sàng',    NULL,                        '2024-02-10 00:00:00', NULL,                    4,  8),
('CB-0011', 'Tốt',       'Sẵn sàng',    NULL,                        '2024-02-10 00:00:00', NULL,                    5,  9),
('CB-0012', 'Mới',       'Đang mượn',    '2024-10-12 00:00:00',       '2024-04-01 00:00:00', NULL,                    5,  10),
('CB-0013', 'Mới',       'Sẵn sàng',    NULL,                        '2024-05-01 00:00:00', NULL,                    9,  11),
('CB-0014', 'Tốt',       'Sẵn sàng',    NULL,                        '2024-05-01 00:00:00', NULL,                    9,  12),
('CB-0015', 'Mới',       'Sẵn sàng',    NULL,                        '2024-06-01 00:00:00', NULL,                    7,  13),
('CB-0016', 'Tốt',       'Đang mượn',    '2024-10-15 00:00:00',       '2024-06-01 00:00:00', NULL,                    7,  14),
('CB-0017', 'Mới',       'Sẵn sàng',    NULL,                        '2024-06-15 00:00:00', NULL,                    8,  15),
('CB-0018', 'Hư hỏng',   'Thanh lý',    NULL,                        '2020-01-01 00:00:00', 'Rách nhiều trang',      2,  3),
('CB-0019', 'Mới',       'Sẵn sàng',    NULL,                        '2024-07-01 00:00:00', NULL,                    10, 6),
('CB-0020', 'Tốt',       'Sẵn sàng',    NULL,                        '2024-07-01 00:00:00', NULL,                    10, 12);

-- ============================================
-- 9. ĐẶT MƯỢN
-- ============================================
INSERT INTO dat_muon (ngay_tao, ngay_het_han, ngay_lay, trang_thai, ghi_chu, ngay_duyet, sach_id, nguoidung_id) VALUES
('2024-10-01 08:00:00', '2024-10-03 23:59:59', '2024-10-02 09:00:00', 'Đã lấy sách',   NULL,                          '2024-10-01 10:00:00', 1,  1),
('2024-10-03 14:00:00', '2024-10-05 23:59:59', '2024-10-04 10:30:00', 'Đã lấy sách',   NULL,                          '2024-10-03 15:00:00', 7,  3),
('2024-10-05 09:00:00', '2024-10-07 23:59:59', '2024-10-06 08:00:00', 'Đã lấy sách',   NULL,                          '2024-10-05 11:00:00', 2,  2),
('2024-10-10 10:00:00', '2024-10-12 23:59:59', '2024-10-11 14:00:00', 'Đã lấy sách',   NULL,                          '2024-10-10 12:00:00', 10, 5),
('2024-10-15 11:00:00', '2024-10-17 23:59:59', NULL,                  'Chờ duyệt',     'Muốn mượn để làm luận văn',   '2024-10-15 14:00:00', 14, 6),
('2024-10-18 08:30:00', '2024-10-20 23:59:59', NULL,                  'Đã duyệt',      NULL,                          '2024-10-18 09:00:00', 12, 9),
('2024-10-20 16:00:00', '2024-10-22 23:59:59', NULL,                  'Chờ duyệt',     NULL,                          '2024-10-20 16:00:00', 3,  10),
('2024-10-22 09:00:00', '2024-10-24 23:59:59', NULL,                  'Đã hủy',        'Người dùng tự hủy',           '2024-10-22 10:00:00', 5,  1);

-- ============================================
-- 10. MƯỢN TRẢ
-- ============================================
INSERT INTO muon_tra (loai, ngay_tao, han_tra, ngay_tra, tien_phat, trang_thai, ghi_chu, dkcb_id, nguoi_dung_id) VALUES
('Mượn về',    '2024-10-02 09:00:00', '2024-10-16 23:59:59', '2024-10-14 10:00:00', 0,     'Đã trả',     NULL,                          2,  1),
('Mượn về',    '2024-10-04 10:30:00', '2024-10-18 23:59:59', NULL,                  0,     'Đang mượn',   NULL,                          9,  3),
('Đọc tại chỗ','2024-10-05 08:00:00', '2024-10-05 17:00:00', '2024-10-05 16:30:00', 0,     'Đã trả',     NULL,                          3,  2),
('Mượn về',    '2024-10-06 08:00:00', '2024-10-20 23:59:59', NULL,                  0,     'Đang mượn',   NULL,                          4,  2),
('Mượn về',    '2024-10-11 14:00:00', '2024-10-25 23:59:59', NULL,                  0,     'Đang mượn',   NULL,                          12, 5),
('Mượn về',    '2024-09-01 09:00:00', '2024-09-15 23:59:59', '2024-09-20 10:00:00', 25000, 'Đã trả',     'Trả trễ 5 ngày, phạt 5k/ngày', 14, 10),
('Mượn về',    '2024-10-15 09:00:00', '2024-10-29 23:59:59', NULL,                  0,     'Đang mượn',   NULL,                          16, 6),
('Đọc tại chỗ','2024-10-18 10:00:00', '2024-10-18 17:00:00', '2024-10-18 15:00:00', 0,     'Đã trả',     NULL,                          8,  9),
('Mượn về',    '2024-08-01 08:00:00', '2024-08-15 23:59:59', '2024-08-30 09:00:00', 75000, 'Đã trả',     'Trả trễ 15 ngày, phạt 5k/ngày', 5, 4),
('Mượn về',    '2024-07-10 10:00:00', '2024-07-24 23:59:59', '2024-07-23 14:00:00', 0,     'Đã trả',     'Trả đúng hạn',                13, 1);

-- ============================================
-- 11. FORM GÓP Ý
-- ============================================
INSERT INTO form_gop_y (ho_ten, lien_he, noi_dung, ngay_tao, nguoi_dung_id) VALUES
('Nguyễn Văn An',    'an.nguyen@gmail.com',  'Thư viện nên mở cửa thêm ngày Chủ nhật để sinh viên có thể đến học.',                  '2024-09-15', 1),
('Trần Thị Bích',    '0912345678',           'Khu vực đọc sách tầng 2 thiếu ổ cắm điện, mong thư viện bổ sung thêm.',               '2024-09-20', 2),
('Lê Minh Cường',    'cuong.le@yahoo.com',   'Đề xuất bổ sung thêm sách chuyên ngành AI và Machine Learning.',                       '2024-10-01', 3),
('Bùi Thanh Inh',    '0989012345',           'Máy tính khu tra cứu tầng 1 bị lỗi, không tra được sách.',                             '2024-10-10', 9),
('Lý Thị Kim',       'kim.ly@gmail.com',     'Hệ thống mượn sách online rất tiện lợi, cảm ơn thư viện!',                             '2024-10-15', 10);

-- ============================================
-- 12. CHỦ ĐỀ (DIỄN ĐÀN)
-- ============================================
INSERT INTO chu_de (tieu_de, mo_ta, ngay_tao, so_luong_xem, trang_thai, nguoi_dung_id) VALUES
('Gợi ý sách hay cho sinh viên CNTT năm nhất',           'Chia sẻ những cuốn sách nên đọc khi mới vào ngành CNTT.',                  '2024-09-01 10:00:00', 256, 'Hoạt động', 3),
('Review sách Mắt Biếc - Nguyễn Nhật Ánh',               'Cùng thảo luận về cuốn tiểu thuyết nổi tiếng của Nguyễn Nhật Ánh.',        '2024-09-10 14:30:00', 189, 'Hoạt động', 1),
('Tìm sách về thuật toán và cấu trúc dữ liệu',          'Cần tìm sách hay về thuật toán, các bạn có gợi ý không?',                  '2024-09-15 09:00:00', 134, 'Hoạt động', 9),
('Thư viện nên tổ chức câu lạc bộ đọc sách',             'Đề xuất thành lập CLB đọc sách hàng tuần tại thư viện.',                    '2024-10-01 16:00:00', 78,  'Hoạt động', 2),
('Chia sẻ kinh nghiệm đọc sách hiệu quả',               'Các tips và phương pháp đọc sách nhanh mà vẫn nhớ lâu.',                   '2024-10-05 11:00:00', 95,  'Hoạt động', 5);

-- ============================================
-- 13. BÀI ĐĂNG
-- ============================================
INSERT INTO bai_dang (noi_dung, ngay_tao, so_luong_binh_luan, trang_thai, nguoi_dung_id, chude_id) VALUES
('Mình recommend cuốn Clean Code của Robert C. Martin. Sách dạy cách viết code sạch, rất cần thiết cho ai muốn đi theo hướng Software Engineering.',
 '2024-09-01 10:15:00', 3, 'Hoạt động', 3, 1),

('Ngoài ra còn cuốn Introduction to Algorithms (CLRS) nữa. Hơi dày nhưng kiến thức rất nền tảng, ai học thuật toán cũng nên có.',
 '2024-09-01 11:00:00', 2, 'Hoạt động', 5, 1),

('Mắt Biếc là cuốn sách mình đọc đi đọc lại không chán. Tình yêu đơn phương của Ngạn thật sự rất xúc động.',
 '2024-09-10 14:45:00', 2, 'Hoạt động', 1, 2),

('Mình thấy bản phim cũng hay nhưng sách hay hơn nhiều. Đọc sách mới cảm nhận hết được nội tâm nhân vật.',
 '2024-09-10 16:00:00', 1, 'Hoạt động', 2, 2),

('Các bạn thử cuốn "Giải thuật và lập trình" của thầy Lê Minh Hoàng xem. Sách Việt Nam mà viết rất hay, dễ hiểu.',
 '2024-09-15 09:30:00', 1, 'Hoạt động', 9, 3),

('Ý tưởng hay lắm! Mình sẵn sàng tham gia. Mỗi tuần đọc 1 cuốn rồi cùng thảo luận thì tuyệt vời.',
 '2024-10-01 16:30:00', 1, 'Hoạt động', 6, 4),

('Mình áp dụng phương pháp Pomodoro khi đọc sách: đọc 25 phút, nghỉ 5 phút. Hiệu quả lắm các bạn!',
 '2024-10-05 11:30:00', 2, 'Hoạt động', 5, 5),

('Mình thì hay ghi chú lại những ý chính bằng sơ đồ tư duy (mind map). Giúp nhớ lâu hơn rất nhiều.',
 '2024-10-05 12:00:00', 0, 'Hoạt động', 10, 5);

-- ============================================
-- 14. BÌNH LUẬN
-- ============================================
INSERT INTO binh_luan (noi_dung, ngay_tao, trang_thai, nguoi_dung_id, bai_dang_id) VALUES
('Đồng ý! Clean Code là cuốn sách kinh điển. Mình đọc xong thay đổi hoàn toàn cách viết code.',
 '2024-09-01 12:00:00', 'Hoạt động', 1, 1),

('Mình cũng đang đọc cuốn này. Chương về naming convention rất hay.',
 '2024-09-01 14:00:00', 'Hoạt động', 9, 1),

('Cảm ơn anh recommend. Em mới năm nhất, sẽ mua đọc ngay!',
 '2024-09-02 08:00:00', 'Hoạt động', 10, 1),

('CLRS hơi nặng cho năm nhất. Nên bắt đầu bằng cuốn nhẹ hơn trước rồi hãy đọc CLRS.',
 '2024-09-01 13:00:00', 'Hoạt động', 3, 2),

('Đúng rồi, có thể đọc "Grokking Algorithms" trước cho dễ tiếp cận.',
 '2024-09-01 15:00:00', 'Hoạt động', 6, 2),

('Mình cũng team sách. Phim lược bỏ nhiều chi tiết hay trong truyện.',
 '2024-09-10 17:00:00', 'Hoạt động', 10, 3),

('Đoạn cuối truyện buồn quá, mình đọc mà rưng rưng.',
 '2024-09-11 09:00:00', 'Hoạt động', 6, 3),

('Sách của thầy Lê Minh Hoàng mình cũng đọc. Bài tập trong sách rất sát với đề thi Olympic tin học.',
 '2024-09-15 10:30:00', 'Hoạt động', 2, 4),

('Thư viện có cuốn này không nhỉ? Mình muốn mượn.',
 '2024-09-15 14:00:00', 'Hoạt động', 5, 5),

('Mình cũng muốn tham gia! Đề xuất họp tại phòng đọc tầng 1 vào chiều thứ 7 hàng tuần.',
 '2024-10-02 08:00:00', 'Hoạt động', 1, 6),

('Pomodoro hiệu quả thật. Mình còn kết hợp với app Forest để tránh xao nhãng.',
 '2024-10-05 13:00:00', 'Hoạt động', 2, 7),

('Mình hay dùng Notion để ghi chú khi đọc sách. Tiện hơn giấy nhiều.',
 '2024-10-05 14:00:00', 'Hoạt động', 9, 7);
