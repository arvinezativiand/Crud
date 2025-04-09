$(document).ready(function () {
    var accessLevel = "@Model";
    if (accessLevel === "AdminBasic") {
        $("#addUserBtn").prop("disabled", true).css("opacity", "0.5");
    }

    $("#addUserBtn").click(function () {
        $("#addUserModal").modal("toggle");
    });

    $("#showUsersBtn").click(function () {
        $('#usersTable').show();
        if ($.fn.DataTable.isDataTable('#usersTable')) {
            $('#usersTable').DataTable().destroy();
        }
        $('#usersTable').DataTable({
            ajax: {
                url: "/User/GetExternalUsers",
                type: "POST",
                contentType: "application/json",
                data: function (d) {
                    return JSON.stringify(d);
                },
                dataSrc: function (json) {
                    return json.data;
                }
            },
            columns: [
                { data: "id", className: "text-center" },
                { data: "email", className: "text-start" },
                {
                    data: "fullName",
                    render: function (data, type, row) {
                        return `<b>${data}</b>`;
                    }
                },
                { data: "city" }
            ],
            language: {
                url: "https://cdn.datatables.net/plug-ins/1.13.6/i18n/fa.json"
            },
            serverSide: true,
            searching: true,
            ordering: true,
            paging: true
        });
    });

    $("#confirmAddUser").click(function () {
        const userData = {
            FullName: DOMPurify.sanitize($("#fullName").val().trim()),
            IdNumber: DOMPurify.sanitize($("#idNumber").val().trim()),
            UserName: DOMPurify.sanitize($("#userName").val().trim()),
            Password: $("#password").val()
        };

        $.ajax({
            url: "/User/AddUser",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(userData),
            success: function (response) {
                if (response.success) {
                    $("#addUserModal").modal("toggle");
                    $("#addUserForm")[0].reset();
                    alert("کاربر با موفقیت اضافه شد!");

                    if ($.fn.DataTable.isDataTable('#usersTable')) {
                        $('#usersTable').DataTable().ajax.reload();
                    }
                }
            },
            error: function (xhr) {
                alert("خطا در افزودن کاربر: " + xhr.responseText);
            }
        });
    });
});