use larstravelapi;

insert into city(Name, Description, Pictures) values(N'TP Hà Nội', N'TP Hà Nội', 'hanoiabc.jpg');
insert into city(Name, Description, Pictures) values(N'TP Nha Trang', N'TP Nha Trang', 'nhatrangabc.jpg');

select * from member_package;
insert into member_package(Name, Description) values(N'Gói cặp đôi', N'Gói cặp đôi');
insert into member_package(Name, Description) values(N'Gói gia đình (Nhỏ)', N'Gói gia đình nhỏ (Từ 3 đến 7 người)');
insert into member_package(Name, Description) values(N'Gói gia đình (Trung)', N'Gói gia đình trung (Từ 8 đến 12 người)');
insert into member_package(Name, Description) values(N'Gói gia đình (Lớn)', N'Gói gia đình lớn (Từ 13 đến 20 người)');

select * from dbo.[user];
INSERT INTO [dbo].[user]([Username],[Password],[Name],[DateOfBirth],[Sex],[Email],[PhoneNumber],[Address])
VALUES ('quangnam@gmail.com','QuangNam',N'Bùi Quang Nam','2001/10/10',N'Nam','quangnam@gmail.com','0362793528',N'Thanh Xuân - Hà Nội')
INSERT INTO [dbo].[user]([Username],[Password],[Name],[DateOfBirth],[Sex],[Email],[PhoneNumber],[Address])
VALUES ('thuylinh@gmail.com','ThuyLinh',N'Nguyễn Ngọc Thùy Linh','2002/10/10',N'Nữ','thuylinh@gmail.com','0367243558',N'Thanh Xuân - Hà Nội')

select * from evaluate;
insert into evaluate(NumberOfEvaluate, MediumStar) values(15, 3.5);
insert into evaluate(NumberOfEvaluate, MediumStar) values(20, 3.8);
insert into evaluate(NumberOfEvaluate, MediumStar) values(80, 4.0);
insert into evaluate(NumberOfEvaluate, MediumStar) values(100, 4.2);


select * from comment;
insert into comment(Content, DateOfComment, UserId, EvaluateId) values(N'Đây là một điểm du lịch tuyệt vời. Tôi sẽ quay trở lại trong tháng tới','2023/10/12',1, 1);
insert into comment(Content, DateOfComment, UserId, EvaluateId) values(N'Đây là một điểm du lịch tuyệt vời. Tôi sẽ quay trở lại trong tháng tới','2023/10/12',2, 2);

select * from hotel;
insert into hotel(Name, Address, PhoneNumber, Description) values(N'Khách sạn Linh San', N'Số 10 - Trần Phú - Hà Đông - Hà Nội','0368989898', N'Khách sạn Linh San');
insert into hotel(Name, Address, PhoneNumber, Description) values(N'Khách sạn Long Trần', N'Số 12 - Trần Phú - Hà Đông - Hà Nội','0368989898', N'Khách sạn Long Trần');


select * from tour;
insert into tour(Name, Address, Description, Pictures, CityId, EvaluateId)
values(N'Hồ Gươm', N'1-8 P. Lê Thái Tổ, Hàng Trống, Hoàn Kiếm, Hà Nội', N'Hồ nước thanh tĩnh có cây cầu bắc qua, đền thờ Nho giáo cùng những bãi cỏ lau và hoa nằm rải rác.',
'hoguomjpg',1,3);
insert into tour(Name, Address, Description, Pictures, CityId, EvaluateId)
values(N'Đền Bạch Mã', N'76 phố Hàng Buồm, quận Hoàn Kiếm, Hà Nội', N'Đền được xây dựng từ thế kỉ thứ 9 và được trùng tu lại dưới thời nhà Nguyễn.',
'denbachmajpg',1,4);

select * from ticket;
insert into ticket(BookingDate, Description, TicketDetailId, TourId, UserId)
values('2023/09/15', Null, 2, 1, 1);
insert into ticket(BookingDate, Description, TicketDetailId, TourId, UserId)
values('2023/09/20', Null, 8, 1, 2);

select * from ticket_detail;
insert into ticket_detail(StartDay, EndDay, Price, Description, MemberPackageId, HotelId)
values('2023/12/10', '2023/12/14', 5000000.00, Null, 1, 1);
insert into ticket_detail(StartDay, EndDay, Price, Description, MemberPackageId, HotelId)
values('2023/12/14', '2023/12/17', 5000000.00, Null, 2, 2);
insert into ticket_detail(StartDay, EndDay, Price, Description, MemberPackageId, HotelId)
values('2023/12/14', '2023/12/17', 5000000.00, Null, 1, 2);