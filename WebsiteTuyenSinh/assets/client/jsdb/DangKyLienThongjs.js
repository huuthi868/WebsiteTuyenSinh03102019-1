var DangKyLienThongjs = {
    init: function () {
        DangKyLienThongjs.registerEvent();
    },
    registerEvent: function () {
        $('.btnDangKy').off('click').on('click', function (e) {
            e.preventDefault();
            var HoTen = $('#HoTen').val();
            var NgaySinh = $('#NgaySinh').val();
            var d = new Date();

            //xử lý ngày sinh
            var ns = NgaySinh.split('/');
            var ngay = new Date(ns[2] + '-' + ns[1] + '-' + ns[0]);
            var nam = parseInt(ns[2]);
            //

            var HKTT = $('#HKTT').val();
            var DiaChi = $('#DiaChi').val();
            var DienThoai = $('#DienThoai').val();
            var TenTruongTotNghiep = $('#TenTruongTotNghiep').val();
            var TenNgheTotNghiep = $('#TenNgheTotNghiep').val();
            var NgheID = $('#NgheID').val();
            var TenTruongTrungCap = $('#TenTruongTrungCap').val();

            if (NgheID === 0 || HoTen === '' || NgaySinh === '' || HKTT === '' || DiaChi === '' || DienThoai === '' || TenTruongTotNghiep === '' || TenNgheTotNghiep === '' || TenTruongTrungCap === '') {
                $.toast({
                    heading: 'Thông báo',
                    text: 'Điền đầy đủ thông tin yêu cầu',
                    position: 'top-right',
                    loaderBg: '#ff6849',
                    icon: 'error',
                    hideAfter: 4000,
                    stack: 6
                });
            }
            else if (ngay === 'Invalid Date' || !(nam >= 1900 && nam <= d.getFullYear() - 15)) {
                $.toast({
                    heading: 'Thông báo',
                    text: 'Nhập ngày, tháng, năm sinh không đúng',
                    position: 'top-right',
                    loaderBg: '#ff6849',
                    icon: 'error',
                    hideAfter: 4000,
                    stack: 6
                });
            }
            else {
                $(".btnDangKy").attr("disabled", "disabled");
                DangKyLienThongjs.saveData();
            }
        });
    },
    saveData: function () {
        var d = new Date();
        var month = d.getMonth() + 1;
        var day = d.getDate();
        var ns = $('#NgaySinh').val().split('/');
        var ngay = parseInt(ns[0]);
        var thang = parseInt(ns[1]);
        var nam = parseInt(ns[2]);

        NgaySinh = (ngay < 10 ? '0' : '') + ngay + '/' + (thang < 10 ? '0' : '') + thang + '/' + nam;

        var model = {
            NgheID: $('#NgheID').val(),
            HoTen: $('#HoTen').val(),
            NgaySinh: NgaySinh,
            GioiTinh: $('#GioiTinh').val() === 1 ? true : false,
            HKTT: $('#HKTT').val(),
            DiaChi: $('#DiaChi').val(),
            SoDienThoai: $('#SoDienThoai').val(),
            Email: $('#Email').val(),
            Facebook: $('#Facebook').val(),
            TruongTotNghiep: $('#TruongTotNghiep').val(),
            TenTruongTrungCap: $('#TenTruongTrungCap').val(),
            TenNgheTotNghiep: $('#TenNgheTotNghiep').val(),
            NamTotNghiep: $('#NamTotNghiep').val(),
            NamTotNghiepTrungCap: $('#NamTotNghiepTrungCap').val(),
            TrangThai: false,
            DangKyOnLine: true,
            HoanThienHoSo: false,
            KichHoat: true,
            NgayTao: (day < 10 ? '0' : '') + day + '/' + (month < 10 ? '0' : '') + month + '/' + d.getFullYear(),
            NguoiTao: 'Guest',
            NgaySua: null,
            NguoiSua: null,
            DaXoa: null,
            NgayXoa: null,
            NguoiXoa: null
        };
        $.ajax({
            url: '/dangky/LienThong',
            data: { model: JSON.stringify(model) },
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    bootbox.dialog({
                        title: "Đăng ký hồ sơ trực tuyến thành công",
                        message: `Chuyển sang trang tra cứu kết quả xét tuyển?`,
                        closeButton: false,
                        buttons: {
                            cancel: {
                                label: '<i class="fa fa-times"></i> Hủy',
                                className: 'btn btn-link pull-right',
                                callback: function () {
                                    DangKyLienThongjs.resetForm();
                                }
                            },
                            confirm: {
                                label: '<i class="fa fa-check"></i> Đồng ý',
                                className: 'btn btn-success',
                                callback: function () {
                                    window.location.href = '/ket-qua/tim-kiem?hoten=' + model.HoTen + '&ngaysinh=' + model.NgaySinh + '&hedangky=lien-thong-cao-dang';
                                }
                            }
                        },
                        callback: function () {
                            DangKyLienThongjs.resetForm();
                        }
                    });
                }
            }
        });
    },
    resetForm: function () {
        $('#NgheID').val(0);
        $('#HoTen').val('');
        $('#NgaySinh').val('');
        $('#GioiTinh').val(0);
        $('#HKTT').val('');
        $('#DiaChi').val('');
        $('#SoDienThoai').val('');
        $('#Email').val('');
        $('#Facebook').val('');
        $('#TenTruongTotNghiep').val('');
        $('#TenTruongTrungCap').val('');
        $('#NamTotNghiep').val('');
        $('#TruongTotNghiep').val('');
        $('#NamTotNghiepTrungCap').val('');
        $('#TenNgheTotNghiep').val('');
    }
};

DangKyLienThongjs.init();