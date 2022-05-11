var GuiCauHoijs = {
    init: function () {
        GuiCauHoijs.registerEvent();
    },
    registerEvent: function () {

        $('#popDangKyBtn').off('click').on('click', function (e) {
            e.preventDefault();

            var HoTen = $('#GROUP3967 #HoTen').val();
            var Email = $('#GROUP3967 #EmailNguoiHoi').val();
            var SoDienThoai = $('#GROUP3967 #SoDienThoai').val();
            var CauHoi = $('#GROUP3967 #CauHoi').val();

            if (HoTen === '' || SoDienThoai === '' || CauHoi === '') {
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
            else {
                $(".popDangKyBtn").attr("disabled", "disabled");
                GuiCauHoijs.saveData(HoTen, Email, SoDienThoai, CauHoi, true);
            }
        });

        $('.btnGuiCauHoi').off('click').on('click', function (e) {
            e.preventDefault();

            var HoTen = $('#HoTen').val();
            var Email = $('#EmailNguoiHoi').val();
            var SoDienThoai = $('#SoDienThoai').val();
            var CauHoi = $('#CauHoi').val();

            if (HoTen === '' || SoDienThoai === '' || CauHoi === '') {
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
            else {
                $(".btnGuiCauHoi").attr("disabled", "disabled");
                GuiCauHoijs.saveData(HoTen, Email, SoDienThoai, CauHoi, false);


            }
        });
    },
    saveData: function (hoten, email, sodienthoai, noidung, popup) {
        var d = new Date();
        var month = d.getMonth() + 1;
        var day = d.getDate();
        var model = {
            HoTen: hoten,
            Email: email,
            SoDienThoai: sodienthoai,
            NgheTuVan: noidung,
            KichHoat: false,
            NgayTao: (day < 10 ? '0' : '') + day + '/' + (month < 10 ? '0' : '') + month + '/' + d.getFullYear(),
            NguoiTao: 'Guest',
            NgaySua: null,
            NguoiSua: null,
            DaXoa: null,
            NgayXoa: null,
            NguoiXoa: null
        };
        $.ajax({
            url: '/Home/CreateDangKyTuVan/',
            data: { model: JSON.stringify(model).toString() },
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    $.toast({
                        heading: 'Thông báo',
                        text: 'Gửi liên hệ thành công!',
                        position: 'top-right',
                        loaderBg: '#ff6849',
                        icon: 'success',
                        hideAfter: 3000,
                        stack: 6
                    });

                    if (popup) {
                        GuiCauHoijs.resetFormPopup();
                        document.getElementById("tbpopup-1").classList.toggle("active");
                    }
                    else
                        setTimeout(function () {
                            GuiCauHoijs.resetForm();
                        }, 1000);
                }
            }
        });
    },
    resetForm: function () {
        $('#HoTen').val('');
        $('#EmailNguoiHoi').val('');
        $('#SoDienThoai').val('');
        $('#CauHoi').val('');

        $(".btnGuiCauHoi").removeAttr("disabled");
    },
    resetFormPopup: function () {
        $('#GROUP3967 #HoTen').val('');
        $('#GROUP3967 #EmailNguoiHoi').val('');
        $('#GROUP3967 #SoDienThoai').val('');
        $('#GROUP3967 #CauHoi').val('');

        $("#GROUP3967 #popDangKyBtn").removeAttr("disabled");
    }
};

GuiCauHoijs.init();