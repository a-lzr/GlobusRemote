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

    let fields = document.querySelectorAll('#file');
    Array.prototype.forEach.call(fields, function (input) {
        let label = input.nextElementSibling,
            labelVal = label.querySelector('.fileName').innerText;

        input.addEventListener('change', function (e) {
            let countFiles = '';
            if (this.files && this.files.length >= 1) {
                countFiles = this.files.length;
            }

            if (countFiles) {
                label.querySelector('.fileName').innerText = this.files[0].name;
            }
            else {
                label.querySelector('.fileName').innerText = labelVal;
            }
        });
    });

    var x = 0;

    $("#fileBasket").on("dragenter", function (evt) {
        evt.preventDefault();
        evt.stopPropagation();
    });

    $("#fileBasket").on("dragover", function (evt) {
        evt.preventDefault();
        evt.stopPropagation();
    });

    $("#fileBasket").on("drop", function (evt) {
        evt.preventDefault();
        evt.stopPropagation();
        var files = evt.originalEvent.dataTransfer.files;
        var fileNames = "";
        if (files.length > 0) {
            fileNames += "Uploading <br/>"
            for (var i = 0; i < files.length; i++) {
                fileNames += files[i].name + "<br />";
            }
        }
        //$("#upload-container").html(fileNames)

        //var data = new FormData();
        //for (var i = 0; i < files.length; i++) {
        //    data.append(files[i].name, files[i]);
        //}
        //$.ajax({
        //    type: "POST",
        //    url: "/home/UploadFiles",
        //    contentType: false,
        //    processData: false,
        //    data: data,
        //    success: function (message) {
        //        $("#fileBasket").html(message);
        //    },
        //    error: function () {
        //        $("#fileBasket").html
        //            ("There was error uploading files!");
        //    },
        //    beforeSend: function () {
        //        $("#progress").show();
        //    },
        //    complete: function () {
        //        $("#progress").hide();
        //    }
        //});
    });
});