var GuiLienHejs = {
    init: function () {
        GuiLienHejs.registerEvent();
    },
    registerEvent: function () {
        $('.btnGuiLienHe').off('click').on('click', function (e) {
            e.preventDefault();
            var HoTen = $('#HoTen').val();
            var NoiDung = $('#NoiDung').val();
            var SoDienThoai = $('#SoDienThoai').val();


            if (HoTen === '' || NoiDung === '' || SoDienThoai === '') {
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
                $(".btnGuiLienHe").attr("disabled", "disabled");
                GuiLienHejs.saveData();
            }
        });
    },
    saveData: function () {
        var d = new Date();
        var month = d.getMonth() + 1;
        var day = d.getDate();
        var model = {
            HoTen: $('#HoTen').val(),
            NamSinh: $('#NamSinh').val(),
            SoDienThoai: $('#SoDienThoai').val(),
            Email: $('#Email').val(),
            DaLienHe: false,
            NoiDung: $('#NoiDung').val(),
            NgayTao: (day < 10 ? '0' : '') + day + '/' + (month < 10 ? '0' : '') + month + '/' + d.getFullYear(),
            NguoiTao: 'Guest',
            NgaySua: null,
            NguoiSua: null,
            DaXoa: null,
            NgayXoa: null,
            NguoiXoa: null
        };
        $.ajax({
            url: '/LienHe/CreateLienHe/',
            data: { model: JSON.stringify(model) },
            type: 'POST',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    $.toast({
                        heading: 'Thông báo',
                        text: 'Liên hệ thành công!',
                        position: 'top-right',
                        loaderBg: '#ff6849',
                        icon: 'success',
                        hideAfter: 3000,
                        stack: 6
                    });

                    setTimeout(function () {
                        GuiLienHejs.resetForm();
                    }, 1000);
                }
            }
        });
    },
    resetForm: function () {
        $('#HoTen').val('');
        $('#NamSinh').val('');
        $('#SoDienThoai').val('');
        $('#Email').val('');
        $('#NoiDung').val('');
        $(".btnGuiLienHe").removeAttr("disabled");
    }
};

GuiLienHejs.init();