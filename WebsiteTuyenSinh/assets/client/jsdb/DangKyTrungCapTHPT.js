var DangKyTrungCapTHPTjs = {
    init: function () {
        DangKyTrungCapTHPTjs.registerEvent();
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
            var NgheID = $('#NgheID').val();

            var DiemLop10 = $('#DiemLop10').val();
            var DiemLop11 = $('#DiemLop11').val();
            var DiemLop12 = $('#DiemLop12').val();

            if (NgheID === 0 || HoTen === '' || NgaySinh === '' || HKTT === '' || DiaChi === '' || DienThoai === '' || TenTruongTotNghiep === '' || DiemLop10 === '' || DiemLop11 === '' || DiemLop12 === '') {
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
            else if (parseFloat(DiemLop10) < 0 || parseFloat(DiemLop10) > 10 || parseFloat(DiemLop11) < 0 || parseFloat(DiemLop11) > 10 || parseFloat(DiemLop12) < 0 || parseFloat(DiemLop12) > 10) {
                $.toast({
                    heading: 'Thông báo',
                    text: 'Nhập điểm trung bình không đúng',
                    position: 'top-right',
                    loaderBg: '#ff6849',
                    icon: 'error',
                    hideAfter: 4000,
                    stack: 6
                });
            }
            else {
                $(".btnDangKy").attr("disabled", "disabled");
                DangKyTrungCapTHPTjs.saveData();
            }
        });

        $('#DiemLop10').off('change').on('change', function (e) {
            DangKyTrungCapTHPTjs.TongDiem();
        });
        $('#DiemLop11').off('change').on('change', function (e) {
            DangKyTrungCapTHPTjs.TongDiem();
        });
        $('#DiemLop12').off('change').on('change', function (e) {
            DangKyTrungCapTHPTjs.TongDiem();
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
            TruongTotNghiep: $('#TenTruongTotNghiep').val(),
            DiemLop10: $('#DiemLop10').val(),
            DiemLop11: $('#DiemLop11').val(),
            DiemLop12: $('#DiemLop12').val(),
            isCaoDang: false,
            TrangThai: parseFloat($('#DiemLop10').val()) + parseFloat($('#DiemLop11').val()) + parseFloat($('#DiemLop12').val()) >= 15 ? true : false,
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
            url: '/dangky/TrungCapTHPT',
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
                                    DangKyTrungCapTHPTjs.resetForm();
                                }
                            },
                            confirm: {
                                label: '<i class="fa fa-check"></i> Đồng ý',
                                className: 'btn btn-success',
                                callback: function () {
                                    window.location.href = '/ket-qua/tim-kiem?hoten=' + model.HoTen + '&ngaysinh=' + model.NgaySinh + '&hedangky=trung-cap-thpt';
                                }
                            }
                        },
                        callback: function () {
                            DangKyTrungCapTHPTjs.resetForm();
                        }
                    });
                }
            }
        });
    },
    TongDiem: function () {
        var DiemLop10 = parseFloat($('#DiemLop10').val() !== "" ? $('#DiemLop10').val() : 0);
        var DiemLop11 = parseFloat($('#DiemLop11').val() !== "" ? $('#DiemLop11').val() : 0);
        var DiemLop12 = parseFloat($('#DiemLop12').val() !== "" ? $('#DiemLop12').val() : 0);
        $('#lblTongDiem').text((DiemLop10 + DiemLop11 + DiemLop12).toFixed(1) + "");
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
        $('#DiemLop10').val('');
        $('#DiemLop11').val('');
        $('#DiemLop12').val('');
        $('#lblTongDiem').text('0');
        $(".btnDangKy").removeAttr("disabled");
    }
};

DangKyTrungCapTHPTjs.init();