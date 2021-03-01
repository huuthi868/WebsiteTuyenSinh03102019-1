var DangKyTrungCapTHCSjs = {
    init: function () {
        DangKyTrungCapTHCSjs.registerEvent();
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
            var DiemLop6 = $('#DiemLop6').val();
            var DiemLop7 = $('#DiemLop7').val();
            var DiemLop8 = $('#DiemLop8').val();
            var DiemLop9 = $('#DiemLop9').val();

            if (NgheID === 0 || HoTen === '' || NgaySinh === '' || HKTT === '' || DiaChi === '' || DienThoai === '' || TenTruongTotNghiep === '' || DiemLop6 === '' || DiemLop7 === '' || DiemLop8 === '' || DiemLop9 === '') {
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
            else if (parseFloat(DiemLop6) < 0 || parseFloat(DiemLop6) > 10 || parseFloat(DiemLop7) < 0 || parseFloat(DiemLop7) > 10 || parseFloat(DiemLop8) < 0 || parseFloat(DiemLop8) > 10 || parseFloat(DiemLop9) < 0 || parseFloat(DiemLop9) > 10) {
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
                DangKyTrungCapTHCSjs.saveData();
            }
        });

        $('#DiemLop6').off('change').on('change', function (e) {
            DangKyTrungCapTHCSjs.TongDiem();
        });
        $('#DiemLop7').off('change').on('change', function (e) {
            DangKyTrungCapTHCSjs.TongDiem();
        });
        $('#DiemLop8').off('change').on('change', function (e) {
            DangKyTrungCapTHCSjs.TongDiem();
        });
        $('#DiemLop9').off('change').on('change', function (e) {
            DangKyTrungCapTHCSjs.TongDiem();
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
            DiemLop6: $('#DiemLop6').val(),
            DiemLop7: $('#DiemLop7').val(),
            DiemLop8: $('#DiemLop8').val(),
            DiemLop9: $('#DiemLop9').val(),
            TrangThai: parseFloat($('#DiemLop6').val()) + parseFloat($('#DiemLop7').val()) + parseFloat($('#DiemLop8').val()) + parseFloat($('#DiemLop9').val()) >= 20 ? true : false,
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
            url: '/DangKy/TrungCapTHCS',
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
                                    DangKyTrungCapTHCSjs.resetForm();
                                }
                            },
                            confirm: {
                                label: '<i class="fa fa-check"></i> Đồng ý',
                                className: 'btn btn-success',
                                callback: function () {
                                    window.location.href = '/ket-qua/tim-kiem?hoten=' + model.HoTen + '&ngaysinh=' + model.NgaySinh + '&hedangky=trung-cap-thcs';
                                }
                            }
                        },
                        callback: function () {
                            DangKyTrungCapTHCSjs.resetForm();
                        }
                    });
                }
            }
        });
    },
    TongDiem: function () {
        var DiemLop6 = parseFloat($('#DiemLop6').val() !== "" ? $('#DiemLop6').val() : 0);
        var DiemLop7 = parseFloat($('#DiemLop7').val() !== "" ? $('#DiemLop7').val() : 0);
        var DiemLop8 = parseFloat($('#DiemLop8').val() !== "" ? $('#DiemLop8').val() : 0);
        var DiemLop9 = parseFloat($('#DiemLop9').val() !== "" ? $('#DiemLop9').val() : 0);
        $('#lblTongDiem').text((DiemLop6 + DiemLop7 + DiemLop8 + DiemLop9).toFixed(1) + "");
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
        $('#DiemLop6').val('');
        $('#DiemLop7').val('');
        $('#DiemLop8').val('');
        $('#DiemLop9').val('');
        $('#lblTongDiem').text('0');
        $(".btnDangKy").removeAttr("disabled");
    }
};
DangKyTrungCapTHCSjs.init();