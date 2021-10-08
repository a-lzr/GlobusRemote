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

    ///*modalshow*/
    //$(".showdialog").click(function (e) {
    //    if ($(this).tagName = "A") {
    //        e.preventDefault(); //  отменяет выполнение события
    //        $.get(this.href, function (data) {
    //            $('#dialogContent').html(data);
    //            $('#modDialog').modal('show');
    //        });
    //    }
    //    else {
    //        $.get(this.src, function (data) {
    //            $('#dialogContent').html(data);
    //            $('#modDialog').modal('show');
    //        });
    //    }
    //});

    /*logindialog*/
    //$(".loginDialog").click(function (e) {
    //    $.get(this.src, function (data) {
    //        $("#loginFormContent").html(data);
    //        /*$("#loginDialog").modal("show");*/
    //    });
    //});

    /*adddialog*/
    //$(".addDialog").click(function (e) {
    //    $(".mode-edit").addClass("hidden");
    //    $(".mode-add").removeClass("hidden");
    //    $.get(this.src, function (data) {
    //        $("#editFormContent").html(data);
    //        $("#editDialog").modal("show");
    //    });
    //});

    /*editdialog*/
    //$(".editDialog").click(function (e) {
    //    $(".mode-add").addClass("hidden");
    //    $(".mode-edit").removeClass("hidden");
    //    $.get(this.src, function (data) {
    //        $("#editFormContent").html(data);
    //        $("#editDialog").modal("show");
    //    });
    //});

    /*uploadfile*/
//    var dropZone = $('#upload-container');

//    $('#file-input').focus(function () {
//        $('label').addClass('focus');
//    })
//        .focusout(function () {
//            $('label').removeClass('focus');
//        });

//    dropZone.on('drag dragstart dragend dragover dragenter dragleave drop', function () {
//        return false;
//    });

//    dropZone.on('dragover dragenter', function () {
//        dropZone.addClass('dragover');
//    });

//    dropZone.on('dragleave', function (e) {
//        dropZone.removeClass('dragover');
//    });

//    dropZone.on('drop', function (e) {
//        dropZone.removeClass('dragover');
//        let files = e.originalEvent.dataTransfer.files;
///*        sendFiles(files);*/
//    });

    //$("#uploadContainer").on("dragenter", function (evt) {
    //    evt.preventDefault();
    //    evt.stopPropagation();
    //});

    //$("#uploadContainer").on("dragover", function (evt) {
    //    evt.preventDefault();
    //    evt.stopPropagation();
    //});

    //$("#uploadContainer").on("drop", function (evt) {
    //    evt.preventDefault();
    //    evt.stopPropagation();
    //    var files = evt.originalEvent.dataTransfer.files;
    //    var fileNames = "";
    //    if (files.length > 0) {
    //        fileNames += "Uploading <br/>"
    //        for (var i = 0; i < files.length; i++) {
    //            fileNames += files[i].name + "<br />";
    //        }
    //    }
    //    $("#fileBasket").html(fileNames)

    //    var data = new FormData();
    //    for (var i = 0; i < files.length; i++) {
    //        data.append(files[i].name, files[i]);
    //    }
    //    $.ajax({
    //        type: "POST",
    //        url: "/home/UploadFiles",
    //        contentType: false,
    //        processData: false,
    //        data: data,
    //        success: function (message) {
    //            $("#fileBasket").html(message);
    //        },
    //        error: function () {
    //            $("#fileBasket").html
    //                ("There was error uploading files!");
    //        },
    //        beforeSend: function () {
    //            $("#progress").show();
    //        },
    //        complete: function () {
    //            $("#progress").hide();
    //        }
    //    });
    //});

    //$(".editDialog").click(function (e) {
    //    $(".mode-add").addClass("hidden");
    //    $(".mode-edit").removeClass("hidden");
    //    $.get(this.src, function (data) {
    //        $("#editFormContent").html(data);
    //        $("#editDialog").modal("show");
    //    });
    //});

    /*editdialog*/
    //$(".editDialog").click(function (e) {
    //    $(".mode-add").addClass("hidden");
    //    $(".mode-edit").removeClass("hidden");
    //    $.get(this.src, function (data) {
    //        $("#editFormContent").html(data);
    //        $("#editDialog").modal("show");
    //    });
    //});

    //function OnBegin() {
    //    $("#progress").show();
    //}

    //function OnFailure(response) {
    //    alert("Error occured.");
    //}

    //function OnSuccess(response) {
    //    alert("Error successed.");
    //    //var message = "Name: " + response.Name;
    //    //message += "\nCountry: " + response.Country;
    //    //alert(message);
    //}

    //function OnComplete() {
    //    $("#progress").hide();
    //}

    //function bindForm(dialog) {
    //    $('form', dialog).submit(function () {
    //        $.ajax({
    //            url: this.action,
    //            type: this.method,
    //            data: $(this).serialize(),
    //            success: function (result) {
    //                if (result.success) {
    //                    $('#myModal').modal('hide');
    //                    $('#replacetarget').load(result.url); //  Load data from the server and place the returned HTML into the matched element
    //                } else {
    //                    $('#myModalContent').html(result);
    //                    bindForm(dialog);
    //                }
    //            }
    //        });
    //        return false;
    //    });
    //}
});