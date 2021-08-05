var GuiCauHoijs = {
    init: function () {
        GuiCauHoijs.registerEvent();
    },
    registerEvent: function () {       
        $('.btnGuiCauHoi').off('click').on('click', function (e) {
            e.preventDefault();

            var HoTen = $('#HoTen').val();
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
                GuiCauHoijs.saveData();
            }
        });
    },
    saveData: function () {
        var d = new Date();
        var month = d.getMonth() + 1;
        var day = d.getDate();
        var model = {
            HoTen: $('#HoTen').val(),
            Email: $('#EmailNguoiHoi').val(),
            SoDienThoai: $('#SoDienThoai').val(),
            NgheTuVan: $('#CauHoi').val(),
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
    }
};

GuiCauHoijs.init();