$(document).ready(function () {
    $('.editDialog').on('click', function (e) {
        e.preventDefault();
        openModal(this.src, $('#editModalContent'));
    });

    $('.deleteDialog').on('click', function (e) {
        e.preventDefault();
        deleteItem(this.form);
    });

    function openModal(url, item) {
        $.ajax({
            url: url,
            type: "GET",
            success: function (data, status) {
                item.html(data);
                $('#editModal').modal({
                    keyboard: true
                }, 'show');
                bindForm();
            },
            error: function (jqXHR, exception) {
                alert(getError(jqXHR, exception));
                location.reload();
            }
        });
    }

    function deleteItem(form) {
        var data = new FormData(form);
        $.ajax({
            url: form.action,
            type: form.method,
            contentType: false,
            processData: false,
            data: data,
            success: function (data, status) {
                if (data == "") {
                    location.reload();
                }
            },
            error: function (jqXHR, exception) {
                var msg = getError(jqXHR, exception);
                alert(msg);
            }
        });
    }

    function bindForm() {
        updateFile();
        $('#editForm').submit(function () {
            var data = new FormData(this);
            $.ajax({
                url: this.action,
                type: this.method,
                contentType: false,
                processData: false,
                data: data,
                success: function (data, status) {
                    if (data == "") {
                        $('#editModal').modal('hide');
                        location.reload();
                    }
                    else {
                        $('#editModalContent').html(data);
                        bindForm();
                    }
                },
                error: function (jqXHR, exception) {
                    var msg = getError(jqXHR, exception);
                    $('#alertTitle').html(msg);
                    $('#alertDetails').html(jqXHR.responseText);
                    $('#alertEdit').removeClass("hidden");

                    $("#alertTitle").click(function () {
                        $('#alerCollapse').toggleClass("show");
                    });
                }
            });
        });
    }

    function getDouble(value) {
        return value.replace(".", (0.1).toLocaleString().substring(1, 2));
    }

    function getError(jqXHR, exception) {
        var msg = '';
        if (jqXHR.status === 0) {
            msg = 'Not connect.\n Verify Network.';
        } else if (jqXHR.status == 404) {
            msg = 'Requested page not found. [404]';
        } else if (jqXHR.status == 500) {
            msg = 'Internal Server Error [500].';
        } else if (exception === 'parsererror') {
            msg = 'Requested JSON parse failed.';
        } else if (exception === 'timeout') {
            msg = 'Time out error.';
        } else if (exception === 'abort') {
            msg = 'Ajax request aborted.';
        } else {
            msg = 'Uncaught Error.\n' + jqXHR.responseText;
        }
        return msg;
    }

    function updateFile() {
        let fields = document.querySelectorAll('#file');
        Array.prototype.forEach.call(fields, function (input) {
            let label = input.nextElementSibling,
                labelVal = label.querySelector('.fileTitle').innerText;

            input.addEventListener('change', function (e) {
                let countFiles = '';
                if (this.files && this.files.length >= 1) {
                    countFiles = this.files.length;
                }

                if (countFiles) {
                    var fileName = this.files[0].name;
                    var extention = fileName.split('.').pop();
                    var name = fileName.substr(0, fileName.length - extention.length - 1);
                    if (fileName.length > 30) {
                        label.querySelector('.fileTitle').innerText = name.substr(0, 30) + '...' + name.substr(name.length - 3, 3) + '.' + extention;
                    }
                    else {
                        label.querySelector('.fileTitle').innerText = fileName;
                    }
                    document.getElementById('nameField').value = fileName.substr(0, fileName.length - extention.length - 1);
                    document.getElementById('extentionField').value = extention;
                    document.getElementById('Fsize').value = this.files[0].size;
                    document.getElementById('sizeInKbField').value = getDouble((this.files[0].size / 1024).toFixed(2));
                }
                else {
                    label.querySelector('.fileTitle').innerText = labelVal;
                    document.getElementById('nameField').value = "";
                    document.getElementById('extentionField').value = "";
                    document.getElementById('Fsize').value = 0;
                    document.getElementById('sizeInKbField').value = 0;
                }
            });
        });
    }
});