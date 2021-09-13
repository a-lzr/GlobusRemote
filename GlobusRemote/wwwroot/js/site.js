// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//$("#menu-toggle").click(function (e) {
//    e.preventDefault();
//    $("#wrapper").toggleClass("toggled");
//    //$('#menu-toggle-hide').toggleClass("hidden");
//    //$('#menu-toggle-show').toggleClass("hidden");
//});

$(document).ready(function () {
    const langCookie = 'lang';
    const langRu = 'RU';
    const langEn = 'EN';

    var cookies = document.cookie.split('; ');
    var filterCookies = cookies.filter(x => x.split('=')[0] == langCookie);
    var srcLang = '/img/lang-ru.png';

    if (filterCookies.length > 0) {
        var currentLang = filterCookies[0].split('=')[1];
        switch (currentLang) {
            case langRu:
                srcLang = '/img/lang-ru.png';
                $(".lang-ru").addClass("hidden");
                $(".lang-en").removeClass("hidden");
                break;
            case langEn:
                srcLang = '/img/lang-en.png';
                $(".lang-ru").removeClass("hidden");
                $(".lang-en").addClass("hidden");
                break;
            default:
                $(".lang-ru").removeClass("hidden");
                $(".lang-en").removeClass("hidden");
                break;
        }
    }
    else
    {
        $(".lang-ru").removeClass("hidden");
        $(".lang-en").removeClass("hidden");
    }

    switch (location.pathname.split('/')[1]) {
        case "Admin":
            $(".area-mobile").removeClass("active");
            $(".area-mobilescenarios").removeClass("active");
            $(".area-mobilebooks").removeClass("active");
            $(".area-admin .sidebar-submenu").slideDown(0);
            $(".area-admin").addClass("active");
            break;
        case "Mobile":
            $(".area-admin").removeClass("active");
            $(".area-mobilescenarios").removeClass("active");
            $(".area-mobilebooks").removeClass("active");
            $(".area-mobile .sidebar-submenu").slideDown(0);
            $(".area-mobile").addClass("active");
            break;
        case "MobileScenarios":
            $(".area-admin").removeClass("active");
            $(".area-mobile").removeClass("active");
            $(".area-mobilebooks").removeClass("active");
            $(".area-mobilescenarios .sidebar-submenu").slideDown(0);
            $(".area-mobilescenarios").addClass("active");
            break;
        case "MobileBooks":
            $(".area-admin").removeClass("active");
            $(".area-mobile").removeClass("active");
            $(".area-mobilescenarios").removeClass("active");
            $(".area-mobilebooks .sidebar-submenu").slideDown(0);
            $(".area-mobilebooks").addClass("active");
            break;
        default:
            $(".area-admin").removeClass("active");
            $(".area-mobile").removeClass("active");
            $(".area-mobilescenarios").removeClass("active");
            $(".area-mobilebooks").removeClass("active");
            break;
    }

    /*current language*/
    $("#lang-current").attr("src", srcLang);

    /*change language*/
    $("#lang-ru").click(function () {
        document.cookie = langCookie + '=' + langRu + '; path=/;';
        location.reload();
    });
    $("#lang-en").click(function () {
        document.cookie = langCookie + '=' + langEn + '; path=/;';
        location.reload();
    });

    /*sidebar*/
    $("#close-sidebar").click(function () {
        $(".page-wrapper").removeClass("toggled");
    });
    $("#show-sidebar").click(function () {
        $(".page-wrapper").addClass("toggled");
    });
    $("#collapse-sidebar").click(function () {
        $(".page-wrapper").toggleClass("collapsed");
    });
    $(".sidebar-dropdown > a").click(function () {
        var active = $(this).parent().hasClass("active");
        $(".sidebar-submenu").slideUp(200);
        $(".sidebar-dropdown").removeClass("active");
        if (!active) {
            $(this)
                .next(".sidebar-submenu")
                .slideDown(200);
            $(this)
                .parent()
                .addClass("active");
        }
    });

    /*controldata*/
    $("#search-field").on('input', function () {
        if ($(this).val().length > 0) {
            $("#search-submit").removeClass("disabled");
        }
        else {
            $("#search-submit").addClass("disabled");
        }
    });

    /*modalshow*/
    $(".showdialog").click(function (e) {
        if ($(this).tagName = "A") {
            e.preventDefault(); //  отменяет выполнение события
            $.get(this.href, function (data) {
                $('#dialogContent').html(data);
                $('#modDialog').modal('show');
            });
        }
        else {
            $.get(this.src, function (data) {
                $('#dialogContent').html(data);
                $('#modDialog').modal('show');
            });
        }
    });

    /*modaledit*/
    $(".editdialog").click(function (e) {
        $.get(this.src, function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });

    //$("#btnSubmit").click(function () {
    //    $.ajax({
    //        url: 'Home/AddCustomer',
    //        data: {},
    //        type: 'POST',
    //        dataType: 'html',
    //        contentType: "application/json; charset=utf-8",
    //        success: function (response) {
    //            $("#dvPartial").html(response);
    //            $("#MyPopup").modal("show");
    //        }
    //    });
    //});

    //$(".viewDialog").click(function (e) {
    //    e.preventDefault();

    //    $("<div id='dialogContent'></div>")
    //        .addClass("dialog")
    //        .appendTo("body")
    //        .load(this.href)
    //        .dialog({
    //            title: $(this).attr("data-dialog-title"),
    //            close: function () { $(this).remove() },
    //            modal: true,
    //            buttons: {
    //                "Сохранить": function () {
    //                    //$.ajax({
    //                    //    url: "@Url.Action("Create", "Home")",
    //                    //    type: "POST",
    //                    //    data: $('form').serialize(),
    //                    //    datatype: "json",
    //                    //    success: function (result) {

    //                    //        $("#dialogContent").html(result);
    //                    //    }
    //                    //});
    //                }
    //            }
    //        });
    //});
});